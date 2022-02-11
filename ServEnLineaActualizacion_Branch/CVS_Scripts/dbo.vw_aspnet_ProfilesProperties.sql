USE [CamaraWebsiteAccounts]

GO
ALTER VIEW [dbo].[vw_aspnet_ProfilesProperties]
AS
SELECT     dbo.aspnet_Users.UserId, dbo.fn_GetProfileElement(N'TipoDocumento', dbo.aspnet_Profile.PropertyNames, dbo.aspnet_Profile.PropertyValuesString) 
                      AS TipoDocumento, dbo.fn_GetProfileElement(N'NumeroDocumento', dbo.aspnet_Profile.PropertyNames, dbo.aspnet_Profile.PropertyValuesString) 
                      AS NumeroDocumento, dbo.fn_GetProfileElement(N'NombreSolicitante', dbo.aspnet_Profile.PropertyNames, dbo.aspnet_Profile.PropertyValuesString) 
                      AS NombreSolicitante, dbo.aspnet_Profile.LastUpdatedDate, dbo.aspnet_Users.UserName, dbo.fn_GetProfileElement(N'UsuarioPadre', 
                      dbo.aspnet_Profile.PropertyNames, dbo.aspnet_Profile.PropertyValuesString) AS UsuarioPadre, dbo.aspnet_Membership.Email, dbo.aspnet_Membership.IsApproved, 
                      dbo.fn_GetProfileElement(N'PasswordResetKey', dbo.aspnet_Profile.PropertyNames, dbo.aspnet_Profile.PropertyValuesString) AS PasswordResetKey, 
                      dbo.fn_GetProfileElement(N'ActivateUserKey', dbo.aspnet_Profile.PropertyNames, dbo.aspnet_Profile.PropertyValuesString) AS ActivateUserKey, 
                      dbo.fn_GetProfileElement(N'IsActive', dbo.aspnet_Profile.PropertyNames, dbo.aspnet_Profile.PropertyValuesString) AS IsActive, 
                      dbo.fn_GetProfileElement(N'NombreEmpresa', dbo.aspnet_Profile.PropertyNames, dbo.aspnet_Profile.PropertyValuesString) AS NombreEmpresa, 
                      dbo.fn_GetProfileElement(N'RNC', dbo.aspnet_Profile.PropertyNames, dbo.aspnet_Profile.PropertyValuesString) AS RNC, 
                      dbo.fn_GetProfileElement(N'ContratoFirmado', dbo.aspnet_Profile.PropertyNames, dbo.aspnet_Profile.PropertyValuesString) AS ContratoFirmado, 
                      dbo.fn_GetProfileElement(N'IpFirma', dbo.aspnet_Profile.PropertyNames, dbo.aspnet_Profile.PropertyValuesString) AS IpFirma, dbo.fn_GetProfileElement(N'Phone', dbo.aspnet_Profile.PropertyNames, dbo.aspnet_Profile.PropertyValuesString) AS 'Phone', dbo.fn_GetProfileElement(N'Extension', dbo.aspnet_Profile.PropertyNames, dbo.aspnet_Profile.PropertyValuesString) AS 'Extension'
FROM         dbo.aspnet_Profile INNER JOIN
                      dbo.aspnet_Membership ON dbo.aspnet_Profile.UserId = dbo.aspnet_Membership.UserId INNER JOIN
                      dbo.aspnet_Users ON dbo.aspnet_Membership.UserId = dbo.aspnet_Users.UserId
GO


