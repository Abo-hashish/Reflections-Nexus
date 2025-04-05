using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reflections.Nexus.WebUI.ViewModels
{
    public class TurnoverViewModel
    {
        public string Department { get; set; }
        public int Count1 { get; set; }
        public int Count2 { get; set; }
    }
}
