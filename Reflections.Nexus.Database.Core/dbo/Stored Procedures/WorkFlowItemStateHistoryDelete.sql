

CREATE PROCEDURE [dbo].[WorkFlowItemStateHistoryDelete]
(
    @WorkFlowItemStateHistoryId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM WorkFlowItemStateHistory
     WHERE WorkFlowItemStateHistoryId = @WorkFlowItemStateHistoryId

    RETURN

