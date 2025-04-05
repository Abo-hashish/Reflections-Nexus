using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reflections.Nexus.WebUI.Services;
using Reflections.Nexus.WebUI.Data;
using Microsoft.AspNetCore.Hosting;
using M=Reflections.Nexus.WebUI.Models;

namespace Reflections.Nexus.WebUI.Pages.Company
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserResolverService _userService;
        private readonly IWebHostEnvironment _environment;

        public EditModel(ApplicationDbContext context, UserResolverService userService, IWebHostEnvironment environment)
        {
            _context = context;
            _userService = userService;
            _environment = environment;
        }

        [BindProperty]
        public M.Company Company { get; set; } = default!;

        [BindProperty]
        public IFormFile companyLogo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .Include(c => c.City)
                .Include(c => c.CompanyType)
                .Include(c => c.Industry)
                .Include(c => c.Parent)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (company == null)
            {
                return NotFound();
            }

            Company = company;
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            ViewData["CompanyTypeId"] = new SelectList(_context.CompanyTypes, "Id", "Value");
            ViewData["IndustryId"] = new SelectList(_context.Industries, "Id", "Value");
            ViewData["ParentId"] = new SelectList(_context.Companies, "Id", "Address");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Check for duplicate company name
            var isNameDuplicate = _context.Companies
                .Any(x => x.Id != Company.Id && x.Name.ToLower() == Company.Name.ToLower());

            if (isNameDuplicate)
            {
                ModelState.AddModelError("Company.Name", "Company name already exists");
                return Page();
            }

            var user = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            Company.Updated = DateTime.Now;
            Company.UpdatedBy = user.Id;

            // Handle logo file upload
            if (companyLogo != null)
            {
                string[] permittedExtensions = { ".png", ".jpg" };
                var extension = Path.GetExtension(companyLogo.FileName)?.ToLowerInvariant();

                if (!permittedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("companyLogo", "Invalid file format. Only .png and .jpg are allowed.");
                    return Page();
                }

                var secureFileName = Regex.Replace(Company.Name.ToLower(), "[^0-9A-Za-z_-]", "") + extension;
                var uploadPath = Path.Combine(_environment.WebRootPath ?? throw new InvalidOperationException("WebRootPath is not configured."), "uploads", "Company");
                var filePath = Path.Combine(uploadPath, secureFileName);

                Directory.CreateDirectory(uploadPath);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await companyLogo.CopyToAsync(fileStream);
                }

                Company.LogoUrl = $"/uploads/Company/{secureFileName}";
            }
            else
            {
                // Retain old logo URL if no new logo is uploaded
                var existingCompany = await _context.Companies.AsNoTracking().FirstOrDefaultAsync(c => c.Id == Company.Id);
                if (existingCompany != null)
                {
                    Company.LogoUrl = existingCompany.LogoUrl;
                }
            }

            // Use Update or Attach with detaching old instances
            var existingEntity = _context.ChangeTracker.Entries<M.Company>()
                .FirstOrDefault(e => e.Entity.Id == Company.Id);

            if (existingEntity != null)
            {
                _context.Entry(existingEntity.Entity).State = EntityState.Detached;
            }

            _context.Update(Company);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(Company.Id))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("./Index");
        }


        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
