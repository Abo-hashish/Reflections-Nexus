

CREATE PROCEDURE [dbo].[NotificationSelectByIdUserAccountId]
(
    @NotificationId int,
    @UserAccountid int
)
AS
    SET NOCOUNT ON

    SELECT Notification.NotificationId, Description, FromEmailAddress, Subject, Body, Notification.Created, Notification.CreatedBy, Notification.Updated, Notification.UpdatedBy, Notification.RowVersion
      FROM Notification
INNER JOIN NotificationUserAccount 
        ON Notification.NotificationId = NotificationUserAccount.NotificationId
     WHERE Notification.NotificationId = @NotificationId
       AND UserAccountId = @UserAccountId

    RETURN
