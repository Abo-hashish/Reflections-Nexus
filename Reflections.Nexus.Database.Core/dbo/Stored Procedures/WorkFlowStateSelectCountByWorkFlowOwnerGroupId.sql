CREATE PROCEDURE [dbo].[WorkFlowStateSelectCountByWorkFlowOwnerGroupId]
(
	@WorkFlowOwnerGroupId int	
)
AS
	SET NOCOUNT ON

	SELECT COUNT(1) AS CountOfStates
	  FROM WorkFlowState
	 WHERE WorkFlowOwnerGroupId = @WorkFlowOwnerGroupId
	
	RETURN
