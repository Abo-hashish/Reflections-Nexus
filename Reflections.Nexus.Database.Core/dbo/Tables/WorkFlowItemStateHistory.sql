CREATE TABLE [dbo].[WorkFlowItemStateHistory] (
    [WorkFlowItemStateHistoryId] INT        IDENTITY (1, 1) NOT NULL,
    [WorkFlowItemId]             INT        NOT NULL,
    [WorkFlowStateId]            INT        NOT NULL,
    [UserAccountId]              INT        NOT NULL,
    [Created]                    DATETIME   CONSTRAINT [DF_WorkFlowItemTransition_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]                  INT        NOT NULL,
    [Updated]                    DATETIME   CONSTRAINT [DF_WorkFlowItemTransition_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]                  INT        NOT NULL,
    [RowVersion]                 ROWVERSION NOT NULL,
    CONSTRAINT [PK_WorkFlowItemTransition] PRIMARY KEY CLUSTERED ([WorkFlowItemStateHistoryId] ASC),
    CONSTRAINT [FK_WorkFlowItemStateHistory_UserAccount] FOREIGN KEY ([UserAccountId]) REFERENCES [dbo].[UserAccount] ([UserAccountId]),
    CONSTRAINT [FK_WorkFlowItemStateHistory_WorkFlowItem] FOREIGN KEY ([WorkFlowItemId]) REFERENCES [dbo].[WorkFlowItem] ([WorkFlowItemId]),
    CONSTRAINT [FK_WorkFlowItemStateHistory_WorkFlowState] FOREIGN KEY ([WorkFlowStateId]) REFERENCES [dbo].[WorkFlowState] ([WorkFlowStateId])
);

