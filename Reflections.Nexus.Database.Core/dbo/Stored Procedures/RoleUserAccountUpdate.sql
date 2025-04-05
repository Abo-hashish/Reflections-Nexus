CREATE PROCEDURE [dbo].[RoleUserAccountUpdate]
(
	@RoleUserAccountId int,
	@RoleId int,
	@UserAccountId int,
	@UpdatedBy int,
	@RowVersion timestamp
)
AS
	SET NOCOUNT ON
	
	UPDATE RoleUserAccount
	   SET RoleId = @RoleId, 
		   UserAccountId = @UserAccountId, 		   
		   Updated = GetDate(), 
		   UpdatedBy = @UpdatedBy
     WHERE RoleUserAccountId = @RoleUserAccountId
       AND RowVersion = @RowVersion
	
	RETURN @@ROWCOUNT
