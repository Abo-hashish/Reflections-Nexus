

CREATE PROCEDURE [dbo].[NotificationWorkFlowStateSelectByWorkFlowStateId]
(
    @WorkFlowStateId int,
    @NotificationId int
)
AS
    SET NOCOUNT ON

    SELECT NotificationWorkFlowStateId, NotificationWorkFlowState.NotificationUserAccountId, WorkFlowStateId, NotificationWorkFlowState.Created, NotificationWorkFlowState.CreatedBy, NotificationWorkFlowState.Updated, NotificationWorkFlowState.UpdatedBy, NotificationWorkFlowState.RowVersion
      FROM NotificationWorkFlowState
INNER JOIN NotificationUserAccount
        ON NotificationWorkFlowState.NotificationUserAccountId = NotificationUserAccount.NotificationUserAccountId
INNER JOIN Notification
        ON NotificationUserAccount.NotificationId = Notification.NotificationId
     WHERE WorkFlowStateId = @WorkFlowStateId
       AND Notification.NotificationId = @NotificationId

    RETURN
