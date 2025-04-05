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

namespace Reflections.Nexus.WebUI.Pages.EmployeeTelephoneNumber
{
    [Authorize(Roles = "Administrator,hr,It")]
    public class IndexModel : BasePageModel<IndexModel>
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;
        private readonly UserResolverService _userService;

        public IndexModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<M.EmployeeTelephoneNumber> EmployeeTelephoneNumber { get;set; } = default!;

        public async Task OnGetAsync()
        {
            EmployeeTelephoneNumber = await _context.EmployeeTelephoneNumber
                .Include(e => e.Employee)
                .Include(e => e.Type)
            //.Include(c => c.CreatedByNavigation)
            //.Include(c => c.UpdatedByNavigation)
            .ToListAsync();
        }
    }
}
