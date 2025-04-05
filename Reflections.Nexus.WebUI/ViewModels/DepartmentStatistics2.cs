using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reflections.Nexus.WebUI.ViewModels
{
    public class DepartmentStatistics2
    {
        public string Department { get; set; }
        public int Statistic { get; set; }
        public Decimal Percentage { get; set; }
    }
}
