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

namespace Reflections.Nexus.WebUI.Pages.EmployeeFileType
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
        public M.EmployeeFileType EmployeeFileType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeefiletype =  await _context.EmployeeFileTypes
                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeefiletype == null)
            {
                return NotFound();
            }
            EmployeeFileType = employeefiletype;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var NameValidation = _context.EmployeeFileTypes.Count(x => x.Id != EmployeeFileType.Id && x.Value == EmployeeFileType.Value);
            if (NameValidation != 0)
            {
                ModelState.AddModelError("EmployeeFileType.Value", "Employee FileType already exists");
                return Page();
            }

            //var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            //EmployeeFileType.Updated = DateTime.Now;
            //EmployeeFileType.UpdatedBy = User.Id;
            //EmployeeFileType.UpdatedByNavigation = User;



            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EmployeeFileType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeFileTypeExists(EmployeeFileType.Id))
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

        private bool EmployeeFileTypeExists(int id)
        {
            return _context.EmployeeFileTypes.Any(e => e.Id == id);
        }
    }
}
