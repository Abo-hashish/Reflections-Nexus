CREATE PROCEDURE [dbo].[PaidTimeOffRequestSelectAll]
AS
    SET NOCOUNT ON

    SELECT PaidTimeOffRequestId, UserAccountId, RequestDate, PaidTimeOffDayTypeId, PaidTimeOffRequestTypeId, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM PaidTimeOffRequest

    RETURN
