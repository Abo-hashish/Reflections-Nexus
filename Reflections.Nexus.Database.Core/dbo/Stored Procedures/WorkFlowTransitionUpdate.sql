

CREATE PROCEDURE [dbo].[WorkFlowTransitionUpdate]
(
    @WorkFlowTransitionId  int, 
    @WorkFlowId  int, 
    @TransitionName  varchar(50), 
    @FromWorkFlowStateId  int, 
    @ToWorkFlowStateId  int, 
    @PostTransitionMethodName  varchar(255), 
    @UpdatedBy  int, 
    @RowVersion  timestamp
)
AS
    SET NOCOUNT ON

    UPDATE WorkFlowTransition
       SET 
           WorkFlowId = @WorkFlowId, 
           TransitionName = @TransitionName, 
           FromWorkFlowStateId = @FromWorkFlowStateId, 
           ToWorkFlowStateId = @ToWorkFlowStateId, 
           PostTransitionMethodName = @PostTransitionMethodName, 
           Updated = GetDate(), 
           UpdatedBy = @UpdatedBy
     WHERE WorkFlowTransitionId = @WorkFlowTransitionId
       AND RowVersion = @RowVersion

    RETURN @@ROWCOUNT

