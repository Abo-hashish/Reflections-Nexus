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
using Microsoft.IdentityModel.Tokens;

namespace Reflections.Nexus.WebUI.Pages.RecievedRequests
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
        public M.EmployeeRequest EmployeeRequest { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeerequest =  await _context.EmployeeRequests
                
               // .Include(e => e.Employee)
                .Include(e => e.Notification)
                .Include(e => e.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeerequest == null)
            {
                return NotFound();
            }
            EmployeeRequest = employeerequest;
           ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName");
           ViewData["NotificationId"] = new SelectList(_context.Notifications, "Id", "Message");
           ViewData["StatusId"] = new SelectList(_context.RequestStatuses, "Id", "Value");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // Validate the current user
            var userId = _userService.GetCurrentUserID();
            if (userId==0)
            {
                throw new InvalidOperationException("Unable to resolve the current user.");
            }

            var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            EmployeeRequest.Updated = DateTime.Now;
            EmployeeRequest.UpdatedBy = userId;

            // Reload the EmployeeRequest from the database to ensure EmployeeId remains unchanged
            var existingRequest = await _context.EmployeeRequests.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == EmployeeRequest.Id);

            if (existingRequest == null)
            {
                return NotFound("The EmployeeRequest does not exist.");
            }

            // Preserve the original EmployeeId
            EmployeeRequest.EmployeeId = existingRequest.EmployeeId;
            EmployeeRequest.NotificationId = 1;

            //if (!ModelState.IsValid)
            //{
            //    ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName");
            //    ViewData["StatusId"] = new SelectList(_context.RequestStatuses, "Id", "Value");
            //    return Page();
            //}

            // Attach the updated entity to the context and mark only the desired fields as modified
            _context.Attach(EmployeeRequest).State = EntityState.Modified;
            _context.Entry(EmployeeRequest).Property(e => e.EmployeeId).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeRequestExists(EmployeeRequest.Id))
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


        private bool EmployeeRequestExists(int id)
        {
            return _context.EmployeeRequests.Any(e => e.Id == id);
        }
    }
}
