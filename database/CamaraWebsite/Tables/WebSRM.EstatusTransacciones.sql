CREATE TABLE [WebSRM].[EstatusTransacciones]
(
[EstatusTransId] [int] NOT NULL IDENTITY(1, 1),
[EstatusTranNombre] [nvarchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[EstatusTransDescripcion] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [WebSRM].[EstatusTransacciones] ADD CONSTRAINT [PK_EstatusTransacciones] PRIMARY KEY CLUSTERED  ([EstatusTransId])
GO
