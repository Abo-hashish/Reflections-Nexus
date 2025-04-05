CREATE TABLE [dbo].[PaidTimeOffRequest] (
    [PaidTimeOffRequestId]     INT        IDENTITY (1, 1) NOT NULL,
    [UserAccountId]            INT        NOT NULL,
    [RequestDate]              DATETIME   NOT NULL,
    [PaidTimeOffDayTypeId]     INT        NOT NULL,
    [PaidTimeOffRequestTypeId] INT        NOT NULL,
    [Cancelled]                BIT        CONSTRAINT [DF_PaidTimeOffRequest_Cancelled] DEFAULT ((0)) NOT NULL,
    [Created]                  DATETIME   CONSTRAINT [DF_PaidTimeOffRequest_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]                INT        NOT NULL,
    [Updated]                  DATETIME   CONSTRAINT [DF_PaidTimeOffRequest_Updated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]                INT        NOT NULL,
    [RowVersion]               ROWVERSION NOT NULL,
    CONSTRAINT [PK_PaidTimeOffRequest] PRIMARY KEY CLUSTERED ([PaidTimeOffRequestId] ASC),
    CONSTRAINT [FK_PaidTimeOffRequest_PaidTimeOffDayType] FOREIGN KEY ([PaidTimeOffDayTypeId]) REFERENCES [dbo].[PaidTimeOffDayType] ([PaidTimeOffDayTypeId]),
    CONSTRAINT [FK_PaidTimeOffRequest_PaidTimeOffRequestType] FOREIGN KEY ([PaidTimeOffRequestTypeId]) REFERENCES [dbo].[PaidTimeOffRequestType] ([PaidTimeOffRequestTypeId]),
    CONSTRAINT [FK_PaidTimeOffRequest_UserAccount] FOREIGN KEY ([UserAccountId]) REFERENCES [dbo].[UserAccount] ([UserAccountId])
);

