using System;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.Website.Operaciones.Ventanilla
{
    ///<summary>
    /// Página desde donde se inicia la operación de creación de un nuevo registro
    ///</summary>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class NuevoRegistro : FormularioPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Form.DefaultButton = btnNuevoRegistroMercantil.UniqueID;
            
            if (IsPostBack) return;

            InicializarUI();
            Master.NombreActividad = "Solicitud de nuevo registro de empresa";
            if (!this.IsEditMode)
                LimpiarObjetosEnSesion();    
            
        }

        private void InicializarUI()
        {
            //DropdownList de Cámaras
            var camaras = new Comun.CamarasController().FetchAllActivas();
            this.ddlCamaras.BindCollection
                (camaras, Comun.Camaras.PropColumns.ID, Comun.Camaras.PropColumns.Nombre, Helper.IdCamaraPrincipal);

            if (this.IsEditMode)
            {
                this.ddlCamaras.Items.FindByValue(this.CamaraId).Selected = true;
                this.txtNombreNuevaSociedad.Text = this.SociedadRegistroNuevo.NombreSocial;
            }
        }

        // 01 - Registro de nuevas compañías
        protected void btnNuevoRegistroMercantil_Click(object sender, EventArgs e)
        {
            this.RegistroNuevo = new DataAccess.EF.OficinaVirtual.Registros();
            this.SociedadRegistroNuevo = new OFV.Sociedades()
            {
                //Rnc = this.txtNuevoRnc.Text,
                NombreSocial = this.txtNombreNuevaSociedad.Text
            };
            this.RegistroNuevo.RegistroMercantil = 0;
            this.RegistroNuevo.EsNuevoRegistro = true;

            if (!this.IsEditMode)            
                this.CamaraId = ddlCamaras.SelectedValue;

            //cambio del view activo
            Response.Redirect("DatosGenerales.aspx" + DefaultQueryString);
        }

        protected void btnLinkAdecuacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adecuacion.aspx" + DefaultQueryString);
        }
    }
}
