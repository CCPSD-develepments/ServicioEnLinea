SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[sp_admin_SetMasterPage] 
(
	@ThemeId int
)
AS
SET NOCOUNT ON;
BEGIN
UPDATE       site_Themes
SET                IsEnabled = 0
WHERE        (IsEnabled = 1) AND (ThemeCategory = N'admin')
UPDATE       site_Themes
SET                IsEnabled = 1
WHERE        (ThemeId = @ThemeId)
END
GO
