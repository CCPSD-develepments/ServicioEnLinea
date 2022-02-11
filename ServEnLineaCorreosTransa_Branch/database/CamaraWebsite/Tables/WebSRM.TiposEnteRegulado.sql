CREATE TABLE [WebSRM].[TiposEnteRegulado]
(
[TipoEnteReguladoId] [int] NOT NULL IDENTITY(1, 1),
[Descripcion] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_TiposEnteRegulado_FechaModificacion] DEFAULT (getdate())
)
GO
ALTER TABLE [WebSRM].[TiposEnteRegulado] ADD CONSTRAINT [PK_TiposEnteRegulado] PRIMARY KEY CLUSTERED  ([TipoEnteReguladoId])
GO
