﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reflections.Nexus.WebUI.Models;

[Table("HeadCountType")]
public partial class HeadCountType
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Value { get; set; }

    [InverseProperty("HeadCountType")]
    public virtual ICollection<HeadCountItem> HeadCountItems { get; set; } = new List<HeadCountItem>();
}