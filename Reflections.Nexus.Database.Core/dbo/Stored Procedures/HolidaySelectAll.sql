CREATE PROCEDURE [dbo].[HolidaySelectAll]
AS
    SET NOCOUNT ON

    SELECT HolidayId, HolidayName, HolidayDate, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM Holiday
  ORDER BY HolidayDate

    RETURN
