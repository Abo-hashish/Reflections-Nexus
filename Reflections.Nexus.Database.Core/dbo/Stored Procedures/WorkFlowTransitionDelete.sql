

CREATE PROCEDURE [dbo].[WorkFlowTransitionDelete]
(
    @WorkFlowTransitionId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM WorkFlowTransition
     WHERE WorkFlowTransitionId = @WorkFlowTransitionId

    RETURN

