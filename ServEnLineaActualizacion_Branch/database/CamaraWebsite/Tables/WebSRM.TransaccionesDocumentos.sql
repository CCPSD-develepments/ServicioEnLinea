CREATE TABLE [WebSRM].[TransaccionesDocumentos]
(
[TransaccionesDocumentosId] [int] NOT NULL IDENTITY(1, 1),
[TransaccionId] [int] NOT NULL,
[TipoDocumentoId] [int] NULL,
[Nombre] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Descripcion] [varchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[NombreArchivo] [varchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FechaEnvio] [datetime] NOT NULL,
[Usuario] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[RowId] [uniqueidentifier] NOT NULL ROWGUIDCOL,
[DocContentType] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DocContent] [varbinary] (max) NOT NULL,
[CantidadCopia] [int] NOT NULL CONSTRAINT [DF_TransaccionesDocumentos_CantidadCopia] DEFAULT ((0)),
[CantidadOriginal] [int] NOT NULL CONSTRAINT [DF_TransaccionesDocumentos_CantidadOriginal] DEFAULT ((0)),
[FechaDocumento] [datetime] NULL
)
GO
ALTER TABLE [WebSRM].[TransaccionesDocumentos] ADD CONSTRAINT [PK_TransaccionesDocumentos] PRIMARY KEY CLUSTERED  ([TransaccionesDocumentosId])
GO
ALTER TABLE [WebSRM].[TransaccionesDocumentos] ADD CONSTRAINT [UQ__Transacc__FFEE74302057CCD0] UNIQUE NONCLUSTERED  ([RowId])
GO
ALTER TABLE [WebSRM].[TransaccionesDocumentos] ADD CONSTRAINT [FK_TransaccionesDocumentos_Transacciones] FOREIGN KEY ([TransaccionId]) REFERENCES [WebSRM].[Transacciones] ([TransaccionId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'', 'SCHEMA', N'WebSRM', 'TABLE', N'TransaccionesDocumentos', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Descripción del documento de la base de datos CamaraComun.', 'SCHEMA', N'WebSRM', 'TABLE', N'TransaccionesDocumentos', 'COLUMN', N'Descripcion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fecha en que se somete el archivo.', 'SCHEMA', N'WebSRM', 'TABLE', N'TransaccionesDocumentos', 'COLUMN', N'FechaEnvio'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Nombre del documento digitado por el usuario desde el website.', 'SCHEMA', N'WebSRM', 'TABLE', N'TransaccionesDocumentos', 'COLUMN', N'Nombre'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Nombre final del archivo.', 'SCHEMA', N'WebSRM', 'TABLE', N'TransaccionesDocumentos', 'COLUMN', N'NombreArchivo'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Id del tipo de documento en CamaraComun.', 'SCHEMA', N'WebSRM', 'TABLE', N'TransaccionesDocumentos', 'COLUMN', N'TipoDocumentoId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Primary key de la tabla.', 'SCHEMA', N'WebSRM', 'TABLE', N'TransaccionesDocumentos', 'COLUMN', N'TransaccionesDocumentosId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Foreign key a la tabla trasacciones.', 'SCHEMA', N'WebSRM', 'TABLE', N'TransaccionesDocumentos', 'COLUMN', N'TransaccionId'
GO
