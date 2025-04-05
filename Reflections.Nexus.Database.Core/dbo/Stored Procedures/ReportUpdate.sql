

CREATE PROCEDURE [dbo].[ReportUpdate]
(
    @ReportId  int, 
    @ReportName  varchar(50), 
    @FileName  varchar(255), 
    @ObjectName  varchar(255), 
    @Description  varchar(255), 
    @SubReportObjectName  varchar(255), 
    @SubReportMethodName  varchar(50), 
    @UpdatedBy  int, 
    @RowVersion  timestamp
)
AS
    SET NOCOUNT ON

    UPDATE Report
       SET 
           ReportName = @ReportName, 
           FileName = @FileName, 
           ObjectName = @ObjectName, 
           Description = @Description, 
           SubReportObjectName = @SubReportObjectName, 
           SubReportMethodName = @SubReportMethodName, 
           Updated = GetDate(), 
           UpdatedBy = @UpdatedBy
     WHERE ReportId = @ReportId
       AND RowVersion = @RowVersion

    RETURN @@ROWCOUNT

