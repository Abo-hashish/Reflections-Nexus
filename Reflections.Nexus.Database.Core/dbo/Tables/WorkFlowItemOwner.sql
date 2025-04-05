CREATE TABLE [dbo].[WorkFlowItemOwner] (
    [WorkFlowItemOwnerId]  INT        IDENTITY (1, 1) NOT NULL,
    [WorkFlowItemId]       INT        NOT NULL,
    [WorkFlowOwnerGroupId] INT        NOT NULL,
    [UserAccountId]        INT        NULL,
    [Created]              DATETIME   CONSTRAINT [DF_WorkFlowItemOwner_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]            INT        NOT NULL,
    [Updated]              DATETIME   CONSTRAINT [DF_WorkFlowItemOwner_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]            INT        NOT NULL,
    [RowVersion]           ROWVERSION NOT NULL,
    CONSTRAINT [PK_WorkFlowItemOwner] PRIMARY KEY CLUSTERED ([WorkFlowItemOwnerId] ASC),
    CONSTRAINT [FK_WorkFlowItemOwner_UserAccount] FOREIGN KEY ([UserAccountId]) REFERENCES [dbo].[UserAccount] ([UserAccountId]),
    CONSTRAINT [FK_WorkFlowItemOwner_WorkFlowItem] FOREIGN KEY ([WorkFlowItemId]) REFERENCES [dbo].[WorkFlowItem] ([WorkFlowItemId]),
    CONSTRAINT [FK_WorkFlowItemOwner_WorkFlowOwnerGroup] FOREIGN KEY ([WorkFlowOwnerGroupId]) REFERENCES [dbo].[WorkFlowOwnerGroup] ([WorkFlowOwnerGroupId])
);

