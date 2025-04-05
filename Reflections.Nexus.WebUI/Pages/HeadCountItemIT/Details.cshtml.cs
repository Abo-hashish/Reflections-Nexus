using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Reflections.Nexus.WebUI.Services;
using Reflections.Nexus.WebUI.Data;
using M = Reflections.Nexus.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Reflections.Nexus.WebUI.Code;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;
using Reflections.Nexus.WebUI.ViewModels;

namespace Reflections.Nexus.WebUI.Pages.HeadCountItemIT
{
    public class DetailsModel : PageModel
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;
        private readonly UserResolverService _userService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;

        public DetailsModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context, UserResolverService userService,
             UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userService = userService;
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
        }

        [BindProperty]
        public M.HeadCountItem HeadCountItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headcountitem = await _context.HeadCountItems
                        .Include(h => h.Employee)
                        .Include(h => h.FromDepartmentJobTitle)
                        .Include(h => h.FromWorkingModel)
                        .Include(h => h.Gender)
                        .Include(h => h.HeadCountType)
                        .Include(h => h.IdentificationType)
                        .Include(h => h.JobType)
                        .Include(h => h.Manager)
                        .Include(h => h.MaritalStatus)
                        .Include(h => h.MilitaryStatus)
                        .Include(h => h.Nationality)
                        .Include(h => h.ToDepartmentJobTitle)
                        .Include(h => h.ToWorkingModel).FirstOrDefaultAsync(m => m.Id == id);
            if (headcountitem == null)
            {
                return NotFound();
            }
            else
            {
                HeadCountItem = headcountitem;
            }
            return Page();
        }

        public string GetUserNameById(int id)
        {
            return _context.Users.Where(e => e.Id == id).FirstOrDefault().DisplayName;
        }

        public async Task<IActionResult>
           OnPostAsync()
        {

            var headcountitem = await _context.HeadCountItems
               .FirstOrDefaultAsync(m => m.Id == HeadCountItem.Id);

            var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

            headcountitem.ItcheckBy = User.Id;
            headcountitem.ItcheckDate = DateTime.Now;
            _context.Attach(headcountitem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeadCountItemExists(HeadCountItem.Id))
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

        private bool HeadCountItemExists(int id)
        {
            return _context.HeadCountItems.Any(e => e.Id == id);
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
    }
}
