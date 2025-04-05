

CREATE PROCEDURE [dbo].[NotificationInsert]
(
    @NotificationId  int OUTPUT, 
    @Description  varchar(255), 
    @FromEmailAddress  varchar(100), 
    @Subject  varchar(MAX), 
    @Body  varchar(MAX), 
    @CreatedBy  int
)
AS
    SET NOCOUNT ON

    INSERT INTO Notification (Description, FromEmailAddress, Subject, Body, Created, CreatedBy, Updated, UpdatedBy)
         VALUES (
                @Description, 
                @FromEmailAddress, 
                @Subject, 
                @Body, 
                GetDate(), 
                @CreatedBy, 
                GetDate(), 
                @CreatedBy
                )
    SET @NotificationId = Scope_Identity()

    RETURN

