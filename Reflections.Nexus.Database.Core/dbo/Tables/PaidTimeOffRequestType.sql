CREATE TABLE [dbo].[PaidTimeOffRequestType] (
    [PaidTimeOffRequestTypeId]   INT          IDENTITY (1, 1) NOT NULL,
    [PaidTimeOffRequestTypeName] VARCHAR (50) NOT NULL,
    [Created]                    DATETIME     CONSTRAINT [DF_PaidTimeOffVacationDayType_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]                  INT          NOT NULL,
    [Updated]                    DATETIME     CONSTRAINT [DF_PaidTimeOffVacationDayType_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]                  INT          NOT NULL,
    [RowVersion]                 ROWVERSION   NOT NULL,
    CONSTRAINT [PK_PaidTimeOffVacationDayType] PRIMARY KEY CLUSTERED ([PaidTimeOffRequestTypeId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PaidTimeOffVacationDayType]
    ON [dbo].[PaidTimeOffRequestType]([PaidTimeOffRequestTypeName] ASC);

