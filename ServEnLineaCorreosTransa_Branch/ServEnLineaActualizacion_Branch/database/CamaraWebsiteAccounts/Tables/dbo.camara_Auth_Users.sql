CREATE TABLE [dbo].[camara_Auth_Users]
(
[UserName] [nvarchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[NoRegistro] [int] NOT NULL,
[Cedula] [nvarchar] (14) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CamaraID] [char] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Nombre] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Activo] [bit] NOT NULL
)
GO
ALTER TABLE [dbo].[camara_Auth_Users] ADD CONSTRAINT [PK_camara_Auth_Users] PRIMARY KEY CLUSTERED  ([UserName], [NoRegistro], [Cedula], [CamaraID])
GO
