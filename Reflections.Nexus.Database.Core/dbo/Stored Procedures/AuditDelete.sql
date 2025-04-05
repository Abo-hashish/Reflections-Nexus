

CREATE PROCEDURE [dbo].[AuditDelete]
(
    @AuditId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM Audit
     WHERE AuditId = @AuditId

    RETURN

