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
using M = Reflections.Nexus.WebUI.ViewModels;
using Reflections.Nexus.WebUI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Reflections.Nexus.WebUI.Pages.Attrition
{
    [Authorize(Roles = "Administrator,hr,Manager,CEO,MD")]
    public class IndexModel : BasePageModel<IndexModel>
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;
        private readonly UserResolverService _userService;

        public IndexModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context)
        {
            _context = context;
        }


        public IList<M.AttritionViewModel> Data2 { get; set; } = default!;





        public async Task OnGetAsync()
        {


            Data2 = await _context.Database.SqlQuery<M.AttritionViewModel>(
           @$"SELECT 
            d.Name AS Department,
            COUNT(CASE WHEN e.ExitDate IS NOT NULL THEN 1 END) * 100.0 / COUNT(*) AS Statistic
            FROM 
            dbo.Employee e
            INNER JOIN 
            dbo.JobTitle jt ON e.JobTitleId = jt.Id
            INNER JOIN 
            dbo.Department d ON jt.DepartmentId = d.Id
            WHERE 
            d.IsActive = 1
            GROUP BY 
            d.Name")
           .ToListAsync();
        }
    }
}
