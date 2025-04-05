CREATE TABLE [dbo].[WorkFlowOwnerGroup] (
    [WorkFlowOwnerGroupId] INT           IDENTITY (1, 1) NOT NULL,
    [WorkFlowId]           INT           NOT NULL,
    [OwnerGroupName]       VARCHAR (50)  NOT NULL,
    [DefaultUserAccountId] INT           NULL,
    [IsDefaultSameAsLast]  BIT           NOT NULL,
    [Description]          VARCHAR (255) NULL,
    [Created]              DATETIME      NOT NULL,
    [CreatedBy]            INT           NOT NULL,
    [Updated]              DATETIME      NOT NULL,
    [UpdatedBy]            INT           NOT NULL,
    [RowVersion]           ROWVERSION    NOT NULL,
    CONSTRAINT [PK_WorkFlowOwnerGroup] PRIMARY KEY CLUSTERED ([WorkFlowOwnerGroupId] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_WorkFlowOwnerGroup]
    ON [dbo].[WorkFlowOwnerGroup]([WorkFlowId] ASC, [OwnerGroupName] ASC);

