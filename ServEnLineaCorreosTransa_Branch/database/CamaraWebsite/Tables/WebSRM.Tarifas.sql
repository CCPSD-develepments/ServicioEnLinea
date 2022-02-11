CREATE TABLE [WebSRM].[Tarifas]
(
[TarifaId] [int] NOT NULL IDENTITY(1, 1),
[Descripcion] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[MontoInicial] [decimal] (38, 2) NULL,
[MontoFinal] [decimal] (38, 2) NULL,
[CostoContitucion] [decimal] (38, 6) NOT NULL,
[CostoModificacion] [decimal] (38, 6) NOT NULL,
[CostoModificacionNeto] AS ([CostoContitucion]*([CostoModificacion]/(100))),
[CostoRenovacion] [decimal] (38, 6) NOT NULL,
[CostoRenovacionNeto] AS ([CostoContitucion]*([CostoRenovacion]/(100)))
)
GO
ALTER TABLE [WebSRM].[Tarifas] ADD CONSTRAINT [PK_Tarifas] PRIMARY KEY CLUSTERED  ([TarifaId])
GO
