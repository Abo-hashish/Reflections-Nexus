

CREATE PROCEDURE [dbo].[WorkFlowItemSelectByWorkflowId]
(
    @WorkFlowId int    
)
AS
    SET NOCOUNT ON

    SELECT COUNT(1) AS CountOfWorkFlowItems
      FROM WorkFlowItem
     WHERE WorkFlowId = @WorkFlowId       

    RETURN
