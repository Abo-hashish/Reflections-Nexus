CREATE TABLE [dbo].[RoleUserAccount] (
    [RoleUserAccountId] INT        IDENTITY (1, 1) NOT NULL,
    [RoleId]            INT        NOT NULL,
    [UserAccountId]     INT        NOT NULL,
    [Created]           DATETIME   CONSTRAINT [DF_RoleUserAccount_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]         INT        NOT NULL,
    [Updated]           DATETIME   CONSTRAINT [DF_RoleUserAccount_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]         INT        NOT NULL,
    [RowVersion]        ROWVERSION NOT NULL,
    CONSTRAINT [PK_RoleUserAccount] PRIMARY KEY CLUSTERED ([RoleUserAccountId] ASC),
    CONSTRAINT [FK_RoleUserAccount_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId]) ON DELETE CASCADE,
    CONSTRAINT [FK_RoleUserAccount_UserAccount] FOREIGN KEY ([UserAccountId]) REFERENCES [dbo].[UserAccount] ([UserAccountId]),
    CONSTRAINT [IX_RoleUserAccount] UNIQUE NONCLUSTERED ([RoleId] ASC, [UserAccountId] ASC)
);

