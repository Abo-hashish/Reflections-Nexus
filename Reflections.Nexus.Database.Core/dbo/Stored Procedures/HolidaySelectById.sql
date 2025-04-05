

CREATE PROCEDURE [dbo].[HolidaySelectById]
(
    @HolidayId int
)
AS
    SET NOCOUNT ON

    SELECT HolidayId, HolidayName, HolidayDate, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM Holiday
     WHERE HolidayId = @HolidayId

    RETURN
