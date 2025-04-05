

CREATE PROCEDURE [dbo].[WorkFlowOwnerGroupSelectById]
(
    @WorkFlowOwnerGroupId int
)
AS
    SET NOCOUNT ON

    SELECT WorkFlowOwnerGroupId, WorkFlowId, OwnerGroupName, DefaultUserAccountId, IsDefaultSameAsLast, Description, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM WorkFlowOwnerGroup
     WHERE WorkFlowOwnerGroupId = @WorkFlowOwnerGroupId

    RETURN
