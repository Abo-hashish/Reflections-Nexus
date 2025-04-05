

CREATE PROCEDURE [dbo].[PaidTimeOffRequestSelectByUserAccountIdYear]
(
	@PaidTimeOffRequestId int,
    @UserAccountId int,
    @VacationYear smallint
)
AS
    SET NOCOUNT ON

    SELECT (SELECT COUNT(1)
             FROM PaidTimeOffRequest
            WHERE UserAccountId = @UserAccountId
              AND PaidTimeOffRequest.PaidTimeOffRequestId <> @PaidTimeOffRequestId
              AND YEAR(RequestDate) = @VacationYear
              AND PaidTimeOffRequestTypeId = 1
              AND PaidTimeOffDayTypeId = 1
              AND Cancelled = 0) AS CountOfFullVacation,
           (SELECT COUNT(1) * 0.5
             FROM PaidTimeOffRequest
            WHERE UserAccountId = @UserAccountId
              AND PaidTimeOffRequest.PaidTimeOffRequestId <> @PaidTimeOffRequestId
              AND YEAR(RequestDate) = @VacationYear
              AND PaidTimeOffRequestTypeId = 1
              AND PaidTimeOffDayTypeId <> 1
              AND Cancelled = 0) AS CountOfHalfVacation,
           (SELECT COUNT(1)
             FROM PaidTimeOffRequest
            WHERE UserAccountId = @UserAccountId
              AND PaidTimeOffRequest.PaidTimeOffRequestId <> @PaidTimeOffRequestId
              AND YEAR(RequestDate) = @VacationYear
              AND PaidTimeOffRequestTypeId = 2
              AND PaidTimeOffDayTypeId = 1
              AND Cancelled = 0) AS CountOfFullPersonal,
           (SELECT COUNT(1) * 0.5
             FROM PaidTimeOffRequest
            WHERE UserAccountId = @UserAccountId
              AND PaidTimeOffRequest.PaidTimeOffRequestId <> @PaidTimeOffRequestId
              AND YEAR(RequestDate) = @VacationYear
              AND PaidTimeOffRequestTypeId = 2
              AND PaidTimeOffDayTypeId <> 1
              AND Cancelled = 0) AS CountOfHalfPersonal,
           (SELECT COUNT(1)
             FROM PaidTimeOffRequest
            WHERE UserAccountId = @UserAccountId
              AND PaidTimeOffRequest.PaidTimeOffRequestId <> @PaidTimeOffRequestId
              AND YEAR(RequestDate) = @VacationYear
              AND PaidTimeOffRequestTypeId = 3
              AND PaidTimeOffDayTypeId = 1
              AND Cancelled = 0) AS CountOfFullUnpaid,
           (SELECT COUNT(1) * 0.5
             FROM PaidTimeOffRequest
            WHERE UserAccountId = @UserAccountId
              AND PaidTimeOffRequest.PaidTimeOffRequestId <> @PaidTimeOffRequestId
              AND YEAR(RequestDate) = @VacationYear
              AND PaidTimeOffRequestTypeId = 3
              AND PaidTimeOffDayTypeId <> 1
              AND Cancelled = 0) AS CountOfHalfUnPaid

    RETURN
