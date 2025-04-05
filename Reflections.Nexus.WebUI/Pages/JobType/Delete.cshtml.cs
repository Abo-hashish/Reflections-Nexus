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

namespace Reflections.Nexus.WebUI.Pages.JobType
{
    public class DeleteModel : PageModel
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;

        public DeleteModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public M.JobType JobType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobtype = await _context.JobTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (jobtype == null)
            {
                return NotFound();
            }
            else
            {
                JobType = jobtype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobtype = await _context.JobTypes.FindAsync(id);
            if (jobtype != null)
            {
                JobType = jobtype;
                _context.JobTypes.Remove(JobType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
