CREATE TABLE [WebSRM].[TransaccionDetalle]
(
[TransaccionDetalles] [int] NOT NULL IDENTITY(1, 1),
[Cuenta] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Detalle] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Cantidad] [int] NOT NULL,
[PrecioUnitario] [money] NOT NULL,
[Descuento] [money] NOT NULL CONSTRAINT [DF_TransaccionDetalle_Descuento] DEFAULT ((0)),
[Total] AS ([PrecioUnitario]*[Cantidad]),
[TotalBruto] AS ([PrecioUnitario]*[Cantidad]-[Descuento]),
[FacturaId] [int] NOT NULL
)
GO
ALTER TABLE [WebSRM].[TransaccionDetalle] ADD CONSTRAINT [PK__TransaccionDetal__0ABD916C] PRIMARY KEY CLUSTERED  ([TransaccionDetalles])
GO
ALTER TABLE [WebSRM].[TransaccionDetalle] ADD CONSTRAINT [FK_TransaccionDetalle_Facturas] FOREIGN KEY ([FacturaId]) REFERENCES [WebSRM].[Facturas] ([FacturaId]) ON DELETE CASCADE ON UPDATE CASCADE
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que contiene información del detalle de las transacción', 'SCHEMA', N'WebSRM', 'TABLE', N'TransaccionDetalle', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Cantidad de servicios solicitado', 'SCHEMA', N'WebSRM', 'TABLE', N'TransaccionDetalle', 'COLUMN', N'Cantidad'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Cuenta que afecta de la contabilidad', 'SCHEMA', N'WebSRM', 'TABLE', N'TransaccionDetalle', 'COLUMN', N'Cuenta'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Descuento del servicio', 'SCHEMA', N'WebSRM', 'TABLE', N'TransaccionDetalle', 'COLUMN', N'Descuento'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Detalle de la transacción', 'SCHEMA', N'WebSRM', 'TABLE', N'TransaccionDetalle', 'COLUMN', N'Detalle'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Precio initario del servicio', 'SCHEMA', N'WebSRM', 'TABLE', N'TransaccionDetalle', 'COLUMN', N'PrecioUnitario'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Total del servicio', 'SCHEMA', N'WebSRM', 'TABLE', N'TransaccionDetalle', 'COLUMN', N'Total'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Total bruto del servicio', 'SCHEMA', N'WebSRM', 'TABLE', N'TransaccionDetalle', 'COLUMN', N'TotalBruto'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador primario', 'SCHEMA', N'WebSRM', 'TABLE', N'TransaccionDetalle', 'COLUMN', N'TransaccionDetalles'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Clave primaria', 'SCHEMA', N'WebSRM', 'TABLE', N'TransaccionDetalle', 'CONSTRAINT', N'PK__TransaccionDetal__0ABD916C'
GO
