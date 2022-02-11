using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using System.Text;

namespace CamaraComercio.Website.Operaciones.Registro
{
    ///<summary>
    /// Página en donde se definen los datos de la sociedad
    ///</summary>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class DatosSociedad : FormularioPage
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosSociedad.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosSociedad.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;

            //set hyperlinks
            if (!DefaultQueryString.Contains("action=edit"))
                DefaultQueryString = "action=edit";

            //Inicializando el form
            LoadData();
            InitializeUI();

            //Inicializando las restricciones segun el tipo de empresa
            RenderizarControles(this.Form.Controls);

            //Comentarios dinámicos - Capital Social Mínimo
            decimal capitalSocialMinimo = 0;
            Decimal.TryParse(this.rvCapitalSocialNuevo.MinimumValue, out capitalSocialMinimo);
            if (capitalSocialMinimo > 0)
                litCapitalSocialComment.Text = "El monto mínimo es de RD$" + FormatDecimalString(rvCapitalSocialNuevo.MinimumValue);

            //Comentarios dinámicos - Organo Administrativo
            this.lblDuracionOrganoAdminComment.Text = String.Format("La duración máxima es de {0} años", this.rvDuracionConsejo.MaximumValue);

            //Validacion de edicion
            if (IsFormularionConfirmacion || this.IsEditMode)
                LoadFormData();
            hfNuevoRegistro.Value = this.RegistroNuevo.EsNuevoRegistro ? "1" : "0";

            //Correccion de campos para sociedades extranjeras
            var tipoSociedadID = this.SociedadRegistroNuevo.TipoSociedadId.HasValue
                                     ? this.SociedadRegistroNuevo.TipoSociedadId.Value
                                     : this.TipoSociedadId;
            if (Helper.TipoSociedadExtranjera.Contains(tipoSociedadID))
                this.spanCapSuscrito.Text = String.Empty;
        }

        /// <summary>
        /// Carga de valores maestros (catalogos) en Dropdowns
        /// </summary>
        private void LoadData()
        {
            var dbComun = new Comun.CamaraComunEntities();

            //Nombre y tipo de la empresa
            this.litNombreEmpresa.Text = this.SociedadRegistroNuevo.NombreSocial;
            var tipoEmpresa = dbComun.TipoSociedad.FirstOrDefault(c => c.TipoSociedadId == this.SociedadRegistroNuevo.TipoSociedadId);
            if (tipoEmpresa != null)
            {
                //this.litTipoEmpresa.Text = tipoEmpresa.Etiqueta;
                this.litDescripcionSociedad.Text = tipoEmpresa.DescripcionExtendida;
            }

            //Entes Regulados
            var colEntesRegulados = dbComun.TiposEnteRegulado.ToList();
            ddlTipoEnteRegulado.BindCollection(colEntesRegulados, Comun.TiposEnteRegulado.PropColumns.TipoEnteReguladoId, Comun.TiposEnteRegulado.PropColumns.Descripcion);

            //Monedas
            var monedas = dbComun.TipoMoneda;
            ddlMonedaActivos.BindCollection(monedas, Comun.TipoMoneda.PropColumns.TipoMonedaId, Comun.TipoMoneda.PropColumns.Abreviatura);
            ddlMonedaBienesRaices.BindCollection(monedas, Comun.TipoMoneda.PropColumns.TipoMonedaId, Comun.TipoMoneda.PropColumns.Abreviatura);
            ddlMonedaCapitalSocial.BindCollection(monedas, Comun.TipoMoneda.PropColumns.TipoMonedaId, Comun.TipoMoneda.PropColumns.Abreviatura);
            ddlMonedaCapitalSuscrito.BindCollection(monedas, Comun.TipoMoneda.PropColumns.TipoMonedaId, Comun.TipoMoneda.PropColumns.Abreviatura);

            var ddlActivoRd = ddlMonedaActivos.Items.FindByText("RD$");
            if (ddlActivoRd != null) ddlActivoRd.Selected = true;
            var ddlBienesRd = ddlMonedaBienesRaices.Items.FindByText("RD$");
            if (ddlBienesRd != null) ddlBienesRd.Selected = true;
            var ddlCapitalRd = ddlMonedaCapitalSocial.Items.FindByText("RD$");
            if (ddlCapitalRd != null) ddlCapitalRd.Selected = true;
            var ddlSuscritoRd = ddlMonedaCapitalSuscrito.Items.FindByText("RD$");
            if (ddlSuscritoRd != null) ddlSuscritoRd.Selected = true;


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

            //Mensaje personalizado para el range validator
            this.rvDuracionConsejo.ErrorMessage =
                String.Format("La duración máxima permitida para el consejo es de {0} años. ",
                              this.rvDuracionConsejo.MaximumValue);

            //Revisión de empresa extranjera
            var esExtranjera = Helper.TipoSociedadExtranjera.Contains(this.TipoSociedadId);
            this.lblCapSuscritoComment.Visible = !esExtranjera;
            
        }

        // 03 - Llenado de los datos financieros
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosSociedad.btnDatosFinancierosLlenos_Click(object, EventArgs)'
        protected void btnDatosFinancierosLlenos_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosSociedad.btnDatosFinancierosLlenos_Click(object, EventArgs)'
        {
            if (!Page.IsValid || !IsValido()) return;

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

            if (calInicioOperaciones.SelectedDate != DateTime.MinValue)
                this.RegistroNuevo.FechaInicioOperacion = calInicioOperaciones.SelectedDate;

            if (calUltimaAsamblea.SelectedDate != DateTime.MinValue)
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
            this.RegistroNuevo.RegistroNombreComercial = txtNombreComercialNumero.Text;

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
                int bancoId;
                var nombreBanco = banco[1].Trim().Replace(";null", "").Replace("null", "").Replace("undefined", "");
                if (Int32.TryParse(banco[0], out bancoId) && nombreBanco.Length > 0)
                {
                    this.ReferenciasBancariasRegistro.Add(new OFV.ReferenciasBancarias
                                                              {
                                                                  BancoId = bancoId,
                                                                  NombreBanco = nombreBanco
                                                              });
                }
            }
            this.ReciboDgii = new ReciboDGII
            {
                NoReciboDGII =  this.txtNoRecibo.Text,
                MontoDGII = this.txtMontoDGII.DecimalValue()
            };
            if (this.hfFechaReciboDgii.Value.Length > 0)
            {
                this.ReciboDgii.FechaReciboDGII = Convert.ToDateTime(this.hfFechaReciboDgii.Value);
            }

            //Próxima vista
            Response.Redirect("Confirmacion.aspx" + DefaultQueryString);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosSociedad.LoadFormData()'
        protected void LoadFormData()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosSociedad.LoadFormData()'
        {
            //Datos de la sociedad
            this.txtCapitalSocialNuevo.Text = this.RegistroNuevo.CapitalSocial.HasValue ? this.RegistroNuevo.CapitalSocial.Value.ToString() : String.Empty;
            this.txtCapSuscrito.Text = this.RegistroNuevo.CapitalPagado.HasValue ? this.RegistroNuevo.CapitalPagado.Value.ToString() : String.Empty;
            this.txtBienesRaices.Text = this.RegistroNuevo.BienesRaices.HasValue ? this.RegistroNuevo.BienesRaices.ToString() : String.Empty;
            this.txtActivos.Text = this.RegistroNuevo.Activos.HasValue ? this.RegistroNuevo.Activos.Value.ToString() : String.Empty;

            if (this.RegistroNuevo.FechaInicioOperacion.HasValue && this.RegistroNuevo.FechaInicioOperacion != DateTime.MinValue)
                calInicioOperaciones.SelectedDate = this.RegistroNuevo.FechaInicioOperacion.Value;
            if (this.SociedadRegistroNuevo.FechaAsamblea.HasValue && this.SociedadRegistroNuevo.FechaAsamblea != DateTime.MinValue)
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

            if (this.ReciboDgii.FechaReciboDGII.HasValue && this.ReciboDgii.FechaReciboDGII != DateTime.MinValue)
            {
                radFechaRecibo.Text = this.ReciboDgii.FechaReciboDGII.Value2().ToStringDom();
                this.hfFechaReciboDgii.Value = this.ReciboDgii.FechaReciboDGII.Value2().ToString();
            }

            txtNombreComercialDesc.Text = this.RegistroNuevo.NombreComercial;
            txtNombreComercialNumero.Text = this.RegistroNuevo.RegistroNombreComercial;

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
            {
                if (item.BancoId > 0 && item.NombreBanco.Length > 0)
                    sb.Append(String.Format("{0},{1};", item.BancoId, item.NombreBanco));
            }
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
            //Variables
            var isValid = true;
            var repTransacciones = new SRM.TransaccionesRepository(this.CamaraId);
            
            #region Validar Cantidad de Empleados
            int cantm = 0, cantf = 0;

            Int32.TryParse(txtEmpleadosM.Text, out cantm);
            Int32.TryParse(txtEmpleadosF.Text, out cantf);

            if (cantm == 0 && cantf == 0)
            {
                var ctrl = new CustomValidator()
                                {
                                    IsValid = false,
                                    ErrorMessage = "La cantidad total de empleados no puede ser 0",
                                    ValidationGroup = "3",
                                    Display = ValidatorDisplay.None
                                };
                
                this.Page.Form.Controls.Add(ctrl);
                isValid = false;
            } 

            #endregion

            #region Manejo de Socios
            IEnumerable<OFV.Socios> socios;
            var sb = new StringBuilder();

            if (((Telerik.Web.UI.RadGrid)ManejoSocios1.FindControl("rgsocios")).Items.Count <= 0) 
            {
                var ctrl = new CustomValidator
                {
                    IsValid = false,
                    ErrorMessage = "Debe introducir los socios",
                    ValidationGroup = "3",
                    Display = ValidatorDisplay.None
                };
                this.Page.Form.Controls.Add(ctrl);

                isValid = false;

                return isValid;
            }

            foreach (var item in ManejoSocios1.ListSociosRender)
            {
                var item1 = item;
                socios = this.SociosEnRegistro.Where(a => a.TipoRelacion == item1.TipoSocioId);

                string errorMsg;
                if (socios.Count() < item.CantMinSocio && item.CantMaxSocio.Value2() == 0)
                {
                    errorMsg = String.Format("{0} requiere mínimo {1} entrada(s).", item.Descripcion,
                                                    item.CantMinSocio);
                    var ctrl = new CustomValidator
                    {
                        IsValid = false,
                        ErrorMessage = errorMsg,
                        ValidationGroup = "3",
                        Display = ValidatorDisplay.None
                    };
                    this.Page.Form.Controls.Add(ctrl);

                    isValid = false;
                }
                else if (socios.Count() < item.CantMinSocio ||
                         (socios.Count() > item.CantMaxSocio && item.CantMaxSocio > 0))
                {
                    errorMsg = String.Format("{0} requiere mínimo {1} entradas y máximo {2}.",
                                                 item.Descripcion,
                                                 item.CantMinSocio, item.CantMaxSocio);
                    var ctrl = new CustomValidator
                    {
                        IsValid = false,
                        ErrorMessage = errorMsg,
                        ValidationGroup = "3",
                        Display = ValidatorDisplay.None
                    };
                    this.Page.Form.Controls.Add(ctrl);

                    isValid = false;
                }

            }
            #endregion

            #region Manejo del Recibo de la DGII
//            #region Decomentar cuando se resuelva problema con la gente de la dgii
//            //Si el boton del número de recibo es visible, quiere decir que es requerido y se valida la entrada
//            if (this.btnValidarNoRecibo.Visible)
//            {
//                //Fecha
//                var fechaStr = this.hfFechaReciboDgii.Value;
//                DateTime fecha;
//                if (!DateTime.TryParse(fechaStr, out fecha))
//                {
//                    var ctrl = new CustomValidator
//                                   {
//                                       IsValid = false,
//                                       ErrorMessage = (this.txtRestadoReciboDgii.Text.Length > 0)
//                                                          ? this.txtRestadoReciboDgii.Text
//                                                          : "El No. de Recibo de DGII no es válido. Por favor revisar nuevamente",
//                                       ValidationGroup = "3",
//                                       Display = ValidatorDisplay.None
//                                   };
//                    this.Page.Form.Controls.Add(ctrl);

//                    isValid = false;
//                }

//                //Número de recibo
//                var noReciboDgii = this.txtNoRecibo.Text;
//                if (noReciboDgii.Length > 0 && repTransacciones.ReciboDgiiExiste(noReciboDgii))
//                {
//                    var ctrl = new CustomValidator()
//                                   {
//                                       IsValid = false,
//                                       ErrorMessage =
//                                           @"El número de recibo de DGII utilizado ya ha sido utilizado en una 
//                                    transacción previa. Revise el número e intenta nuevamente.",
//                                       ValidationGroup = "3",
//                                       Display = ValidatorDisplay.None
//                                   };
//                    this.Page.Form.Controls.Add(ctrl);
//                    isValid = false;
//                }
//                        }


//            #endregion
            #endregion //ReciboDGII

            //Revisión del número del registro comercial
            
            var noRegistroComercial = this.txtNombreComercialNumero.Text;
            if (noRegistroComercial.Length > 0 && repTransacciones.RegistroOnapiExiste(noRegistroComercial))
            {
                var ctrl = new CustomValidator()
                               {
                                   IsValid = false,
                                   ErrorMessage =
                                       @"El número de registro comercial digitado ya existe para 
                                                  otra sociedad o empresa. Revise el número e intenta nuevamente.",
                                   ValidationGroup = "3",
                                   Display = ValidatorDisplay.None
                               };
                this.Page.Form.Controls.Add(ctrl);
                isValid = false;
            }

            //Revision del capital suscrito (si aplica)
            var capitalSocial = this.txtCapitalSocialNuevo.DecimalValue();
            if (this.txtCapSuscrito.Visible && capitalSocial > 0
                    && !Helper.TipoSociedadExtranjera.Contains(this.TipoSociedadId))
            {
                var capitalSuscritoMinimo = capitalSocial * (Helper.PorcentajeCapitalPagado / 100);
                var capitalSuscrito = this.txtCapSuscrito.DecimalValue();
                if (capitalSuscrito < capitalSuscritoMinimo)
                {
                    var ctrl = new CustomValidator()
                               {
                                   IsValid = false,
                                   ErrorMessage = String.Format("El capital suscrito y pagado mínimo requerido para " +
                                      "este tipo de sociedad/empresa es del {0}% del capital autorizado ({1:n})",
                                      Helper.PorcentajeCapitalPagado, capitalSuscritoMinimo),
                                   ValidationGroup = "3",
                                   Display = ValidatorDisplay.None
                               };
                    
                    this.Page.Form.Controls.Add(ctrl);
                    isValid = false;
                }
            }

            return isValid;
        }

        ///<summary>
        /// Método que elimina todos los validadores personalizados de la página
        ///</summary>
        public void ResetValidators()
        {
            foreach (var ctrl in this.Page.Form.Controls.OfType<CustomValidator>())
                this.Page.Form.Controls.Remove(ctrl);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosSociedad.btnValidarReciboOnapi_Click(object, EventArgs)'
        protected void btnValidarReciboOnapi_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosSociedad.btnValidarReciboOnapi_Click(object, EventArgs)'
        {
            try
            {
                wsOnapi2.ServicioCC onapi = new wsOnapi2.ServicioCC();
                int numeroOnapi = 0;
                int.TryParse(txtNombreComercialNumero.Text, out numeroOnapi);
                wsOnapi2.ResultadoBusquedaNombre res = onapi.BuscarNombrePorNumero(numeroOnapi, "cc", "abc");

                if (res != null)
                    txtNombreComercialDesc.Text = res.Texto;
                else
                {
                    var ctrl = new CustomValidator()
                    {
                        IsValid = false,
                        ErrorMessage =
                            @"Numero de recibo no valido ",
                        ValidationGroup = "3",
                        Display = ValidatorDisplay.None
                    };
                    txtNombreComercialDesc.Text = string.Empty;
                    this.Page.Form.Controls.Add(ctrl);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                var ctrl = new CustomValidator()
                {
                    IsValid = false,
                    ErrorMessage =
                        @"Ha ocurrido un error validando el numero de recibo, Por favor contactar al personal de soporte  ",
                    ValidationGroup = "3",
                    Display = ValidatorDisplay.None
                };
                txtNombreComercialDesc.Text = string.Empty;
                this.Page.Form.Controls.Add(ctrl);
            }
        }

    }
}
