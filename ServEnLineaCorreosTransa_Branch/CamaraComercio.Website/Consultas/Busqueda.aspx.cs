using CamaraComercio.DataAccess.EF;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.SRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using SRM = CamaraComercio.DataAccess.EF.SRM;


namespace CamaraComercio.Website.Consultas
{
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Busqueda'
    public partial class Busqueda : SecurePage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Busqueda'
    {
        private int transaccionId;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;

            InitInterface();
        }

        /// <summary>
        /// Inicializa las colecciones necesarias para la búsqueda
        /// </summary>
        private void InitInterface()
        {
            //Camaras DropdownB
            var camaraCol = User.IsInRole("Testers")
                ? new CamarasController().FetchAll()
                : new CamarasController().FetchAllActivas();

            var camaraDefault = Helper.IdCamaraPrincipal;
            this.ddlCamara.BindCollection(camaraCol, Camaras.PropColumns.ID, Camaras.PropColumns.Nombre, camaraDefault);
            this.ddlCamaraPF.BindCollection(camaraCol, Camaras.PropColumns.ID, Camaras.PropColumns.Nombre, camaraDefault);
            this.ddlCamaraAccionistas.BindCollection(camaraCol, Camaras.PropColumns.ID, Camaras.PropColumns.Nombre, camaraDefault);
            if (!User.IsInRole("Testers"))
            {
                this.ddlCamara.Enabled = false;
                this.ddlCamaraPF.Enabled = false;
                this.ddlCamaraAccionistas.Enabled = false;
            }

            //Tipos de búsqueda
            var itemValues = Enum.GetValues(typeof(TipoBusquedaSociedades));
            for (var i = 0; i <= itemValues.Length - 1; i++)
            {
                var val = (int)itemValues.GetValue(i);
                var nombre = EnumHelper<TipoBusquedaSociedades>.ObtenerDescripcion(val);
                var item = new ListItem(nombre, val.ToString());
                this.ddlTipoBusqueda.Items.Add(item);
                this.ddlTipoBusquedaPF.Items.Add(item);
            }
            this.ddlTipoBusqueda.SelectedIndex = 0;
            this.ddlTipoBusquedaPF.SelectedIndex = 0;
            lblBusquedaExactaPF.Visible = false;

        }

        #region Busqueda de Empresas

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.btnBuscar_Click(object, EventArgs)'
        protected void btnBuscar_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.btnBuscar_Click(object, EventArgs)'
        {
            LoadData();
            rgridEmpresas.DataBind();
            rgridEmpresas.Visible = true;
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.rgridEmpresas_ItemDataBound(object, GridItemEventArgs)'
        protected void rgridEmpresas_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.rgridEmpresas_ItemDataBound(object, GridItemEventArgs)'
        {

            if (e.Item.ItemType != GridItemType.Item &&
                e.Item.ItemType != GridItemType.AlternatingItem) return;

            int sociedadId;
            int registroId;
            var camaraId = this.lblHidSelectedCamaraID.Value;

            Int32.TryParse(e.Item.Cells[2].Text, out sociedadId);
            Int32.TryParse(e.Item.Cells[3].Text, out registroId);

            var ctrl = e.Item.FindControl("lnkVerDetalleId");
            if (!(ctrl is HyperLink)) return;

            var lnk = (HyperLink)ctrl;
            lnk.NavigateUrl = String.Format("VerDetalleEmpresa.aspx?sociedadId" +
                "={0}&registroId={1}&CamaraId={2}", sociedadId, registroId, camaraId);

            
        }

        #endregion


        #region Busqueda de Persona Fisica
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.btnBuscarPF_Click(object, EventArgs)'
        protected void btnBuscarPF_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.btnBuscarPF_Click(object, EventArgs)'
        {
            var camaraId = this.ddlCamaraPF.SelectedValue;
            this.lblHidSelectedCamaraID.Value = camaraId;
            this.lblMensajePF.Text = "";
            var query = string.Empty;

            if (String.IsNullOrEmpty(txtBusquedaPF.Text.Trim()) && txtBusquedaPF.Visible)
            {
                this.lblMensajePF.Text = "Debe digitar por lo menos un parametro de busqueda";
                return;
            }
            TipoBusquedaSociedades tipoBusqueda;
            Enum.TryParse(this.ddlTipoBusquedaPF.SelectedItem.Value, out tipoBusqueda);
            if (tipoBusqueda == TipoBusquedaSociedades.PorRnc)
            {
                if (txtBusquedaRNCPF.Text.ToString().Length < 9)
                {
                    this.lblMensajePF.Text = "Asegure que está ingresando un docuemnto valido";
                    return;
                }
                query = Regex.Replace(txtBusquedaRNCPF.Text, @"[^\d]", "").FormatRnc();
                var personascontroller = new SRM.PersonaFisicaController();
                var personasRegistro = personascontroller.ObtenerPersonaRegistroByDocumentoRnc(ckbBusquedaExactaPF.Checked, query, camaraId);

                //Databind
                this.rgridEmpresasPF.DataSource = personasRegistro;
                this.rgridEmpresasPF.DataBind();
                this.rgridEmpresasPF.Visible = true;
                this.panelEmpresasFilterPF.Visible = true;
            }
            else if (tipoBusqueda == TipoBusquedaSociedades.PorNoRegistro)
            {
                var personascontroller = new SRM.PersonaFisicaController();
                query = Regex.Replace(txtBusquedaRPF.Text, @"[^\d]", "");
                var personasRegistro = personascontroller.ObtenerPersonaRegistroByRM(ckbBusquedaExactaPF.Checked, query, camaraId);
                //Databind
                this.rgridEmpresasPF.DataSource = personasRegistro;
                this.rgridEmpresasPF.DataBind();
                this.rgridEmpresasPF.Visible = true;
                this.panelEmpresasFilterPF.Visible = true;
            }
            else if (tipoBusqueda == TipoBusquedaSociedades.PorNombre)
            {
                var personascontroller = new SRM.PersonaFisicaController();
                var personasRegistro = personascontroller.ObtenerPersonaRegistroByName(ckbBusquedaExactaPF.Checked, txtBusquedaPF.Text, camaraId);
                this.rgridEmpresasPF.DataSource = personasRegistro;
                this.rgridEmpresasPF.DataBind();
                this.rgridEmpresasPF.Visible = true;
                this.panelEmpresasFilterPF.Visible = true;
            }
            else
            {
                this.lblMensajePF.Text =
                    "Estamos Trabajando puede realizar la busqueda Por RNC o Cedula";
                this.rgridEmpresasPF.Visible = false;
                this.panelEmpresasFilterPF.Visible = false;
            }

            //Mensaje de error para búsquedas grandes
            if (this.rgridEmpresasPF.Items.Count == 50)
                this.lblMensajePF.Text =
                    "Su búsqueda arrojo demasiados resultados, solo se muestran los primeros 50. Intente hacer su búsqueda más específica";


        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.rgridEmpresasPF_ItemDataBound(object, GridItemEventArgs)'
        protected void rgridEmpresasPF_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.rgridEmpresasPF_ItemDataBound(object, GridItemEventArgs)'
        {
            if (e.Item.ItemType != GridItemType.Item &&
                e.Item.ItemType != GridItemType.AlternatingItem) return;

            int personaId;
            int registroId;
            var camaraId = this.lblHidSelectedCamaraID.Value;

            Int32.TryParse(e.Item.Cells[2].Text, out personaId);
            Int32.TryParse(e.Item.Cells[3].Text, out registroId);
            var dt = (e.Item.DataItem as PersonasRegistros);
            var nombreCompleto = string.Format("{0} {1} {2} {3}", dt.Personas.PrimerNombre, dt.Personas.SegundoNombre
                , dt.Personas.PrimerApellido, dt.Personas.SegundoApellido);
            var lblNombreC = (Label)e.Item.FindControl("NombreCompletoGrid");
            lblNombreC.Text = nombreCompleto;
            var fechaInicioOperacion = (Label)e.Item.FindControl("lblFecha");
            fechaInicioOperacion.Text = string.Format("{0:dd/MM/yyyy}", dt.Registros.FechaInicioOperacion);

            var ctrl = e.Item.FindControl("lnkVerDetalleId");
            if (!(ctrl is HyperLink)) return;

            var lnk = (HyperLink)ctrl;
            lnk.NavigateUrl = String.Format("VerDetalleEmpresa.aspx?sociedadId=" +
                "&personaId={0}&registroId={1}&CamaraId={2}", personaId, registroId, camaraId);
        }
        #endregion

        #region Busqueda de personas
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.btnBuscarSocios_Click(object, EventArgs)'
        protected void btnBuscarSocios_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.btnBuscarSocios_Click(object, EventArgs)'
        {
            var camaraId = this.ddlCamaraAccionistas.SelectedValue;
            this.lblHidSelectedCamaraID.Value = camaraId;
            this.lblMensajeSocios.Text = "";

            //Se revisa que se haya insertado por lo menos un parámetro de búsqueda
            if (String.IsNullOrEmpty(txtNombre.Text.Trim()) && String.IsNullOrEmpty(txtSegundoNombre.Text.Trim()) &&
                 String.IsNullOrEmpty(txtApellido.Text.Trim()) && String.IsNullOrEmpty(txtSegundoApellido.Text.Trim()) &&
                 String.IsNullOrEmpty(txtCedula.Text.Trim()))
            {
                this.lblMensajeSocios.Text = "Debe digitar por lo menos un parámetro de búsqueda";
                return;
            }

            var personaRep = new PersonaRepository(camaraId);
            var personaCol = personaRep.FindPersona(txtNombre.Text.Trim(), txtSegundoNombre.Text.Trim(),
                                txtApellido.Text.Trim(), txtSegundoApellido.Text.Trim(), txtCedula.Text.Trim().FormatRnc());

            var personaColAcc = personaRep.FindPersona
                                (txtNombre.Text.Trim().RemoverAcentos(),
                                 txtSegundoNombre.Text.Trim().RemoverAcentos(),
                                 txtApellido.Text.Trim().RemoverAcentos(),
                                 txtSegundoApellido.Text.Trim().RemoverAcentos(),
                                 txtCedula.Text.Trim().FormatRnc());
            if (personaColAcc.Count() > 0)
                personaCol = personaCol.Union(personaColAcc);

            //Query de búsqueda para la próxima pantalla
            if (this.txtCedula.Text.Trim().Length > 0)
            {
                this.hfSearchQry.Value = this.txtCedula.Text.Trim();
            }
            else
            {
                var sb = new StringBuilder();
                if (this.txtNombre.Text.Trim().Length > 0) sb.Append(this.txtNombre.Text.Trim());
                if (this.txtSegundoNombre.Text.Trim().Length > 0) sb.Append(" " + this.txtSegundoNombre.Text.Trim());
                if (this.txtApellido.Text.Trim().Length > 0) sb.Append(" " + this.txtApellido.Text.Trim());
                if (this.txtSegundoApellido.Text.Trim().Length > 0) sb.Append(" " + this.txtSegundoApellido.Text.Trim());
                this.hfSearchQry.Value = sb.ToString();
            }

            //Databind
            this.rgBusquedaSocios.DataSource = personaCol;
            this.rgBusquedaSocios.DataBind();
            this.rgBusquedaSocios.Visible = true;

            //Mensaje de error para búsquedas grandes
            if (this.rgBusquedaSocios.Items.Count == 50)
                this.lblMensajeSocios.Text =
                    "Su búsqueda arrojo demasiados resultados, solo se muestran los primeros 50. Intente hacer su búsqueda más específica";
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.rgBusquedaSocios_ItemDataBound(object, GridItemEventArgs)'
        protected void rgBusquedaSocios_ItemDataBound(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.rgBusquedaSocios_ItemDataBound(object, GridItemEventArgs)'
        {
            if (e.Item.ItemType != GridItemType.Item &&
               e.Item.ItemType != GridItemType.AlternatingItem) return;

            int personaId;
            var camaraId = this.lblHidSelectedCamaraID.Value;

            Int32.TryParse(e.Item.Cells[2].Text, out personaId);

            var ctrl = e.Item.FindControl("lnkVerPersona");
            if (!(ctrl is HyperLink)) return;

            var lnk = (HyperLink)ctrl;
            lnk.NavigateUrl = String.Format("VerDetalleSocio.aspx?personaId={0}&CamaraId={1}&qry={2}"
                , personaId, camaraId, this.hfSearchQry.Value);
        }
        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.lnkCertNoExiste_Click(object, EventArgs)'
        protected void lnkCertNoExiste_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.lnkCertNoExiste_Click(object, EventArgs)'
        {
            int servicioId = Helper.ServicioIdRmNoExiste;
            int modeloId = Helper.ModeloIdRmNoExiste;
            string camaraId = ddlCamara.SelectedValue;
            var noEspesificada = !String.IsNullOrEmpty(txtBusqueda.Text) ? txtBusqueda.Text : "N/A";

            RegisterTransaction(servicioId, modeloId);

            if (!DefaultQueryString.Contains("nSolicitud="))
                DefaultQueryString = String.Format("nSolicitud={0}&TipoModeloId={1}&EsCertificacion=1&CamaraId={2}&NoEspecificada={3}&EntregaDigital={4}", transaccionId, modeloId, camaraId, noEspesificada,false);

            Session["DocumentosSeleccionados"] = null;

            //Response.Redirect("~/TarjetaCredito/PagosTarjeta.aspx" + DefaultQueryString);
            Response.Redirect("~/Empresas/RevisionDocumentos.aspx" + DefaultQueryString);
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.lnkCertNoExistePF_Click(object, EventArgs)'
        protected void lnkCertNoExistePF_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.lnkCertNoExistePF_Click(object, EventArgs)'
        {
            int servicioId = Helper.ServicioIdRmNoExiste;
            int modeloId = Helper.ModeloIdRmNoExiste;
            string camaraId = ddlCamara.SelectedValue;
            var noEspesificada = !String.IsNullOrEmpty(txtBusquedaPF.Text) ? txtBusquedaPF.Text : "N/A";
            if (!String.IsNullOrEmpty(txtBusquedaRNC.Text) || !String.IsNullOrEmpty(txtBusquedaR.Text))
            {
                this.lblMensajePF.Text = "No puede realizar esta transacción.";
                return;
            }

            RegisterTransaction(servicioId, modeloId);

            if (!DefaultQueryString.Contains("nSolicitud="))
                DefaultQueryString = String.Format("nSolicitud={0}&TipoModeloId={1}&EsCertificacion=1&CamaraId={2}&NoEspecificada={3}&EntregaDigital={4}", transaccionId, modeloId, camaraId, noEspesificada, false);

            Session["DocumentosSeleccionados"] = null;

            //Response.Redirect("~/TarjetaCredito/PagosTarjeta.aspx" + DefaultQueryString);
            Response.Redirect("~/Empresas/RevisionDocumentos.aspx" + DefaultQueryString);
        }

        private bool RegisterTransaction(int servicioId, int? modeloId = null)
        {
            var transaccion = new OFV.Transacciones
            {
                Fecha = DateTime.Now,
                NombreContacto = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                ModificacionCapital = 0m,
                CapitalSocial = 0m,
                RNCSolicitante = ((OficinaVirtualUserProfile)Context.Profile).RNC,
                ServicioId = servicioId,
                UserName = User.Identity.Name.ToLower(),
                CamaraId = this.ddlCamara.SelectedValue,
                EstatusTransId = 40,
                Solicitante = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono,
                NombreSocialPersona = this.txtBusqueda.Text,
                TipoModeloId = modeloId,
                EsCertificacion = true,
            };

            OFV.TransaccionesRepository repTransaccion = new OFV.TransaccionesRepository();

            OFV.TransaccionesDocDescargas docs = new OFV.TransaccionesDocDescargas();
            docs.UserName = User.Identity.Name.ToLower();
            docs.FechaDescarga = DateTime.Today;

            TipoBusquedaSociedades tipoBusqueda = TipoBusquedaSociedades.PorNombre;

            Enum.TryParse<TipoBusquedaSociedades>(ddlTipoBusqueda.SelectedValue, out tipoBusqueda);

            switch (tipoBusqueda)
            {
                case TipoBusquedaSociedades.PorNombre:
                    docs.NombreSocialOrComment = " con el Nombre " + txtBusqueda.Text;
                    break;
                case TipoBusquedaSociedades.PorNoRegistro:
                    docs.NombreSocialOrComment = " con el Registro Mércantil " + txtBusqueda.Text;
                    break;

                case TipoBusquedaSociedades.PorRnc:
                    docs.NombreSocialOrComment = " con el Registro Nacional de Contribuyente (RNC) " + txtBusqueda.Text;
                    break;
            }

            transaccion.TransaccionesDocDescargas.Add(docs);

            repTransaccion.Add(transaccion);

            var result = repTransaccion.Save() > 0;

            transaccionId = transaccion.TransaccionId;

            return result;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.rgridEmpresas_NeedDataSource(object, GridNeedDataSourceEventArgs)'
        protected void rgridEmpresas_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.rgridEmpresas_NeedDataSource(object, GridNeedDataSourceEventArgs)'
        {
            var start = rgridEmpresas.MasterTableView.CurrentPageIndex * rgridEmpresas.MasterTableView.PageSize;
            var length = rgridEmpresas.MasterTableView.PageSize;
            LoadData(start, length);
        }

        private void LoadData(int start = 0, int length = 20)
        {
            var camaraID = this.ddlCamara.SelectedItem.Value;
            var sociedadRep = new SumarioRepository(camaraID);
            this.lblHidSelectedCamaraID.Value = camaraID;

            //Formateo de la búsqueda dependiendo del tipo de usuario
            TipoBusquedaSociedades tipoBusqueda;
            Enum.TryParse(this.ddlTipoBusqueda.SelectedItem.Value, out tipoBusqueda);
            var query = String.Empty;

            if (tipoBusqueda == TipoBusquedaSociedades.PorNombre)
                query = this.txtBusqueda.Text;
            else if (tipoBusqueda == TipoBusquedaSociedades.PorRnc)
                query = Regex.Replace(this.txtBusquedaRNC.Text, @"[^\d]", "").FormatRnc();
            else if (tipoBusqueda == TipoBusquedaSociedades.PorNoRegistro)
                query = Regex.Replace(this.txtBusquedaR.Text, @"[^\d]", "");


            lblMensajeSociedades.Text = string.Empty;
            txtEmpresasFilter.Text = string.Empty;
            panelEmpresasFilter.Visible = false;

            if (string.IsNullOrWhiteSpace(query))
            {
                lblMensajeSociedades.Text = "Debe digitar al menos una letra";
                rgridEmpresas.DataSource = new List<object>();
                rgridEmpresas.VirtualItemCount = 0;
                return;
            }

            panelEmpresasFilter.Visible = true;

            if (tipoBusqueda == TipoBusquedaSociedades.PorRnc)
                query = query.FormatRnc();

            //Si se hace la busqueda por nombre y no arrojó nada, se intenta nuevamente sin los acentos
            var datatable = sociedadRep.FindSociedadesDt(query, tipoBusqueda, ckbBusquedaExacta.Checked, start, length);

            if (datatable.Items.Count() == 0 && tipoBusqueda == TipoBusquedaSociedades.PorNombre)
                datatable = sociedadRep.FindSociedadesDt(query.RemoverAcentos(), tipoBusqueda, ckbBusquedaExacta.Checked, start, length);

            //Bind a los grids correspondientes
            rgridEmpresas.DataSource = datatable.Items.ToList();
            rgridEmpresas.VirtualItemCount = datatable.TotalRows;

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.ddlTipoBusquedaPF_SelectedIndexChanged(object, EventArgs)'
        protected void ddlTipoBusquedaPF_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.ddlTipoBusquedaPF_SelectedIndexChanged(object, EventArgs)'
        {
            TipoBusquedaSociedades tipoBusqueda;
            Enum.TryParse(this.ddlTipoBusquedaPF.SelectedItem.Value, out tipoBusqueda);

            if (tipoBusqueda == TipoBusquedaSociedades.PorNombre)
            {
                txtBusquedaPF.Visible = true;
                txtBusquedaRNCPF.Text = "";
                txtBusquedaRNCPF.Visible = false;
                txtBusquedaRPF.Text = "";
                txtBusquedaRPF.Visible = false;
                lblMensajePF.Text = "";
                ddTipoDocumento.Visible = false;
            }
            else if (tipoBusqueda == TipoBusquedaSociedades.PorRnc)
            {
                txtBusquedaPF.Text = "";
                txtBusquedaPF.Visible = false;
                txtBusquedaRNCPF.Visible = true;
                txtBusquedaRPF.Text = "";
                txtBusquedaRPF.Visible = false;
                lblMensajePF.Text = "";
                ddTipoDocumento.Visible = true;
            }
            else if (tipoBusqueda == TipoBusquedaSociedades.PorNoRegistro)
            {
                txtBusquedaPF.Visible = false;
                txtBusquedaPF.Text = "";
                txtBusquedaRNCPF.Visible = false;
                txtBusquedaRNCPF.Text = "";
                txtBusquedaRPF.Visible = true;
                lblMensajePF.Text = "";
                ddTipoDocumento.Visible = false;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.ddlTipoBusqueda_SelectedIndexChanged(object, EventArgs)'
        protected void ddlTipoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.ddlTipoBusqueda_SelectedIndexChanged(object, EventArgs)'
        {
            TipoBusquedaSociedades tipoBusqueda;
            Enum.TryParse(this.ddlTipoBusqueda.SelectedItem.Value, out tipoBusqueda);

            if (tipoBusqueda == TipoBusquedaSociedades.PorNombre)
            {
                txtBusqueda.Visible = true;
                txtBusquedaRNC.Text = "";
                txtBusquedaRNC.Visible = false;
                txtBusquedaR.Text = "";
                txtBusquedaR.Visible = false;
                lblMensajeSociedades.Text = "";
                ddTipoDocumentoSoc.Visible = false;
            }
            else if (tipoBusqueda == TipoBusquedaSociedades.PorRnc)
            {
                txtBusqueda.Text = "";
                txtBusqueda.Visible = false;
                txtBusquedaRNC.Visible = true;
                txtBusquedaR.Text = "";
                txtBusquedaR.Visible = false;
                lblMensajeSociedades.Text = "";
                ddTipoDocumentoSoc.Visible = true;
            }
            else if (tipoBusqueda == TipoBusquedaSociedades.PorNoRegistro)
            {
                txtBusqueda.Visible = false;
                txtBusqueda.Text = "";
                txtBusquedaRNC.Visible = false;
                txtBusquedaRNC.Text = "";
                txtBusquedaR.Visible = true;
                lblMensajeSociedades.Text = "";
                ddTipoDocumentoSoc.Visible = false;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.rgridEmpresas_PreRender(object, EventArgs)'
        protected void rgridEmpresas_PreRender(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.rgridEmpresas_PreRender(object, EventArgs)'
        {
            if (rgridEmpresas.MasterTableView.Items.Count == 0)
            {
                GridNoRecordsItem noRecordsItem = (GridNoRecordsItem)rgridEmpresas.MasterTableView.GetItems(GridItemType.NoRecordsItem)[0];
                var certificacionNoEspecificada = (Label)noRecordsItem.FindControl("certificacionNoEspecificada");
                if (String.IsNullOrWhiteSpace(this.txtBusqueda.Text))
                {
                    if (certificacionNoEspecificada != null)
                        certificacionNoEspecificada.Visible = false;
                }
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.rgridEmpresasPF_PreRender(object, EventArgs)'
        protected void rgridEmpresasPF_PreRender(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.rgridEmpresasPF_PreRender(object, EventArgs)'
        {
            if (rgridEmpresasPF.MasterTableView.Items.Count == 0)
            {
                GridNoRecordsItem noRecordsItem = (GridNoRecordsItem)rgridEmpresasPF.MasterTableView.GetItems(GridItemType.NoRecordsItem)[0];
                var certificacionNoEspecificadaPF = (Label)noRecordsItem.FindControl("certificacionNoEspecificadaPF");
                if (String.IsNullOrWhiteSpace(this.txtBusquedaPF.Text))
                {
                    if (certificacionNoEspecificadaPF != null)
                        certificacionNoEspecificadaPF.Visible = false;
                }
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.ddTipoDocumento_SelectedIndexChanged(object, EventArgs)'
        protected void ddTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.ddTipoDocumento_SelectedIndexChanged(object, EventArgs)'
        {
            int.TryParse(this.ddTipoDocumento.SelectedItem.Value, out int tipoMask);

            if (tipoMask == 1)
            {
                txtBusquedaRNCPF.Text = "";
                txtBusquedaRNCPF.Mask = "###-#######-#";
            }
            else if (tipoMask == 2)
            {
                txtBusquedaRNCPF.Text = "";
                txtBusquedaRNCPF.Mask = "#-##-#####-#";
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.ddTipoDocumentoSoc_SelectedIndexChanged(object, EventArgs)'
        protected void ddTipoDocumentoSoc_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Busqueda.ddTipoDocumentoSoc_SelectedIndexChanged(object, EventArgs)'
        {
            int.TryParse(this.ddTipoDocumentoSoc.SelectedItem.Value, out int tipoMask);

            if (tipoMask == 1)
            {
                txtBusquedaRNC.Text = "";
                txtBusquedaRNC.Mask = "###-#######-#";
            }
            else if (tipoMask == 2)
            {
                txtBusquedaRNC.Text = "";
                txtBusquedaRNC.Mask = "#-##-#####-#";
            }
        }
    }
}