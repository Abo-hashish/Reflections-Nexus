CREATE PROCEDURE [dbo].[WorkFlowOwnerGroupSelectCountByNameWorkflowId]
(
	@WorkFlowOwnerGroupId int,
	@WorkFlowId int,
	@OwnerGroupName varchar(50)
)
AS
	SET NOCOUNT ON

	SELECT COUNT(1) AS CountOfNames
	  FROM WorkFlowOwnerGroup
	 WHERE OwnerGroupName = @OwnerGroupName
  	   AND WorkFlowId = @WorkFlowId
	   AND WorkFlowOwnerGroupId <> @WorkFlowOwnerGroupId
	
	RETURN
