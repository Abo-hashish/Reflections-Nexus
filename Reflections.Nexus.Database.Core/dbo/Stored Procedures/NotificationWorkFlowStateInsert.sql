

CREATE PROCEDURE [dbo].[NotificationWorkFlowStateInsert]
(
    @NotificationWorkFlowStateId  int OUTPUT, 
    @NotificationUserAccountId  int, 
    @WorkFlowStateId  int, 
    @CreatedBy  int
)
AS
    SET NOCOUNT ON

    INSERT INTO NotificationWorkFlowState (NotificationUserAccountId, WorkFlowStateId, Created, CreatedBy, Updated, UpdatedBy)
         VALUES (
                @NotificationUserAccountId, 
                @WorkFlowStateId, 
                GetDate(), 
                @CreatedBy, 
                GetDate(), 
                @CreatedBy
                )
    SET @NotificationWorkFlowStateId = Scope_Identity()

    RETURN

