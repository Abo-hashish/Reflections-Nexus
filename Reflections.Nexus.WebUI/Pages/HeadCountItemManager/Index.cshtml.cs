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

namespace Reflections.Nexus.WebUI.Pages.HeadCountItemManager
{
    [Authorize(Roles = "Manager,CEO,MD")]
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
            var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());
            HeadCountItem = await _context.HeadCountItems.FromSql(
            $@"SELECT hci.*
            FROM HeadCountItem hci
            INNER JOIN Employee e ON hci.EmployeeId = e.Id
            INNER JOIN JobTitle jt ON e.JobTitleId = jt.Id
            INNER JOIN Department d ON jt.DepartmentId = d.Id
            INNER JOIN Employee m ON d.ManagerId = m.Id
            INNER JOIN Users u ON m.Email = u.Email
            WHERE u.Id = {User.Id}")
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
