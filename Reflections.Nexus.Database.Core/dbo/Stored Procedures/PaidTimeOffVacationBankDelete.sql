

CREATE PROCEDURE [dbo].[PaidTimeOffVacationBankDelete]
(
    @PaidTimeOffVacationBankId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM PaidTimeOffVacationBank
     WHERE PaidTimeOffVacationBankId = @PaidTimeOffVacationBankId

    RETURN

