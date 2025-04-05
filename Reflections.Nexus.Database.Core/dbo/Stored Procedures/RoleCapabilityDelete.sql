CREATE PROCEDURE [dbo].[RoleCapabilityDelete]
(
	@RoleCapabilityId int
)
AS
	SET NOCOUNT ON
	
	DELETE
	  FROM RoleCapability
	 WHERE RoleCapabilityId = @RoleCapabilityId
	
	RETURN
