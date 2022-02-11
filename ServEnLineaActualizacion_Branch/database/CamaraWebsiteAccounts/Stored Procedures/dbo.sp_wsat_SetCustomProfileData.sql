SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE dbo.sp_wsat_SetCustomProfileData
    @ApplicationName      nvarchar(256),
    @UserName             nvarchar(256),
	@IsUserAnonymous	  bit,
	@FirstName			  nvarchar(50),
	@LastName			  nvarchar(50) 
as

declare	@ApplicationId uniqueidentifier
set		@ApplicationId = NULL

declare @CurrentUtcDate datetime
set     @CurrentUtcDate = getutcdate()

--Get the appid
exec dbo.aspnet_Applications_CreateApplication @ApplicationName, @ApplicationId OUTPUT

--Create user if needed
declare @UserId uniqueidentifier

select	@UserId = UserId
from	dbo.vw_aspnet_Users
where	ApplicationId	= @ApplicationId
and		LoweredUserName = LOWER(@UserName)

if(@UserId IS NULL)
	exec dbo.aspnet_Users_CreateUser @ApplicationId, @UserName, @IsUserAnonymous, @CurrentUtcDate, @UserId OUTPUT

--Either insert a new row of data, or update a pre-existing row
if exists (select 1 from dbo.aspnet_CustomProfile where UserId = @UserId) 
BEGIN 
	update dbo.aspnet_CustomProfile
	set	FirstName		= @FirstName,
		LastName		= @LastName,
		LastUpdatedDate	= @CurrentUtcDate
	where UserId = @UserId
END
else
BEGIN
	insert dbo.aspnet_CustomProfile (UserId, FirstName, LastName, LastUpdatedDate)
    values (@UserId, @FirstName, @LastName, @CurrentUtcDate)
END
GO
