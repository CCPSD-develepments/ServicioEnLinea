CREATE TABLE [WebSRM].[Socios]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[RegistroId] [int] NOT NULL,
[TipoSocio] [nvarchar] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[TipoRelacion] [nvarchar] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CargoId] [int] NULL,
[TipoDocumento] [nvarchar] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Documento] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[NacionalidadId] [int] NULL,
[RegistroMercantil] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Orden] [int] NOT NULL CONSTRAINT [DF__Socios__Orden__4AB81AF0] DEFAULT ((1)),
[SociedadNombreSocial] [nvarchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[PersonaPrimerNombre] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[PersonaSegundoNombre] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[PersonaPrimerApellido] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[PersonaSegundoApellido] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[PersonaEstadoCivil] [nvarchar] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[PersonaProfesionId] [int] NULL,
[DireccionCalle] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DireccionNumero] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DireccionCiudadId] [int] NULL,
[DireccionSectorId] [int] NULL,
[DireccionApartadoPostal] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[RepresentanteId] [int] NULL,
[CantidadAcciones] [int] NULL
)
GO
ALTER TABLE [WebSRM].[Socios] ADD CONSTRAINT [PK__Socios__3214EC070CBAE877] PRIMARY KEY CLUSTERED  ([Id])
GO
ALTER TABLE [WebSRM].[Socios] ADD CONSTRAINT [FK_Socios_Personas] FOREIGN KEY ([RepresentanteId]) REFERENCES [WebSRM].[Personas] ([PersonaId])
GO
