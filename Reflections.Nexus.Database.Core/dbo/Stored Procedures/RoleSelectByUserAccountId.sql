CREATE PROCEDURE [dbo].[RoleSelectByUserAccountId]
(
	@UserAccountId int
)
AS
	SET NOCOUNT ON
	
	SELECT Role.RoleId, RoleName, Role.Created, Role.CreatedBy, Role.Updated, Role.UpdatedBy, Role.RowVersion
	  FROM Role
INNER JOIN RoleUserAccount
 	    ON Role.RoleId = RoleUserAccount.RoleId
	 WHERE UserAccountId = @UserAccountId
	
	RETURN
