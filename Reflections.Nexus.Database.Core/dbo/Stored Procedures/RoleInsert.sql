CREATE PROCEDURE [dbo].[RoleInsert]
(
	@RoleId int OUTPUT,	
	@RoleName varchar(50),
	@CreatedBy int	
)
AS
	SET NOCOUNT ON
	
	INSERT INTO Role (RoleName, Created, CreatedBy, Updated, UpdatedBy)
	     VALUES (@RoleName,
	             GetDate(),
	             @CreatedBy,
	             GetDate(),
	             @CreatedBy)

	SET @RoleId = Scope_Identity()                
	
	RETURN
