

CREATE PROCEDURE [dbo].[AuditObjectPropertyUpdate]
(
    @AuditObjectPropertyId  int, 
    @AuditObjectId  int, 
    @PropertyName  varchar(255), 
    @UpdatedBy  int, 
    @RowVersion  timestamp
)
AS
    SET NOCOUNT ON

    UPDATE AuditObjectProperty
       SET 
           AuditObjectId = @AuditObjectId, 
           PropertyName = @PropertyName, 
           Updated = GetDate(), 
           UpdatedBy = @UpdatedBy
     WHERE AuditObjectPropertyId = @AuditObjectPropertyId
       AND RowVersion = @RowVersion

    RETURN @@ROWCOUNT

