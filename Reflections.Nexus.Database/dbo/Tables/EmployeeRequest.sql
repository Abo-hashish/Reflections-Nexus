CREATE TABLE [dbo].[EmployeeRequest] (
    [Id]            INT          IDENTITY(1,1)  NOT NULL,
    [NotificationId]    INT            NOT NULL,
    EmployeeId  INT NOT NULL,
    [StatusId] INT NOT NULL,
    [Notes]         NTEXT NOT NULL,
    [Created]    DATETIME       NOT NULL,
    [CreatedBy]  INT  NOT NULL,
    [Updated]    DATETIME       NOT NULL,
    [UpdatedBy]  INT  NOT NULL,
    [RowVersion] TIMESTAMP NOT NULL, 
    CONSTRAINT [PK_EmployeeRequest] PRIMARY KEY CLUSTERED ([Id] ASC),
    
    
    CONSTRAINT [FK_EmployeeRequest_Notification] FOREIGN KEY ([NotificationId]) REFERENCES [dbo].[Notification] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [FK_EmployeeRequest_RequestStatus] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[RequestStatus] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [FK_EmployeeRequest_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id]) ON UPDATE CASCADE
);

