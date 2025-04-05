CREATE TABLE [dbo].[MenuItem] (
    [MenuItemId]       INT           IDENTITY (1, 1) NOT NULL,
    [MenuItemName]     VARCHAR (50)  NOT NULL,
    [Description]      VARCHAR (MAX) NULL,
    [Url]              VARCHAR (MAX) NULL,
    [ParentMenuItemId] INT           NULL,
    [DisplaySequence]  TINYINT       CONSTRAINT [DF_MenuItem_DisplaySequence] DEFAULT ((0)) NOT NULL,
    [IsAlwaysEnabled]  BIT           CONSTRAINT [DF_MenuItem_IsAlwaysEnabled] DEFAULT ((0)) NOT NULL,
    [Created]          DATETIME      CONSTRAINT [DF_MenuItem_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]        INT           NOT NULL,
    [Updated]          DATETIME      CONSTRAINT [DF_MenuItem_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]        INT           NOT NULL,
    [RowVersion]       ROWVERSION    NOT NULL,
    CONSTRAINT [PK_MenuItem] PRIMARY KEY CLUSTERED ([MenuItemId] ASC),
    CONSTRAINT [FK_MenuItem_MenuItem] FOREIGN KEY ([ParentMenuItemId]) REFERENCES [dbo].[MenuItem] ([MenuItemId]),
    CONSTRAINT [IX_MenuItem] UNIQUE NONCLUSTERED ([MenuItemName] ASC)
);

