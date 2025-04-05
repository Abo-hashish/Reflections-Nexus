

CREATE PROCEDURE [dbo].[PaidTimeOffRequestSelectByCurrentOwner]
(	
    @UserAccountId int,
    @WorkFlowObjectName varchar(255)
)
AS
    SET NOCOUNT ON

    SELECT PaidTimeOffRequestId, UserAccountId, RequestDate, PaidTimeOffDayTypeId, PaidTimeOffRequestTypeId, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM PaidTimeOffRequest
INNER JOIN (SELECT ItemId, WorkFlowItemOwner.UserAccountId AS OwnerId
              FROM WorkFlowItem
        INNER JOIN WorkFlow
                ON WorkFlowItem.WorkFlowId = WorkFlow.WorkFlowId
        INNER JOIN WorkFlowState
                ON WorkFlowItem.CurrWorkFlowStateId = WorkFlowState.WorkFlowStateId
        INNER JOIN WorkFlowItemOwner
                ON WorkFlowItem.WorkFlowItemId = WorkFlowItemOwner.WorkFlowItemId
             WHERE WorkFlowObjectName = @WorkFlowObjectName
               AND WorkFlowState.WorkFlowOwnerGroupId = WorkFlowItemOwner.WorkFlowOwnerGroupId) AS Item
        ON PaidTimeOffRequest.PaidTimeOffRequestId = Item.ItemId
     WHERE Item.OwnerId = @UserAccountId       
       AND Cancelled = 0

    RETURN
