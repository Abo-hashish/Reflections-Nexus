

CREATE PROCEDURE [dbo].[AuditObjectPropertySelectByAuditObjectId]
(
    @AuditObjectId int
)
AS
    SET NOCOUNT ON

    SELECT AuditObjectPropertyId, AuditObjectId, PropertyName, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM AuditObjectProperty
     WHERE AuditObjectId = @AuditObjectId

    RETURN
