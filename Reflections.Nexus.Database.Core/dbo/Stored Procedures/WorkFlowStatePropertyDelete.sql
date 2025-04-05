

CREATE PROCEDURE [dbo].[WorkFlowStatePropertyDelete]
(
    @WorkFlowStatePropertyId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM WorkFlowStateProperty
     WHERE WorkFlowStatePropertyId = @WorkFlowStatePropertyId

    RETURN

