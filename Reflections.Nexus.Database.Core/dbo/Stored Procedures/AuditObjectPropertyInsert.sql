

CREATE PROCEDURE [dbo].[AuditObjectPropertyInsert]
(
    @AuditObjectPropertyId  int OUTPUT, 
    @AuditObjectId  int, 
    @PropertyName  varchar(255), 
    @CreatedBy  int
)
AS
    SET NOCOUNT ON

    INSERT INTO AuditObjectProperty (AuditObjectId, PropertyName, Created, CreatedBy, Updated, UpdatedBy)
         VALUES (
                @AuditObjectId, 
                @PropertyName, 
                GetDate(), 
                @CreatedBy, 
                GetDate(), 
                @CreatedBy
                )
    SET @AuditObjectPropertyId = Scope_Identity()

    RETURN

