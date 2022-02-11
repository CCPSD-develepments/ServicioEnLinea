SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[sp_admin_CurrentTheme]
AS
	SET NOCOUNT ON;
SELECT        ThemeId, ThemeUrl, ThemeThumbUrl, ThemeName, ThemeDescription, ThemeCategory, IsEnabled
FROM            site_Themes
WHERE        (ThemeCategory = N'admin') AND (IsEnabled = 1)
GO
