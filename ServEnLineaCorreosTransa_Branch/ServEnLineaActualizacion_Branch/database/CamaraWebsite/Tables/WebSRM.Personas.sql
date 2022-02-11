CREATE TABLE [WebSRM].[Personas]
(
[PersonaId] [int] NOT NULL IDENTITY(1, 1),
[RegistroId] [int] NOT NULL CONSTRAINT [DF__Personas__Regist__02284B6B] DEFAULT ((0)),
[TipoDocumento] [nchar] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Documento] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[PrimerNombre] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[SegundoNombre] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[PrimerApellido] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[SegundoApellido] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Rnc] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[NacionalidadId] [int] NULL,
[EstadoCivil] [nchar] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ProfesionId] [int] NULL,
[DireccionId] [int] NULL,
[DireccionCalle] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DireccionNumero] [nvarchar] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DireccionCiudadId] [int] NULL,
[DireccionSectorId] [int] NULL,
[DireccionApartadoPostal] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [WebSRM].[Personas] ADD CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED  ([PersonaId])
GO
ALTER TABLE [WebSRM].[Personas] ADD CONSTRAINT [UQ_Personas_2] UNIQUE NONCLUSTERED  ([Documento])
GO
ALTER TABLE [WebSRM].[Personas] ADD CONSTRAINT [FK_Personas_Direcciones (Persona)] FOREIGN KEY ([DireccionId]) REFERENCES [WebSRM].[Direcciones] ([DireccionId])
GO
