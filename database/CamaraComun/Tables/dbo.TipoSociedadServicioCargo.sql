CREATE TABLE [dbo].[TipoSociedadServicioCargo]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[CargoID] [int] NULL,
[TipoSociedadID] [int] NULL,
[ServicioID] [int] NULL,
[Descripcion] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [dbo].[TipoSociedadServicioCargo] ADD CONSTRAINT [PK_TipoSociedadServicioCargo] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[TipoSociedadServicioCargo] ADD CONSTRAINT [FK_TipoSociedadServicioCargo_Cargos] FOREIGN KEY ([CargoID]) REFERENCES [dbo].[Cargos] ([CargoId])
GO
ALTER TABLE [dbo].[TipoSociedadServicioCargo] ADD CONSTRAINT [FK_TipoSociedadServicioCargo_Servicio] FOREIGN KEY ([ServicioID]) REFERENCES [dbo].[Servicio] ([ServicioId])
GO
ALTER TABLE [dbo].[TipoSociedadServicioCargo] ADD CONSTRAINT [FK_TipoSociedadServicioCargo_TipoSociedad] FOREIGN KEY ([TipoSociedadID]) REFERENCES [dbo].[TipoSociedad] ([TipoSociedadId])
GO
