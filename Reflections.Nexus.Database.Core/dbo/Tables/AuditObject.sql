CREATE TABLE [dbo].[AuditObject] (
    [AuditObjectId]            INT           IDENTITY (1, 1) NOT NULL,
    [ObjectName]               VARCHAR (255) NOT NULL,
    [ObjectFullyQualifiedName] VARCHAR (255) NOT NULL,
    [Created]                  DATETIME      CONSTRAINT [DF_AuditObject_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]                INT           NOT NULL,
    [Updated]                  DATETIME      CONSTRAINT [DF_AuditObject_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]                INT           NOT NULL,
    [RowVersion]               ROWVERSION    NOT NULL,
    CONSTRAINT [PK_AuditObject] PRIMARY KEY CLUSTERED ([AuditObjectId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_AuditObject]
    ON [dbo].[AuditObject]([ObjectName] ASC);

