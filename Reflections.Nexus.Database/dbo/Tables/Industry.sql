CREATE TABLE [dbo].[Industry] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Value] NVARCHAR (50) UNIQUE NOT NULL,
    CONSTRAINT [PK__Industry__3214EC27D6683BAD] PRIMARY KEY CLUSTERED ([Id] ASC)
);

