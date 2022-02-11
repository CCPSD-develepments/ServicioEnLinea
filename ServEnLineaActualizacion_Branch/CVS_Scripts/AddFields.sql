-- Oficina Virtual
GO
ALTER TABLE [CamaraWebsite].[WebSRM].[Sociedades] ADD SrmSociedadId INT NULL;
GO
ALTER TABLE [CamaraWebsite].[WebSRM].[Registros] ADD SrmRegistroId INT NULL;
GO
ALTER TABLE [CamaraWebsite].[WebSRM].[Socios] ADD SrmId INT NULL;

-- SRM
GO
ALTER TABLE [CamaraSDQ].[Sistema].[RegistrosSocios] ADD RegistroMercantil NVARCHAR(20) NULL;
GO
ALTER TABLE [CamaraSDQ].[Sistema].[RegistrosSocios] ADD SociedadNombreSocial NVARCHAR(150) NULL;
GO
ALTER TABLE [CamaraSDQ].[Sistema].[RegistrosSocios] ADD FechaNacimiento DATETIME NULL;
GO
ALTER TABLE [CamaraSDQ].[Sistema].[RegistrosSocios] ADD TipoBeneficiario NVARCHAR(50) NULL;
GO
GO
ALTER TABLE [CamaraSDQ].[Sistema].[RegistrosSocios] ADD IdentificacionTributariaPais NVARCHAR(100) NULL;
GO
ALTER TABLE [CamaraSDQ].[Sistema].[RegistrosSocios] ADD TipoDatosSocio NVARCHAR(20) NULL;

GO
ALTER TABLE [CamaraSDQ].[Sociedad].[Sociedades] ADD AccionesNominales INT NULL;
GO
ALTER TABLE [CamaraSDQ].[Sociedad].[Sociedades] ADD AccionesNoNominales INT NULL;

GO
ALTER TABLE [CamaraSDQ].[Sistema].[Registros] ADD RegistroMercantil INT NULL;
GO
ALTER TABLE [CamaraSDQ].[Sistema].[Registros] ADD EsNuevoRegistro BIT DEFAULT 1;
GO
ALTER TABLE [CamaraSDQ].[Sistema].[Registros] ADD NombreSolicitante NVARCHAR(80) NULL;
GO
ALTER TABLE [CamaraSDQ].[Sistema].[Registros] ADD CargoSolicitante NVARCHAR(80) NULL;
GO
ALTER TABLE [CamaraSDQ].[Sistema].[Registros] ADD EntidadActiva BIT NULL;
GO
ALTER TABLE [CamaraSDQ].[Sistema].[Registros] ADD EsRenovacion BIT DEFAULT 0;
GO

ALTER TABLE [CamaraWebsite].[WebSRM].[Transacciones] ADD EsCertificacion BIT;
GO

  UPDATE [CamaraWebsite].[OFV].[TipoServicioDetalles]
  SET [Url] = '~/Operaciones/Modificaciones/Modificaciones.aspx',
  [WebKey] = 'servicioRenovacionSimpleId'
  WHERE [TipoServicioId] = 8

  --ARREGLO PARA NOMBRE SOCIAL SOCIO
  ALTER TABLE [CamaraWebsite].[WebSRM].[Socios]
  ALTER COLUMN [PersonaPrimerNombre] nvarchar(150)
  
  --Agregar campo para ayuda en ver detalle empresa
  ALTER TABLE [CamaraWebsite].[OFV].[TipoServicioDetalles]
  ADD DescripcionAyuda NVARCHAR(max);
  go
  
  --texto tooltip por tipo servicio 9/10/2019
    update [CamaraWebsite].[OFV].[TipoServicioDetalles]
  set DescripcionAyuda = 'Es la emisión de un nuevo Registro Mercantil, tras la pérdida o el deterioro del certificado previamente emitido.'
  where TipoServicioId in (5)

    update [CamaraWebsite].[OFV].[TipoServicioDetalles]
  set DescripcionAyuda = 'Es la actualización de la fecha de vigencia de un Certificado del Registro Mercantil hasta dos años posterior a la fecha de vencimiento.'
  where TipoServicioId in (8,3)

   update [CamaraWebsite].[OFV].[TipoServicioDetalles]
  set DescripcionAyuda = 'Es una comunicación oficial emitida por la Cámara que certifica informaciones de una compañía inscrita.'
  where TipoServicioId in (7)