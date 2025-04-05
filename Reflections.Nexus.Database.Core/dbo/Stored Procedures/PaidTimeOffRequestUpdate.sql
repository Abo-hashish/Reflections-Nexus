

CREATE PROCEDURE [dbo].[PaidTimeOffRequestUpdate]
(
    @PaidTimeOffRequestId  int, 
    @UserAccountId  int, 
    @RequestDate  datetime, 
    @PaidTimeOffDayTypeId  int, 
    @PaidTimeOffRequestTypeId  int, 
    @UpdatedBy  int, 
    @RowVersion  timestamp
)
AS
    SET NOCOUNT ON

    UPDATE PaidTimeOffRequest
       SET 
           UserAccountId = @UserAccountId, 
           RequestDate = @RequestDate, 
           PaidTimeOffDayTypeId = @PaidTimeOffDayTypeId, 
           PaidTimeOffRequestTypeId = @PaidTimeOffRequestTypeId, 
           Updated = GetDate(), 
           UpdatedBy = @UpdatedBy
     WHERE PaidTimeOffRequestId = @PaidTimeOffRequestId
       AND RowVersion = @RowVersion

    RETURN @@ROWCOUNT

