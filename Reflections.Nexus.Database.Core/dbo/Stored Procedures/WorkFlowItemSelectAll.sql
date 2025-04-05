CREATE PROCEDURE [dbo].[WorkFlowItemSelectAll]
AS
    SET NOCOUNT ON

    SELECT WorkFlowItemId, WorkFlowId, ItemId, SubmitterUserAccountId, CurrWorkFlowStateId, WorkFlowItem.Created, WorkFlowItem.CreatedBy, WorkFlowItem.Updated, WorkFlowItem.UpdatedBy, WorkFlowItem.RowVersion,
	       LastName + ', ' + FirstName AS SubmitterUserName
      FROM WorkFlowItem
INNER JOIN UserAccount
        ON WorkFlowItem.SubmitterUserAccountId = UserAccount.UserAccountId

    RETURN
