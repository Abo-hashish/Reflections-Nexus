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
using M=Reflections.Nexus.WebUI.Models;

namespace Reflections.Nexus.WebUI.Pages.JobTitle
{
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
        public M.JobTitle JobTitle { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobtitle =  await _context.JobTitles
                
                .Include(j => j.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobtitle == null)
            {
                return NotFound();
            }
            JobTitle = jobtitle;
           ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var NameValidation = _context.JobTitles.Count(x => x.Id != JobTitle.Id && x.Name == JobTitle.Name);
            if (NameValidation != 0)
            {
                ModelState.AddModelError("JobTitle.Name", "JobTitle name already exists");
                return Page();
            }

            //var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            //JobTitle.Updated = DateTime.Now;
            //JobTitle.UpdatedBy = User.Id;
            //JobTitle.UpdatedByNavigation = User;



            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(JobTitle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTitleExists(JobTitle.Id))
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

        private bool JobTitleExists(int id)
        {
            return _context.JobTitles.Any(e => e.Id == id);
        }
    }
}
