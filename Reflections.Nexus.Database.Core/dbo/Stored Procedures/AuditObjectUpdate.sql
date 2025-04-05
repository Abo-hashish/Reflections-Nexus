

CREATE PROCEDURE [dbo].[AuditObjectUpdate]
(
    @AuditObjectId  int, 
    @ObjectName  varchar(255),     
    @ObjectFullyQualifiedName varchar(255),
    @UpdatedBy  int, 
    @RowVersion  timestamp
)
AS
    SET NOCOUNT ON

    UPDATE AuditObject
       SET 
           ObjectName = @ObjectName,            
           ObjectFullyQualifiedName = @ObjectFullyQualifiedName,
           Updated = GetDate(), 
           UpdatedBy = @UpdatedBy
     WHERE AuditObjectId = @AuditObjectId
       AND RowVersion = @RowVersion

    RETURN @@ROWCOUNT

