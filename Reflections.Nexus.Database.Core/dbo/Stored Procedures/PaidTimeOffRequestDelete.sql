

CREATE PROCEDURE [dbo].[PaidTimeOffRequestDelete]
(
    @PaidTimeOffRequestId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM PaidTimeOffRequest
     WHERE PaidTimeOffRequestId = @PaidTimeOffRequestId

    RETURN

