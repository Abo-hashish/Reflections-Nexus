CREATE PROCEDURE [dbo].[WorkFlowItemStateHistorySelectByWorkFlowItemId]
(
    @WorkFlowItemId int
)
AS
    SET NOCOUNT ON

    SELECT WorkFlowItemStateHistoryId, WorkFlowItemId, WorkFlowItemStateHistory.WorkFlowStateId, WorkFlowItemStateHistory.UserAccountId, WorkFlowItemStateHistory.Created, WorkFlowItemStateHistory.CreatedBy, WorkFlowItemStateHistory.Updated, WorkFlowItemStateHistory.UpdatedBy, WorkFlowItemStateHistory.RowVersion,
           StateName, 
           UserAccount.LastName + ', ' + UserAccount.FirstName AS OwnerName, 
           Inserted.LastName + ', ' + Inserted.FirstName AS InsertedBy
      FROM WorkFlowItemStateHistory
INNER JOIN WorkFlowState
        ON WorkFlowItemStateHistory.WorkFlowStateId = WorkFlowState.WorkFlowStateId
INNER JOIN UserAccount
        ON WorkFlowItemStateHistory.UserAccountId = UserAccount.UserAccountId
INNER JOIN UserAccount Inserted
        ON WorkFlowItemStateHistory.CreatedBy = Inserted.UserAccountId
     WHERE WorkFlowItemId = @WorkFlowItemId

    RETURN
