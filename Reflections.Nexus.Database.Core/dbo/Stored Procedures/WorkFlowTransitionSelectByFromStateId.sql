CREATE PROCEDURE [dbo].[WorkFlowTransitionSelectByFromStateId]
(
    @FromWorkFlowStateId int
)
AS
    SET NOCOUNT ON

    DECLARE @SQL varchar(1000)

    SET @SQL = 'SELECT WorkFlowTransitionId, WorkFlowTransition.WorkFlowId, TransitionName, FromWorkFlowStateId, ToWorkFlowStateId, PostTransitionMethodName, WorkFlowTransition.Created, WorkFlowTransition.CreatedBy, WorkFlowTransition.Updated, WorkFlowTransition.UpdatedBy, WorkFlowTransition.RowVersion,
                WorkFlowState.StateName AS FromStateName, WorkFlowState1.StateName AS ToStateName
           FROM WorkFlowTransition 
     INNER JOIN WorkFlowState AS WorkFlowState1 
             ON WorkFlowState1.WorkFlowStateId = WorkFlowTransition.ToWorkFlowStateId 
LEFT OUTER JOIN WorkFlowState 
             ON WorkFlowState.WorkFlowStateId = WorkFlowTransition.FromWorkFlowStateId '

    IF @FromWorkFlowStateId IS NULL 
        SET @SQL = @SQL + 'WHERE FromWorkFlowStateId IS NULL'
    ELSE
        SET @SQL = @SQL + 'WHERE FromWorkFlowStateID = ' + CONVERT(varchar(15), @FromWorkFlowStateId)

    EXEC(@SQL)

    RETURN
