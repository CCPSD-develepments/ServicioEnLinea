CREATE TABLE [dbo].[camara_Systems]
(
[SystemId] [uniqueidentifier] NOT NULL,
[Description] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Active] [bit] NOT NULL,
[CreatedOn] [datetime] NOT NULL
)
GO
ALTER TABLE [dbo].[camara_Systems] ADD CONSTRAINT [PK_camara_Systems] PRIMARY KEY CLUSTERED  ([SystemId])
GO
