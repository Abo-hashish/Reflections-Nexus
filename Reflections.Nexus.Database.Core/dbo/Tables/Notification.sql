CREATE TABLE [dbo].[Notification] (
    [NotificationId]   INT           NOT NULL,
    [Description]      VARCHAR (255) NOT NULL,
    [FromEmailAddress] VARCHAR (100) NOT NULL,
    [Subject]          VARCHAR (MAX) NOT NULL,
    [Body]             VARCHAR (MAX) NOT NULL,
    [Created]          DATETIME      CONSTRAINT [DF_Notification_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]        INT           NOT NULL,
    [Updated]          DATETIME      CONSTRAINT [DF_Notification_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]        INT           NOT NULL,
    [RowVersion]       ROWVERSION    NOT NULL,
    CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED ([NotificationId] ASC)
);

