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
using M = Reflections.Nexus.WebUI.Models;

namespace Reflections.Nexus.WebUI.Pages.EmployeeRequest
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

            var employeerequest = await _context.EmployeeRequests

                //.Include(e => e.Employee)
                .Include(e => e.Notification)
                .Include(e => e.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeerequest == null)
            {
                return NotFound();
            }
            EmployeeRequest = employeerequest;
     
            ViewData["NotificationId"] = new SelectList(_context.Notifications, "Id", "Message");
            ViewData["StatusId"] = new SelectList(_context.RequestStatuses, "Id", "Value");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //var NameValidation = _context.EmployeeRequests.Count(x => x.Id != EmployeeRequest.Id && x.Name == EmployeeRequest.name);
            //if (NameValidation != 0)
            //{
            //    ModelState.AddModelError("EmployeeRequest.Name", "EmployeeRequest name already exists");
            //    return Page();
            //}

            //var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            //EmployeeRequest.Updated = DateTime.Now;
            //EmployeeRequest.UpdatedBy = User.Id;
            //EmployeeRequest.UpdatedByNavigation = User;



            //if (!ModelState.IsValid)
            //{
            //    ViewData["NotificationId"] = new SelectList(_context.Notifications, "Id", "Message");
            //    ViewData["StatusId"] = new SelectList(_context.RequestStatuses, "Id", "Value");
            //    return Page();
            //}

            _context.Attach(EmployeeRequest).State = EntityState.Modified;

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