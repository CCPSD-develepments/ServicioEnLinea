CREATE TABLE [OFV].[PropiedadesUI]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Nombre] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
GO
ALTER TABLE [OFV].[PropiedadesUI] ADD CONSTRAINT [PK_PropieadesUI] PRIMARY KEY CLUSTERED  ([ID])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Propiedades de Interfaz de Usuario', 'SCHEMA', N'OFV', 'TABLE', N'PropiedadesUI', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID Primario', 'SCHEMA', N'OFV', 'TABLE', N'PropiedadesUI', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Nombre de la propiedad', 'SCHEMA', N'OFV', 'TABLE', N'PropiedadesUI', 'COLUMN', N'Nombre'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Llave Primaria', 'SCHEMA', N'OFV', 'TABLE', N'PropiedadesUI', 'CONSTRAINT', N'PK_PropieadesUI'
GO
