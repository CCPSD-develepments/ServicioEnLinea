CREATE TABLE [WebSRM].[Facturas]
(
[FacturaId] [int] NOT NULL IDENTITY(1, 1),
[TransaccionId] [int] NULL,
[Fecha] [datetime] NOT NULL,
[Ncf] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Usuario] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Estado] [int] NOT NULL,
[Complementaria] [bit] NOT NULL CONSTRAINT [DF_Facturas_Complementaria] DEFAULT ((0)),
[TipoNcf] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[TotalFactura] [decimal] (36, 7) NOT NULL CONSTRAINT [DF_Facturas_TotalFactura] DEFAULT ((0)),
[FacturaSrmId] [int] NOT NULL,
[CamaraId] [char] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
GO
ALTER TABLE [WebSRM].[Facturas] ADD CONSTRAINT [PK_Facturas] PRIMARY KEY CLUSTERED  ([FacturaId])
GO
ALTER TABLE [WebSRM].[Facturas] ADD CONSTRAINT [FK_Facturas_Transacciones] FOREIGN KEY ([TransaccionId]) REFERENCES [WebSRM].[Transacciones] ([TransaccionId])
GO
