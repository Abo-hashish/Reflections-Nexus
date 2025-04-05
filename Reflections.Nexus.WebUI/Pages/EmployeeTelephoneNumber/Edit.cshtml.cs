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

namespace Reflections.Nexus.WebUI.Pages.EmployeeTelephoneNumber
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
        public M.EmployeeTelephoneNumber EmployeeTelephoneNumber { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeetelephonenumber =  await _context.EmployeeTelephoneNumber
                
                .Include(e => e.Employee)
                .Include(e => e.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeetelephonenumber == null)
            {
                return NotFound();
            }
            EmployeeTelephoneNumber = employeetelephonenumber;
           ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName");
           ViewData["TypeId"] = new SelectList(_context.PhoneNumberTypes, "Id", "Value");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var NameValidation = _context.EmployeeTelephoneNumber.Count(x => x.Id != EmployeeTelephoneNumber.Id && x.Number == EmployeeTelephoneNumber.Number);
            if (NameValidation != 0)
            {
                ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName");
                ViewData["TypeId"] = new SelectList(_context.PhoneNumberTypes, "Id", "Value");
                ModelState.AddModelError("EmployeeTelephoneNumber.Name", "EmployeeTelephoneNumber already exists");
                return Page();
            }

            var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            EmployeeTelephoneNumber.Updated = DateTime.Now;
            EmployeeTelephoneNumber.UpdatedBy = User.Id;



            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EmployeeTelephoneNumber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeTelephoneNumberExists(EmployeeTelephoneNumber.Id))
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

        private bool EmployeeTelephoneNumberExists(int id)
        {
            return _context.EmployeeTelephoneNumber.Any(e => e.Id == id);
        }
    }
}
