using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reflections.Nexus.WebUI.Services;
using Reflections.Nexus.WebUI.Data;
using M = Reflections.Nexus.WebUI.Models;
using Microsoft.AspNetCore.Authorization;

namespace Reflections.Nexus.WebUI.Pages.EmployeeManager 
{
    [Authorize(Roles = "Manager")]
    public class EditModel : PageModel
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;
        private readonly UserResolverService _userService;

        public EditModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context, UserResolverService userService)
        {
            _context = context;
            _userService = userService;
        }

        [BindProperty]
        public M.Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee =  await _context.Employees
                
                .Include(e => e.City)
                .Include(e => e.EmploymentType)
                .Include(e => e.Gender)
                .Include(e => e.IdentificationType)
                .Include(e => e.JobTitle)
                .Include(e => e.JobType)
                .Include(e => e.Manager)
                .Include(e => e.MaritalStatus)
                .Include(e => e.MilitaryStatus)
                .Include(e => e.Nationality)
                .Include(e => e.WorkingModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            Employee = employee;
           ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
           ViewData["EmploymentTypeId"] = new SelectList(_context.EmploymentTypes, "Id", "Value");
           ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Value");
           ViewData["IdentificationTypeId"] = new SelectList(_context.IdentificationTypes, "Id", "Value");
           ViewData["JobTitleId"] = new SelectList(_context.JobTitles, "Id", "Name");
           ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "Id", "Value");
           ViewData["ManagerId"] = new SelectList(_context.Employees, "Id", "FirstName");
           ViewData["MaritalStatusId"] = new SelectList(_context.MaritalStatuses, "Id", "Value");
           ViewData["MilitaryStatusId"] = new SelectList(_context.MilitaryStatuses, "Id", "Value");
           ViewData["NationalityId"] = new SelectList(_context.Countries, "Id", "Name");
           ViewData["WorkingModelId"] = new SelectList(_context.WorkingModels, "Id", "Value");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // checks that the identification is not repeated 
            var NameValidation = _context.Employees.Count(x => x.Id != Employee.Id && x.Identification == Employee.Identification);
            if (NameValidation != 0)
            {
                ModelState.AddModelError("Employee.Identification", "Employee Identification already exists");
                return Page();
            }

            var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            Employee.Updated = DateTime.Now;
            Employee.UpdatedBy = User.Id;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(Employee.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
