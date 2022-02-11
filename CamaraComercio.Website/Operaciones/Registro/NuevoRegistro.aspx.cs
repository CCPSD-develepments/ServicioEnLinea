using System;
using System.Linq;
using CamaraComercio.DataAccess.EF.CamaraComun;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.Website.Operaciones.Registro
{
    ///<summary>
    /// Página desde donde se inicia la operación de creación de un nuevo registro
    ///</summary>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class NuevoRegistro : FormularioPage
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'NuevoRegistro.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'NuevoRegistro.Page_Load(object, EventArgs)'
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
            var camaras = User.IsInRole("Testers") 
                                     ? new Comun.CamarasController().FetchAll() 
                                     : new Comun.CamarasController().FetchAllActivas();

            this.ddlCamaras.BindCollection
                (camaras, Comun.Camaras.PropColumns.ID, Comun.Camaras.PropColumns.Nombre, Helper.IdCamaraPrincipal);

            if (this.IsEditMode)
            {
                this.ddlCamaras.Items.FindByValue(this.CamaraId).Selected = true;
                this.txtNombreNuevaSociedad.Text = this.SociedadRegistroNuevo.NombreSocial;
            }

            //Tipos de empresas/sociedades que se pueden registrar
            var dbEntities = new Comun.CamaraComunEntities();
            var colEmpresas = dbEntities.TipoSociedad.Where(ts => ts.SiteVisible == true).ToList();
            if (this.RegistroNuevo.EsNuevoRegistro)
            {
                var colEmpresasOrden = colEmpresas.FindAll(a => Helper.TipoSociedadOrdenConstitucion.Contains(a.TipoSociedadId));
                colEmpresasOrden.AddRange(
                    colEmpresas.FindAll(a => !Helper.TipoSociedadOrdenConstitucion.Contains(a.TipoSociedadId)));
                colEmpresas = colEmpresasOrden;
            }
            this.ddAdecuacion.BindCollection(colEmpresas,
                Comun.TipoSociedad.PropColumns.TipoSociedadId,
                Comun.TipoSociedad.PropColumns.Descripcion);

            //Si estamos en modo de edición se establece el ID del tipo de sociedad seleccionado
            if (this.SociedadRegistroNuevo.TipoSociedadId.HasValue)
                this.ddAdecuacion.SelectedValue = this.SociedadRegistroNuevo.TipoSociedadId.ToString();
                
        }

        // 01 - Registro de nuevas compañías
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'NuevoRegistro.btnNuevoRegistroMercantil_Click(object, EventArgs)'
        protected void btnNuevoRegistroMercantil_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'NuevoRegistro.btnNuevoRegistroMercantil_Click(object, EventArgs)'
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


            //Variable que indica si la empresa a constituir es extranjera
            var esExtranjera = Helper.TipoSociedadExtranjera.Contains(Int32.Parse(ddAdecuacion.SelectedValue));
            //Asignacion de valores al objeto sociedad
            var tipoSociedadID = Convert.ToInt32(this.ddAdecuacion.SelectedItem.Value);
            this.TipoSociedadId = tipoSociedadID;
            this.SociedadRegistroNuevo.TipoSociedadId = tipoSociedadID;
            this.SociedadRegistroNuevo.EsNacional = esExtranjera;

            //cambio del view activo
            Response.Redirect("DatosGenerales.aspx" + DefaultQueryString);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'NuevoRegistro.btnLinkAdecuacion_Click(object, EventArgs)'
        protected void btnLinkAdecuacion_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'NuevoRegistro.btnLinkAdecuacion_Click(object, EventArgs)'
        {
            Response.Redirect("Adecuacion.aspx" + DefaultQueryString);
        }
    }
}
