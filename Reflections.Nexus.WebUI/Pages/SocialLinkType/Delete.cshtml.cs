using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Reflections.Nexus.WebUI.Services;
using Reflections.Nexus.WebUI.Data;
using M=Reflections.Nexus.WebUI.Models;

namespace Reflections.Nexus.WebUI.Pages.SocialLinkType
{
    public class DeleteModel : PageModel
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;

        public DeleteModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public M.SocialLinkType SocialLinkType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sociallinktype = await _context.SocialLinkTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (sociallinktype == null)
            {
                return NotFound();
            }
            else
            {
                SocialLinkType = sociallinktype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sociallinktype = await _context.SocialLinkTypes.FindAsync(id);
            if (sociallinktype != null)
            {
                SocialLinkType = sociallinktype;
                _context.SocialLinkTypes.Remove(SocialLinkType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
