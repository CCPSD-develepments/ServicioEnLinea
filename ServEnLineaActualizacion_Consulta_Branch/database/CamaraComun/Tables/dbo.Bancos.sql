CREATE TABLE [dbo].[Bancos]
(
[BancoId] [int] NOT NULL IDENTITY(1, 1),
[Descripcion] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Orden] [int] NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Bancos_FechaModificacion] DEFAULT (getdate()),
[rowguid] [uniqueidentifier] NOT NULL ROWGUIDCOL CONSTRAINT [DF_Bancos_rowguid] DEFAULT (newid())
)
GO
ALTER TABLE [dbo].[Bancos] ADD CONSTRAINT [PK_Bancos] PRIMARY KEY CLUSTERED  ([BancoId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que contiene información de los bancos', 'SCHEMA', N'dbo', 'TABLE', N'Bancos', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador primario', 'SCHEMA', N'dbo', 'TABLE', N'Bancos', 'COLUMN', N'BancoId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Descripción del banco', 'SCHEMA', N'dbo', 'TABLE', N'Bancos', 'COLUMN', N'Descripcion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fecha de modificación del registro de la tabla', 'SCHEMA', N'dbo', 'TABLE', N'Bancos', 'COLUMN', N'FechaModificacion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Orden de despliegue del banco', 'SCHEMA', N'dbo', 'TABLE', N'Bancos', 'COLUMN', N'Orden'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador del registro de la tabla', 'SCHEMA', N'dbo', 'TABLE', N'Bancos', 'COLUMN', N'rowguid'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Llave Primaria', 'SCHEMA', N'dbo', 'TABLE', N'Bancos', 'CONSTRAINT', N'PK_Bancos'
GO
