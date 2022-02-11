using System;
using System.Web.Services;
using CamaraComercio.DataAccess.EF.SRM;
using CamaraComercio.WebServices.Helpers;
using CamaraComercio.WebServices.Nobox;

namespace CamaraComercio.WebServices
{
    /// <summary>
    /// Feed de noticias para empresas/sociedades. Retorna JSON Strings
    /// </summary>
    [WebService(Namespace = "http://www.camarasantodomingo.org.do")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class NewsFeedJson : WebService
    {
        [WebMethod(Description = "Realiza una búsqueda de empresas en el sistema de registro mercantil")]
        public string FindEmpresas(string query, TipoBusquedaSociedades tipoBusqueda)
        {
            return DataAccessMethods.FindEmpresas(query, tipoBusqueda, String.Empty).ToJSON();
        }

        [WebMethod(Description = "Realiza una búsqueda de empresas en el sistema de registro mercantil, especificando la cámara")]
        public string FindEmpresasByCamara(string query, TipoBusquedaSociedades tipoBusqueda, string camaraID)
        {
            return DataAccessMethods.FindEmpresas(query, tipoBusqueda, camaraID).ToJSON();
        }

        [WebMethod(Description = "Obtiene el feed de actividades de una empresa a partir de su RNC")]
        public string GetActividadPorEmpresa(string rnc, int cantidadRegistros)
        {
            return DataAccessMethods.GetActividadPorEmpresa(rnc, cantidadRegistros, String.Empty).ToJSON();
        }

        [WebMethod(Description = "Obtiene el feed de actividades de una empresa a partir de su RNC, especificando la cámara")]
        public string GetActividadPorEmpresaCamara(string rnc, int cantidadRegistros, string camaraID)
        {
            return DataAccessMethods.GetActividadPorEmpresa(rnc, cantidadRegistros, camaraID).ToJSON();
        }

        [WebMethod(Description = "Obtiene todas las cámaras activas de la Ventanilla Unica")]
        public string GetAllCamaras()
        {
            return DataAccessMethods.GetAllCamaras().ToJSON();
        }
    }
}
