using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Reflections.Nexus.WebUI.Services;
using Reflections.Nexus.WebUI.Data;
using M=Reflections.Nexus.WebUI.Models;

namespace Reflections.Nexus.WebUI.Pages.EmployeeTelephoneNumber
{
    public class DeleteModel : PageModel
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;

        public DeleteModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public M.EmployeeTelephoneNumber EmployeeTelephoneNumber { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeetelephonenumber = await _context.EmployeeTelephoneNumber
                .Include(e => e.Employee)
                .Include(e => e.Type).FirstOrDefaultAsync(m => m.Id == id);

            if (employeetelephonenumber == null)
            {
                return NotFound();
            }
            else
            {
                EmployeeTelephoneNumber = employeetelephonenumber;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeetelephonenumber = await _context.EmployeeTelephoneNumber.FindAsync(id);
            if (employeetelephonenumber != null)
            {
                EmployeeTelephoneNumber = employeetelephonenumber;
                _context.EmployeeTelephoneNumber.Remove(EmployeeTelephoneNumber);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
