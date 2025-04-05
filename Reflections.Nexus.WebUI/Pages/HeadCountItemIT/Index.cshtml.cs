using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Reflections.Nexus.WebUI.Code;
using Reflections.Nexus.WebUI.Data;
using Reflections.Nexus.WebUI.Services;
using Reflections.Nexus.WebUI.Data;
using M=Reflections.Nexus.WebUI.Models;
using Reflections.Nexus.WebUI.ViewModels;

namespace Reflections.Nexus.WebUI.Pages.HeadCountItemIT
{
    [Authorize(Roles = "Administrator,Manager,CEO,MD,hr,It")]
    public class IndexModel : BasePageModel<IndexModel>
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;
        private readonly UserResolverService _userService;

        public IndexModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<M.HeadCountItem> HeadCountItem { get;set; } = default!;

        //public IList<CountryViewModel> data { get; set; } = default!;

        public async Task OnGetAsync()
        {

            //data = await _context.Database.SqlQueryRaw<CountryViewModel>("select Id, Name from country", parm1).ToListAsync();



            HeadCountItem = await _context.HeadCountItems.Where(h => h.ItcheckBy == null && h.HrcheckBy != null )
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
                .Include(h => h.ToWorkingModel)
            //.Include(c => c.CreatedByNavigation)
            //.Include(c => c.UpdatedByNavigation)
            .ToListAsync();
        }
    }
}
