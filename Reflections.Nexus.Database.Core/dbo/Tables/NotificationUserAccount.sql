CREATE TABLE [dbo].[NotificationUserAccount] (
    [NotificationUserAccountId] INT        IDENTITY (1, 1) NOT NULL,
    [NotificationId]            INT        NOT NULL,
    [UserAccountId]             INT        NOT NULL,
    [Created]                   DATETIME   CONSTRAINT [DF_NotificationUserAccountId_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]                 INT        NOT NULL,
    [Updated]                   DATETIME   CONSTRAINT [DF_NotificationUserAccountId_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]                 INT        NOT NULL,
    [RowVersion]                ROWVERSION NOT NULL,
    CONSTRAINT [PK_NotificationUserAccountId] PRIMARY KEY CLUSTERED ([NotificationUserAccountId] ASC),
    CONSTRAINT [FK_NotificationUserAccount_Notification] FOREIGN KEY ([NotificationId]) REFERENCES [dbo].[Notification] ([NotificationId]),
    CONSTRAINT [FK_NotificationUserAccount_UserAccount] FOREIGN KEY ([UserAccountId]) REFERENCES [dbo].[UserAccount] ([UserAccountId])
);

