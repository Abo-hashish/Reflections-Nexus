CREATE PROCEDURE [dbo].[AuditObjectSelectAll]
AS
    SET NOCOUNT ON

    SELECT AuditObjectId, ObjectName, ObjectFullyQualifiedName, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM AuditObject

    RETURN
