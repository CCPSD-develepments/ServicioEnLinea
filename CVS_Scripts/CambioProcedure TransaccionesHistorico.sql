USE [CamaraSDQ]
GO
/****** Object:  StoredProcedure [Website].[pGetTransaccionesHistorico]    Script Date: 6/27/2019 11:04:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Website].[pGetTransaccionesHistorico] ( @TransaccionId INT )
AS 
    BEGIN

        WITH    Trans ( TransaccionId, Fecha, TipoTransaccionId, TipoServicioId, Salicitante, RNCSolicitante, NombreContacto, TelefonoContacto, FaxContacto, NoReciboDGII, FechaReciboDGII, MontoDGII, DestinoTraslado, Comentario, ComentarioHtml, FlowId, Estatus, Estatus2, Prioridad, CustomString1, CustomString2, CustomString3, CustomInt1, CustomInt2, CustomInt3, CustomDateTime1, CustomDateTime2, CustomDecimal1, CustomDecimal2, FechaModificacion, rowguid, Tipo, NCF, UsuarioId, HoraInicio, HoraFinal, Receptor, TipoNcf, UbicacionExpedienteId, UbicacionExterna, TipoServicio, Servicio, TipoServicioSufijo, TransaccionIdAnterior )
                  AS ( SELECT   TransaccionId ,
                                Fecha ,
                                TipoTransaccionId ,
                                TipoServicioId ,
                                Salicitante ,
                                RNCSolicitante ,
                                NombreContacto ,
                                TelefonoContacto ,
                                FaxContacto ,
                                NoReciboDGII ,
                                FechaReciboDGII ,
                                MontoDGII ,
                                DestinoTraslado ,
                                Comentario ,
                                ComentarioHtml ,
                                FlowId ,
                                Estatus ,
                                Estatus2 ,
                                Prioridad ,
                                CustomString1 ,
                                CustomString2 ,
                                CustomString3 ,
                                CustomInt1 ,
                                CustomInt2 ,
                                CustomInt3 ,
                                CustomDateTime1 ,
                                CustomDateTime2 ,
                                CustomDecimal1 ,
                                CustomDecimal2 ,
                                FechaModificacion ,
                                rowguid ,
                                Tipo ,
                                NCF ,
                                UsuarioId ,
                                HoraInicio ,
                                HoraFinal ,
                                Receptor ,
                                TipoNcf ,
                                UbicacionExpedienteId ,
                                UbicacionExterna ,
                                TipoServicio ,
                                Servicio ,
                                TipoServicioSufijo ,
                                TransaccionIdAnterior
                       FROM     Transaccion.Transacciones AS tCam WITH (NOLOCK)
                       WHERE    tCam.TransaccionId = @TransaccionId --@TransaccionId
                       --UNION ALL
                       --SELECT   tCam.TransaccionId ,
                       --         tCam.Fecha ,
                       --         tCam.TipoTransaccionId ,
                       --         tCam.TipoServicioId ,
                       --         tCam.Salicitante ,
                       --         tCam.RNCSolicitante ,
                       --         tCam.NombreContacto ,
                       --         tCam.TelefonoContacto ,
                       --         tCam.FaxContacto ,
                       --         tCam.NoReciboDGII ,
                       --         tCam.FechaReciboDGII ,
                       --         tCam.MontoDGII ,
                       --         tCam.DestinoTraslado ,
                       --         tCam.Comentario ,
                       --         tCam.ComentarioHtml ,
                       --         tCam.FlowId ,
                       --         tCam.Estatus ,
                       --         tCam.Estatus2 ,
                       --         tCam.Prioridad ,
                       --         tCam.CustomString1 ,
                       --         tCam.CustomString2 ,
                       --         tCam.CustomString3 ,
                       --         tCam.CustomInt1 ,
                       --         tCam.CustomInt2 ,
                       --         tCam.CustomInt3 ,
                       --         tCam.CustomDateTime1 ,
                       --         tCam.CustomDateTime2 ,
                       --         tCam.CustomDecimal1 ,
                       --         tCam.CustomDecimal2 ,
                       --         tCam.FechaModificacion ,
                       --         tCam.rowguid ,
                       --         tCam.Tipo ,
                       --         tCam.NCF ,
                       --         tCam.UsuarioId ,
                       --         tCam.HoraInicio ,
                       --         tCam.HoraFinal ,
                       --         tCam.Receptor ,
                       --         tCam.TipoNcf ,
                       --         tCam.UbicacionExpedienteId ,
                       --         tCam.UbicacionExterna ,
                       --         tCam.TipoServicio ,
                       --         tCam.Servicio ,
                       --         tCam.TipoServicioSufijo ,
                       --         tCam.TransaccionIdAnterior
                       --FROM     Transaccion.Transacciones AS tCam WITH (NOLOCK)
                       --         INNER JOIN trans ON trans.TransaccionId = tCam.TransaccionIdAnterior
                     )
            SELECT  *
            FROM    Trans



    END

