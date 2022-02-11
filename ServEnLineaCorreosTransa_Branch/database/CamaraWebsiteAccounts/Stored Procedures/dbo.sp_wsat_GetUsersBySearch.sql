SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[sp_wsat_GetUsersBySearch]
(
	@Email nvarchar(256),
	@UserName nvarchar(256), 
	@startRowIndex INT,
	@maximumRows INT
) 
AS 
BEGIN

SELECT 
		RowNumber, 
		Email, 
		UserName, 
		IsApproved, 
		IsLockedOut, 
		CreateDate, 
		LastLoginDate, 
		LastActivityDate 
						
FROM 
	(
		SELECT 	ROW_NUMBER() OVER (ORDER BY aspnet_Users.UserName DESC) AS RowNumber, 
				aspnet_Membership.Email, 
				aspnet_Users.UserName, 
				aspnet_Membership.IsApproved, 
				aspnet_Membership.IsLockedOut, 
				aspnet_Membership.CreateDate, 
				aspnet_Membership.LastLoginDate, 
				aspnet_Users.LastActivityDate 
		FROM	aspnet_Membership 
		INNER   JOIN aspnet_Users 
		ON		aspnet_Membership.UserId = aspnet_Users.UserId 
		WHERE	(aspnet_Membership.Email LIKE N'%' + @Email + N'%') OR
				(aspnet_Users.UserName LIKE N'%' + @UserName + N'%') OR
				(aspnet_Membership.Email LIKE N'%' + @Email + N'%') AND (aspnet_Users.UserName LIKE N'%' + @UserName + N'%')
		) as u
WHERE	u.RowNumber > @startRowIndex 
AND		u.RowNumber <= (@startRowIndex + @maximumRows) 

END
GO
