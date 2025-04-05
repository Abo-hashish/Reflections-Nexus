CREATE PROCEDURE [dbo].[PaidTimeOffRequestTypeSelectAll]
AS
    SET NOCOUNT ON

    SELECT PaidTimeOffRequestTypeId, PaidTimeOffRequestTypeName, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM PaidTimeOffRequestType

    RETURN
