CREATE TABLE [dbo].[TipoSociedadSufijo]
(
[TipoSociedadSufijoId] [int] NOT NULL IDENTITY(1, 1),
[TipoSociedadId] [int] NOT NULL,
[Sufijo] [varchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_TipoSociedadSufijo_Sufijo] DEFAULT ('')
)
GO
ALTER TABLE [dbo].[TipoSociedadSufijo] ADD CONSTRAINT [PK_TipoSociedadesSufijos] PRIMARY KEY CLUSTERED  ([TipoSociedadSufijoId])
GO
ALTER TABLE [dbo].[TipoSociedadSufijo] ADD CONSTRAINT [UQ_Sufijo] UNIQUE NONCLUSTERED  ([Sufijo])
GO
ALTER TABLE [dbo].[TipoSociedadSufijo] ADD CONSTRAINT [FK_TiposSociedadesSufijos_TiposSociedades] FOREIGN KEY ([TipoSociedadId]) REFERENCES [dbo].[TipoSociedad] ([TipoSociedadId])
GO
