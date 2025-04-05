CREATE PROCEDURE [dbo].[WorkFlowOwnerGroupSelectByWorkFlowId]
(
	@WorkFlowId int
)
AS
	SET NOCOUNT ON
	
    SELECT WorkFlowOwnerGroupId, WorkFlowId, OwnerGroupName, DefaultUserAccountId, IsDefaultSameAsLast, Description, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM WorkFlowOwnerGroup
     WHERE WorkFlowId = @WorkFlowId
	
	RETURN
