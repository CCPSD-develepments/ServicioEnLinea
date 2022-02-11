CREATE TABLE [dbo].[Ciudades]
(
[CiudadId] [int] NOT NULL IDENTITY(1, 1),
[Nombre] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[PaisId] [int] NULL,
[Orden] [int] NOT NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Ciudades_FechaModificacion] DEFAULT (getdate()),
[rowguid] [uniqueidentifier] NOT NULL ROWGUIDCOL CONSTRAINT [DF_Ciudades_rowguid] DEFAULT (newid())
)
GO
ALTER TABLE [dbo].[Ciudades] ADD CONSTRAINT [PK__Ciudades__E826E7703CF40B7E] PRIMARY KEY CLUSTERED  ([CiudadId])
GO
ALTER TABLE [dbo].[Ciudades] ADD CONSTRAINT [FK_Ciudades_Paises] FOREIGN KEY ([PaisId]) REFERENCES [dbo].[Paises] ([PaisId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que contiene información de las ciudades', 'SCHEMA', N'dbo', 'TABLE', N'Ciudades', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador primario', 'SCHEMA', N'dbo', 'TABLE', N'Ciudades', 'COLUMN', N'CiudadId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fecha de modificación del registro', 'SCHEMA', N'dbo', 'TABLE', N'Ciudades', 'COLUMN', N'FechaModificacion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Nombre de la ciudad', 'SCHEMA', N'dbo', 'TABLE', N'Ciudades', 'COLUMN', N'Nombre'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Orden de despliegue', 'SCHEMA', N'dbo', 'TABLE', N'Ciudades', 'COLUMN', N'Orden'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador del pais al que pertenece', 'SCHEMA', N'dbo', 'TABLE', N'Ciudades', 'COLUMN', N'PaisId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador del registro de la tabla', 'SCHEMA', N'dbo', 'TABLE', N'Ciudades', 'COLUMN', N'rowguid'
GO
