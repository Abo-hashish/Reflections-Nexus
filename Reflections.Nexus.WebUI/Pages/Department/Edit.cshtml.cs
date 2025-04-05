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
using NuGet.Frameworks;

namespace Reflections.Nexus.WebUI.Pages.Department
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
        public M.Department Department { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department =  await _context.Departments
                
                .Include(d => d.Company)
                .Include(d => d.Manager)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            Department = department;
           ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
           ViewData["ManagerId"] = new SelectList(_context.Employees, "Id", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var NameValidation = _context.Departments.Count(x => x.Id != Department.Id && x.Name == Department.Name);
            if (NameValidation != 0)
            {
                ModelState.AddModelError("Department.Name", "Department name already exists");
                ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
                ViewData["ManagerId"] = new SelectList(_context.Employees, "Id", "FirstName" + " " + "LastName");
                return Page();
            }
            var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            Department.Updated = DateTime.Now;
            Department.UpdatedBy = User.Id;
            //

            if (!ModelState.IsValid)
            {
                ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
                ViewData["ManagerId"] = new SelectList(_context.Employees, "Id", "FullName");
                return Page();
            }

            _context.Attach(Department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(Department.Id))
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

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}
