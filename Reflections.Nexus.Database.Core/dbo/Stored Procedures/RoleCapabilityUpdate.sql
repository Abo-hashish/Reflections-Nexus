CREATE PROCEDURE [dbo].[RoleCapabilityUpdate]
(
	@RoleCapabilityId int,
	@RoleId int,
	@CapabilityId int,
	@AccessFlag tinyint,
	@UpdatedBy int,
	@RowVersion timestamp
)
AS
	SET NOCOUNT ON
	UPDATE RoleCapability 
	   SET RoleId = @RoleId, 
	       CapabilityId = @CapabilityId, 
	       AccessFlag = @AccessFlag, 
	       Updated = GetDate(), 
	       UpdatedBy = @UpdatedBy
	 WHERE RoleCapabilityId = @RoleCapabilityId
	   AND RowVersion = @RowVersion

	RETURN @@ROWCOUNT
