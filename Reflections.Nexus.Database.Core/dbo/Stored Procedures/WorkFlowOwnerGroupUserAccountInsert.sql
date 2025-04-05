

CREATE PROCEDURE [dbo].[WorkFlowOwnerGroupUserAccountInsert]
(
    @WorkFlowOwnerGroupUserAccountId  int OUTPUT, 
    @WorkFlowOwnerGroupId  int, 
    @UserAccountId  int, 
    @CreatedBy  int
)
AS
    SET NOCOUNT ON

    INSERT INTO WorkFlowOwnerGroupUserAccount (WorkFlowOwnerGroupId, UserAccountId, Created, CreatedBy, Updated, UpdatedBy)
         VALUES (
                @WorkFlowOwnerGroupId, 
                @UserAccountId, 
                GetDate(), 
                @CreatedBy, 
                GetDate(), 
                @CreatedBy
                )
    SET @WorkFlowOwnerGroupUserAccountId = Scope_Identity()

    RETURN

