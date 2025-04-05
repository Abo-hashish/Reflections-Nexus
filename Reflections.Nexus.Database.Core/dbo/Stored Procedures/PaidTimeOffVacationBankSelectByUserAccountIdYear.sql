

CREATE PROCEDURE [dbo].[PaidTimeOffVacationBankSelectByUserAccountIdYear]
(
    @UserAccountid int,
    @VacationYear smallint
)
AS
    SET NOCOUNT ON

    SELECT PaidTimeOffVacationBankId, PaidTimeOffVacationBank.UserAccountId, VacationYear, PersonalDays, VacationDays, PaidTimeOffVacationBank.Created, PaidTimeOffVacationBank.CreatedBy, PaidTimeOffVacationBank.Updated, PaidTimeOffVacationBank.UpdatedBy, PaidTimeOffVacationBank.RowVersion,
           LastName + ', ' + FirstName AS UserName
      FROM PaidTimeOffVacationBank
INNER JOIN UserAccount
        ON PaidTimeOffVacationBank.UserAccountId = UserAccount.UserAccountId
     WHERE PaidTimeOffVacationBank.UserAccountid = @UserAccountId
       AND VacationYear = @VacationYear

    RETURN
