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
using M=Reflections.Nexus.WebUI.ViewModels;

namespace Reflections.Nexus.WebUI.Pages.SalaryStatistics
{
    [Authorize(Roles = "Administrator,CEO,MD,hr")]
    public class IndexModel : BasePageModel<IndexModel>
    {
        private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;
        private readonly UserResolverService _userService;

        public IndexModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<M.SalaryStatistics> statistics { get;set; } = default!;

        public int AverageSalary { get; set; }
        public int MaximumSalary { get; set; }
        public int MinimumSalary { get; set; }


        public async Task OnGetAsync()
{
        // var statistics = await _context.SalaryStatistics
        //.FromSqlInterpolated($@"
        //    SELECT 
        //        AVG(Salary) AS AverageSalary, 
        //        MAX(Salary) AS MaximumSalary, 
        //        MIN(Salary) AS MinimumSalary
        //    FROM Employee")
        //.FirstOrDefaultAsync();

         var statistics = await _context.Database.SqlQuery<M.SalaryStatistics>($@"
            SELECT 
                AVG(Salary) AS AverageSalary, 
                MAX(Salary) AS MaximumSalary, 
                MIN(Salary) AS MinimumSalary
            FROM Employee")
            .FirstOrDefaultAsync();

            if (statistics != null)
         {
            AverageSalary = statistics.AverageSalary;
            MaximumSalary = statistics.MaximumSalary;
            MinimumSalary = statistics.MinimumSalary;
         }
}

    }
}
