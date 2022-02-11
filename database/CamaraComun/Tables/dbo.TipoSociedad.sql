CREATE TABLE [dbo].[TipoSociedad]
(
[TipoSociedadId] [int] NOT NULL IDENTITY(1, 1),
[Descripcion] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[TipoIdentificador] [int] NOT NULL CONSTRAINT [DF_TipoSociedad_TipoIdentificador] DEFAULT ((0)),
[Etiqueta] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_TiposSociedades_FechaModificacion] DEFAULT (getdate()),
[Visible] [bit] NULL,
[CapitalAutorizado] [decimal] (18, 2) NOT NULL CONSTRAINT [DF_TipoSociedad_CapitalAutorizado] DEFAULT ((0.00)),
[SiteVisible] [bit] NULL,
[DescripcionExtendida] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [dbo].[TipoSociedad] ADD CONSTRAINT [PK__TipoSociedades__07020F21] PRIMARY KEY CLUSTERED  ([TipoSociedadId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que contiene información de los tipos de sociedades', 'SCHEMA', N'dbo', 'TABLE', N'TipoSociedad', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Descripción del tipo de sociedades', 'SCHEMA', N'dbo', 'TABLE', N'TipoSociedad', 'COLUMN', N'Descripcion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Etiqueta del tipo de sociedad', 'SCHEMA', N'dbo', 'TABLE', N'TipoSociedad', 'COLUMN', N'Etiqueta'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fecha de modificación del registro de la tabla', 'SCHEMA', N'dbo', 'TABLE', N'TipoSociedad', 'COLUMN', N'FechaModificacion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identifica si es tipo es de sociedades o de personas fisica', 'SCHEMA', N'dbo', 'TABLE', N'TipoSociedad', 'COLUMN', N'TipoIdentificador'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador primario', 'SCHEMA', N'dbo', 'TABLE', N'TipoSociedad', 'COLUMN', N'TipoSociedadId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Clave primaria', 'SCHEMA', N'dbo', 'TABLE', N'TipoSociedad', 'CONSTRAINT', N'PK__TipoSociedades__07020F21'
GO
