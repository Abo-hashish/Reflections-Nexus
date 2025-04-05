CREATE TABLE [dbo].[UserAccount] (
    [UserAccountId] INT           IDENTITY (2, 1) NOT NULL,
    [AccountName]   VARCHAR (50)  NOT NULL,
    [FirstName]     VARCHAR (50)  NOT NULL,
    [LastName]      VARCHAR (50)  NOT NULL,
    [Email]         VARCHAR (100) NOT NULL,
    [IsActive]      BIT           NOT NULL,
    [Created]       DATETIME      CONSTRAINT [DF_UserAccount_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]     INT           NOT NULL,
    [Updated]       DATETIME      CONSTRAINT [DF_UserAccount_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]     INT           NOT NULL,
    [RowVersion]    ROWVERSION    NOT NULL,
    CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED ([UserAccountId] ASC),
    CONSTRAINT [IX_UserAccount] UNIQUE NONCLUSTERED ([AccountName] ASC)
);

