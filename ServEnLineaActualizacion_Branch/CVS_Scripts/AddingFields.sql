use [CamaraWebsite]

alter table [WebSRM].[Transacciones] add ContratoFirmado bit 

alter table [WebSRM].[Transacciones] add FirmaDigital bit

alter table [WebSRM].[Transaccionesadd] add ImprimirCopias bit;

--Agregar campo idTransaccion en Registro
USE CamaraWebsite;    
GO 
ALTER TABLE Websrm.Registros ADD TransaccionId INT
ALTER TABLE Websrm.Registros     
ADD CONSTRAINT FK_Registros_Transaccion FOREIGN KEY (TransaccionId)     
    REFERENCES Websrm.transacciones (TransaccionId);    
GO 

  --Agregar campo idTransaccion en Sociedad
USE CamaraWebsite;    
GO
ALTER TABLE Websrm.Sociedades ADD TransaccionId INT
ALTER TABLE Websrm.Sociedades     
ADD CONSTRAINT FK_Sociedades_Transaccion FOREIGN KEY (TransaccionId)     
    REFERENCES Websrm.transacciones (TransaccionId);    
GO 

  --Agregar campo idTransaccion en Referencias Comerciales
USE CamaraWebsite;    
GO 
ALTER TABLE Websrm.ReferenciasComerciales ADD TransaccionId INT
ALTER TABLE Websrm.ReferenciasComerciales
ADD CONSTRAINT FK_ReferenciasComerciales_Transaccion FOREIGN KEY (TransaccionId)     
    REFERENCES Websrm.transacciones (TransaccionId);    
GO 

  --Agregar campo idTransaccion en Referencias Bancarias
USE CamaraWebsite;    
GO
ALTER TABLE Websrm.ReferenciasBancarias ADD TransaccionId INT
ALTER TABLE Websrm.ReferenciasBancarias
ADD CONSTRAINT FK_ReferenciasBancarias_Transaccion FOREIGN KEY (TransaccionId)     
    REFERENCES Websrm.transacciones (TransaccionId);    
GO 

--Agregar campo SrmSocioId
ALTER TABLE [CamaraWebsite].[WebSRM].[Socios]
ADD SrmSocioId int

--Agregar campo TransaccionId a socios
ALTER TABLE [CamaraWebsite].[WebSRM].[Socios]
ADD TransaccionId int

-- Agregar campos en transacion --
-- estos campos estan relacionados con A nombre de quien saldria las certificaciones y las copias de las certificaciones y se se depositarian en cansilleria --

alter table [WebSRM].[Transacciones] add DepositarCansilleria bit;
alter table [WebSRM].[Transacciones] add ANombreQuien nvarchar(255);

  ALTER TABLE [CamaraWebsite].[WebSRM].[Socios]
  ALTER COLUMN Documento nvarchar(20) null

  --Agregar campo CantidadCopiaCertificaciones
ALTER TABLE [CamaraWebsite].[WebSRM].[Transacciones]
ADD CantidadCopiaCertificaciones int

--Crear tabla historico Transacciones
  create table [CamaraWebsite].[WebSRM].[HistoricoTransacciones]
  (
	ID int primary key identity (1,1),
	TransaccionId int,
	fecha dateTime,
	ServicioId int,
	estado int
  )
  GO

--Trigger HistorialTransacciones
  create trigger triggerHistorialTransacciones on [CamaraWebsite].[WebSRM].[Transacciones]
  after insert , update
  as
  begin
	if UPDATE(EstatusTransId)
			begin
			insert into [CamaraWebsite].[WebSRM].[HistoricoTransacciones]
			select inserted.TransaccionId, GETDATE(),
			inserted.ServicioId, inserted.EstatusTransId
			from inserted;
		end
  end
  go
  
      --Agregar campo EsPersona
ALTER TABLE [CamaraWebsite].[OFV].[EmpresasPorUsuario]
ADD EsPersona bit

--Modificacion trigger
USE [CamaraWebsite]
GO
/** Object:  Trigger [WebSRM].[triggerHistorialTransacciones]    Script Date: 8/13/2019 10:19:23 AM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  ALTER trigger [WebSRM].[triggerHistorialTransacciones] on [CamaraWebsite].[WebSRM].[Transacciones]
  after insert , update
  as
  begin
	if (UPDATE(EstatusTransId) or UPDATE(ServicioId))
			begin
			insert into [CamaraWebsite].[WebSRM].[HistoricoTransacciones]
			select inserted.TransaccionId, GETDATE(),
			inserted.ServicioId, inserted.EstatusTransId
			from inserted;
		end
  end


--modificacion trigger historio transacciones
USE [CamaraWebsite]
GO
/****** Object:  Trigger [WebSRM].[triggerHistorialTransacciones]    Script Date: 8/18/2019 10:13:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  ALTER trigger [WebSRM].[triggerHistorialTransacciones] on [CamaraWebsite].[WebSRM].[Transacciones]
  after insert , update
  as
  begin
	if (UPDATE(EstatusTransId))
			begin
			insert into [CamaraWebsite].[WebSRM].[HistoricoTransacciones]
			select inserted.TransaccionId, GETDATE(),
			inserted.ServicioId, inserted.EstatusTransId
			from inserted;
		end
  end