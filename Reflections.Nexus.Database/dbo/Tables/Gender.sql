CREATE TABLE [dbo].[Gender] (
    [Id]   INT       IDENTITY(1,1)   NOT NULL,
    [Value] NVARCHAR (6) UNIQUE NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

