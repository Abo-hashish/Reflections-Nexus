

CREATE PROCEDURE [dbo].[NotificationUserAccountDelete]
(
    @NotificationUserAccountId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM NotificationUserAccount
     WHERE NotificationUserAccountId = @NotificationUserAccountId

    RETURN

