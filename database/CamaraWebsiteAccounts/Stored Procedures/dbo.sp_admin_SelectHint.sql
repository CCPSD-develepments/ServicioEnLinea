SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[sp_admin_SelectHint]
(
	@helpid int
)
AS
	SET NOCOUNT ON;
SELECT        helpId, HintUrl, HintName, HintCategory
FROM            admin_Hints
WHERE        (helpId = @helpid)
GO
