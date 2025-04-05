

CREATE PROCEDURE [dbo].[EmailUpdate]
(
    @EmailId  int, 
    @ToEmailAddress  varchar(max), 
    @CCEmailAddress  varchar(max), 
    @BCCEmailAddress  varchar(max), 
    @FromEmailAddress  varchar(255), 
    @Subject  varchar(max), 
    @Body  varchar(max), 
    @EmailStatusFlag  tinyint, 
    @UpdatedBy  int, 
    @RowVersion  timestamp
)
AS
    SET NOCOUNT ON

    UPDATE Email
       SET 
           ToEmailAddress = @ToEmailAddress, 
           CCEmailAddress = @CCEmailAddress, 
           BCCEmailAddress = @BCCEmailAddress, 
           FromEmailAddress = @FromEmailAddress, 
           Subject = @Subject, 
           Body = @Body, 
           EmailStatusFlag = @EmailStatusFlag, 
           Updated = GetDate(), 
           UpdatedBy = @UpdatedBy
     WHERE EmailId = @EmailId
       AND RowVersion = @RowVersion

    RETURN @@ROWCOUNT

