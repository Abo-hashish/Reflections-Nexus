CREATE TABLE [dbo].[Holiday] (
    [HolidayId]   INT          IDENTITY (1, 1) NOT NULL,
    [HolidayName] VARCHAR (50) NOT NULL,
    [HolidayDate] DATETIME     NOT NULL,
    [Created]     DATETIME     CONSTRAINT [DF_Holiday_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]   INT          NOT NULL,
    [Updated]     DATETIME     CONSTRAINT [DF_Holiday_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]   INT          NOT NULL,
    [RowVersion]  ROWVERSION   NOT NULL,
    CONSTRAINT [PK_Holiday] PRIMARY KEY CLUSTERED ([HolidayId] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Holiday]
    ON [dbo].[Holiday]([HolidayDate] ASC);

