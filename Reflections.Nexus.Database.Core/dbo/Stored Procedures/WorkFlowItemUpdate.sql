

CREATE PROCEDURE [dbo].[WorkFlowItemUpdate]
(
    @WorkFlowItemId  int, 
    @WorkFlowId  int, 
    @ItemId  int, 
    @SubmitterUserAccountId  int, 
    @CurrWorkFlowStateId  int, 
    @UpdatedBy  int, 
    @RowVersion  timestamp
)
AS
    SET NOCOUNT ON

    UPDATE WorkFlowItem
       SET 
           WorkFlowId = @WorkFlowId, 
           ItemId = @ItemId, 
           SubmitterUserAccountId = @SubmitterUserAccountId, 
           CurrWorkFlowStateId = @CurrWorkFlowStateId, 
           Updated = GetDate(), 
           UpdatedBy = @UpdatedBy
     WHERE WorkFlowItemId = @WorkFlowItemId
       AND RowVersion = @RowVersion

    RETURN @@ROWCOUNT

