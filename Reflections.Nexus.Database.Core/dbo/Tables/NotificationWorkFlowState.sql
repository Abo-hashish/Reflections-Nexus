CREATE TABLE [dbo].[NotificationWorkFlowState] (
    [NotificationWorkFlowStateId] INT        IDENTITY (1, 1) NOT NULL,
    [NotificationUserAccountId]   INT        NOT NULL,
    [WorkFlowStateId]             INT        NOT NULL,
    [Created]                     DATETIME   CONSTRAINT [DF_NotificationWorkFlowState_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]                   INT        NOT NULL,
    [Updated]                     DATETIME   CONSTRAINT [DF_NotificationWorkFlowState_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]                   INT        NOT NULL,
    [RowVersion]                  ROWVERSION NOT NULL,
    CONSTRAINT [PK_NotificationWorkFlowState] PRIMARY KEY CLUSTERED ([NotificationWorkFlowStateId] ASC),
    CONSTRAINT [FK_NotificationWorkFlowState_NotificationUserAccount] FOREIGN KEY ([NotificationUserAccountId]) REFERENCES [dbo].[NotificationUserAccount] ([NotificationUserAccountId]) ON DELETE CASCADE,
    CONSTRAINT [FK_NotificationWorkFlowState_WorkFlowState] FOREIGN KEY ([WorkFlowStateId]) REFERENCES [dbo].[WorkFlowState] ([WorkFlowStateId])
);

