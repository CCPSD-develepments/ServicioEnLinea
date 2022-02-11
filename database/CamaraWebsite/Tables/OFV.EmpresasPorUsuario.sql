CREATE TABLE [OFV].[EmpresasPorUsuario]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Usuario] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FechaSolicitud] [datetime] NOT NULL,
[FechaCreacion] [datetime] NULL,
[FechaUltModificacion] [datetime] NULL,
[Estado] [smallint] NOT NULL,
[CamaraID] [char] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[NoRegistro] [int] NULL,
[TransaccionId] [int] NULL
)
GO
ALTER TABLE [OFV].[EmpresasPorUsuario] ADD CONSTRAINT [PK_EmpresasPorUsuario] PRIMARY KEY CLUSTERED  ([ID])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que define los usuarios que poseen acceso al sistema. Cada empresa puede tener un solo administrador. ', 'SCHEMA', N'OFV', 'TABLE', N'EmpresasPorUsuario', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID de la cámara a la que esta empresa pertenece', 'SCHEMA', N'OFV', 'TABLE', N'EmpresasPorUsuario', 'COLUMN', N'CamaraID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Estado de la solicitud: 1=Solicitado, 2= Activo, 3=Desactivado por cambio de usuario, 4=Desactivado por cierre', 'SCHEMA', N'OFV', 'TABLE', N'EmpresasPorUsuario', 'COLUMN', N'Estado'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fecha de aceptación/ingreso al sistema', 'SCHEMA', N'OFV', 'TABLE', N'EmpresasPorUsuario', 'COLUMN', N'FechaCreacion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fecha de solicitud de acceso al sistema', 'SCHEMA', N'OFV', 'TABLE', N'EmpresasPorUsuario', 'COLUMN', N'FechaSolicitud'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fecha Ultima modificación de la solicitud del usuario', 'SCHEMA', N'OFV', 'TABLE', N'EmpresasPorUsuario', 'COLUMN', N'FechaUltModificacion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID Primario', 'SCHEMA', N'OFV', 'TABLE', N'EmpresasPorUsuario', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'No. de registro de la sociedad/empresa', 'SCHEMA', N'OFV', 'TABLE', N'EmpresasPorUsuario', 'COLUMN', N'NoRegistro'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Usuario del membership que tiene acceso a la empresa', 'SCHEMA', N'OFV', 'TABLE', N'EmpresasPorUsuario', 'COLUMN', N'Usuario'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Llave Primaria', 'SCHEMA', N'OFV', 'TABLE', N'EmpresasPorUsuario', 'CONSTRAINT', N'PK_EmpresasPorUsuario'
GO
