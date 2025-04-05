CREATE PROCEDURE [dbo].[ReportSelectAll]
AS
    SET NOCOUNT ON

    SELECT ReportId, ReportName, FileName, ObjectName, Description, SubReportObjectName, SubReportMethodName, Created, CreatedBy, Updated, UpdatedBy, RowVersion
      FROM Report

    RETURN
