CREATE TABLE [WebSRM].[Direcciones]
(
[DireccionId] [int] NOT NULL IDENTITY(1, 1),
[Calle] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Numero] [nvarchar] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CiudadId] [int] NULL,
[SectorId] [int] NULL,
[ApartadoPostal] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[TelefonoCasa] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[TelefonoOficina] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Extension] [int] NULL,
[Fax] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Email] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[SitioWeb] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [WebSRM].[Direcciones] ADD CONSTRAINT [PK__Direccio__68906D6407020F21] PRIMARY KEY CLUSTERED  ([DireccionId])
GO
