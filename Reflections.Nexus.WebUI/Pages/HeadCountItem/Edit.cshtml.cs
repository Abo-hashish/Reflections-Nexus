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

namespace Reflections.Nexus.WebUI.Pages.HeadCountItem
{
    public class EditModel : PageModel
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;
        private readonly UserResolverService _userService;

        public EditModel(ApplicationDbContext context, UserResolverService userService)
        {
            _context = context;
            _userService = userService;
        }

        [BindProperty]
        public M.HeadCountItem HeadCountItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headcountItem = await _context.HeadCountItems
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
                .FirstOrDefaultAsync(m => m.Id == id);

            if (headcountItem == null)
            {
                return NotFound();
            }

            HeadCountItem = headcountItem;
            PopulateViewData();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var nameValidation = _context.HeadCountItems.Count(x => x.Id != HeadCountItem.Id );
            //if (nameValidation > 0)
            //{
            //    ModelState.AddModelError("HeadCountItem.Name", "HeadCountItem name already exists.");
            //    PopulateViewData();
            //    return Page();
            //}

            var currentUser = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            if (HeadCountItem.HeadCountTypeId == 2)
            {
                if (HeadCountItem.ToDepartmentJobTitleId != HeadCountItem.FromDepartmentJobTitleId || HeadCountItem.FromWorkingModelId != HeadCountItem.ToWorkingModelId)
                {

                    ModelState.AddModelError(string.Empty, "For 'Hire' type, 'To' and 'From' Job Titles and Working Models must be equal.");
                }


            }


            if (!ModelState.IsValid)
            {
                PopulateViewData();  // Re-populate dropdowns in case of error
                return Page();
            }



            HeadCountItem.Updated = DateTime.Now;
            HeadCountItem.UpdatedBy = currentUser.Id;


            _context.Attach(HeadCountItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeadCountItemExists(HeadCountItem.Id))
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

        private bool HeadCountItemExists(int id)
        {
            return _context.HeadCountItems.Any(e => e.Id == id);
        }

        private void PopulateViewData()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName");
            ViewData["FromDepartmentJobTitleId"] = new SelectList(_context.JobTitles?.ToList() ?? new List<M.JobTitle>(), "Id", "Name");
            ViewData["FromWorkingModelId"] = new SelectList(_context.WorkingModels?.ToList() ?? new List<M.WorkingModel>(), "Id", "Value");
            ViewData["GenderId"] = new SelectList(_context.Genders?.ToList() ?? new List<M.Gender>(), "Id", "Value");
            ViewData["HeadCountTypeId"] = new SelectList(_context.HeadCountTypes?.ToList() ?? new List<M.HeadCountType>(), "Id", "Value");
            ViewData["IdentificationTypeId"] = new SelectList(_context.IdentificationTypes?.ToList() ?? new List<M.IdentificationType>(), "Id", "Value");
            ViewData["EmploymentTypeId"] = new SelectList(_context.EmploymentTypes?.ToList() ?? new List<M.EmploymentType>(), "Id", "Value");
            ViewData["JobTypeId"] = new SelectList(_context.JobTypes?.ToList() ?? new List<M.JobType>(), "Id", "Value");
            ViewData["ManagerId"] = new SelectList(_context.Employees, "Id", "FullName");
            ViewData["MaritalStatusId"] = new SelectList(_context.MaritalStatuses?.ToList() ?? new List<M.MaritalStatus>(), "Id", "Value");
            ViewData["MilitaryStatusId"] = new SelectList(_context.MilitaryStatuses?.ToList() ?? new List<M.MilitaryStatus>(), "Id", "Value");
            ViewData["NationalityId"] = new SelectList(_context.Countries?.ToList() ?? new List<M.Country>(), "Id", "Name");
            ViewData["ToDepartmentJobTitleId"] = new SelectList(_context.JobTitles?.ToList() ?? new List<M.JobTitle>(), "Id", "Name");
            ViewData["ToWorkingModelId"] = new SelectList(_context.WorkingModels?.ToList() ?? new List<M.WorkingModel>(), "Id", "Value");
        }

    }
}
