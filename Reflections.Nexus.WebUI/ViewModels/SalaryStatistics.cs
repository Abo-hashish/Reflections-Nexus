using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reflections.Nexus.WebUI.ViewModels
{
    public class SalaryStatistics
    {
        public int AverageSalary { get; set; }
        public int MaximumSalary { get; set; }
        public int MinimumSalary { get; set; }
    }
}
