CREATE PROCEDURE [dbo].[PaidTimeOffVacationBankSelectDistinctYears]	
AS
	SET NOCOUNT ON
	
	SELECT DISTINCT VacationYear
	  FROM PaidTimeOffVacationBank
	
	RETURN
