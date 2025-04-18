﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Reflections.Nexus.WebUI.Code;

namespace Reflections.Nexus.WebUI.Models;

[Table("Department")]
[Index("CompanyId", Name = "IX_Department_CompanyId")]
[Index("ManagerId", Name = "IX_Department_ManagerId")]
public partial class Department : BaseEntity
{

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Display(Name = "Company")]
    public int CompanyId { get; set; }

    [Display(Name = "Manager")]
    public int? ManagerId { get; set; }

    [Display(Name = "Is Active?")]
    public bool IsActive { get; set; }

   
    [ForeignKey("CompanyId")]
    [InverseProperty("Departments")]
    public virtual Company Company { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<JobTitle> JobTitles { get; set; } = new List<JobTitle>();

    [ForeignKey("ManagerId")]
    [InverseProperty("Departments")]
    public virtual Employee Manager { get; set; }
}