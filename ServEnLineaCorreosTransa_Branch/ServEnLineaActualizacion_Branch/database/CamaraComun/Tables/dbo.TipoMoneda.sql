CREATE TABLE [dbo].[TipoMoneda]
(
[TipoMonedaId] [int] NOT NULL IDENTITY(1, 1),
[Descripcion] [nvarchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Abreviatura] [varchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
GO
ALTER TABLE [dbo].[TipoMoneda] ADD CONSTRAINT [PK__TiposMon__F561DE933296789C] PRIMARY KEY CLUSTERED  ([TipoMonedaId])
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_TiposMonedas] ON [dbo].[TipoMoneda] ([Descripcion], [Abreviatura])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que contiene información de los tipos de monedas. Puede que esta tabla se deje de utilizar al momento que entre el soporte de multimonedas del sistema de gestión. ', 'SCHEMA', N'dbo', 'TABLE', N'TipoMoneda', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Abreviatura de la moneda', 'SCHEMA', N'dbo', 'TABLE', N'TipoMoneda', 'COLUMN', N'Abreviatura'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Decripción del la moneda', 'SCHEMA', N'dbo', 'TABLE', N'TipoMoneda', 'COLUMN', N'Descripcion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador primario', 'SCHEMA', N'dbo', 'TABLE', N'TipoMoneda', 'COLUMN', N'TipoMonedaId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Clave primaria', 'SCHEMA', N'dbo', 'TABLE', N'TipoMoneda', 'CONSTRAINT', N'PK__TiposMon__F561DE933296789C'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Índice para búsqueda', 'SCHEMA', N'dbo', 'TABLE', N'TipoMoneda', 'INDEX', N'IDX_TiposMonedas'
GO
