

CREATE PROCEDURE [dbo].[AuditSelectById]
(
    @AuditId int
)
AS
    SET NOCOUNT ON

    SELECT AuditId, ObjectName, RecordId, PropertyName, OldValue, NewValue, AuditType, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM Audit
     WHERE AuditId = @AuditId

    RETURN
