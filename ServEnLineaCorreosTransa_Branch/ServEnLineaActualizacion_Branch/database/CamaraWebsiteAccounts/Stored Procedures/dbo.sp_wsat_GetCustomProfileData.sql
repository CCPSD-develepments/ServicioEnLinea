SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE dbo.sp_wsat_GetCustomProfileData
    @ApplicationName      nvarchar(256),
    @UserName             nvarchar(256),
	@FirstName			  nvarchar(50)		OUTPUT,
	@LastName			  nvarchar(50)		OUTPUT 
as

declare	@ApplicationId uniqueidentifier
set		@ApplicationId = NULL

--Get the appid
exec dbo.aspnet_Applications_CreateApplication @ApplicationName, @ApplicationId OUTPUT

--Return data for the requested user in the application
select	@FirstName	= FirstName,
		@LastName	= LastName 
from	dbo.aspnet_CustomProfile pt,
	    dbo.vw_aspnet_Users u
where	u.ApplicationId	= @ApplicationId
and		u.UserName		= @UserName
and		u.UserId		= pt.UserId
GO
