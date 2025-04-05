

CREATE PROCEDURE [dbo].[AuditObjectPropertyDeleteByAuditObjectId]
(
    @AuditObjectId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM AuditObjectProperty
     WHERE AuditObjectId = @AuditObjectId

    RETURN

