USE [CamaraWebsiteAccounts]
GO
/****** Object:  StoredProcedure [dbo].[DeleteUserNoAproved]    Script Date: 9/30/2019 11:19:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUserNoAproved]
	@ApplicationName  nvarchar(256)
as
begin
declare @userId TABLE (userID nvarchar(Max))
declare @userNametb TABLE (userName nvarchar(Max))
declare @applicationId nvarchar(256)

select @applicationId = ApplicationId from [CamaraWebsiteAccounts].[dbo].[aspnet_Applications] 
where LoweredApplicationName = LOWER(@ApplicationName)

insert into @userId SELECT UserId FROM [CamaraWebsiteAccounts].[dbo].[aspnet_Membership] 
where DATEDIFF(HOUR,CreateDate,GETDATE()) > 24 and IsApproved = 0 
and ApplicationId = @applicationId

DELETE FROM dbo.aspnet_Membership WHERE UserId in (select userID from @userId)
DELETE FROM dbo.aspnet_UsersInRoles WHERE UserId in (select userID from @userId)
DELETE FROM dbo.aspnet_Profile WHERE UserId in (select userID from @userId)
DELETE FROM dbo.aspnet_Users WHERE UserId in (select userID from @userId)

end