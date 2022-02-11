using System;
using System.Linq;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF;
using CamaraComercio.Website.Operaciones.Registro;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using OFVPer = CamaraComercio.DataAccess.EF.OficinaVirtual;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using CamaraComercio.Website.Helpers;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CamaraComercio.Website.Empresas
{
    ///<summary>
    /// Página para ver el detalle de una sociedad/empresa. 
    ///</summary>
    /// <remarks>
    /// Desde esta página se pueden iniciar todas las solicitudes de modificación
    /// </remarks>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class VerDetalleEmpresa : CamaraComercio.Website.Operaciones.FormularioPage
    {
        private const string BotonModificacion = "Registro Modificación";
        #region Private fields and Properties

        ///// <summary>
        ///// Configuracion de los Servicios  
        ///// </summary>
        //public static ServicioSection ServiciosDefault
        //{
        //    get
        //    {
        //        return (ServicioSection)WebConfigurationManager.GetWebApplicationSection("servicioSection");
        //    }
        //}

#pragma warning disable CS0109 // The member 'VerDetalleEmpresa.SociedadId' does not hide an accessible member. The new keyword is not required.
        /// <summary>
        /// Llave Primaria de la Sociedad.  
        /// </summary>
        protected new int SociedadId
#pragma warning restore CS0109 // The member 'VerDetalleEmpresa.SociedadId' does not hide an accessible member. The new keyword is not required.
        {
            get
            {
                if (Session["SociedadId"] == null)
                    Session["SociedadId"] = 0;

                return (int)Session["SociedadId"];
            }
            set
            {
                Session["SociedadId"] = value;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleEmpresa.PersonaId'
#pragma warning disable CS0109 // The member 'VerDetalleEmpresa.PersonaId' does not hide an accessible member. The new keyword is not required.
        protected new int PersonaId
#pragma warning restore CS0109 // The member 'VerDetalleEmpresa.PersonaId' does not hide an accessible member. The new keyword is not required.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleEmpresa.PersonaId'
        {
            get
            {
                if (Session["PersonaId"] == null)
                    Session["PersonaId"] = 0;

                return (int)Session["PersonaId"];
            }
            set
            {
                Session["PersonaId"] = value;
            }
        }

        /// <summary>
        /// Llave primaria del numero de registro mecartil de la empresa.
        /// </summary>
        public int RegistroId
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["registroId"])
                           ? int.Parse(Request.QueryString["registroId"])
                           : 0;
            }
            set { DefaultQueryString = String.Format("registroId={0}", value); }

        }
        /// <summary>
        /// Llave primaria del numero del tipo de sociedad.
        /// </summary>
        new public int TipoSociedadId
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["TipoSociedadId"])
                           ? int.Parse(Request.QueryString["TipoSociedadId"])
                           : 0;
            }
            set { DefaultQueryString = String.Format("TipoSociedadId={0}", value); }
        }

        private SRM.cvw_SociedadesRegistros SociedadRegistro;

        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleEmpresa.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleEmpresa.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;

            ShowMenu();

            if (TipoSociedadId == 7)
            {
                var personascontroller = new SRM.PersonaFisicaController();
                var personasRegistro = personascontroller.ObteneByRegistroIdCamara(this.RegistroId, CamaraId);
                var personaRegistro = personasRegistro.FirstOrDefault();
                this.PersonaId = personaRegistro.PersonaId;

                if (RegistroId == 0 || CamaraId.Length == 0 || CamaraId.Length > 3)
                {
                    ErrorMessage = "No puede visualizar los datos de una empresa inexistente";
                    Response.Redirect("~/Empresas/Oficina.aspx");
                }


                //Interfaz
                InitInterface();
                if (this.RegistroId > 0 && this.CamaraId.Length > 0 && this.PersonaId > 0)
                {
                    const string urlCopiasCert = "/Operaciones/Shared/CopiasCert.aspx?SociedadId={0}&RegistroId={1}&CamaraId={2}&TipoSociedadId={3}&TipoServicioId={4}&PersonaId={5}";
                    const string urlActualizarDatosGenerales = "/Empresas/ActualizarDatosGenerales.aspx?SociedadId={0}&RegistroId={1}&CamaraId={2}&PersonaId={3}";
                    this.lnkActualizarDatosGenerales.NavigateUrl = String.Format(urlActualizarDatosGenerales, "", this.RegistroId, this.CamaraId, this.PersonaId);
                    this.lnkActualizarDatosGenerales.Visible = false;
                    this.HelpImgAD.Visible = false;
                    this.lnkCopiasRegistradas.NavigateUrl = String.Format(urlCopiasCert, "", this.RegistroId, this.CamaraId, this.TipoSociedadId, Helper.ServicioCopiasCertificadasId, this.PersonaId);
                    this.HelpImgCC.ToolTip = "Es una copia fiel de los documentos inscritos en el Registro Mercantil sellados por la Cámara.";
                }
            }
            else
            {
                var sociedadescontroller = new SRM.SociedadesController();
                var sociedadRegistro = sociedadescontroller.FetchSociedadesRegistroByRegistroId(this.RegistroId, CamaraId);
                this.SociedadId = sociedadRegistro.SociedadId;

                if (RegistroId == 0 || CamaraId.Length == 0 || CamaraId.Length > 3)
                {
                    ErrorMessage = "No puede visualizar los datos de una empresa inexistente";
                    Response.Redirect("~/Empresas/Oficina.aspx");
                }


                //Interfaz
                InitInterface();
                if (this.RegistroId > 0 && this.CamaraId.Length > 0 && this.SociedadId > 0)
                {
                    const string urlCopiasCert = "/Operaciones/Shared/CopiasCert.aspx?SociedadId={0}&RegistroId={1}&CamaraId={2}&TipoSociedadId={3}&TipoServicioId={4}";
                    const string urlActualizarDatosGenerales = "/Empresas/ActualizarDatosGenerales.aspx?SociedadId={0}&RegistroId={1}&CamaraId={2}";
                    this.lnkActualizarDatosGenerales.NavigateUrl = String.Format(urlActualizarDatosGenerales, this.SociedadId, this.RegistroId, this.CamaraId);
                    this.lnkCopiasRegistradas.NavigateUrl = String.Format(urlCopiasCert, this.SociedadId, this.RegistroId, this.CamaraId, this.SociedadRegistro.TipoSociedadId, Helper.ServicioCopiasCertificadasId);
                    this.HelpImgCC.ToolTip = "Es una copia fiel de los documentos inscritos en el Registro Mercantil sellados por la Cámara.";
                    this.HelpImgAD.ToolTip = "Consiste en la introducción o aportación de datos más actuales o recientes correspondientes a la sociedad.   " +
                        @"-CANTIDAD DE EMPLEADOS" +
                        "\n - CORREO ELECTRÓNICO / PÁGINA WEB / APARTADO POSTAL" +
                        "\n -INFORMACIONES GENERALES DE SOCIOS(Dirección, Nacionalidad, Estado Civil, Documento Identidad)" +
                        "\n -TELÉFONOS / FAX" +
                        "\n - REFERENCIAS COMERCIALES\nREFERENCIAS BANCARIAS" +
                        "\n - RNC" +
                        "\n - NOMBRE COMERCIAL" +
                        "\n - ÚLTIMA ASAMBLEA";
                }
            }
            
        }

        /// <summary>
        /// Inicializa los valores de la interfaz.
        /// </summary>
        protected void InitInterface()
        {
            if (TipoSociedadId == 7)
            {
                #region PersonaF
                var dbComun = new Comun.CamaraComunEntities();
                var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);

                var personascontroller = new SRM.PersonaFisicaController();
                var personas = personascontroller.ObteneByPersonaIdCamara(PersonaId, CamaraId);
                var persona = personas.FirstOrDefault();


                //Valido si la empresa esta adecuada o vencida
                DateTime? fechaVencimientoCalculated;
                    fechaVencimientoCalculated = persona.Registros.FechaVencimiento != null? persona.Registros.FechaVencimiento : (DateTime?)null;

                ValidateEmpresa(persona.PersonaId,false, persona.Registros.FechaVencimiento, fechaVencimientoCalculated);
                #endregion
                #region Generales
                var nombreCompleto = persona.Personas.PrimerNombre +" " + persona.Personas.SegundoNombre + " " + persona.Personas.PrimerApellido + " " + persona.Personas.SegundoApellido;
                litTituloM.Text = nombreCompleto;

                txtDenominacion.Text = nombreCompleto;
                //litTipoEmpresa.Text = dbComun.TipoSociedad.FirstOrDefault(c => c.TipoSociedadId == sociedadRegistro.TipoSociedadId).Etiqueta;
                //Numero registro mercantil.
                txtNumeroRegistro.Text = persona.NumeroRegistro.ToString();

                //Estatus
                txtStatus.Visible = false;
                lblEstatus.Visible = false;
                lblTipoEntidad.Visible = true;
                lblTipoSociedad.Visible = false;
                txtDuracionSociedad.Visible = false;
                lblDuracionSociedad.Visible = false;
                txtDuracionConsejo.Visible = false;
                lblDuracionConsejo.Visible = false;
                txtFechaUltActo.Visible = false;
                lblFechaUltActo.Visible = false;
                lblEnteRegulado.Visible = false;
                txtEnteRegulado.Visible = false;
                lblNumeroResolucion.Visible = false;
                txtNumeroResolucion.Visible = false;
                lblNumeroNaveInd.Visible = false;
                txtNumeroNaveInd.Visible = false;
                lblFechaConstitucion.Visible = false;
                lblFechaInicioOperacion.Visible = true;

                var tipoSociedad = dbComun.TipoSociedad.Where(a => a.TipoSociedadId == this.TipoSociedadId).FirstOrDefault();
                txtTipoSociedad.Text = tipoSociedad != null ? tipoSociedad.Descripcion : String.Empty;


                txtRNC.Text = persona.Personas.Rnc != null ? persona.Personas.Rnc.FormatRnc(): persona.Personas.Documento;

                txtFechaConstitucion.Text = persona.Registros.FechaInicioOperacion.HasValue
                                                ? persona.Registros.FechaInicioOperacion.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                                                : String.Empty;


                //txtDuracionSociedad.Text = sociedadRegistro.DuracionSociedad;
                //txtDuracionConsejo.Text = sociedadRegistro.DuraccionDirectiva.HasValue
                //                              ? sociedadRegistro.DuraccionDirectiva.Value + " años"
                //                              : String.Empty;

                //txtFechaUltActo.Text = sociedadRegistro.FechaModificacion.HasValue
                //                           ? sociedadRegistro.FechaModificacion.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                //                           : String.Empty;

                //txtEnteRegulado.Text = !String.IsNullOrEmpty(sociedadRegistro.TipoEnteRegulado)
                //                       ? sociedadRegistro.TipoEnteRegulado
                //                       : "No";

                //var noResolucionExiste = !String.IsNullOrEmpty(sociedadRegistro.NoResolucion);
                //txtNumeroResolucion.Text = sociedadRegistro.NoResolucion;
                //txtNumeroResolucion.Visible = noResolucionExiste;
                //lblNumeroResolucion.Visible = noResolucionExiste;

                //var noNaveExiste = !String.IsNullOrEmpty(sociedadRegistro.NumeroNaveIndustrial);
                //txtNumeroNaveInd.Text = sociedadRegistro.NumeroNaveIndustrial;
                //txtNumeroNaveInd.Visible = noNaveExiste;
                //lbltxtNumeroNaveInd.Visible = noNaveExiste;

                #endregion


                #region Direccion

                if (persona.Personas.DireccionId.HasValue)
                {
                    var repDirecciones = new Repository<SRM.ViewDirecciones, SRM.CamaraSRMEntities>(dbSrm);
                    var direccion = repDirecciones.SelectByKey(SRM.ViewDirecciones.PropColumns.DireccionId,
                                                                               persona.Personas.DireccionId.Value);

                    txtDireccion.Text = direccion.Calle;
                    txtNumero.Text = direccion.Numero;

                    if (direccion.PaisId.HasValue)
                    {
                        var pais = dbComun.Paises.Where(a => a.PaisId == direccion.PaisId).FirstOrDefault();
                        ddlPais.Text = pais != null ? pais.Nombre : String.Empty;
                    }
                    if (direccion.CiudadId.HasValue)
                    {
                        var ciudad = dbComun.Ciudades.Where(a => a.CiudadId == direccion.CiudadId).FirstOrDefault();
                        ddlCiudad.Text = ciudad != null ? ciudad.Nombre : String.Empty;

                    }

                    if (direccion.SectorId.HasValue)
                    {
                        var sector = dbComun.Sectores.Where(a => a.SectorId == direccion.SectorId).FirstOrDefault();
                        ddlSector.Text = sector != null ? sector.Nombre : String.Empty;
                    }

                    txtApartadoPostal.Text = direccion.ApartadoPostal;
                    txtTelefono1.Text = direccion.TelefonoCasa;
                    txtTelefono2.Text = direccion.TelefonoOficina;
                    txtFax.Text = direccion.Fax;
                }


                #endregion

                #region Registro

                txtFechaEmision.Text = persona.Registros.FechaEmision.HasValue
                                           ? persona.Registros.FechaEmision.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                                           : String.Empty;

                txtFechaVencimiento.Text = persona.Registros.FechaVencimiento.HasValue
                                               ? persona.Registros.FechaVencimiento.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                                               : String.Empty;

                txtFechaInicioOperacion.Text = persona.Registros.FechaInicioOperacion.HasValue
                                                   ? persona.Registros.FechaInicioOperacion.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                                                   : String.Empty;

                txtFechaUltModificacion.Text = persona.Registros.FechaModificacion != null
                                                   ? persona.Registros.FechaModificacion.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                                                   : String.Empty;

                #endregion

                #region Capital

                //Capital Autorizado
                txtAutorizado.Text = persona.Registros.CapitalAutorizado.HasValue
                                         ? persona.Registros.CapitalAutorizado.Value.ToString("n2")
                                         : "0.00";


                //Capital General
                txtGeneral.Text = persona.Registros.CapitalSocial.HasValue
                                      ? persona.Registros.CapitalSocial.Value.ToString("n2")
                                      : "0.00";


                //Capital Bienes
                txtBienes.Text = persona.Registros.BienesRaices.HasValue
                                     ? persona.Registros.BienesRaices.Value.ToString("n2")
                                     : "0.00";


                //Capital Pagado
                txtPagado.Text = persona.Registros.CapitalPagado.HasValue
                                      ? persona.Registros.CapitalPagado.Value.ToString("n2")
                                      : "0.00";

                //Capital Activo
                txtActivos.Text = persona.Registros.Activos.HasValue
                                      ? persona.Registros.Activos.Value.ToString("n2")
                                      : "0.00";

                #endregion

                #region Empleado
                //Cantidad de Empleados
                var masc = persona.Registros.EmpleadosMasculinos.HasValue ? persona.Registros.EmpleadosMasculinos.Value : 0;
                var fem = persona.Registros.EmpleadosFemeninos.HasValue ? persona.Registros.EmpleadosFemeninos.Value : 0;
                txtMasculinos.Text = String.Format("Masculinos: {0} | Femeninos: {1}", masc, fem);

                #endregion

                if (!string.IsNullOrEmpty(persona.Registros.NombreComercial))
                {
                    txtNombreComercial.Text = persona.Registros.NombreComercial;
                    txtNombreComercialNumero.Text = persona.Registros.RegistroNombreComercial;
                }
                else
                {
                    txtNombreComercial.Visible = false;
                    txtNombreComercialNumero.Visible = false;
                    lblNombreComercial.Visible = false;
                    lblNombreComercialVacio.Text = "No existe una marca de nombre comercial registrada.";
                }

                txtActividad.Text = persona.Registros.ActividadNegocio;

                #region
                //Actividades
                var tipoActivad = dbSrm.ViewRegistrosActividades.Where(a => a.RegistroId == persona.Registros.RegistroId).ToList();
                cblTipoActividades.DataSource = tipoActivad;
                cblTipoActividades.DataBind();
                cblTipoActividades.Visible = (cblTipoActividades.Items.Count > 0);

                //Agregando el Tipo de Sociedad para que pueda mostrarse las opciones disponibles

                #endregion

                //Validacion de si la empresa se puede renovar
                var puedeRenovar = persona.Registros.FechaVencimiento.HasValue
                                    ? (persona.Registros.FechaVencimiento.Value - DateTime.Today).Days < Helper.TiempoMinimoPermitirRenovacionDias
                                    : true;
                if (!puedeRenovar)
                {
                    foreach (RepeaterItem item in
                        tpTipoTransacciones.Items.Cast<RepeaterItem>()
                        .Where(item => item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem))
                    {
                        var hf = item.FindControl("hfServicioId") as HiddenField;
                        if (hf != null)
                        {
                            if (hf.Value.Trim() == Helper.TipoServicioIdRenovacion.ToString().Trim())
                            {
                                var btn = item.FindControl("hlOpcion") as LinkButton;
                                if (btn != null)
                                {
                                    btn.CommandName = "renovacionNoEsPosible";
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                #region Sociedades
                var dbComun = new Comun.CamaraComunEntities();
                var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);

                var sociedadescontroller = new SRM.SociedadesController();
                var sociedadRegistro = sociedadescontroller.FetchSociedadesRegistroBySociedadId(SociedadId, CamaraId);

                //Valido si la empresa esta adecuada o vencida
                DateTime? fechaVencimientoCalculated;
                if (!sociedadRegistro.FechaVencimiento.HasValue)
                    fechaVencimientoCalculated = sociedadRegistro.FechaEmision.HasValue ? sociedadRegistro.FechaEmision.Value.AddYears(sociedadRegistro.DuraccionDirectiva.HasValue ? sociedadRegistro.DuraccionDirectiva.Value : 0) : (DateTime?)null;
                else
                    fechaVencimientoCalculated = sociedadRegistro.FechaVencimiento;

                ValidateEmpresa(0,sociedadRegistro.bAdecuada, sociedadRegistro.FechaVencimiento, fechaVencimientoCalculated);

                #region Generales

                litTituloM.Text = sociedadRegistro.NombreSociedad ?? sociedadRegistro.NombreEmpresa;
                txtDenominacion.Text = sociedadRegistro.NombreSociedad ?? sociedadRegistro.NombreEmpresa;
                //litTipoEmpresa.Text = dbComun.TipoSociedad.FirstOrDefault(c => c.TipoSociedadId == sociedadRegistro.TipoSociedadId).Etiqueta;
                //Numero registro mercantil.
                txtNumeroRegistro.Text = sociedadRegistro.NumeroRegistro.ToString();

                //Estatus
                var estatus = dbComun.EstadoRegistro.Where(a => a.EstadoRegistroId == sociedadRegistro.EstatusId).FirstOrDefault();
                txtStatus.Text = estatus != null ? estatus.Descripcion : String.Empty;

                if (sociedadRegistro.TipoSociedadId.HasValue)
                {
                    var tipoSociedad = dbComun.TipoSociedad.Where(a => a.TipoSociedadId == sociedadRegistro.TipoSociedadId).FirstOrDefault();
                    txtTipoSociedad.Text = tipoSociedad != null ? tipoSociedad.Descripcion : String.Empty;
                }

                txtRNC.Text = sociedadRegistro.Rnc.FormatRnc();

                txtFechaConstitucion.Text = sociedadRegistro.FechaConstitucion.HasValue
                                                ? sociedadRegistro.FechaConstitucion.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                                                : String.Empty;

                txtDuracionSociedad.Text = sociedadRegistro.DuracionSociedad;
                txtDuracionConsejo.Text = sociedadRegistro.DuraccionDirectiva.HasValue
                                              ? sociedadRegistro.DuraccionDirectiva.Value + " años"
                                              : String.Empty;

                txtFechaUltActo.Text = sociedadRegistro.FechaModificacion.HasValue
                                           ? sociedadRegistro.FechaModificacion.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                                           : String.Empty;

                txtEnteRegulado.Text = !String.IsNullOrEmpty(sociedadRegistro.TipoEnteRegulado)
                                       ? sociedadRegistro.TipoEnteRegulado
                                       : "No";

                var noResolucionExiste = !String.IsNullOrEmpty(sociedadRegistro.NoResolucion);
                txtNumeroResolucion.Text = sociedadRegistro.NoResolucion;
                txtNumeroResolucion.Visible = noResolucionExiste;
                lblNumeroResolucion.Visible = noResolucionExiste;

                var noNaveExiste = !String.IsNullOrEmpty(sociedadRegistro.NumeroNaveIndustrial);
                txtNumeroNaveInd.Text = sociedadRegistro.NumeroNaveIndustrial;
                txtNumeroNaveInd.Visible = noNaveExiste;
                lblNumeroNaveInd.Visible = noNaveExiste;

                #endregion

                #region Direccion

                if (sociedadRegistro.DireccionId.HasValue)
                {


                    var repDirecciones = new Repository<SRM.ViewDirecciones, SRM.CamaraSRMEntities>(dbSrm);
                    var direccion = repDirecciones.SelectByKey(SRM.ViewDirecciones.PropColumns.DireccionId,
                                                                               sociedadRegistro.DireccionId.Value);

                    txtDireccion.Text = direccion.Calle;
                    txtNumero.Text = direccion.Numero;

                    if (direccion.PaisId.HasValue)
                    {
                        var pais = dbComun.Paises.Where(a => a.PaisId == direccion.PaisId).FirstOrDefault();
                        ddlPais.Text = pais != null ? pais.Nombre : String.Empty;
                    }
                    if (direccion.CiudadId.HasValue)
                    {
                        var ciudad = dbComun.Ciudades.Where(a => a.CiudadId == direccion.CiudadId).FirstOrDefault();
                        ddlCiudad.Text = ciudad != null ? ciudad.Nombre : String.Empty;

                    }

                    if (direccion.SectorId.HasValue)
                    {
                        var sector = dbComun.Sectores.Where(a => a.SectorId == direccion.SectorId).FirstOrDefault();
                        ddlSector.Text = sector != null ? sector.Nombre : String.Empty;
                    }

                    txtApartadoPostal.Text = direccion.ApartadoPostal;
                    txtTelefono1.Text = direccion.TelefonoCasa;
                    txtTelefono2.Text = direccion.TelefonoOficina;
                    txtFax.Text = direccion.Fax;
                }


                #endregion

                #region Registro

                txtFechaEmision.Text = sociedadRegistro.FechaEmision.HasValue
                                           ? sociedadRegistro.FechaEmision.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                                           : String.Empty;

                txtFechaVencimiento.Text = sociedadRegistro.FechaVencimiento.HasValue
                                               ? sociedadRegistro.FechaVencimiento.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                                               : String.Empty;

                txtFechaInicioOperacion.Text = sociedadRegistro.FechaInicioOperacion.HasValue
                                                   ? sociedadRegistro.FechaInicioOperacion.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                                                   : String.Empty;

                txtFechaUltModificacion.Text = sociedadRegistro.FechaModificacion.HasValue
                                                   ? sociedadRegistro.FechaModificacion.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                                                   : String.Empty;

                #region Capital

                SociedadRegistro = sociedadRegistro;

                //Capital Autorizado
                txtAutorizado.Text = sociedadRegistro.CapitalAutorizado.HasValue
                                         ? sociedadRegistro.CapitalAutorizado.Value.ToString("n2")
                                         : "0.00";


                //Capital General
                txtGeneral.Text = sociedadRegistro.CapitalSocial.HasValue
                                      ? sociedadRegistro.CapitalSocial.Value.ToString("n2")
                                      : "0.00";


                //Capital Bienes
                txtBienes.Text = sociedadRegistro.BienesRaices.HasValue
                                     ? sociedadRegistro.BienesRaices.Value.ToString("n2")
                                     : "0.00";


                //Capital Pagado
                txtPagado.Text = sociedadRegistro.CapitalPagado.HasValue
                                      ? sociedadRegistro.CapitalPagado.Value.ToString("n2")
                                      : "0.00";

                //Capital Activo
                txtActivos.Text = sociedadRegistro.Activos.HasValue
                                      ? sociedadRegistro.Activos.Value.ToString("n2")
                                      : "0.00";

                #endregion

                //Cantidad de Empleados
                var masc = sociedadRegistro.EmpleadosMasculinos.HasValue ? sociedadRegistro.EmpleadosMasculinos.Value : 0;
                var fem = sociedadRegistro.EmpleadosFemeninos.HasValue ? sociedadRegistro.EmpleadosFemeninos.Value : 0;
                txtMasculinos.Text = String.Format("Masculinos: {0} | Femeninos: {1}", masc, fem);

                #endregion

                if (!string.IsNullOrEmpty(sociedadRegistro.NombreComercial))
                {
                    txtNombreComercial.Text = sociedadRegistro.NombreComercial;
                    txtNombreComercialNumero.Text = sociedadRegistro.RegistroNombreComercial;
                }
                else
                {
                    txtNombreComercial.Visible = false;
                    txtNombreComercialNumero.Visible = false;
                    lblNombreComercial.Visible = false;
                    lblNombreComercialVacio.Text = "No existe una marca de nombre comercial registrada.";
                }

                txtActividad.Text = sociedadRegistro.ActividadNegocio;

                //Actividades
                var tipoActivad = dbSrm.ViewRegistrosActividades.Where(a => a.RegistroId == sociedadRegistro.RegistroId).ToList();
                cblTipoActividades.DataSource = tipoActivad;
                cblTipoActividades.DataBind();
                cblTipoActividades.Visible = (cblTipoActividades.Items.Count > 0);

                //Agregando el Tipo de Sociedad para que pueda mostrarse las opciones disponibles
                TipoSociedadId = sociedadRegistro.TipoSociedadId.Value2();
                #endregion

                //Validacion de si la empresa se puede renovar
                var puedeRenovar = sociedadRegistro.FechaVencimiento.HasValue
                                    ? (sociedadRegistro.FechaVencimiento.Value - DateTime.Today).Days < Helper.TiempoMinimoPermitirRenovacionDias
                                    : true;
                if (!puedeRenovar)
                {
                    foreach (RepeaterItem item in
                        tpTipoTransacciones.Items.Cast<RepeaterItem>()
                        .Where(item => item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem))
                    {
                        var hf = item.FindControl("hfServicioId") as HiddenField;
                        if (hf != null)
                        {
                            if (hf.Value.Trim() == Helper.TipoServicioIdRenovacion.ToString().Trim())
                            {
                                var btn = item.FindControl("hlOpcion") as LinkButton;
                                if (btn != null)
                                {
                                    btn.CommandName = "renovacionNoEsPosible";
                                }
                            }
                        }
                    }
                }
            }
        }

        private void InitMonedad(SRM.cvw_SociedadesRegistros sociedadRegistro)
        {
            var tipmonedaRep = new Comun.TipoMonedaRepository();
            var tiposMonedas = tipmonedaRep.SelectAll();


            if (sociedadRegistro.TipoMonedaCapitalAutorizado.HasValue)
            {
                var moneda = tiposMonedas
                    .Where(m => m.TipoMonedaId == sociedadRegistro.TipoMonedaCapitalAutorizado)
                    .FirstOrDefault();
                ddlMonedaAutorizado.Text = moneda != null ? moneda.Abreviatura : String.Empty;
            }

            if (sociedadRegistro.TipoMonedaActivos.HasValue)
            {
                var moneda = tiposMonedas
                    .Where(m => m.TipoMonedaId == sociedadRegistro.TipoMonedaActivos)
                    .FirstOrDefault();
                ddlMonedaActivos.Text = moneda != null ? moneda.Abreviatura : String.Empty;
            }

            if (sociedadRegistro.TipoMonedaCapitalPagado.HasValue)
            {
                var moneda = tiposMonedas
                    .Where(m => m.TipoMonedaId == sociedadRegistro.TipoMonedaCapitalPagado)
                    .FirstOrDefault();
                ddlMonedaPagado.Text = moneda != null ? moneda.Abreviatura : String.Empty;
            }

            if (sociedadRegistro.TipoMonedaBienesRaices.HasValue)
            {
                var moneda = tiposMonedas
                    .Where(m => m.TipoMonedaId == sociedadRegistro.TipoMonedaBienesRaices)
                    .FirstOrDefault();
                ddlMonedaBienes.Text = moneda != null ? moneda.Abreviatura : String.Empty;
            }

            if (sociedadRegistro.TipoMonedaCapitalSocial.HasValue)
            {
                var moneda = tiposMonedas
                    .Where(m => m.TipoMonedaId == sociedadRegistro.TipoMonedaCapitalSocial)
                    .FirstOrDefault();
                ddlMonedaGeneral.Text = moneda != null ? moneda.Abreviatura : String.Empty;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleEmpresa.Page_PreRenderComplete(object, EventArgs)'
        protected void Page_PreRenderComplete(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleEmpresa.Page_PreRenderComplete(object, EventArgs)'
        {
            if (!IsPostBack && SociedadRegistro != null)
                InitMonedad(SociedadRegistro);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleEmpresa.ShowMenu()'
        protected void ShowMenu()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleEmpresa.ShowMenu()'
        {
            tpTipoTransacciones.DataSource = odsTipoTransacciones.Select();
            tpTipoTransacciones.DataBind();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleEmpresa.tpTipoTransacciones_OnItemCreated(object, RepeaterItemEventArgs)'
        protected void tpTipoTransacciones_OnItemCreated(object sender, RepeaterItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleEmpresa.tpTipoTransacciones_OnItemCreated(object, RepeaterItemEventArgs)'
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;

            var detalle = e.Item.DataItem as OFV.TipoServicioDetalles;
            var hl = e.Item.FindControl("hlOpcion") as LinkButton;
            var tooltip = e.Item.FindControl("HelpImg") as Image;
            tooltip.ToolTip = !string.IsNullOrEmpty(detalle.DescripcionAyuda) ? detalle.DescripcionAyuda : "";

            if (hl == null || detalle == null) return;

            var qry = string.Empty;
            var qryt = string.Empty;
            
                if (!DefaultQueryString.Contains("TipoServicioId="))
                DefaultQueryString = String.Format("TipoServicioId={0}", detalle.TipoServicioId);

            if (!String.IsNullOrWhiteSpace(detalle.WebKey))
                DefaultQueryString = String.Format("TipoServicioId={0}&ServicioId={1}", detalle.TipoServicioId,
                                                   ServiciosDefault.Servicios.FirstOrDefault(a => a.TipoSociedadId == this.TipoSociedadId)[detalle.WebKey]);

            if (DefaultQueryString.Contains("SociedadId="))
            {
                if(TipoSociedadId != 7)
                {
                    var sociedadescontroller = new SRM.SociedadesController();
                    var sociedadRegistro = sociedadescontroller.FetchSociedadesRegistroByRegistroId(this.RegistroId, CamaraId);
                    var sociedadId = sociedadRegistro.SociedadId;
                    int socId;
                    int.TryParse(Request.QueryString["SociedadId"], out socId);
                    if (socId == 0)
                    {
                        qry = Regex.Replace(DefaultQueryString.ToString(), "SociedadId=", string.Format("SociedadId={0}", sociedadId));
                        qryt = String.Format("?SociedadId={0}{1}", sociedadRegistro.SociedadId, DefaultQueryString.Substring(12));
                    }
                }
                else
                {
                    var ctrlPersona = new SRM.PersonaFisicaController();
                    var personas = ctrlPersona.ObteneByRegistroIdCamara(RegistroId, CamaraId);
                    if (personas.Count == 0)
                    {
                        this.GenerateCustomError("No se encontró ninguna entidad Persona con ese Número de Registro en la Cámara indicada");
                        return;
                    }
                    var persona = personas.First();
                    if (!DefaultQueryString.Contains("&PersonaId="))
                    {
                        qryt = String.Format("{0}&PersonaId={1}", DefaultQueryString, persona.PersonaId);
                    }
                    
                }
                

            }

            hl.CommandArgument = detalle.Url + qryt;

            DefaultQueryString = String.Empty;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleEmpresa.GoOption(object, EventArgs)'
        protected void GoOption(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleEmpresa.GoOption(object, EventArgs)'
        {
            var lb = sender as LinkButton;
            if (lb == null) return;
            //Aqui si es una verificacion se verifica si esta compania ya se esta modificando
            //en caso de que si saldra un aviso.
            if (lb.Text.Equals(BotonModificacion) && ModificacionCompanias.EstaSiendoModificada(this.CamaraId, Convert.ToInt32(txtNumeroRegistro.Text), this.CurrentUser.UserName.ToLower())) 
            {
                Session["ModificacionURL"] = lb.CommandArgument;
                Response.Redirect("/Empresas/MensajeModificacion.aspx");
            }

            if (lb.CommandArgument.StartsWith("~/Operaciones/Shared/RegDup.aspx"))
            {
                if(this.TipoSociedadId != 7)
                {
                    var sociedadescontroller = new SRM.SociedadesController();
                    var sociedadRegistro = sociedadescontroller.FetchSociedadesRegistroBySociedadId(SociedadId, CamaraId);
                    if (TransaccionesValidator.ExisteTransaccionActivaMejora(this.CamaraId, 401, sociedadRegistro.NumeroRegistro, Helper.IdEstatusTransaccionesDuplicar, this.TipoSociedadId))
                    {
                        ErrorMessage = "Ya existe una solicitud de este servicio.  Verifique el historico de transacciones.";
                        Master.ShowMessageError(ErrorMessage);
                        return;
                    }
                }
                else
                {
                    var personaController = new SRM.PersonaFisicaController();
                    var PersonaRegistro = personaController.ObteneByPersonaIdCamara(PersonaId, CamaraId).First();
                    if (TransaccionesValidator.ExisteTransaccionActivaMejora(this.CamaraId, 401, PersonaRegistro.NumeroRegistro, Helper.IdEstatusTransaccionesDuplicar, this.TipoSociedadId))
                    {
                        ErrorMessage = "Ya existe una solicitud de este servicio.  Verifique el historico de transacciones.";
                        Master.ShowMessageError(ErrorMessage);
                        return;
                    }
                }
                
            }
            if(this.TipoSociedadId != 7)
            {
                if (String.IsNullOrWhiteSpace(lb.CommandName))
                {
                    if (lb.CommandArgument.StartsWith("~/Operaciones/Shared/RegDup.aspx"))
                    {
                        ServicioId = 401;

                        var rpath = Request.QueryString + "&nservId=" + ServicioId;
                        //  Response.Redirect(lb.CommandArgument + "?" + Request.QueryString); bk -2021-09-06
                        Response.Redirect("/Empresas/DatosGenerales.aspx" + "?" + rpath);
                    }
                    else
                         
                    {
                        if (String.IsNullOrWhiteSpace(lb.CommandName))
                            Response.Redirect(lb.CommandArgument + "?" + Request.QueryString);
                    }


                }

               
            }
            else
            {
                if (String.IsNullOrWhiteSpace(lb.CommandName))
                    Response.Redirect(lb.CommandArgument);
            }


            switch (lb.CommandName)
            {
                case "servicioRenovacionSimpleId":
                    if (this.TipoSociedadId != 7)
                    {
                        var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);
                        var regActual = dbSrm.SociedadesRegistros.Where(a => a.RegistroId == this.RegistroId && a.SociedadId == this.SociedadId)
                                        .Select(a => a.Registros).FirstOrDefault();

                        if (PuedeRenovar(regActual.FechaVencimiento) >= 180)
                        {
                            ErrorMessage = string
                                .Format("Puede internar renovar cuando a su Registro le quede menos de 180 días para vencer, Actualmente su registro vence en {0:n0} días."
                                , PuedeRenovar(regActual.FechaVencimiento));
                            Master.ShowMessageError(ErrorMessage);
                            return;
                        }
                        /*if (!InitRenovacion(regActual))
                        {
                            ErrorMessage =
                                "Su registro Mercantil se encuentra vigente.  Puede solicitar la renovacion en los ultimos " +
                                Helper.TiempoMinimoPermitirRenovacionMeses.ToString() + " meses antes de su vencimiento.";
                            Master.ShowMessageError(ErrorMessage);
                            break;
                        }*/
                        this.ServicioId =
                            ServiciosDefault.Servicios.FirstOrDefault(a => a.TipoSociedadId == this.TipoSociedadId)[
                                lb.CommandName];
                        this.LoadRegistroData(dbSrm, regActual);
                        this.RegistroNuevo.EsRenovacion = true;
                        this.GuardarObjetosRegistro();
                        if (String.IsNullOrWhiteSpace(ErrorMessage))
                            Response.Redirect("~/TarjetaCredito/PagosTarjeta.aspx" + DefaultQueryString);
                        Master.ShowMessageError(ErrorMessage);
                    }
                    else
                    {
                        var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);
                        var regActual = dbSrm.PersonasRegistros.Where(a => a.RegistroId == this.RegistroId && a.PersonaId == this.PersonaId)
                                        .Select(a => a.Registros).FirstOrDefault();
                        var personaController = new SRM.PersonaFisicaController();
                        
                        var PersonaRegistro = personaController.ObteneByPersonaIdCamara(PersonaId, CamaraId).First();
                        if (PuedeRenovar(regActual.FechaVencimiento) >= 180)
                        {
                            ErrorMessage = string
                                .Format("Puede internar renovar cuando a su Registro le quede menos de 180 días para vencer, Actualmente su registro vence en {0:n0} días."
                                , PuedeRenovar(regActual.FechaVencimiento));
                            Master.ShowMessageError(ErrorMessage);
                            return;
                        }
                        /*if (!InitRenovacion(regActual))
                        {
                            ErrorMessage =
                                "Su registro Mercantil se encuentra vigente.  Puede solicitar la renovacion en los ultimos " +
                                Helper.TiempoMinimoPermitirRenovacionMeses.ToString() + " meses antes de su vencimiento.";
                            Master.ShowMessageError(ErrorMessage);
                            break;
                        }*/
                        this.ServicioId = 421;

                        if (TransaccionesValidator.ExisteTransaccionActivaMejora(this.CamaraId, this.ServicioId, PersonaRegistro.NumeroRegistro, Helper.IdEstatusTransaccionesDuplicar, this.TipoSociedadId))
                        {
                            ErrorMessage = "Ya existe una solicitud de este servicio.  Verifique el historico de transacciones.";
                            Master.ShowMessageError(ErrorMessage);
                            return;
                        }

                        this.LoadRegistroDataPer(dbSrm, regActual);
                        this.RegistroNuevo.EsRenovacion = true;
                        this.GuardarObjetosRegistroPer();
                        if (String.IsNullOrWhiteSpace(ErrorMessage))
                            Response.Redirect("~/TarjetaCredito/PagosTarjeta.aspx" + DefaultQueryString);
                        Master.ShowMessageError(ErrorMessage);
                    }
                    break;
                    
                
                case "renovacionNoEsPosible":
                    var error = String.Format(
                            "Las empresas solo pueden ser renovadas a partir de {0} días antes de su fecha de vencimiento.", Helper.TiempoMinimoPermitirRenovacionDias);
                    Master.ShowMessageError(error);
                    break;
            }
        }

        private bool InitRenovacion(SRM.Registros regActual)
        {
            var fechaVenc = regActual.FechaVencimiento;
            var fechaEmision = regActual.FechaEmision.GetValueOrDefault();

            bool result =
               (fechaVenc.HasValue &&
                 fechaVenc.Value <= DateTime.Today.AddMonths(Helper.TiempoMinimoPermitirRenovacionMeses)) ||
                fechaEmision.AddYears(Helper.DuracionRegistroMercantilAnos) <=
                DateTime.Today.AddMonths(Helper.TiempoMinimoPermitirRenovacionMeses);

            return result;

        }

        private int PuedeRenovar(DateTime? fechaVencimiento)
        {
            if(fechaVencimiento != null)
            {
                DateTime hoy = DateTime.Today;
                TimeSpan diferencia =  fechaVencimiento.Value - hoy;
                return Convert.ToInt32(diferencia.Days);
            }
            return 368;
        }


    }
}