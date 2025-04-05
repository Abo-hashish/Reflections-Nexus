

CREATE PROCEDURE [dbo].[PaidTimeOffRequestSelectByUserAccountId]
(	
    @UserAccountId int
)
AS
    SET NOCOUNT ON

    SELECT PaidTimeOffRequestId, UserAccountId, RequestDate, PaidTimeOffDayTypeId, PaidTimeOffRequestTypeId, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM PaidTimeOffRequest
     WHERE UserAccountId = @UserAccountId       

    RETURN
