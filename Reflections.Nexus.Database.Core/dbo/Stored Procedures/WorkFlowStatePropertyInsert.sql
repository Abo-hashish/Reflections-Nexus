

CREATE PROCEDURE [dbo].[WorkFlowStatePropertyInsert]
(
    @WorkFlowStatePropertyId  int OUTPUT, 
    @WorkFlowStateId  int, 
    @PropertyName  varchar(255), 
    @Required  bit, 
    @ReadOnly  bit, 
    @CreatedBy  int
)
AS
    SET NOCOUNT ON

    INSERT INTO WorkFlowStateProperty (WorkFlowStateId, PropertyName, Required, ReadOnly, Created, CreatedBy, Updated, UpdatedBy)
         VALUES (
                @WorkFlowStateId, 
                @PropertyName, 
                @Required, 
                @ReadOnly, 
                GetDate(), 
                @CreatedBy, 
                GetDate(), 
                @CreatedBy
                )
    SET @WorkFlowStatePropertyId = Scope_Identity()

    RETURN

