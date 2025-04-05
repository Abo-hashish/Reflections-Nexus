

CREATE PROCEDURE [dbo].[NotificationUserAccountSelectByUserAccountId]
(
    @UserAccountId int
)
AS
    SET NOCOUNT ON

    SELECT NotificationUserAccountId, NotificationId, UserAccountId, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM NotificationUserAccount
     WHERE UserAccountId = @UserAccountId

    RETURN
