

CREATE PROCEDURE [dbo].[EmailSelectById]
(
    @EmailId int
)
AS
    SET NOCOUNT ON

    SELECT EmailId, ToEmailAddress, CCEmailAddress, BCCEmailAddress, FromEmailAddress, Subject, Body, EmailStatusFlag, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM Email
     WHERE EmailId = @EmailId

    RETURN
