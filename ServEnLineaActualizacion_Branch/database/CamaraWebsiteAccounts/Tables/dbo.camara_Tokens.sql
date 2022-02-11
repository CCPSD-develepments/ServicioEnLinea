CREATE TABLE [dbo].[camara_Tokens]
(
[TokenId] [uniqueidentifier] NOT NULL,
[SystemId] [uniqueidentifier] NOT NULL,
[Username] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CreatedOn] [datetime] NOT NULL
)
GO
ALTER TABLE [dbo].[camara_Tokens] ADD CONSTRAINT [PK_camara_Tokens] PRIMARY KEY CLUSTERED  ([TokenId])
GO
