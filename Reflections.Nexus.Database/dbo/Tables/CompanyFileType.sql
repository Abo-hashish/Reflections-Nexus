CREATE TABLE [dbo].[CompanyFileType] (
    [Id]    INT        IDENTITY (1, 1) NOT NULL,
    [Value] NVARCHAR(50) NOT NULL,
    CONSTRAINT [PK_CompanyFileType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

