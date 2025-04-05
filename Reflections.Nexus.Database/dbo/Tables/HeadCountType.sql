CREATE TABLE [dbo].[HeadCountType] (
    [Id]   INT      IDENTITY(1,1)  NOT NULL,
    [Value] NVARCHAR(50) UNIQUE NOT NULL,
    CONSTRAINT [PK_HeadCountType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

