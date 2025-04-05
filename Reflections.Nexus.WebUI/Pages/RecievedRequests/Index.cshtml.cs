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
using M = Reflections.Nexus.WebUI.ViewModels;
using Reflections.Nexus.WebUI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Reflections.Nexus.WebUI.ViewModels;


namespace Reflections.Nexus.WebUI.Pages.RecievedRequests
{
    [Authorize(Roles = "Administrator,hr,Manager,CEO,MD")]
    public class IndexModel : BasePageModel<IndexModel>
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;
        private readonly UserResolverService _userService;

        public IndexModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context, UserResolverService user_Service)
        {
            _context = context;
            _userService = user_Service;
        }


        public IList<M.employee_Id> empid { get; set; } = default!;
        public IList<M.RequestViewModel> Data { get; set; } = default!;

        public int employeeID { get; set; }

        public async Task OnGetAsync()
        {

            var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            var empid = await _context.Database.SqlQuery<M.employee_Id>(@$"Select e.Id
            FROM Users u, Employee e
            WHERE E.Email = u.Email AND u.Id ={User.Id} ")
                 .ToListAsync();
            if(empid!=null)
            {
                employeeID = empid.First().Id;
            }

            Data = await _context.Database.SqlQuery<M.RequestViewModel>(
                @$"SELECT       EmployeeRequest.Id, Employee.FirstName +' '+ Employee.LastName As Fullname, EmployeeRequest.Notes , RequestStatus.Value As Status
                FROM            dbo.EmployeeRequest INNER JOIN
                         dbo.Employee ON dbo.EmployeeRequest.EmployeeId = dbo.Employee.Id INNER JOIN
                         dbo.Employee AS Employee_1 ON dbo.Employee.ManagerId = Employee_1.Id INNER JOIN
						 RequestStatus ON EmployeeRequest.StatusId = RequestStatus.Id
                WHERE        (Employee_1.Id = {employeeID}) AND (dbo.EmployeeRequest.StatusId = 3);")
                .ToListAsync();


            
        }
    }
}
