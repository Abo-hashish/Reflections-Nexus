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
using Reflections.Nexus.WebUI.Models;
using Microsoft.Data.SqlClient;

namespace Reflections.Nexus.WebUI.Pages.HeadCountItemHR
{
    public class DetailsModel : PageModel
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;
        private readonly UserResolverService _userService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public DetailsModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context, UserResolverService userService,
             UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userService = userService;
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
            _roleManager = roleManager;
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

            headcountitem.HrcheckBy = User.Id;
            headcountitem.HrcheckDate = DateTime.Now;
            _context.Attach(headcountitem).State = EntityState.Modified;

            if (headcountitem.HeadCountTypeId == 2)
            {
                var employee = new M.Employee();
                employee.FirstName = headcountitem.FirstName;
                employee.MiddleName = headcountitem.MiddleName;
                employee.LastName = headcountitem.LastName;
                employee.BirthDate = headcountitem.BirthDate;
                employee.JoiningDate = headcountitem.JoiningDate;
                employee.Address = headcountitem.Address;
                employee.WorkingModelId = (int)headcountitem.ToWorkingModelId;
                employee.JobTitleId = (int)headcountitem.ToDepartmentJobTitleId;
                employee.EmploymentTypeId = (int)headcountitem.EmploymentTypeId;
                employee.GenderId = (int)headcountitem.GenderId;
                employee.MilitaryStatusId = (int)headcountitem.MilitaryStatusId;
                employee.MaritalStatusId = (int)headcountitem.MaritalStatusId;
                employee.Identification = headcountitem.Identification;
                employee.IdentificationTypeId=(int)headcountitem.IdentificationTypeId;
                employee.JobTypeId = (int)headcountitem.JobTypeId;
                employee.NationalityId = (int)headcountitem.NationalityId;
                employee.Salary = (int)headcountitem.Salary;
                employee.CityId = 1;
                employee.WorkingModelId = (int)headcountitem.ToWorkingModelId;
                string email = headcountitem.FirstName.Replace(" ", "").ToLower() + "." + headcountitem.LastName.Replace(" ", "").ToLower() + "@reflections-ibs.com";
                employee.Email = email;
                employee.Created = DateTime.Now;
                employee.Updated = DateTime.Now;
                employee.CreatedBy = User.Id;
                employee.UpdatedBy = User.Id;

                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                headcountitem.EmployeeId = employee.Id;

                _context.HeadCountItems.Update(headcountitem);


                var user = CreateUser();

                user.FirstName = headcountitem.FirstName;
                user.LastName = headcountitem.LastName;
                user.UserName = headcountitem.FirstName.Replace(" ", "").ToLower() + "." + headcountitem.LastName.Replace(" ", "").ToLower() + "@reflections-ibs.com";
                user.Email = headcountitem.FirstName.Replace(" ", "").ToLower() + "." + headcountitem.LastName.Replace(" ", "").ToLower() + "@reflections-ibs.com";
                user.IsActive = true;
                user.EmailConfirmed = true;


                var result = await _userManager.CreateAsync(user, "P@ssw0rd");

                if (result.Succeeded)
                {
                    var defaultrole = _roleManager.FindByIdAsync("11").Result;
                    if (defaultrole != null)
                    {
                        IdentityResult roleresult = await _userManager.AddToRoleAsync(user, defaultrole.Name);
                    }
                }

            }

            if (headcountitem.HeadCountTypeId == 1) // Promote
            {
                // Step 1: Fetch the Employee using EmployeeId
                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == headcountitem.EmployeeId);
                if (employee == null)
                {
                    throw new Exception("Employee not found.");
                }

                // Step 2: Fetch the Account (User) using Employee.Email
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == employee.Email);
                if (user == null)
                {
                    throw new Exception($"No account found for email {employee.Email}.");
                }

                // Step 3: Fetch the Manager Role ID
                var managerRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Manager");
                if (managerRole == null)
                {
                    throw new Exception("Role 'Manager' not found in the database.");
                }

                // Step 4: Update the User's Role in the UserRoles Table
                string updateRoleQuery = @"
                INSERT INTO UserRoles
                VALUES (@UserId , @RoleId)";

                await _context.Database.ExecuteSqlRawAsync(updateRoleQuery,
                    new SqlParameter("@UserId", user.Id),
                    new SqlParameter("@RoleId", managerRole.Id)); // New Role ID for "Manager"
                     // Existing User ID

                Console.WriteLine($"User {user.UserName} successfully promoted to 'Manager'.");
            }



            if (headcountitem.HeadCountTypeId == 3 || headcountitem.HeadCountTypeId == 5 || headcountitem.HeadCountTypeId == 6) // Resign / Quit / Retire / Fire
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == headcountitem.EmployeeId);
                if (employee == null)
                {
                    throw new Exception("Employee not found.");
                }

                // Step 2: Update the Employee's ExitDate
                string updateEmployeeQuery = @"
                                            UPDATE Employee
                                            SET ExitDate = @ExitDate, Updated=@DateNow, UpdatedBy=@AccountId
                                            WHERE Id = @EmployeeId";

                await _context.Database.ExecuteSqlRawAsync(updateEmployeeQuery,
                    new SqlParameter("@ExitDate", DateTime.Now), // Set ExitDate to current date and time
                    new SqlParameter("@DateNow", DateTime.Now),
                    new SqlParameter("@AccountId",User.Id),
                    new SqlParameter("@EmployeeId", employee.Id));

                // Step 3: Fetch the User associated with the Employee
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == employee.Email);
                if (user == null)
                {
                    throw new Exception($"No account found for email {employee.Email}.");
                }

                // Step 4: Update the User's IsActive Property
                string updateUserQuery = @"
                                            UPDATE Users
                                            SET IsActive = @IsActive
                                            WHERE Id = @UserId";

                await _context.Database.ExecuteSqlRawAsync(updateUserQuery,
                    new SqlParameter("@IsActive", false), // Set IsActive to false
                    new SqlParameter("@UserId", user.Id));

                // Log Success
                Console.WriteLine($"Employee {employee.FirstName} {employee.LastName} has been terminated. User account deactivated.");
            }

            if (headcountitem.HeadCountTypeId == 4) // Transfer
            {
                try
                {
                    int ToJobTitleID = (int)headcountitem.ToDepartmentJobTitleId;
                    int empID = (int)headcountitem.EmployeeId;

                    string query = "UPDATE Employee SET JobTitleID = @ToJobTitleID WHERE Id = @empID";
                    _context.Database.ExecuteSqlRaw(query,
                        new SqlParameter("@ToJobTitleID", ToJobTitleID),
                        new SqlParameter("@empID", empID));

                    Console.WriteLine("Employee JobTitleID updated successfully.");
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine($"Database update error: {ex.Message}");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }


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
