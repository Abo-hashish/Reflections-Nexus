

CREATE PROCEDURE [dbo].[PaidTimeOffRequestTypeSelectById]
(
    @PaidTimeOffRequestTypeId int
)
AS
    SET NOCOUNT ON

    SELECT PaidTimeOffRequestTypeId, PaidTimeOffRequestTypeName, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM PaidTimeOffRequestType
     WHERE PaidTimeOffRequestTypeId = @PaidTimeOffRequestTypeId

    RETURN
