CREATE PROCEDURE [dbo].[RoleSelectAll]	
AS
	SET NOCOUNT ON
	
	SELECT RoleId, RoleName, Created, CreatedBy, Updated, UpdatedBy, RowVersion
	  FROM Role
	
	RETURN
