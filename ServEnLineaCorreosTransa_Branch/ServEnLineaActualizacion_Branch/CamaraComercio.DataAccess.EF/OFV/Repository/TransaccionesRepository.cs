﻿using System;
using System.Collections.Generic;
using System.Linq;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.SRM;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    /// <summary>
    /// Repositorio de transacciones para Oficina Virtual
    /// </summary>
    public class TransaccionesRepository : Repository<Transacciones, CamaraWebsiteEntities>
    {
        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        public TransaccionesRepository()
            : base(new CamaraWebsiteEntities())
        {

        }

        /// <summary>
        /// Obtiene el total de transacciones activas para la combinacion de Servicio/No. Mercantil
        /// </summary>
        /// <param name="servicioId"></param>
        /// <param name="numeroMercantil"></param>
        /// <param name="estatusCerrados"></param>
        /// <returns></returns>
        public int CountTransaccionActiva(int servicioId, int? numeroMercantil, List<int> estatusCerrados)
        {
            var db = this.Session;

            if (!estatusCerrados.Contains(0))
                estatusCerrados.Add(0); //Se agrega estatus En Oficina Virtual Manualmente.

            return db.Transacciones.Where(a => a.ServicioId == servicioId && a.NumeroRegistro == numeroMercantil && a.SubTransaccionId == null
                && !estatusCerrados.Contains(a.EstatusTransId)).Count();
        }
        public int CountTransaccionActivaMejora(int servicioId, int? numeroMercantil, List<int> estatusCerrados,int tipoSociedadId)
        {
            var db = this.Session;

            if (!estatusCerrados.Contains(0))
                estatusCerrados.Add(0); //Se agrega estatus En Oficina Virtual Manualmente.

            return db.Transacciones.Where(a => a.ServicioId == servicioId && a.NumeroRegistro == numeroMercantil && a.SubTransaccionId == null
                && !estatusCerrados.Contains(a.EstatusTransId) && a.TipoSociedadId == tipoSociedadId).Count();
        }

        /// <summary>
        /// Obtiene el total de transacciones activas para la combinacion de Servicio/No. Mercantil
        /// </summary>
        /// <param name="servicioId"></param>
        /// <param name="numeroMercantil"></param>
        /// <param name="estatusCerrados"></param>
        /// <returns></returns>
        public int CountTransaccionActiva(List<int> servicioId, int? numeroMercantil, List<int> estatusCerrados)
        {
            var db = this.Session;
            List<int> transaccionesPrinc = new List<int>();

            if (!estatusCerrados.Contains(0))
                estatusCerrados.Add(0); //Se agrega estatus En Oficina Virtual Manualmente.

            var transacciones = db.Transacciones.Where(a => servicioId.Contains(a.ServicioId)
                                               && a.NumeroRegistro == numeroMercantil
                                               && !estatusCerrados.Contains(a.EstatusTransId));

            foreach (var tran in transacciones)
            {
                if (tran.SubTransaccionId.HasValue)
                    transaccionesPrinc.Add(tran.SubTransaccionId.Value);
            }

            var headers = db.Transacciones.Where(a => transaccionesPrinc.Contains(a.TransaccionId)
                                                  && !a.SrmTransaccionId.HasValue);

            return headers.Count();
        }

        /// <summary>
        /// Obtiene una transaccion activa para la combinacion de Servicio/No. Mercantil
        /// </summary>
        /// <param name="servicioId"></param>
        /// <param name="numeroMercantil"></param>
        /// <param name="estatusCerrados"></param>
        /// <returns></returns>
        public Transacciones GetTransaccionActiva(List<int> servicioId, int? numeroMercantil, List<int> estatusCerrados)
        {
            var db = this.Session;

            if (!estatusCerrados.Contains(0))
                estatusCerrados.Add(0); //Se agrega estatus En Oficina Virtual Manualmente.
            //servicioId.Contains(tr.ServicioId) &&
            var tran = (from tr in db.Transacciones
                        where tr.NumeroRegistro == numeroMercantil && !estatusCerrados.Contains(tr.EstatusTransId)
                        orderby tr.TransaccionId descending
                        select tr).FirstOrDefault();

            return tran;
            //db.Transacciones.Where(a => servicioId.Contains(a.ServicioId) 
            //                               && a.NumeroRegistro == numeroMercantil
            //                               && !estatusCerrados.Contains(a.EstatusTransId)).FirstOrDefault();
        }


        /// <summary>
        /// Obtiene el ID de la transaccion activa para la combinacion de Servicio/No. Mercantil
        /// </summary>
        /// <param name="servicioId"></param>
        /// <param name="numeroMercantil"></param>
        /// <param name="estatusCerrados"></param>
        /// <returns></returns>
        public Transacciones GetTransaccionActiva(int servicioId, int? numeroMercantil, List<int> estatusCerrados)
        {
            var db = this.Session;

            if (!estatusCerrados.Contains(0))
                estatusCerrados.Add(0); //Se agrega estatus En Oficina Virtual Manualmente.

            return db.Transacciones.Where(a => a.ServicioId == servicioId && a.NumeroRegistro == numeroMercantil
                                               && !estatusCerrados.Contains(a.EstatusTransId)).FirstOrDefault();
        }

        /// <summary>
        /// Obtiene una Transaccion asociada a un Usuario.
        /// </summary>
        /// <param name="transactionId">Id de la Transaccion.</param>
        /// <param name="userName">Usuario que realizó la operación</param>
        /// <returns></returns>
        public Transacciones GetTransaccion(int transactionId, string userName)
        {
            var db = this.Session;
            return
                db.Transacciones.Include("SubTransacciones").FirstOrDefault(
                    a => a.TransaccionId == transactionId);
            //&& a.UserName == userName
        }

        /// <summary>
        /// Obtiene una Transaccion asociada a un Usuario.
        /// </summary>
        /// <param name="transactionId">Id de la Transaccion.</param>
        /// <param name="userName">Usuario que realizó la operación</param>
        /// <returns></returns>
        public TransaccionesDocDescargas GetCertificacionTransaccion(int transactionId, string userName)
        {
            var db = this.Session;
            return
                db.TransaccionesDocDescargas.Include("Transacciones").FirstOrDefault(
                    a => a.TransaccionId == transactionId && a.UserName == userName);
        }

        public decimal GetCostoTransaccion(Transacciones trans, decimal PorcentajeVIP)
        {
            var repServicio = new ServicioRepository();

            var subtotal = repServicio.GetTotalServicio(trans.ServicioId, trans.CamaraId, trans.CapitalSocial,
                                                         trans.ModificacionCapital, Convert.ToBoolean(trans.Prioridad),
                                                         PorcentajeVIP, trans);

            trans.SubTransacciones.ToList().ForEach(tnx =>
            {
                var service =
                    repServicio.GetServicio(tnx.ServicioId).FirstOrDefault();

                if (service != null && service.SeCobraEnSubTransaccion)
                    subtotal += repServicio.GetTotalServicio(tnx.ServicioId,
                                                                tnx.CamaraId,
                                                                tnx.CapitalSocial,
                                                                tnx.ModificacionCapital,
                                                                Convert.ToBoolean(tnx.Prioridad),
                                                                PorcentajeVIP, trans);
            });

            return subtotal;
        }

        /// <summary>
        /// Calcula el costo de la Transaccion Padre.
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="PorcentajeVIP"></param>
        /// <returns></returns>
        public decimal GetCostoTransaccionCabecera(Transacciones trans, decimal PorcentajeVIP)
        {
            //var SrmBD = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext("SDQ");
            //var CapitalSocial = SrmBD.Registros.Where(x => x.RegistroId == trans.RegistroId).FirstOrDefault().CapitalSocial;
            //trans.CapitalSocial = CapitalSocial;

            var repServicio = new ServicioRepository();

            var subtotal = repServicio.GetTotalServicio(trans.ServicioId, trans.CamaraId, trans.CapitalSocial,
                                                        trans.ModificacionCapital, Convert.ToBoolean(trans.Prioridad),
                                                        PorcentajeVIP, trans);


            if (trans.CapitalSocial == 0 && trans.TipoSociedadId == 13 &&  trans.ServicioId == 398)
            {
                subtotal = 9800;
            }



            return subtotal;
        }

        /// <summary>
        /// Calcula el costo de las subtransacciones.
        /// </summary>
        /// 
        /// <param name="trans">Objeto de transaccion</param>
        /// <param name="PorcentajeVIP">Incluir costos para porcentaje VIP</param>
        /// <param name="considerarMod">Indica si debe considerar las modificaciones como cobrables</param>
        /// <returns></returns>
        public decimal GetCostoTransaccionSub(Transacciones trans, decimal PorcentajeVIP, bool considerarMod, bool EsVip)
        {
            var repServicio = new ServicioRepository();

            var subtotal = 0M;

            var service = repServicio.GetServicio(trans.ServicioId).FirstOrDefault();

            if (considerarMod)
            {
                subtotal = repServicio.GetTotalServicio(trans.ServicioId, trans.CamaraId,
                                                        trans.CapitalSocial, trans.ModificacionCapital,
                                                        Convert.ToBoolean(trans.Prioridad), PorcentajeVIP, trans);
            }
            else
            {
                if (service != null && service.SeCobraEnSubTransaccion)
                {
                    subtotal = repServicio.GetTotalServicio(trans.ServicioId, trans.CamaraId,
                                                        trans.CapitalSocial, trans.ModificacionCapital,
                                                        Convert.ToBoolean(EsVip), PorcentajeVIP, trans);
                }
            }

            return subtotal;
        }
    }
}