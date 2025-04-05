using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Reflections.Nexus.WebUI.Code;
using Reflections.Nexus.WebUI.Data;
using Reflections.Nexus.WebUI.Services;
using Reflections.Nexus.WebUI.Data;
using M=Reflections.Nexus.WebUI.Models;

namespace Reflections.Nexus.WebUI.Pages.Employee
{
    [Authorize(Roles = "Administrator,hr,Manager,CEO,MD")]
    public class IndexModel : BasePageModel<IndexModel>
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;
        private readonly UserResolverService _userService;

        public IndexModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<M.Employee> Employee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Employee = await _context.Employees
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
                .Include(e => e.WorkingModel)
            //.Include(c => c.CreatedByNavigation)
            //.Include(c => c.UpdatedByNavigation)
            .ToListAsync();
        }
    }
}
