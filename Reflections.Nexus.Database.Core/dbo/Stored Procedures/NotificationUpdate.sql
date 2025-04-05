

CREATE PROCEDURE [dbo].[NotificationUpdate]
(
    @NotificationId  int, 
    @Description  varchar(255), 
    @FromEmailAddress  varchar(100), 
    @Subject  varchar(MAX), 
    @Body  varchar(MAX), 
    @UpdatedBy  int, 
    @RowVersion  timestamp
)
AS
    SET NOCOUNT ON

    UPDATE Notification
       SET 
           Description = @Description, 
           FromEmailAddress = @FromEmailAddress, 
           Subject = @Subject, 
           Body = @Body, 
           Updated = GetDate(), 
           UpdatedBy = @UpdatedBy
     WHERE NotificationId = @NotificationId
       AND RowVersion = @RowVersion

    RETURN @@ROWCOUNT

