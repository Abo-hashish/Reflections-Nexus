

CREATE PROCEDURE [dbo].[PaidTimeOffDayTypeSelectById]
(
    @PaidTimeOffDayTypeId int
)
AS
    SET NOCOUNT ON

    SELECT PaidTimeOffDayTypeId, PaidTimeOffDayTypeName, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM PaidTimeOffDayType
     WHERE PaidTimeOffDayTypeId = @PaidTimeOffDayTypeId

    RETURN
