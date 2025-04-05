

CREATE PROCEDURE [dbo].[NotificationWorkFlowStateDeleteByNotificationUserAccountId]
(
    @NotificationUserAccountId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM NotificationWorkFlowState
     WHERE NotificationUserAccountId = @NotificationUserAccountId

    RETURN

