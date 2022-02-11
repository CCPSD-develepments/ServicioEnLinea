CREATE TABLE [dbo].[aspnet_CustomProfile]
(
[UserId] [uniqueidentifier] NOT NULL,
[FirstName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LastName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LastUpdatedDate] [datetime] NOT NULL,
[Gender] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[BirthDate] [datetime] NULL,
[Occupation] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[PersonalWebsite] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Address] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[AptNumber] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[City] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[State] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[PostalCode] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Country] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DayPhone] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DayPhoneExt] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[EveningPhone] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[EveningPhoneExt] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CellPhone] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Fax] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Company] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Address2] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[City2] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[State2] [nchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[PostalCode2] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Phone2] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Fax2] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Website2] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Culture] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Newsletter] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [dbo].[aspnet_CustomProfile] ADD CONSTRAINT [PK_aspnet_CustomProfile] PRIMARY KEY CLUSTERED  ([UserId])
GO
