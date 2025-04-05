using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Reflections.Nexus.WebUI.Code;
using Reflections.Nexus.WebUI.Services;
using Reflections.Nexus.WebUI.Data;
using M = Reflections.Nexus.WebUI.Models;
using Microsoft.IdentityModel.Tokens;
using Reflections.Nexus.WebUI.Models;
using System.Text.RegularExpressions;

namespace Reflections.Nexus.WebUI.Pages.EmployeeFile
{
    [Authorize(Roles = "Administrator,hr,CEO,MD")]
    public class CreateModel : BasePageModel<CreateModel>
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;
        private readonly UserResolverService _userService;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context, UserResolverService userService, IWebHostEnvironment environment)
        {
            _context = context;
            _userService = userService;
            _environment = environment;
        }

        public IActionResult OnGet()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName");
            ViewData["FileTypeId"] = new SelectList(_context.EmployeeFileTypes, "Id", "Value");
            return Page();
        }

        [BindProperty]
        public M.EmployeeFile EmployeeFile { get; set; } = default!;

        [BindProperty]
        public IFormFile employee_file { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult>
            OnPostAsync()
        {

            var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            EmployeeFile.Created = DateTime.Now;
            EmployeeFile.CreatedBy = User.Id;
            EmployeeFile.Updated = DateTime.Now;
            EmployeeFile.UpdatedBy = User.Id;

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.EmployeeFiles.Add(EmployeeFile);
            //await _context.SaveChangesAsync();
            if (employee_file != null)
            {
                string[] permittedExtensions = { ".pdf", ".jpg", ".heic", ".png" };
                var ext = Path.GetExtension(employee_file.FileName).ToLowerInvariant();

                if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                {
                    ModelState.AddModelError("Upload", "The file extension is invalid. Only .png, .jpg, and .pdf are allowed.");
                    ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName");
                    ViewData["FileTypeId"] = new SelectList(_context.EmployeeFileTypes, "Id", "Value");
                    return Page();
                }

                //var uniqueIdentifier = Guid.NewGuid().ToString(); // Generate a unique identifier
                //var filePath = Regex.Replace(EmployeeFile.Id.ToString(), "[^0-9A-Za-z_-]", "") + "_" + uniqueIdentifier + ext;

                //using (var fileStream = new FileStream(filePath, FileMode.Create))
                //{
                //    await employee_file.CopyToAsync(fileStream);
                //}

                //EmployeeFile.FileUrl = $"/uploads/EmployeeFile/{filePath}";

                //_context.EmployeeFiles.Add(EmployeeFile);
                //await _context.SaveChangesAsync();



                var secureFileName = Regex.Replace(Guid.NewGuid().ToString(), "[^0-9A-Za-z_-]", "") + ext;
                var filePath = Path.Combine(_environment.WebRootPath, "uploads", "EmployeeFile", secureFileName);

                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await employee_file.CopyToAsync(fileStream);
                }

                EmployeeFile.FileUrl = $"/uploads/EmployeeFile/{secureFileName}";

                _context.EmployeeFiles.Add(EmployeeFile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
