CREATE TABLE [WebSRM].[Cargos]
(
[CargoId] [int] NOT NULL IDENTITY(1, 1),
[Descripcion] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Cargos_FechaModificacion] DEFAULT (getdate())
)
GO
ALTER TABLE [WebSRM].[Cargos] ADD CONSTRAINT [PK_Cargos] PRIMARY KEY CLUSTERED  ([CargoId])
GO
