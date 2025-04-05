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

namespace Reflections.Nexus.WebUI.Pages.City
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
        public M.City City { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city =  await _context.Cities
                
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }
            City = city;
           ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // validate thet city is not repeated note that city names can be repeated in different countries
            var NameValidation = _context.Cities.Count(x => x.Id != City.Id &&( x.Name == City.Name && x.CountryId==City.CountryId ));
            if (NameValidation != 0)
            {
                ModelState.AddModelError("City.Name", "City name already exists");
                return Page();
            }

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

            _context.Attach(City).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(City.Id))
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

        private bool CityExists(int id)
        {
            return _context.Cities.Any(e => e.Id == id);
        }
    }
}
