﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reflections.Nexus.WebUI.Models;

[Table("CompanyType")]
public partial class CompanyType
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Value { get; set; }

    [InverseProperty("CompanyType")]
    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}