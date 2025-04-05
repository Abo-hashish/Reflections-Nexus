

CREATE PROCEDURE [dbo].[WorkFlowStatePropertySelectByWorkFlowStateId]
(
    @WorkFlowStateId int
)
AS
    SET NOCOUNT ON

    SELECT WorkFlowStatePropertyId, WorkFlowStateId, PropertyName, Required, ReadOnly, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM WorkFlowStateProperty
     WHERE WorkFlowStateId = @WorkFlowStateId

    RETURN
