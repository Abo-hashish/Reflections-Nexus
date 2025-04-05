

CREATE PROCEDURE [dbo].[AuditInsert]
(
    @AuditId  int OUTPUT, 
    @ObjectName  varchar(255), 
    @RecordId  int, 
    @PropertyName  varchar(255), 
    @OldValue  varchar(max), 
    @NewValue  varchar(max), 
    @AuditType  tinyint, 
    @CreatedBy  int
)
AS
    SET NOCOUNT ON

    INSERT INTO Audit (ObjectName, RecordId, PropertyName, OldValue, NewValue, AuditType, Created, CreatedBy, Updated, UpdatedBy)
         VALUES (
                @ObjectName, 
                @RecordId, 
                @PropertyName, 
                @OldValue, 
                @NewValue, 
                @AuditType, 
                GetDate(), 
                @CreatedBy, 
                GetDate(), 
                @CreatedBy
                )
    SET @AuditId = Scope_Identity()

    RETURN

