CREATE PROCEDURE [dbo].[RoleCapabilityInsert]
(
	@RoleCapabilityId int OUTPUT,
	@RoleId int,
	@CapabilityId int,
	@AccessFlag tinyint,
	@CreatedBy int
)

AS
	SET NOCOUNT ON
	INSERT INTO RoleCapability (RoleId, CapabilityId, AccessFlag, Created, CreatedBy,
		Updated, UpdatedBy)
		 VALUES (@RoleId, 
				@CapabilityId, 
				@AccessFlag, 
				GetDate(),
				@CreatedBy,
				GetDate(),
				@CreatedBy)
	
	SET @RoleCapabilityId = Scope_Identity()

	RETURN
