CREATE TABLE [dbo].[TiposNcf]
(
[TipoNcfId] [int] NOT NULL,
[Descripcion] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[SiteVisible] [bit] NOT NULL CONSTRAINT [DF_TiposNcf_SiteVisible] DEFAULT ((0))
)
GO
ALTER TABLE [dbo].[TiposNcf] ADD CONSTRAINT [PK_TiposNcf] PRIMARY KEY CLUSTERED  ([TipoNcfId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tipos de NCF que pueden ser generados por el SRM y la OFV. Esta tabla será decomisada para usar los tipos de NCFs directamente desde el sistema de gestión', 'SCHEMA', N'dbo', 'TABLE', N'TiposNcf', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Descripción (nombre) del tipo de NCF (ej. Comprobante que genera crédito fiscal)', 'SCHEMA', N'dbo', 'TABLE', N'TiposNcf', 'COLUMN', N'Descripcion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Determine si este tipo de comprobante es visible en la VU/OFV', 'SCHEMA', N'dbo', 'TABLE', N'TiposNcf', 'COLUMN', N'SiteVisible'
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID Primario', 'SCHEMA', N'dbo', 'TABLE', N'TiposNcf', 'COLUMN', N'TipoNcfId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Llave Primaria', 'SCHEMA', N'dbo', 'TABLE', N'TiposNcf', 'CONSTRAINT', N'PK_TiposNcf'
GO
