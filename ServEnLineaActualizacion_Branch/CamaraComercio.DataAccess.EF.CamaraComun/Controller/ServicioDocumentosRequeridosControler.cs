using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System;

namespace CamaraComercio.DataAccess.EF.CamaraComun
{
    /// <summary>
    /// Controlador para la vista ServicioDocumentosRequeridos
    /// </summary>
    [DataObject()]
    public class ServicioDocumentosRequeridosControler
    {
        /// <summary>
        /// Obtiene todos los documentos requeridos para un servicio
        /// </summary>
        /// <param name="servicioId">Tipo de servicio</param>
        /// <param name="tipoSociedadId">Tipo de sociedad</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static IQueryable<ServicioDocumentoRequerido> GetDocumentosRequeridos(int? servicioId, int? tipoSociedadId)
        {
            var db = new CamaraComunEntities();
            return db.ServicioDocumentoRequerido.Where(c =>
                                                       c.ServicioId == servicioId
                                                       && c.TipoSociedadId == tipoSociedadId
                                                       && c.TipoDocumento.SiteVisible
                                                       && c.Servicio.SiteVisible
                                                       && c.SiteVisible);
        }

        /// <summary>
        /// Obtiene todo slos docuemntos requeridos a partir de un lsitado de servicios
        /// </summary>
        /// <param name="servicioId">Listado de IDs para servicios</param>
        /// <param name="tipoSociedadId">Tipo de sociedad</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static IQueryable<ServicioDocumentoRequerido> GetDocumentosRequeridos(List<int> servicioId, int? tipoSociedadId)
        {
            var db = new CamaraComunEntities();
            return db.ServicioDocumentoRequerido.Where(c => servicioId.Contains(c.ServicioId)
                                                            && c.TipoSociedadId == tipoSociedadId
                                                            && c.TipoDocumento.SiteVisible
                                                            && c.Servicio.SiteVisible
                                                            && c.SiteVisible).GroupBy(c => c.TipoDocumentoId)
                .Select(c => c.FirstOrDefault()).AsQueryable();
        }

        /// <summary>
        /// Obtiene los tipos de servicios a partir de grupos
        /// </summary>
        /// <param name="servicioId">Tipo de Servicio</param>
        /// <param name="tipoSociedadId">Tipo de Sociedad</param>
        /// <param name="grupo">Grupo</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static IQueryable<ServicioDocumentoRequerido> GetDocumentosRequeridos(List<int> servicioId, int? tipoSociedadId, int grupo = 0)
        {
            var db = new CamaraComunEntities();
            var query = db.ServicioDocumentoRequerido.Where(c => servicioId.Contains(c.ServicioId)
                                                                 && c.TipoSociedadId == tipoSociedadId && c.Grupo == grupo
                                                                 && c.TipoDocumento.SiteVisible
                                                                 && c.Servicio.SiteVisible
                                                                 && c.SiteVisible).GroupBy(c => c.TipoDocumentoId)
                .Select(c => c.FirstOrDefault());
            return query;
        }

        /// <summary>
        /// Obtiene los grupos de documentos requeridos para un servicio
        /// </summary>
        /// <param name="servicioId">ID del servicio</param>
        /// <param name="tipoSociedadId">Tipo de Sociedad</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static List<int?> GetGrupoDocumentosRequeridos(List<int> servicioId, int? tipoSociedadId)
        {
            var db = new CamaraComunEntities();
            var query = (db.ServicioDocumentoRequerido.Where(
                        c => servicioId.Contains(c.ServicioId) && c.TipoSociedadId == tipoSociedadId
                        && c.Grupo > 0
                        && c.TipoDocumento.SiteVisible
                        && c.Servicio.SiteVisible
                        && c.SiteVisible)
                        .Select(c => c.Grupo)).Distinct();
            return query.ToList();
        }

        /// <summary>
        /// Obtiene todos los servicios desde la base de datos CamaraComun
        /// </summary>
        /// <returns></returns>
        public static IQueryable<Servicio> GetServicios()
        {
            var db = new CamaraComunEntities();
            return db.Servicio;
        }

        /// <summary>
        /// Obtiene los documentos requeridos por tipo de sociedad
        /// </summary>
        /// <param name="servicioId">ID del Servicio</param>
        /// <param name="tipoSociedadId">ID del tipo de sociedad</param>
        /// <returns></returns>
        public static IQueryable<ViewServicioDocumentoRequerido> GetDocumentosRequeridosByTipoSociedad(int servicioId, int tipoSociedadId)
        {
            var db = new CamaraComunEntities();
            //TODO: Stan: Este listado debe filtrar los documentos con SiteVisible
            var query = db.ViewServicioDocumentoRequerido.Where(o =>
                           o.ServicioId == servicioId
                        && o.TipoSociedadId == tipoSociedadId)
                        .OrderBy(o => o.Grupo);
            return query;
        }
    }

    /// <summary>
    /// Clase que representa un Documento Requerido por un Servicio. 
    /// </summary>
    public partial class ServicioDocumentoRequerido
    {
        /// <summary>
        /// Cantidad de documentos originales
        /// </summary>
        public int CantidadOriginal { get; set; }

        /// <summary>
        /// Cantidad de documentos en copia
        /// </summary>
        public int CantidadCopia { get; set; }

        /// <summary>
        /// Nombre del Documento.  Debe poblarse para poder mostrar el contenido.  se Accede a traves de la Propiedad TipoDocumento.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Costo Copia.  Debe poblarse para poder mostrar el contenido.  se Accede a traves de la Propiedad TipoDocumento.
        /// </summary>
        public decimal CostoCopia { get; set; }

        /// <summary>
        /// Costo Original.  Debe poblarse para poder mostrar el contenido.  se Accede a traves de la Propiedad TipoDocumento.
        /// </summary>
        public decimal CostoOriginal { get; set; }

        /// <summary>
        /// Indica que el servicio se solicitó bajo la modalidad express (VIP)
        /// </summary>
        public bool bExpress { get; set; }

        /// <summary>
        /// Porcentaje a facturar por ser express
        /// </summary>
        public decimal PorcentajeVIP { get; set; }

        /// <summary>
        /// Costo total por copias
        /// </summary>
        public decimal CostoCopiaFinal
        {
            get { return CostoCopia + (bExpress ? CostoCopia * (PorcentajeVIP / 100) : 0m); }
        }

        /// <summary>
        /// Costo total por originales
        /// </summary>
        public decimal CostoOriginalFinal
        {
            get { return CostoOriginal + (bExpress ? CostoOriginal * (PorcentajeVIP / 100) : 0m); }
        }

        public DateTime? Fecha
        {
            get;
            set;
        }

        public String NombreCosto
        {
            get { return String.Format("{0} - {1}", Nombre, CostoOriginal); }
        }

        public bool Agregado { get; set; }


    }

    /// <summary>
    /// Extensiones para los documentos requeridos
    /// </summary>
    public static class ServicioDocumentoExtension
    {
        /// <summary>
        /// Calculo de totales por tipo de servicio
        /// </summary>
        /// <param name="servicio">Servicio par el cual se calcula el total</param>
        /// <returns></returns>
        public static decimal GetTotal(this IEnumerable<ServicioDocumentoRequerido> servicio, bool EsVIP)
        {
            decimal total = servicio.Sum(a => a.CostoCopiaFinal * a.CantidadCopia + a.CantidadOriginal * a.CostoOriginalFinal);

            if (EsVIP)
                total *= 2;

            return total;
        }

        /// <summary>
        /// Calcula el total 
        /// </summary>
        /// <param name="servicio"></param>
        /// <param name="cantidadCopiaExoneradasNuevaEmpresa"></param>
        /// <param name="cantidadOriginalExoneradasNuevaEmpresa"></param>
        /// <returns></returns>
        public static decimal GetTotal(this IEnumerable<ServicioDocumentoRequerido> servicio, int cantidadCopiaExoneradasNuevaEmpresa, int cantidadOriginalExoneradasNuevaEmpresa, bool EsVIP)
        {
            var result = servicio.Sum(a => a.CostoCopiaFinal * a.CantidadCopia + a.CantidadOriginal * a.CostoOriginalFinal);

            var copiasExoneradas =
                servicio.Where(a => a.CantidadCopia > 0)
                    .Sum(a => cantidadCopiaExoneradasNuevaEmpresa * a.CostoCopiaFinal);

            var copiasOriginales =
                servicio.Where(a => a.CantidadOriginal > 0).Sum(
                    a => cantidadOriginalExoneradasNuevaEmpresa * a.CostoOriginalFinal);

            decimal valor = result - (copiasExoneradas + copiasOriginales);

            if (EsVIP)
                valor *= 2;

            return valor;
        }
    }
}
