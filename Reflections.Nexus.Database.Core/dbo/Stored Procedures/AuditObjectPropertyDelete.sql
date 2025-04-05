

CREATE PROCEDURE [dbo].[AuditObjectPropertyDelete]
(
    @AuditObjectPropertyId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM AuditObjectProperty
     WHERE AuditObjectPropertyId = @AuditObjectPropertyId

    RETURN

