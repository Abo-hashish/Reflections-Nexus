CREATE TABLE [dbo].[RoleCapability] (
    [RoleCapabilityId] INT        IDENTITY (1, 1) NOT NULL,
    [RoleId]           INT        NOT NULL,
    [CapabilityId]     INT        NOT NULL,
    [AccessFlag]       TINYINT    NOT NULL,
    [Created]          DATETIME   CONSTRAINT [DF_RoleCapability_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]        INT        NOT NULL,
    [Updated]          DATETIME   CONSTRAINT [DF_RoleCapability_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]        INT        NOT NULL,
    [RowVersion]       ROWVERSION NOT NULL,
    CONSTRAINT [PK_RoleCapability] PRIMARY KEY CLUSTERED ([RoleCapabilityId] ASC),
    CONSTRAINT [FK_RoleCapability_Capability] FOREIGN KEY ([CapabilityId]) REFERENCES [dbo].[Capability] ([CapabilityId]),
    CONSTRAINT [FK_RoleCapability_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId]) ON DELETE CASCADE,
    CONSTRAINT [IX_RoleCapability] UNIQUE NONCLUSTERED ([RoleId] ASC, [CapabilityId] ASC)
);

