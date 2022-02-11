CREATE TABLE [OFV].[Mensajes]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Usuario] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[UsuarioSistema] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[UsuarioPadre] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[TipoMensaje] [int] NOT NULL,
[Mensaje] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CamaraId] [char] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[SociedadID] [int] NULL,
[TransaccionId] [int] NULL,
[Titulo] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FechaEnvio] [datetime] NULL,
[FechaLectura] [datetime] NULL
)
GO
ALTER TABLE [OFV].[Mensajes] ADD CONSTRAINT [PK_Mensajes] PRIMARY KEY CLUSTERED  ([ID])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Mensajería interna de la aplicación. ', 'SCHEMA', N'OFV', 'TABLE', N'Mensajes', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID de la cámara de comercio asociada', 'SCHEMA', N'OFV', 'TABLE', N'Mensajes', 'COLUMN', N'CamaraId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fecha de envío al usuario', 'SCHEMA', N'OFV', 'TABLE', N'Mensajes', 'COLUMN', N'FechaEnvio'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fecha de lectura por parte del usuario', 'SCHEMA', N'OFV', 'TABLE', N'Mensajes', 'COLUMN', N'FechaLectura'
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID Primario', 'SCHEMA', N'OFV', 'TABLE', N'Mensajes', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Cuerpo del mensaje', 'SCHEMA', N'OFV', 'TABLE', N'Mensajes', 'COLUMN', N'Mensaje'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Si el mensaje es con respecto a una sociedad específica se especifica en este campo (también opcional)', 'SCHEMA', N'OFV', 'TABLE', N'Mensajes', 'COLUMN', N'SociedadID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Titulo del mensaje', 'SCHEMA', N'OFV', 'TABLE', N'Mensajes', 'COLUMN', N'Titulo'
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID de la transacción asociada (no obligatorio)', 'SCHEMA', N'OFV', 'TABLE', N'Mensajes', 'COLUMN', N'TransaccionId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Usuario al que se dirige el mensaje', 'SCHEMA', N'OFV', 'TABLE', N'Mensajes', 'COLUMN', N'Usuario'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Usuario del sistema que envia el mensaje. Puede ser un analista dentro de la cámara, o un servicio para enviar mensajes automáticos (campo opcional)', 'SCHEMA', N'OFV', 'TABLE', N'Mensajes', 'COLUMN', N'UsuarioSistema'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Llave Primaria', 'SCHEMA', N'OFV', 'TABLE', N'Mensajes', 'CONSTRAINT', N'PK_Mensajes'
GO
