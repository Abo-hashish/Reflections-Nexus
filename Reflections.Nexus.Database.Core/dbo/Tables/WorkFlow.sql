CREATE TABLE [dbo].[WorkFlow] (
    [WorkFlowId]         INT           IDENTITY (1, 1) NOT NULL,
    [WorkflowName]       VARCHAR (50)  NOT NULL,
    [WorkFlowObjectName] VARCHAR (255) NOT NULL,
    [Created]            DATETIME      NOT NULL,
    [CreatedBy]          INT           NOT NULL,
    [Updated]            DATETIME      NOT NULL,
    [UpdatedBy]          INT           NOT NULL,
    [RowVersion]         ROWVERSION    NOT NULL,
    CONSTRAINT [PK_Workflow] PRIMARY KEY CLUSTERED ([WorkFlowId] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Workflow]
    ON [dbo].[WorkFlow]([WorkflowName] ASC);

