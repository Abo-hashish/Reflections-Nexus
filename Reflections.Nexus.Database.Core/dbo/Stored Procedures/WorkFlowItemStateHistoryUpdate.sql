

CREATE PROCEDURE [dbo].[WorkFlowItemStateHistoryUpdate]
(
    @WorkFlowItemStateHistoryId  int, 
    @WorkFlowItemId  int, 
    @WorkFlowStateId  int, 
    @UserAccountId  int, 
    @UpdatedBy  int, 
    @RowVersion  timestamp
)
AS
    SET NOCOUNT ON

    UPDATE WorkFlowItemStateHistory
       SET 
           WorkFlowItemId = @WorkFlowItemId, 
           WorkFlowStateId = @WorkFlowStateId, 
           UserAccountId = @UserAccountId, 
           Updated = GetDate(), 
           UpdatedBy = @UpdatedBy
     WHERE WorkFlowItemStateHistoryId = @WorkFlowItemStateHistoryId
       AND RowVersion = @RowVersion

    RETURN @@ROWCOUNT

