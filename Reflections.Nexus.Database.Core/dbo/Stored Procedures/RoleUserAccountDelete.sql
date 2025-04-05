CREATE PROCEDURE [dbo].[RoleUserAccountDelete]
(
	@RoleUserAccountId int
)
AS
	SET NOCOUNT ON
	
	DELETE 
	  FROM RoleUserAccount
	 WHERE RoleUserAccountId = @RoleUserAccountId
	 
	RETURN
