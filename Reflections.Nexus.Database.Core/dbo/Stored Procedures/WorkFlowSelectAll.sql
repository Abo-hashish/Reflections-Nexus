CREATE PROCEDURE [dbo].[WorkFlowSelectAll]
AS
    SET NOCOUNT ON

    SELECT WorkFlowId, WorkflowName, WorkFlowObjectName, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM WorkFlow

    RETURN
