

CREATE PROCEDURE [dbo].[NotificationUserAccountInsert]
(
    @NotificationUserAccountId  int OUTPUT, 
    @NotificationId  int, 
    @UserAccountId  int, 
    @CreatedBy  int
)
AS
    SET NOCOUNT ON

    INSERT INTO NotificationUserAccount (NotificationId, UserAccountId, Created, CreatedBy, Updated, UpdatedBy)
         VALUES (
                @NotificationId, 
                @UserAccountId, 
                GetDate(), 
                @CreatedBy, 
                GetDate(), 
                @CreatedBy
                )
    SET @NotificationUserAccountId = Scope_Identity()

    RETURN

