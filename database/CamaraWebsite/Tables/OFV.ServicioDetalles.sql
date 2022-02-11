CREATE TABLE [OFV].[ServicioDetalles]
(
[ServicioId] [int] NOT NULL,
[Url] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
GO
ALTER TABLE [OFV].[ServicioDetalles] ADD CONSTRAINT [PK_ServicioDetalles] PRIMARY KEY CLUSTERED  ([ServicioId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que maneja el mapeo entre las páginas (ASPX) y los servicios', 'SCHEMA', N'OFV', 'TABLE', N'ServicioDetalles', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID del Servicio', 'SCHEMA', N'OFV', 'TABLE', N'ServicioDetalles', 'COLUMN', N'ServicioId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'URL', 'SCHEMA', N'OFV', 'TABLE', N'ServicioDetalles', 'COLUMN', N'Url'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Llave Primaria', 'SCHEMA', N'OFV', 'TABLE', N'ServicioDetalles', 'CONSTRAINT', N'PK_ServicioDetalles'
GO
