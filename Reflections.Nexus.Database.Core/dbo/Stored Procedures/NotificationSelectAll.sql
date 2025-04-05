CREATE PROCEDURE [dbo].[NotificationSelectAll]
AS
    SET NOCOUNT ON

    SELECT NotificationId, Description, FromEmailAddress, Subject, Body, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM Notification

    RETURN
