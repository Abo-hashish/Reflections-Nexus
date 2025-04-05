CREATE TABLE [dbo].[Role] (
    [RoleId]     INT          IDENTITY (1, 1) NOT NULL,
    [RoleName]   VARCHAR (50) NOT NULL,
    [Created]    DATETIME     CONSTRAINT [DF_Role_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]  INT          NOT NULL,
    [Updated]    DATETIME     CONSTRAINT [DF_Role_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]  INT          NOT NULL,
    [RowVersion] ROWVERSION   NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([RoleId] ASC),
    CONSTRAINT [IX_Role] UNIQUE NONCLUSTERED ([RoleName] ASC)
);

