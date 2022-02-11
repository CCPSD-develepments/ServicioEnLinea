using System;
using System.Collections.Generic;
using System.Linq;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using System.Text;

namespace CamaraComercio.Website.Operaciones.Ventanilla
{
    ///<summary>
    /// Página en donde se definen los datos de la sociedad
    ///</summary>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class DatosSociedad : FormularioPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSociosMensajes.Text = String.Empty;

            if (IsPostBack) return;

            //set hyperlinks
            if (!DefaultQueryString.Contains("action=edit"))
                DefaultQueryString = "action=edit";
            this.hlinksolicitud.NavigateUrl = "NuevoRegistro.aspx" + DefaultQueryString;

            //Inicializando el form
            LoadData();
            InitializeUI();

            //Inicializando las restricciones segun el tipo de empresa
            RenderizarControles(this.Form.Controls);

            if (IsFormularionConfirmacion || this.IsEditMode)
                LoadFormData();
            hfNuevoRegistro.Value = this.RegistroNuevo.EsNuevoRegistro ? "1" : "0";
        }

        /// <summary>
        /// Carga de valores maestros (catalogos) en Dropdowns
        /// </summary>
        private void LoadData()
        {
            var dbComun = new Comun.CamaraComunEntities();

            //Entes Regulados
            var colEntesRegulados = dbComun.TiposEnteRegulado.ToList();
            ddlTipoEnteRegulado.BindCollection(colEntesRegulados, Comun.TiposEnteRegulado.PropColumns.TipoEnteReguladoId, Comun.TiposEnteRegulado.PropColumns.Descripcion);

            //Monedas
            var monedas = dbComun.TipoMoneda;
            ddlMonedaActivos.BindCollection(monedas, Comun.TipoMoneda.PropColumns.TipoMonedaId, Comun.TipoMoneda.PropColumns.Abreviatura);
            ddlMonedaBienesRaices.BindCollection(monedas, Comun.TipoMoneda.PropColumns.TipoMonedaId, Comun.TipoMoneda.PropColumns.Abreviatura);
            ddlMonedaCapitalSocial.BindCollection(monedas, Comun.TipoMoneda.PropColumns.TipoMonedaId, Comun.TipoMoneda.PropColumns.Abreviatura);
            ddlMonedaCapitalSuscrito.BindCollection(monedas, Comun.TipoMoneda.PropColumns.TipoMonedaId, Comun.TipoMoneda.PropColumns.Abreviatura);
            ddlMonedaMontoDgii.BindCollection(monedas, Comun.TipoMoneda.PropColumns.TipoMonedaId, Comun.TipoMoneda.PropColumns.Abreviatura);

            var ddlActivoRd = ddlMonedaActivos.Items.FindByText("RD$");
            if (ddlActivoRd != null) ddlActivoRd.Selected = true;

            var ddlBienesRd = ddlMonedaBienesRaices.Items.FindByText("RD$");
            if (ddlBienesRd != null) ddlBienesRd.Selected = true;

            var ddlCapitalRd = ddlMonedaCapitalSocial.Items.FindByText("RD$");
            if (ddlCapitalRd != null) ddlCapitalRd.Selected = true;

            var ddlSuscritoRd = ddlMonedaCapitalSuscrito.Items.FindByText("RD$");
            if (ddlSuscritoRd != null) ddlSuscritoRd.Selected = true;

            var ddlDgiiRd = ddlMonedaMontoDgii.Items.FindByText("RD$");
            if (ddlDgiiRd != null) ddlDgiiRd.Selected = true;
        }

        /// <summary>
        /// Inicializacion de elementos del UI
        /// </summary>
        private void InitializeUI()
        {
            //Revision de accionistas
            if (this.SociedadRegistroNuevo.TipoSociedadId == 1)
            {
                this.ManejoSocios1.MensajeRecordsVacios = "Debe seleccionar por lo menos un accionista";
            }

            //Revision de fecha de operaciones
            if (this.RegistroSistemaActual.FechaInicioOperacion != null)
            {
                this.calInicioOperaciones.SelectedDate = this.RegistroSistemaActual.FechaInicioOperacion.Value;
                this.calInicioOperaciones.Enabled = false;
            }

            //Validaciones entre nuevos registros y adecuaciones
            if (this.RegistroNuevo.EsNuevoRegistro)
            {
                this.txtCapitalSocialActual.Text = "0.00";
                this.txtCapitalSocialActual.ReadOnly = true;
                this.txtCapitalSocialActual.Visible = false;
                this.lbltxtCapitalSocialActual.Visible = false;

                this.txtCapitalSocialActual.Visible = false;
                this.lbltxtCapitalSocialActual.Visible = false;

                this.lblcalUltimaAsamblea.Text = "Fecha Estatutos/Asamblea Constitutiva";
                this.calUltimaAsambleaReq.Text = "La fecha de la asamblea es requerida";

            }
            else
            {
                if (this.RegistroSistemaActual.CapitalAutorizado != null)
                {
                    this.txtCapitalSocialActual.Text = this.RegistroSistemaActual.CapitalAutorizado.Value.ToString("n");
                    this.txtCapitalSocialActual.ReadOnly = true;
                }
            }
        }

        // 03 - Llenado de los datos financieros
        protected void btnDatosFinancierosLlenos_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid || !IsValido()) return;

            //Revisión del numero de recibo de DGII
            var repTransacciones = new SRM.TransaccionesRepository(this.CamaraId);
            var noReciboDgii = this.txtNoRecibo.Text;
            this.lblNoReciboDgiiExiste.Visible = false;
            if (noReciboDgii.Length > 0 && repTransacciones.ReciboDgiiExiste(noReciboDgii))
            {
                this.lblNoReciboDgiiExiste.Visible = true;
                return;
            }

            //Revision del capital suscrito (si aplica)
            var capitalSocial = this.txtCapitalSocialNuevo.DecimalValue();
            this.lblErrorCapitalSuscrito.Text = String.Empty;
            if (this.txtCapSuscrito.Visible && capitalSocial > 0)
            {
                var capitalSuscritoMinimo = capitalSocial * 0.10m;
                var capitalSuscrito = this.txtCapSuscrito.DecimalValue();
                if (capitalSuscrito < capitalSuscritoMinimo)
                {
                    this.lblErrorCapitalSuscrito.Text =
                        String.Format("<br/>El capital suscrito y pagado mínimo requerido para " +
                                      "este tipo de sociedad/empresa es del 10% del capital autorizado ({0})",
                                      capitalSuscritoMinimo.ToString("n"));
                    return;
                }
            }

            //Datos de la sociedad
            this.RegistroNuevo.CapitalSocial = this.txtCapitalSocialNuevo.DecimalValue();
            if (this.RegistroNuevo.CapitalSocial > 0)
                this.RegistroNuevo.TipoMonedaCapitalSocial = Convert.ToInt32(this.ddlMonedaCapitalSocial.SelectedValue);
            this.RegistroNuevo.CapitalPagado = this.txtCapSuscrito.DecimalValue();
            if (this.RegistroNuevo.CapitalPagado > 0)
                this.RegistroNuevo.TipoMonedaCapitalPagado = Convert.ToInt32(this.ddlMonedaCapitalSuscrito.SelectedValue);
            this.RegistroNuevo.BienesRaices = this.txtBienesRaices.DecimalValue();
            if (this.RegistroNuevo.BienesRaices > 0)
                this.RegistroNuevo.TipoMonedaBienesRaices = Convert.ToInt32(this.ddlMonedaBienesRaices.SelectedValue);
            this.RegistroNuevo.Activos = this.txtActivos.DecimalValue();
            if (this.RegistroNuevo.Activos > 0)
                this.RegistroNuevo.TipoMonedaActivos = Convert.ToInt32(this.ddlMonedaActivos.SelectedValue);

            this.RegistroNuevo.FechaInicioOperacion = calInicioOperaciones.SelectedDate;
            this.SociedadRegistroNuevo.FechaAsamblea = calUltimaAsamblea.SelectedDate;
            
            this.SociedadRegistroNuevo.DuracionSociedad = this.txtDuracionSociedad.IntegerValue().ToString();
            this.SociedadRegistroNuevo.DuraccionDirectiva = this.txtDuracionOrganoAdmin.IntegerValue();

            if (chkLlevaCapitalSocial.Visible && chkLlevaCapitalSocial.Checked)
                this.SociedadRegistroNuevo.TieneCapitalSocial = false;

            this.SociedadRegistroNuevo.EsEnteRegulado = this.rblEsEnteRegulado.SelectedIndex == 0 ? true : false;
            this.SociedadRegistroNuevo.TipoEnteReguladoId = null;
            if (this.SociedadRegistroNuevo.EsEnteRegulado)
                this.SociedadRegistroNuevo.TipoEnteReguladoId = ddlTipoEnteRegulado.SelectedItem != null
                                                                    ? Convert.ToInt32(this.ddlTipoEnteRegulado.SelectedItem.Value)
                                                                    : (int?)null;

            this.SociedadRegistroNuevo.NoResolucion = this.txtNoResolucion.Text;

            this.RegistroNuevo.EmpleadosFemeninos = txtEmpleadosF.Text.Length > 0 ? Convert.ToInt32(txtEmpleadosF.Text) : 0;
            this.RegistroNuevo.EmpleadosMasculinos = txtEmpleadosM.Text.Length > 0 ? Convert.ToInt32(txtEmpleadosM.Text) : 0;

            this.RegistroNuevo.MarcaFabrica = String.Empty;
            this.RegistroNuevo.RegistroMarcaFabrica = String.Empty;
            this.RegistroNuevo.PatenteInvencion = String.Empty;
            this.RegistroNuevo.RegistroPatenteInvencion = String.Empty;
            this.RegistroNuevo.NombreComercial = txtNombreComercialDesc.Text;

            //Referencias Comerciales
            this.ReferenciasComercialesRegistro = new List<OFV.ReferenciasComerciales>();
            var lineasRc = hfReferenciasComerciales.Value.Split(',');
            foreach (var linea in lineasRc.Where(linea => linea.Trim().Length > 0))
            {
                this.ReferenciasComercialesRegistro.Add(new OFV.ReferenciasComerciales { Descripcion = linea });
            }

            //Sucursales
            this.SucursalesRegistro = new List<OFV.Sucursales>();
            var lineasSuc = hfTxtSucursales.Value.Split(',');
            foreach (var linea in lineasSuc.Where(linea => linea.Trim().Length > 0))
            {
                this.SucursalesRegistro.Add(new OFV.Sucursales { Descripcion = linea });
            }

            //Referencias Bancarias
            this.ReferenciasBancariasRegistro = new List<OFV.ReferenciasBancarias>();
            var lineasRb = hfReferenciasBancarias.Value.Split(';');
            foreach (var linea in lineasRb.Where(linea => linea.Trim().Length > 0))
            {
                var banco = linea.Split(',');
                this.ReferenciasBancariasRegistro.Add(new OFV.ReferenciasBancarias
                                                          {
                                                              BancoId = Convert.ToInt32(banco[0]),
                                                              NombreBanco = banco[1]
                                                          });
            }

            this.ReciboDgii = new ReciboDGII
            {
                NoReciboDGII = this.txtNoRecibo.Text,
                MontoDGII = this.txtMontoDGII.DecimalValue()
            };
            
            if (this.radFechaRecibo.SelectedDate != DateTime.MinValue)
                this.ReciboDgii.FechaReciboDGII = this.radFechaRecibo.SelectedDate;

            //Proxima vista
            Response.Redirect("Confirmacion.aspx" + DefaultQueryString);
        }

        protected void LoadFormData()
        {
            //Datos de la sociedad
            this.txtCapitalSocialNuevo.Text = this.RegistroNuevo.CapitalSocial.HasValue ? this.RegistroNuevo.CapitalSocial.Value.ToString() : String.Empty;
            this.txtCapSuscrito.Text = this.RegistroNuevo.CapitalPagado.HasValue ? this.RegistroNuevo.CapitalPagado.Value.ToString() : String.Empty;
            this.txtBienesRaices.Text = this.RegistroNuevo.BienesRaices.HasValue ? this.RegistroNuevo.BienesRaices.ToString() : String.Empty;
            this.txtActivos.Text = this.RegistroNuevo.Activos.HasValue ? this.RegistroNuevo.Activos.Value.ToString() : String.Empty;

            if (this.RegistroNuevo.FechaInicioOperacion.HasValue)
                calInicioOperaciones.SelectedDate = this.RegistroNuevo.FechaInicioOperacion.Value;
            if (this.SociedadRegistroNuevo.FechaAsamblea.HasValue)
                calUltimaAsamblea.SelectedDate = this.SociedadRegistroNuevo.FechaAsamblea.Value;

            //Duracion Sociedad
            this.txtDuracionSociedad.Text = this.SociedadRegistroNuevo.DuracionSociedad;
            this.ddlDuracionSociedad.SelectedValue = this.SociedadRegistroNuevo.DuracionSociedad == "INDEFINIDA" ||
                                                     this.SociedadRegistroNuevo.DuracionSociedad == "0"
                                                         ? "1"
                                                         : "2";

            this.txtDuracionOrganoAdmin.Text = (this.SociedadRegistroNuevo.DuraccionDirectiva.HasValue && this.SociedadRegistroNuevo.DuraccionDirectiva != 0)
                                               ? this.SociedadRegistroNuevo.DuraccionDirectiva.Value.ToString()
                                               : String.Empty;
            this.rblEsEnteRegulado.SelectedIndex = this.SociedadRegistroNuevo.EsEnteRegulado ? 0 : -1;

            ddlTipoEnteRegulado.SelectedValue = this.SociedadRegistroNuevo.TipoEnteReguladoId.HasValue ? this.SociedadRegistroNuevo.TipoEnteReguladoId.Value.ToString() : "-1";

            this.txtNoResolucion.Text = this.SociedadRegistroNuevo.NoResolucion;

            txtEmpleadosM.Text = this.RegistroNuevo.EmpleadosMasculinos.GetValueOrDefault().ToString();
            txtEmpleadosF.Text = this.RegistroNuevo.EmpleadosFemeninos.GetValueOrDefault().ToString();

            txtMontoDGII.Text = this.ReciboDgii.MontoDGII.Value2().ToString();
            txtNoRecibo.Text = this.ReciboDgii.NoReciboDGII;
            if (this.ReciboDgii.FechaReciboDGII.HasValue)
                radFechaRecibo.SelectedDate = this.ReciboDgii.FechaReciboDGII.Value2();

            txtNombreComercialDesc.Text = this.RegistroNuevo.NombreComercial;

            //Referencias Comerciales
            var sb = new StringBuilder();
            foreach (var item in this.ReferenciasComercialesRegistro)
                sb.Append(item.Descripcion + ",");
            this.hfReferenciasComerciales.Value = sb.ToString().TrimEnd(',');

            //Sucursales
            sb = new StringBuilder();
            foreach (var item in this.SucursalesRegistro)
                sb.Append(item.Descripcion + ",");
            this.hfTxtSucursales.Value = sb.ToString().TrimEnd(',');

            //Referencias Bancarias
            sb = new StringBuilder();
            foreach (var item in this.ReferenciasBancariasRegistro)
                sb.Append(String.Format("{0},{1};", item.BancoId, item.NombreBanco));
            this.hfReferenciasBancarias.Value = sb.ToString().TrimEnd(';');
        }

        /// <summary>
        /// Formatea un string numérico con comas y dos espacios decimales
        /// </summary>
        /// <param name="rfValue"></param>
        /// <returns></returns>
        public string FormatDecimalString(string rfValue)
        {
            decimal val;
            return Decimal.TryParse(rfValue, out val) ? val.ToString("n2") : "";
        }

        ///<summary>
        /// Determina si el listado de socios ingresado es válido para
        /// el tipo de sociedad actual
        ///</summary>
        ///<returns></returns>
        public bool IsValido()
        {
            var isValid = true;
            IEnumerable<OFV.Socios> socios;
            var sb = new StringBuilder();
            foreach (var item in ManejoSocios1.ListSociosRender)
            {
                var item1 = item;
                socios = this.SociosEnRegistro.Where(a => a.TipoRelacion == item1.TipoSocioId);

                if (socios.Count() < item.CantMinSocio && item.CantMaxSocio.Value2() == 0)
                {
                    sb.Append(String.Format("{0} requiere mínimo {1} entrada(s). <br>", item.Descripcion,
                                            item.CantMinSocio));
                    isValid = false;
                }
                else if (socios.Count() < item.CantMinSocio ||
                         (socios.Count() > item.CantMaxSocio && item.CantMaxSocio > 0))
                {
                    sb.Append(String.Format("{0} requiere mínimo {1} entradas y máximo {2}. <br>", item.Descripcion,
                                            item.CantMinSocio, item.CantMaxSocio));
                    isValid = false;
                }
            }

            lblSociosMensajes.Text = sb.ToString();
            return isValid;
        }
    }
}
