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

namespace Reflections.Nexus.WebUI.Pages.SocialLink
{
    [Authorize(Roles = "Administrator,Manager")]
    public class IndexModel : BasePageModel<IndexModel>
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;
        private readonly UserResolverService _userService;

        public IndexModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<M.SocialLink> SocialLink { get;set; } = default!;

        public async Task OnGetAsync()
        {
            SocialLink = await _context.SocialLinks
                .Include(s => s.Company)
                .Include(s => s.SocialType)
            //.Include(c => c.CreatedByNavigation)
            //.Include(c => c.UpdatedByNavigation)
            .ToListAsync();
        }
    }
}
