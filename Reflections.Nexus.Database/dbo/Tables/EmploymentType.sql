CREATE TABLE [dbo].[EmploymentType] (
    [Id]    INT        IDENTITY(1,1)   NOT NULL,
    [Value] NVARCHAR (50) UNIQUE NOT NULL,
    CONSTRAINT [PK_EmploymentType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

