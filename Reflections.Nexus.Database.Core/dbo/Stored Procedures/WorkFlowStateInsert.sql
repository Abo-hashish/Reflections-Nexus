

CREATE PROCEDURE [dbo].[WorkFlowStateInsert]
(
    @WorkFlowStateId  int OUTPUT, 
    @WorkFlowId  int, 
    @StateName  varchar(50), 
    @Description  varchar(255), 
    @WorkFlowOwnerGroupId  int, 
    @IsOwnerSubmitter  bit, 
    @CreatedBy  int
)
AS
    SET NOCOUNT ON

    INSERT INTO WorkFlowState (WorkFlowId, StateName, Description, WorkFlowOwnerGroupId, IsOwnerSubmitter, Created, CreatedBy, Updated, UpdatedBy)
         VALUES (
                @WorkFlowId, 
                @StateName, 
                @Description, 
                @WorkFlowOwnerGroupId, 
                @IsOwnerSubmitter, 
                GetDate(), 
                @CreatedBy, 
                GetDate(), 
                @CreatedBy
                )
    SET @WorkFlowStateId = Scope_Identity()

    RETURN

