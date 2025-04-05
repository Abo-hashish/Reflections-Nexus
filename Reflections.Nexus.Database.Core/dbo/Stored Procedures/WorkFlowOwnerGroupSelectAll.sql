CREATE PROCEDURE [dbo].[WorkFlowOwnerGroupSelectAll]
AS
    SET NOCOUNT ON

    SELECT WorkFlowOwnerGroupId, WorkFlowId, OwnerGroupName, DefaultUserAccountId, IsDefaultSameAsLast, Description, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM WorkFlowOwnerGroup

    RETURN
