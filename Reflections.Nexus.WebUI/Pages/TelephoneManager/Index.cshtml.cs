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
using Reflections.Nexus.WebUI.Models;
using Humanizer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Reflections.Nexus.WebUI.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Reflections.Nexus.WebUI.Pages.TelephoneManager
{
    [Authorize(Roles = "Manager,CEO,MD")]
    public class IndexModel : BasePageModel<IndexModel>
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;
        private readonly UserResolverService _userService;

        public IndexModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context,UserResolverService userService)
        {
            _context = context;
            _userService = userService;
        }

        public IList<M.EmployeeTelephoneNumber> EmployeeTelephoneNumber { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var managerUserId = _userService.GetCurrentUserID();

            if (managerUserId == null)
            {
                throw new Exception("Manager not found.");
            }

            // Use a raw SQL query with manager ID
            EmployeeTelephoneNumber = await _context.EmployeeTelephoneNumber
                .FromSql($@"
            SELECT 
                et.* ,e.FirstName,e.LastName
            FROM EmployeeTelephoneNumber et
            INNER JOIN Employee e ON et.EmployeeId = e.Id
            INNER JOIN JobTitle jt ON e.JobTitleId = jt.Id
            INNER JOIN Department d ON jt.DepartmentId = d.Id
            INNER JOIN Employee m ON d.ManagerId = m.Id
            INNER JOIN Users u ON m.Email = u.Email
            WHERE u.Id = {managerUserId}").
                Include(e => e.Employee)
                .Include(e => e.Type)

                .ToListAsync();
        }
        public class EmployeeTelephoneNumberViewModel
        {
            public int Id { get; set; }
            public string Number { get; set; }
            public bool IsPrimary { get; set; }
            public string EmployeeFullName { get; set; } // Combine FirstName and LastName
        }


    }

}
