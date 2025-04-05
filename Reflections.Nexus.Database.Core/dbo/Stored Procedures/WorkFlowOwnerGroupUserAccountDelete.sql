

CREATE PROCEDURE [dbo].[WorkFlowOwnerGroupUserAccountDelete]
(
    @WorkFlowOwnerGroupUserAccountId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM WorkFlowOwnerGroupUserAccount
     WHERE WorkFlowOwnerGroupUserAccountId = @WorkFlowOwnerGroupUserAccountId

    RETURN

