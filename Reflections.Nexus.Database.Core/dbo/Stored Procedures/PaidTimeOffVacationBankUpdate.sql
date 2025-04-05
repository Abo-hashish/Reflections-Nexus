

CREATE PROCEDURE [dbo].[PaidTimeOffVacationBankUpdate]
(
    @PaidTimeOffVacationBankId  int, 
    @UserAccountId  int, 
    @VacationYear  smallint, 
    @PersonalDays  tinyint, 
    @VacationDays  tinyint, 
    @UpdatedBy  int, 
    @RowVersion  timestamp
)
AS
    SET NOCOUNT ON

    UPDATE PaidTimeOffVacationBank
       SET 
           UserAccountId = @UserAccountId, 
           VacationYear = @VacationYear, 
           PersonalDays = @PersonalDays, 
           VacationDays = @VacationDays, 
           Updated = GetDate(), 
           UpdatedBy = @UpdatedBy
     WHERE PaidTimeOffVacationBankId = @PaidTimeOffVacationBankId
       AND RowVersion = @RowVersion

    RETURN @@ROWCOUNT

