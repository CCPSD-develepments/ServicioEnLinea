CREATE TABLE [dbo].[aspnet_PersonalizationPerUser]
(
[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__aspnet_Perso__Id__4E88ABD4] DEFAULT (newid()),
[PathId] [uniqueidentifier] NULL,
[UserId] [uniqueidentifier] NULL,
[PageSettings] [image] NOT NULL,
[LastUpdatedDate] [datetime] NOT NULL
)
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] ADD CONSTRAINT [PK__aspnet_Personali__4D94879B] PRIMARY KEY NONCLUSTERED  ([Id])
GO
CREATE UNIQUE CLUSTERED INDEX [aspnet_PersonalizationPerUser_index1] ON [dbo].[aspnet_PersonalizationPerUser] ([PathId], [UserId])
GO
CREATE UNIQUE NONCLUSTERED INDEX [aspnet_PersonalizationPerUser_ncindex2] ON [dbo].[aspnet_PersonalizationPerUser] ([UserId], [PathId])
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] ADD CONSTRAINT [FK__aspnet_Pe__PathI__4F7CD00D] FOREIGN KEY ([PathId]) REFERENCES [dbo].[aspnet_Paths] ([PathId])
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] ADD CONSTRAINT [FK__aspnet_Pe__PathI__55009F39] FOREIGN KEY ([PathId]) REFERENCES [dbo].[aspnet_Paths] ([PathId])
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] ADD CONSTRAINT [FK__aspnet_Pe__UserI__693CA210] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
