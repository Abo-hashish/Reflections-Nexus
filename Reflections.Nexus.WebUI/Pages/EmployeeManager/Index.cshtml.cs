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
using M = Reflections.Nexus.WebUI.Models;

namespace Reflections.Nexus.WebUI.Pages.EmployeeManager
{
    [Authorize(Roles = "Manager,MD,CEO")]
    public class IndexModel : BasePageModel<IndexModel>
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;
        private readonly UserResolverService _userService;


        public IndexModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context, UserResolverService userService)
        {
            _context = context;
            _userService = userService;
        }

        public IList<M.Employee> EmployeeManager { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());
            EmployeeManager = await _context.Employees.FromSql(
            $@"SELECT Employee.*
                 FROM Users INNER JOIN
                 Employee AS Employee_1 ON Users.Email = Employee_1.Email INNER JOIN
                 Employee INNER JOIN
                 JobTitle ON Employee.JobTitleId = JobTitle.Id INNER JOIN
                 dbo.Department ON JobTitle.DepartmentId = Department.Id ON Employee_1.Id = dbo.Department.ManagerId
           WHERE (Users.Id = {User.Id});").ToListAsync();
        }
    }
}
