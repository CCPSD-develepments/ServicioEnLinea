CREATE TABLE [dbo].[site_ThemeCss]
(
[CssId] [int] NOT NULL IDENTITY(1, 1),
[CssUrl] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CssName] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CssDescription] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ThemeCategory] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [dbo].[site_ThemeCss] ADD CONSTRAINT [PK_site_ThemeCss] PRIMARY KEY CLUSTERED  ([CssId])
GO
