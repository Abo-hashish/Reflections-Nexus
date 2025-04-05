CREATE PROCEDURE [dbo].[PaidTimeOffDayTypeSelectAll]
AS
    SET NOCOUNT ON

    SELECT PaidTimeOffDayTypeId, PaidTimeOffDayTypeName, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM PaidTimeOffDayType

    RETURN
