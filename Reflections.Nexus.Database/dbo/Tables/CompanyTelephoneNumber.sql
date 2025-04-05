CREATE TABLE [dbo].[CompanyTelephoneNumber] (
    [Id]          INT         IDENTITY(1,1)  NOT NULL,
    CompanyId INT NOT NULL,
    [PhoneNumber] NVARCHAR (20) UNIQUE NOT NULL,
    [TypeId]        INT    NOT NULL,
    [IsPrimary]   BIT           NOT NULL,
        [Created]    DATETIME       NOT NULL,
    [CreatedBy]  INT  NOT NULL,
    [Updated]    DATETIME       NOT NULL,
    [UpdatedBy]  INT  NOT NULL,
    [RowVersion] TIMESTAMP NOT NULL, 
    CONSTRAINT [PK_CompanyTelephoneNumber] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CompanyTelephoneNumber_PhoneNumberType] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[PhoneNumberType] ([ID]) ON UPDATE CASCADE,
    CONSTRAINT [FK_CompanyTelephoneNumber_Company] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([ID]) ON UPDATE CASCADE
);

