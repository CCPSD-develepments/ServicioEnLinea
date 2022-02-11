CREATE TABLE [dbo].[aspnet_SchemaVersions]
(
[Feature] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CompatibleSchemaVersion] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsCurrentVersion] [bit] NOT NULL
)
GO
ALTER TABLE [dbo].[aspnet_SchemaVersions] ADD CONSTRAINT [PK__aspnet_SchemaVer__08EA5793] PRIMARY KEY CLUSTERED  ([Feature], [CompatibleSchemaVersion])
GO
