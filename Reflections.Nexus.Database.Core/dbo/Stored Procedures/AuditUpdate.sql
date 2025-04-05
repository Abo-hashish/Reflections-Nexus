

CREATE PROCEDURE [dbo].[AuditUpdate]
(
    @AuditId  int, 
    @ObjectName  varchar(255), 
    @RecordId  int, 
    @PropertyName  varchar(255), 
    @OldValue  varchar(max), 
    @NewValue  varchar(max), 
    @AuditType  tinyint, 
    @UpdatedBy  int, 
    @RowVersion  timestamp
)
AS
    SET NOCOUNT ON

    UPDATE Audit
       SET 
           ObjectName = @ObjectName, 
           RecordId = @RecordId, 
           PropertyName = @PropertyName, 
           OldValue = @OldValue, 
           NewValue = @NewValue, 
           AuditType = @AuditType, 
           Updated = GetDate(), 
           UpdatedBy = @UpdatedBy
     WHERE AuditId = @AuditId
       AND RowVersion = @RowVersion

    RETURN @@ROWCOUNT

