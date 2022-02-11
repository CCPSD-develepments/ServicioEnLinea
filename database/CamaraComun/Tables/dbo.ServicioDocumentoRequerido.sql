CREATE TABLE [dbo].[ServicioDocumentoRequerido]
(
[TipoSociedadId] [int] NOT NULL,
[ServicioId] [int] NOT NULL,
[TipoDocumentoId] [int] NOT NULL,
[Requerido] [bit] NOT NULL CONSTRAINT [DF__Transacci__Reque__20ACD28B] DEFAULT ((0)),
[Grupo] [int] NULL,
[SiteVisible] [bit] NOT NULL CONSTRAINT [DF_ServicioDocumentoRequerido_SiteVisible] DEFAULT ((0))
)
GO
ALTER TABLE [dbo].[ServicioDocumentoRequerido] ADD CONSTRAINT [PK_TiposServiciosDocumentosRequeridos] PRIMARY KEY CLUSTERED  ([ServicioId], [TipoSociedadId], [TipoDocumentoId])
GO
ALTER TABLE [dbo].[ServicioDocumentoRequerido] ADD CONSTRAINT [FK_ServicioDocumentoRequerido_TipoSociedad] FOREIGN KEY ([TipoSociedadId]) REFERENCES [dbo].[TipoSociedad] ([TipoSociedadId])
GO
ALTER TABLE [dbo].[ServicioDocumentoRequerido] ADD CONSTRAINT [FK_TransaccionDocumentosRequisitos_TiposServicios] FOREIGN KEY ([ServicioId]) REFERENCES [dbo].[Servicio] ([ServicioId]) ON UPDATE CASCADE
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que contiene información de los documentos requeridos de la transacciones', 'SCHEMA', N'dbo', 'TABLE', N'ServicioDocumentoRequerido', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Define si el documento es requerido en la transacción', 'SCHEMA', N'dbo', 'TABLE', N'ServicioDocumentoRequerido', 'COLUMN', N'Requerido'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificafor del tipo de servicio', 'SCHEMA', N'dbo', 'TABLE', N'ServicioDocumentoRequerido', 'COLUMN', N'ServicioId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificafor del documento', 'SCHEMA', N'dbo', 'TABLE', N'ServicioDocumentoRequerido', 'COLUMN', N'TipoDocumentoId'
GO
