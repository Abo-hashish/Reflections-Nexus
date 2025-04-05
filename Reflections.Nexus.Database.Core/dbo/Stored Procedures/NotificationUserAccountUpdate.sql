

CREATE PROCEDURE [dbo].[NotificationUserAccountUpdate]
(
    @NotificationUserAccountId  int, 
    @NotificationId  int, 
    @UserAccountId  int, 
    @UpdatedBy  int, 
    @RowVersion  timestamp
)
AS
    SET NOCOUNT ON

    UPDATE NotificationUserAccount
       SET 
           NotificationId = @NotificationId, 
           UserAccountId = @UserAccountId, 
           Updated = GetDate(), 
           UpdatedBy = @UpdatedBy
     WHERE NotificationUserAccountId = @NotificationUserAccountId
       AND RowVersion = @RowVersion

    RETURN @@ROWCOUNT

