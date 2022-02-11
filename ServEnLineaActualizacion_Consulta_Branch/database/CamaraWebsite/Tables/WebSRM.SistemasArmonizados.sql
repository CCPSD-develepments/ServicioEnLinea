CREATE TABLE [WebSRM].[SistemasArmonizados]
(
[SistemaArmonizadoId] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Descripcion] [nvarchar] (300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_SistemasArmonizados_FechaModificacion] DEFAULT (getdate())
)
GO
ALTER TABLE [WebSRM].[SistemasArmonizados] ADD CONSTRAINT [PK_SistemasArmonizados] PRIMARY KEY CLUSTERED  ([SistemaArmonizadoId])
GO
