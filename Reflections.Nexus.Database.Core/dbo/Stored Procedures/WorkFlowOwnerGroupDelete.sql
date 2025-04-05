

CREATE PROCEDURE [dbo].[WorkFlowOwnerGroupDelete]
(
    @WorkFlowOwnerGroupId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM WorkFlowOwnerGroup
     WHERE WorkFlowOwnerGroupId = @WorkFlowOwnerGroupId

    RETURN

