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

namespace Reflections.Nexus.WebUI.Pages.RequestStatus
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
        public M.RequestStatus RequestStatus { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requeststatus =  await _context.RequestStatuses
                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requeststatus == null)
            {
                return NotFound();
            }
            RequestStatus = requeststatus;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var NameValidation = _context.RequestStatuses.Count(x => x.Id != RequestStatus.Id && x.Value == RequestStatus.Value);
            if (NameValidation != 0)
            {
                ModelState.AddModelError("RequestStatus.Name", "RequestStatus name already exists");
                return Page();
            }

            //var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            //RequestStatus.Updated = DateTime.Now;
            //RequestStatus.UpdatedBy = User.Id;
            //RequestStatus.UpdatedByNavigation = User;



            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RequestStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestStatusExists(RequestStatus.Id))
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

        private bool RequestStatusExists(int id)
        {
            return _context.RequestStatuses.Any(e => e.Id == id);
        }
    }
}
