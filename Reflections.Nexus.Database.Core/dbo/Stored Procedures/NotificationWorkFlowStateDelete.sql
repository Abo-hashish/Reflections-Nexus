

CREATE PROCEDURE [dbo].[NotificationWorkFlowStateDelete]
(
    @NotificationWorkFlowStateId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM NotificationWorkFlowState
     WHERE NotificationWorkFlowStateId = @NotificationWorkFlowStateId

    RETURN

