

CREATE PROCEDURE [dbo].[WorkFlowItemOwnerDelete]
(
    @WorkFlowItemOwnerId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM WorkFlowItemOwner
     WHERE WorkFlowItemOwnerId = @WorkFlowItemOwnerId

    RETURN

