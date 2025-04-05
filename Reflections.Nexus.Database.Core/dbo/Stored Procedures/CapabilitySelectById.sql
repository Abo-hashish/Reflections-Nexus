CREATE PROCEDURE [dbo].[CapabilitySelectById]
(
    @CapabilityId int
)
AS
	SET NOCOUNT ON
	
	SELECT CapabilityId, CapabilityName, MenuItemId, AccessType, Created, CreatedBy, Updated, UpdatedBy, RowVersion
	FROM Capability
	WHERE CapabilityId = @CapabilityId
	
	RETURN
