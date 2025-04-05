CREATE PROCEDURE [dbo].[ReportRoleCapability]	
AS
	SET NOCOUNT ON
	
	SELECT Role.RoleName, RoleCapability.AccessFlag, Capability.CapabilityName
	  FROM Capability 
INNER JOIN RoleCapability 
		ON Capability.CapabilityId = RoleCapability.CapabilityId 
INNER JOIN Role 
		ON RoleCapability.RoleId = Role.RoleId
                      
	RETURN
