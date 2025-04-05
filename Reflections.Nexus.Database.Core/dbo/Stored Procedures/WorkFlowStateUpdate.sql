

CREATE PROCEDURE [dbo].[WorkFlowStateUpdate]
(
    @WorkFlowStateId  int, 
    @WorkFlowId  int, 
    @StateName  varchar(50), 
    @Description  varchar(255), 
    @WorkFlowOwnerGroupId  int, 
    @IsOwnerSubmitter  bit, 
    @UpdatedBy  int, 
    @RowVersion  timestamp
)
AS
    SET NOCOUNT ON

    UPDATE WorkFlowState
       SET 
           WorkFlowId = @WorkFlowId, 
           StateName = @StateName, 
           Description = @Description, 
           WorkFlowOwnerGroupId = @WorkFlowOwnerGroupId, 
           IsOwnerSubmitter = @IsOwnerSubmitter, 
           Updated = GetDate(), 
           UpdatedBy = @UpdatedBy
     WHERE WorkFlowStateId = @WorkFlowStateId
       AND RowVersion = @RowVersion

    RETURN @@ROWCOUNT

