CREATE PROCEDURE [dbo].[ReportRoleUserAccount]
	
AS
	SET NOCOUNT ON
	
	      SELECT RoleName, FirstName, LastName
            FROM UserAccount 
RIGHT OUTER JOIN RoleUserAccount 
              ON UserAccount.UserAccountId = dbo.RoleUserAccount.UserAccountId 
RIGHT OUTER JOIN Role 
              ON RoleUserAccount.RoleId = Role.RoleId
	RETURN
