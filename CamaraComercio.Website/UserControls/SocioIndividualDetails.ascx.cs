using System;
using System.Collections.Generic;
using CamaraComercio.DataAccess.EF;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using Oficina = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website.UserControls
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioIndividualDetails'
    public partial class SocioIndividualDetails : System.Web.UI.UserControl
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioIndividualDetails'
    {
        private object _dataItem = null;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioIndividualDetails.DataItem'
        public object DataItem
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioIndividualDetails.DataItem'
        {
            get
            {
                return this._dataItem;
            }
            set
            {
                this._dataItem = value;
            }
        }

        /// <summary>
        /// Edit mode is enabled on the grid
        /// </summary>
        public bool EditModeEnabled { get; set; }

        private List<Comun.TipoSocio> ListSociosRender
        {
            get
            {
                if (Session["SociosRender"] == null)
                    return new List<Comun.TipoSocio>();

                return (List<Comun.TipoSocio>)Session["SociosRender"];
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioIndividualDetails.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioIndividualDetails.Page_Load(object, EventArgs)'
        {
            var repCiudades = new Comun.CiudadesRepository();

            if (ddlCiudades.Items.Count == 0)
            {
                var colCiudades = repCiudades.FecthInDominicanRepublic(Helper.CiudadesPrincipales, Helper.IdPaisRD);
                this.ddlCiudades.BindCollection(colCiudades, Comun.Ciudades.PropColumns.CiudadId,
                                                Comun.Ciudades.PropColumns.Nombre);
            }

            if (ddlEstadoCivil.Items.Count == 0)
            {
                var civils = Oficina.EstadoCivil.FetchAll();
                ddlEstadoCivil.BindCollection(civils, "value", "text");
            }

            chlTiposSocios.Visible = ListSociosRender.Count > 0;
            if (!chlTiposSocios.Visible) return;
            chlTiposSocios.DataSource = ListSociosRender;
            chlTiposSocios.BindCollection(ListSociosRender, "TipoSocioId", "Descripcion");
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioIndividualDetails.Page_PreRender(object, EventArgs)'
        protected void Page_PreRender(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioIndividualDetails.Page_PreRender(object, EventArgs)'
        {
            //Load verification for Empresas
            if (!(DataItem is Telerik.Web.UI.GridInsertionObject))
            {
                if (btnUpdate.Visible)
                {
                    if (!string.IsNullOrEmpty(litTipoDocumento.Text))
                    {
                        if (litTipoDocumento.Text == "C")
                        {
                            ddlTipoDocumento.SelectedIndex = 0;
                            txtTitleDocumento.Text = "Cédula";
                            regexCedula.Enabled = true;
                        }
                        else
                        {
                            ddlTipoDocumento.SelectedIndex = 1;
                            txtTitleDocumento.Text = "Pasaporte";
                            regexCedula.Enabled = false;
                        }
                    }

                    if (!string.IsNullOrEmpty(litCiudadID.Text) && !string.IsNullOrEmpty(litSectorID.Text))
                    {
                        //Se marca la ciudad
                        ddlCiudades.SelectedValue = litCiudadID.Text;

                        //Se refresca el listado de sectores de la ciudad
                        ddlSectores.DataBind();

                        //Se marca el sector
                        ddlSectores.SelectedValue = litSectorID.Text;
                    }

                    if (txtSegundoNombre.Text.Length == 0 && !EditModeEnabled)
                    {
                        mvDatosGenerales.ActiveViewIndex = 1;
                    }
                }
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioIndividualDetails.ddlTipoDatos_SelectedIndexChanged(object, EventArgs)'
        protected void ddlTipoDatos_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioIndividualDetails.ddlTipoDatos_SelectedIndexChanged(object, EventArgs)'
        {
            EditModeEnabled = true;
            if (ddlTipoDatos.SelectedValue == "Empresa")
            {
                ddlTipoDatosEmpresa.SelectedIndex = 1;
                mvDatosGenerales.SetActiveView(vSocioEmpresa);
                if (txtPrimerNombre.Text.Length > 0)
                {
                    txtEmpresa.Text = txtPrimerNombre.Text;
                }
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioIndividualDetails.ddlTipoDatosEmpresa_SelectedIndexChanged(object, EventArgs)'
        protected void ddlTipoDatosEmpresa_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioIndividualDetails.ddlTipoDatosEmpresa_SelectedIndexChanged(object, EventArgs)'
        {
            EditModeEnabled = true;
            if (ddlTipoDatosEmpresa.SelectedValue == "Persona")
            {
                ddlTipoDatos.SelectedIndex = 0;
                mvDatosGenerales.SetActiveView(vSocioPersona);
                if (txtEmpresa.Text.Length > 0)
                {
                    txtPrimerNombre.Text = txtEmpresa.Text;
                }
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioIndividualDetails.ddlTipoDocumento_SelectedIndexChanged(object, EventArgs)'
        protected void ddlTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioIndividualDetails.ddlTipoDocumento_SelectedIndexChanged(object, EventArgs)'
        {
            if (ddlTipoDocumento.SelectedValue == "P")
            {
                txtTitleDocumento.Text = "Pasaporte";
                regexCedula.Enabled = false;
            }
            else
            {
                txtTitleDocumento.Text = "Cédula";
                regexCedula.Enabled = true;
            }
        }

    }
}