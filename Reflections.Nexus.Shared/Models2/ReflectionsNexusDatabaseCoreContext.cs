﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Reflections.Nexus.Shared.Models2;

public partial class ReflectionsNexusDatabaseCoreContext : DbContext
{
    public ReflectionsNexusDatabaseCoreContext(DbContextOptions<ReflectionsNexusDatabaseCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Audit> Audits { get; set; }

    public virtual DbSet<AuditObject> AuditObjects { get; set; }

    public virtual DbSet<AuditObjectProperty> AuditObjectProperties { get; set; }

    public virtual DbSet<Capability> Capabilities { get; set; }

    public virtual DbSet<Email> Emails { get; set; }

    public virtual DbSet<Holiday> Holidays { get; set; }

    public virtual DbSet<MenuItem> MenuItems { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationUserAccount> NotificationUserAccounts { get; set; }

    public virtual DbSet<NotificationWorkFlowState> NotificationWorkFlowStates { get; set; }

    public virtual DbSet<PaidTimeOffDayType> PaidTimeOffDayTypes { get; set; }

    public virtual DbSet<PaidTimeOffRequest> PaidTimeOffRequests { get; set; }

    public virtual DbSet<PaidTimeOffRequestType> PaidTimeOffRequestTypes { get; set; }

    public virtual DbSet<PaidTimeOffVacationBank> PaidTimeOffVacationBanks { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleCapability> RoleCapabilities { get; set; }

    public virtual DbSet<RoleUserAccount> RoleUserAccounts { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    public virtual DbSet<WorkFlow> WorkFlows { get; set; }

    public virtual DbSet<WorkFlowItem> WorkFlowItems { get; set; }

    public virtual DbSet<WorkFlowItemOwner> WorkFlowItemOwners { get; set; }

    public virtual DbSet<WorkFlowItemStateHistory> WorkFlowItemStateHistories { get; set; }

    public virtual DbSet<WorkFlowOwnerGroup> WorkFlowOwnerGroups { get; set; }

    public virtual DbSet<WorkFlowOwnerGroupUserAccount> WorkFlowOwnerGroupUserAccounts { get; set; }

    public virtual DbSet<WorkFlowState> WorkFlowStates { get; set; }

    public virtual DbSet<WorkFlowStateProperty> WorkFlowStateProperties { get; set; }

    public virtual DbSet<WorkFlowTransition> WorkFlowTransitions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Audit>(entity =>
        {
            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Updated).HasDefaultValueSql("getdate()");
        });

        modelBuilder.Entity<AuditObject>(entity =>
        {
            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Updated).HasDefaultValueSql("getdate()");
        });

        modelBuilder.Entity<AuditObjectProperty>(entity =>
        {
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.AuditObject).WithMany(p => p.AuditObjectProperties).HasConstraintName("FK_AuditObjectProperty_AuditObject");
        });

        modelBuilder.Entity<Capability>(entity =>
        {
            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Updated).HasDefaultValueSql("getdate()");

            entity.HasOne(d => d.MenuItem).WithMany(p => p.Capabilities).HasConstraintName("FK_Capability_MenuItem");
        });

        modelBuilder.Entity<Email>(entity =>
        {
            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Updated).HasDefaultValueSql("getdate()");
        });

        modelBuilder.Entity<Holiday>(entity =>
        {
            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Updated).HasDefaultValueSql("getdate()");
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Updated).HasDefaultValueSql("getdate()");

            entity.HasOne(d => d.ParentMenuItem).WithMany(p => p.InverseParentMenuItem).HasConstraintName("FK_MenuItem_MenuItem");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.Property(e => e.NotificationId).ValueGeneratedNever();
            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Updated).HasDefaultValueSql("getdate()");
        });

        modelBuilder.Entity<NotificationUserAccount>(entity =>
        {
            entity.HasKey(e => e.NotificationUserAccountId).HasName("PK_NotificationUserAccountId");

            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Updated).HasDefaultValueSql("getdate()");

            entity.HasOne(d => d.Notification).WithMany(p => p.NotificationUserAccounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationUserAccount_Notification");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.NotificationUserAccounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationUserAccount_UserAccount");
        });

        modelBuilder.Entity<NotificationWorkFlowState>(entity =>
        {
            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Updated).HasDefaultValueSql("getdate()");

            entity.HasOne(d => d.NotificationUserAccount).WithMany(p => p.NotificationWorkFlowStates).HasConstraintName("FK_NotificationWorkFlowState_NotificationUserAccount");

            entity.HasOne(d => d.WorkFlowState).WithMany(p => p.NotificationWorkFlowStates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationWorkFlowState_WorkFlowState");
        });

        modelBuilder.Entity<PaidTimeOffDayType>(entity =>
        {
            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Updated).HasDefaultValueSql("getdate()");
        });

        modelBuilder.Entity<PaidTimeOffRequest>(entity =>
        {
            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Updated).HasDefaultValueSql("getdate()");

            entity.HasOne(d => d.PaidTimeOffDayType).WithMany(p => p.PaidTimeOffRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaidTimeOffRequest_PaidTimeOffDayType");

            entity.HasOne(d => d.PaidTimeOffRequestType).WithMany(p => p.PaidTimeOffRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaidTimeOffRequest_PaidTimeOffRequestType");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.PaidTimeOffRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaidTimeOffRequest_UserAccount");
        });

        modelBuilder.Entity<PaidTimeOffRequestType>(entity =>
        {
            entity.HasKey(e => e.PaidTimeOffRequestTypeId).HasName("PK_PaidTimeOffVacationDayType");

            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Updated).HasDefaultValueSql("getdate()");
        });

        modelBuilder.Entity<PaidTimeOffVacationBank>(entity =>
        {
            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Updated).HasDefaultValueSql("getdate()");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.PaidTimeOffVacationBanks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaidTimeOffVacationBank_UserAccount");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Updated).HasDefaultValueSql("getdate()");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Updated).HasDefaultValueSql("getdate()");
        });

        modelBuilder.Entity<RoleCapability>(entity =>
        {
            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Updated).HasDefaultValueSql("getdate()");

            entity.HasOne(d => d.Capability).WithMany(p => p.RoleCapabilities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoleCapability_Capability");

            entity.HasOne(d => d.Role).WithMany(p => p.RoleCapabilities).HasConstraintName("FK_RoleCapability_Role");
        });

        modelBuilder.Entity<RoleUserAccount>(entity =>
        {
            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Updated).HasDefaultValueSql("getdate()");

            entity.HasOne(d => d.Role).WithMany(p => p.RoleUserAccounts).HasConstraintName("FK_RoleUserAccount_Role");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.RoleUserAccounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoleUserAccount_UserAccount");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Updated).HasDefaultValueSql("getdate()");
        });

        modelBuilder.Entity<WorkFlow>(entity =>
        {
            entity.HasKey(e => e.WorkFlowId).HasName("PK_Workflow");

            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<WorkFlowItem>(entity =>
        {
            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Updated).HasDefaultValueSql("getdate()");

            entity.HasOne(d => d.SubmitterUserAccount).WithMany(p => p.WorkFlowItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkFlowItem_UserAccount");

            entity.HasOne(d => d.WorkFlow).WithMany(p => p.WorkFlowItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkFlowItem_Workflow");
        });

        modelBuilder.Entity<WorkFlowItemOwner>(entity =>
        {
            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Updated).HasDefaultValueSql("getdate()");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.WorkFlowItemOwners).HasConstraintName("FK_WorkFlowItemOwner_UserAccount");

            entity.HasOne(d => d.WorkFlowItem).WithMany(p => p.WorkFlowItemOwners)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkFlowItemOwner_WorkFlowItem");

            entity.HasOne(d => d.WorkFlowOwnerGroup).WithMany(p => p.WorkFlowItemOwners)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkFlowItemOwner_WorkFlowOwnerGroup");
        });

        modelBuilder.Entity<WorkFlowItemStateHistory>(entity =>
        {
            entity.HasKey(e => e.WorkFlowItemStateHistoryId).HasName("PK_WorkFlowItemTransition");

            entity.Property(e => e.Created).HasDefaultValueSql("getdate()");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Updated).HasDefaultValueSql("getdate()");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.WorkFlowItemStateHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkFlowItemStateHistory_UserAccount");

            entity.HasOne(d => d.WorkFlowItem).WithMany(p => p.WorkFlowItemStateHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkFlowItemStateHistory_WorkFlowItem");

            entity.HasOne(d => d.WorkFlowState).WithMany(p => p.WorkFlowItemStateHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkFlowItemStateHistory_WorkFlowState");
        });

        modelBuilder.Entity<WorkFlowOwnerGroup>(entity =>
        {
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<WorkFlowOwnerGroupUserAccount>(entity =>
        {
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.UserAccount).WithMany(p => p.WorkFlowOwnerGroupUserAccounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkFlowOwnerGroupUserAccount_UserAccount");

            entity.HasOne(d => d.WorkFlowOwnerGroup).WithMany(p => p.WorkFlowOwnerGroupUserAccounts).HasConstraintName("FK_WorkFlowOwnerGroupUserAccount_WorkFlowOwnerGroup");
        });

        modelBuilder.Entity<WorkFlowState>(entity =>
        {
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.WorkFlow).WithMany(p => p.WorkFlowStates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkFlowState_Workflow");

            entity.HasOne(d => d.WorkFlowOwnerGroup).WithMany(p => p.WorkFlowStates).HasConstraintName("FK_WorkFlowState_WorkFlowOwnerGroup");
        });

        modelBuilder.Entity<WorkFlowStateProperty>(entity =>
        {
            entity.HasKey(e => e.WorkFlowStatePropertyId).HasName("PK_WorkFlowStateField");

            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.WorkFlowState).WithMany(p => p.WorkFlowStateProperties).HasConstraintName("FK_WorkFlowStateField_WorkFlowState");
        });

        modelBuilder.Entity<WorkFlowTransition>(entity =>
        {
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.FromWorkFlowState).WithMany(p => p.WorkFlowTransitionFromWorkFlowStates).HasConstraintName("FK_WorkFlowTransition_WorkFlowState");

            entity.HasOne(d => d.ToWorkFlowState).WithMany(p => p.WorkFlowTransitionToWorkFlowStates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkFlowTransition_WorkFlowState1");

            entity.HasOne(d => d.WorkFlow).WithMany(p => p.WorkFlowTransitions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkFlowTransition_Workflow");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}