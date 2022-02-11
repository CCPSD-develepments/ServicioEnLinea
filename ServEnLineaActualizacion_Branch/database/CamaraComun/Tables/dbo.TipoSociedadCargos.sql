CREATE TABLE [dbo].[TipoSociedadCargos]
(
[TipoSociedadCargoId] [int] NOT NULL IDENTITY(1, 1),
[TipoSociedadId] [int] NULL,
[CargoId] [int] NULL,
[PuedeSerEmpresa] [bit] NULL,
[CargoModificacion] [bit] NULL
)
GO
ALTER TABLE [dbo].[TipoSociedadCargos] ADD CONSTRAINT [PK_TipoSociedadCargos] PRIMARY KEY CLUSTERED  ([TipoSociedadCargoId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID del Cargo', 'SCHEMA', N'dbo', 'TABLE', N'TipoSociedadCargos', 'COLUMN', N'CargoId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Esto indica que el cargo se ve en modificacion de empresas', 'SCHEMA', N'dbo', 'TABLE', N'TipoSociedadCargos', 'COLUMN', N'CargoModificacion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Indica si el cargo puede ser ocupado por otra empresa', 'SCHEMA', N'dbo', 'TABLE', N'TipoSociedadCargos', 'COLUMN', N'PuedeSerEmpresa'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Llave Primaria (autonumérica)', 'SCHEMA', N'dbo', 'TABLE', N'TipoSociedadCargos', 'COLUMN', N'TipoSociedadCargoId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID del tipo de sociedad', 'SCHEMA', N'dbo', 'TABLE', N'TipoSociedadCargos', 'COLUMN', N'TipoSociedadId'
GO
