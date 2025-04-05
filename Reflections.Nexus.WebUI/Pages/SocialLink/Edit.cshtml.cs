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

namespace Reflections.Nexus.WebUI.Pages.SocialLink
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
        public M.SocialLink SocialLink { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sociallink =  await _context.SocialLinks
                
                .Include(s => s.Company)
                .Include(s => s.SocialType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sociallink == null)
            {
                return NotFound();
            }
            SocialLink = sociallink;
           ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Address");
           ViewData["SocialTypeId"] = new SelectList(_context.SocialLinkTypes, "Id", "Value");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // modified so that social links are not repeated
            var NameValidation = _context.SocialLinks.Count(x => x.Id != SocialLink.Id && x.Url == SocialLink.Url);
            if (NameValidation != 0)
            {
                ModelState.AddModelError("SocialLink.Url", "SocialLink  already exists");
                return Page();
            }

            //var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            //SocialLink.Updated = DateTime.Now;
            //SocialLink.UpdatedBy = User.Id;
            //SocialLink.UpdatedByNavigation = User;



            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SocialLink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocialLinkExists(SocialLink.Id))
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

        private bool SocialLinkExists(int id)
        {
            return _context.SocialLinks.Any(e => e.Id == id);
        }
    }
}
