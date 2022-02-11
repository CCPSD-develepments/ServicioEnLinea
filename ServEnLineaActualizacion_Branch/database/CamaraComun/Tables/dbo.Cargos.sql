CREATE TABLE [dbo].[Cargos]
(
[CargoId] [int] NOT NULL IDENTITY(1, 1),
[Descripcion] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Cargos_FechaModificacion] DEFAULT (getdate()),
[rowguid] [uniqueidentifier] NOT NULL ROWGUIDCOL CONSTRAINT [DF_Cargos_rowguid] DEFAULT (newid()),
[SiteVisible] [bit] NULL
)
GO
ALTER TABLE [dbo].[Cargos] ADD CONSTRAINT [PK_Cargos] PRIMARY KEY CLUSTERED  ([CargoId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que contiene información de los cargos relacionado con las personas.', 'SCHEMA', N'dbo', 'TABLE', N'Cargos', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador primario', 'SCHEMA', N'dbo', 'TABLE', N'Cargos', 'COLUMN', N'CargoId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Descripción del cargo', 'SCHEMA', N'dbo', 'TABLE', N'Cargos', 'COLUMN', N'Descripcion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fecha de Modificadion del registro de la tabla', 'SCHEMA', N'dbo', 'TABLE', N'Cargos', 'COLUMN', N'FechaModificacion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador del registro de la tabla', 'SCHEMA', N'dbo', 'TABLE', N'Cargos', 'COLUMN', N'rowguid'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Clave primaria', 'SCHEMA', N'dbo', 'TABLE', N'Cargos', 'CONSTRAINT', N'PK_Cargos'
GO
