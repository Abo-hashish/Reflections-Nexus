CREATE TABLE [dbo].[Department] (
    [Id]        INT        IDENTITY(1,1)   NOT NULL,
    [Name]      NVARCHAR (50)  NOT NULL,
    [CompanyId] INT           NOT NULL,
    [ManagerId] INT           ,
    [IsActive]  BIT           NOT NULL,
       [Created]    DATETIME       NOT NULL,
    [CreatedBy]  INT  NOT NULL,
    [Updated]    DATETIME       NOT NULL,
    [UpdatedBy]  INT  NOT NULL,
    [RowVersion] TIMESTAMP NOT NULL, 
    CONSTRAINT [PK__Departme__3214EC0735C0FED9] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Department_Company] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([ID]) ON UPDATE CASCADE,
    CONSTRAINT [FK_Department_Employee] FOREIGN KEY ([ManagerId]) REFERENCES [dbo].[Employee] ([Id])
);

