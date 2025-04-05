CREATE TABLE [dbo].[WorkFlowOwnerGroupUserAccount] (
    [WorkFlowOwnerGroupUserAccountId] INT        IDENTITY (1, 1) NOT NULL,
    [WorkFlowOwnerGroupId]            INT        NOT NULL,
    [UserAccountId]                   INT        NOT NULL,
    [Created]                         DATETIME   NOT NULL,
    [CreatedBy]                       INT        NOT NULL,
    [Updated]                         DATETIME   NOT NULL,
    [UpdatedBy]                       INT        NOT NULL,
    [RowVersion]                      ROWVERSION NOT NULL,
    CONSTRAINT [PK_WorkFlowOwnerGroupUserAccount] PRIMARY KEY CLUSTERED ([WorkFlowOwnerGroupUserAccountId] ASC),
    CONSTRAINT [FK_WorkFlowOwnerGroupUserAccount_UserAccount] FOREIGN KEY ([UserAccountId]) REFERENCES [dbo].[UserAccount] ([UserAccountId]),
    CONSTRAINT [FK_WorkFlowOwnerGroupUserAccount_WorkFlowOwnerGroup] FOREIGN KEY ([WorkFlowOwnerGroupId]) REFERENCES [dbo].[WorkFlowOwnerGroup] ([WorkFlowOwnerGroupId]) ON DELETE CASCADE
);

