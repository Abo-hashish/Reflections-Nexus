CREATE PROCEDURE [dbo].[AuditObjectPropertySelectAll]
AS
    SET NOCOUNT ON

    SELECT AuditObjectPropertyId, AuditObjectId, PropertyName, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM AuditObjectProperty

    RETURN
