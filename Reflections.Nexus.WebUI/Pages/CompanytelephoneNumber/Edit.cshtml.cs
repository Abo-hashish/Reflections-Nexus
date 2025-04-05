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
using M=Reflections.Nexus.WebUI.Models;

namespace Reflections.Nexus.WebUI.Pages.CompanytelephoneNumber
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
        public M.CompanyTelephoneNumber CompanyTelephoneNumber { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companytelephonenumber =  await _context.CompanyEmployeeTelephoneNumber
                
                .Include(c => c.Company)
                .Include(c => c.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companytelephonenumber == null)
            {
                return NotFound();
            }
            CompanyTelephoneNumber = companytelephonenumber;
           ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
           ViewData["TypeId"] = new SelectList(_context.PhoneNumberTypes, "Id", "Value");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var NameValidation = _context.CompanyEmployeeTelephoneNumber.Count(x => x.Id != CompanyTelephoneNumber.Id && x.PhoneNumber == CompanyTelephoneNumber.PhoneNumber);
            if (NameValidation != 0)
            {
                ModelState.AddModelError("CompanyTelephoneNumber.PhoneNumber", "Company Telephone Number already exists");
                return Page();
            }

            var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            CompanyTelephoneNumber.Updated = DateTime.Now;
            CompanyTelephoneNumber.UpdatedBy = User.Id;



            if (!ModelState.IsValid)
            {
                ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
                ViewData["TypeId"] = new SelectList(_context.PhoneNumberTypes, "Id", "Value");
                return Page();
            }

            _context.Attach(CompanyTelephoneNumber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyTelephoneNumberExists(CompanyTelephoneNumber.Id))
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

        private bool CompanyTelephoneNumberExists(int id)
        {
            return _context.CompanyEmployeeTelephoneNumber.Any(e => e.Id == id);
        }
    }
}
