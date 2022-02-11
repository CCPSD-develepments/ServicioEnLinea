using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamaraComercio.Website.Helpers;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.DataAccess.EF;

namespace CamaraComercio.Website.Operaciones.Shared
{
    /// <summary>
    /// Formulario en el que se especifica la forma de entrega de la solicitud
    /// </summary>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class FormaEntrega : EnvioDatosPage
    {

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormaEntrega.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormaEntrega.Page_Load(object, EventArgs)'
        {
            if (!IsPostBack)
                InitInterface();
        }

        private void InitInterface()
        {
           
            if (String.IsNullOrWhiteSpace(this.CamaraId)) return;

            var helper = new TransaccionDevueltaHelper(Request);
            if (helper.EstaDevuelta())
            {
                UpdateTransaction(helper.ObtenerTransaccionId());
            }

            hlFisica.NavigateUrl = "/Empresas/RevisionDocumentos.aspx" + DefaultQueryString + "&formaEntrega=F";
            hlEnvioDatos.NavigateUrl = "/Empresas/RevisionDocumentos.aspx" + DefaultQueryString + "&formaEntrega=D";

            var dbComun = new Comun.CamaraComunEntities();
            var dbWebsite = new CamaraWebsiteEntities();
            
            var camara = dbComun.Camaras.FirstOrDefault(a => a.ID == this.CamaraId);
            this.ltrNombreCamara.Text = camara.Nombre;
            this.ltrDireccionCamara.Text = camara.Direccion;
            this.lblNoRecibo.Text = this.IdTransaciones.ToString();
            //this.LtServicioNombre.Text = this.IdTransaciones.ToString();

            //Se revisa el servicio asociado
            if (String.IsNullOrEmpty(Request.QueryString["nSolicitud"])) return;
            Int32 nSolicitud;
            if (!Int32.TryParse(Request.QueryString["nSolicitud"], out nSolicitud)) return;

            //Aqui grabo el log de la transaccion que se creo
            LogTransaccionesMethods.GrabarLogTransacciones(nSolicitud, Request.RawUrl, false, User.Identity.Name);

            var trans = dbWebsite.Transacciones.Where(t => t.TransaccionId == nSolicitud).FirstOrDefault();
            if (trans == null) return;
            var serviciosSinDocumentos = Helper.ServicioIdsSinDocumentos;


            if (serviciosSinDocumentos.Contains(trans.ServicioId))
            {

                if (trans.ServicioId == 398)
                {
                    var rpath = DefaultQueryString + "&nservId=" + trans.ServicioId; // Request.QueryString + "&nservId=" + trans.ServicioId;
                    Response.Redirect("/Empresas/DatoGenerales.aspx" + rpath);
                }
                else
                {
                    Response.Redirect("/Empresas/RevisionDocumentos.aspx" + DefaultQueryString);
                }

              


            }


            var serviciosDefault = (ServicioSection)
                    WebConfigurationManager.GetWebApplicationSection("servicioSection");
            var serviciosConstitucion = serviciosDefault.Servicios
                .Select(s => s.ServicioConstitucionId).Distinct().ToList();
            if (serviciosConstitucion.Contains(trans.ServicioId))
                this.pnlSolicitudInclusion.Visible = true;
        }

        private void UpdateTransaction(long transId)
        {
            var transSpecification = new Specification<DataAccess.EF.OficinaVirtual.Transacciones>(x => x.TransaccionId == transId);

            var repTransaccion = new DataAccess.EF.OficinaVirtual.TransaccionesRepository();
            var transaccion = repTransaccion.SelectAll(transSpecification).FirstOrDefault();
            transaccion.Fecha = DateTime.Now;
            transaccion.EstatusTransId = Helper.EstatusTransIdNuevo;

            repTransaccion.Save();
        }
    }
}