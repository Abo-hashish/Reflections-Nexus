﻿CREATE TABLE [dbo].[RequestStatus]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Value] NVARCHAR(20) UNIQUE NOT NULL
)
