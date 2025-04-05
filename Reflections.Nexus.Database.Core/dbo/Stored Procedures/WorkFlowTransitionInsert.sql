
CREATE PROCEDURE [dbo].[WorkFlowTransitionInsert]
(
    @WorkFlowTransitionId  int OUTPUT, 
    @WorkFlowId  int, 
    @TransitionName  varchar(50), 
    @FromWorkFlowStateId  int, 
    @ToWorkFlowStateId  int,     
    @PostTransitionMethodName  varchar(255), 
    @CreatedBy  int
)
AS
    SET NOCOUNT ON

    INSERT INTO WorkFlowTransition (WorkFlowId, TransitionName, FromWorkFlowStateId, ToWorkFlowStateId, PostTransitionMethodName, Created, CreatedBy, Updated, UpdatedBy)
         VALUES (
                @WorkFlowId, 
                @TransitionName, 
                @FromWorkFlowStateId, 
                @ToWorkFlowStateId, 
                @PostTransitionMethodName, 
                GetDate(), 
                @CreatedBy, 
                GetDate(), 
                @CreatedBy
                )
    SET @WorkFlowTransitionId = Scope_Identity()

    RETURN

