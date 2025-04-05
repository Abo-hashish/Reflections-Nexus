

CREATE PROCEDURE [dbo].[PaidTimeOffRequestSelectById]
(
    @PaidTimeOffRequestId int
)
AS
    SET NOCOUNT ON

    SELECT PaidTimeOffRequestId, UserAccountId, RequestDate, PaidTimeOffDayTypeId, PaidTimeOffRequestTypeId, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM PaidTimeOffRequest
     WHERE PaidTimeOffRequestId = @PaidTimeOffRequestId

    RETURN
