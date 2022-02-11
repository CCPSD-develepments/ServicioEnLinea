IF NOT EXISTS (SELECT * FROM master.dbo.syslogins WHERE loginname = N'CC\nextmedia')
CREATE LOGIN [CC\nextmedia] FROM WINDOWS
GO
CREATE USER [CC\Nextmedia] FOR LOGIN [CC\nextmedia] WITH DEFAULT_SCHEMA=[dbo]
GO
GRANT CONNECT TO [CC\Nextmedia]
