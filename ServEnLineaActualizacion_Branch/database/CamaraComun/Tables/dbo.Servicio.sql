CREATE TABLE [dbo].[Servicio]
(
[ServicioId] [int] NOT NULL IDENTITY(1, 1),
[Descripcion] [varchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[TipoServicioId] [int] NOT NULL,
[CostoServicio] [money] NOT NULL CONSTRAINT [DF__TiposServ__Costo__7073AF84] DEFAULT ((0)),
[CalculoBaseCapital] [bit] NOT NULL,
[TipoCalculoBaseCapital] [int] NOT NULL CONSTRAINT [DF_Servicio_TipoCalculoBaseCapital] DEFAULT ((0)),
[ServicioParalelo] [bit] NOT NULL,
[ServicioFlowId] [int] NOT NULL CONSTRAINT [DF_Servicio_ServicioFlowId] DEFAULT ((0)),
[Cuenta] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_Servicio_Cuenta] DEFAULT (''),
[SeCobra] [bit] NOT NULL,
[SinDocumento] [bit] NOT NULL,
[SubTransaccional] [bit] NOT NULL,
[AfectaOtraCompania] [bit] NOT NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_TiposServicios_FechaModificacion] DEFAULT (getdate()),
[ValidarRenovacion] [bit] NOT NULL,
[EsTransformacion] [bit] NOT NULL,
[TipoIdentificador] [int] NOT NULL,
[Visible] [bit] NOT NULL CONSTRAINT [DF_TiposServicios_Visible] DEFAULT ((1)),
[SiteVisible] [bit] NOT NULL CONSTRAINT [DF_Servicio_SiteVisible] DEFAULT ((0)),
[UsarCostoServicio] [bit] NOT NULL CONSTRAINT [DF_Servicio_UsarCostoServicio] DEFAULT ((0)),
[CopiaExonerada] [bit] NOT NULL CONSTRAINT [DF_Servicio_CopiaExonerada] DEFAULT ((0)),
[CuentaExpress] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF_Servicio_CuentaExpress] DEFAULT (''),
[EsAdecuacion] [bit] NOT NULL CONSTRAINT [DF_Servicio_EsAdecuacion] DEFAULT ((0)),
[SeCobraEnSubTransaccion] [bit] NOT NULL CONSTRAINT [DF_Servicio_SeCobraEnSubTransaccion] DEFAULT ((0)),
[TransaccionJerarquia] [int] NOT NULL CONSTRAINT [DF_Servicio_TransaccionJerarquia] DEFAULT ((0)),
[GrupoServicio] [int] NOT NULL CONSTRAINT [DF_Servicio_GrupoServicio] DEFAULT ((0)),
[DescripcionWeb] [nvarchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[TransfDestinoId] [int] NULL,
[SinCapital] [bit] NULL,
[ServicioJerarquia] [int] NULL
)
GO
ALTER TABLE [dbo].[Servicio] ADD CONSTRAINT [PK__TiposServicios__0AD2A005] PRIMARY KEY CLUSTERED  ([ServicioId])
GO
CREATE NONCLUSTERED INDEX [_dta_index_TiposServicios_7_2055678371__K1_2_4_5_6_7_8_9_10_11_12_13] ON [dbo].[Servicio] ([ServicioId]) INCLUDE ([AfectaOtraCompania], [CalculoBaseCapital], [CostoServicio], [Cuenta], [Descripcion], [SeCobra], [ServicioFlowId], [ServicioParalelo], [SinDocumento], [SubTransaccional], [TipoCalculoBaseCapital])
GO
ALTER TABLE [dbo].[Servicio] ADD CONSTRAINT [FK_TiposServicios_TiposTransacciones] FOREIGN KEY ([TipoServicioId]) REFERENCES [dbo].[TipoServicio] ([TipoServicioId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que contiene información de los tipos de servicios', 'SCHEMA', N'dbo', 'TABLE', N'Servicio', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Define si afecta a otras sociedades', 'SCHEMA', N'dbo', 'TABLE', N'Servicio', 'COLUMN', N'AfectaOtraCompania'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Define si se cobra en base del capital autorizado', 'SCHEMA', N'dbo', 'TABLE', N'Servicio', 'COLUMN', N'CalculoBaseCapital'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Costo del servicio', 'SCHEMA', N'dbo', 'TABLE', N'Servicio', 'COLUMN', N'CostoServicio'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Cuenta que afecta en la contabilidad el servicio', 'SCHEMA', N'dbo', 'TABLE', N'Servicio', 'COLUMN', N'Cuenta'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Descripción del servicio', 'SCHEMA', N'dbo', 'TABLE', N'Servicio', 'COLUMN', N'Descripcion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fecha de modificación del registro de la tabla', 'SCHEMA', N'dbo', 'TABLE', N'Servicio', 'COLUMN', N'FechaModificacion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Organiza el Orden de los servicios para ser mostrados y cobrados en la factura.', 'SCHEMA', N'dbo', 'TABLE', N'Servicio', 'COLUMN', N'GrupoServicio'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Define si se cobra o no el servicio', 'SCHEMA', N'dbo', 'TABLE', N'Servicio', 'COLUMN', N'SeCobra'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Define el fujo del servicio', 'SCHEMA', N'dbo', 'TABLE', N'Servicio', 'COLUMN', N'ServicioFlowId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador primario', 'SCHEMA', N'dbo', 'TABLE', N'Servicio', 'COLUMN', N'ServicioId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Define si el servicio se puede ejecutar de forma paralela con otro servicio', 'SCHEMA', N'dbo', 'TABLE', N'Servicio', 'COLUMN', N'ServicioParalelo'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Define si no registra documento el servicio', 'SCHEMA', N'dbo', 'TABLE', N'Servicio', 'COLUMN', N'SinDocumento'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Define si el servicio puede selecionar como subtransacción', 'SCHEMA', N'dbo', 'TABLE', N'Servicio', 'COLUMN', N'SubTransaccional'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Define el tipo de calculo del costo del servicio en base del capital autirizado', 'SCHEMA', N'dbo', 'TABLE', N'Servicio', 'COLUMN', N'TipoCalculoBaseCapital'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tipo identificador', 'SCHEMA', N'dbo', 'TABLE', N'Servicio', 'COLUMN', N'TipoIdentificador'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador del tipo de transacción', 'SCHEMA', N'dbo', 'TABLE', N'Servicio', 'COLUMN', N'TipoServicioId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Define que la sociedad debe estas vijente para poder disparar este servicio', 'SCHEMA', N'dbo', 'TABLE', N'Servicio', 'COLUMN', N'ValidarRenovacion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Clave primaria', 'SCHEMA', N'dbo', 'TABLE', N'Servicio', 'CONSTRAINT', N'PK__TiposServicios__0AD2A005'
GO
