SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


CREATE VIEW [dbo].[cvw_TipoDocumentoRegla]
AS     SELECT   trd.TipoReglaDocumentoId, trd.TipoDocumentoId, trd.TipoReglaId, tr.Descripcion Regla,
                CONVERT(BIT, 0) Validado
       FROM     dbo.TipoReglaDocumento trd 
       INNER JOIN dbo.TipoRegla tr ON trd.TipoReglaId = tr.TipoReglaId

GO
EXEC sp_addextendedproperty N'MS_Description', N'Vista que facilita las consultas para las reglas de los documentos requeridos para cada servicio', 'SCHEMA', N'dbo', 'VIEW', N'cvw_TipoDocumentoRegla', NULL, NULL
GO
