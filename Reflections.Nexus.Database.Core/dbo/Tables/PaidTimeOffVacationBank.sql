CREATE TABLE [dbo].[PaidTimeOffVacationBank] (
    [PaidTimeOffVacationBankId] INT        IDENTITY (1, 1) NOT NULL,
    [UserAccountId]             INT        NOT NULL,
    [VacationYear]              SMALLINT   NOT NULL,
    [PersonalDays]              TINYINT    NOT NULL,
    [VacationDays]              TINYINT    NOT NULL,
    [Created]                   DATETIME   CONSTRAINT [DF_PaidTimeOffVacationBank_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]                 INT        NOT NULL,
    [Updated]                   DATETIME   CONSTRAINT [DF_PaidTimeOffVacationBank_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]                 INT        NOT NULL,
    [RowVersion]                ROWVERSION NOT NULL,
    CONSTRAINT [PK_PaidTimeOffVacationBank] PRIMARY KEY CLUSTERED ([PaidTimeOffVacationBankId] ASC),
    CONSTRAINT [FK_PaidTimeOffVacationBank_UserAccount] FOREIGN KEY ([UserAccountId]) REFERENCES [dbo].[UserAccount] ([UserAccountId])
);


GO
CREATE NONCLUSTERED INDEX [IX_PaidTimeOffVacationBank]
    ON [dbo].[PaidTimeOffVacationBank]([UserAccountId] ASC, [VacationYear] ASC);

