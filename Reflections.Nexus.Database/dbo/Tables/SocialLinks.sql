CREATE TABLE [dbo].[SocialLinks] (
    [Id]           INT         IDENTITY(1,1)   NOT NULL,
    [CompanyId]    INT            NOT NULL,
    [SocialTypeId] INT            NOT NULL,
    [Url]          NVARCHAR (255) UNIQUE NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SocialLinks_Company] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([ID]) ON UPDATE CASCADE,
    CONSTRAINT [FK_SocialLinks_SocialLinkType] FOREIGN KEY ([SocialTypeId]) REFERENCES [dbo].[SocialLinkType] ([Id]) ON UPDATE CASCADE
);

