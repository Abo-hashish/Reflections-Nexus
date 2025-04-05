

CREATE PROCEDURE [dbo].[WorkFlowItemInsert]
(
    @WorkFlowItemId  int OUTPUT, 
    @WorkFlowId  int, 
    @ItemId  int, 
    @SubmitterUserAccountId  int, 
    @CurrWorkFlowStateId  int, 
    @CreatedBy  int
)
AS
    SET NOCOUNT ON

    INSERT INTO WorkFlowItem (WorkFlowId, ItemId, SubmitterUserAccountId, CurrWorkFlowStateId, Created, CreatedBy, Updated, UpdatedBy)
         VALUES (
                @WorkFlowId, 
                @ItemId, 
                @SubmitterUserAccountId, 
                @CurrWorkFlowStateId, 
                GetDate(), 
                @CreatedBy, 
                GetDate(), 
                @CreatedBy
                )
    SET @WorkFlowItemId = Scope_Identity()

    RETURN

