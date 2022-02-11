using System.Web.Services;
using CamaraComercio.WebServices.GestionWs;
using CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.WebServices.Facturacion
{
    /// <summary>
    /// Servicio de facturacion
    /// </summary>
    [WebService(Namespace = "http://www.registromercantil.org.do/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ServicioFacturacion : SistemaGestionFacturaHandler
    {
        [WebMethod(Description = "Genera un Ncf dependiendo el tipo en el Sistema de Gestión")]
        public string GenerarNcf(string camaraId, int tipoNcf)
        {
            var servicio = new Contabilidad();
            return servicio.GetNcf(CamarasController.GetGestionId(camaraId), tipoNcf);
        }
    }
}