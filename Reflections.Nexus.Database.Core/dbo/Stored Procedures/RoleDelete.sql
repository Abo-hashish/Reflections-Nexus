CREATE PROCEDURE [dbo].[RoleDelete]
(
	@RoleId int
)
AS
	SET NOCOUNT ON
	
	DELETE
	  FROM Role
	 WHERE RoleId = @RoleId
	
	RETURN
