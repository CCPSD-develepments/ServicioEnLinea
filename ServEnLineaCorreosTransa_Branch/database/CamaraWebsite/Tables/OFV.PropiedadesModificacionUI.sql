CREATE TABLE [OFV].[PropiedadesModificacionUI]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[ServicioID] [int] NULL,
[NombreControl] [nvarchar] (80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [OFV].[PropiedadesModificacionUI] ADD CONSTRAINT [PK_PropiedadesModificacionUI] PRIMARY KEY CLUSTERED  ([ID])
GO
