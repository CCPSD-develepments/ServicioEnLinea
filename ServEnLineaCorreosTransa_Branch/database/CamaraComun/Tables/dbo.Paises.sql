CREATE TABLE [dbo].[Paises]
(
[PaisId] [int] NOT NULL IDENTITY(1, 1),
[Nombre] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Orden] [int] NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Paises_FechaModificacion] DEFAULT (getdate()),
[rowguid] [uniqueidentifier] NOT NULL ROWGUIDCOL CONSTRAINT [DF_Paises_rowguid] DEFAULT (newid())
)
GO
ALTER TABLE [dbo].[Paises] ADD CONSTRAINT [PK__Paises__41EDCAC5] PRIMARY KEY CLUSTERED  ([PaisId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que contiene información de los paises', 'SCHEMA', N'dbo', 'TABLE', N'Paises', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fecha de modificación del registro de la tabla', 'SCHEMA', N'dbo', 'TABLE', N'Paises', 'COLUMN', N'FechaModificacion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Nombre del país', 'SCHEMA', N'dbo', 'TABLE', N'Paises', 'COLUMN', N'Nombre'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Orden de despliegue de los paises', 'SCHEMA', N'dbo', 'TABLE', N'Paises', 'COLUMN', N'Orden'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador primario.', 'SCHEMA', N'dbo', 'TABLE', N'Paises', 'COLUMN', N'PaisId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador del registro de la tabla', 'SCHEMA', N'dbo', 'TABLE', N'Paises', 'COLUMN', N'rowguid'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Clave primaria', 'SCHEMA', N'dbo', 'TABLE', N'Paises', 'CONSTRAINT', N'PK__Paises__41EDCAC5'
GO
