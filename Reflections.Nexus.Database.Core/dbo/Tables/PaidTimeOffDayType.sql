CREATE TABLE [dbo].[PaidTimeOffDayType] (
    [PaidTimeOffDayTypeId]   INT          IDENTITY (1, 1) NOT NULL,
    [PaidTimeOffDayTypeName] VARCHAR (50) NOT NULL,
    [Created]                DATETIME     CONSTRAINT [DF_PaidTimeOffDayType_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]              INT          NOT NULL,
    [Updated]                DATETIME     CONSTRAINT [DF_PaidTimeOffDayType_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]              INT          NOT NULL,
    [RowVersion]             ROWVERSION   NOT NULL,
    CONSTRAINT [PK_PaidTimeOffDayType] PRIMARY KEY CLUSTERED ([PaidTimeOffDayTypeId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PaidTimeOffDayType]
    ON [dbo].[PaidTimeOffDayType]([PaidTimeOffDayTypeName] ASC);

