CREATE PROCEDURE [dbo].[UserAccountSelectById]
(
    @UserAccountId int
)
AS
	SET NOCOUNT ON
	
	SELECT UserAccountId, AccountName, FirstName, LastName, Email, IsActive, Created, CreatedBy, Updated, UpdatedBy, RowVersion
	  FROM UserAccount
	 WHERE UserAccountId = @UserAccountId
	
	RETURN
