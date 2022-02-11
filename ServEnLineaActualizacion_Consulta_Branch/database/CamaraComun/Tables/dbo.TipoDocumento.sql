CREATE TABLE [dbo].[TipoDocumento]
(
[TipoDocumentoId] [int] NOT NULL IDENTITY(1, 1),
[Nombre] [nvarchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Registrable] [bit] NOT NULL CONSTRAINT [DF_Documentos_Regsitrable] DEFAULT ((0)),
[CostoOriginal] [money] NOT NULL,
[CostoCopia] [money] NOT NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Documentos_FechaModificacion] DEFAULT (getdate()),
[Visible] [bit] NOT NULL CONSTRAINT [DF_TipoDocumento_Visible] DEFAULT ((0)),
[SiteVisible] [bit] NULL,
[Descripcion] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [dbo].[TipoDocumento] ADD CONSTRAINT [PK_TipoDocumento] PRIMARY KEY CLUSTERED  ([TipoDocumentoId])
GO
ALTER TABLE [dbo].[TipoDocumento] ADD CONSTRAINT [UQ_Nombre_TipoDocumento] UNIQUE NONCLUSTERED  ([Nombre])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que contiene información de los tipos de documentos que se pueden registrar', 'SCHEMA', N'dbo', 'TABLE', N'TipoDocumento', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Costo del documento en copia', 'SCHEMA', N'dbo', 'TABLE', N'TipoDocumento', 'COLUMN', N'CostoCopia'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Costo del documento en original', 'SCHEMA', N'dbo', 'TABLE', N'TipoDocumento', 'COLUMN', N'CostoOriginal'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Columna que tiene descripciones o sugerencias sobre los documentos', 'SCHEMA', N'dbo', 'TABLE', N'TipoDocumento', 'COLUMN', N'Descripcion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fecha de modificación del registro de la tabla', 'SCHEMA', N'dbo', 'TABLE', N'TipoDocumento', 'COLUMN', N'FechaModificacion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Nombre del documento', 'SCHEMA', N'dbo', 'TABLE', N'TipoDocumento', 'COLUMN', N'Nombre'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Define si el documento es registrable o no', 'SCHEMA', N'dbo', 'TABLE', N'TipoDocumento', 'COLUMN', N'Registrable'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador primario', 'SCHEMA', N'dbo', 'TABLE', N'TipoDocumento', 'COLUMN', N'TipoDocumentoId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Define si es visible o no', 'SCHEMA', N'dbo', 'TABLE', N'TipoDocumento', 'COLUMN', N'Visible'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Llave Primaria', 'SCHEMA', N'dbo', 'TABLE', N'TipoDocumento', 'CONSTRAINT', N'PK_TipoDocumento'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Clave unica para el nombre del documento.', 'SCHEMA', N'dbo', 'TABLE', N'TipoDocumento', 'CONSTRAINT', N'UQ_Nombre_TipoDocumento'
GO
