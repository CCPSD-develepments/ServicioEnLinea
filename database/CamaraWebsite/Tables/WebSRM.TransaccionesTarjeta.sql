CREATE TABLE [WebSRM].[TransaccionesTarjeta]
(
[TarjetaId] [int] NOT NULL IDENTITY(1, 1),
[FacturaId] [int] NOT NULL,
[FechaTransaccion] [datetime] NOT NULL,
[NumeroTarjeta] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[AnoVencimiento] [varchar] (4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[MesVencimiento] [varchar] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[NombreTarjeta] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[NombreBanco] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[TipoTarjeta] [varchar] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[bProcesada] [bit] NOT NULL CONSTRAINT [DF_TransaccionesTarjeta_bProcesada] DEFAULT ((0)),
[bCancelada] [bit] NOT NULL CONSTRAINT [DF_TransaccionesTarjeta_bCancelada] DEFAULT ((0))
)
GO
ALTER TABLE [WebSRM].[TransaccionesTarjeta] ADD CONSTRAINT [PK_TransaccionesTarjeta] PRIMARY KEY CLUSTERED  ([TarjetaId])
GO
ALTER TABLE [WebSRM].[TransaccionesTarjeta] ADD CONSTRAINT [FK_TransaccionesTarjeta_Facturas] FOREIGN KEY ([FacturaId]) REFERENCES [WebSRM].[Facturas] ([FacturaId])
GO
