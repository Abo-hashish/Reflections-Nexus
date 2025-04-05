CREATE PROCEDURE [dbo].[UserAccountSelectByWorkFlowOwnerGroupId]
(
	@WorkFlowOwnerGroupId int
)
AS
	SET NOCOUNT ON
	
	SELECT UserAccount.UserAccountId, AccountName, FirstName, LastName, Email, IsActive, UserAccount.Created, UserAccount.CreatedBy, UserAccount.Updated, UserAccount.UpdatedBy, UserAccount.RowVersion
	  FROM UserAccount
INNER JOIN WorkFlowOwnerGroupUserAccount
        ON UserAccount.UserAccountId = WorkFlowOwnerGroupUserAccount.UserAccountId
	 WHERE WorkFlowOwnerGroupId = @WorkFlowOwnerGroupId
	
	RETURN
