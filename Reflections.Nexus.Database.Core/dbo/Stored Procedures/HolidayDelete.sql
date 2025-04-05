

CREATE PROCEDURE [dbo].[HolidayDelete]
(
    @HolidayId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM Holiday
     WHERE HolidayId = @HolidayId

    RETURN

