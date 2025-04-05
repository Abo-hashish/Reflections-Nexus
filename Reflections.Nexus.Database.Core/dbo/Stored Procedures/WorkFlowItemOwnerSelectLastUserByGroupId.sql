

CREATE PROCEDURE [dbo].[WorkFlowItemOwnerSelectLastUserByGroupId]
(
    @WorkFlowOwnerGroupId int,
    @UserAccountId int
)
AS
    SET NOCOUNT ON

     SELECT TOP(1) UserAccountId
       FROM WorkFlowItem
 INNER JOIN WorkFlowItemOwner
         ON WorkFlowItem.WorkFlowItemId = WorkFlowItemOwner.WorkFlowItemId
      WHERE WorkFlowOwnerGroupId = @WorkFlowOwnerGroupId
        AND WorkFlowItem.CreatedBy = @UserAccountId
   ORDER BY WorkFlowItem.Created Desc

    RETURN
