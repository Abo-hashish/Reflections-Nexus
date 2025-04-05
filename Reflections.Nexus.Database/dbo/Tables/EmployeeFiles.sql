CREATE TABLE [dbo].[EmployeeFiles] (
    [Id]         INT           IDENTITY(1,1) NOT NULL,
    [FileTypeId] INT            NOT NULL,
    [EmployeeId] INT            NOT NULL,
    [FileURL]        NVARCHAR (200) UNIQUE NOT NULL,
    [Created]    DATETIME       NOT NULL,
    [CreatedBy]  INT  NOT NULL,
    [Updated]    DATETIME       NOT NULL,
    [UpdatedBy]  INT  NOT NULL,
    [RowVersion] TIMESTAMP NOT NULL, 
    CONSTRAINT [PK__Employee__3214EC27C74AC7F2] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EmployeeFiles_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [FK_EmployeeFiles_EmployeeFileType] FOREIGN KEY ([FileTypeId]) REFERENCES [dbo].[EmployeeFileType] ([Id]) ON UPDATE CASCADE
);

