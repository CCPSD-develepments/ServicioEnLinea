CREATE TABLE [WebSRM].[NombresComerciales]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[TransaccionID] [int] NULL,
[NombreComercial1] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[NombreComercial2] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[NombreComercial3] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [WebSRM].[NombresComerciales] ADD CONSTRAINT [PK_NombresComerciales] PRIMARY KEY CLUSTERED  ([ID])
GO
