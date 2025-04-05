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
        using M=Reflections.Nexus.WebUI.Models;

namespace Reflections.Nexus.WebUI.Pages.Employee
{
    [Authorize(Roles = "Administrator,hr,Manager,CEO,MD")]
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
            ViewData["CityId"] = new SelectList(_context.Cities?.ToList() ?? new List<M.City>(), "Id", "Name");
            ViewData["EmploymentTypeId"] = new SelectList(_context.EmploymentTypes?.ToList() ?? new List<M.EmploymentType>(), "Id", "Value");
            ViewData["GenderId"] = new SelectList(_context.Genders?.ToList() ?? new List<M.Gender>(), "Id", "Value");
            ViewData["IdentificationTypeId"] = new SelectList(_context.IdentificationTypes?.ToList() ?? new List<M.IdentificationType>(), "Id", "Value");
            ViewData["JobTitleId"] = new SelectList(_context.JobTitles?.ToList() ?? new List<M.JobTitle>(), "Id", "Name");
            ViewData["JobTypeId"] = new SelectList(_context.JobTypes?.ToList() ?? new List<M.JobType>(), "Id", "Value");
            ViewData["ManagerId"] = new SelectList(_context.Employees?.ToList() ?? new List<M.Employee>(), "Id", "FirstName");
            ViewData["MaritalStatusId"] = new SelectList(_context.MaritalStatuses?.ToList() ?? new List<M.MaritalStatus>(), "Id", "Value");
            ViewData["MilitaryStatusId"] = new SelectList(_context.MilitaryStatuses?.ToList() ?? new List<M.MilitaryStatus>(), "Id", "Value");
            ViewData["NationalityId"] = new SelectList(_context.Countries?.ToList() ?? new List<M.Country>(), "Id", "Name");
            ViewData["WorkingModelId"] = new SelectList(_context.WorkingModels?.ToList() ?? new List<M.WorkingModel>(), "Id", "Value");

            return Page();
        }

        [BindProperty]
    public M.Employee Employee { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult>
        OnPostAsync()
        {

            var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            Employee.Created = DateTime.Now;
            Employee.CreatedBy = User.Id;
            Employee.Updated = DateTime.Now;
            Employee.UpdatedBy = User.Id;

            if (Employee.Salary <= 0)
            {
                ModelState.AddModelError("Employee.Salary", "Salary must be greater than 0.");
            }

            if (string.IsNullOrWhiteSpace(Employee.Identification) || Employee.Identification.Length < 14)
            {
                ModelState.AddModelError("Employee.Identification", "Identification must be at least 14 characters long.");
            }

            if (!string.IsNullOrEmpty(Employee.FirstName) && Employee.FirstName.Any(char.IsDigit))
            {
                ModelState.AddModelError("Employee.FirstName", "First Name should not contain numbers.");
            }

            if (!string.IsNullOrEmpty(Employee.LastName) && Employee.LastName.Any(char.IsDigit))
            {
                ModelState.AddModelError("Employee.LastName", "Last Name should not contain numbers.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employees.Add(Employee);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
        }
        }
        }
