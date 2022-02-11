CREATE TABLE [dbo].[site_Themes]
(
[ThemeId] [int] NOT NULL IDENTITY(1, 1),
[ThemeUrl] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ThemeThumbUrl] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ThemeName] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ThemeDescription] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ThemeCategory] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsEnabled] [bit] NULL
)
GO
ALTER TABLE [dbo].[site_Themes] ADD CONSTRAINT [PK_site_Themes] PRIMARY KEY CLUSTERED  ([ThemeId])
GO
