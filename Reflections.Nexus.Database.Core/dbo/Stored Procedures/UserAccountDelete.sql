CREATE PROCEDURE [dbo].[UserAccountDelete]
(
	@UserAccountId int
)
AS
	SET NOCOUNT ON
	
	DELETE
	  FROM UserAccount
	 WHERE UserAccountId = @UserAccountId
	
	RETURN
