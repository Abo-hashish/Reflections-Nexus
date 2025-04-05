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

namespace Reflections.Nexus.WebUI.Pages.HeadCountItem
{
    public class DeleteModel : PageModel
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;

        public DeleteModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public M.HeadCountItem HeadCountItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headcountitem = await _context.HeadCountItems
                .Include(h => h.Employee)
                .Include(h => h.FromDepartmentJobTitle)
                .Include(h => h.FromWorkingModel)
                .Include(h => h.Gender)
                .Include(h => h.HeadCountType)
                .Include(h => h.IdentificationType)
                .Include(h => h.JobType)
                .Include(h => h.Manager)
                .Include(h => h.MaritalStatus)
                .Include(h => h.MilitaryStatus)
                .Include(h => h.Nationality)
                .Include(h => h.ToDepartmentJobTitle)
                .Include(h => h.ToWorkingModel).FirstOrDefaultAsync(m => m.Id == id);

            if (headcountitem == null)
            {
                return NotFound();
            }
            else
            {
                HeadCountItem = headcountitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headcountitem = await _context.HeadCountItems.FindAsync(id);
            if (headcountitem != null)
            {
                HeadCountItem = headcountitem;
                _context.HeadCountItems.Remove(HeadCountItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
