

CREATE PROCEDURE [dbo].[NotificationUserAccountSelectByWorkFlowStateId]
(
    @WorkFlowStateId int,
    @NotificationId int
)
AS
    SET NOCOUNT ON

    SELECT NotificationUserAccount.NotificationUserAccountId, NotificationId, UserAccountId, NotificationUserAccount.Created, NotificationUserAccount.CreatedBy, NotificationUserAccount.Updated, NotificationUserAccount.UpdatedBy, NotificationUserAccount.RowVersion
      FROM NotificationUserAccount
INNER JOIN NotificationWorkFlowState
        ON NotificationUserAccount.NotificationUserAccountId = NotificationWorkFlowState.NotificationUserAccountId
     WHERE WorkFlowStateId = @WorkFlowStateId
       AND NotificationId = @NotificationId

    RETURN
