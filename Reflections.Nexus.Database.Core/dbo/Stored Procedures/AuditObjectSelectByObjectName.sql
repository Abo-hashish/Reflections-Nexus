

CREATE PROCEDURE [dbo].[AuditObjectSelectByObjectName]
(
    @ObjectName varchar(255)
)
AS
    SET NOCOUNT ON

    SELECT AuditObjectId, ObjectName, ObjectFullyQualifiedName, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM AuditObject
     WHERE ObjectName = @ObjectName

    RETURN
