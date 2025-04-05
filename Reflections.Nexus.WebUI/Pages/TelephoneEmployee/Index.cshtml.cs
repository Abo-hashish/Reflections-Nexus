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

namespace Reflections.Nexus.WebUI.Pages.TelephoneEmployee
{
    [Authorize(Roles = "Employee")]
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
            var currentUserId = _userService.GetCurrentUserID();

            if (currentUserId == null)
            {
                throw new Exception("Manager not found.");
            }
            EmployeeTelephoneNumber = await _context.EmployeeTelephoneNumber
                .FromSqlInterpolated($@"SELECT
            et.*
        FROM EmployeeTelephoneNumber et
        INNER JOIN Employee e ON et.EmployeeId = e.Id
        INNER JOIN Users u ON e.Email = u.Email
        WHERE u.Id = { currentUserId}
            ")
                .Include(e => e.Employee)
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
