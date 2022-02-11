CREATE TABLE [dbo].[Sectores]
(
[SectorId] [int] NOT NULL IDENTITY(1, 1),
[Nombre] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CiudadId] [int] NOT NULL,
[Orden] [int] NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF__Sectores__FechaM__52E34C9D] DEFAULT (getdate()),
[rowguid] [uniqueidentifier] NOT NULL ROWGUIDCOL CONSTRAINT [DF__Sectores__rowgui__53D770D6] DEFAULT (newid())
)
GO
ALTER TABLE [dbo].[Sectores] ADD CONSTRAINT [PK__Sectores__755E57E950FB042B] PRIMARY KEY CLUSTERED  ([SectorId])
GO
ALTER TABLE [dbo].[Sectores] ADD CONSTRAINT [FK_Sectores_Ciudades] FOREIGN KEY ([CiudadId]) REFERENCES [dbo].[Ciudades] ([CiudadId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que contiene información de los sectores', 'SCHEMA', N'dbo', 'TABLE', N'Sectores', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Indetificador de la ciudad al que pertenece el sector', 'SCHEMA', N'dbo', 'TABLE', N'Sectores', 'COLUMN', N'CiudadId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fecha de modificación del registro de la tabla', 'SCHEMA', N'dbo', 'TABLE', N'Sectores', 'COLUMN', N'FechaModificacion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Nombre del sector', 'SCHEMA', N'dbo', 'TABLE', N'Sectores', 'COLUMN', N'Nombre'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Orden de despliegre del sector', 'SCHEMA', N'dbo', 'TABLE', N'Sectores', 'COLUMN', N'Orden'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador del registro de la tabla', 'SCHEMA', N'dbo', 'TABLE', N'Sectores', 'COLUMN', N'rowguid'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador primario', 'SCHEMA', N'dbo', 'TABLE', N'Sectores', 'COLUMN', N'SectorId'
GO
