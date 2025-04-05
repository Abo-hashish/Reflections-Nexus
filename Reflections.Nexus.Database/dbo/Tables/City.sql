CREATE TABLE [dbo].[City] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (100) NOT NULL,
    [CountryId] INT            NOT NULL,
    [IsActive]  BIT            NOT NULL,
    CONSTRAINT [PK__City__3214EC276A5C1E8A] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_City_Country] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Country] ([ID]) ON UPDATE CASCADE
);

