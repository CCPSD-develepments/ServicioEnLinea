CREATE TABLE [dbo].[aspnet_UsersInRoles]
(
[UserId] [uniqueidentifier] NOT NULL,
[RoleId] [uniqueidentifier] NOT NULL
)
GO
ALTER TABLE [dbo].[aspnet_UsersInRoles] ADD CONSTRAINT [PK__aspnet_UsersInRo__35BCFE0A] PRIMARY KEY CLUSTERED  ([UserId], [RoleId])
GO
CREATE NONCLUSTERED INDEX [aspnet_UsersInRoles_index] ON [dbo].[aspnet_UsersInRoles] ([RoleId])
GO
ALTER TABLE [dbo].[aspnet_UsersInRoles] ADD CONSTRAINT [FK__aspnet_Us__RoleI__37A5467C] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[aspnet_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[aspnet_UsersInRoles] ADD CONSTRAINT [FK__aspnet_Us__RoleI__59C55456] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[aspnet_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[aspnet_UsersInRoles] ADD CONSTRAINT [FK__aspnet_Us__UserI__49C3F6B7] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
