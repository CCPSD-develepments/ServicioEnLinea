﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CamaraComercio.DataAccess.EF.SRM;
using System.ComponentModel;

namespace CamaraComercio.DataAccess.EF.CamaraComun
{
    /// <summary>
    /// Repositorio de los servicios en CamaraComun
    /// </summary>
    [DataObject()]
    public class ServicioRepository : Repository<Servicio, CamaraComunEntities>
    {
        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        public ServicioRepository()
            : base(new CamaraComunEntities())
        {

        }

        /// <summary>
        /// Obtiene el total a pagar por un servicio
        /// </summary>
        /// <param name="servicioId">ID del servicio</param>
        /// <param name="camaraId">ID de la Cámara</param>
        /// <param name="CapitalAutorizado">Capital Autorizado de la empresa</param>
        /// <param name="CapitalModificado">Capital Modificado de la empresa</param>
        /// <param name="bExpress">Indica si la transaccion es express</param>
        /// <param name="PorcentajeVip">Porcentaje a facturar para transacción express</param>
        /// <returns></returns>
        public Decimal GetTotalServicio(int servicioId, string camaraId, Decimal? CapitalAutorizado, Decimal? CapitalModificado, bool bExpress, Decimal PorcentajeVip, CamaraComercio.DataAccess.EF.OficinaVirtual.Transacciones trans)
        {
            int tipoSerTransformacion = 11, servAumentoCapital = 372, servRenovacionConDocumento = 371, servRenovacionConAumento = 416, tipoSerRenovacion = 3,
                servReduccionCapital = 383, servReduccionCapitalSuscrito = 384, servAumentoCapitalSuscrito = 384;

            var servicio = this.SelectByKey("ServicioId", servicioId);

            //Si el servicio se calcula en abse 
            if (servicio != null && !servicio.CalculoBaseCapital && servicio.SeCobra && servicio.CostoServicio > 0)
                return servicio.CostoServicio + (bExpress ? servicio.CostoServicio * (PorcentajeVip / 100) : 0m);

            var dbSrm = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId);

            #region Verificar Servicios con Aumento de capital,Reduccion, Renovacion.
            if (VerificarSiEsUnaMODIFICACIONPORTRANSFORMACION(trans, trans.SubTransacciones.ToList()))
            {
                //Si es una transformacion con aumento de capital, cobrar en base al aumento de capital
                if (servicio.TipoServicioId.Equals(tipoSerTransformacion)) servicioId = servAumentoCapital;
                //Si incluye una renovacion cobrar como servicio de renovacion con aumento de capital.
                if (servicioId.Equals(servRenovacionConDocumento)) servicioId = servRenovacionConAumento;
            }
            else if (servicioId.Equals(servRenovacionConDocumento) && VerificarSiEsUnaRenovacionConAumento(trans, trans.SubTransacciones.ToList()))
            {
                //Si es una renovacion  con aumento entonce cobrar servicio de renovacion con aumento de capital.
                if (servicio.TipoServicioId.Equals(tipoSerRenovacion)) servicioId = servRenovacionConAumento;
            }
            //Si es una modificacion con transformacion con reduccion capital autorizado
            else if (VerificarSiEsUnaMODIFICACIONPORTRANSFORMACIONConReduccion(trans, trans.SubTransacciones.ToList()))
            {
                if (servicio.TipoServicioId.Equals(tipoSerTransformacion)) servicioId = servReduccionCapital;
            }
            //Si es una modificacion con transformacion con reduccion capital Suscrito
            else if (VerificarSiEsUnaMODIFICACIONPORTRANSFORMACIONConReduccionSuscrito(trans, trans.SubTransacciones.ToList()))
            {
                if (servicio.TipoServicioId.Equals(tipoSerTransformacion)) servicioId = servReduccionCapitalSuscrito;
            }
            //Si es una modificacion con transformacion con aumento capital Suscrito
            else if (VerificarSiEsUnaMODIFICACIONPORTRANSFORMACIONAumentoSuscrito(trans, trans.SubTransacciones.ToList()))
            {
                if (servicio.TipoServicioId.Equals(tipoSerTransformacion)) servicioId = servAumentoCapitalSuscrito;

                if (servicioId.Equals(servRenovacionConDocumento)) servicioId = servRenovacionConAumento;
            }
            #endregion

            decimal? calculoCostoServicio = dbSrm.csp_GetCostoServicio(servicioId, CapitalAutorizado, CapitalModificado).FirstOrDefault();

            var costo = calculoCostoServicio.HasValue ? calculoCostoServicio.Value : 0m;

            return costo + (bExpress ? costo * (PorcentajeVip / 100) : 0);
        }

        private bool VerificarSiEsUnaMODIFICACIONPORTRANSFORMACIONAumentoSuscrito(OficinaVirtual.Transacciones trans, List<OficinaVirtual.Transacciones> list)
        {
            List<int> listServiciosId = new List<int>();
            bool modifTrans = false;

            foreach (var item in list)
                listServiciosId.Add(item.ServicioId);

            var servicio = this.SelectByKey("ServicioId", trans.ServicioId);

            if (servicio.TipoServicioId.Equals(11) && listServiciosId.Contains(381))
                modifTrans = true;

            return modifTrans;
        }

        private bool VerificarSiEsUnaMODIFICACIONPORTRANSFORMACIONConReduccionSuscrito(OficinaVirtual.Transacciones trans, List<OficinaVirtual.Transacciones> list)
        {
            List<int> listServiciosId = new List<int>();
            bool modifTrans = false;

            foreach (var item in list)
                listServiciosId.Add(item.ServicioId);

            var servicio = this.SelectByKey("ServicioId", trans.ServicioId);

            if (servicio.TipoServicioId.Equals(11) && listServiciosId.Contains(384))
                modifTrans = true;

            return modifTrans;
        }

        private bool VerificarSiEsUnaMODIFICACIONPORTRANSFORMACIONConReduccion(OficinaVirtual.Transacciones trans, List<OficinaVirtual.Transacciones> list)
        {
            List<int> listServiciosId = new List<int>();
            bool modifTrans = false;

            foreach (var item in list)
                listServiciosId.Add(item.ServicioId);

            var servicio = this.SelectByKey("ServicioId", trans.ServicioId);

            if (servicio.TipoServicioId.Equals(11) && listServiciosId.Contains(383))
                modifTrans = true;

            return modifTrans;
        }

        private bool VerificarSiEsUnaRenovacionConAumento(OficinaVirtual.Transacciones trans, List<OficinaVirtual.Transacciones> list)
        {
            List<int> listServiciosId = new List<int>();
            bool modifTrans = false;

            foreach (var item in list)
                listServiciosId.Add(item.ServicioId);

            //Si es una subtransaccion pero la transaccion principal es un aumento, se cambia el id de servicio.
            if (list.Count <= 0 && trans.SubTransaccionId.HasValue)
            {
                var dbWeb = new OficinaVirtual.CamaraWebsiteEntities();

                var tran = (from tr in dbWeb.Transacciones
                            where tr.TransaccionId.Equals(trans.SubTransaccionId.Value)
                            select tr).FirstOrDefault();

                if (tran.ServicioId.Equals(372) || tran.ServicioId.Equals(381))
                    return true;
            }


            if ((listServiciosId.Contains(372) || listServiciosId.Contains(381)))
                modifTrans = true;

            return modifTrans;
        }

        private bool VerificarSiEsUnaMODIFICACIONPORTRANSFORMACION(CamaraComercio.DataAccess.EF.OficinaVirtual.Transacciones trans, List<CamaraComercio.DataAccess.EF.OficinaVirtual.Transacciones> transList)
        {
            List<int> listServiciosId = new List<int>();
            bool modifTrans = false;

            foreach (var item in transList)
                listServiciosId.Add(item.ServicioId);

            var servicio = this.SelectByKey("ServicioId", trans.ServicioId);

            if (servicio.TipoServicioId.Equals(11) && listServiciosId.Contains(372))
                modifTrans = true;
            //else 
            //{
            //    var dbOFV = new CamaraComercio.DataAccess.EF.OficinaVirtual.CamaraWebsiteEntities();
            //    var dbComun = new CamaraComercio.DataAccess.EF.CamaraComun.CamaraComunEntities();

            //    var query = (from transOFV in dbOFV.Transacciones
            //                 where transOFV.TransaccionId.Equals(trans.SubTransaccionId.Value)
            //                 join ser in dbComun.Servicio on transOFV.ServicioId equals ser.ServicioId
            //                 select new {transOFV.ServicioId, ser.TipoServicioId }).FirstOrDefault();

            //    if(query != null)
            //        modifTrans = query.TipoServicioId.Equals(11);
            //} 
            return modifTrans;
        }

        /// <summary>
        /// Obtiene todos los servicios para un tipo de sociedad y tipo de servicio específicos
        /// </summary>
        /// <param name="tipoServicioId">ID del tipo de servicio</param>
        /// <param name="tipoSociedadId">ID del tipo de sociedad</param>
        /// <param name="sinCapital">Indica si se deben traer servicios par empresas sin capital</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Servicio> GetServicios(int tipoServicioId, int tipoSociedadId, bool sinCapital)
        {
            var db = this.Session;

            var result = from s in db.Servicio
                         join sdr in db.ServicioDocumentoRequerido on s.ServicioId equals sdr.ServicioId
                         where s.TipoServicioId == tipoServicioId && sdr.TipoSociedadId == tipoSociedadId
                                && s.SiteVisible && sdr.SiteVisible && s.SinCapital == sinCapital
                         select s;

            var queryResult = result.Distinct().ToList();
            var listServicios = result.Select(a => a.ServicioId).Distinct().ToList();

            //Obtengo las urls de los servicios
            var dbWebsite = new CamaraComercio.DataAccess.EF.OficinaVirtual.CamaraWebsiteEntities();
            var url = dbWebsite.ServicioDetalles.Where(a => listServicios.Contains(a.ServicioId)).ToList();

            var info = new CultureInfo("es-DO");
            queryResult.ForEach(a =>
            {
                a.Descripcion = info.TextInfo.ToTitleCase(a.Descripcion.ToLower());
                var urlSeleccionado = url.FirstOrDefault(u => u.ServicioId == a.ServicioId);
                if (urlSeleccionado != null)
                    a.UrlModificacion = urlSeleccionado.Url;
            }
                );
            return queryResult;
        }

        /// <summary>
        /// Obtiene los servicios de certificación avanzados
        /// </summary>
        /// <param name="tipoServicioId">ID del tipo de servicio</param>
        /// <param name="tipoSociedadId">ID del tipo de sociedad</param>
        /// <param name="camaraId">ID de la Cámara</param>
        /// <param name="esEmpresa">Indica si es para personas (accionistas) o emrpesa</param>
        /// <param name="servicioFlowIdNoRequiereAnalisis">ID indicador de certificados avanzados</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IEnumerable<Servicio> GetServiciosCertificacionAvanzados(int tipoServicioId, int tipoSociedadId, string camaraId, bool esEmpresa,
            int servicioFlowIdNoRequiereAnalisis)
        {
            if(tipoSociedadId != 7)
            {
                var comun = new CamaraComunEntities();
                var db = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId);
                var result =
                    db.ModelosCertificaciones.Where(
                        a => (!a.TipoSociedadId.HasValue || a.TipoSociedadId == tipoSociedadId) && a.EsEmpresa == esEmpresa)
                        .Select(a => a.ServicioId).ToList();
                var servicios = comun.Servicio.Where(s => s.TipoServicioId == tipoServicioId
                                                          && !result.Contains(s.ServicioId)
                                                          && s.ServicioFlowId != servicioFlowIdNoRequiereAnalisis
                                                          && !String.IsNullOrEmpty(s.Descripcion)
                                                          && s.SiteVisible == true);
                return servicios.AsEnumerable();
            }
            else
            {
                var comun = new CamaraComunEntities();
                var db = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId);
                var result =
                    db.ModelosCertificaciones.Where(
                        a => (!a.TipoSociedadId.HasValue || a.TipoSociedadId == tipoSociedadId) && a.EsEmpresa == esEmpresa)
                        .Select(a => a.ServicioId).ToList();
                var servicios = comun.Servicio.Where(s => s.TipoServicioId == tipoServicioId
                                                          && !result.Contains(s.ServicioId)
                                                          && s.ServicioFlowId != servicioFlowIdNoRequiereAnalisis
                                                          && !String.IsNullOrEmpty(s.Descripcion)
                                                          && s.SiteVisible == true);
                var servPF = "413,728,731,734,736,411";
                var servId = servPF.Split(',').Select(c => int.Parse(c)).ToList();
                List<Servicio> resultadoSel = new List<Servicio>();
                foreach (var item in servicios)
                {
                    if (servId.Contains(item.ServicioId))
                    {
                        resultadoSel.Add(item);
                    }
                }
                return resultadoSel.AsEnumerable();
            }

            //TODO: Stan: Lo de ServicioFlowIdNoRequiereAnalisis no tenia que estar en este select, ya eso es logica de negocios
        }


        /// <summary>
        /// Obtiene los servicios de certificación avanzados Para Personas
        /// </summary>
        /// <param name="tipoServicioId">ID del tipo de servicio</param>
        /// <param name="camaraId">ID de la Cámara</param>
        /// <param name="esEmpresa">Indica si es para personas (accionistas) o emrpesa</param>
        /// <param name="servicioFlowIdNoRequiereAnalisis">ID indicador de certificados avanzados</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IEnumerable<Servicio> GetServiciosCertificacionAvanzados(int tipoServicioId, string camaraId, bool esPersona,
            int servicioFlowIdNoRequiereAnalisis)
        {
            var comun = new CamaraComunEntities();
            var db = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId);
            var result =
                db.ModelosCertificaciones.Where(a => a.EsPersona == esPersona)
                    .Select(a => a.ServicioId).ToList();
            var servicios = comun.Servicio.Where(s => s.TipoServicioId == tipoServicioId
                                                      && !result.Contains(s.ServicioId)
                                                      && s.ServicioFlowId != servicioFlowIdNoRequiereAnalisis
                                                      && !String.IsNullOrEmpty(s.Descripcion)
                                                      && s.SiteVisible == true);
            return servicios.AsEnumerable();

            //TODO: Stan: Lo de ServicioFlowIdNoRequiereAnalisis no tenia que estar en este select, ya eso es logica de negocios
        }


        /// <summary>
        /// Retorna un servicio a partir de su ID
        /// </summary>
        /// <param name="servicioId">ID del servicio</param>
        /// <returns></returns>
        public IEnumerable<Servicio> GetServicio(int servicioId)
        {
            //TODO: Stan: Esto ya lo trae el repositorio por default. El método se llama SelectByKey(
            return this.Session.Servicio.Where(a => a.ServicioId == servicioId).AsEnumerable();
        }


        /// <summary>
        /// Retorna un servicio a partir de su ID
        /// </summary>
        /// <param name="servicioId">ID del servicio</param>
        /// <returns></returns>
        public IEnumerable<Servicio> GetServicioById(int servicioId)
        {
            //TODO: Stan: Esto ya lo trae el repositorio por default. El método se llama SelectByKey(
            return this.Session.Servicio.Where(a => a.ServicioId == servicioId).AsEnumerable();
        }



    }
}