SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[sp_wsat_GetUsersByIsLockedOut]
( 
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
						LastActivityDate 
						
				FROM 
					(
						SELECT 	ROW_NUMBER() OVER (ORDER BY aspnet_Users.UserName DESC) AS RowNumber, 
								aspnet_Users.UserName, 
								aspnet_Membership.Email, 
								aspnet_Membership.IsApproved, 
								aspnet_Membership.IsLockedOut, 
								aspnet_Membership.CreateDate, 
								aspnet_Membership.LastLoginDate, 
								aspnet_Users.LastActivityDate 
						FROM	aspnet_Membership 
						INNER   JOIN aspnet_Users 
						ON		aspnet_Membership.UserId = aspnet_Users.UserId 
						WHERE	(aspnet_Membership.IsLockedOut = 1)
					 ) as u
				WHERE	u.RowNumber > @startRowIndex 
				AND		u.RowNumber <= (@startRowIndex + @maximumRows) 

END
GO
