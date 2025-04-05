

CREATE PROCEDURE [dbo].[NotificationSelectById]
(
    @NotificationId int
)
AS
    SET NOCOUNT ON

    SELECT NotificationId, Description, FromEmailAddress, Subject, Body, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM Notification
     WHERE NotificationId = @NotificationId

    RETURN
