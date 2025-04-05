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
using M=Reflections.Nexus.WebUI.ViewModels;
using Reflections.Nexus.WebUI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Reflections.Nexus.WebUI.Pages.EmployeesInDepartments
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

        public IList<M.EmployeeViewModel> Data { get;set; } = default!;
        public List<M.DepartmentViewModel> Departments { get; set; } = new List<M.DepartmentViewModel>();
        [BindProperty(SupportsGet = true)]
        public int SelectedDepartmentId { get; set; } // For the selected department
        public double AverageSalary { get; set; }
        public decimal MaximumSalary { get; set; }
        public decimal MinimumSalary { get; set; }




        public async Task OnGetAsync(int? departmentId)
        {

            //ViewData["DepartmentId"] = new SelectList(
            // await _context.Database.SqlQuery<M.DepartmentViewModel>(@$"SELECT Id,Name
            // FROM Department
            // where IsActive=1;").ToListAsync(), "Id", "Name");

            var departments = await _context.Database.SqlQuery<M.DepartmentViewModel>(
            @$"SELECT Id, Name FROM Department WHERE IsActive = 1;").ToListAsync();

            ViewData["DepartmentId"] = new SelectList(departments, "Id", "Name", SelectedDepartmentId);

            if (SelectedDepartmentId>0)
            {
                //SelectedDepartmentId = departmentId.Value;
                Data = await _context.Database.SqlQuery<M.EmployeeViewModel>(
                    @$"SELECT  
                         Employee.Id, Employee.FirstName, Employee.LastName, Employee.Email, Gender.Value AS Gender, JobTitle.Name AS [JobTitle], JobType.Value AS [JobType], 
                         EmploymentType.Value AS [EmploymentType], WorkingModel.Value AS [WorkingModel], Employee.Salary
                    FROM            Employee INNER JOIN
                         EmploymentType ON Employee.EmploymentTypeId = EmploymentType.Id INNER JOIN
                         Gender ON Employee.GenderId = Gender.Id INNER JOIN
                         JobTitle ON Employee.JobTitleId = JobTitle.Id INNER JOIN
                         JobType ON Employee.JobTypeId = JobType.Id INNER JOIN
                         WorkingModel ON Employee.WorkingModelId = WorkingModel.Id INNER JOIN
                         Department ON JobTitle.DepartmentId = Department.Id
                    WHERE        (Department.Id = {SelectedDepartmentId})")
                    .ToListAsync();
            }
            else
            {
                // Load all employees if no department is selected
                Data = await _context.Database.SqlQuery<M.EmployeeViewModel>(
                    @$"SELECT        dbo.Employee.Id, dbo.Employee.FirstName, dbo.Employee.LastName, dbo.Employee.Email, dbo.Gender.Value AS Gender, dbo.JobTitle.Name AS [JobTitle], dbo.JobType.Value AS [JobType], 
                         dbo.EmploymentType.Value AS [EmploymentType], dbo.WorkingModel.Value AS [WorkingModel], dbo.Employee.Salary
                    FROM            dbo.Employee INNER JOIN
                         EmploymentType ON Employee.EmploymentTypeId = dbo.EmploymentType.Id INNER JOIN
                         Gender ON Employee.GenderId = Gender.Id INNER JOIN
                         JobTitle ON Employee.JobTitleId = JobTitle.Id INNER JOIN
                         JobType ON Employee.JobTypeId = JobType.Id INNER JOIN
                         WorkingModel ON Employee.WorkingModelId = WorkingModel.Id")
                    .ToListAsync();
            }   
            AverageSalary = Data.Any() ? Data.Average(e => e.Salary) : 0;
            MaximumSalary = Data.Any() ? Data.Max(e => e.Salary) : 0;
            MinimumSalary = Data.Any() ? Data.Min(e => e.Salary) : 0;
            ViewData["DepartmentId"] = new SelectList(departments, "Id", "Name", SelectedDepartmentId);
        }

    }
}
