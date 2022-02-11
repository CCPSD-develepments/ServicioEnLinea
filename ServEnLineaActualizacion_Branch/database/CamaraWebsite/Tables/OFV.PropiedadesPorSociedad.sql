CREATE TABLE [OFV].[PropiedadesPorSociedad]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[PropiedadID] [int] NOT NULL,
[TipoSociedadID] [int] NOT NULL,
[Required] [bit] NOT NULL,
[Descripcion] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LowerLimit] [decimal] (18, 2) NULL,
[UpperLimit] [decimal] (18, 2) NULL
)
GO
ALTER TABLE [OFV].[PropiedadesPorSociedad] ADD CONSTRAINT [PK_PropiedadesPorSociedad] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [OFV].[PropiedadesPorSociedad] ADD CONSTRAINT [FK_PropiedadesPorSociedad_PropiedadesUI] FOREIGN KEY ([PropiedadID]) REFERENCES [OFV].[PropiedadesUI] ([ID])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Propiedades de Interfaz de Usuario relacionadas con cada tipo de sociedad', 'SCHEMA', N'OFV', 'TABLE', N'PropiedadesPorSociedad', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Descripción / Mensaje a desplegar en labels', 'SCHEMA', N'OFV', 'TABLE', N'PropiedadesPorSociedad', 'COLUMN', N'Descripcion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID Primario', 'SCHEMA', N'OFV', 'TABLE', N'PropiedadesPorSociedad', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Límite inferior', 'SCHEMA', N'OFV', 'TABLE', N'PropiedadesPorSociedad', 'COLUMN', N'LowerLimit'
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID de la propiedad', 'SCHEMA', N'OFV', 'TABLE', N'PropiedadesPorSociedad', 'COLUMN', N'PropiedadID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Indica si este atributo es requerido', 'SCHEMA', N'OFV', 'TABLE', N'PropiedadesPorSociedad', 'COLUMN', N'Required'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tipo de Sociedad ID', 'SCHEMA', N'OFV', 'TABLE', N'PropiedadesPorSociedad', 'COLUMN', N'TipoSociedadID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Límite superior', 'SCHEMA', N'OFV', 'TABLE', N'PropiedadesPorSociedad', 'COLUMN', N'UpperLimit'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Llave Primaria', 'SCHEMA', N'OFV', 'TABLE', N'PropiedadesPorSociedad', 'CONSTRAINT', N'PK_PropiedadesPorSociedad'
GO
