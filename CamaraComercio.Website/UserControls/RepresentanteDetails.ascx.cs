using System;
using CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website.UserControls
{
    ///<summary>
    /// User control para manejo de los detalles de un representante
    ///</summary>
    public partial class RepresentanteDetails : System.Web.UI.UserControl
    {
        private object _dataItem = null;
        ///<summary>
        /// Objeto de datos bindeado
        ///</summary>
        public object DataItem
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RepresentanteDetails.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RepresentanteDetails.Page_Load(object, EventArgs)'
        {
            if (ddlEstadoCivil.Items.Count != 0) return;
            
            var civils = EstadoCivil.FetchAll();
            ddlEstadoCivil.BindCollection(civils, "Value", "Text");
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RepresentanteDetails.Page_PreRender(object, EventArgs)'
        protected void Page_PreRender(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RepresentanteDetails.Page_PreRender(object, EventArgs)'
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


                    if (txtSegundoNombre.Text.Length == 0 && !EditModeEnabled)
                        mvDatosGenerales.ActiveViewIndex = 0;
                }
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RepresentanteDetails.ddlTipoDocumento_SelectedIndexChanged(object, EventArgs)'
        protected void ddlTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RepresentanteDetails.ddlTipoDocumento_SelectedIndexChanged(object, EventArgs)'
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