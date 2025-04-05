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

namespace Reflections.Nexus.WebUI.Pages.EmployeeTelephoneNumber
{
    [Authorize(Roles = "Administrator,hr,It")]
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName");
            ViewData["TypeId"] = new SelectList(_context.PhoneNumberTypes, "Id", "Value");
            return Page();
        }

        [BindProperty]
        public M.EmployeeTelephoneNumber EmployeeTelephoneNumber { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult>
            OnPostAsync()
        {

            var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            EmployeeTelephoneNumber.Created = DateTime.Now;
            EmployeeTelephoneNumber.CreatedBy = User.Id;
            EmployeeTelephoneNumber.Updated = DateTime.Now;
            EmployeeTelephoneNumber.UpdatedBy = User.Id;

            //if (!ModelState.IsValid)
            //{
            //    ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName");
            //    ViewData["TypeId"] = new SelectList(_context.PhoneNumberTypes, "Id", "Value");
            //    return Page();
            //}

            _context.EmployeeTelephoneNumber.Add(EmployeeTelephoneNumber);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
