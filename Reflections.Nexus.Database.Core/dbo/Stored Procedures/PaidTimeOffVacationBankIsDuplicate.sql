

CREATE PROCEDURE [dbo].[PaidTimeOffVacationBankIsDuplicate]
(
    @PaidTimeOffVacationBankId int,
    @UserAccountId int,
    @VacationYear smallint
)
AS
    SET NOCOUNT ON

    SELECT Count(1) AS CountOfDuplicates
      FROM PaidTimeOffVacationBank
     WHERE PaidTimeOffVacationBankId <> @PaidTimeOffVacationBankId
       AND UserAccountId = @UserAccountId
       AND VacationYear = @VacationYear

    RETURN
