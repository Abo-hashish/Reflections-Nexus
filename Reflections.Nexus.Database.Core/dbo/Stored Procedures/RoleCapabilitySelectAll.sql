CREATE PROCEDURE [dbo].[RoleCapabilitySelectAll]
AS
    SET NOCOUNT ON

    SELECT RoleCapabilityId, RoleId, CapabilityId, AccessFlag, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM RoleCapability

    RETURN
