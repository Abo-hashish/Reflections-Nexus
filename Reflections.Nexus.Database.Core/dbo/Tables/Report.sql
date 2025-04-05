CREATE TABLE [dbo].[Report] (
    [ReportId]            INT           IDENTITY (1, 1) NOT NULL,
    [ReportName]          VARCHAR (50)  NOT NULL,
    [FileName]            VARCHAR (255) NOT NULL,
    [ObjectName]          VARCHAR (255) NOT NULL,
    [Description]         VARCHAR (255) NOT NULL,
    [SubReportObjectName] VARCHAR (255) NULL,
    [SubReportMethodName] VARCHAR (50)  NULL,
    [Created]             DATETIME      CONSTRAINT [DF_Report_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]           INT           NOT NULL,
    [Updated]             DATETIME      CONSTRAINT [DF_Report_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]           INT           NOT NULL,
    [RowVersion]          ROWVERSION    NOT NULL,
    CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED ([ReportId] ASC)
);

