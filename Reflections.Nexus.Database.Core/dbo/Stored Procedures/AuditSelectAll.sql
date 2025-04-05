CREATE PROCEDURE [dbo].[AuditSelectAll]
AS
    SET NOCOUNT ON

    SELECT AuditId, ObjectName, RecordId, PropertyName, OldValue, NewValue, AuditType, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM Audit

    RETURN
