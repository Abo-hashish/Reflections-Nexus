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

namespace Reflections.Nexus.WebUI.Pages.EmployeeFile
{
    public class DeleteModel : PageModel
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;

        public DeleteModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public M.EmployeeFile EmployeeFile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeefile = await _context.EmployeeFiles
                .Include(e => e.Employee)
                .Include(e => e.FileType).FirstOrDefaultAsync(m => m.Id == id);

            if (employeefile == null)
            {
                return NotFound();
            }
            else
            {
                EmployeeFile = employeefile;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeefile = await _context.EmployeeFiles.FindAsync(id);
            if (employeefile != null)
            {
                EmployeeFile = employeefile;
                _context.EmployeeFiles.Remove(EmployeeFile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
