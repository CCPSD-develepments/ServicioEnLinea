CREATE TABLE [dbo].[Camaras]
(
[ID] [char] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Nombre] [nvarchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[GestionID] [int] NULL,
[RNC] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Activa] [bit] NULL,
[HeaderImpresiones] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[SecurityGroup] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Direccion] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[PathCertificado] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Password] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Reason] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[SignContact] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[SignLocation] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Logo] [image] NULL,
[PuedeVenderOnline] [bit] NULL,
[VisanetMerchant] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[BraintreeMerchant] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[NombreEncargado] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[PuestoEncargado] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ActivaOnline] [bit] NULL
)
GO
ALTER TABLE [dbo].[Camaras] ADD CONSTRAINT [PK_Camaras] PRIMARY KEY CLUSTERED  ([ID])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que representa las cámras en el sistema. Para cada cámara que haga uso del sistema de gestión y del sistema de Registro Mercantil, habrá una entrada en esta tabla. ', 'SCHEMA', N'dbo', 'TABLE', N'Camaras', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Indica si la cámara está activa o no', 'SCHEMA', N'dbo', 'TABLE', N'Camaras', 'COLUMN', N'Activa'
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID en el sistema de gestión para esta cámara', 'SCHEMA', N'dbo', 'TABLE', N'Camaras', 'COLUMN', N'GestionID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Es el enunciado que aparece en la parte superior de cada documento que la cámara emite. Es el equivalente al papel timbrado en cada institución. Se usa para facturas, registros mercantiles y comunicaciones en general', 'SCHEMA', N'dbo', 'TABLE', N'Camaras', 'COLUMN', N'HeaderImpresiones'
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID Primario', 'SCHEMA', N'dbo', 'TABLE', N'Camaras', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Nombre de la Cámara de Comercio', 'SCHEMA', N'dbo', 'TABLE', N'Camaras', 'COLUMN', N'Nombre'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Direccion del certificado digital para firmar documentos a nombre de la camara', 'SCHEMA', N'dbo', 'TABLE', N'Camaras', 'COLUMN', N'PathCertificado'
GO
EXEC sp_addextendedproperty N'MS_Description', N'RNC de la cámara. Este dato se necesita para generación de facturas', 'SCHEMA', N'dbo', 'TABLE', N'Camaras', 'COLUMN', N'RNC'
GO
