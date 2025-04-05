

CREATE PROCEDURE [dbo].[WorkFlowItemOwnerInsert]
(
    @WorkFlowItemOwnerId  int OUTPUT, 
    @WorkFlowItemId  int, 
    @WorkFlowOwnerGroupId  int, 
    @UserAccountId  int, 
    @CreatedBy  int
)
AS
    SET NOCOUNT ON

    INSERT INTO WorkFlowItemOwner (WorkFlowItemId, WorkFlowOwnerGroupId, UserAccountId, Created, CreatedBy, Updated, UpdatedBy)
         VALUES (
                @WorkFlowItemId, 
                @WorkFlowOwnerGroupId, 
                @UserAccountId, 
                GetDate(), 
                @CreatedBy, 
                GetDate(), 
                @CreatedBy
                )
    SET @WorkFlowItemOwnerId = Scope_Identity()

    RETURN

