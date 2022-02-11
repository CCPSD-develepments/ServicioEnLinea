CREATE TABLE [dbo].[EstadoRegistro]
(
[EstadoRegistroId] [int] NOT NULL IDENTITY(1, 1),
[Descripcion] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
GO
ALTER TABLE [dbo].[EstadoRegistro] ADD CONSTRAINT [PK__EstadosR__3214EC271BB31344] PRIMARY KEY CLUSTERED  ([EstadoRegistroId])
GO
ALTER TABLE [dbo].[EstadoRegistro] ADD CONSTRAINT [UQ__EstadosR__92C53B6C1E8F7FEF] UNIQUE NONCLUSTERED  ([Descripcion])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que contiene información de los estados de los registros', 'SCHEMA', N'dbo', 'TABLE', N'EstadoRegistro', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Descripción del estado del registro', 'SCHEMA', N'dbo', 'TABLE', N'EstadoRegistro', 'COLUMN', N'Descripcion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador primario', 'SCHEMA', N'dbo', 'TABLE', N'EstadoRegistro', 'COLUMN', N'EstadoRegistroId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Clave primaria', 'SCHEMA', N'dbo', 'TABLE', N'EstadoRegistro', 'CONSTRAINT', N'PK__EstadosR__3214EC271BB31344'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Clave unica para evitar la duplicidad de nombre en los estados', 'SCHEMA', N'dbo', 'TABLE', N'EstadoRegistro', 'CONSTRAINT', N'UQ__EstadosR__92C53B6C1E8F7FEF'
GO
