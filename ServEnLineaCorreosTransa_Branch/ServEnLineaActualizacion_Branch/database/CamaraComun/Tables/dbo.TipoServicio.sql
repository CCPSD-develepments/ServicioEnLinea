CREATE TABLE [dbo].[TipoServicio]
(
[TipoServicioId] [int] NOT NULL IDENTITY(1, 1),
[Descripcion] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Sufijo] [varchar] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FechaModificacion] [datetime] NOT NULL CONSTRAINT [DF_TiposTransacciones_FechaModificacion] DEFAULT (getdate()),
[TipoIdentificador] [int] NOT NULL CONSTRAINT [DF_TipoServicio_TipoIdentificador] DEFAULT ((0)),
[Visible] [bit] NOT NULL CONSTRAINT [DF_TiposTransacciones_Visible] DEFAULT ((1)),
[SiteVisible] [bit] NOT NULL
)
GO
ALTER TABLE [dbo].[TipoServicio] ADD CONSTRAINT [PK__TiposTransaccion__08EA5793] PRIMARY KEY CLUSTERED  ([TipoServicioId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que contiene información de los tipos de transacciones', 'SCHEMA', N'dbo', 'TABLE', N'TipoServicio', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Descripción del tipo de transacción', 'SCHEMA', N'dbo', 'TABLE', N'TipoServicio', 'COLUMN', N'Descripcion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fecha de modificación del registro de la tabla', 'SCHEMA', N'dbo', 'TABLE', N'TipoServicio', 'COLUMN', N'FechaModificacion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Sufijo del tipo de transacción', 'SCHEMA', N'dbo', 'TABLE', N'TipoServicio', 'COLUMN', N'Sufijo'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tipo de identificador', 'SCHEMA', N'dbo', 'TABLE', N'TipoServicio', 'COLUMN', N'TipoIdentificador'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador primario', 'SCHEMA', N'dbo', 'TABLE', N'TipoServicio', 'COLUMN', N'TipoServicioId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Clave primaria', 'SCHEMA', N'dbo', 'TABLE', N'TipoServicio', 'CONSTRAINT', N'PK__TiposTransaccion__08EA5793'
GO
