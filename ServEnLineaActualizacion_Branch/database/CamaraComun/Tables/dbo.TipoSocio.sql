CREATE TABLE [dbo].[TipoSocio]
(
[TipoSocioId] [nchar] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Descripcion] [nvarchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
GO
ALTER TABLE [dbo].[TipoSocio] ADD CONSTRAINT [PK_TipoSocio] PRIMARY KEY CLUSTERED  ([TipoSocioId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Descripcion de los tipos de socios', 'SCHEMA', N'dbo', 'TABLE', N'TipoSocio', 'COLUMN', N'Descripcion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador primario', 'SCHEMA', N'dbo', 'TABLE', N'TipoSocio', 'COLUMN', N'TipoSocioId'
GO
