

CREATE PROCEDURE [dbo].[NotificationWorkFlowStateSelectByNotificationUserAccountId]
(
    @NotificationUserAccountId int
)
AS
    SET NOCOUNT ON

    SELECT NotificationWorkFlowStateId, NotificationUserAccountId, WorkFlowStateId, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM NotificationWorkFlowState
     WHERE NotificationUserAccountId = @NotificationUserAccountId

    RETURN
