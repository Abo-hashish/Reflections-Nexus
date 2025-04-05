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

namespace Reflections.Nexus.WebUI.Pages.MilitaryStatus
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
        public M.MilitaryStatus MilitaryStatus { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var militarystatus =  await _context.MilitaryStatuses
                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (militarystatus == null)
            {
                return NotFound();
            }
            MilitaryStatus = militarystatus;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var NameValidation = _context.MilitaryStatuses.Count(x => x.Id != MilitaryStatus.Id && x.Value == MilitaryStatus.Value);
            if (NameValidation != 0)
            {
                ModelState.AddModelError("MilitaryStatus.Name", "MilitaryStatus name already exists");
                return Page();
            }

            //var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            //MilitaryStatus.Updated = DateTime.Now;
            //MilitaryStatus.UpdatedBy = User.Id;
            //MilitaryStatus.UpdatedByNavigation = User;



            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MilitaryStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MilitaryStatusExists(MilitaryStatus.Id))
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

        private bool MilitaryStatusExists(int id)
        {
            return _context.MilitaryStatuses.Any(e => e.Id == id);
        }
    }
}
