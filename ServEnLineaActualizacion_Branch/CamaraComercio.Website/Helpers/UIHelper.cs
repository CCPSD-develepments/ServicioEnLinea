using System;
using System.Collections.Generic;
using CamaraComercio.DataAccess.EF.SRM;
using CamaraComercio.DataAccess.EF;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website
{
    /// <summary>
    /// Expone métodos que ayudan con la renderizacion de 
    /// iconos en la interfaz del usuario
    /// </summary>
    public class StatusIconHelper
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'StatusIconHelper.GetStatusIcon(int)'
        public string GetStatusIcon(int statusId)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'StatusIconHelper.GetStatusIcon(int)'
        {
            var db = new OFV.CamaraWebsiteEntities();
            var repEstatus = new Repository<OFV.EstatusTransacciones, OFV.CamaraWebsiteEntities>(db);
            var estatus = repEstatus.SelectByKey(OFV.EstatusTransacciones.PropColumns.EstatusTransId, statusId);

            if (estatus == null)
                return String.Empty;

            return estatus.EstatusTransDescripcion ?? "";
        }
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ExtendedSociedadesEstatusEnum'
    public static class ExtendedSociedadesEstatusEnum
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ExtendedSociedadesEstatusEnum'
    {
        /// <summary>
        /// Obtiene el icono relacionado con el estado de la empresa
        /// </summary>
        /// <param name="seid"></param>
        /// <returns></returns>
        public static string GetIconUrl(this SociedadesEstatudId seid)
        {
            string url;
            var dictionary = new Dictionary<SociedadesEstatudId, string>
                                 {
                                     {SociedadesEstatudId.Activa, "/res/img/icons/bullet_green.png"},
                                     {SociedadesEstatudId.Disuelta, "/res/img/icons/bullet_red.png"},
                                     {SociedadesEstatudId.CeseTemporal, "/res/img/icons/bullet_black.png"},
                                     {SociedadesEstatudId.Fusionada, "/res/img/icons/bullet_black.png"},
                                     {SociedadesEstatudId.Trasladada, "/res/img/icons/bullet_black.png"}
                                 };
            if (!dictionary.TryGetValue(seid, out url))
                url = "/res/img/icons/bullet_white.png";

            return url;
        }
    }

    /// <summary>
    /// Verifica si una transaccion fue realizada previamente
    /// </summary>
    public static class TransaccionesValidator
    {
        //cuando hayan cero referencias se dejó de usar
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransaccionesValidator.ExisteTransaccionActiva(string, int, int?, List<int>)'
        public static bool ExisteTransaccionActiva(string camaraId, int servicioId, int? numeroRegistro, List<int> statusCerrados)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransaccionesValidator.ExisteTransaccionActiva(string, int, int?, List<int>)'
        {
            var transRepSrm = new TransaccionesRepository(camaraId);

              if (transRepSrm.CountTransaccionActiva(servicioId, numeroRegistro, statusCerrados) > 0)
                return true;

            var transRep = new DataAccess.EF.OficinaVirtual.TransaccionesRepository();
            return transRep.CountTransaccionActiva(servicioId, numeroRegistro, statusCerrados) > 0;
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransaccionesValidator.ExisteTransaccionActivaMejora(string, int, int?, List<int>, int)'
        public static bool ExisteTransaccionActivaMejora(string camaraId, int servicioId, int? numeroRegistro, List<int> statusCerrados, int tipoSociedadId)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransaccionesValidator.ExisteTransaccionActivaMejora(string, int, int?, List<int>, int)'
        {
            var transRepSrm = new TransaccionesRepository(camaraId);

            if (transRepSrm.CountTransaccionActivaMejora(servicioId, numeroRegistro, statusCerrados,tipoSociedadId) > 0)
                return true;

            var transRep = new DataAccess.EF.OficinaVirtual.TransaccionesRepository();
            return transRep.CountTransaccionActivaMejora(servicioId, numeroRegistro, statusCerrados,tipoSociedadId) > 0;
        }


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransaccionesValidator.ExisteTransaccionActiva(string, List<int>, int?, List<int>)'
        public static bool ExisteTransaccionActiva(string camaraId, List<int> servicioId, int? numeroRegistro, List<int> statusCerrados)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransaccionesValidator.ExisteTransaccionActiva(string, List<int>, int?, List<int>)'
        {
            var transRepSrm = new TransaccionesRepository(camaraId);

            if (transRepSrm.CountTransaccionActiva(servicioId, numeroRegistro, statusCerrados) > 0)
                return true;

            var transRep = new DataAccess.EF.OficinaVirtual.TransaccionesRepository();
            return transRep.CountTransaccionActiva(servicioId, numeroRegistro, statusCerrados) > 0;
        }
    }
}