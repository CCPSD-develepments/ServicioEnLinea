SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[sp_admin_SelectMasterPage]
AS
	SET NOCOUNT ON;
SELECT        ThemeUrl 
FROM            site_Themes
WHERE        (IsEnabled = 1) AND (ThemeCategory = N'admin')
GO
