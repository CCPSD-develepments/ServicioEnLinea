CREATE TABLE [WebSRM].[DiasFeriados]
(
[Fecha] [datetime] NOT NULL
)
GO
ALTER TABLE [WebSRM].[DiasFeriados] ADD CONSTRAINT [PK_DiasFeriados] PRIMARY KEY CLUSTERED  ([Fecha])
GO
