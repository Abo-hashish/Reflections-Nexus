CREATE TABLE [dbo].[WorkFlowStateProperty] (
    [WorkFlowStatePropertyId] INT           IDENTITY (1, 1) NOT NULL,
    [WorkFlowStateId]         INT           NOT NULL,
    [PropertyName]            VARCHAR (255) NOT NULL,
    [Required]                BIT           NOT NULL,
    [ReadOnly]                BIT           NOT NULL,
    [Created]                 DATETIME      NOT NULL,
    [CreatedBy]               INT           NOT NULL,
    [Updated]                 DATETIME      NOT NULL,
    [UpdatedBy]               INT           NOT NULL,
    [RowVersion]              ROWVERSION    NOT NULL,
    CONSTRAINT [PK_WorkFlowStateField] PRIMARY KEY CLUSTERED ([WorkFlowStatePropertyId] ASC),
    CONSTRAINT [FK_WorkFlowStateField_WorkFlowState] FOREIGN KEY ([WorkFlowStateId]) REFERENCES [dbo].[WorkFlowState] ([WorkFlowStateId]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_WorkFlowStateField]
    ON [dbo].[WorkFlowStateProperty]([WorkFlowStateId] ASC, [PropertyName] ASC);

