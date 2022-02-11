CREATE TABLE [dbo].[admin_Hints]
(
[helpId] [int] NOT NULL IDENTITY(1, 1),
[HintUrl] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[HintName] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[HintDescription] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[HintCategory] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [dbo].[admin_Hints] ADD CONSTRAINT [PK_admin_Hints] PRIMARY KEY CLUSTERED  ([helpId])
GO
