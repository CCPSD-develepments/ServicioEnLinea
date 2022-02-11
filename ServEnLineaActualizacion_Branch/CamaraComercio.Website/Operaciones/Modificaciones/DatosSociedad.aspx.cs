using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using System.Text;

namespace CamaraComercio.Website.Operaciones.Modificaciones
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosSociedad'
    public partial class DatosSociedad : ModificacionPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosSociedad'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosSociedad.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosSociedad.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;

            //Inicializando el form
            LoadData();
            InitializeUI();

            //Inicializando las restricciones segun el tipo de empresa
            RenderizarControles(this.Form.Controls);

            if (IsFormularionConfirmacion)
                LoadFormData();

            //Cerrando controles si se trata de una modificación
            var tipoServicios = new Comun.CamaraComunEntities().Servicio
                .Where(s => this.ServiciosSeleccionadosPorUrl.Contains(s.ServicioId))
                .Select(s => s.TipoServicioId).Distinct().ToList();
            if (!tipoServicios.Contains(Helper.TipoServicioIdTransformacion))
            {
                var autorizados = new OFV.PropiedadesModUIRepository().GetControlesByServicioIDs(this.ServiciosSeleccionadosPorUrl);
                HabilitarControlesMod(this.Form, ref autorizados);
            }
            //Habilito el boton de onapi
            btnValidarOnapi.Enabled = true;
        }

        /// <summary>
        /// Carga de valores maestros (catalogos) en Dropdowns
        /// </summary>
        private void LoadData()
        {
            //Data Context
            var dbComun = new Comun.CamaraComunEntities();

            //Entes Regulados
            var colEntesRegulados = dbComun.TiposEnteRegulado.ToList();
            ddlTipoEnteRegulado.BindCollection(colEntesRegulados,
                Comun.TiposEnteRegulado.PropColumns.TipoEnteReguladoId,
                Comun.TiposEnteRegulado.PropColumns.Descripcion);

            //Tipo de empresa (header)
            var tipoEmpresa = dbComun.TipoSociedad.FirstOrDefault(c => c.TipoSociedadId == this.SociedadRegistroNuevo.TipoSociedadId);
            //this.litTipoEmpresaTit.Text = tipoEmpresa.Etiqueta;
            this.litDescripcionSociedad.Text = tipoEmpresa.DescripcionExtendida;

            //Hidden fields
            hfNuevoRegistro.Value = this.RegistroNuevo.EsNuevoRegistro ? "1" : "0";
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

            //Mensaje personalizado para el range validator
            this.rvDuracionConsejo.ErrorMessage =
                String.Format("La duración máxima permitida para el consejo es de {0} años. ",
                              this.rvDuracionConsejo.MaximumValue);
        }

        // 03 - Llenado de los datos financieros
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosSociedad.btnDatosFinancierosLlenos_Click(object, EventArgs)'
        protected void btnDatosFinancierosLlenos_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosSociedad.btnDatosFinancierosLlenos_Click(object, EventArgs)'
        {
            //Revisión de requisitos de socios
            if (!Page.IsValid || !IsValido()) return;


            if (SociedadRegistro == null)
                InitializeSociedad();

            //Capitales
            if (this.RegistroNuevo.CapitalPagado == 0)
                this.RegistroNuevo.CapitalPagado = this.SociedadRegistro.Registros.CapitalPagado;

            this.RegistroNuevo.CapitalAutorizado = this.SociedadRegistro.Registros.CapitalAutorizado;

            this.RegistroNuevo.Activos = this.SociedadRegistro.Registros.Activos;
            this.RegistroNuevo.BienesRaices = this.SociedadRegistro.Registros.BienesRaices;

            //Modificacion de Tipo 
            this.RegistroNuevo.TipoMonedaActivos = this.SociedadRegistro.Registros.TipoMonedaActivos;
            this.RegistroNuevo.TipoMonedaBienesRaices = this.SociedadRegistro.Registros.TipoMonedaBienesRaices;
            this.RegistroNuevo.TipoMonedaCapitalPagado = this.SociedadRegistro.Registros.TipoMonedaCapitalPagado;

            //Datos de la sociedad
            this.SociedadRegistroNuevo.DuracionSociedad = this.txtDuracionSociedad.IntegerValue().ToString();
            this.SociedadRegistroNuevo.DuraccionDirectiva = this.txtDuracionOrganoAdmin.IntegerValue();

            this.SociedadRegistroNuevo.Rnc = this.txtRNC.Text;

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
            this.ReferenciasBancariasRegistro = new List<ReferenciasBancarias>();
            var lineasRb = hfReferenciasBancarias.Value.Split(';');
            foreach (var linea in lineasRb.Where(linea => linea.Trim().Length > 0))
            {
                var banco = linea.Split(',');
                this.ReferenciasBancariasRegistro.Add(new ReferenciasBancarias
                                                          {
                                                              BancoId = Convert.ToInt32(banco[0]),
                                                              NombreBanco = banco[1]
                                                          });
            }

            //Proxima vista
            Response.Redirect("Confirmacion.aspx" + DefaultQueryString);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosSociedad.LoadFormData()'
        protected void LoadFormData()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosSociedad.LoadFormData()'
        {
            //Header
            var soc = RegistroSistemaActual.SociedadesRegistros.FirstOrDefault();
            this.litNombreEmpresaTit.Text = soc.Sociedades.NombreSocial;
            this.litNombreEmpresaTit.Text = soc.Sociedades.NombreSocial;

            //Capitales
            this.lblMontoCapitalSocial.Text = this.RegistroNuevo.CapitalSocial.Value2().ToString("n");

            if (this.lblCapitalSuscrito.Visible)
            {
                this.lblMontoCapitalSuscrito.Text = this.RegistroNuevo.CapitalPagado.Value2().ToString("n");
                this.pnlCapitalSuscrito.Visible = this.RegistroNuevo.CapitalPagado.Value2() > 0;
            }

            //Duracion Sociedad
            this.txtDuracionSociedad.Text = this.SociedadRegistroNuevo.DuracionSociedad;
            this.ddlDuracionSociedad.SelectedValue = this.SociedadRegistroNuevo.DuracionSociedad == "INDEFINIDA" ||
                                                     this.SociedadRegistroNuevo.DuracionSociedad == "0"
                                                         ? "1"
                                                         : "2";

            this.txtDuracionOrganoAdmin.Text = (this.SociedadRegistroNuevo.DuraccionDirectiva.HasValue && this.SociedadRegistroNuevo.DuraccionDirectiva != 0)
                                               ? this.SociedadRegistroNuevo.DuraccionDirectiva.Value.ToString()
                                               : String.Empty;
            this.rblEsEnteRegulado.SelectedIndex = this.SociedadRegistroNuevo.EsEnteRegulado ? 0 : 1;

            ddlTipoEnteRegulado.SelectedValue = this.SociedadRegistroNuevo.TipoEnteReguladoId.HasValue ? this.SociedadRegistroNuevo.TipoEnteReguladoId.Value.ToString() : "-1";

            this.txtNoResolucion.Text = this.SociedadRegistroNuevo.NoResolucion;
            this.txtRNC.Text = this.SociedadRegistroNuevo.Rnc.RemoverFormato();

            txtEmpleadosM.Text = this.RegistroNuevo.EmpleadosMasculinos.GetValueOrDefault().ToString();
            txtEmpleadosF.Text = this.RegistroNuevo.EmpleadosFemeninos.GetValueOrDefault().ToString();

            txtNombreComercialDesc.Text = this.RegistroNuevo.NombreComercial;
            txtNombreComercialNumero.Text = this.RegistroNuevo.RegistroNombreComercial;

            //Referencias Comerciales
            var sb = new StringBuilder();
            foreach (var item in this.ReferenciasComercialesRegistro)
                sb.Append(item.Descripcion.Replace(",","") + ",");
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
            IEnumerable<Socios> socios;
            var sb = new StringBuilder();

            //Validaciones por tipos de socios
            var listadoSocios = ManejoSocios1.ListSociosRender.ToList();
            foreach (var item in listadoSocios)
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

            //Validacionws por tipo de cargos
            var rep = new Comun.TipoSociedadServicioCargoRepository();
            var validaciones = rep.GetValidations(this.TipoSociedadId,
                                                  this.ServiciosSeleccionadosPorUrl.ConvertAll<Int32?>(s => s))
                                                  .ToList();
            var cargoIds = validaciones.Select(v => v.CargoID).Distinct();
            var cargoNombres = validaciones.Select(v => v.Descripcion).Distinct();
            if (validaciones.Count() > 0)
            {
                var usuariosConCargos = this.SociosEnRegistro.Where(s => s.CargoId != null && cargoIds.Contains(s.CargoId));
                if (usuariosConCargos.Count() == 0)
                {
                    var sbNombres = new StringBuilder();
                    foreach (var nombre in cargoNombres)
                        sbNombres.AppendFormat("{0},", nombre);

                    var mensaje = "Existen cargos requeridos para este servicio que no han sido definidos: "
                                  + sbNombres.ToString().TrimEnd(',');

                    var ctrl = new CustomValidator
                    {
                        IsValid = false,
                        ErrorMessage = mensaje,
                        ValidationGroup = "3",
                        Display = ValidatorDisplay.None
                    };
                    this.Page.Form.Controls.Add(ctrl);
                    isValid = false;
                }
            }
            
            return isValid;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosSociedad.btnValidarOnapi_Click(object, EventArgs)'
        protected void btnValidarOnapi_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosSociedad.btnValidarOnapi_Click(object, EventArgs)'
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