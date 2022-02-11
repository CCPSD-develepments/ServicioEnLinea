CREATE TABLE [dbo].[ServiciosEnCamara]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[ServicioID] [int] NULL,
[CamaraID] [char] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [dbo].[ServiciosEnCamara] ADD CONSTRAINT [PK_ServiciosEnCamara] PRIMARY KEY CLUSTERED  ([ID])
GO
ALTER TABLE [dbo].[ServiciosEnCamara] WITH NOCHECK ADD CONSTRAINT [FK_ServiciosEnCamara_Camaras] FOREIGN KEY ([CamaraID]) REFERENCES [dbo].[Camaras] ([ID])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que define cuales servicios estarán disponibles en cada cámara. Por el momento esta tabla no es utlizada y todos los servicios son comunes para todas las cámaras en OFV/VU/SRM', 'SCHEMA', N'dbo', 'TABLE', N'ServiciosEnCamara', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Foreign Key: CamaraID', 'SCHEMA', N'dbo', 'TABLE', N'ServiciosEnCamara', 'COLUMN', N'CamaraID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID Primario', 'SCHEMA', N'dbo', 'TABLE', N'ServiciosEnCamara', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Foreign Key: ID del servicio (viene de CamaraComun)', 'SCHEMA', N'dbo', 'TABLE', N'ServiciosEnCamara', 'COLUMN', N'ServicioID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Llave Primaria', 'SCHEMA', N'dbo', 'TABLE', N'ServiciosEnCamara', 'CONSTRAINT', N'PK_ServiciosEnCamara'
GO
