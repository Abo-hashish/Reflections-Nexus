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

namespace Reflections.Nexus.WebUI.Pages.TelephoneManager
{
    public class DetailsModel : PageModel
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;

        public DetailsModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public M.Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

    var employee = await _context.Employees
                .Include(e => e.City)
                .Include(e => e.EmploymentType)
                .Include(e => e.Gender)
                .Include(e => e.IdentificationType)
                .Include(e => e.JobTitle)
                .Include(e => e.JobType)
                .Include(e => e.Manager)
                .Include(e => e.MaritalStatus)
                .Include(e => e.MilitaryStatus)
                .Include(e => e.Nationality)
                .Include(e => e.WorkingModel).FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                Employee = employee;
            }
            return Page();
        }
    }
}
