CREATE TABLE [WebSRM].[TransaccionesDocDescargas]
(
[DescargaId] [int] NOT NULL IDENTITY(1, 1),
[TransaccionId] [int] NOT NULL,
[DocContent] [varbinary] (max) NULL,
[FechaDescarga] [datetime] NULL,
[UserName] [varchar] (11) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[NombreSocialOrComment] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [WebSRM].[TransaccionesDocDescargas] ADD CONSTRAINT [PK_TransaccionesDocDescargas] PRIMARY KEY CLUSTERED  ([DescargaId])
GO
ALTER TABLE [WebSRM].[TransaccionesDocDescargas] ADD CONSTRAINT [FK_TransaccionesDocDescargas_Transacciones] FOREIGN KEY ([TransaccionId]) REFERENCES [WebSRM].[Transacciones] ([TransaccionId])
GO
