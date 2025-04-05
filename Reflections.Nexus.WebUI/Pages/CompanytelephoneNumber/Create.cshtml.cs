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

namespace Reflections.Nexus.WebUI.Pages.CompanytelephoneNumber
{
    [Authorize(Roles = "Administrator,Configuration,CEO,MD")]
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
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            ViewData["TypeId"] = new SelectList(_context.PhoneNumberTypes, "Id", "Value");
            return Page();
        }

        [BindProperty]
        public M.CompanyTelephoneNumber CompanyTelephoneNumber { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult>
            OnPostAsync()
        {

            var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            CompanyTelephoneNumber.Created = DateTime.Now;
            CompanyTelephoneNumber.CreatedBy = User.Id;
            CompanyTelephoneNumber.Updated = DateTime.Now;
            CompanyTelephoneNumber.UpdatedBy = User.Id;

            if (!ModelState.IsValid)
            {
                OnGet();
            }



            _context.CompanyEmployeeTelephoneNumber.Add(CompanyTelephoneNumber);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
