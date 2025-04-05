CREATE TABLE [dbo].[Audit] (
    [AuditId]      INT           IDENTITY (1, 1) NOT NULL,
    [ObjectName]   VARCHAR (255) NOT NULL,
    [RecordId]     INT           NOT NULL,
    [PropertyName] VARCHAR (255) NULL,
    [OldValue]     VARCHAR (MAX) NULL,
    [NewValue]     VARCHAR (MAX) NULL,
    [AuditType]    TINYINT       NOT NULL,
    [Created]      DATETIME      CONSTRAINT [DF_Audit_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]    INT           NOT NULL,
    [Updated]      DATETIME      CONSTRAINT [DF_Audit_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]    INT           NOT NULL,
    [RowVersion]   ROWVERSION    NOT NULL,
    CONSTRAINT [PK_Audit] PRIMARY KEY CLUSTERED ([AuditId] ASC)
);

