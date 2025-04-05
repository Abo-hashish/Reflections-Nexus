

CREATE PROCEDURE [dbo].[ReportInsert]
(
    @ReportId  int OUTPUT, 
    @ReportName  varchar(50), 
    @FileName  varchar(255), 
    @ObjectName  varchar(255), 
    @Description  varchar(255), 
    @SubReportObjectName  varchar(255), 
    @SubReportMethodName  varchar(50), 
    @CreatedBy  int
)
AS
    SET NOCOUNT ON

    INSERT INTO Report (ReportName, FileName, ObjectName, Description, SubReportObjectName, SubReportMethodName, Created, CreatedBy, Updated, UpdatedBy)
         VALUES (
                @ReportName, 
                @FileName, 
                @ObjectName, 
                @Description, 
                @SubReportObjectName, 
                @SubReportMethodName, 
                GetDate(), 
                @CreatedBy, 
                GetDate(), 
                @CreatedBy
                )
    SET @ReportId = Scope_Identity()

    RETURN

