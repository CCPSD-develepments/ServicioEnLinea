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
    public partial class TransformacionReduccion : ModificacionPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            //Busco Datos de Sociedad
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

            ltTipoSociedad.Text = String.Format("{0}",
                                                tipoSociedad.FirstOrDefault(a => a.TipoSociedadId == tipoSociedadId).
                                                    Descripcion);
            ltTipoSociedadTit.Text = String.Format("{0}",
                                             tipoSociedad.FirstOrDefault(a => a.TipoSociedadId == tipoSociedadId).
                                                 Descripcion);


            var capAutorizado = Convert.ToDouble(SociedadRegistro.Registros.CapitalAutorizado.GetValueOrDefault());

            //Mostrando y Estableciendo el maximo para el capital Autorizado.
            ltCapAutorizado.Text = String.Format("{0:n}", capAutorizado);
            txtCapitalSocialNuevo.MaxValue = capAutorizado;

            var currentTipoSociedad = tipoSociedad.FirstOrDefault(a => a.TipoSociedadId == tipoSociedadId);
            tipoSociedad.Remove(currentTipoSociedad);

            ddlTipoSociedadNueva.BindCollection(tipoSociedad, TipoSociedad.PropColumns.TipoSociedadId,
                                                TipoSociedad.PropColumns.Descripcion);

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
            //Guardar transaccion
            GuardarObjetoModificacion();

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
            int tipoSociedadId = ddlTipoSociedadNueva.SelectedItem != null
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