CREATE PROCEDURE [dbo].[RoleUserAccountSelectByRoleId]
(
	@RoleId int
)
AS
	SET NOCOUNT ON
	
	SELECT RoleUserAccountId, RoleId, UserAccountId, Created, CreatedBy, Updated, 
	       UpdatedBy, RowVersion
	  FROM RoleUserAccount
	 WHERE RoleId = @RoleId
	
	RETURN
