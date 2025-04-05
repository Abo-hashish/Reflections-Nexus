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

namespace Reflections.Nexus.WebUI.Pages.SocialLinkType
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
        public M.SocialLinkType SocialLinkType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sociallinktype =  await _context.SocialLinkTypes
                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sociallinktype == null)
            {
                return NotFound();
            }
            SocialLinkType = sociallinktype;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var NameValidation = _context.SocialLinkTypes.Count(x => x.Id != SocialLinkType.Id && x.Value == SocialLinkType.Value);
            if (NameValidation != 0)
            {
                ModelState.AddModelError("SocialLinkType.Name", "SocialLinkType name already exists");
                return Page();
            }

            //var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            //SocialLinkType.Updated = DateTime.Now;
            //SocialLinkType.UpdatedBy = User.Id;
            //SocialLinkType.UpdatedByNavigation = User;



            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SocialLinkType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocialLinkTypeExists(SocialLinkType.Id))
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

        private bool SocialLinkTypeExists(int id)
        {
            return _context.SocialLinkTypes.Any(e => e.Id == id);
        }
    }
}
