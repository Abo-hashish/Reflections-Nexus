

CREATE PROCEDURE [dbo].[AuditObjectDelete]
(
    @AuditObjectId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM AuditObject
     WHERE AuditObjectId = @AuditObjectId

    RETURN

