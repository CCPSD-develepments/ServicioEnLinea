using CamaraComercio.DataAccess.EF.CamaraComun;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    /// <summary>
    /// Controlador para Transacciones en la Oficina Virtual
    /// </summary>
    [DataObject]
    public class TransaccionesController
    {
        #region Transacciones Historia
        /// <summary>
        /// Obtiene el histórico de transacciones de un usuario a partir de su ID
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <param name="Estatus"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Transacciones> GetTransaccionesHistoria(string userId, int startRowIndex = 0, int maximumRows = 10, int Estatus = 15)
        {
            userId = userId.ToLower();
            //Aqui el usuario selecciono Ningunas
            if (Estatus.Equals(0))
            {
                return new List<Transacciones>();
            }
            //Aqui el usuario selecciono las transacciones canceladas. 
            else if (Estatus.Equals(1))
            {
                var dbUsers = new Membership.CamaraWebsiteAccountsEntities();
                var uHijos = dbUsers.ViewProfileProperties
                            .Where(c => c.UsuarioPadre == userId).ToList()
                            .Select(c => c.UserName.ToLower()).ToList();

                var uPadre = dbUsers.ViewProfileProperties.Where(c => c.UserName == userId).Select(c => c.UsuarioPadre).FirstOrDefault();

                List<Transacciones> trSrm = new List<Transacciones>();
                var db = new CamaraWebsiteEntities();

                
                var transac = from tr in db.TransaccionesCanceladas
                              where (tr.UserName == userId || uHijos.Contains(tr.UserName) /*|| tr.UserName == uPadre*/) && (!tr.SubTransaccionId.HasValue)
                              select tr;

                foreach (var transaccion in transac)
                {
                    Transacciones tr = new Transacciones();
                    tr.ApellidoPersona = transaccion.ApellidoPersona;
                    tr.bLoadedInSRM = transaccion.bLoadedInSRM;
                    tr.bPagada = false;
                    tr.CamaraId = transaccion.CamaraId;
                    tr.CapitalSocial = transaccion.CapitalSocial;
                    tr.Comentario = transaccion.Comentario;
                    tr.DestinoTraslado = transaccion.DestinoTraslado;
                    //tr.EsDigital = false;
                    tr.EstatusTransId = 13; //Cancelada
                    EstatusTransacciones estatus = new EstatusTransacciones();
                    estatus.EstatusTranNombre = "Cancelado";
                    estatus.EstatusTransDescripcion = "Cancelado";
                    estatus.EstatusTransId = 13;
                    tr.EstatusTransacciones = estatus;
                    tr.FaxContacto = transaccion.FaxContacto;
                    tr.Fecha = transaccion.Fecha.Value;
                    tr.FechaAsamblea = transaccion.FechaAsamblea;
                    tr.FechaReciboDGII = transaccion.FechaReciboDGII;
                    tr.InstanceXML = transaccion.InstanceXML;
                    tr.ModificacionCapital = transaccion.ModificacionCapital;
                    tr.MontoDGII = transaccion.MontoDGII;
                    tr.NCF = transaccion.NCF;
                    tr.NombreContacto = transaccion.NombreContacto;
                    tr.NombreSocialPersona = transaccion.NombreSocialPersona;
                    tr.NoReciboDGII = transaccion.NoReciboDGII;
                    tr.NumeroRegistro = transaccion.NumeroRegistro;
                    tr.Prioridad = transaccion.Prioridad.Value;
                    //tr.ReCheck = false;
                    tr.RegistroId = transaccion.RegistroId.Value;
                    tr.RNCSolicitante = transaccion.RNCSolicitante;
                    tr.ServicioId = transaccion.ServicioId.Value;
                    tr.Solicitante = transaccion.Solicitante;
                    tr.SrmTransaccionId = transaccion.SrmTransaccionId;
                    tr.SubTransaccionId = transaccion.SubTransaccionId;
                    tr.TelefonoContacto = transaccion.TelefonoContacto;
                    tr.Tipo = transaccion.Tipo;
                    tr.TipoComprobanteId = transaccion.TipoComprobanteId;
                    tr.TipoModeloId = transaccion.TipoModeloId;
                    tr.TipoNcf = transaccion.TipoNcf;
                    tr.TipoSociedadId = transaccion.TipoSociedadId.Value;
                    tr.Token = transaccion.Token;
                    tr.TransaccionId = transaccion.TransaccionId;
                    tr.UserName = transaccion.UserName;
                    //tr.VieneProblema = false;

                    trSrm.Add(tr);
                }

                var query = (from c in trSrm
                             where (c.UserName == userId || uHijos.Contains(c.UserName) || c.UserName == uPadre) && (!c.SubTransaccionId.HasValue)
                             orderby c.Fecha descending
                             select c).Skip(startRowIndex).Take(startRowIndex + maximumRows).ToList();

                var ids = query.Select(t => t.ServicioId).Distinct();

                var nombreServicios = new CamaraComun.CamaraComunEntities()
                    .Servicio.Where(s => ids.Contains(s.ServicioId))
                    .Select(s => new { s.ServicioId, s.Descripcion }).ToList();

                foreach (var t in query.Where(t => nombreServicios.FirstOrDefault(n => n.ServicioId == t.ServicioId) != null))
                {
                    t.NombreServicio = nombreServicios.First(n => n.ServicioId == t.ServicioId).Descripcion;
                }


                return query;
            }
            else
            {
                var dbUsers = new Membership.CamaraWebsiteAccountsEntities();
                var uHijos = dbUsers.ViewProfileProperties
                            .Where(c => c.UsuarioPadre == userId).ToList()
                            .Select(c => c.UserName.ToLower()).ToList();

                //determinar usuario padre
                var uPadre = dbUsers.ViewProfileProperties.Where(c => c.UserName == userId).Select(c => c.UsuarioPadre).FirstOrDefault();

                List<Transacciones> trSrm = new List<Transacciones>();
                var db = new CamaraWebsiteEntities();

                var transac = from tr in db.Transacciones
                              where (tr.UserName == userId || uHijos.Contains(tr.UserName) /*|| tr.UserName == uPadre*/) && (!tr.SubTransaccionId.HasValue)
                              select tr;

                //Aqui cargo la transaccion seleccionada.
                LoadTransacciones(Estatus, transac);

                foreach (var item in transac)
                {
                    if (!item.Deleted)
                        trSrm.Add(item);
                }
                var query = (from c in trSrm
                             orderby c.Fecha descending
                             select c).Skip(startRowIndex).Take(startRowIndex + maximumRows).ToList();

                var ids = query.Select(t => t.ServicioId).Distinct();

                var nombreServicios = new CamaraComun.CamaraComunEntities()
                    .Servicio.Where(s => ids.Contains(s.ServicioId))
                    .Select(s => new { s.ServicioId, s.Descripcion }).ToList();

                foreach (var t in query.Where(t => nombreServicios.FirstOrDefault(n => n.ServicioId == t.ServicioId) != null))
                {
                    t.NombreServicio = nombreServicios.First(n => n.ServicioId == t.ServicioId).Descripcion;
                }

                return query;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IEnumerable<HistoricoTransacciones> HistoricoLlenado(int transaccion, int maximumRows = 1, int startRowIndex = 10)
        {
            var dbOfv = new CamaraWebsiteEntities();
            var comun = new CamaraComunEntities();
            var result = new List<HistoricoTransacciones>();
            var sortHistoria = new List<HistoricoTransacciones>();
            var historia = dbOfv.HistoricoTransacciones.Where(x => x.TransaccionId == transaccion).OrderBy(x => x.fecha);

            foreach (var item in historia)
            {
                if (sortHistoria.Count != 0)
                {
                    if (item.estado == sortHistoria.Last().estado) continue;
                    sortHistoria.Add(item);
                }
                else
                    sortHistoria.Add(item);
            }

            if (historia != null)
            {
                result.AddRange(sortHistoria);
            }
            return result.Skip(maximumRows).Take(maximumRows + startRowIndex).ToList();
        }

        public int countHistoricoLLenado(int transaccion)
        {
            var dbOfv = new CamaraWebsiteEntities();
            var comun = new CamaraComunEntities();
            var result = new List<HistoricoTransacciones>();
            var sortHistoria = new List<HistoricoTransacciones>();
            var historia = dbOfv.HistoricoTransacciones.Where(x => x.TransaccionId == transaccion).OrderBy(x => x.fecha);

            foreach (var item in historia)
            {
                if (sortHistoria.Count != 0)
                {
                    if (item.estado == sortHistoria.Last().estado) continue;
                    sortHistoria.Add(item);
                }
                else
                    sortHistoria.Add(item);
            }

            if (historia != null)
            {
                result.AddRange(sortHistoria);
            }
            return result.Count;
        }


        private static void LoadTransacciones(int Estatus, IQueryable<Transacciones> transac)
        {
            var estaddo = GetUltimoEstado(transac.ToList());
            foreach (var item in transac)
            {
                EstatusTransaccionesResult srmEstatus = estaddo.Where(x => x.TransactionId == item.TransaccionId).FirstOrDefault();
                // EstatusTransacciones srmEstatus = GetUltimoEstado(item.TransaccionId);
                if (!string.IsNullOrEmpty(srmEstatus?.EstatusTransDescripcion))
                {
                    //item.EstatusTransId = srmEstatus.EstatusTransId;
                    //item.EstatusTransacciones.EstatusTranNombre = srmEstatus.EstatusTranNombre;
                    //item.EstatusTransacciones.EstatusTransDescripcion = srmEstatus.EstatusTransDescripcion;
                    //item.EstatusTransacciones.EstatusTransId = srmEstatus.EstatusTransId;

                    if (Estatus > 0)
                    {
                        //if (Estatus == 15)
                        //{
                        //    if (srmEstatus.EstatusTransId.Equals(42) && !Estatus.Equals(9999))
                        //        item.Deleted = false;
                        //    else if (!srmEstatus.EstatusTransId.Equals(Estatus) && !Estatus.Equals(9999))
                        //        item.Deleted = true;
                        //}
                        //else
                        //{
                            if (!srmEstatus.EstatusTransId.Equals(Estatus) && !Estatus.Equals(9999))
                                item.Deleted = true;
                        //}
                    }
                }

                // item.EnvioDesc = item.EsDigital ? "Digital" : "Fisico";
            }
        }

        /// <summary>
        /// Obtiene el histórico de transacciones de un usuario a partir de su ID
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <param name="estatus"></param>
        /// <returns>Retorna un DataTable</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public System.Data.DataTable GetTransaccionesHistoriaDt(string userId, int startRowIndex = 0, int maximumRows = 10, int estatus = 0)
        {
            var c = GetTransaccionesByEstatus(userId, startRowIndex, maximumRows, estatus);
            return c.ToDataTable();
        }
        public List<Transacciones> GetTransaccionesByEstatus(string userId, int startRowIndex = 0, int maximumRows = 10, int estatus = 0)
        {
            List<Transacciones> transacciones = new List<Transacciones>();

            var dbUsers = new Membership.CamaraWebsiteAccountsEntities();
            var uHijos = dbUsers.ViewProfileProperties.Where(c => c.UsuarioPadre == userId).ToList().Select(c => c.UserName.ToLower()).ToList();

            var uPadre = dbUsers.ViewProfileProperties.Where(c => c.UserName == userId).Select(c => c.UsuarioPadre).FirstOrDefault();

            List<Transacciones> trSrm = new List<Transacciones>();
            var db = new CamaraWebsiteEntities();

            var transac = from tr in db.Transacciones
                          where (tr.UserName == userId || uHijos.Contains(tr.UserName) /*|| tr.UserName == uPadre*/) && (!tr.SubTransaccionId.HasValue)
                          select tr;
            if (estatus == 9999)
            {
                transacciones.AddRange(transac);
            }
            else
            {

                transacciones.AddRange(transac.Where(c => c.EstatusTransId == estatus).ToList());
            }
            return transacciones;
        }
        /// <summary>
        /// cOUNT 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <param name="estatus"></param>
        /// <returns>rETORNA INT</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public int GetCountTransaccionesHistoriaDt(string userId, int startRowIndex = 0, int maximumRows = 10, int Estatus = 0)
        {
            var c = GetTransaccionesByEstatus(userId, startRowIndex, maximumRows, Estatus);
            return c.Count();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public System.Data.DataTable GetTransaccionesHistoriaDtP(string userId, int startRowIndex = 0, int maximumRows = 10, int estatus = 15)
        {
            var trans = GetTransaccionesHistoria(userId.ToLower(), startRowIndex, int.MaxValue, estatus);
            var a = new List<Transacciones>();

            foreach (var item in trans)
            {
                if (item != null)
                {
                    if (item.EstatusTransId == 15 || item.EstatusTransId == 40 || item.EstatusTransId == 42)
                    {
                        a.Add(item);
                    }
                }
            }
            return a.ToDataTable();
        }

        /// <summary>
        /// cOUNT 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <param name="estatus"></param>
        /// <returns>rETORNA INT</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public int GetCountTransaccionesHistoriaDtP(string userId, int startRowIndex = 0, int maximumRows = 10, int Estatus = 15)
        {
            var trans = GetTransaccionesHistoria(userId, 0, int.MaxValue, Estatus);
            var a = new List<Transacciones>();

            foreach (var item in trans)
            {
                if (item != null)
                {
                    if (item.EstatusTransId == 15 || item.EstatusTransId == 40 || item.EstatusTransId == 42)
                    {
                        a.Add(item);
                    }
                }
            }
            return a.Count();
        }

        /// <summary>
        /// Retorna la cantidad de Transacciones Historicas asociadas a una Transacción.
        /// </summary>
        /// <param name="transaccionId">User Id del Usuario.</param>
        /// <remarks>Se adicionan los parametros opcionales startRowIndex y maximumRows 
        /// para cumplir con el signature de algunos object data sources</remarks>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public int GetCountTransaccionesHistoria(int transaccionId)
        {
            return GetTransaccionHistoria(transaccionId, int.MinValue, int.MaxValue).Count;
        }
        /// <summary>
        /// Retorna la cantidad de Transacciones Historicas asociadas a una Transacción.
        /// </summary>
        /// <param name="transaccionId">User Id del Usuario.</param>
        /// <remarks>Se adicionan los parametros opcionales startRowIndex y maximumRows 
        /// para cumplir con el signature de algunos object data sources</remarks>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public int GetCountTransaccionesHistoria(int transaccionId, int Estatus)
        {
            return GetTransaccionHistoria(transaccionId, int.MinValue, int.MaxValue, Estatus).Count;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public int GetCountTransaccionesHistoria(string userId, int startRowIndex = 0, int maximumRows = 10, int Estatus = 0)
        {
            //Aqui el usuario selecciono Ningunas
            if (Estatus.Equals(0)) return 0;

            //Aqui el usuario selecciono las transacciones canceladas. 
            else if (Estatus.Equals(1))
            {
                var dbUsers = new Membership.CamaraWebsiteAccountsEntities();
                var uHijos = dbUsers.ViewProfileProperties
                            .Where(c => c.UsuarioPadre == userId).ToList()
                            .Select(c => c.UserName.ToLower()).ToList();

                var uPadre = dbUsers.ViewProfileProperties.Where(c => c.UserName == userId).Select(c => c.UsuarioPadre).FirstOrDefault();

                var db = new CamaraWebsiteEntities();

                var transac = from tr in db.TransaccionesCanceladas
                              where (tr.UserName == userId || uHijos.Contains(tr.UserName) || tr.UserName == uPadre) && (!tr.SubTransaccionId.HasValue)
                              select tr;

                var count = (from c in transac
                             where (c.UserName == userId || uHijos.Contains(c.UserName) || c.UserName == uPadre) && (!c.SubTransaccionId.HasValue)
                             orderby c.Fecha descending
                             select c).Count();

                return count;
            }
            else
            {
                var dbUsers = new Membership.CamaraWebsiteAccountsEntities();
                var uHijos = dbUsers.ViewProfileProperties
                            .Where(c => c.UsuarioPadre == userId).ToList()
                            .Select(c => c.UserName.ToLower()).ToList();

                //determinar usuario padre
                var uPadre = dbUsers.ViewProfileProperties.Where(c => c.UserName == userId).Select(c => c.UsuarioPadre).FirstOrDefault();

                List<Transacciones> trSrm = new List<Transacciones>();
                var db = new CamaraWebsiteEntities();
                var transac = from tr in db.Transacciones
                              where (tr.UserName == userId || uHijos.Contains(tr.UserName) || tr.UserName == uPadre) && (!tr.SubTransaccionId.HasValue)
                              select tr;

                //Aqui cargo la transaccion seleccionada.
                LoadTransacciones(Estatus, transac);

                foreach (var item in transac)
                {
                    if (!item.Deleted)
                        trSrm.Add(item);
                }

                var count = (from c in trSrm
                             where (c.UserName == userId || uHijos.Contains(c.UserName) || c.UserName == uPadre) && (!c.SubTransaccionId.HasValue)
                             orderby c.Fecha descending
                             select c).Count();

                return count;
            }

            //var db = new CamaraWebsiteEntities();
            //var query = db.Transacciones.Where(a => a.UserName == userId);
            //return query.ToList().Count;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public bool HasTransaccionesDevueltas(string userId)
        {
            using (var db = new CamaraWebsiteEntities())
            {
                return db.Transacciones.Where(a => a.UserName == userId).Any(d => d.UserName == userId && d.EstatusTransId == 15);
            }
        }

        /// <summary>
        /// Retorna la cantidad de Transacciones de un usuario.
        /// </summary>
        /// <param name="userId">User Id del Usuario.</param>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <remarks>Se adicionan los parametros opcionales startRowIndex y maximumRows 
        /// para cumplir con el signature de algunos object data sources</remarks>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public int GetCountTransaccionesHistoria(string userId, int startRowIndex = 0, int maximumRows = 10)
        {
            var db = new CamaraWebsiteEntities();
            var query = db.Transacciones.Where(a => a.UserName == userId);
            return query.ToList().Count;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static List<TransaccionHistorico> GetTransaccionHistoria(int transaccionId, int startRowIndex = 0, int maximumRows = 10)
        {
            var db = new CamaraWebsiteEntities();

            //Lista que contendra la historia
            var result = new List<TransaccionHistorico>();

            //Transaccion del WebSite
            var transWebSite = db.Transacciones.Where(a => a.TransaccionId == transaccionId).AsEnumerable()
                .Select(a => new TransaccionHistorico
                {
                    TransaccionId = a.TransaccionId,
                    Fecha = a.Fecha,
                    SrmTransaccionId = a.SrmTransaccionId,
                    CamaraId = a.CamaraId,
                    EstatusTransId = a.EstatusTransId,
                    ServicioId = a.ServicioId,
                    TipoSociedadId = a.TipoSociedadId
                })
                .FirstOrDefault();


            if (transWebSite != null)
            {
                result.Add(transWebSite);
                if (transWebSite.SrmTransaccionId.HasValue)
                {
                    var dbSRM = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(transWebSite.CamaraId);

                    var transHistoria = dbSRM.pGetTransaccionesHistorico(transWebSite.SrmTransaccionId).AsEnumerable()
                        .Select(a => new TransaccionHistorico
                        {
                            TransaccionId = a.TransaccionId.GetValueOrDefault(),
                            Fecha = a.FechaModificacion,
                            CamaraId = transWebSite.CamaraId,
                            ServicioId = a.TipoServicioId.GetValueOrDefault(),
                            EstatusTransId = a.Estatus.GetValueOrDefault(),
                            TipoSociedadId = a.CustomInt1.GetValueOrDefault()

                        }).ToList();
                    result.AddRange(transHistoria);
                }
            }
            return result.Skip(startRowIndex).Take(maximumRows).ToList();
        }

        /// <summary>
        /// Obtiene todas las transacciones hijas realizadas a partir de una transacción.
        /// </summary>
        /// <param name="transaccionId">Id de la Transaccion Padre.</param>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static List<TransaccionHistorico> GetTransaccionHistoria(int transaccionId, int startRowIndex = 0, int maximumRows = 10, int estatus = 0)
        {
            var db = new CamaraWebsiteEntities();

            //Lista que contendra la historia
            var result = new List<TransaccionHistorico>();

            //Transaccion del WebSite
            var transWebSite = db.Transacciones.Where(a => a.TransaccionId == transaccionId).AsEnumerable()
                .Select(a => new TransaccionHistorico
                {
                    TransaccionId = a.TransaccionId,
                    Fecha = a.Fecha,
                    SrmTransaccionId = a.SrmTransaccionId,
                    CamaraId = a.CamaraId,
                    EstatusTransId = a.EstatusTransId,
                    ServicioId = a.ServicioId,
                    TipoSociedadId = a.TipoSociedadId
                })
                .FirstOrDefault();


            if (transWebSite != null)
            {
                result.Add(transWebSite);
                if (transWebSite.SrmTransaccionId.HasValue)
                {
                    var dbSRM = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(transWebSite.CamaraId);

                    var listaEstados = dbSRM.EstatusTransacciones.ToList();

                    var seguimiento = (from est in dbSRM.EstatusTransacciones
                                       join seg in dbSRM.SeguimientoTransacciones on est.EstatusTransId equals seg.Estado
                                       where seg.TransaccionId == transWebSite.SrmTransaccionId.Value
                                       orderby seg.FechaModificacion
                                       select new
                                       {
                                           Descripcion = est.EstatusTransaccion,
                                           seg.Estado,
                                           seg.FechaModificacion,
                                           seg.Comentario,
                                           seg.TransaccionId,
                                           seg.TipoComentario

                                       }).ToList();

                    var transHistoria = seguimiento.AsEnumerable()
                        .Select(a => new TransaccionHistorico
                        {
                            TransaccionId = a.TransaccionId,
                            Fecha = a.FechaModificacion,
                            CamaraId = transWebSite.CamaraId,
                            ServicioId = transWebSite.ServicioId,
                            EstatusTransId = a.Estado,
                            TipoSociedadId = transWebSite.TipoSociedadId,
                            Comentario = a.TipoComentario == 3 || a.TipoComentario == 1 ? a.Comentario : string.Empty

                        }).ToList();
                    result.AddRange(transHistoria);
                }
            }
            return result.Skip(startRowIndex).Take(maximumRows).ToList();
        }

        ///<summary>
        /// Obtiene el ultimo estado de la transacción de acuerdo al TransaccionId en CamaraWebsite
        ///</summary>
        ///<param name="transaccionId"></param>
        ///<returns></returns>
        public static EstatusTransacciones GetUltimoEstado(int transaccionId)
        {
            var db = new CamaraWebsiteEntities();

            //Lista que contendra la historia
            var result = new List<TransaccionHistorico>();

            //Transaccion del WebSite
            var transWebSite = db.Transacciones.Where(a => a.TransaccionId == transaccionId).AsEnumerable()
                .Select(a => new TransaccionHistorico
                {
                    TransaccionId = a.TransaccionId,
                    Fecha = a.Fecha,
                    SrmTransaccionId = a.SrmTransaccionId,
                    CamaraId = a.CamaraId,
                    EstatusTransId = a.EstatusTransId,
                    ServicioId = a.ServicioId,
                    TipoSociedadId = a.TipoSociedadId
                })
                .FirstOrDefault();


            if (transWebSite != null)
            {
                result.Add(transWebSite);
                if (transWebSite.SrmTransaccionId.HasValue)
                {
                    var dbSRM = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(transWebSite.CamaraId);

                    var transHistoria = dbSRM.pGetTransaccionesHistorico(transWebSite.SrmTransaccionId).AsEnumerable()
                        .Select(a => new TransaccionHistorico
                        {
                            TransaccionId = a.TransaccionId.GetValueOrDefault(),
                            Fecha = a.FechaModificacion,
                            CamaraId = transWebSite.CamaraId,
                            ServicioId = a.TipoServicioId.GetValueOrDefault(),
                            EstatusTransId = a.Estatus.GetValueOrDefault(),
                            TipoSociedadId = a.CustomInt1.GetValueOrDefault()

                        }).ToList();
                    result.AddRange(transHistoria);
                }
            }

            var lastHistStatus = result.OrderByDescending(d => d.Fecha).FirstOrDefault();

            var estatusTransIdNuevo = new AppSettingsReader().GetValue("EstatusTransIdNuevo", typeof(Int32)) as Int32?;
            if (result.Count > 1 && result.Where(d => d.EstatusTransId == estatusTransIdNuevo).Count() > 0)
                lastHistStatus = result.Where(d => d.EstatusTransId != estatusTransIdNuevo)
                                .OrderByDescending(d => d.Fecha).FirstOrDefault();

            var statusTrans = db.EstatusTransacciones.Where(d => d.EstatusTransId == lastHistStatus.EstatusTransId).FirstOrDefault();

            return statusTrans != null
                       ? statusTrans
                       : new EstatusTransacciones();
        }


        ///<summary>
        /// Obtiene el ultimo estado de la transacción de acuerdo al TransaccionId en CamaraWebsite
        ///</summary>
        ///<param name="transaccionId"></param>
        ///<returns></returns>
        public static List<EstatusTransaccionesResult> GetUltimoEstado(List<Transacciones> transaccion)
        {
            var db = new CamaraWebsiteEntities();
            var statusTransactions = new List<EstatusTransaccionesResult>();

            var transWebSites = transaccion
             .Select(a => new TransaccionHistorico
             {
                 TransaccionId = a.TransaccionId,
                 Fecha = a.Fecha,
                 SrmTransaccionId = a.SrmTransaccionId ?? 0,
                 CamaraId = a.CamaraId,
                 EstatusTransId = a.EstatusTransId,
                 ServicioId = a.ServicioId,
                 TipoSociedadId = a.TipoSociedadId
             });

            var srmTransaccionIds = transWebSites.Select(x => x.SrmTransaccionId ?? 0).ToArray();

            var transHistorias = new List<SRM.Transacciones>();

            var camaraIds = transWebSites.Select(x => x.CamaraId).Distinct().ToList();
            foreach (var id in camaraIds)
            {
                var dbSRM = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(id);
                var paramValue = string.Join(",", srmTransaccionIds);
                var query = string.Format(CamaraComercio.DataAccess.EF.Queries.SqlTransaction.TransaccionesHistorico, paramValue);
                var resultad = dbSRM.Transacciones.Where(x => srmTransaccionIds.Contains(x.TransaccionId)).ToList();
                transHistorias.AddRange(resultad);
            }

            foreach (var transWebSite in transWebSites)
            {
                var result = new List<TransaccionHistorico>();
                if (transWebSite != null)
                {
                    result.Add(transWebSite);
                    if (transWebSite.SrmTransaccionId.HasValue)
                    {
                        //   var dbSRM = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(transWebSite.CamaraId);

                        var transHistoria = transHistorias.Where(x => x.TransaccionId == transWebSite.SrmTransaccionId)
                            .Select(a => new TransaccionHistorico
                            {
                                TransaccionId = a.TransaccionId,
                                Fecha = a.FechaModificacion,
                                CamaraId = transWebSite.CamaraId,
                                ServicioId = a.TipoServicioId,
                                EstatusTransId = a.Estatus,
                                TipoSociedadId = a.CustomInt1.GetValueOrDefault()

                            }).ToList();
                        result.AddRange(transHistoria);
                    }
                }

                var lastHistStatus = result.OrderByDescending(d => d.Fecha).FirstOrDefault();

                var estatusTransIdNuevo = new AppSettingsReader().GetValue("EstatusTransIdNuevo", typeof(Int32)) as Int32?;
                if (result.Count > 1 && result.Where(d => d.EstatusTransId == estatusTransIdNuevo).Count() > 0)
                    lastHistStatus = result.Where(d => d.EstatusTransId != estatusTransIdNuevo)
                                    .OrderByDescending(d => d.Fecha).FirstOrDefault();

                if (lastHistStatus != null)
                {
                    var statusTrans = db.EstatusTransacciones.Where(d => d.EstatusTransId == lastHistStatus.EstatusTransId).Select(
                    x => new EstatusTransaccionesResult
                    {
                        EstatusTranNombre = x.EstatusTranNombre,
                        EstatusTransDescripcion = x.EstatusTransDescripcion,
                        EstatusTransId = x.EstatusTransId
                    }).FirstOrDefault();

                    statusTrans = statusTrans != null
                               ? statusTrans
                               : new EstatusTransaccionesResult();

                    statusTrans.TransactionId = transWebSite.TransaccionId;

                    statusTransactions.Add(statusTrans);
                }


            }

            return statusTransactions;

        }

        #endregion

        #region Transaccion

        /// <summary>
        /// Método que retorna una transacción a partir de su ID en CamaraWebsite
        /// </summary>
        /// <param name="transaccionId">Transaccion Id de la solicitud.</param>
        /// <returns></returns>
        public static Transacciones GetTransaccionById(int transaccionId)
        {
            var db = new CamaraWebsiteEntities();
            var query = db.Transacciones.Where(a => a.TransaccionId == transaccionId);
            var trans = query.FirstOrDefault();
            return trans;
        }

        /// <summary>
        /// Metodo que retorna una transaccion a partir del ID en el que fue guardado en SRM
        /// </summary>
        /// <param name="transaccionSrmId">Número de transacción en el SRM</param>
        /// <param name="camaraId">Cámara a la que pertenece la transacción</param>
        /// <returns></returns>
        public static Transacciones GetTransaccionBySrmId(int transaccionSrmId, string camaraId)
        {
            var db = new CamaraWebsiteEntities();
            var query = db.Transacciones.Where(a => a.SrmTransaccionId == transaccionSrmId && a.CamaraId == camaraId);
            var trans = query.FirstOrDefault();
            return trans;
        }

        #endregion

        /// <summary>
        /// Obtiene todos los documentos asociados a una transacción el SRM.
        /// </summary>
        /// <param name="SrmTransaccionId">Id de la transacción en el SRM.</param>
        /// <returns></returns>
        public List<TransaccionesDocumentos> GetTransaccionesDocumentos(int SrmTransaccionId)
        {
            var dbWebSite = new CamaraWebsiteEntities();

            var trans = dbWebSite.Transacciones.Where(t => t.SrmTransaccionId == SrmTransaccionId).FirstOrDefault();

            return trans != null ? trans.TransaccionesDocumentos.ToList() : new List<TransaccionesDocumentos>();
        }

        /// <summary>
        /// Obtiene el documento para visualizar.
        /// </summary>
        /// <param name="id">Id del docuemnto registrado en el Website.</param>
        /// <param name="srmTransaccionId">Id de la transacción en el SRM.</param>
        /// <returns></returns>
        public TransaccionesDocumentos GetTransaccionesDocumentos(int id, int srmTransaccionId)
        {
            using (var dbWebSite = new CamaraWebsiteEntities())
            {
                var doc = dbWebSite.TransaccionesDocumentos
                    .Where(t => t.TransaccionesDocumentosId == id).FirstOrDefault();

                return doc;
            }
        }


        /// <summary>
        /// Actualiza una transacción como cargada en el SRM
        /// </summary>
        /// <param name="transaccionId">ID de la transacción</param>
        /// <param name="bLoadedSrm">Parametro de carga en el SRM (bool)</param>
        /// <param name="srmTransaccionId">ID de la transacción en el SRM</param>
        /// <returns></returns>
        public int UpdateTransacciones(int transaccionId, bool bLoadedSrm, int srmTransaccionId)
        {
            var dbWebSite = new CamaraWebsiteEntities();
            var trans = dbWebSite.Transacciones.Where(t => t.TransaccionId == transaccionId).FirstOrDefault();
            trans.bLoadedInSRM = bLoadedSrm;
            trans.SrmTransaccionId = srmTransaccionId;

            return dbWebSite.SaveChanges();
        }

        /// <summary>
        /// Actualiza una transacción como pagada desde el SRM
        /// </summary>
        /// <param name="transaccionId"></param>
        /// <returns></returns>
        public int UpdateTransaccionPagada(int transaccionId)
        {
            var dbWebSite = new CamaraWebsiteEntities();
            var trans = dbWebSite.Transacciones.Where(t => t.TransaccionId == transaccionId).FirstOrDefault();
            trans.bPagada = true;
            return dbWebSite.SaveChanges();
        }

        public List<Transacciones> ObtenerTransaccionesProblema(string padreUser)
        {
            var listUser = new List<string>();

            var dbUsers = new Membership.CamaraWebsiteAccountsEntities();
            var uHijos = dbUsers.ViewProfileProperties
                        .Where(c => c.UsuarioPadre == padreUser).ToList()
                        .Select(c => c.UserName.ToLower()).ToList();
            List<Transacciones> trSrm = new List<Transacciones>();
            List<Transacciones> result = new List<Transacciones>();
            var db = new CamaraWebsiteEntities();

            var transac = from tr in db.Transacciones
                          where (tr.UserName == padreUser || uHijos.Contains(tr.UserName) /*|| tr.UserName == uPadre*/) && (!tr.SubTransaccionId.HasValue)
                          select tr;

            var estaddo = GetUltimoEstado(transac.ToList());
            foreach (var item in transac)
            {
                EstatusTransaccionesResult srmEstatus = estaddo.Where(x => x.TransactionId == item.TransaccionId).FirstOrDefault();
                if (!string.IsNullOrEmpty(srmEstatus?.EstatusTransDescripcion))
                {
                    if (item.EstatusTransId.Equals(15)|| item.EstatusTransId.Equals(40)|| item.EstatusTransId.Equals(42))
                    {
                        if (srmEstatus.EstatusTransId.Equals(15) || srmEstatus.EstatusTransId.Equals(42))
                        {
                            result.Add(item);
                        }
                    }
                    
                }
            }

            if(result.Count != 0)
            {
                var ids = result.Select(t => t.ServicioId).Distinct();

                var nombreServicios = new CamaraComun.CamaraComunEntities()
                    .Servicio.Where(s => ids.Contains(s.ServicioId))
                    .Select(s => new { s.ServicioId, s.Descripcion }).ToList();

                foreach (var t in result.Where(t => nombreServicios.FirstOrDefault(n => n.ServicioId == t.ServicioId) != null))
                {
                    t.NombreServicio = nombreServicios.First(n => n.ServicioId == t.ServicioId).Descripcion;
                }
                result.OrderByDescending(x => x.Fecha);
            }
            return result;
        }

        //---------------------transacciones BHD: 

       
        public List<TransaccionesEmpBHD> ObtenerTransaccionesBHD(string username)
        {
            var dbOfv = new CamaraWebsiteEntities();        
                        

            List<TransaccionesEmpBHD> TransBHDs = new List<TransaccionesEmpBHD>();
            using (CamaraWebsiteEntities db = new CamaraWebsiteEntities())
            {           
                            

                TransBHDs = db.TransaccionesEmpBHD.Where(tr => tr.UserName == username && tr.Estatus == 1).ToList();
                  
            }

            return TransBHDs.ToList();

           
        }



        public TransaccionesEmpBHD LTransaccionesBHDById(string username, int SolicitudId)
        {

         
            var TransBHDs = new TransaccionesEmpBHD();

            //try
            //{

            using (CamaraWebsiteEntities db = new CamaraWebsiteEntities())
            {
            
                TransBHDs = db.TransaccionesEmpBHD.Where(tr => tr.UserName == username && tr.SolicitudId == SolicitudId).OrderByDescending(u => u.Id).FirstOrDefault();

            }

            //}
            //catch (Exception ex)
            //{

            //}

            return TransBHDs;

        }
        //actualizza el estado en la tabla local dependiendo el estado devulto al consultar el endpont
        public void ActualizarEstadosBHD(int SolicitudId, int bEstadId)
        {
            using (var db = new CamaraWebsiteEntities())
            {
                //buscar transacciones pendientes <> 1:
               
              //  var result = db.TransaccionesEmpBHD.Where(x => x.reference == SolicitudId).FirstOrDefault();
                var result = db.TransaccionesEmpBHD.Where(tr =>  tr.SolicitudId == SolicitudId).OrderByDescending(u => u.Id).FirstOrDefault(); // last


                if (result != null)
                {
                    result.Estatus = bEstadId;
                    db.SaveChanges();
                }
            }

        }
        //---------------------buscar data:



    }

    /// <summary>
    /// Representación de una transacción en el SRM, desde Oficina Virtual. Esta es una clase DTO
    /// </summary>
    [Serializable]
    public class TransaccionSrm
    {
        /// <summary>
        /// Listado de transacciones
        /// </summary>
        public Transacciones Transaccion { get; set; }

        /// <summary>
        /// Objeto de Registro Mercantil (tabla Registros)
        /// </summary>
        public Registros Registro { get; set; }

        /// <summary>
        /// Objeto de la sociedad (tabla Sociedades)
        /// </summary>
        public Sociedades Sociedad { get; set; }

        /// <summary>
        /// Listado de Socios en este registro
        /// </summary>
        public List<Socios> Socios { get; set; }

        /// <summary>
        /// Listado de productos de la emrpesa
        /// </summary>
        public List<Productos> Productos { get; set; }

        /// <summary>
        /// Listado de actividades comerciales de la emrpesa
        /// </summary>
        public List<RegistrosActividades> RegistroActividades { get; set; }

        /// <summary>
        /// Listado de referencias comerciales de la empresa
        /// </summary>
        public List<ReferenciasComerciales> ReferenciasComerciales { get; set; }

        /// <summary>
        /// Listado de referencias bancarias de la empresa
        /// </summary>
        public List<ReferenciasBancarias> ReferenciasBancarias { get; set; }

        ///<summary>
        /// Listado de sucursales
        ///</summary>
        public List<Sucursales> Sucursales { get; set; }

        ///<summary>
        /// Factura relacionada a la transaccion
        ///</summary>
        public Facturas Factura { get; set; }

        ///<summary>
        /// Transaccion Detalle relacionada a la transaccion (Factura Detalle)
        ///</summary>
        public List<TransaccionDetalle> TransaccionDetalle { get; set; }

        private int _transaccionId = 0;

        /// <summary>
        /// Inicializa la transacción dentro del SRM
        /// </summary>
        /// <param name="transaccionId"></param>
        /// <param name="camaraId"></param>
        public void InitializeWithSrm(int transaccionId, string camaraId)
        {
            var dbWebSite = new CamaraWebsiteEntities();
            this._transaccionId = transaccionId;
            this.Transaccion = dbWebSite.Transacciones.Include("SubTransacciones").FirstOrDefault(t => t.SrmTransaccionId == this._transaccionId && t.CamaraId == camaraId);
            if (this.Transaccion == null)
                throw new Exception("No Existe Transaccion Registrada.");
            InitializeObjects();
        }

        /// <summary>
        /// Inicializa la transacción para OFV
        /// </summary>
        /// <param name="transaccionId"></param>
        /// <param name="camaraId"></param>
        public void InitializeWithWebSite(int transaccionId, string camaraId)
        {
            var dbWebSite = new CamaraWebsiteEntities();
            this._transaccionId = transaccionId;
            this.Transaccion = dbWebSite.Transacciones.Include("SubTransacciones").FirstOrDefault(t => t.TransaccionId == this._transaccionId && t.CamaraId == camaraId);
            if (this.Transaccion == null)
                throw new Exception("No Existe Transaccion Registrada.");
            InitializeObjects();
        }

        /// <summary>
        /// Inicialización del objeto
        /// </summary>
        private void InitializeObjects()
        {
            var dbWebSite = new CamaraWebsiteEntities();
            this.Registro = dbWebSite.Registros.FirstOrDefault(r => r.RegistroId == this.Transaccion.RegistroId);
            if (this.Registro == null)
                return;

            this.Sociedad = dbWebSite.Sociedades.FirstOrDefault(s => s.RegistroId == this.Registro.RegistroId);
            this.Socios = dbWebSite.Socios.Where(s => s.RegistroId == this.Registro.RegistroId).ToList();
            this.Productos = dbWebSite.Productos.Where(s => s.RegistroId == this.Registro.RegistroId).ToList();
            this.RegistroActividades =
                dbWebSite.RegistrosActividades.Where(s => s.RegistroId == this.Registro.RegistroId).ToList();
            this.ReferenciasBancarias =
                dbWebSite.ReferenciasBancarias.Where(s => s.RegistroId == this.Registro.RegistroId).ToList();
            this.ReferenciasComerciales =
                dbWebSite.ReferenciasComerciales.Where(s => s.RegistroId == this.Registro.RegistroId).ToList();
            this.Factura = dbWebSite.Facturas.Where(s => s.TransaccionId == this._transaccionId).FirstOrDefault();
            if (this.Factura != null)
                this.TransaccionDetalle =
                    dbWebSite.TransaccionDetalle.Where(td => td.FacturaId == this.Factura.FacturaId).ToList();
        }
    }


    public partial class EstatusTransaccionesResult
    {
        public virtual int EstatusTransId
        {
            get;
            set;
        }

        public virtual string EstatusTranNombre
        {
            get;
            set;
        }

        public virtual string EstatusTransDescripcion
        {
            get;
            set;
        }

        public int TransactionId { get; set; }
    }
}
