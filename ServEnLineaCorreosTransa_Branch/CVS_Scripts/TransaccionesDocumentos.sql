use [CamaraWebsite]

alter table [WebSRM].[Transacciones] add EsCasoAperturado bit
alter table [WebSRM].[Transacciones] add FolderId varchar(50)
alter table [WebSRM].[TransaccionesDocumentos] add [FirmaDigital] bit 
alter table [WebSRM].[TransaccionesDocumentos] add [SBDocumentId] varchar(50) 
ALTER TABLE [WebSRM].[TransaccionesTarjeta] ADD MedioDePago varchar(50) NULL
ALTER TABLE [WebSRM].[Facturas] ADD Credito decimal(36,7)

ALTER TABLE [CamaraComun].[dbo].[TipoServicio] ADD DescripcionWeb varchar(100);

UPDATE [CamaraComun].[dbo].[TipoServicio] SET DescripcionWeb = Descripcion;

/* Actualizaciones */
INSERT INTO CamaraComun.dbo.ServicioDocumentoRequerido 
([TipoSociedadId],[ServicioId],[TipoDocumentoId],[Requerido],[Grupo],[SiteVisible])
SELECT TipoSociedadId, 30, 1560, 1, 0, 1 FROM CamaraComun.dbo.TipoSociedad

UPDATE CamaraComun.dbo.Servicio SET SiteVisible = 1 WHERE ServicioId = 30

UPDATE [CamaraComun].dbo.TipoServicio
SET SiteVisible = 0;

UPDATE [CamaraComun].dbo.TipoServicio
SET SiteVisible = 1
WHERE TipoServicioId in (1,3,4,5,6,7,8,38);

UPDATE [CamaraComun].[dbo].[TipoServicio] SET DescripcionWeb = REPLACE(Descripcion, 'Registro', 'Solicitud de ');

UPDATE [CamaraWebsite].[OFV].[TipoServicioDetalles] Url = '~/Operaciones/Shared/RegDup.aspx' WHERE TipoServicioId IN (5,8)

ALTER TABLE CamaraWebsite.WebSRM.Facturas ADD CobroPorServicio decimal(36,7) NULL;

ALTER TABLE CamaraWebsite.WebSRM.Transacciones ADD ComentariosProblema varchar(max) NULL;




/* agregar campo en la transaccion para guardar el monto consumido de la nota de credito */
alter table [CamaraWebsite].[WebSRM].[Transacciones]
Add PagadoConNota decimal(18,0) null