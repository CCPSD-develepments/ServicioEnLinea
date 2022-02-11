using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.Website.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CamaraComercio.Website.Formularios
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormViewer'
    public partial class FormViewer : FormularioPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormViewer'
    {
#pragma warning disable CS0108 // 'FormViewer.IdTransaciones' hides inherited member 'EnvioDatosPage.IdTransaciones'. Use the new keyword if hiding was intended.
        /// <summary>
        /// IDs de transacciones a las que se asocian los documentos
        /// </summary>
        public int IdTransaciones
#pragma warning restore CS0108 // 'FormViewer.IdTransaciones' hides inherited member 'EnvioDatosPage.IdTransaciones'. Use the new keyword if hiding was intended.
        {
            get { return !String.IsNullOrWhiteSpace(Request.QueryString["nSolicitud"]) ? int.Parse(Request.QueryString["nSolicitud"]) : 0; }
            set { DefaultQueryString = String.Format("nSolicitud={0}", value); }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormViewer.EsCertificacion'
        public bool EsCertificacion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormViewer.EsCertificacion'
        {
            get
            {
                bool result;
                var val = !String.IsNullOrWhiteSpace(Request.QueryString["esCertificacion"])
                            ? Request.QueryString["esCertificacion"] == "1"
                            : false;
                result = val;
                if (!val)
                {
                    var valF =!String.IsNullOrWhiteSpace(Request.QueryString["EsCertificacion"])
                                ? Request.QueryString["EsCertificacion"] == "1"
                                : false;
                    result = valF;
                }
                return result;
            }
        }

#pragma warning disable CS0108 // 'FormViewer.BackUrl' hides inherited member 'EnvioDatos.BackUrl'. Use the new keyword if hiding was intended.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormViewer.BackUrl'
        protected string BackUrl
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormViewer.BackUrl'
#pragma warning restore CS0108 // 'FormViewer.BackUrl' hides inherited member 'EnvioDatos.BackUrl'. Use the new keyword if hiding was intended.
        {
            get
            {
                /*var noSolicitud = Request.QueryString["nSolicitud"];
                var tipoModeloId = Request.QueryString["TipoModeloId"];
                var esCertificacion = Request.QueryString["EsCertificacion"];
                var camaraId = Request.QueryString["CamaraId"];

                return $"~/Empresas/RevisionDocumentos.aspx?nSolicitud={noSolicitud}&TipoModeloId={tipoModeloId}&EsCertificacion={esCertificacion}&CamaraId={camaraId}";*/
                var helper = new TransaccionDevueltaHelper(Request);
                string queryString = DefaultQueryString;
                if (helper.EstaDevuelta() && !queryString.Contains("estado="))
                    queryString += "&estado=devuelto";
                return $"~/Empresas/RevisionDocumentos.aspx{queryString}";
            }
        }

#pragma warning disable CS0108 // 'FormViewer.Page_Load(object, EventArgs)' hides inherited member 'EnvioDatos.Page_Load(object, EventArgs)'. Use the new keyword if hiding was intended.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormViewer.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormViewer.Page_Load(object, EventArgs)'
#pragma warning restore CS0108 // 'FormViewer.Page_Load(object, EventArgs)' hides inherited member 'EnvioDatos.Page_Load(object, EventArgs)'. Use the new keyword if hiding was intended.
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated) Response.Redirect("~/Empresas/Oficina.aspx");
            var db = new CamaraWebsiteEntities();
            var transaccion = db.Transacciones.FirstOrDefault(a => a.TransaccionId.Equals(IdTransaciones));
            string queryString = DefaultQueryString;
            int TipoServicioId;
            int.TryParse(Request.QueryString["TipoServicioId"], out TipoServicioId);

            bool cert = false;
            if (transaccion != null)
            {
                cert = transaccion.EsCertificacion.Equals(true) ? true : false ;
            }

            if (cert && TipoServicioId != 17)
            {
                this.Label1.Text = "/Formularios/Certificacion.aspx" + queryString;
            }
            else
            {
                if (transaccion.ServicioId == 686 || transaccion.ServicioId == 741)
                {
                    this.Label1.Text = "/Formularios/SolicitudIinclusionEmpresa.aspx" + queryString;
                }
               
                else
                {
                    switch (transaccion.TipoSociedadId)
                    {
                        case 1:
                            this.Label1.Text = "/Formularios/SociedadAnonima.aspx" + queryString;
                            break;
                        case 2:
                            this.Label1.Text = "/Formularios/SociedadResponsabilidadLimitada.aspx" + queryString;
                            break;
                        case 3:
                            this.Label1.Text = "/Formularios/SociedadNombreColectivo.aspx" + queryString;
                            break;
                        case 4:
                            this.Label1.Text = "/Formularios/SociedadCSimple.aspx" + queryString;
                            break;
                        case 5:
                            this.Label1.Text = "/Formularios/SociedadCPorAcciones.aspx" + queryString;
                            break;
                        case 7:
                            this.Label1.Text = "/Formularios/PersonaFisica.aspx" + queryString;
                            break;
                        case 16:
                            this.Label1.Text = "/Formularios/SociedadAnonimaSimplificada.aspx" + queryString;
                            break;
                        case 13:
                            this.Label1.Text = "/Formularios/SociedadExtranjera.aspx" + queryString;
                            break;
                        default:
                            this.Label1.Text = "/Formularios/SociedadEIRL.aspx" + queryString;
                            break;
                    }
                }

            }

            FormularioURL = this.Label1.Text;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormViewer.btnBack_Click(object, EventArgs)'
#pragma warning disable CS0108 // 'FormViewer.btnBack_Click(object, EventArgs)' hides inherited member 'EnvioDatos.btnBack_Click(object, EventArgs)'. Use the new keyword if hiding was intended.
        protected void btnBack_Click(object sender, EventArgs e)
#pragma warning restore CS0108 // 'FormViewer.btnBack_Click(object, EventArgs)' hides inherited member 'EnvioDatos.btnBack_Click(object, EventArgs)'. Use the new keyword if hiding was intended.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormViewer.btnBack_Click(object, EventArgs)'
        {
            Response.Redirect(BackUrl);
        }
    }
}