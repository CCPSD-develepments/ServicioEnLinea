using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CamaraComercio.Website.TarjetaCredito
{
    public partial class TransaccionalTest : System.Web.UI.Page
    {
        public string NumeroSolicitud
        { get { return !String.IsNullOrEmpty(Request.QueryString["nSolicitud"]) ? Request.QueryString["nSolicitud"] : String.Empty; } }

        public string CamaraId
        { get { return !String.IsNullOrEmpty(Request.QueryString["CamaraId"]) ? Request.QueryString["CamaraId"] : String.Empty; } }

        public string TipoSociedadId
        { get { return !String.IsNullOrEmpty(Request.QueryString["TipoSociedadId"]) ? Request.QueryString["TipoSociedadId"] : String.Empty; } }
        
        public string FormaEntrega
        { get { return !String.IsNullOrEmpty(Request.QueryString["formaEntrega"]) ? Request.QueryString["formaEntrega"] : String.Empty; } }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPagoExitoso_Click(object sender, EventArgs e)
        {
            var url = String.Format("PagosTarjeta.aspx?CamaraId={0}&nSolicitud={1}&TipoSociedadId={2}" +
                                    "&formaEntrega={3}&token={4}", new[] {this.CamaraId, this.NumeroSolicitud,
                                    this.TipoSociedadId,this.FormaEntrega, Guid.NewGuid().ToString()});
            Response.Redirect(url);
        }
    }
}