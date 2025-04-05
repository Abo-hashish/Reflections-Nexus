

CREATE PROCEDURE [dbo].[WorkFlowStatePropertyDeleteByWorkFlowStateId]
(
    @WorkFlowStateId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM WorkFlowStateProperty
     WHERE WorkFlowStateId = @WorkFlowStateId

    RETURN

