CREATE TABLE [dbo].[WorkFlowState] (
    [WorkFlowStateId]      INT           IDENTITY (1, 1) NOT NULL,
    [WorkFlowId]           INT           NOT NULL,
    [StateName]            VARCHAR (50)  NOT NULL,
    [Description]          VARCHAR (255) NULL,
    [WorkFlowOwnerGroupId] INT           NULL,
    [IsOwnerSubmitter]     BIT           NOT NULL,
    [Created]              DATETIME      NOT NULL,
    [CreatedBy]            INT           NOT NULL,
    [Updated]              DATETIME      NOT NULL,
    [UpdatedBy]            INT           NOT NULL,
    [RowVersion]           ROWVERSION    NOT NULL,
    CONSTRAINT [PK_WorkFlowState] PRIMARY KEY CLUSTERED ([WorkFlowStateId] ASC),
    CONSTRAINT [FK_WorkFlowState_Workflow] FOREIGN KEY ([WorkFlowId]) REFERENCES [dbo].[WorkFlow] ([WorkFlowId]),
    CONSTRAINT [FK_WorkFlowState_WorkFlowOwnerGroup] FOREIGN KEY ([WorkFlowOwnerGroupId]) REFERENCES [dbo].[WorkFlowOwnerGroup] ([WorkFlowOwnerGroupId])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_WorkFlowState]
    ON [dbo].[WorkFlowState]([WorkFlowId] ASC, [StateName] ASC);

