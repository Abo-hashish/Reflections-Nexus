CREATE TABLE [dbo].[EmployeeTelephoneNumber] (
    [Id]        INT         IDENTITY(1,1)  NOT NULL,
    [IsPrimary] BIT           NOT NULL,
    [Number]    NVARCHAR (20) UNIQUE NOT NULL,
    [EmployeeId] INT NOT NULL,
    [TypeId] INT NOT NULL,
    [Created]    DATETIME       NOT NULL,
    [CreatedBy]  INT  NOT NULL,
    [Updated]    DATETIME       NOT NULL,
    [UpdatedBy]  INT  NOT NULL,
    [RowVersion] TIMESTAMP NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PhoneNumber_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [FK_EmployeeTelephoneNumber_PhoneNumberType] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[PhoneNumberType] ([ID]) ON UPDATE CASCADE,
);

