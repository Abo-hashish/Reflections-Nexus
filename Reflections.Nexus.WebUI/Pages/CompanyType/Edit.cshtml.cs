using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reflections.Nexus.WebUI.Services;
using Reflections.Nexus.WebUI.Data;
using M = Reflections.Nexus.WebUI.Models;

namespace Reflections.Nexus.WebUI.Pages.CompanyType
{
    public class EditModel : PageModel
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;
        private readonly UserResolverService _userService;

        public EditModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context, UserResolverService userService)
        {
            _context = context;
            _userService = userService;
        }

        [BindProperty]
        public M.CompanyType CompanyType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companytype =  await _context.CompanyTypes
                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companytype == null)
            {
                return NotFound();
            }
            CompanyType = companytype;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var NameValidation = _context.CompanyTypes.Count(x => x.Id != CompanyType.Id && x.Value == CompanyType.Value);
            if (NameValidation != 0)
            {
                ModelState.AddModelError("CompanyType.Value", "Company Type already exists");
                return Page();
            }

            //var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            //CompanyType.Updated = DateTime.Now;
            //CompanyType.UpdatedBy = User.Id;
            //CompanyType.UpdatedByNavigation = User;



            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CompanyType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyTypeExists(CompanyType.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CompanyTypeExists(int id)
        {
            return _context.CompanyTypes.Any(e => e.Id == id);
        }
    }
}
