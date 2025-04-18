﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reflections.Nexus.Shared.Models;

[Table("Identification")]
public partial class Identification
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Type { get; set; } = null!;

    public DateTime Created { get; set; }

    [StringLength(50)]
    public string CreatedBy { get; set; } = null!;

    public DateTime Updated { get; set; }

    [StringLength(50)]
    public string UpdatedBy { get; set; } = null!;

    public byte[] RowVersion { get; set; } = null!;
}