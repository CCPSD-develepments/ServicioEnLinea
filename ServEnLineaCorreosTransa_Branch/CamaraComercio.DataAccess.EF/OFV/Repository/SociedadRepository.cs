using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.SRM;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    /// <summary>
    /// Repositorio para el manejo de sociedades en Oficina Virtual
    /// </summary>
    [DataObject]
    public class SociedadesRepository : Repository<Sociedades, CamaraWebsiteEntities>
    {
        public static bool EstaCompleta(int transaccionId)
        {
            var dbWebSite = new CamaraWebsiteEntities();
            bool Completa = false;

            //Verifico que si la transaccion no tiene log por lo tanto esta se hizo antes del cambio
            // de grabar los log de la transaccion por lo tanto me tiene que permitir verla.
            var verificar = from tran in dbWebSite.LogTransacciones
                            where tran.TransaccionId.Equals(transaccionId)
                            select tran;

            if (verificar.Count() <= 0)
                return true;

            var query = from tran in dbWebSite.LogTransacciones
                        where tran.TransaccionId.Equals(transaccionId) && tran.Completed.Equals(true)
                        select tran;

            return query.Count() > 0;
        }

        //id Estatus Transacciones
        private const int Completado = 14, Cancelado = 13, Devuelto = 18;

        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        public SociedadesRepository()
            : base(new CamaraWebsiteEntities())
        {
        }

        /// <summary>
        /// Retorna todas las solicitudes de constitución activas para un usuario
        /// </summary>
        /// <param name="username">Nombre del usuario</param>
        /// <returns>Una colección IEnumerable de SociedadOfvDTO</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IEnumerable<SociedadOfvDTO> GetNuevasSociedadesPendientes(String username)
        {
            var db = this.Session;
            //Estatus que no se deberian mostrar en Transacciones en Proceso
            List<int> estatus = new List<int>() { Completado,Cancelado, Devuelto };
            
            //Estatus de transacciones cerradas
            var reader = new AppSettingsReader();
            var str = (string)reader.GetValue("IdEstatusTransaccionesCerradas", typeof(string));
            var estatusTransCerrados = str.Split(',').Select(c => int.Parse(c)).ToList();

            //Usuarios
            var dbUsers = new CamaraComercio.DataAccess.EF.Membership.CamaraWebsiteAccountsEntities();
            var uHijos = dbUsers.ViewProfileProperties
                        .Where(c => c.UsuarioPadre == username.ToLower()).Select(c => c.UserName).ToList();

            ////Determinar usuario padre
            //var uPadre = dbUsers.ViewProfileProperties.Where(c => c.UserName == username).Select(c => c.UsuarioPadre).FirstOrDefault();

            //Transacciones
            var transacciones = db.Transacciones
                //.Where(t => (t.UserName == username || uHijos.Contains(t.UserName) || t.UserName == uPadre)
                .Where(t => (t.UserName == username || uHijos.Contains(t.UserName))
                    && (!t.ServicioVentanillaUnica.HasValue || t.ServicioVentanillaUnica == false)
                    && (!t.SubTransaccionId.HasValue)
                    && !estatusTransCerrados.Contains(t.EstatusTransId) )
                .Select(t => new { t.NumeroRegistro, t.CamaraId, t.TransaccionId, t.Fecha, t.NombreSocialPersona, t.TipoSociedadId, t.EstatusTransId , t.ServicioId});

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
                var nombreServicio = new CamaraComun.CamaraComunEntities()
                  .Servicio.Where(s => s.ServicioId == item.ServicioId).FirstOrDefault()?.Descripcion;
                item.Servicio = nombreServicio;
            }
            #endregion

            return sociedades;
        }



        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IEnumerable<SociedadOfvDTO> GetNuevasSociedadesPendientesGeneral()
        {
            var db = this.Session;
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
                .Where(t => (t.UserName !=  "" || uHijos.Contains(t.UserName))
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
                var nombreServicio = new CamaraComun.CamaraComunEntities()
                  .Servicio.Where(s => s.ServicioId == item.ServicioId).FirstOrDefault()?.Descripcion;
                item.Servicio = nombreServicio;
            }
            #endregion

            return sociedades;
        }


        /// <summary>
        /// Retorna todas las solicitudes de constitución activas para un usuario
        /// </summary>
        /// <param name="username">Nombre del usuario</param>
        /// <returns>Una colección IEnumerable de SociedadOfvDTO</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IEnumerable<SociedadOfvDTO> GetNuevasSociedadesPendientesHijo(String username)
        {
            var db = this.Session;
            //Estatus que no se deberian mostrar en Transacciones en Proceso
            List<int> estatus = new List<int>() { Completado, Cancelado, Devuelto };

            //Estatus de transacciones cerradas
            var reader = new AppSettingsReader();
            var str = (string)reader.GetValue("IdEstatusTransaccionesCerradas", typeof(string));
            var estatusTransCerrados = str.Split(',').Select(c => int.Parse(c)).ToList();

            //Transacciones
            var transacciones = db.Transacciones
                .Where(t => t.UserName == username
                    && (!t.ServicioVentanillaUnica.HasValue || t.ServicioVentanillaUnica == false)
                    && (!t.SubTransaccionId.HasValue)
                    && !estatusTransCerrados.Contains(t.EstatusTransId))
                .Select(t => new { t.RegistroId, t.CamaraId, t.TransaccionId, t.Fecha, t.NombreSocialPersona, t.TipoSociedadId, t.EstatusTransId });

            //Tipos de empresa
            var dbComun = new Comun.CamaraComunEntities();
            var tiposSociedades = dbComun.TipoSociedad.Where(ts => ts.Visible == true)
                                    .Select(ts => new { ts.TipoSociedadId, ts.Descripcion, ts.Etiqueta }).ToList();

            #region Obtener Transacciones Pendientes 
            var sociedades = (from trans in transacciones
                              join est in db.EstatusTransacciones on trans.EstatusTransId equals est.EstatusTransId
                              where (!estatus.Contains(trans.EstatusTransId))
                              orderby trans.Fecha descending
                              select new SociedadOfvDTO
                              {
                                  TransaccionID = trans.TransaccionId,
                                  CamaraID = trans.CamaraId,
                                  FechaSolicitud = trans.Fecha,
                                  NombreSocial = trans.NombreSocialPersona,
                                  RegistroID = trans.RegistroId,
                                  TipoSociedadID = trans.TipoSociedadId,
                                  EstatusTransaccion = est.EstatusTransDescripcion,
                                  EstatusId = est.EstatusTransId,
                              }).ToList();

            //Nombres de tipos de empresas
            foreach (var item in sociedades)
            {
                var tipoSoc = tiposSociedades.Where(ts => ts.TipoSociedadId == item.TipoSociedadID).FirstOrDefault();
                EstatusTransacciones srmEstatus = TransaccionesController.GetUltimoEstado(item.TransaccionID);
                if (tipoSoc != null)
                {
                    item.TipoSociedad = tipoSoc.Descripcion;
                    item.SiglasTipoSociedad = tipoSoc.Etiqueta;
                    //Asignando el id del nuevo estatus del srm a las transacciones que ya han sido trabajadas
                    if (!string.IsNullOrEmpty(srmEstatus.EstatusTransDescripcion))
                    {
                        item.EstatusId = srmEstatus.EstatusTransId;
                        item.EstatusTransaccion = srmEstatus.EstatusTransDescripcion;
                    }
                }
                else
                {
                    item.TipoSociedad = "Certificacion";
                    item.SiglasTipoSociedad = "CERT";

                    if (!string.IsNullOrEmpty(srmEstatus.EstatusTransDescripcion))
                    {
                        item.EstatusId = srmEstatus.EstatusTransId;
                        item.EstatusTransaccion = srmEstatus.EstatusTransDescripcion;
                    }
                }

                if (!EstaCompleta(item.TransaccionID))
                    item.EstatusTransaccion = "Solicitud Incompleta";
            }
            //Si estas transacciones estan completada, cancelada o devuelta entonce excluir
            var sociedadesPendientes = from soc in sociedades
                                       where (!estatus.Contains(soc.EstatusId))
                                       select soc;

            #endregion

            return sociedadesPendientes;
        }

        /// <summary>
        /// Retorna todas las solicitudes de constitución activas para un usuario
        /// </summary>
        /// <param name="username">Nombre del usuario</param>
        /// <returns>Retorna un objeto DataTable con a partir de una colección IEnumerable de SociedadOfvDTO</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public System.Data.DataTable GetNuevasSociedadesPendientesDt(String username)
        {
            
            var socPendientes = GetNuevasSociedadesPendientes(username);
            return socPendientes.ToDataTable();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public System.Data.DataTable GetNuevasSociedadesPendientesDttodos()
        {
            var socPendientes = GetNuevasSociedadesPendientesGeneral();
            return socPendientes.ToDataTable();
        }


        /// <summary>
        /// Retorna todas las solicitudes de constitución activas para un usuario
        /// </summary>
        /// <param name="username">Nombre del usuario</param>
        /// <returns>Retorna un objeto DataTable con a partir de una colección IEnumerable de SociedadOfvDTO</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public System.Data.DataTable GetNuevasSociedadesPendientesHijoDt(String username)
        {
            var socPendientes = GetNuevasSociedadesPendientesHijo(username);
            return socPendientes.ToDataTable();
        }

        /// <summary>
        /// Clase DTO que representa una sociedad
        /// </summary>
        public class SociedadOfvDTO
        {
            /// <summary>
            /// ID de la transacción
            /// </summary>
            public int TransaccionID { get; set; }

            /// <summary>
            /// ID de la cámara de comercio
            /// </summary>
            public string CamaraID { get; set; }

            /// <summary>
            /// Número de registro mercantil
            /// </summary>
            public int? RegistroID { get; set; }

            /// <summary>
            /// ID de la sociedad
            /// </summary>
            public int SociedadID { get; set; }

            /// <summary>
            /// ID del tipo de sociedad
            /// </summary>
            public int? TipoSociedadID { get; set; }

            /// <summary>
            /// Nombre / razón social de la empresa o sociedad
            /// </summary>
            public string NombreSocial { get; set; }

            /// <summary>
            /// Descripcion del tipo de sociedad
            /// </summary>
            public string TipoSociedad { get; set; }

            /// <summary>
            /// Siglas del tipo de sociedad
            /// </summary>
            public string SiglasTipoSociedad { get; set; }

            /// <summary>
            /// Fecha de solicitud de la transacción
            /// </summary>
            public DateTime? FechaSolicitud { get; set; }

            /// <summary>
            /// Estatus de las transacciones
            /// </summary>
            public string EstatusTransaccion { get; set; }
            
            /// <summary>
            ///Id del estatus 
            /// </summary>
            public int EstatusId { get; set; }
            /// <summary>
            /// Nombre del servicio
            /// </summary>
            public string Servicio { get; set; }
            /// <summary>
            /// Id del servicio
            /// </summary>

            public int ServicioId { get; set; }
        }
    }
}
