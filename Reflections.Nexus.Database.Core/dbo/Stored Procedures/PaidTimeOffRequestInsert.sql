

CREATE PROCEDURE [dbo].[PaidTimeOffRequestInsert]
(
    @PaidTimeOffRequestId  int OUTPUT, 
    @UserAccountId  int, 
    @RequestDate  datetime, 
    @PaidTimeOffDayTypeId  int, 
    @PaidTimeOffRequestTypeId  int, 
    @CreatedBy  int
)
AS
    SET NOCOUNT ON

    INSERT INTO PaidTimeOffRequest (UserAccountId, RequestDate, PaidTimeOffDayTypeId, PaidTimeOffRequestTypeId, Created, CreatedBy, Updated, UpdatedBy)
         VALUES (
                @UserAccountId, 
                @RequestDate, 
                @PaidTimeOffDayTypeId, 
                @PaidTimeOffRequestTypeId, 
                GetDate(), 
                @CreatedBy, 
                GetDate(), 
                @CreatedBy
                )
    SET @PaidTimeOffRequestId = Scope_Identity()

    RETURN

