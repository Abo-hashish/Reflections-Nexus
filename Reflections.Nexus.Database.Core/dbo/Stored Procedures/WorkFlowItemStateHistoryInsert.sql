

CREATE PROCEDURE [dbo].[WorkFlowItemStateHistoryInsert]
(
    @WorkFlowItemStateHistoryId  int OUTPUT, 
    @WorkFlowItemId  int, 
    @WorkFlowStateId  int, 
    @UserAccountId  int, 
    @CreatedBy  int
)
AS
    SET NOCOUNT ON

    INSERT INTO WorkFlowItemStateHistory (WorkFlowItemId, WorkFlowStateId, UserAccountId, Created, CreatedBy, Updated, UpdatedBy)
         VALUES (
                @WorkFlowItemId, 
                @WorkFlowStateId, 
                @UserAccountId, 
                GetDate(), 
                @CreatedBy, 
                GetDate(), 
                @CreatedBy
                )
    SET @WorkFlowItemStateHistoryId = Scope_Identity()

    RETURN

