CREATE PROCEDURE [dbo].[WorkFlowStateSelectAll]
AS
    SET NOCOUNT ON

    SELECT WorkFlowStateId, WorkFlowId, StateName, Description, WorkFlowOwnerGroupId, IsOwnerSubmitter, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM WorkFlowState

    RETURN
