CREATE TABLE [WebSRM].[Sectores]
(
[SectorId] [int] NOT NULL IDENTITY(1, 1),
[Nombre] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CiudadId] [int] NOT NULL,
[Orden] [int] NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF__Sectores__FechaM__403A8C7D] DEFAULT (getdate())
)
GO
ALTER TABLE [WebSRM].[Sectores] ADD CONSTRAINT [PK__Sectores__755E57E9145C0A3F] PRIMARY KEY CLUSTERED  ([SectorId])
GO
