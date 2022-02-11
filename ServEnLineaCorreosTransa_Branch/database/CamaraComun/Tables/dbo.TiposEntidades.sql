CREATE TABLE [dbo].[TiposEntidades]
(
[TipoEntidadId] [int] NOT NULL IDENTITY(1, 1),
[Descripcion] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Visible] [bit] NULL
)
GO
ALTER TABLE [dbo].[TiposEntidades] ADD CONSTRAINT [PK_TiposEntidades] PRIMARY KEY CLUSTERED  ([TipoEntidadId])
GO
