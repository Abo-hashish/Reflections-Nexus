CREATE TABLE [dbo].[Account] (
    [Id]         INT        IDENTITY(1,1)    NOT NULL,
    [Username]   NVARCHAR (255) UNIQUE NOT NULL,
    [Password]   NVARCHAR (50) NOT NULL,
    [EmployeeId] INT            NULL,
    [RoleTypeId] INT            NOT NULL,
    [Created]    DATETIME       NOT NULL,
    [CreatedBy]  INT  NOT NULL,
    [Updated]    DATETIME       NOT NULL,
    [UpdatedBy]  INT  NOT NULL,
    [RowVersion] TIMESTAMP  NOT NULL,
    CONSTRAINT [PK__AppUser__3214EC075AD6A3C0] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Account_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id]) ON UPDATE CASCADE
);