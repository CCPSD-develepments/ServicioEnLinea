CREATE TABLE [WebSRM].[RegistrosActividades]
(
[AtividadId] [int] NOT NULL IDENTITY(1, 1),
[RegistroId] [int] NOT NULL,
[TipoActividadId] [int] NOT NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_RegistrosActividades_FechaModificacion] DEFAULT (getdate())
)
GO
ALTER TABLE [WebSRM].[RegistrosActividades] ADD CONSTRAINT [PK_RegistrosActividades] PRIMARY KEY CLUSTERED  ([AtividadId])
GO
ALTER TABLE [WebSRM].[RegistrosActividades] ADD CONSTRAINT [FK_RegistrosActividades_Registros] FOREIGN KEY ([RegistroId]) REFERENCES [WebSRM].[Registros] ([RegistroId]) ON UPDATE CASCADE
GO
