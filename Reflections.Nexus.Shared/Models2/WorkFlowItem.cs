﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reflections.Nexus.Shared.Models2;

[Table("WorkFlowItem")]
public partial class WorkFlowItem
{
    [Key]
    public int WorkFlowItemId { get; set; }

    public int WorkFlowId { get; set; }

    public int ItemId { get; set; }

    public int SubmitterUserAccountId { get; set; }

    public int CurrWorkFlowStateId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Created { get; set; }

    public int CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Updated { get; set; }

    public int UpdatedBy { get; set; }

    [Required]
    public byte[] RowVersion { get; set; }

    [ForeignKey("SubmitterUserAccountId")]
    [InverseProperty("WorkFlowItems")]
    public virtual UserAccount SubmitterUserAccount { get; set; }

    [ForeignKey("WorkFlowId")]
    [InverseProperty("WorkFlowItems")]
    public virtual WorkFlow WorkFlow { get; set; }

    [InverseProperty("WorkFlowItem")]
    public virtual ICollection<WorkFlowItemOwner> WorkFlowItemOwners { get; set; } = new List<WorkFlowItemOwner>();

    [InverseProperty("WorkFlowItem")]
    public virtual ICollection<WorkFlowItemStateHistory> WorkFlowItemStateHistories { get; set; } = new List<WorkFlowItemStateHistory>();
}