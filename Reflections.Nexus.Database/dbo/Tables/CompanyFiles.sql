CREATE TABLE [dbo].[CompanyFiles] (
    [Id]         INT           IDENTITY(1,1) NOT NULL,
    [FileTypeId] INT            NOT NULL,
    [URL]        NVARCHAR (255) UNIQUE NOT NULL,
    [CompanyId]  INT            NOT NULL,
    [Created]    DATETIME       NOT NULL,
    [CreatedBy]  INT  NOT NULL,
    [Updated]    DATETIME       NOT NULL,
    [UpdatedBy]  INT  NOT NULL,
    [RowVersion] TIMESTAMP NOT NULL, 
    CONSTRAINT [PK__CompanyF__3214EC074A53B7CC] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CompanyFiles_Company] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([ID]) ON UPDATE CASCADE,
    CONSTRAINT [FK_CompanyFiles_CompanyFileType] FOREIGN KEY ([FileTypeId]) REFERENCES [dbo].[CompanyFileType] ([Id]) ON UPDATE CASCADE
);

