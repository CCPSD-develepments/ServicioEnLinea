CREATE TABLE [WebSRM].[Paises]
(
[PaisId] [int] NOT NULL IDENTITY(1, 1),
[Nombre] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Descripcion] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Orden] [int] NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_Paises_FechaModificacion] DEFAULT (getdate())
)
GO
ALTER TABLE [WebSRM].[Paises] ADD CONSTRAINT [PK__Paises__41EDCAC5] PRIMARY KEY CLUSTERED  ([PaisId])
GO
