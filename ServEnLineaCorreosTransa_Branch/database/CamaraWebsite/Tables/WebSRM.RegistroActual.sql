CREATE TABLE [WebSRM].[RegistroActual]
(
[RegistroId] [float] NOT NULL,
[EmpresaId] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[NumeroRegistro] [float] NULL,
[TipoSociedadId] [int] NULL,
[TipoSociedad] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FechaEmision] [datetime] NULL,
[FechaVencimiento] [datetime] NULL,
[FechaConstitucion] [datetime] NULL,
[FechaInicioOperaciones] [datetime] NULL,
[NombreEstablecimiento] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[RazonSocial] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CapitalGeneral] [float] NULL,
[CapitalAutorizado] [float] NULL,
[CapitalPagado] [float] NULL,
[Activos] [float] NULL,
[BienesRaices] [float] NULL,
[IsZonaFranca] [bit] NULL,
[RNC] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [WebSRM].[RegistroActual] ADD CONSTRAINT [PK__Registro__B89731DE6477ECF3] PRIMARY KEY CLUSTERED  ([RegistroId])
GO
