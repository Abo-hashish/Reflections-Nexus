

CREATE PROCEDURE [dbo].[WorkFlowStateSelectById]
(
    @WorkFlowStateId int
)
AS
    SET NOCOUNT ON

    SELECT WorkFlowStateId, WorkFlowId, StateName, Description, WorkFlowOwnerGroupId, IsOwnerSubmitter, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM WorkFlowState
     WHERE WorkFlowStateId = @WorkFlowStateId

    RETURN
