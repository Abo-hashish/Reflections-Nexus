CREATE TABLE [dbo].[Country] (
    [Id]       INT           IDENTITY(1,1) NOT NULL,
    [Name]     NVARCHAR (50) UNIQUE NOT NULL,
    [IsActive] BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

