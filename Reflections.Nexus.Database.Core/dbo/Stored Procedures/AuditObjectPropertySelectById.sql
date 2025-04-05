

CREATE PROCEDURE [dbo].[AuditObjectPropertySelectById]
(
    @AuditObjectPropertyId int
)
AS
    SET NOCOUNT ON

    SELECT AuditObjectPropertyId, AuditObjectId, PropertyName, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM AuditObjectProperty
     WHERE AuditObjectPropertyId = @AuditObjectPropertyId

    RETURN
