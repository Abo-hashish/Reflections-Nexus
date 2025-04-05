CREATE PROCEDURE [dbo].[RoleCapabilitySelectById]
(
    @RoleCapabilityId int
)
AS
    SET NOCOUNT ON

    SELECT RoleCapabilityId, RoleId, CapabilityId, AccessFlag, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM RoleCapability
     WHERE RoleCapabilityId = @RoleCapabilityId

    RETURN
