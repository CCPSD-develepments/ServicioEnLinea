CREATE TABLE [WebSRM].[Sociedades]
(
[SociedadId] [int] NOT NULL IDENTITY(1, 1),
[RegistroId] [int] NOT NULL CONSTRAINT [DF__Sociedade__Regis__01342732] DEFAULT ((0)),
[TipoSociedadId] [int] NULL,
[NombreSocial] [nvarchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Rnc] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[EsNacional] [bit] NOT NULL CONSTRAINT [DF_Sociedades_EsNacional] DEFAULT ((1)),
[NacionalidadId] [int] NULL,
[FechaConstitucion] [datetime] NULL,
[DuracionSociedad] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FechaAsamblea] [datetime] NULL,
[DuraccionDirectiva] [int] NULL,
[EstatusId] [int] NULL,
[EsEnteRegulado] [bit] NOT NULL CONSTRAINT [DF_Sociedades_EsEnteRegulado] DEFAULT ((0)),
[TipoEnteReguladoId] [int] NULL,
[NoResolucion] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[NumeroNaveIndustrial] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[NombreSiglas] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[SiglasConfig] [nvarchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[AccionesNominales] [int] NULL,
[AccionesNoNominales] [int] NULL
)
GO
ALTER TABLE [WebSRM].[Sociedades] ADD CONSTRAINT [PK_Sociedades] PRIMARY KEY CLUSTERED  ([SociedadId])
GO
