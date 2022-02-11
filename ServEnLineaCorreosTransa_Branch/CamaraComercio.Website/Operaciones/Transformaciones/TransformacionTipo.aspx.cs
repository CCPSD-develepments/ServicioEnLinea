using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.Website.Operaciones.Modificaciones;

namespace CamaraComercio.Website.Operaciones.Transformaciones
{
    /// <summary>
    /// Pagina que contiene la info para la transformacion de sociedad.
    /// </summary>
    public partial class TransformacionTipo : ModificacionPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            //Buscando Datos de Sociedad
            LoadInterfaceValue();

            InitInterface();

            InitCapitalReglas();

            if (this.IsFormularionConfirmacion)
                InitInterface();
        }

        private void LoadInterfaceValue()
        {
            InitializeSociedad();

            var dbComun = new CamaraComunEntities();

            var tipoSociedad =
                dbComun.TipoSociedad.ToList();


            int tipoSociedadId = SociedadRegistro.Sociedades.TipoSociedadId.GetValueOrDefault();
            var capAutorizado = Convert.ToDouble(SociedadRegistro.Registros.CapitalAutorizado.GetValueOrDefault());

            var currentTipoSociedad = tipoSociedad.FirstOrDefault(a => a.TipoSociedadId == tipoSociedadId);

            ltTipoSociedad.Text = String.Format("{0}", currentTipoSociedad.Descripcion);
            ltTipoSociedadTit.Text = String.Format("{0}", currentTipoSociedad.Descripcion);
            tipoSociedad.Remove(currentTipoSociedad);
            ltCapAutorizado.Text = String.Format("{0:n}", capAutorizado);
            txtCapitalSocialNuevo.MinValue = capAutorizado;

            ddlTipoSociedadNueva.BindCollection(tipoSociedad, TipoSociedad.PropColumns.TipoSociedadId,
                                                TipoSociedad.PropColumns.Descripcion);

            var currentServicioId = int.Parse(Request.QueryString["CurrentServicioId"] ?? "0");
            if (currentServicioId != 0)
            {
                var servicio = dbComun.Servicio.First(s => s.ServicioId == currentServicioId);

                if (servicio.TransfDestinoId.HasValue)
                {
                    ddlTipoSociedadNueva.SelectedValue = servicio.TransfDestinoId.GetValueOrDefault().ToString();
                    this.SociedadRegistroNuevo.TipoSociedadId = this.NuevoTipoSociedad;
                    ddlTipoSociedadNueva.Enabled = false;
                }
            }

            ltNombreSocial.Text = this.SociedadRegistro.Sociedades.NombreSocial;
        }

        private void InitInterface()
        {
            if (NuevoTipoSociedad > 0)
                ddlTipoSociedadNueva.SelectedValue = NuevoTipoSociedad.ToString();

            txtCapitalSocialNuevo.Text = this.NuevoCapitalSocial.ToString();

        }

        protected void btnEnviarModificacion_Click(object sender, EventArgs e)
        {
            this.NuevoTipoSociedad = int.Parse(ddlTipoSociedadNueva.SelectedValue);
            this.NuevoCapitalSocial = decimal.Parse(txtCapitalSocialNuevo.Text);

            //Especifico Tipo Servicio
            int servicioId = 0;
            int.TryParse(this.Request.QueryString["CurrentServicioId"], out servicioId);

            if (servicioId <= 0)
            {
                ErrorMessage = "Servicio Invalido.";
                Response.Redirect("~/Operaciones/Modificaciones/SolicitudOperacion.aspx");
            }

            this.ServicioId = servicioId;

            EsTransformacion = true;

            this.ReciboDGII.FechaReciboDGII = radFechaRecibo.SelectedDate;
            this.ReciboDGII.NoReciboDGII = txtNoRecibo.Text;
            this.ReciboDGII.MontoDGII = txtMontoDGII.DecimalValue();


            //Guardar transaccion
            GuardarObjetoModificacion();

            this.SociedadRegistroNuevo.TipoSociedadId = this.NuevoTipoSociedad;

            if (!String.IsNullOrWhiteSpace(ErrorMessage))
            {
                Master.ShowMessageError(ErrorMessage);
                return;
            }
            //Envio a pagina siguiente. 
            GoNextPage();

            SubmitChanges();

            //Envio a pantalla de confirmacion
            if (Redirect)
                Response.Redirect("~/Empresas/RevisionDocumentos.aspx" + DefaultQueryString);
        }

        protected void InitCapitalReglas()
        {
            var tipoSociedadId = ddlTipoSociedadNueva.SelectedItem != null
                                     ? Int32.Parse(ddlTipoSociedadNueva.SelectedValue)
                                     : 0;

            var dbComun = new CamaraComunEntities();
            var tipoSociedad = dbComun.TipoSociedad.FirstOrDefault(a => a.TipoSociedadId == tipoSociedadId) ??
                               new TipoSociedad();

            rvCapitalSocialNuevo.MinimumValue = String.Format("{0:n}", tipoSociedad.CapitalAutorizado);
        }

        /// <summary>
        /// Evento de Dropdown para establecer las reglas dependiendo el tipo de sociedad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlTipoSociedadNueva_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitCapitalReglas();
        }

    }
}