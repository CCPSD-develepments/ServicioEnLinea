CREATE TABLE [dbo].[TipoRegla]
(
[TipoReglaId] [int] NOT NULL IDENTITY(1, 1),
[Descripcion] [varchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
GO
ALTER TABLE [dbo].[TipoRegla] ADD CONSTRAINT [PK_TiposReglasDocumentos] PRIMARY KEY CLUSTERED  ([TipoReglaId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que contiene información de los tipos de reglas de los documentos', 'SCHEMA', N'dbo', 'TABLE', N'TipoRegla', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Decripción de los tipos de reglas de los documentos', 'SCHEMA', N'dbo', 'TABLE', N'TipoRegla', 'COLUMN', N'Descripcion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador primario', 'SCHEMA', N'dbo', 'TABLE', N'TipoRegla', 'COLUMN', N'TipoReglaId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Clave primaria', 'SCHEMA', N'dbo', 'TABLE', N'TipoRegla', 'CONSTRAINT', N'PK_TiposReglasDocumentos'
GO
