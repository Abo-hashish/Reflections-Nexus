CREATE PROCEDURE [dbo].[NotificationWorkFlowStateSelectAll]
AS
    SET NOCOUNT ON

    SELECT NotificationWorkFlowStateId, NotificationUserAccountId, WorkFlowStateId, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM NotificationWorkFlowState

    RETURN
