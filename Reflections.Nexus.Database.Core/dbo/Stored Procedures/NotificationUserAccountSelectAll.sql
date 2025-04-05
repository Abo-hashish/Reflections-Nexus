CREATE PROCEDURE [dbo].[NotificationUserAccountSelectAll]
AS
    SET NOCOUNT ON

    SELECT NotificationUserAccountId, NotificationId, UserAccountId, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM NotificationUserAccount

    RETURN
