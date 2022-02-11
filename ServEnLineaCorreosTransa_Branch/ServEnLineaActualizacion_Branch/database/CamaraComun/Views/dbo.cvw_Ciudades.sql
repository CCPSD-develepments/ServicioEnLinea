SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[cvw_Ciudades]

AS     SELECT  c.CiudadId, c.Nombre, c.PaisId, c.Orden, c.FechaModificacion, c.rowguid, p.Nombre AS Pais
       FROM    dbo.Ciudades c 
       LEFT JOIN dbo.Paises p ON c.PaisId = p.PaisId


GO
EXEC sp_addextendedproperty N'MS_Description', N'Vista que unifica las ciudades, para facilitar su búsqueda', 'SCHEMA', N'dbo', 'VIEW', N'cvw_Ciudades', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID de la ciudad', 'SCHEMA', N'dbo', 'VIEW', N'cvw_Ciudades', 'COLUMN', N'CiudadId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fecha de última modificación', 'SCHEMA', N'dbo', 'VIEW', N'cvw_Ciudades', 'COLUMN', N'FechaModificacion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Nombre de la ciudad', 'SCHEMA', N'dbo', 'VIEW', N'cvw_Ciudades', 'COLUMN', N'Nombre'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Orden de despliegue', 'SCHEMA', N'dbo', 'VIEW', N'cvw_Ciudades', 'COLUMN', N'Orden'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Nombre del país a la que la ciudad pertenece', 'SCHEMA', N'dbo', 'VIEW', N'cvw_Ciudades', 'COLUMN', N'Pais'
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID del país a la que pertenece', 'SCHEMA', N'dbo', 'VIEW', N'cvw_Ciudades', 'COLUMN', N'PaisId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'GUID', 'SCHEMA', N'dbo', 'VIEW', N'cvw_Ciudades', 'COLUMN', N'rowguid'
GO
