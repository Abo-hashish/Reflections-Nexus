

CREATE PROCEDURE [dbo].[WorkFlowItemDelete]
(
    @WorkFlowItemId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM WorkFlowItem
     WHERE WorkFlowItemId = @WorkFlowItemId

    RETURN

