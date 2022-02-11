CREATE TABLE [dbo].[ActivityLog]
(
[ActivityLogID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ActivityLog_ActivityLogID] DEFAULT (newid()),
[UserId] [uniqueidentifier] NOT NULL,
[Activity] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[PageUrl] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ActivityDate] [datetime] NOT NULL,
[IpAddress] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [dbo].[ActivityLog] ADD CONSTRAINT [PK_ActivityLog] PRIMARY KEY NONCLUSTERED  ([ActivityLogID])
GO
ALTER TABLE [dbo].[ActivityLog] ADD CONSTRAINT [FK_ActivityLog_aspnet_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
