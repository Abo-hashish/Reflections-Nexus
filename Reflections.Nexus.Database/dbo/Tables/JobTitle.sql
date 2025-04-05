CREATE TABLE [dbo].[JobTitle] (
    [Id]           INT          IDENTITY(1,1)  NOT NULL,
    [Name]         NVARCHAR (100) NOT NULL,
    [DepartmentId] INT            NOT NULL,
    [IsActive]     BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_JobTitle_Department] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department] ([Id]) ON UPDATE CASCADE
);

