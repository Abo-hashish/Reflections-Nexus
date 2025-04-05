

CREATE PROCEDURE [dbo].[WorkFlowStatePropertySelectById]
(
    @WorkFlowStatePropertyId int
)
AS
    SET NOCOUNT ON

    SELECT WorkFlowStatePropertyId, WorkFlowStateId, PropertyName, Required, ReadOnly, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM WorkFlowStateProperty
     WHERE WorkFlowStatePropertyId = @WorkFlowStatePropertyId

    RETURN
