using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Services;
using CamaraComercio.DataAccess.EF;
using CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.WebServices.Servicios
{
    /// <summary>
    /// Clase que maneja la obtención de las cofiguraciones de los servicios del sistema SRM.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiciosSrm : WebService
    {
        private CamaraComunEntities dbComun = new CamaraComunEntities();

        [WebMethod(Description = "Clase que maneja la obtención del listado de servicios desde SRM.")]
        public List<TipoServicio> ObtenerListadoTipoServicos()
        {
            var rep = new Repository<TipoServicio, CamaraComunEntities>(dbComun);
            return rep.SelectAll().Where(s => s.Visible).ToList();
        }

        [WebMethod(Description = "Clase que maneja la obtención del listado de servicios desde SRM.")]
        public List<Servicio> ObtenerListdoServicios(int tipoServicioId)
        {
            //var repServ = new Repository<Servicio, CamaraComunEntities>(dbComun);
            
            //var servicos = new ServicioCollection()
            //    .Where(DataAccess.Comun.Servicio.Columns.Visible, 1)
            //    .Where(DataAccess.Comun.Servicio.Columns.TipoServicioId, tipoServicioId)
            //    .Load();

            //return servicos;
            return null;
        }
        [WebMethod(Description = "Clase que maneja la obtención del listado de servicios desde SRM.")]
        public List<TipoSociedad> ObtenerListadoTipoSociedad()
        {
            //var tipoSociedades = new TipoSociedadCollection()
            //    .Load();

            //return tipoSociedades;
            return null;
        }

        [WebMethod(Description = "Clase que maneja la obtención del listado de servicios desde SRM.")]
        public List<TipoSociedadSufijo> OptenerListadoTipoSociedadesSufijos(int tipoSociedadId)
        {
            //var sufijos = new TipoSociedadSufijoCollection()
            //    .Where(TipoSociedadSufijo.Columns.TipoSociedadId, tipoSociedadId)
            //    .Load();

            //return sufijos;
            return null;
        }

        [WebMethod(Description = "Clase que maneja la obtención del listado de servicios desde SRM.")]
        public List<ViewServicioDocumentoRequerido> ObtenerListadoDocumentosRequeridos(int servicioId, int tipoSociedad)
        {
            //var requisitos = new ViewServicioDocumentoRequeridoCollection()
            //    .Where(ViewServicioDocumentoRequerido.Columns.ServicioId, servicioId)
            //    .Where(ViewServicioDocumentoRequerido.Columns.TipoSociedadId, tipoSociedad)
            //    .Load();

            //return requisitos;
            return null;
        }
        [WebMethod(Description = "Clase que maneja la obtención del listado de servicios desde SRM.")]
        public List<TipoDocumento> ObtenerListadoDocumentos()
        {
            //var documentos = new TipoDocumentoCollection()
            //    .Load();

            //return documentos;
            return null;
        }

        [WebMethod(Description = "Clase que maneja la obtención del listado de servicios desde SRM.")]
        public List<TipoRegla> ObtenerListadoReglas()
        {
            //var reglas = new TipoReglaCollection()
            //    .Load();

            //return reglas;
            return null;
        }
    }
}
