CREATE TABLE [OFV].[TipoServicioDetalles]
(
[TipoServicioId] [int] NOT NULL,
[Url] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[WebKey] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [OFV].[TipoServicioDetalles] ADD CONSTRAINT [PK_TipoServicioDetalles] PRIMARY KEY CLUSTERED  ([TipoServicioId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que maneja el detalle de los tipos de servicio', 'SCHEMA', N'OFV', 'TABLE', N'TipoServicioDetalles', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID del tipo de servicio', 'SCHEMA', N'OFV', 'TABLE', N'TipoServicioDetalles', 'COLUMN', N'TipoServicioId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'URL ', 'SCHEMA', N'OFV', 'TABLE', N'TipoServicioDetalles', 'COLUMN', N'Url'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Llave Web', 'SCHEMA', N'OFV', 'TABLE', N'TipoServicioDetalles', 'COLUMN', N'WebKey'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Llave Primaria', 'SCHEMA', N'OFV', 'TABLE', N'TipoServicioDetalles', 'CONSTRAINT', N'PK_TipoServicioDetalles'
GO
