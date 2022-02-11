using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.Website.DTO
{
    ///<summary>
    /// Representacion para el UI de documentos requeridos
    ///</summary>
    [DataObject]
    public class ServicioDocumentoRequeridoUI
    {
        /// <summary>
        /// Retorna todos los documentos requeridos
        /// </summary>
        /// <param name="tipoSociedadId"></param>
        /// <param name="grupo"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IQueryable<ServicioDocumentoRequerido> GetDocumentosRequeridos(int? tipoSociedadId, int grupo = 0)
        {
            var context = HttpContext.Current;
            var servicios = (List<int>)context.Session["Servicios"];
            return (servicios != null && servicios.Count > 0)
                       ? ServicioDocumentosRequeridosControler.GetDocumentosRequeridos(servicios, tipoSociedadId, grupo)
                       : null;
        }

        ///<summary>
        /// Retorna todos los documentos requeridos por grupo
        ///</summary>
        ///<param name="tipoSociedadId"></param>
        ///<returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<int?> GetGrupoDocumentosRequeridos(int? tipoSociedadId)
        {
            var context = HttpContext.Current;
            var servicios = (List<int>)context.Session["Servicios"];
            return (servicios != null && servicios.Count > 0)
                       ? ServicioDocumentosRequeridosControler.GetGrupoDocumentosRequeridos(servicios, tipoSociedadId)
                       : null;
        }
    }
}