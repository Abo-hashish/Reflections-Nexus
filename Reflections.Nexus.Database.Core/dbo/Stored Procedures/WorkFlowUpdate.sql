CREATE PROCEDURE [dbo].[WorkFlowUpdate]
(
    @WorkFlowId  int, 
    @WorkflowName  varchar(50), 
    @WorkFlowObjectName  varchar(255),     
    @UpdatedBy  int, 
    @RowVersion  timestamp
)
AS
    SET NOCOUNT ON

    UPDATE WorkFlow
       SET 
           WorkflowName = @WorkflowName, 
           WorkFlowObjectName = @WorkFlowObjectName,            
           Updated = GetDate(), 
           UpdatedBy = @UpdatedBy
     WHERE WorkFlowId = @WorkFlowId
       AND RowVersion = @RowVersion

    RETURN @@ROWCOUNT

