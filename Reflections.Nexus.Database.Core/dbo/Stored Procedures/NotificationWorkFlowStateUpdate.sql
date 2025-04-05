

CREATE PROCEDURE [dbo].[NotificationWorkFlowStateUpdate]
(
    @NotificationWorkFlowStateId  int, 
    @NotificationUserAccountId  int, 
    @WorkFlowStateId  int, 
    @UpdatedBy  int, 
    @RowVersion  timestamp
)
AS
    SET NOCOUNT ON

    UPDATE NotificationWorkFlowState
       SET 
           NotificationUserAccountId = @NotificationUserAccountId, 
           WorkFlowStateId = @WorkFlowStateId, 
           Updated = GetDate(), 
           UpdatedBy = @UpdatedBy
     WHERE NotificationWorkFlowStateId = @NotificationWorkFlowStateId
       AND RowVersion = @RowVersion

    RETURN @@ROWCOUNT

