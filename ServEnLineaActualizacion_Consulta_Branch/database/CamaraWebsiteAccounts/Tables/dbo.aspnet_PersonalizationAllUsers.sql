CREATE TABLE [dbo].[aspnet_PersonalizationAllUsers]
(
[PathId] [uniqueidentifier] NOT NULL,
[PageSettings] [image] NOT NULL,
[LastUpdatedDate] [datetime] NOT NULL
)
GO
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers] ADD CONSTRAINT [PK__aspnet_Personali__4AB81AF0] PRIMARY KEY CLUSTERED  ([PathId])
GO
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers] ADD CONSTRAINT [FK__aspnet_Pe__PathI__4BAC3F29] FOREIGN KEY ([PathId]) REFERENCES [dbo].[aspnet_Paths] ([PathId])
GO
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers] ADD CONSTRAINT [FK__aspnet_Pe__PathI__540C7B00] FOREIGN KEY ([PathId]) REFERENCES [dbo].[aspnet_Paths] ([PathId])
GO
