

CREATE PROCEDURE [dbo].[WorkFlowDelete]
(
    @WorkFlowId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM WorkFlow
     WHERE WorkFlowId = @WorkFlowId

    RETURN

