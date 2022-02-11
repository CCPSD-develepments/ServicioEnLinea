using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CamaraComercio.WebServices
{
    /// <summary>
    /// Web Service que maneja la generación de reportes y certificaciones
    /// </summary>
    [WebService(Namespace = "http://www.registromercantil.org.do/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GeneracionReportes : System.Web.Services.WebService
    {
    }
}
