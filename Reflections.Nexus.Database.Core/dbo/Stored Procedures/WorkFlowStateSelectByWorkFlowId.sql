

CREATE PROCEDURE [dbo].[WorkFlowStateSelectByWorkFlowId]
(
    @WorkFlowId int
)
AS
    SET NOCOUNT ON

    SELECT WorkFlowStateId, WorkFlowId, StateName, Description, WorkFlowOwnerGroupId, IsOwnerSubmitter, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM WorkFlowState
     WHERE WorkFlowId = @WorkFlowId

    RETURN
