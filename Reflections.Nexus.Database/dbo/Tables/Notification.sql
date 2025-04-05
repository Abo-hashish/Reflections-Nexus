CREATE TABLE [dbo].[Notification] (
    [Id]         INT      IDENTITY(1,1)  NOT NULL,
    [Seen]     BIT NOT NULL,
    [Message]     NTEXT NOT NULL,
    [Created]    DATETIME       NOT NULL,
    [Updated]    DATETIME       NOT NULL, 
    CONSTRAINT [PK_Activities] PRIMARY KEY CLUSTERED ([id] ASC)
);

