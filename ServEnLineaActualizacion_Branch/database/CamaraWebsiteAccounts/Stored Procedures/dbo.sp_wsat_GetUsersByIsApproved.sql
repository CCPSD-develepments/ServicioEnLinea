SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[sp_wsat_GetUsersByIsApproved]
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
						WHERE	(aspnet_Membership.IsApproved = 0)
					 ) as u
				WHERE	u.RowNumber > @startRowIndex 
				AND		u.RowNumber <= (@startRowIndex + @maximumRows) 

END
GO
