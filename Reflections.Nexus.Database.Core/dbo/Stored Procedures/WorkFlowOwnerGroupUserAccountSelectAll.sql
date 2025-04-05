CREATE PROCEDURE [dbo].[WorkFlowOwnerGroupUserAccountSelectAll]
AS
    SET NOCOUNT ON

    SELECT WorkFlowOwnerGroupUserAccountId, WorkFlowOwnerGroupId, WorkFlowOwnerGroupUserAccount.UserAccountId, WorkFlowOwnerGroupUserAccount.Created, WorkFlowOwnerGroupUserAccount.CreatedBy, WorkFlowOwnerGroupUserAccount.Updated, WorkFlowOwnerGroupUserAccount.UpdatedBy, WorkFlowOwnerGroupUserAccount.RowVersion,
		   LastName + ', ' + FirstName AS UserName
      FROM WorkFlowOwnerGroupUserAccount
INNER JOIN UserAccount
        ON WorkFlowOwnerGroupUserAccount.UserAccountId = UserAccount.UserAccountId

    RETURN
