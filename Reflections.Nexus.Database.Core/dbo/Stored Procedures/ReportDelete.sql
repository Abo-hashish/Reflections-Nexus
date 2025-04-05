

CREATE PROCEDURE [dbo].[ReportDelete]
(
    @ReportId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM Report
     WHERE ReportId = @ReportId

    RETURN

