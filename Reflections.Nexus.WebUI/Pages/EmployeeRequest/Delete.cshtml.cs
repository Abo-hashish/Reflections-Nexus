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

namespace Reflections.Nexus.WebUI.Pages.EmployeeRequest
{
    public class DeleteModel : PageModel
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;

        public DeleteModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public M.EmployeeRequest EmployeeRequest { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeerequest = await _context.EmployeeRequests
                .Include(e => e.Employee)
                .Include(e => e.Notification)
                .Include(e => e.Status).FirstOrDefaultAsync(m => m.Id == id);

            if (employeerequest == null)
            {
                return NotFound();
            }
            else
            {
                EmployeeRequest = employeerequest;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeerequest = await _context.EmployeeRequests.FindAsync(id);
            if (employeerequest != null)
            {
                EmployeeRequest = employeerequest;
                _context.EmployeeRequests.Remove(EmployeeRequest);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
