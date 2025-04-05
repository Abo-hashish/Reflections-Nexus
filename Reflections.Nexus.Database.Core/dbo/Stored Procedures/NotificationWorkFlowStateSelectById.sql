

CREATE PROCEDURE [dbo].[NotificationWorkFlowStateSelectById]
(
    @NotificationWorkFlowStateId int
)
AS
    SET NOCOUNT ON

    SELECT NotificationWorkFlowStateId, NotificationUserAccountId, WorkFlowStateId, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM NotificationWorkFlowState
     WHERE NotificationWorkFlowStateId = @NotificationWorkFlowStateId

    RETURN
