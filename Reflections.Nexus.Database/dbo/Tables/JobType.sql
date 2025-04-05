CREATE TABLE [dbo].[JobType] (
    [Id]   INT          IDENTITY(1,1) NOT NULL,
    [Value] NVARCHAR (50) UNIQUE NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

