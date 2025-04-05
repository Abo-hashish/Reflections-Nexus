

CREATE PROCEDURE [dbo].[WorkFlowItemOwnerUpdate]
(
    @WorkFlowItemOwnerId  int, 
    @WorkFlowItemId  int, 
    @WorkFlowOwnerGroupId  int, 
    @UserAccountId  int, 
    @UpdatedBy  int, 
    @RowVersion  timestamp
)
AS
    SET NOCOUNT ON

    UPDATE WorkFlowItemOwner
       SET 
           WorkFlowItemId = @WorkFlowItemId, 
           WorkFlowOwnerGroupId = @WorkFlowOwnerGroupId, 
           UserAccountId = @UserAccountId, 
           Updated = GetDate(), 
           UpdatedBy = @UpdatedBy
     WHERE WorkFlowItemOwnerId = @WorkFlowItemOwnerId
       AND RowVersion = @RowVersion

    RETURN @@ROWCOUNT

