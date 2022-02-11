CREATE TABLE [WebSRM].[ReferenciasComerciales]
(
[ReferenciaComercialId] [int] NOT NULL IDENTITY(1, 1),
[RegistroId] [int] NOT NULL,
[TipoReferencia] [nchar] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Descripcion] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_ReferenciasComerciales_FechaModificacion] DEFAULT (getdate())
)
GO
ALTER TABLE [WebSRM].[ReferenciasComerciales] ADD CONSTRAINT [PK_ReferenciasComerciales] PRIMARY KEY CLUSTERED  ([ReferenciaComercialId])
GO
ALTER TABLE [WebSRM].[ReferenciasComerciales] WITH NOCHECK ADD CONSTRAINT [FK_ReferenciasComerciales_Registros] FOREIGN KEY ([RegistroId]) REFERENCES [WebSRM].[Registros] ([RegistroId]) ON UPDATE CASCADE
GO
