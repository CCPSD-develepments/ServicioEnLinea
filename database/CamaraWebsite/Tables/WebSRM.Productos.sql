CREATE TABLE [WebSRM].[Productos]
(
[ProductoId] [int] NOT NULL IDENTITY(1, 1),
[RegistroId] [int] NOT NULL,
[Descripcion] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[SistemaArmonizadoId] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Productos_FechaModificacion] DEFAULT (getdate())
)
GO
ALTER TABLE [WebSRM].[Productos] ADD CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED  ([ProductoId])
GO
ALTER TABLE [WebSRM].[Productos] ADD CONSTRAINT [FK_Productos_Registros] FOREIGN KEY ([RegistroId]) REFERENCES [WebSRM].[Registros] ([RegistroId]) ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [WebSRM].[Productos] ADD CONSTRAINT [FK_Productos_SistemasArmonizados] FOREIGN KEY ([SistemaArmonizadoId]) REFERENCES [WebSRM].[SistemasArmonizados] ([SistemaArmonizadoId]) ON DELETE SET NULL ON UPDATE CASCADE
GO
