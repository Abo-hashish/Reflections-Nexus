

CREATE PROCEDURE [dbo].[AuditObjectSelectById]
(
    @AuditObjectId int
)
AS
    SET NOCOUNT ON

    SELECT AuditObjectId, ObjectName, ObjectFullyQualifiedName, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM AuditObject
     WHERE AuditObjectId = @AuditObjectId

    RETURN
