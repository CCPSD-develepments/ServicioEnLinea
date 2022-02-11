SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[sp_admin_DeleteTheme] 
(
	@ThemeId int
)
AS
SET NOCOUNT ON;
DELETE FROM site_Themes
WHERE        (ThemeId = @ThemeId)
GO
