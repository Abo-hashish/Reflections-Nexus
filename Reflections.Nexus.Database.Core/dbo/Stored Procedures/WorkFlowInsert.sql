CREATE PROCEDURE [dbo].[WorkFlowInsert]
(
    @WorkFlowId  int OUTPUT, 
    @WorkflowName  varchar(50), 
    @WorkFlowObjectName  varchar(255),     
    @CreatedBy  int
)
AS
    SET NOCOUNT ON

    INSERT INTO WorkFlow (WorkflowName, WorkFlowObjectName, Created, CreatedBy, Updated, UpdatedBy)
         VALUES (                
                @WorkflowName, 
                @WorkFlowObjectName, 				
                GetDate(), 
                @CreatedBy, 
                GetDate(), 
                @CreatedBy
                )
    SET @WorkFlowId = Scope_Identity()

    RETURN

