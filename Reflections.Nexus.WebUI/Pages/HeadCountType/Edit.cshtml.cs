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
using M =Reflections.Nexus.WebUI.Models;

namespace Reflections.Nexus.WebUI.Pages.HeadCountType
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
        public M.HeadCountType HeadCountType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headcounttype =  await _context.HeadCountTypes
                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (headcounttype == null)
            {
                return NotFound();
            }
            HeadCountType = headcounttype;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var NameValidation = _context.HeadCountTypes.Count(x => x.Id != HeadCountType.Id && x.Value == HeadCountType.Value);
            if (NameValidation != 0)
            {
                ModelState.AddModelError("HeadCountType.Name", "HeadCountType name already exists");
                return Page();
            }

            //var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            //HeadCountType.Updated = DateTime.Now;
            //HeadCountType.UpdatedBy = User.Id;
            //HeadCountType.UpdatedByNavigation = User;



            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(HeadCountType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeadCountTypeExists(HeadCountType.Id))
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

        private bool HeadCountTypeExists(int id)
        {
            return _context.HeadCountTypes.Any(e => e.Id == id);
        }
    }
}
