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

namespace Reflections.Nexus.WebUI.Pages.HeadCountItem
{
    //[Authorize(Roles = "Administrator,CEO,MD,Manager")] // add IT and HR in their spaces only
    public class CreateModel : BasePageModel<CreateModel>
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;
        private readonly UserResolverService _userService;

        public CreateModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context, UserResolverService userService)
        {
            _context = context;
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName").Prepend(new SelectListItem { Text = "Select an Employee", Value = "0" });
            ViewData["FromDepartmentJobTitleId"] = new SelectList(_context.JobTitles, "Id", "Name");
            ViewData["FromWorkingModelId"] = new SelectList(_context.WorkingModels, "Id", "Value");
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Value");
            ViewData["HeadCountTypeId"] = new SelectList(_context.HeadCountTypes, "Id", "Value");
            ViewData["IdentificationTypeId"] = new SelectList(_context.IdentificationTypes, "Id", "Value");
            ViewData["EmploymentTypeId"] = new SelectList(_context.EmploymentTypes, "Id", "Value");
            ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "Id", "Value");
            ViewData["ManagerId"] = new SelectList(_context.Employees, "Id", "FullName");
            ViewData["MaritalStatusId"] = new SelectList(_context.MaritalStatuses, "Id", "Value");
            ViewData["MilitaryStatusId"] = new SelectList(_context.MilitaryStatuses, "Id", "Value");
            ViewData["NationalityId"] = new SelectList(_context.Countries, "Id", "Name");
            ViewData["ToDepartmentJobTitleId"] = new SelectList(_context.JobTitles, "Id", "Name");
            ViewData["ToWorkingModelId"] = new SelectList(_context.WorkingModels, "Id", "Value");
            return Page();
        }

        [ActionName("LoadData")]
        public IActionResult OnGetLoadData([FromQuery] string selectedValue)
        {
            int receivedValue = int.Parse(selectedValue);
            var employee = _context.Employees.FirstOrDefault(u => u.Id == receivedValue);
            return new JsonResult(new { message = "Success", value = receivedValue, employee = employee });
        }



        [BindProperty]
        public M.HeadCountItem HeadCountItem { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult>
            OnPostAsync()
        {

            var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            if (HeadCountItem.HeadCountTypeId == 2)
            {
                if (HeadCountItem.ToDepartmentJobTitleId != HeadCountItem.FromDepartmentJobTitleId || HeadCountItem.FromWorkingModelId != HeadCountItem.ToWorkingModelId)
                {

                    ModelState.AddModelError(string.Empty, "For 'Hire' type, 'To' and 'From' Job Titles and Working Models must be equal.");
                }

               
            }

            

            if (!ModelState.IsValid)
            {
                PopulateDropdowns();  // Re-populate dropdowns in case of error
                return OnGet();
            }


            HeadCountItem.Created = DateTime.Now;
            HeadCountItem.CreatedBy = User.Id;
            HeadCountItem.Updated = DateTime.Now;
            HeadCountItem.UpdatedBy = User.Id;


            if (HeadCountItem.EmployeeId == 0)
            {
                HeadCountItem.EmployeeId = null;
            }


            _context.HeadCountItems.Add(HeadCountItem);
            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }

        private void PopulateDropdowns()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName").Prepend(new SelectListItem { Text = "Select an Employee", Value = "0" });
            ViewData["HeadCountTypeId"] = new SelectList(_context.HeadCountTypes, "Id", "Value");
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Value");
            ViewData["NationalityId"] = new SelectList(_context.Countries, "Id", "Name");
            ViewData["EmploymentTypeId"] = new SelectList(_context.EmploymentTypes, "Id", "Value");
            ViewData["ManagerId"] = new SelectList(_context.Employees, "Id", "FullName");
        }
    }


}