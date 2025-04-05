CREATE PROCEDURE [dbo].[PaidTimeOffVacationBankCopyYear]
(
	@FromYear smallint,
	@ToYear smallint,
	@CreatedBy int	
)
AS
	SET NOCOUNT ON
	
	INSERT INTO PaidTimeOffVacationBank(UserAccountId, VacationYear, PersonalDays, VacationDays, Created, CreatedBy, Updated, UpdatedBy)
	SELECT UserAccountId, @ToYear, PersonalDays, VacationDays, GetDate(), @CreatedBy, GetDate(), @CreatedBy
	  FROM PaidTimeOffVacationBank
	 WHERE VacationYear = @FromYear
	   AND UserAccountID NOT IN (SELECT UserAccountID
	                                  FROM PaidTimeOffVacationBank
	                                  WHERE VacationYear = @ToYear)
	
	RETURN
