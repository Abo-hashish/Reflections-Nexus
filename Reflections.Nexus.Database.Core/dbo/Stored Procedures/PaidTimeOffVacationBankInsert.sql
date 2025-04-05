

CREATE PROCEDURE [dbo].[PaidTimeOffVacationBankInsert]
(
    @PaidTimeOffVacationBankId  int OUTPUT, 
    @UserAccountId  int, 
    @VacationYear  smallint, 
    @PersonalDays  tinyint, 
    @VacationDays  tinyint, 
    @CreatedBy  int
)
AS
    SET NOCOUNT ON

    INSERT INTO PaidTimeOffVacationBank (UserAccountId, VacationYear, PersonalDays, VacationDays, Created, CreatedBy, Updated, UpdatedBy)
         VALUES (
                @UserAccountId, 
                @VacationYear, 
                @PersonalDays, 
                @VacationDays, 
                GetDate(), 
                @CreatedBy, 
                GetDate(), 
                @CreatedBy
                )
    SET @PaidTimeOffVacationBankId = Scope_Identity()

    RETURN

