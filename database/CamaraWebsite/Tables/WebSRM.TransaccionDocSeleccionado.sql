CREATE TABLE [WebSRM].[TransaccionDocSeleccionado]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[TransaccionId] [int] NOT NULL,
[TipoDocumentoId] [int] NOT NULL,
[CantidadCopia] [int] NOT NULL,
[CantidadOriginal] [int] NOT NULL,
[FechaDocumento] [datetime] NULL
)
GO
ALTER TABLE [WebSRM].[TransaccionDocSeleccionado] ADD CONSTRAINT [PK_TransaccionDocumentosSeleccionados] PRIMARY KEY CLUSTERED  ([ID])
GO
