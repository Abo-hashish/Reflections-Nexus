using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Reflections.Nexus.WebUI.Code;
using Reflections.Nexus.WebUI.Services;
using Reflections.Nexus.WebUI.Data;
using M = Reflections.Nexus.WebUI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Reflections.Nexus.WebUI.Models;
using m = Reflections.Nexus.WebUI.ViewModels;

namespace Reflections.Nexus.WebUI.Pages.EmployeeRequest
{
    [Authorize(Roles = "Administrator, Employee, Manager , It,hr,CEO,MD")]
    public class CreateModel : BasePageModel<CreateModel>
    {
        public int employeeID { get; set; }
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;
        private readonly UserResolverService _userService;

        public IList<m.employee_Id> empid { get; set; } = default!;

        public CreateModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context, UserResolverService userService)
        {
            _context = context;
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            ViewData["NotificationId"] = new SelectList(_context.Notifications, "Id", "Message");
            return Page();
        }

        [BindProperty]
        public M.EmployeeRequest EmployeeRequest { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult>
            OnPostAsync()
        {

            var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            EmployeeRequest.Created = DateTime.Now;
            EmployeeRequest.CreatedBy = User.Id;
            EmployeeRequest.Updated = DateTime.Now;
            EmployeeRequest.UpdatedBy = User.Id;
            EmployeeRequest.StatusId = 3;
            EmployeeRequest.NotificationId = 1;
            var empid = await _context.Database.SqlQuery<m.employee_Id>(@$"Select e.Id
            FROM Users u, Employee e
            WHERE E.Email = u.Email AND u.Id ={User.Id} ")
            .ToListAsync();
            if (empid != null)
            {
                employeeID = empid.First().Id;
            }

            EmployeeRequest.EmployeeId = employeeID;


            if (!ModelState.IsValid)
            {
                OnGet();
            }

            _context.EmployeeRequests.Add(EmployeeRequest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
