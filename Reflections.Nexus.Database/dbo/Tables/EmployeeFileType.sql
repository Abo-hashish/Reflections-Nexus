CREATE TABLE [dbo].[EmployeeFileType] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Value] NVARCHAR (50) UNIQUE NOT NULL,
    CONSTRAINT [PK_EmployeeFileType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

