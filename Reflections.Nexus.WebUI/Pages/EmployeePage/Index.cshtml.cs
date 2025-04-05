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

namespace Reflections.Nexus.WebUI.Pages.EmployeePage
{
    [Authorize(Roles = "Employee")]
    public class IndexModel : BasePageModel<IndexModel>
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;
        private readonly UserResolverService _userService;

        public IndexModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context, UserResolverService userService)
        {
            _context = context;
            _userService = userService;
        }

        public IList<M.Employee> EmployeePage { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var userId = _userService.GetCurrentUserID();
            if (userId == null)
            {
                throw new Exception("Current user not found.");
            }

            // Fetch the employee using a proper SQL query
            EmployeePage = await _context.Employees
                .FromSqlInterpolated($@"
            SELECT e.*
            FROM Employee e
            INNER JOIN Users u ON e.Email = u.Email
            WHERE u.Id = {userId}")
                .ToListAsync();
        }
    }
}
