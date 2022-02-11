SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW dbo.vw_aspnet_ProfilesProperties
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
                      dbo.fn_GetProfileElement(N'IpFirma', dbo.aspnet_Profile.PropertyNames, dbo.aspnet_Profile.PropertyValuesString) AS IpFirma
FROM         dbo.aspnet_Profile INNER JOIN
                      dbo.aspnet_Membership ON dbo.aspnet_Profile.UserId = dbo.aspnet_Membership.UserId INNER JOIN
                      dbo.aspnet_Users ON dbo.aspnet_Membership.UserId = dbo.aspnet_Users.UserId
GO
EXEC sp_addextendedproperty N'MS_Description', N'Vista que simplifica la búsqueda de usuarios mediante parametros personalizados', 'SCHEMA', N'dbo', 'VIEW', N'vw_aspnet_ProfilesProperties', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_DiagramPane1', N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[29] 4[12] 2[8] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "aspnet_Profile"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 239
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "aspnet_Membership"
            Begin Extent = 
               Top = 56
               Left = 609
               Bottom = 185
               Right = 930
            End
            DisplayFlags = 280
            TopColumn = 10
         End
         Begin Table = "aspnet_Users"
            Begin Extent = 
               Top = 6
               Left = 277
               Bottom = 135
               Right = 466
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 15
         Width = 284
         Width = 1980
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', 'SCHEMA', N'dbo', 'VIEW', N'vw_aspnet_ProfilesProperties', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_DiagramPaneCount', 1, 'SCHEMA', N'dbo', 'VIEW', N'vw_aspnet_ProfilesProperties', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Custom Property: Nombre del usuario', 'SCHEMA', N'dbo', 'VIEW', N'vw_aspnet_ProfilesProperties', 'COLUMN', N'NombreSolicitante'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Custom Property: Número del documento', 'SCHEMA', N'dbo', 'VIEW', N'vw_aspnet_ProfilesProperties', 'COLUMN', N'NumeroDocumento'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Custom Property: Tipo de documento, cédula o pasaporte', 'SCHEMA', N'dbo', 'VIEW', N'vw_aspnet_ProfilesProperties', 'COLUMN', N'TipoDocumento'
GO
EXEC sp_addextendedproperty N'MS_Description', N'User ID en la tabla de membership', 'SCHEMA', N'dbo', 'VIEW', N'vw_aspnet_ProfilesProperties', 'COLUMN', N'UserId'
GO
