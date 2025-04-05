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

namespace Reflections.Nexus.WebUI.Pages.EmployeeFileType
{
    public class DeleteModel : PageModel
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;

        public DeleteModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public M.EmployeeFileType EmployeeFileType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeefiletype = await _context.EmployeeFileTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (employeefiletype == null)
            {
                return NotFound();
            }
            else
            {
                EmployeeFileType = employeefiletype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeefiletype = await _context.EmployeeFileTypes.FindAsync(id);
            if (employeefiletype != null)
            {
                EmployeeFileType = employeefiletype;
                _context.EmployeeFileTypes.Remove(EmployeeFileType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
