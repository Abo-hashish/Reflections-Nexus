

CREATE PROCEDURE [dbo].[WorkFlowSelectById]
(
    @WorkFlowId int
)
AS
    SET NOCOUNT ON

    SELECT WorkFlowId, WorkflowName, WorkFlowObjectName, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM WorkFlow
     WHERE WorkFlowId = @WorkFlowId

    RETURN
