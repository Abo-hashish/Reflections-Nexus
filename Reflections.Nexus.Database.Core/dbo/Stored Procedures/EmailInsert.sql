

CREATE PROCEDURE [dbo].[EmailInsert]
(
    @EmailId  int OUTPUT, 
    @ToEmailAddress  varchar(max), 
    @CCEmailAddress  varchar(max), 
    @BCCEmailAddress  varchar(max), 
    @FromEmailAddress  varchar(255), 
    @Subject  varchar(max), 
    @Body  varchar(max), 
    @EmailStatusFlag  tinyint, 
    @CreatedBy  int
)
AS
    SET NOCOUNT ON

    INSERT INTO Email (ToEmailAddress, CCEmailAddress, BCCEmailAddress, FromEmailAddress, Subject, Body, EmailStatusFlag, Created, CreatedBy, Updated, UpdatedBy)
         VALUES (
                @ToEmailAddress, 
                @CCEmailAddress, 
                @BCCEmailAddress, 
                @FromEmailAddress, 
                @Subject, 
                @Body, 
                @EmailStatusFlag, 
                GetDate(), 
                @CreatedBy, 
                GetDate(), 
                @CreatedBy
                )
    SET @EmailId = Scope_Identity()

    RETURN

