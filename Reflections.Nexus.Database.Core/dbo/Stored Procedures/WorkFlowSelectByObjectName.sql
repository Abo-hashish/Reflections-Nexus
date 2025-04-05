

CREATE PROCEDURE [dbo].[WorkFlowSelectByObjectName]
(
    @WorkFlowObjectName varchar(255)
)
AS
    SET NOCOUNT ON

    SELECT WorkFlowId, WorkflowName, WorkFlowObjectName, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM WorkFlow
     WHERE WorkFlowObjectName = @WorkFlowObjectName

    RETURN
