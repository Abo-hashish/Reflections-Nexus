CREATE TABLE [dbo].[HeadCount] (
    [Id]          INT        IDENTITY(1,1)    NOT NULL,
    [Activated]   NVARCHAR (20)  NOT NULL,
    [ActivatedOn] DATETIME       NOT NULL,
    [Notes]       NTEXT NULL,
        [Created]    DATETIME       NOT NULL,
    [CreatedBy]  INT  NOT NULL,
    [Updated]    DATETIME       NOT NULL,
    [UpdatedBy]  INT  NOT NULL,
    [RowVersion] TIMESTAMP NOT NULL, 
    CONSTRAINT [PK__HeadCoun__3214EC2782A3FB9D] PRIMARY KEY CLUSTERED ([Id] ASC)
);

