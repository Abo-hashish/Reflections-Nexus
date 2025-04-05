using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Reflections.Nexus.WebUI.Code;
using Reflections.Nexus.WebUI.Data;
using Reflections.Nexus.WebUI.Services;
using M = Reflections.Nexus.WebUI.Models;
using Microsoft.AspNetCore.Authorization;

namespace Reflections.Nexus.WebUI.Pages.Company
{
    [Authorize(Roles = "Administrator,MD,CEO")] 
    public class CreateModel : BasePageModel<CreateModel>
    {
        private readonly ApplicationDbContext _context;
        private readonly UserResolverService _userService;
        private readonly IWebHostEnvironment _environment;


        public CreateModel(ApplicationDbContext context, UserResolverService userService, IWebHostEnvironment environment)
        {
            _context = context;
            _userService = userService;
            _environment = environment;
        }

        public IActionResult OnGet()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            ViewData["CompanyTypeId"] = new SelectList(_context.CompanyTypes, "Id", "Value");
            ViewData["IndustryId"] = new SelectList(_context.Industries, "Id", "Value");
            ViewData["ParentId"] = new SelectList(_context.Companies, "Id", "Name"); 
            return Page();
        }

        [BindProperty]
        public M.Company Company { get; set; } = default!;

        [BindProperty]
        public IFormFile companyLogo { get; set; } = default!; 

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (companyLogo != null)
            {
                string[] permittedExtensions = { ".png", ".jpg" };
                var ext = Path.GetExtension(companyLogo.FileName).ToLowerInvariant();

                if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                {
                    ModelState.AddModelError("Upload", "The file extension is invalid. Only .png and .jpg are allowed.");
                    ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
                    ViewData["CompanyTypeId"] = new SelectList(_context.CompanyTypes, "Id", "Value");
                    ViewData["IndustryId"] = new SelectList(_context.Industries, "Id", "Value");
                    ViewData["ParentId"] = new SelectList(_context.Companies, "Id", "Name");
                    return Page();
                }

                var secureFileName = Regex.Replace(Company.Name.ToLower(), "[^0-9A-Za-z_-]", "") + ext;
                var filePath = Path.Combine(_environment.WebRootPath, "uploads", "Company", secureFileName);

                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!); // Ensure the directory exists

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await companyLogo.CopyToAsync(fileStream);
                }

                Company.LogoUrl = $"/uploads/Company/{secureFileName}";

                var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

                Company.CreatedBy = User.Id;
                Company.UpdatedBy = User.Id;


                if (!ModelState.IsValid)
                {
                    ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
                    ViewData["CompanyTypeId"] = new SelectList(_context.CompanyTypes, "Id", "Value");
                    ViewData["IndustryId"] = new SelectList(_context.Industries, "Id", "Value");
                    ViewData["ParentId"] = new SelectList(_context.Companies, "Id", "Name");
                    return Page();
                }

                if (string.IsNullOrWhiteSpace(Company.Name))
                {
                    ModelState.AddModelError("Company.Name", "Company Name is required.");
                    return Page();
                }

                if (_context.Companies.Any(c => c.Name == Company.Name))
                {
                    ModelState.AddModelError("Company.Name", "A company with this name already exists.");
                    return Page();
                }






                _context.Companies.Add(Company);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
