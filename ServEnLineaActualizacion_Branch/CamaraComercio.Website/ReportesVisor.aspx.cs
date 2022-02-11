using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamaraComercio.Website.wsReporteRM;

namespace CamaraComercio.Website
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ReportesVisor'
    public partial class ReportesVisor : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ReportesVisor'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ReportesVisor.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ReportesVisor.Page_Load(object, EventArgs)'
        {
            var numRegistro = Convert.ToInt32(Session["numRegistro"]);
            var TipoRegistro = Convert.ToInt32(Session["TipoRegistro"]);
            var CamaraId = Session["CamaraId"].ToString();
            Session.Remove("numRegistro");
            Session.Remove("TipoRegistro");
            string userName = System.Configuration.ConfigurationManager.AppSettings["Usuario"];
            string password = System.Configuration.ConfigurationManager.AppSettings["Password"];

            //WebService
            try
            {
                wsRegistroMercantil wsReportCert = new wsRegistroMercantil();
                var RMCert = wsReportCert.VerCertificadoRM(userName.ToLower(), password, numRegistro, TipoRegistro, CamaraId);

                if (RMCert == string.Empty)
                {
                    this.GenerateCustomError("Su certificado no esta disponible para mostrar con el Nuevo formato. Favor ponerse en contacto con la Camara de Comercio.");
                    return;
                }
                byte[] Reporte = Convert.FromBase64String(RMCert);
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", Reporte.Length.ToString());
                Response.BinaryWrite(Reporte);
                Response.End();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                this.GenerateCustomError("Ha ocurrido un error. Favor ponerse en contacto con la Camara de Comercio.");
            }
        }
    }
}