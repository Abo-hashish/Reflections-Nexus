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


namespace Reflections.Nexus.WebUI.Pages.DepartmentStatistics
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

        public IList<M.DepartmentStatistics> Data { get; set; } = default!;

        public IList<M.DepartmentStatistics2> Data2 { get; set; } = default!;





        public async Task OnGetAsync()
        {

            Data = await _context.Database.SqlQuery<M.DepartmentStatistics>(
                @$"SELECT d.Name As Department, AVG(E.Salary) AS Statistic
                FROM  dbo.Department AS d INNER JOIN
                dbo.JobTitle AS jt ON d.Id = jt.DepartmentId INNER JOIN
                dbo.Employee AS E ON jt.Id = E.JobTitleId
                GROUP BY d.Name
                ORDER BY Statistic DESC;")
                .ToListAsync();


            Data2 = await _context.Database.SqlQuery<M.DepartmentStatistics2>(
           @$"SELECT d.Name As Department, COUNT(*) AS Statistic, COUNT(*) * 100.0 /
            (SELECT COUNT(*) AS Expr1
            FROM  dbo.Employee) AS Percentage
            FROM  dbo.Department AS d INNER JOIN
            dbo.JobTitle AS jt ON d.Id = jt.DepartmentId INNER JOIN
            dbo.Employee AS E ON jt.Id = E.JobTitleId
            GROUP BY d.Name
            ORDER BY Statistic DESC;")
           .ToListAsync();
        }
    }
}
