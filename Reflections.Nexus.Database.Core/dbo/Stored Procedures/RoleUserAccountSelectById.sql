CREATE PROCEDURE [dbo].[RoleUserAccountSelectById]
(
    @RoleUserAccountId int
)
AS
    SET NOCOUNT ON

    SELECT RoleUserAccountId, RoleId, UserAccountId, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM RoleUserAccount
     WHERE RoleUserAccountId = @RoleUserAccountId

    RETURN
