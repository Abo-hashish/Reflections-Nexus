﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Reflections.Nexus.WebUI.Code;

namespace Reflections.Nexus.WebUI.Models;

[Index("EmployeeId", Name = "IX_EmployeeFiles_EmployeeId")]
[Index("FileTypeId", Name = "IX_EmployeeFiles_FileTypeId")]
public partial class EmployeeFile : BaseEntity
{
    [Display(Name = "File Type")]
    public int FileTypeId { get; set; }

    [Display(Name = "Employerr")]
    public int EmployeeId { get; set; }

    [Required]
    [Column("FileURL")]
    [StringLength(200)]
    [Display(Name = "File URL")]
    public string FileUrl { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("EmployeeFiles")]
    public virtual Employee Employee { get; set; }

    [ForeignKey("FileTypeId")]
    [InverseProperty("EmployeeFiles")]
    public virtual EmployeeFileType FileType { get; set; }
}