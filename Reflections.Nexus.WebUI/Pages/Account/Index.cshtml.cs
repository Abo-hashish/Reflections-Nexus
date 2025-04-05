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
using Reflections.Nexus.WebUI.Code;
using Reflections.Nexus.WebUI.Data;

namespace Reflections.Nexus.WebUI.Pages.Account
{
    //[Authorize(Roles = "Administrator")]
    public class IndexModel : BasePageModel<IndexModel>
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;
        private readonly UserResolverService _userService;

        public IndexModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ApplicationUser> ApplicationUser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ApplicationUser = await _context.Users
            //.Include(c => c.CreatedByNavigation)
            //.Include(c => c.UpdatedByNavigation)
            .ToListAsync();
        }
    }
}
