SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[cvw_ServicioDocumentoRequerido]
AS     SELECT   ServicioDocRequerido.TipoSociedadId, ServicioDocRequerido.ServicioId,
                ServicioDocRequerido.TipoDocumentoId, ServicioDocRequerido.Requerido, ISNULL(ServicioDocRequerido.Grupo, 0) Grupo,
                TipoDoc.Nombre AS DocumentoDescripcion, TipoSociedad.Descripcion AS TipoSociedadDescripcion,
                TipoDoc.Registrable, TipoDoc.CostoOriginal, TipoDoc.CostoCopia, TipoDoc.Visible,
                TipoDoc.FechaModificacion
       FROM     dbo.ServicioDocumentoRequerido ServicioDocRequerido 
       INNER JOIN dbo.TipoSociedad TipoSociedad ON ServicioDocRequerido.TipoSociedadId = TipoSociedad.TipoSociedadId 
       INNER JOIN dbo.TipoDocumento TipoDoc ON ServicioDocRequerido.TipoDocumentoId = TipoDoc.TipoDocumentoId




GO
