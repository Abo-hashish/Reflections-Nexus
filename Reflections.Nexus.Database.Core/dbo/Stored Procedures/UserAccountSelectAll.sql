CREATE PROCEDURE [dbo].[UserAccountSelectAll]	
AS
	SET NOCOUNT ON
	
	SELECT UserAccountId, AccountName, FirstName, LastName, Email, IsActive, Created, CreatedBy, Updated, UpdatedBy, RowVersion
	  FROM UserAccount
  ORDER BY  FirstName, LastName
	
	RETURN
