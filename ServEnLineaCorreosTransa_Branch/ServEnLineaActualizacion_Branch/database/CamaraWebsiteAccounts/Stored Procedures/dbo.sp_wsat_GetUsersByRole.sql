SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[sp_wsat_GetUsersByRole]
(
	@RoleName nvarchar(256), 
	@startRowIndex INT,
	@maximumRows INT
) 
AS 
BEGIN

				SELECT 
						RowNumber, 
						UserName, 
						Email, 
						IsApproved, 
						IsLockedOut, 
						CreateDate, 
						LastLoginDate, 
						LastActivityDate,
						RoleName 
				FROM 
					(
						SELECT 	ROW_NUMBER() OVER (ORDER BY aspnet_Users.UserName DESC) AS RowNumber, 
								aspnet_Users.UserName, 
								aspnet_Membership.Email, 
								aspnet_Membership.IsApproved, 
								aspnet_Membership.IsLockedOut, 
								aspnet_Membership.CreateDate, 
								aspnet_Membership.LastLoginDate, 
								aspnet_Users.LastActivityDate,
								aspnet_Roles.RoleName 
						FROM	aspnet_Membership 
						INNER   JOIN aspnet_Users 
						ON aspnet_Membership.UserId = aspnet_Users.UserId AND aspnet_Membership.UserId = aspnet_Users.UserId 
						INNER JOIN aspnet_UsersInRoles 
						ON aspnet_Users.UserId = aspnet_UsersInRoles.UserId AND aspnet_Users.UserId = aspnet_UsersInRoles.UserId 
						INNER JOIN aspnet_Roles 
						ON aspnet_UsersInRoles.RoleId = aspnet_Roles.RoleId AND aspnet_UsersInRoles.RoleId = aspnet_Roles.RoleId 
						WHERE	aspnet_Roles.RoleName = @RoleName
					 ) as u
				WHERE	u.RowNumber > @startRowIndex 
				AND		u.RowNumber <= (@startRowIndex + @maximumRows) 

END
GO
