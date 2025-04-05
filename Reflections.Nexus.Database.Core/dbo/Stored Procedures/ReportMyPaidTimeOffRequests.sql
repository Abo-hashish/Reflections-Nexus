

CREATE PROCEDURE [dbo].[ReportMyPaidTimeOffRequests]
(	
	@WorkFlowObjectName varchar(255),
    @UserAccountId int
)
AS
    SET NOCOUNT ON

    SELECT UserAccount.LastName, UserAccount.FirstName, PaidTimeOffRequest.RequestDate, 
           PaidTimeOffDayType.PaidTimeOffDayTypeName, PaidTimeOffRequestType.PaidTimeOffRequestTypeName, WorkFlowState.StateName AS CurrentState, 
           CurrentOwner.LastName AS CurrentOwnerLastName, CurrentOwner.FirstName AS CurrentOwnerFirstName
      FROM WorkFlow 
INNER JOIN WorkFlowItem ON WorkFlow.WorkFlowId = WorkFlowItem.WorkFlowId 
INNER JOIN PaidTimeOffRequest 
INNER JOIN PaidTimeOffDayType ON PaidTimeOffRequest.PaidTimeOffDayTypeId = PaidTimeOffDayType.PaidTimeOffDayTypeId 
INNER JOIN PaidTimeOffRequestType ON PaidTimeOffRequest.PaidTimeOffRequestTypeId = PaidTimeOffRequestType.PaidTimeOffRequestTypeId 
        ON WorkFlowItem.ItemId = PaidTimeOffRequest.PaidTimeOffRequestId 
INNER JOIN UserAccount ON PaidTimeOffRequest.UserAccountId = UserAccount.UserAccountId 
INNER JOIN WorkFlowState ON WorkFlowItem.CurrWorkFlowStateId = WorkFlowState.WorkFlowStateId 
INNER JOIN WorkFlowItemOwner ON WorkFlowState.WorkFlowOwnerGroupId = WorkFlowItemOwner.WorkFlowOwnerGroupId 
       AND WorkFlowItem.WorkFlowItemId = WorkFlowItemOwner.WorkFlowItemId 
INNER JOIN UserAccount AS CurrentOwner ON WorkFlowItemOwner.UserAccountId = CurrentOwner.UserAccountId
     WHERE PaidTimeOffRequest.UserAccountId = @UserAccountId
       AND WorkFlowObjectName = @WorkFlowObjectName

    RETURN
