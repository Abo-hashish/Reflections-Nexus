

CREATE PROCEDURE [dbo].[HolidayUpdate]
(
    @HolidayId  int, 
    @HolidayName  varchar(50), 
    @HolidayDate  datetime, 
    @UpdatedBy  int, 
    @RowVersion  timestamp
)
AS
    SET NOCOUNT ON

    UPDATE Holiday
       SET 
           HolidayName = @HolidayName, 
           HolidayDate = @HolidayDate, 
           Updated = GetDate(), 
           UpdatedBy = @UpdatedBy
     WHERE HolidayId = @HolidayId
       AND RowVersion = @RowVersion

    RETURN @@ROWCOUNT

