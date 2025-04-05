CREATE PROCEDURE [dbo].[RoleUserAccountInsert]
(
	@RoleUserAccountId int OUTPUT,
	@RoleId int,
	@UserAccountId int,
	@CreatedBy int
)
AS
	SET NOCOUNT ON
	
	INSERT INTO RoleUserAccount(RoleId, UserAccountId, Created, CreatedBy, Updated, UpdatedBy)
		 VALUES (@RoleId, 
				@UserAccountId, 
				GetDate(),
				@CreatedBy,
				GetDate(), 
				@CreatedBy)
	
	SET @RoleUserAccountId = Scope_Identity()
	RETURN
