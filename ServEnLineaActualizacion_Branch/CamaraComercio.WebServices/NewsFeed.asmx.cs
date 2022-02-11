using System;
using System.Collections.Generic;
using System.Web.Services;
using CamaraComercio.DataAccess.EF.SRM;
using CamaraComercio.WebServices.Nobox;

namespace CamaraComercio.WebServices
{
    /// <summary>
    /// Feed de noticias para empresas/sociedades
    /// </summary>
    [WebService(Namespace = "http://www.camarasantodomingo.org.do")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class NewsFeed : WebService
    {
        [WebMethod(Description = "Realiza una búsqueda de empresas en el sistema de registro mercantil")]
        public List<SociedadDTO> FindEmpresas(string query, TipoBusquedaSociedades tipoBusqueda)
        {
            return DataAccessMethods.FindEmpresas(query, tipoBusqueda, String.Empty);
        }

        [WebMethod(Description = "Realiza una búsqueda de empresas en el sistema de registro mercantil, especificando la cámara")]
        public List<SociedadDTO> FindEmpresasByCamara(string query, TipoBusquedaSociedades tipoBusqueda, string camaraID)
        {
            return DataAccessMethods.FindEmpresas(query, tipoBusqueda, camaraID);
        }

        [WebMethod(Description = "Obtiene el feed de actividades de una empresa a partir de su RNC")]
        public List<ActividadDTO> GetActividadPorEmpresa(string rnc, int cantidadRegistros)
        {
            return DataAccessMethods.GetActividadPorEmpresa(rnc, cantidadRegistros, String.Empty);
        }

        [WebMethod(Description = "Obtiene el feed de actividades de una empresa a partir de su RNC, especificando la cámara")]
        public List<ActividadDTO> GetActividadPorEmpresaCamara(string rnc, int cantidadRegistros, string camaraID)
        {
            return DataAccessMethods.GetActividadPorEmpresa(rnc, cantidadRegistros, camaraID);
        }

        [WebMethod(Description = "Obtiene todas las cámaras activas de la Ventanilla Unica")]
        public List<CamaraDTO> GetAllCamaras()
        {
            return DataAccessMethods.GetAllCamaras();
        }
    }
}
