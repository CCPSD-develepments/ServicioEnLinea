CREATE TABLE [dbo].[Actividades]
(
[ActividadID] [int] NOT NULL IDENTITY(1, 1),
[PadreID] [int] NULL,
[Descripcion] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DescripconLarga] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FechaModificacion] [datetime] NULL,
[RecibeAccion] [bit] NULL,
[TieneHijos] [bit] NULL,
[Visible] [bit] NULL CONSTRAINT [DF_Actividades_Visible] DEFAULT ((1))
)
GO
ALTER TABLE [dbo].[Actividades] ADD CONSTRAINT [PK_Actividades] PRIMARY KEY CLUSTERED  ([ActividadID])
GO
