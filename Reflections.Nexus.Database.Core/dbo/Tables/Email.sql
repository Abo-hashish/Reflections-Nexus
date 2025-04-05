CREATE TABLE [dbo].[Email] (
    [EmailId]          INT           IDENTITY (1, 1) NOT NULL,
    [ToEmailAddress]   VARCHAR (MAX) NOT NULL,
    [CCEmailAddress]   VARCHAR (MAX) NULL,
    [BCCEmailAddress]  VARCHAR (MAX) NULL,
    [FromEmailAddress] VARCHAR (255) NOT NULL,
    [Subject]          VARCHAR (MAX) NOT NULL,
    [Body]             VARCHAR (MAX) NOT NULL,
    [EmailStatusFlag]  TINYINT       NOT NULL,
    [Created]          DATETIME      CONSTRAINT [DF_Email_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]        INT           NOT NULL,
    [Updated]          DATETIME      CONSTRAINT [DF_Email_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]        INT           NOT NULL,
    [RowVersion]       ROWVERSION    NOT NULL,
    CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED ([EmailId] ASC)
);

