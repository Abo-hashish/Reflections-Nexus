CREATE TABLE [dbo].[AccountRole]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [AccountId] INT NOT NULL, 
    [RoleId] INT NOT NULL,
    CONSTRAINT [FK_AccountRole_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([ID]) ON UPDATE CASCADE,
    CONSTRAINT [FK_AccountRole_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([ID]) ON UPDATE CASCADE
)
