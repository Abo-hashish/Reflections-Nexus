CREATE PROCEDURE [dbo].[WorkFlowStatePropertySelectAll]
AS
    SET NOCOUNT ON

    SELECT WorkFlowStatePropertyId, WorkFlowStateId, PropertyName, Required, ReadOnly, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM WorkFlowStateProperty

    RETURN
