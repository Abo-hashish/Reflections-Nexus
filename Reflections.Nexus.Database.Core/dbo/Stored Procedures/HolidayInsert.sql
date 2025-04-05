

CREATE PROCEDURE [dbo].[HolidayInsert]
(
    @HolidayId  int OUTPUT, 
    @HolidayName  varchar(50), 
    @HolidayDate  datetime, 
    @CreatedBy  int
)
AS
    SET NOCOUNT ON

    INSERT INTO Holiday (HolidayName, HolidayDate, Created, CreatedBy, Updated, UpdatedBy)
         VALUES (
                @HolidayName, 
                @HolidayDate, 
                GetDate(), 
                @CreatedBy, 
                GetDate(), 
                @CreatedBy
                )
    SET @HolidayId = Scope_Identity()

    RETURN

