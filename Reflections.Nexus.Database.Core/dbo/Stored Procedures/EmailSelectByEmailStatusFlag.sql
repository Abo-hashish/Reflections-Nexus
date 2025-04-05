

CREATE PROCEDURE [dbo].[EmailSelectByEmailStatusFlag]
(
    @EmailStatusFlag tinyint
)
AS
    SET NOCOUNT ON

    SELECT EmailId, ToEmailAddress, CCEmailAddress, BCCEmailAddress, FromEmailAddress, Subject, Body, EmailStatusFlag, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM Email
     WHERE EmailStatusFlag = @EmailStatusFlag

    RETURN
