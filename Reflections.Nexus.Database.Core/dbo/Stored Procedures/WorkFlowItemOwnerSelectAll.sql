CREATE PROCEDURE [dbo].[WorkFlowItemOwnerSelectAll]
AS
    SET NOCOUNT ON

         SELECT WorkFlowItemOwnerId, WorkFlowItemId, WorkFlowOwnerGroupId, WorkFlowItemOwner.UserAccountId, WorkFlowItemOwner.Created, WorkFlowItemOwner.CreatedBy, WorkFlowItemOwner.Updated, WorkFlowItemOwner.UpdatedBy, WorkFlowItemOwner.RowVersion,
		        LastName + ', ' + FirstName AS UserName
           FROM WorkFlowItemOwner
LEFT OUTER JOIN UserAccount
             ON WorkFlowItemOwner.UserAccountId = UserAccount.UserAccountId
              

    RETURN
