CREATE TABLE [dbo].[TiposEnteRegulado]
(
[TipoEnteReguladoId] [int] NOT NULL IDENTITY(1, 1),
[Descripcion] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_TiposEnteRegulado_FechaModificacion] DEFAULT (getdate()),
[rowguid] [uniqueidentifier] NOT NULL ROWGUIDCOL CONSTRAINT [DF_TiposEnteRegulado_rowguid] DEFAULT (newid())
)
GO
ALTER TABLE [dbo].[TiposEnteRegulado] ADD CONSTRAINT [PK_TiposEnteRegulado] PRIMARY KEY CLUSTERED  ([TipoEnteReguladoId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que contiene información de los tipos de ente regulados de las sociedades', 'SCHEMA', N'dbo', 'TABLE', N'TiposEnteRegulado', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Descripción del tipo de ente regulado', 'SCHEMA', N'dbo', 'TABLE', N'TiposEnteRegulado', 'COLUMN', N'Descripcion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fecha de modificación del registro de la tabla', 'SCHEMA', N'dbo', 'TABLE', N'TiposEnteRegulado', 'COLUMN', N'FechaModificacion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador del registro de la tabla', 'SCHEMA', N'dbo', 'TABLE', N'TiposEnteRegulado', 'COLUMN', N'rowguid'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador primario', 'SCHEMA', N'dbo', 'TABLE', N'TiposEnteRegulado', 'COLUMN', N'TipoEnteReguladoId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Clave primaria', 'SCHEMA', N'dbo', 'TABLE', N'TiposEnteRegulado', 'CONSTRAINT', N'PK_TiposEnteRegulado'
GO
