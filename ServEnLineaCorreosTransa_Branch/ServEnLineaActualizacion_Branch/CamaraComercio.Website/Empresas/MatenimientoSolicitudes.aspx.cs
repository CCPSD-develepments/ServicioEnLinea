using CamaraComercio.DataAccess.EF;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static CamaraComercio.DataAccess.EF.OficinaVirtual.SociedadesRepository;

namespace CamaraComercio.Website.Empresas
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MatenimientoSolicitudes'
    public partial class MatenimientoSolicitudes : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MatenimientoSolicitudes'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MatenimientoSolicitudes.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MatenimientoSolicitudes.Page_Load(object, EventArgs)'
        {





        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MatenimientoSolicitudes.GetNuevasSociedadesPendientesDttodos()'
        public System.Data.DataTable GetNuevasSociedadesPendientesDttodos()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MatenimientoSolicitudes.GetNuevasSociedadesPendientesDttodos()'
        {
            var socPendientes = GetNuevasSociedadesPendientesGeneral();
            return socPendientes.ToDataTable();
        }


        private const int Completado = 14, Cancelado = 13, Devuelto = 18;
        CamaraWebsiteEntities db = new CamaraWebsiteEntities();

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MatenimientoSolicitudes.GetNuevasSociedadesPendientesGeneral()'
        public IEnumerable<SociedadOfvDTO> GetNuevasSociedadesPendientesGeneral()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MatenimientoSolicitudes.GetNuevasSociedadesPendientesGeneral()'
        {
           // var db = this.Session;
            //Estatus que no se deberian mostrar en Transacciones en Proceso
            List<int> estatus = new List<int>() { Completado, Cancelado, Devuelto };

            //Estatus de transacciones cerradas
            var reader = new AppSettingsReader();
            var str = (string)reader.GetValue("IdEstatusTransaccionesCerradas", typeof(string));
            var estatusTransCerrados = str.Split(',').Select(c => int.Parse(c)).ToList();

            //Usuarios
            var dbUsers = new CamaraComercio.DataAccess.EF.Membership.CamaraWebsiteAccountsEntities();
            var uHijos = dbUsers.ViewProfileProperties.ToList().Select(c => c.UserName).ToList();

            ////Determinar usuario padre
            //var uPadre = dbUsers.ViewProfileProperties.Where(c => c.UserName == username).Select(c => c.UsuarioPadre).FirstOrDefault();

            //Transacciones
            var transacciones = db.Transacciones
                //.Where(t => (t.UserName == username || uHijos.Contains(t.UserName) || t.UserName == uPadre)
                .Where(t => (t.UserName != "" || uHijos.Contains(t.UserName))
                    && (!t.ServicioVentanillaUnica.HasValue || t.ServicioVentanillaUnica == false)
                    && (!t.SubTransaccionId.HasValue)
                    && !estatusTransCerrados.Contains(t.EstatusTransId))
                .Select(t => new { t.NumeroRegistro, t.CamaraId, t.TransaccionId, t.Fecha, t.NombreSocialPersona, t.TipoSociedadId, t.EstatusTransId, t.ServicioId });

            #region Obtener Transacciones Pendientes 
            var sociedades = (from trans in transacciones
                              join est in db.EstatusTransacciones on trans.EstatusTransId equals est.EstatusTransId
                              where (!estatus.Contains(trans.EstatusTransId) && !estatus.Contains(trans.EstatusTransId))
                              orderby trans.Fecha descending
                              select new SociedadOfvDTO
                              {
                                  TransaccionID = trans.TransaccionId,
                                  CamaraID = trans.CamaraId,
                                  FechaSolicitud = trans.Fecha,
                                  NombreSocial = trans.NombreSocialPersona,
                                  RegistroID = trans.NumeroRegistro,
                                  TipoSociedadID = trans.TipoSociedadId,
                                  EstatusTransaccion = est.EstatusTransDescripcion,
                                  EstatusId = est.EstatusTransId,
                                  ServicioId = trans.ServicioId
                              }).ToList();

            //Nombres de tipos de servicios
            foreach (var item in sociedades)
            {
                var nombreServicio = new DataAccess.EF.CamaraComun.CamaraComunEntities()
                  .Servicio.Where(s => s.ServicioId == item.ServicioId).FirstOrDefault()?.Descripcion;
                item.Servicio = nombreServicio;
            }
            #endregion

            return sociedades;
        }


    }
}