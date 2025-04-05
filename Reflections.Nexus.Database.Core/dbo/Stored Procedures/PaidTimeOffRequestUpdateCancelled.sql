

CREATE PROCEDURE [dbo].[PaidTimeOffRequestUpdateCancelled]
(
    @PaidTimeOffRequestId  int, 
    @Cancelled bit    
)
AS
    SET NOCOUNT ON

    UPDATE PaidTimeOffRequest
       SET 
           Cancelled = @Cancelled           
     WHERE PaidTimeOffRequestId = @PaidTimeOffRequestId
       
    

