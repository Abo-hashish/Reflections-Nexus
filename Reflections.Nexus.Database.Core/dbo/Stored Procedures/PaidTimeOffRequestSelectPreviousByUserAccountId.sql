

CREATE PROCEDURE [dbo].[PaidTimeOffRequestSelectPreviousByUserAccountId]
(
	@PaidTimeOffRequestId int,
    @UserAccountId int
)
AS
    SET NOCOUNT ON

    SELECT PaidTimeOffRequestId, UserAccountId, RequestDate, PaidTimeOffDayTypeId, PaidTimeOffRequestTypeId, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM PaidTimeOffRequest
     WHERE UserAccountId = @UserAccountId
       AND PaidTimeOffRequest.PaidTimeOffRequestId <> @PaidTimeOffRequestId
       AND Cancelled = 0

    RETURN
