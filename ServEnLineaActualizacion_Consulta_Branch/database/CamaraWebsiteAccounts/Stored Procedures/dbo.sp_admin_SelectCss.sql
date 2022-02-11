SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[sp_admin_SelectCss]
(
	@cssid int
)
AS
	SET NOCOUNT ON;
SELECT        CssId, CssUrl, CssName, ThemeCategory
FROM            site_ThemeCss
WHERE        (CssId = @cssid)
GO
