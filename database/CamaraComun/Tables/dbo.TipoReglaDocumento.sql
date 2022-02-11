CREATE TABLE [dbo].[TipoReglaDocumento]
(
[TipoReglaDocumentoId] [int] NOT NULL IDENTITY(1, 1),
[TipoDocumentoId] [int] NOT NULL,
[TipoReglaId] [int] NOT NULL
)
GO
ALTER TABLE [dbo].[TipoReglaDocumento] ADD CONSTRAINT [PK_ReglaTipoDocumento] PRIMARY KEY CLUSTERED  ([TipoReglaDocumentoId])
GO
ALTER TABLE [dbo].[TipoReglaDocumento] ADD CONSTRAINT [FK_ReglaTipoDocumento_TipoDocumentoRegla] FOREIGN KEY ([TipoReglaId]) REFERENCES [dbo].[TipoRegla] ([TipoReglaId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tipos de reglas para los documentos', 'SCHEMA', N'dbo', 'TABLE', N'TipoReglaDocumento', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tipo de Documento Relacionado', 'SCHEMA', N'dbo', 'TABLE', N'TipoReglaDocumento', 'COLUMN', N'TipoDocumentoId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID Primario
', 'SCHEMA', N'dbo', 'TABLE', N'TipoReglaDocumento', 'COLUMN', N'TipoReglaDocumentoId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tipo de Regla Relacionada', 'SCHEMA', N'dbo', 'TABLE', N'TipoReglaDocumento', 'COLUMN', N'TipoReglaId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Llave primaria', 'SCHEMA', N'dbo', 'TABLE', N'TipoReglaDocumento', 'CONSTRAINT', N'PK_ReglaTipoDocumento'
GO
