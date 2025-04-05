using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace Reflections.Nexus.WebUI.ViewModels
{
    public class AttritionViewModel
    {
        public string Department { get; set; }
        public decimal Statistic { get; set; }
    }
}
