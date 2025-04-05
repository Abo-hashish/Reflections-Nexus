CREATE PROCEDURE [dbo].[RoleUserAccountSelectAll]
AS
    SET NOCOUNT ON

    SELECT RoleUserAccountId, RoleId, UserAccountId, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM RoleUserAccount

    RETURN
