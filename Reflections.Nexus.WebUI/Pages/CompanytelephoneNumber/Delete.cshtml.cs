using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Reflections.Nexus.WebUI.Services;
using Reflections.Nexus.WebUI.Data;
using M = Reflections.Nexus.WebUI.Models;

namespace Reflections.Nexus.WebUI.Pages.CompanytelephoneNumber
{
    public class DeleteModel : PageModel
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;

        public DeleteModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public M.CompanyTelephoneNumber CompanyTelephoneNumber { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companytelephonenumber = await _context.CompanyEmployeeTelephoneNumber
                .Include(c => c.Company)
                .Include(c => c.Type).FirstOrDefaultAsync(m => m.Id == id);

            if (companytelephonenumber == null)
            {
                return NotFound();
            }
            else
            {
                CompanyTelephoneNumber = companytelephonenumber;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companytelephonenumber = await _context.CompanyEmployeeTelephoneNumber.FindAsync(id);
            if (companytelephonenumber != null)
            {
                CompanyTelephoneNumber = companytelephonenumber;
                _context.CompanyEmployeeTelephoneNumber.Remove(CompanyTelephoneNumber);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
