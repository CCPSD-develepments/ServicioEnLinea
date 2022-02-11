CREATE TABLE [WebSRM].[Sucursales]
(
[SucursalId] [int] NOT NULL IDENTITY(1, 1),
[SociedadId] [int] NOT NULL,
[Descripcion] [nvarchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DireccionId] [int] NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Suscursales_FechaModificacion] DEFAULT (getdate()),
[DireccionCalle] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DireccionNumero] [nvarchar] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DireccionCiudadId] [int] NULL,
[DireccionSectorId] [int] NULL,
[DireccionApartadoPostal] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DireccionTelefonoCasa] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DireccionTelefonoOficina] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DireccionExtension] [int] NULL,
[DireccionFax] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DireccionEmail] [nvarchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [WebSRM].[Sucursales] ADD CONSTRAINT [PK_Suscursales] PRIMARY KEY CLUSTERED  ([SucursalId])
GO
ALTER TABLE [WebSRM].[Sucursales] ADD CONSTRAINT [FK_Suscursales_Sociedades] FOREIGN KEY ([SociedadId]) REFERENCES [WebSRM].[Sociedades] ([SociedadId]) ON DELETE CASCADE ON UPDATE CASCADE
GO
