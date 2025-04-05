

CREATE PROCEDURE [dbo].[ReportSelectById]
(
    @ReportId int
)
AS
    SET NOCOUNT ON

    SELECT ReportId, ReportName, FileName, ObjectName, Description, SubReportObjectName, SubReportMethodName, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM Report
     WHERE ReportId = @ReportId

    RETURN
