CREATE TABLE [WebSRM].[ReferenciasBancarias]
(
[ReferenciaBancariaId] [int] NOT NULL IDENTITY(1, 1),
[RegistroId] [int] NOT NULL,
[BancoId] [int] NOT NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_ReferenciasBancarias_FechaModificacion] DEFAULT (getdate())
)
GO
ALTER TABLE [WebSRM].[ReferenciasBancarias] ADD CONSTRAINT [PK_ReferenciasBancarias] PRIMARY KEY CLUSTERED  ([ReferenciaBancariaId])
GO
ALTER TABLE [WebSRM].[ReferenciasBancarias] ADD CONSTRAINT [FK_ReferenciasBancarias_Registros] FOREIGN KEY ([RegistroId]) REFERENCES [WebSRM].[Registros] ([RegistroId])
GO
