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


namespace Reflections.Nexus.WebUI.Pages.Turnover
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


        public IList<M.TurnoverViewModel> Data2 { get; set; } = default!;





        public async Task OnGetAsync()
        {


            Data2 = await _context.Database.SqlQuery<M.TurnoverViewModel>(
           @$"SELECT 
            d.Name AS Department,
             COUNT(CASE 
             WHEN DATEDIFF(YEAR, e.JoiningDate, GETDATE()) >= 1 AND e.ExitDate IS NULL THEN 1 
             END) AS Count1,
               COUNT(CASE 
           WHEN DATEDIFF(YEAR, e.JoiningDate, e.ExitDate) < 1 AND e.ExitDate IS NOT NULL THEN 1 
             END) AS Count2
            FROM 
             dbo.Employee e
            INNER JOIN 
            dbo.JobTitle jt ON e.JobTitleId = jt.Id
            INNER JOIN 
             dbo.Department d ON jt.DepartmentId = d.Id
            Where d.IsActive=1
            GROUP BY 
             d.Name;")
           .ToListAsync();
        }
    }
}
