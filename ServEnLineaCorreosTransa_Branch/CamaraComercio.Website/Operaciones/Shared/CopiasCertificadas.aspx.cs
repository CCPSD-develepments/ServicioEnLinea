using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF;
using CamaraComercio.DataAccess.EF.SRM;
using Telerik.Web.UI;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.Website.Operaciones.Shared
{
    ///<summary>
    /// Página para solicitud de copias certificadas
    ///</summary>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class CopiasCertificadas : System.Web.UI.Page
    {
        #region Eventos
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CopiasCertificadas.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CopiasCertificadas.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;

            //Bindeando controles de listas
            BindEnumToDropDown(typeof(SRM.TipoBusquedaSociedades), ddlTipoBusqueda);
            BindCamaras();
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CopiasCertificadas.btnBuscar_Click(object, EventArgs)'
        protected void btnBuscar_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CopiasCertificadas.btnBuscar_Click(object, EventArgs)'
        {
            var camaraID = this.ddlCamara.SelectedItem.Value;
            var sociedadRep = new SumarioRepository(camaraID);
            var query = this.txtBusqueda.Text;

            this.lblHidSelectedCamaraID.Text = camaraID;
            TipoBusquedaSociedades tipoBusqueda;
            Enum.TryParse(this.ddlTipoBusqueda.SelectedItem.Value, out tipoBusqueda);
            
            if (tipoBusqueda == TipoBusquedaSociedades.PorRnc)
                query = query.FormatRnc();

            var sumario = sociedadRep.FindSociedades(query, tipoBusqueda);
            
            rgridEmpresas.DataSource = sumario;
            rgridEmpresas.DataBind();
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CopiasCertificadas.rgridEmpresas_ItemCommand(object, GridCommandEventArgs)'
        protected void rgridEmpresas_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CopiasCertificadas.rgridEmpresas_ItemCommand(object, GridCommandEventArgs)'
        {
            if (e.CommandArgument == null || e.CommandArgument.ToString().Length <= 0) return;

            int noRegistro;
            var values = e.CommandArgument.ToString().Split('-');
            Int32.TryParse(values[0], out noRegistro);
            if (noRegistro > 0)
            {
                this.lblNombreEmpresa.Text = values[1];
                this.lbHidSelectedRegistro.Text = noRegistro.ToString();
                this.rgridDocumentos.DataSourceID = "odsDocumentosTransaccion";
                this.mvCopiasCertificadas.SetActiveView(vDocumentos);
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CopiasCertificadas.btnSeleccionarDocs_Click(object, EventArgs)'
        protected void btnSeleccionarDocs_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CopiasCertificadas.btnSeleccionarDocs_Click(object, EventArgs)'
        {
            //Lista que contiene los id's de los documentos seleccionados
            var docsSeleccionados = new List<Int32>();
            foreach (var row in from GridDataItem row in this.rgridDocumentos.Items
                                let ctrl = row.Cells[5].FindControl("chkSeleccionDoc")
                                where (ctrl is CheckBox)
                                where ((CheckBox)ctrl).Checked
                                select row)
            {
                int docTransaccionId;
                if (!Int32.TryParse(row.Cells[2].Text, out docTransaccionId)) continue;
                docsSeleccionados.Add(docTransaccionId);
            }

            //Se trae la colección de nuevo desde la base de datos
            //(es más fácil llamarlos de nuevo que persistir el objeto en memoria/sesión y cargar al servidor)
            var docRepository = new SRM.DocumentosTransaccionesRepository(this.ddlCamara.SelectedValue);
            int noRegistro;
            if (Int32.TryParse(this.lbHidSelectedRegistro.Text, out noRegistro))
            {
                //Binding de los documentos seleccionados. Se convierte a DataTable para aprovechar funcionalidades automáticas del Telerik Grid
                this.rgridConfirmacionDocs.DataSource = docRepository.GetDocumentosByNoRegistro(noRegistro)
                                                        .Where(d => docsSeleccionados.Contains(d.DocumentoTransaccionID))
                                                        .ToDataTable();
                this.rgridConfirmacionDocs.DataBind();
                this.mvCopiasCertificadas.SetActiveView(vPrecios);
            }
            else
            {
                throw new WebException("Error de acceso a propiedad cambiada client-side");
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CopiasCertificadas.btnModificarDoca_Click(object, EventArgs)'
        protected void btnModificarDoca_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CopiasCertificadas.btnModificarDoca_Click(object, EventArgs)'
        {
            this.mvCopiasCertificadas.SetActiveView(vDocumentos);
        }
        #endregion

        #region Binding Collections

        /// <summary>
        /// Bindeo de Cámaras
        /// </summary>
        private void BindCamaras()
        {
            var camarasCtrl = new Comun.CamarasController().FetchAllActivas(); ;
            ddlCamara.BindCollection(camarasCtrl, Comun.Camaras.PropColumns.ID, Comun.Camaras.PropColumns.Nombre);
        }

        /// <summary>
        /// Bindeo de tipos de búsqueda a un enum 
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="lictrl"></param>
        public void BindEnumToDropDown(Type enumType, ListControl lictrl)
        {
            var itemValues = Enum.GetValues(enumType);
            for (var i = 0; i <= itemValues.Length - 1; i++)
            {
                var val = (int)itemValues.GetValue(i);
                var nombre = EnumHelper<TipoBusquedaSociedades>.ObtenerDescripcion(val);
                var item = new ListItem(nombre, val.ToString());
                lictrl.Items.Add(item);
            }
            lictrl.SelectedIndex = 0;
        }


        #endregion

    }
}