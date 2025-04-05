CREATE TABLE [dbo].[AuditObjectProperty] (
    [AuditObjectPropertyId] INT           IDENTITY (1, 1) NOT NULL,
    [AuditObjectId]         INT           NOT NULL,
    [PropertyName]          VARCHAR (255) NOT NULL,
    [Created]               DATETIME      NOT NULL,
    [CreatedBy]             INT           NOT NULL,
    [Updated]               DATETIME      NOT NULL,
    [UpdatedBy]             INT           NOT NULL,
    [RowVersion]            ROWVERSION    NOT NULL,
    CONSTRAINT [PK_AuditObjectProperty] PRIMARY KEY CLUSTERED ([AuditObjectPropertyId] ASC),
    CONSTRAINT [FK_AuditObjectProperty_AuditObject] FOREIGN KEY ([AuditObjectId]) REFERENCES [dbo].[AuditObject] ([AuditObjectId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AuditObjectProperty]
    ON [dbo].[AuditObjectProperty]([AuditObjectId] ASC, [PropertyName] ASC);

