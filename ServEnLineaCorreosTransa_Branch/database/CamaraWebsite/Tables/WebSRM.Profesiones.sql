CREATE TABLE [WebSRM].[Profesiones]
(
[ProfesionId] [int] NOT NULL IDENTITY(1, 1),
[Descripcion] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Profesiones_FechaModificacion] DEFAULT (getdate())
)
GO
ALTER TABLE [WebSRM].[Profesiones] ADD CONSTRAINT [PK_Profesiones] PRIMARY KEY CLUSTERED  ([ProfesionId])
GO
