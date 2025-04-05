

CREATE PROCEDURE [dbo].[NotificationUserAccountSelectById]
(
    @NotificationUserAccountId int
)
AS
    SET NOCOUNT ON

    SELECT NotificationUserAccountId, NotificationId, UserAccountId, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM NotificationUserAccount
     WHERE NotificationUserAccountId = @NotificationUserAccountId

    RETURN
