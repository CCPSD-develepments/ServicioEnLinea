CREATE TABLE [WebSRM].[Transacciones]
(
[TransaccionId] [int] NOT NULL IDENTITY(1, 1),
[Fecha] [datetime] NOT NULL,
[EstatusTransId] [int] NOT NULL CONSTRAINT [DF_Transacciones_EstatusId] DEFAULT ((1)),
[RegistroId] [int] NOT NULL,
[ServicioId] [int] NOT NULL,
[CamaraId] [char] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[UserName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[TipoSociedadId] [int] NOT NULL,
[Solicitante] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[RNCSolicitante] [varchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[NombreContacto] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[TelefonoContacto] [varchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FaxContacto] [varchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[NoReciboDGII] [varchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FechaReciboDGII] [datetime] NULL,
[MontoDGII] [money] NULL,
[DestinoTraslado] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[NombreSocialPersona] [nvarchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ApellidoPersona] [nvarchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[NumeroRegistro] [int] NULL,
[FechaAsamblea] [datetime] NULL,
[CapitalSocial] [decimal] (18, 0) NULL,
[ModificacionCapital] [decimal] (18, 0) NULL,
[bLoadedInSRM] [bit] NULL,
[Tipo] [int] NULL,
[NCF] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[TipoNcf] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[SrmTransaccionId] [int] NULL,
[bPagada] [bit] NOT NULL CONSTRAINT [DF_Transacciones_bPagada] DEFAULT ((0)),
[SubTransaccionId] [int] NULL,
[InstanceXML] [varchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Prioridad] [tinyint] NOT NULL CONSTRAINT [DF_Transacciones_Prioridad] DEFAULT ((0)),
[TipoModeloId] [int] NULL,
[Token] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[TipoComprobanteId] [int] NULL,
[Comentario] [nvarchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [WebSRM].[Transacciones] ADD CONSTRAINT [PK_Transacciones] PRIMARY KEY CLUSTERED  ([TransaccionId])
GO
ALTER TABLE [WebSRM].[Transacciones] ADD CONSTRAINT [FK_Transacciones_EstatusTransacciones] FOREIGN KEY ([EstatusTransId]) REFERENCES [WebSRM].[EstatusTransacciones] ([EstatusTransId])
GO
ALTER TABLE [WebSRM].[Transacciones] ADD CONSTRAINT [FK_Transacciones_Transacciones] FOREIGN KEY ([SubTransaccionId]) REFERENCES [WebSRM].[Transacciones] ([TransaccionId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'', 'SCHEMA', N'WebSRM', 'TABLE', N'Transacciones', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Flag. True Indica que la transaccion ya fue cargada a SRM.', 'SCHEMA', N'WebSRM', 'TABLE', N'Transacciones', 'COLUMN', N'bLoadedInSRM'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Codigo de la Localidad de la Camara.', 'SCHEMA', N'WebSRM', 'TABLE', N'Transacciones', 'COLUMN', N'CamaraId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Cambio de domicilio de una compañia.', 'SCHEMA', N'WebSRM', 'TABLE', N'Transacciones', 'COLUMN', N'DestinoTraslado'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fax del contacto de la Transacción', 'SCHEMA', N'WebSRM', 'TABLE', N'Transacciones', 'COLUMN', N'FaxContacto'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fecha de la Transacción', 'SCHEMA', N'WebSRM', 'TABLE', N'Transacciones', 'COLUMN', N'Fecha'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fecha del Recibo del pago de Impuesto de la DGII', 'SCHEMA', N'WebSRM', 'TABLE', N'Transacciones', 'COLUMN', N'FechaReciboDGII'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Monto del Recibo del pago de Impuesto de la DGII', 'SCHEMA', N'WebSRM', 'TABLE', N'Transacciones', 'COLUMN', N'MontoDGII'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Contacto de la Transacción', 'SCHEMA', N'WebSRM', 'TABLE', N'Transacciones', 'COLUMN', N'NombreContacto'
GO
EXEC sp_addextendedproperty N'MS_Description', N'No. del Recibo del pago de Impuesto de la DGII', 'SCHEMA', N'WebSRM', 'TABLE', N'Transacciones', 'COLUMN', N'NoReciboDGII'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Rnc del Solicitante de la Transacción', 'SCHEMA', N'WebSRM', 'TABLE', N'Transacciones', 'COLUMN', N'RNCSolicitante'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Solicitante de la Transacción', 'SCHEMA', N'WebSRM', 'TABLE', N'Transacciones', 'COLUMN', N'Solicitante'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Telefono del contacto de la Transacción', 'SCHEMA', N'WebSRM', 'TABLE', N'Transacciones', 'COLUMN', N'TelefonoContacto'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Indica el token utilizado para el pago de la transacción desde el sistema transaccional', 'SCHEMA', N'WebSRM', 'TABLE', N'Transacciones', 'COLUMN', N'Token'
GO
EXEC sp_addextendedproperty N'MS_Description', N'No. de Transacción', 'SCHEMA', N'WebSRM', 'TABLE', N'Transacciones', 'COLUMN', N'TransaccionId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Id del Usuario del WebSite. ', 'SCHEMA', N'WebSRM', 'TABLE', N'Transacciones', 'COLUMN', N'UserName'
GO
