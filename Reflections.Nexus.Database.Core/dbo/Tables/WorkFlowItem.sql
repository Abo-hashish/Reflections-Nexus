CREATE TABLE [dbo].[WorkFlowItem] (
    [WorkFlowItemId]         INT        IDENTITY (1, 1) NOT NULL,
    [WorkFlowId]             INT        NOT NULL,
    [ItemId]                 INT        NOT NULL,
    [SubmitterUserAccountId] INT        NOT NULL,
    [CurrWorkFlowStateId]    INT        NOT NULL,
    [Created]                DATETIME   CONSTRAINT [DF_WorkFlowItem_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]              INT        NOT NULL,
    [Updated]                DATETIME   CONSTRAINT [DF_WorkFlowItem_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]              INT        NOT NULL,
    [RowVersion]             ROWVERSION NOT NULL,
    CONSTRAINT [PK_WorkFlowItem] PRIMARY KEY CLUSTERED ([WorkFlowItemId] ASC),
    CONSTRAINT [FK_WorkFlowItem_UserAccount] FOREIGN KEY ([SubmitterUserAccountId]) REFERENCES [dbo].[UserAccount] ([UserAccountId]),
    CONSTRAINT [FK_WorkFlowItem_Workflow] FOREIGN KEY ([WorkFlowId]) REFERENCES [dbo].[WorkFlow] ([WorkFlowId])
);

