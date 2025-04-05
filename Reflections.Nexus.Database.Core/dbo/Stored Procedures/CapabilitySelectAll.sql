CREATE PROCEDURE [dbo].[CapabilitySelectAll]
AS
	SET NOCOUNT ON
	
	SELECT CapabilityId, CapabilityName, MenuItemId, AccessType, Created, CreatedBy, Updated, UpdatedBy, RowVersion
	FROM Capability
	
	RETURN
