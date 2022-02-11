CREATE TABLE [WebSRM].[CategoriasSocios]
(
[TipoCategoriaId] [int] NOT NULL IDENTITY(1, 1),
[TipoCategoria] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Descripcion] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [WebSRM].[CategoriasSocios] ADD CONSTRAINT [PK_CategoriasSocios_CategoriasSocios] PRIMARY KEY CLUSTERED  ([TipoCategoriaId])
GO
