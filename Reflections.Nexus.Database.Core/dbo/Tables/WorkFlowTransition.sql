CREATE TABLE [dbo].[WorkFlowTransition] (
    [WorkFlowTransitionId]     INT           IDENTITY (1, 1) NOT NULL,
    [WorkFlowId]               INT           NOT NULL,
    [TransitionName]           VARCHAR (50)  NOT NULL,
    [FromWorkFlowStateId]      INT           NULL,
    [ToWorkFlowStateId]        INT           NOT NULL,
    [PostTransitionMethodName] VARCHAR (255) NULL,
    [Created]                  DATETIME      NOT NULL,
    [CreatedBy]                INT           NOT NULL,
    [Updated]                  DATETIME      NOT NULL,
    [UpdatedBy]                INT           NOT NULL,
    [RowVersion]               ROWVERSION    NOT NULL,
    CONSTRAINT [PK_WorkFlowTransition] PRIMARY KEY CLUSTERED ([WorkFlowTransitionId] ASC),
    CONSTRAINT [FK_WorkFlowTransition_Workflow] FOREIGN KEY ([WorkFlowId]) REFERENCES [dbo].[WorkFlow] ([WorkFlowId]),
    CONSTRAINT [FK_WorkFlowTransition_WorkFlowState] FOREIGN KEY ([FromWorkFlowStateId]) REFERENCES [dbo].[WorkFlowState] ([WorkFlowStateId]),
    CONSTRAINT [FK_WorkFlowTransition_WorkFlowState1] FOREIGN KEY ([ToWorkFlowStateId]) REFERENCES [dbo].[WorkFlowState] ([WorkFlowStateId])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_WorkFlowTransition_1]
    ON [dbo].[WorkFlowTransition]([FromWorkFlowStateId] ASC, [ToWorkFlowStateId] ASC);

