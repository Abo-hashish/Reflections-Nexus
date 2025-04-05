


CREATE PROCEDURE [dbo].[AuditObjectInsert]
(
    @AuditObjectId  int OUTPUT, 
    @ObjectName  varchar(255),     
    @ObjectFullyQualifiedName varchar(255),
    @CreatedBy  int
)
AS
    SET NOCOUNT ON

    INSERT INTO AuditObject (ObjectName, ObjectFullyQualifiedName, Created, CreatedBy, Updated, UpdatedBy)
         VALUES (
                @ObjectName,               
                @ObjectFullyQualifiedName,  
                GetDate(), 
                @CreatedBy, 
                GetDate(), 
                @CreatedBy
                )
    SET @AuditObjectId = Scope_Identity()

    RETURN

