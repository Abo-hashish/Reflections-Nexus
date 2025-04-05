CREATE TABLE [dbo].[Capability] (
    [CapabilityId]   INT          IDENTITY (1, 1) NOT NULL,
    [CapabilityName] VARCHAR (50) NOT NULL,
    [MenuItemId]     INT          NULL,
    [AccessType]     TINYINT      NOT NULL,
    [Created]        DATETIME     CONSTRAINT [DF_Capability_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]      INT          NOT NULL,
    [Updated]        DATETIME     CONSTRAINT [DF_Capability_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]      INT          NOT NULL,
    [RowVersion]     ROWVERSION   NOT NULL,
    CONSTRAINT [PK_Capability] PRIMARY KEY CLUSTERED ([CapabilityId] ASC),
    CONSTRAINT [FK_Capability_MenuItem] FOREIGN KEY ([MenuItemId]) REFERENCES [dbo].[MenuItem] ([MenuItemId]),
    CONSTRAINT [IX_Capability] UNIQUE NONCLUSTERED ([CapabilityName] ASC)
);

