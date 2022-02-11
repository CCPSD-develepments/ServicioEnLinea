CREATE TABLE [dbo].[Nomenclaturas]
(
[CamaraId] [char] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[TipoNomenclatura] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Prefijo] [varchar] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Sufijo] [varchar] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Separador1] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Separador2] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Separador3] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Formato] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
GO
ALTER TABLE [dbo].[Nomenclaturas] ADD CONSTRAINT [PK_Nomenclaturas] PRIMARY KEY CLUSTERED  ([CamaraId], [TipoNomenclatura])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tabla que almacena la nomenclatura de generación del número de registro mercantil para cada cámara (ejemplo SD-30064 es el registro de Nextmedia en Santo Domingo)', 'SCHEMA', N'dbo', 'TABLE', N'Nomenclaturas', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID de la Cámara a la que pertenece esta nomenclatura. Este Id también puede ser parte del formato de la nomenclatura', 'SCHEMA', N'dbo', 'TABLE', N'Nomenclaturas', 'COLUMN', N'CamaraId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Formato de la nomenclatura, este es almacenado como formato de string. ej. {0}{1}{2} donde 0=Prefijo/Sufijo, 1=RM, 2=CamaraId, se desplegaria como: SD30064SDQ. Esto puede ser personalizado.', 'SCHEMA', N'dbo', 'TABLE', N'Nomenclaturas', 'COLUMN', N'Formato'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Prefijo del formato de la nomenclatura del Numero de Registro (ej. [Prefijo => SD]30064).', 'SCHEMA', N'dbo', 'TABLE', N'Nomenclaturas', 'COLUMN', N'Prefijo'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Caracter utilizado para separar el Id de la cámara, el prefijo y el sufijo en el formato de la nomenclatura', 'SCHEMA', N'dbo', 'TABLE', N'Nomenclaturas', 'COLUMN', N'Separador1'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Caracter utilizado para separar el Id de la cámara, el prefijo y el sufijo en el formato de la nomenclatura', 'SCHEMA', N'dbo', 'TABLE', N'Nomenclaturas', 'COLUMN', N'Separador2'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Caracter utilizado para separar el Id de la cámara, el prefijo y el sufijo en el formato de la nomenclatura', 'SCHEMA', N'dbo', 'TABLE', N'Nomenclaturas', 'COLUMN', N'Separador3'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Sufijo del formato de la nomenclatura del Numero de Registro (ej. 30064[SD <= Sufijo]).', 'SCHEMA', N'dbo', 'TABLE', N'Nomenclaturas', 'COLUMN', N'Sufijo'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tipo de nomenclatura (Persona Física o Empresa/Sociedad)', 'SCHEMA', N'dbo', 'TABLE', N'Nomenclaturas', 'COLUMN', N'TipoNomenclatura'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Clave primaria compuesta por dos campos de la tabla', 'SCHEMA', N'dbo', 'TABLE', N'Nomenclaturas', 'CONSTRAINT', N'PK_Nomenclaturas'
GO
