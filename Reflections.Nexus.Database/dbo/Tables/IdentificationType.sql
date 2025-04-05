CREATE TABLE [dbo].[IdentificationType] (
    [Id]               INT         IDENTITY(1,1)  NOT NULL,
    [Value]             NVARCHAR (50) UNIQUE NOT NULL,
    CONSTRAINT [PK__Identifi__3214EC077151D407] PRIMARY KEY CLUSTERED ([Id] ASC)
);

