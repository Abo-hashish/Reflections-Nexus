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
using Reflections.Nexus.WebUI.Models;

namespace Reflections.Nexus.WebUI.Pages.HeadCountItemEmployee
{

    public class IndexModel : BasePageModel<IndexModel>
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;
        private readonly UserResolverService _userService;

        public IndexModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context, UserResolverService user_Service)
        {
            _context = context;
            _userService = user_Service;
        }

        public IList<M.HeadCountItem> HeadCountItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            // Step 1: Get the current user ID
            var currentUserId = _userService.GetCurrentUserID();

            if (currentUserId == null)
            {
                throw new Exception("Current user not found.");
            }

            // Step 2: Use SQL query with parameterized input
            HeadCountItem = await _context.HeadCountItems
                .FromSqlInterpolated($@"
            SELECT hci.*
            FROM HeadCountItem hci
            INNER JOIN Employee e ON hci.EmployeeId = e.Id
            INNER JOIN Users u ON e.Email = u.Email
            WHERE u.Id = {currentUserId}")
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
                .Include(h => h.ToWorkingModel)
            .ToListAsync();
                
        }
    }
}
