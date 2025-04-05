

CREATE PROCEDURE [dbo].[NotificationDelete]
(
    @NotificationId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM Notification
     WHERE NotificationId = @NotificationId

    RETURN

