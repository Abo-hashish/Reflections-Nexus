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

namespace Reflections.Nexus.WebUI.Pages.City
{
    [Authorize(Roles = "Administrator,Configuration")]
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public  M.City City { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult>
            OnPostAsync()
        {

            var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            


            if (string.IsNullOrWhiteSpace(City.Name))
            {
                ModelState.AddModelError("City.Name", "City name is required.");
            }

            if (City.Name?.Length < 2 || City.Name?.Length > 100)
            {
                ModelState.AddModelError("City.Name", "City name must be between 2 and 100 characters.");
            }

            if (_context.Cities.Any(c => c.Name == City.Name && c.CountryId == City.CountryId))
            {
                ModelState.AddModelError("City.Name", "City name must be unique within the same country.");
            }


            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cities.Add(City);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
