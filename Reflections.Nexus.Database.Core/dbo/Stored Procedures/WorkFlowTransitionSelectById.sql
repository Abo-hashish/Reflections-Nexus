

CREATE PROCEDURE [dbo].[WorkFlowTransitionSelectById]
(
    @WorkFlowTransitionId int
)
AS
    SET NOCOUNT ON

         SELECT WorkFlowTransitionId, WorkFlowTransition.WorkFlowId, TransitionName, FromWorkFlowStateId, ToWorkFlowStateId, PostTransitionMethodName, WorkFlowTransition.Created, WorkFlowTransition.CreatedBy, WorkFlowTransition.Updated, WorkFlowTransition.UpdatedBy, WorkFlowTransition.RowVersion,
                WorkFlowState.StateName AS FromStateName, WorkFlowState1.StateName AS ToStateName
           FROM WorkFlowTransition 
     INNER JOIN WorkFlowState AS WorkFlowState1 
             ON WorkFlowState1.WorkFlowStateId = WorkFlowTransition.ToWorkFlowStateId 
LEFT OUTER JOIN WorkFlowState 
             ON WorkFlowState.WorkFlowStateId = WorkFlowTransition.FromWorkFlowStateId   
          WHERE WorkFlowTransitionId = @WorkFlowTransitionId

    RETURN
