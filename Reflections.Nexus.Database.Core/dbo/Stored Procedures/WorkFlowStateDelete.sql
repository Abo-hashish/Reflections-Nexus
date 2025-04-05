

CREATE PROCEDURE [dbo].[WorkFlowStateDelete]
(
    @WorkFlowStateId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM WorkFlowState
     WHERE WorkFlowStateId = @WorkFlowStateId

    RETURN

