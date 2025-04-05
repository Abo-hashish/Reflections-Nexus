

CREATE PROCEDURE [dbo].[WorkFlowOwnerGroupUserAccountUpdate]
(
    @WorkFlowOwnerGroupUserAccountId  int, 
    @WorkFlowOwnerGroupId  int, 
    @UserAccountId  int, 
    @UpdatedBy  int, 
    @RowVersion  timestamp
)
AS
    SET NOCOUNT ON

    UPDATE WorkFlowOwnerGroupUserAccount
       SET 
           WorkFlowOwnerGroupId = @WorkFlowOwnerGroupId, 
           UserAccountId = @UserAccountId, 
           Updated = GetDate(), 
           UpdatedBy = @UpdatedBy
     WHERE WorkFlowOwnerGroupUserAccountId = @WorkFlowOwnerGroupUserAccountId
       AND RowVersion = @RowVersion

    RETURN @@ROWCOUNT

