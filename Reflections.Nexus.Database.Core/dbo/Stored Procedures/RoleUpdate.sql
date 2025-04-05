CREATE PROCEDURE [dbo].[RoleUpdate]
(
	@RoleId int,
	@RoleName varchar(50),	
	@UpdatedBy int,
	@RowVersion timestamp
)
AS
	SET NOCOUNT ON
	
	UPDATE Role
	   SET RoleName = @RoleName,
	       Updated = GetDate(),
	       UpdatedBy = @UpdatedBy
	 WHERE RoleId = @RoleId
	   AND RowVersion = @RowVersion
		
	RETURN @@ROWCOUNT
