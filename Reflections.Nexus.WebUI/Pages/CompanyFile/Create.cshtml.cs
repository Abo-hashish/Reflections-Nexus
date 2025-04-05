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
using System.Text.RegularExpressions;

namespace Reflections.Nexus.WebUI.Pages.CompanyFile
{
    [Authorize(Roles = "Administrator,MD,CEO")]
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
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            ViewData["FileTypeId"] = new SelectList(_context.CompanyFileTypes, "Id", "Value");
            return Page();
        }

        [BindProperty]
        public M.CompanyFile CompanyFile { get; set; } = default!;

        [BindProperty]
        public IFormFile company_file { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult>
            OnPostAsync()
        {

            var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            CompanyFile.Created = DateTime.Now;
            CompanyFile.CreatedBy = User.Id;
            CompanyFile.Updated = DateTime.Now;
            CompanyFile.UpdatedBy = User.Id;

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.CompanyFiles.Add(CompanyFile);
            //await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");

            if (company_file!= null)
            {
                string[] permittedExtensions = { ".pdf", ".jpg", ".HEIC" };
                var ext = Path.GetExtension(company_file.FileName).ToLowerInvariant();

                if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                {
                    ModelState.AddModelError("Upload", "The file extension is invalid. Only .png, .jpg, and .pdf are allowed.");
                    ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
                    ViewData["FileTypeId"] = new SelectList(_context.CompanyFileTypes, "Id", "Value");
                    return Page();
                }



                var secureFileName = Regex.Replace(Guid.NewGuid().ToString(), "[^0-9A-Za-z_-]", "") + ext;
                var filePath = Path.Combine(_environment.WebRootPath, "uploads", "CompanyFile", secureFileName);

                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await company_file.CopyToAsync(fileStream);
                }

                CompanyFile.Url = $"/uploads/CompanyFile/{secureFileName}";

                _context.CompanyFiles.Add(CompanyFile);
                await _context.SaveChangesAsync();

            }
            return RedirectToPage("./Index");
        }

    }
}
