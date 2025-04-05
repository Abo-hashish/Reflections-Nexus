

CREATE PROCEDURE [dbo].[WorkFlowStatePropertyUpdate]
(
    @WorkFlowStatePropertyId  int, 
    @WorkFlowStateId  int, 
    @PropertyName  varchar(255), 
    @Required  bit, 
    @ReadOnly  bit, 
    @UpdatedBy  int, 
    @RowVersion  timestamp
)
AS
    SET NOCOUNT ON

    UPDATE WorkFlowStateProperty
       SET 
           WorkFlowStateId = @WorkFlowStateId, 
           PropertyName = @PropertyName, 
           Required = @Required, 
           ReadOnly = @ReadOnly, 
           Updated = GetDate(), 
           UpdatedBy = @UpdatedBy
     WHERE WorkFlowStatePropertyId = @WorkFlowStatePropertyId
       AND RowVersion = @RowVersion

    RETURN @@ROWCOUNT

