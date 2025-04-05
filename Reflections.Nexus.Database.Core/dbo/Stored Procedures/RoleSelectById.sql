CREATE PROCEDURE [dbo].[RoleSelectById]	
(
	@RoleId int
)
AS
	SET NOCOUNT ON
	
	SELECT RoleId, RoleName, Created, CreatedBy, Updated, UpdatedBy, RowVersion
	  FROM Role
	WHERE RoleId = @RoleId
	
	RETURN
