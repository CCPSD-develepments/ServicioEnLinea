CREATE TABLE [dbo].[Profesiones]
(
[ProfesionId] [int] NOT NULL IDENTITY(1, 1),
[Descripcion] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Profesiones_FechaModificacion] DEFAULT (getdate()),
[rowguid] [uniqueidentifier] NOT NULL ROWGUIDCOL CONSTRAINT [DF_Profesiones_rowguid] DEFAULT (newid())
)
GO
ALTER TABLE [dbo].[Profesiones] ADD CONSTRAINT [PK_Profesiones] PRIMARY KEY CLUSTERED  ([ProfesionId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que contiene información de las profesiones', 'SCHEMA', N'dbo', 'TABLE', N'Profesiones', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Descripción de la profesión', 'SCHEMA', N'dbo', 'TABLE', N'Profesiones', 'COLUMN', N'Descripcion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fecha de modificación del registro de la tabla', 'SCHEMA', N'dbo', 'TABLE', N'Profesiones', 'COLUMN', N'FechaModificacion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador primario', 'SCHEMA', N'dbo', 'TABLE', N'Profesiones', 'COLUMN', N'ProfesionId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador del registro de la tabla', 'SCHEMA', N'dbo', 'TABLE', N'Profesiones', 'COLUMN', N'rowguid'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Clave primaria', 'SCHEMA', N'dbo', 'TABLE', N'Profesiones', 'CONSTRAINT', N'PK_Profesiones'
GO
