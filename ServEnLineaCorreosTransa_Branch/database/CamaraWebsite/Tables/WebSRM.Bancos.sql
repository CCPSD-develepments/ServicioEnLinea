CREATE TABLE [WebSRM].[Bancos]
(
[BancoId] [int] NOT NULL IDENTITY(1, 1),
[Descripcion] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Orden] [int] NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Bancos_FechaModificacion] DEFAULT (getdate())
)
GO
ALTER TABLE [WebSRM].[Bancos] ADD CONSTRAINT [PK_Bancos] PRIMARY KEY CLUSTERED  ([BancoId])
GO
