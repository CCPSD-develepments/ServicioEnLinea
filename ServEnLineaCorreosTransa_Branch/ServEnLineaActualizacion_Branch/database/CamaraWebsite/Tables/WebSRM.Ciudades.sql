CREATE TABLE [WebSRM].[Ciudades]
(
[CiudadId] [int] NOT NULL IDENTITY(1, 1),
[Nombre] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[PaisId] [int] NULL,
[Orden] [int] NOT NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Ciudades_FechaModificacion] DEFAULT (getdate())
)
GO
ALTER TABLE [WebSRM].[Ciudades] ADD CONSTRAINT [PK__Ciudades__E826E770398D8EEE] PRIMARY KEY CLUSTERED  ([CiudadId])
GO
ALTER TABLE [WebSRM].[Ciudades] ADD CONSTRAINT [FK_Ciudades_Paises] FOREIGN KEY ([PaisId]) REFERENCES [WebSRM].[Paises] ([PaisId]) ON DELETE CASCADE ON UPDATE CASCADE
GO
