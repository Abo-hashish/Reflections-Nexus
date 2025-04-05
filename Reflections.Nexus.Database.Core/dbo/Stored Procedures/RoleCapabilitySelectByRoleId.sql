CREATE PROCEDURE [dbo].[RoleCapabilitySelectByRoleId]
(
	@RoleId int
)
AS
	SET NOCOUNT ON
	
	SELECT RoleCapabilityId, RoleId, CapabilityId, AccessFlag, Created, CreatedBy,
	       Updated, UpdatedBy, RowVersion
	  FROM RoleCapability
	 WHERE RoleId = @RoleId
	
	RETURN
