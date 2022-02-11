CREATE TABLE [dbo].[TipoSociedadSocio]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[TipoSocioId] [nchar] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[TipoSociedadId] [int] NOT NULL,
[Descripcion] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[RecibeCargo] [bit] NULL CONSTRAINT [DF_TipoSociedadSocio_RecibeCargo] DEFAULT ((0)),
[CantMinSocio] [smallint] NULL CONSTRAINT [DF_TipoSociedadSocio_CantMinSocio] DEFAULT ((0)),
[CantMaxSocio] [int] NULL CONSTRAINT [DF_TipoSociedadSocio_CantMaxSocio] DEFAULT ((0)),
[RecibeAcciones] [bit] NULL CONSTRAINT [DF_TipoSociedadSocio_RecibeAcciones] DEFAULT ((0)),
[GrupoValidacion] [int] NULL
)
GO
ALTER TABLE [dbo].[TipoSociedadSocio] ADD CONSTRAINT [PK_TipoSocioSociedad] PRIMARY KEY CLUSTERED  ([Id])
GO
ALTER TABLE [dbo].[TipoSociedadSocio] ADD CONSTRAINT [FK_TipoSociedadSocio_TipoSociedad] FOREIGN KEY ([TipoSociedadId]) REFERENCES [dbo].[TipoSociedad] ([TipoSociedadId])
GO
ALTER TABLE [dbo].[TipoSociedadSocio] ADD CONSTRAINT [FK_TipoSociedadSocio_TipoSocio] FOREIGN KEY ([TipoSocioId]) REFERENCES [dbo].[TipoSocio] ([TipoSocioId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Grupo para validar los tipos de socios que no pueden registrarse con el mismo cargo', 'SCHEMA', N'dbo', 'TABLE', N'TipoSociedadSocio', 'COLUMN', N'GrupoValidacion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Determina si este tipo de socio lleva un cargo asociado', 'SCHEMA', N'dbo', 'TABLE', N'TipoSociedadSocio', 'COLUMN', N'RecibeCargo'
GO
