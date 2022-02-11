CREATE TABLE [dbo].[aspnet_Roles]
(
[ApplicationId] [uniqueidentifier] NOT NULL,
[RoleId] [uniqueidentifier] NOT NULL CONSTRAINT [DF__aspnet_Ro__RoleI__33D4B598] DEFAULT (newid()),
[RoleName] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[LoweredRoleName] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Description] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [dbo].[aspnet_Roles] ADD CONSTRAINT [PK__aspnet_Roles__31EC6D26] PRIMARY KEY NONCLUSTERED  ([RoleId])
GO
CREATE UNIQUE CLUSTERED INDEX [aspnet_Roles_index1] ON [dbo].[aspnet_Roles] ([ApplicationId], [LoweredRoleName])
GO
ALTER TABLE [dbo].[aspnet_Roles] ADD CONSTRAINT [FK__aspnet_Ro__Appli__440B1D61] FOREIGN KEY ([ApplicationId]) REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
