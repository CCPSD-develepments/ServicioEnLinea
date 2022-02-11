using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamaraComercio.Website.Helpers.ExtendedControls;
using CamaraComercio.Website.Operations;
using CamaraComercio.Website.Helpers;
using ComunEF = CamaraComercio.DataAccess.EF.CamaraComun;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using EF = CamaraComercio.DataAccess.EF;
using OFVper = CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.DataAccess.EF;

namespace CamaraComercio.Website.Operaciones
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage'
    public abstract class FormularioPage : OperationPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage'
    {
        #region Propiedades
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.ServiciosDefault'
        public static ServicioSection ServiciosDefault
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.ServiciosDefault'
        {
            get
            {
                return (ServicioSection)WebConfigurationManager.GetWebApplicationSection("servicioSection");
            }
        }
        #endregion

        #region Propiedades en Sesion

        /// <summary>
        /// Contiene el Id de la Camara.
        /// </summary>
        protected String CamaraId
        {
            get { return !String.IsNullOrWhiteSpace(Request.QueryString["CamaraId"]) ? Request.QueryString["CamaraId"] : String.Empty; }
            set { DefaultQueryString = String.Format("CamaraId={0}", value); }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.TipoSocIdQuery'
        protected String TipoSocIdQuery
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.TipoSocIdQuery'
        {
            get { return !String.IsNullOrWhiteSpace(Request.QueryString["TipoSociedadId"]) ? Request.QueryString["TipoSociedadId"] : String.Empty; }
            set { DefaultQueryString = String.Format("TipoSocieadadId={0}", value); }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.RegistroSistemaActual'
        protected SRM.Registros RegistroSistemaActual
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.RegistroSistemaActual'
        {
            get
            {
                if (Session["RegistroSistemaActual"] == null)
                    Session["RegistroSistemaActual"] = new SRM.Registros();
                return (SRM.Registros)Session["RegistroSistemaActual"];
            }
            set { Session["RegistroSistemaActual"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.RegistroNuevo'
        protected OFV.Registros RegistroNuevo
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.RegistroNuevo'
        {
            get
            {
                if (Session["RegistroNuevo"] == null)
                    Session["RegistroNuevo"] = new OFV.Registros();
                return (OFV.Registros)Session["RegistroNuevo"];
            }
            set { Session["RegistroNuevo"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.SociedadRegistroNuevo'
        protected OFV.Sociedades SociedadRegistroNuevo
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.SociedadRegistroNuevo'
        {
            get
            {
                if (Session["SociedadRegistroNuevo"] == null)
                    Session["SociedadRegistroNuevo"] = new OFV.Sociedades();
                return (OFV.Sociedades)Session["SociedadRegistroNuevo"];
            }
            set { Session["SociedadRegistroNuevo"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.PersonasRegistroNuevo'
        protected OFVper.Personas PersonasRegistroNuevo
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.PersonasRegistroNuevo'
        {
            get
            {
                if (Session["PersonaRegistroNuevo"] == null)
                    Session["PersonaRegistroNuevo"] = new OFV.Personas();
                return (OFV.Personas)Session["PersonaRegistroNuevo"];
            }
            set { Session["PersonaRegistroNuevo"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.ActividadesEnRegistro'
        protected List<OFV.RegistrosActividades> ActividadesEnRegistro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.ActividadesEnRegistro'
        {
            get
            {
                if (Session["ActividadesEnRegistro"] == null)
                    Session["ActividadesEnRegistro"] = new List<OFV.RegistrosActividades>();
                return (List<OFV.RegistrosActividades>)Session["ActividadesEnRegistro"];
            }
            set { Session["ActividadesEnRegistro"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.ProductosEnRegistro'
        protected List<OFV.Productos> ProductosEnRegistro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.ProductosEnRegistro'
        {
            get
            {
                if (Session["ProductosEnRegistro"] == null)
                    Session["ProductosEnRegistro"] = new List<OFV.Productos>();
                return (List<OFV.Productos>)Session["ProductosEnRegistro"];
            }
            set { Session["ProductosEnRegistro"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.SociosEnRegistro'
        protected List<OFV.Socios> SociosEnRegistro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.SociosEnRegistro'
        {
            get
            {
                if (Session["Socios"] == null)
                    Session["Socios"] = new List<OFV.Socios>();
                return (List<OFV.Socios>)Session["Socios"];
            }
            set
            {
                Session["Socios"] = value;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.SociosAdminEnRegistro'
        protected List<OFV.Socios> SociosAdminEnRegistro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.SociosAdminEnRegistro'
        {
            get
            {
                if (Session["PersistedSocios"] == null)
                    Session["PersistedSocios"] = new List<OFV.Socios>();
                return (List<OFV.Socios>)Session["PersistedSocios"];
            }
            set
            {
                Session["PersistedSocios"] = value;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.SociosAutorizadosFirma'
        protected List<OFV.Socios> SociosAutorizadosFirma
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.SociosAutorizadosFirma'
        {
            get
            {
                if (Session["SociosAutorizadosFirma"] == null)
                    Session["SociosAutorizadosFirma"] = new List<OFV.Socios>();
                return (List<OFV.Socios>)Session["SociosAutorizadosFirma"];
            }
            set
            {
                Session["SociosAutorizadosFirma"] = value;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.Representantes'
        protected List<OFV.Personas> Representantes
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.Representantes'
        {
            get
            {
                //  get the customers collection from session
                var representantes =
                    HttpContext.Current.Session["Representantes"] as List<OFV.Personas>;

                //  load the customers on first access
                if (representantes == null)
                {
                    representantes = new List<OFV.Personas>();

                    //  cache the list
                    HttpContext.Current.Session["Representantes"] = representantes;
                }

                return representantes;
            }
            set { HttpContext.Current.Session["Representantes"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.ReferenciasBancariasRegistro'
        protected List<OFV.ReferenciasBancarias> ReferenciasBancariasRegistro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.ReferenciasBancariasRegistro'
        {
            get
            {
                if (Session["ReferenciasBancariasRegistro"] == null)
                    Session["ReferenciasBancariasRegistro"] = new List<OFV.ReferenciasBancarias>();
                return (List<OFV.ReferenciasBancarias>)Session["ReferenciasBancariasRegistro"];
            }
            set { Session["ReferenciasBancariasRegistro"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.Bancos'
        protected List<ComunEF.Bancos> Bancos
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.Bancos'
        {
            get
            {
                if (Session["Bancos"] == null)
                    Session["Bancos"] = new List<ComunEF.Bancos>();
                return (List<ComunEF.Bancos>)Session["Bancos"];
            }
            set { Session["Bancos"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.ReferenciasComercialesRegistro'
        protected List<OFV.ReferenciasComerciales> ReferenciasComercialesRegistro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.ReferenciasComercialesRegistro'
        {
            get
            {
                if (Session["ReferenciasComercialesRegistro"] == null)
                    Session["ReferenciasComercialesRegistro"] = new List<OFV.ReferenciasComerciales>();
                return (List<OFV.ReferenciasComerciales>)Session["ReferenciasComercialesRegistro"];
            }
            set { Session["ReferenciasComercialesRegistro"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.SucursalesRegistro'
        protected List<OFV.Sucursales> SucursalesRegistro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.SucursalesRegistro'
        {
            get
            {
                if (Session["SucursalesRegistro"] == null)
                    Session["SucursalesRegistro"] = new List<OFV.Sucursales>();
                return (List<OFV.Sucursales>)Session["SucursalesRegistro"];
            }
            set { Session["SucursalesRegistro"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.TransaccionesEnRegistro'
        protected List<OFV.Transacciones> TransaccionesEnRegistro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.TransaccionesEnRegistro'
        {
            get
            {
                if (Session["TransaccionesEnRegistro"] == null)
                    Session["TransaccionesEnRegistro"] = new List<OFV.Transacciones>();
                return (List<OFV.Transacciones>)Session["TransaccionesEnRegistro"];
            }
            set { Session["TransaccionesEnRegistro"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.IsFormularionConfirmacion'
        protected bool IsFormularionConfirmacion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.IsFormularionConfirmacion'
        {
            get
            {
                return Session["bIsFormularionConfirmacion"] == null ? false : (bool)Session["bIsFormularionConfirmacion"];
            }
            set
            {
                Session["bIsFormularionConfirmacion"] = value;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.TransaccionIdIndex'
        protected int TransaccionIdIndex
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.TransaccionIdIndex'
        {
            get
            {
                if (Session["TransaccionIdIndex"] == null)
                    Session["TransaccionIdIndex"] = 0;

                return int.Parse(Session["TransaccionIdIndex"].ToString());
            }
            set
            {
                Session["TransaccionIdIndex"] = value;
            }
        }
        /// <summary>
        /// Propiedad que contiene la información de DGII
        /// </summary>
        protected ReciboDGII ReciboDgii
        {
            get
            {
                if (Session["ReciboDGII"] == null)
                    Session["ReciboDGII"] = new ReciboDGII();
                return (ReciboDGII)Session["ReciboDGII"];
            }
            set { Session["ReciboDGII"] = value; }
        }


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.ServicioId'
        protected int ServicioId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.ServicioId'
        {
            get
            {
                if (Session["ServicioId"] == null)
                    Session["ServicioId"] = 0;

                return int.Parse(Session["ServicioId"].ToString());
            }
            set
            {
                Session["ServicioId"] = value;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.IsEditMode'
        protected bool IsEditMode
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.IsEditMode'
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(Request.QueryString["action"]))
                {
                    if (Request.QueryString["action"] == "edit")
                        return true;
                }
                return false;

            }
            set { DefaultQueryString = String.Format("action={0}", value); }
        }
        #endregion

        #region Implementacion de Controles Dinámicos de acuerdo al tipo de Sociedad
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.PropiedadesSociedadActual'
        public IEnumerable<OFV.PropiedadesPorSociedad> PropiedadesSociedadActual
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.PropiedadesSociedadActual'
        {
            get
            {
                return Session["PropiedadesSociedadActual"] != null
                           ? (IEnumerable<OFV.PropiedadesPorSociedad>)Session["PropiedadesSociedadActual"]
                           : null;
            }
            set { Session["PropiedadesSociedadActual"] = value; }
        }

        /// <summary>
        /// Llave primaria del Tipo de Sociedad seleccionada.
        /// </summary>
        public int TipoSociedadId
        {
            get { return Session["TipoSociedadId"] == null ? 0 : int.Parse(Session["TipoSociedadId"].ToString()); }
            set { Session["TipoSociedadId"] = value; }
        }

        /// <summary>
        /// Renderiza los controles dinámicos de acuerdo al tipo de sociedad
        /// </summary>
        /// <param name="controles"></param>
        public void RenderizarControles(ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                try
                {
                    if (control is IExtendedControlOfv)
                    {
                        var controlOfv = (IExtendedControlOfv)control;

                        if (PropiedadesSociedadActual != null && PropiedadesSociedadActual.Count() > 0)
                        {
                            var prop = PropiedadesSociedadActual.Where(p => p.PropiedadesUI.Nombre ==
                                                                            controlOfv.PropertyName).FirstOrDefault();

                            if (prop == null)
                                continue;

                            control.Visible = control.ID.Equals("btnValidarNoRecibo") ? false : prop.Required;
                            //control.Visible = prop.Required;

                            if (control is LabelOfv)
                            {
                                if (!String.IsNullOrEmpty(prop.Descripcion))
                                {
                                    ((LabelOfv)control).Text = prop.Descripcion;
                                    continue;
                                }
                            }
                            if (control is CheckBoxOfv)
                            {
                                ((CheckBoxOfv)control).Visible = true;
                            }
                            if (control is RequiredValidatorOfv)
                            {
                                ((RequiredValidatorOfv)control).Enabled = prop.Required;
                                continue;
                            }
                            if (control is RangeValidatorOfv)
                            {
                                if (prop.LowerLimit.HasValue && prop.LowerLimit > 0)
                                {
                                    var rval = (RangeValidatorOfv)control;
                                    rval.Enabled = true;
                                    rval.MinimumValue = prop.LowerLimit.ToString();
                                }

                                if (prop.UpperLimit.HasValue && prop.UpperLimit > 0)
                                {
                                    var rval = (RangeValidatorOfv)control;
                                    rval.Enabled = true;
                                    rval.MaximumValue = prop.UpperLimit.Value.ToString("#####");
                                }
                                continue;
                            }
                        }
                    }
                }
                finally
                {
                    RenderizarControles(control.Controls);
                }
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda todos los objetos del formulario relacionados al registro
        /// </summary>
        protected void GuardarObjetosRegistroPer()
        {
            //Objetos de la transaccion
            var dbOfv = new OFV.CamaraWebsiteEntities();
            var repRegistros = new EF.Repository<OFV.Registros, OFV.CamaraWebsiteEntities>(dbOfv);
            var repPersona = new EF.Repository<OFV.Personas, OFV.CamaraWebsiteEntities>(dbOfv);
            var repRegistrosActividades = new EF.Repository<OFV.RegistrosActividades, OFV.CamaraWebsiteEntities>(dbOfv);
            var repProductos = new EF.Repository<OFV.Productos, OFV.CamaraWebsiteEntities>(dbOfv);
            var repRefBancarias = new EF.Repository<OFV.ReferenciasBancarias, OFV.CamaraWebsiteEntities>(dbOfv);
            var repRefComerciales = new EF.Repository<OFV.ReferenciasComerciales, OFV.CamaraWebsiteEntities>(dbOfv);
            var repSocios = new EF.Repository<OFV.Socios, OFV.CamaraWebsiteEntities>(dbOfv);
            var repTransacciones = new EF.Repository<OFV.Transacciones, OFV.CamaraWebsiteEntities>(dbOfv);
            var repPersonas = new EF.Repository<OFV.Personas, OFV.CamaraWebsiteEntities>(dbOfv);

            using (var tnx = repRegistros.BeginTransaction())
            {
                try
                {
                    this.RegistroNuevo.GestorUsername = HttpContext.Current.Profile.UserName.ToLower();
                    this.RegistroNuevo.FechaSolicitud = DateTime.Now;

                    if (this.RegistroNuevo.FechaInicioOperacion == DateTime.MinValue)
                        this.RegistroNuevo.FechaInicioOperacion = null;

                    //Objetos que definen la sociedad
                    this.RegistroNuevo.EntidadActiva = true;

                    this.PersonasRegistroNuevo.RegistroId = this.RegistroNuevo.RegistroId;

                    //Transacciones
                    if (this.RegistroNuevo.EsNuevoRegistro)
                    {
                        var montoCapitalSocial = this.RegistroNuevo.CapitalSocial.Value2();
                        bool tieneCapSoc = montoCapitalSocial != 0 ? true : false;
                        var servicio = ServiciosDefault.Servicios.FirstOrDefault(
                            a => a.TipoSociedadId == 7
                                 && a.TieneCapitalSocial == tieneCapSoc);
                        var servicioId = 421;


                        var transConstitucion = new OFV.Transacciones
                        {
                            Fecha = DateTime.Now,
                            NombreContacto = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                            RegistroId = this.RegistroNuevo.RegistroId,
                            ModificacionCapital = 0m,
                            CapitalSocial = this.RegistroNuevo.CapitalSocial,
                            TipoSociedadId = 7,
                            RNCSolicitante = this.PersonasRegistroNuevo.Rnc,
                            ServicioId = servicioId,
                            UserName = User.Identity.Name.ToLower(),
                            CamaraId = this.CamaraId,
                            EstatusTransId = Helper.EstatusTransIdNuevo,
                            Solicitante = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                            FechaReciboDGII =
                                                            this.ReciboDgii.FechaReciboDGII == DateTime.MinValue
                                                                ? null
                                                                : this.ReciboDgii.FechaReciboDGII,
                            MontoDGII = this.ReciboDgii.MontoDGII,
                            NoReciboDGII = this.ReciboDgii.NoReciboDGII,
                            TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono,
                            FechaAsamblea = null,
                            FaxContacto = this.RegistroNuevo.DireccionFax,
                            NombreSocialPersona = this.PersonasRegistroNuevo.NombreCompleto

                        };

                        //Ingresando la solicitud de inclusion
                        servicio = ServiciosDefault.Servicios.Where(srv => srv.TipoSociedadId == 7).FirstOrDefault();
                        if (servicio != null)
                            servicioId = servicio.SolicitudInclusionId;

                        var transSolicitudInclusion = new OFV.Transacciones()
                        {
                            Fecha = DateTime.Now,
                            NombreContacto = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                            RegistroId = this.RegistroNuevo.RegistroId,
                            ModificacionCapital = 0m,
                            CapitalSocial = this.RegistroNuevo.CapitalSocial,
                            TipoSociedadId =7,
                            RNCSolicitante = this.PersonasRegistroNuevo.Rnc,
                            ServicioId = servicioId,
                            UserName = User.Identity.Name.ToLower(),
                            CamaraId = this.CamaraId,
                            EstatusTransId = Helper.EstatusTransIdNuevo,
                            FechaReciboDGII =
                                                                  this.ReciboDgii.FechaReciboDGII == DateTime.MinValue
                                                                      ? null
                                                                      : this.ReciboDgii.FechaReciboDGII,
                            MontoDGII = this.ReciboDgii.MontoDGII,
                            NoReciboDGII = this.ReciboDgii.NoReciboDGII,
                            Solicitante = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                            TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono,
                            FechaAsamblea =
                                                                  this.SociedadRegistroNuevo.FechaAsamblea ==
                                                                  DateTime.MinValue
                                                                      ? null
                                                                      : this.SociedadRegistroNuevo.FechaAsamblea,
                            FaxContacto = this.RegistroNuevo.DireccionFax,
                            NombreSocialPersona = this.PersonasRegistroNuevo.NombreCompleto
                        };

                        transConstitucion.SubTransacciones.Add(transSolicitudInclusion);
                        this.TransaccionesEnRegistro.Add(transConstitucion);

                        //Almaceno el index de la transaccion que se imprimira el registro mercantil
                        this.TransaccionIdIndex = this.TransaccionesEnRegistro.IndexOf(transConstitucion);
                    }
                    else if (this.RegistroNuevo.EsRenovacion)
                    {
                        OFV.Transacciones transRenovacion = null;
                        GuardarRenovacionPer(ref transRenovacion);

                        int tipoSocId;
                        int.TryParse(TipoSocIdQuery, out tipoSocId);

                        if (!TransaccionesValidator.ExisteTransaccionActivaMejora(this.CamaraId, this.ServicioId, transRenovacion.NumeroRegistro, Helper.IdEstatusTransaccionesDuplicar, tipoSocId))
                            this.TransaccionesEnRegistro.Add(transRenovacion);
                        else
                        {
                            ErrorMessage = "Ya existe una solicitud de este servicio.  Verifique el historico de transacciones.";
                            tnx.Rollback();
                            LimpiarGeneratedId();
                            return;
                        }
                    }
                    else
                    {
                        OFV.Transacciones transRenovacion = null;

                        //Si toca renovacion, se calcula
                        if (ValidarRenovacionNecesaria())
                            GuardarRenovacionPer(ref transRenovacion);

                        var servicioId = 421;

                        int tipoSocId;
                        int.TryParse(TipoSocIdQuery, out tipoSocId);
                        if (!TransaccionesValidator.ExisteTransaccionActivaMejora(this.CamaraId, servicioId, this.RegistroNuevo.RegistroMercantil, Helper.EstatusTransaccionCerrados, 7))
                        {
                            var transAdecuacion = new OFV.Transacciones
                            {
                                Fecha = DateTime.Now,
                                RegistroId = this.RegistroNuevo.RegistroId,
                                ModificacionCapital = 0,
                                CapitalSocial = this.RegistroNuevo.CapitalSocial,
                                RNCSolicitante = this.PersonasRegistroNuevo.Rnc,
                                NombreContacto = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                                TipoSociedadId = 7,
                                ServicioId = servicioId,
                                UserName = User.Identity.Name.ToLower(),
                                CamaraId = this.CamaraId,
                                EstatusTransId = Helper.EstatusTransIdNuevo,
                                NumeroRegistro = this.RegistroNuevo.RegistroMercantil,
                                Solicitante = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                                TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono,
                                FechaAsamblea = this.RegistroNuevo.FechaAsamblea1 == DateTime.MinValue ? null : this.RegistroNuevo.FechaAsamblea1,
                                FaxContacto = this.RegistroNuevo.DireccionFax,
                                NombreSocialPersona = this.PersonasRegistroNuevo.PrimerNombre + " " + this.PersonasRegistroNuevo.SegundoApellido + " " + this.PersonasRegistroNuevo.PrimerApellido
                                    + " " + this.PersonasRegistroNuevo.SegundoApellido
                            };
                            this.TransaccionesEnRegistro.Add(transAdecuacion);

                            if (transRenovacion != null)
                                transAdecuacion.SubTransacciones.Add(transRenovacion);

                            //Almaceno el index de la transaccion que se imprimira el registro mercantil
                            this.TransaccionIdIndex = this.TransaccionesEnRegistro.IndexOf(transAdecuacion);
                        }
                        else
                        {
                            ErrorMessage = "Ya existe una solicitud de este servicio.  Verifique el historico de transacciones.";
                            tnx.Rollback();
                            LimpiarGeneratedId();
                            return;
                        }
                    }

                    foreach (var transacion in this.TransaccionesEnRegistro)
                        repTransacciones.Add(transacion);

                    repTransacciones.Save();

                    tnx.Commit();

                    if (!DefaultQueryString.Contains("nSolicitud="))
                        DefaultQueryString = String.Format("nSolicitud={0}", this.TransaccionesEnRegistro[0].TransaccionId);
                    if (!DefaultQueryString.Contains("TipoSociedadId="))
                        DefaultQueryString = String.Format("TipoSociedadId={0}", 7);
                    //TODO pERSONA FISICA QUITAR COMENTARIO EN CASO DE QUE SE GUARDEN MULTIPLES TRANSACCIONES EN RENOVACION DESDE DETALLE DE EMPRESA
                    this.TransaccionesEnRegistro.Clear();
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    tnx.Rollback();
                    LimpiarGeneratedId();
                    throw;
                }
            }

            //Envio a pantalla de confirmacion
            Response.Redirect("/Empresas/RevisionDocumentos.aspx" + DefaultQueryString);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.GuardarObjetosRegistro()'
        protected void GuardarObjetosRegistro()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.GuardarObjetosRegistro()'
        {
            //Objetos de la transaccion
            var dbOfv = new OFV.CamaraWebsiteEntities();
            var repRegistros = new EF.Repository<OFV.Registros, OFV.CamaraWebsiteEntities>(dbOfv);
            var repSociedades = new EF.Repository<OFV.Sociedades, OFV.CamaraWebsiteEntities>(dbOfv);
            var repRegistrosActividades = new EF.Repository<OFV.RegistrosActividades, OFV.CamaraWebsiteEntities>(dbOfv);
            var repProductos = new EF.Repository<OFV.Productos, OFV.CamaraWebsiteEntities>(dbOfv);
            var repRefBancarias = new EF.Repository<OFV.ReferenciasBancarias, OFV.CamaraWebsiteEntities>(dbOfv);
            var repRefComerciales = new EF.Repository<OFV.ReferenciasComerciales, OFV.CamaraWebsiteEntities>(dbOfv);
            var repSucursales = new EF.Repository<OFV.Sucursales, OFV.CamaraWebsiteEntities>(dbOfv);
            var repSocios = new EF.Repository<OFV.Socios, OFV.CamaraWebsiteEntities>(dbOfv);
            var repTransacciones = new EF.Repository<OFV.Transacciones, OFV.CamaraWebsiteEntities>(dbOfv);
            var repPersonas = new EF.Repository<OFV.Personas, OFV.CamaraWebsiteEntities>(dbOfv);

            using (var tnx = repRegistros.BeginTransaction())
            {
                try
                {
                    this.RegistroNuevo.GestorUsername = HttpContext.Current.Profile.UserName.ToLower();
                    this.RegistroNuevo.FechaSolicitud = DateTime.Now;

                    if (this.RegistroNuevo.FechaInicioOperacion == DateTime.MinValue)
                        this.RegistroNuevo.FechaInicioOperacion = null;

                    //Objetos que definen la sociedad
                    this.RegistroNuevo.EntidadActiva = true;
                    repRegistros.Add(this.RegistroNuevo);
                    repRegistros.Save();
                    this.SociedadRegistroNuevo.RegistroId = this.RegistroNuevo.RegistroId;

                    repSociedades.Add(this.SociedadRegistroNuevo);
                    repSociedades.Save();

                    //Grabando Actividades
                    foreach (var actividad in this.ActividadesEnRegistro)
                    {
                        actividad.RegistroId = this.RegistroNuevo.RegistroId;
                        actividad.FechaModificacion = DateTime.Now;
                        repRegistrosActividades.Add(actividad);
                    }
                    repRegistrosActividades.Save();

                    //Guardando Productos
                    foreach (var producto in this.ProductosEnRegistro)
                    {
                        if (producto == null) continue;

                        producto.RegistroId = this.RegistroNuevo.RegistroId;
                        producto.FechaModificacion = DateTime.Now;
                        repProductos.Add(producto);
                    }
                    repProductos.Save();

                    //Grabado Referencias Bancarias
                    foreach (var refBancaria in this.ReferenciasBancariasRegistro)
                    {
                        if (refBancaria == null) continue;

                        refBancaria.RegistroId = this.RegistroNuevo.RegistroId;
                        refBancaria.FechaModificacion = DateTime.Now;
                        repRefBancarias.Add(refBancaria);
                    }
                    repRefBancarias.Save();

                    //Grabando Referencias Comerciales
                    foreach (var refComercial in this.ReferenciasComercialesRegistro)
                    {
                        if (refComercial == null) continue;

                        refComercial.RegistroId = this.RegistroNuevo.RegistroId;
                        refComercial.FechaModificacion = DateTime.Now;
                        refComercial.TipoReferencia = "C";
                        repRefComerciales.Add(refComercial);
                    }
                    repRefComerciales.Save();

                    //Grabando Sucursales
                    foreach (var sucursal in SucursalesRegistro)
                    {
                        sucursal.SociedadId = this.SociedadRegistroNuevo.SociedadId;
                        sucursal.FechaModificacion = DateTime.Now;
                        repSucursales.Add(sucursal);
                    }
                    repSucursales.Save();

                    //Grabando Socios Representados
                    var sociosRepresentados = this.SociosEnRegistro.Where(a => a.RepresentanteId > 0).ToList();
                    foreach (var socios in sociosRepresentados)
                    {
                        var socios1 = socios;
                        socios1.RegistroId = this.RegistroNuevo.RegistroId;

                        var representantes1 =
                            this.Representantes.FirstOrDefault(a => a.PersonaId == socios1.RepresentanteId);

                        var repFromDb = repPersonas.Session.Personas.FirstOrDefault(
                            a =>
                            a.Documento == representantes1.Documento &&
                            a.TipoDocumento == representantes1.TipoDocumento);

                        if (repFromDb != null)
                            repFromDb.Socios.Add(socios1);
                        else
                        {
                            representantes1.Socios.Add(socios1);
                            repPersonas.Add(representantes1);
                        }
                    }

                    repPersonas.Save();

                    foreach (var socio in this.SociosEnRegistro.Where(socio => socio.RepresentanteId == 0))
                    { 
                        socio.RegistroId = this.RegistroNuevo.RegistroId;
                        socio.RegistroMercantil = this.RegistroNuevo.RegistroMercantil.HasValue ? this.RegistroNuevo.RegistroMercantil.Value.ToString() : String.Empty;
                        socio.RepresentanteId = null;
                        socio.Orden += 1;
                        repSocios.Add(socio);
                    }
                    repSocios.Save();

                    //Transacciones
                    if (this.RegistroNuevo.EsNuevoRegistro)
                    {
                        var montoCapitalSocial = this.RegistroNuevo.CapitalSocial.Value2();
                        var servicio = ServiciosDefault.Servicios.FirstOrDefault(
                            a => a.TipoSociedadId == this.SociedadRegistroNuevo.TipoSociedadId
                                 && a.TieneCapitalSocial == this.SociedadRegistroNuevo.TieneCapitalSocial);
                        var servicioId = servicio.ServicioConstitucionId;

                        var transConstitucion = new OFV.Transacciones
                        {
                            Fecha = DateTime.Now,
                            NombreContacto = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                            RegistroId = this.RegistroNuevo.RegistroId,
                            ModificacionCapital = 0m,
                            CapitalSocial = this.RegistroNuevo.CapitalSocial,
                            TipoSociedadId =
                                                            this.SociedadRegistroNuevo.TipoSociedadId.Value2(),
                            RNCSolicitante = this.SociedadRegistroNuevo.Rnc,
                            ServicioId = servicioId,
                            UserName = User.Identity.Name.ToLower(),
                            CamaraId = this.CamaraId,
                            EstatusTransId = Helper.EstatusTransIdNuevo,
                            Solicitante = this.RegistroNuevo.NombreSolicitante,
                            FechaReciboDGII =
                                                            this.ReciboDgii.FechaReciboDGII == DateTime.MinValue
                                                                ? null
                                                                : this.ReciboDgii.FechaReciboDGII,
                            MontoDGII = this.ReciboDgii.MontoDGII,
                            NoReciboDGII = this.ReciboDgii.NoReciboDGII,
                            TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono,
                            FechaAsamblea =
                                                            this.SociedadRegistroNuevo.FechaAsamblea ==
                                                            DateTime.MinValue
                                                                ? null
                                                                : this.SociedadRegistroNuevo.FechaAsamblea,
                            FaxContacto = this.RegistroNuevo.DireccionFax,
                            NombreSocialPersona = this.SociedadRegistroNuevo.NombreSocial

                        };

                        //Ingresando la solicitud de inclusion
                        servicio = ServiciosDefault.Servicios.Where(srv => srv.TipoSociedadId == this.TipoSociedadId).FirstOrDefault();
                        if (servicio != null)
                            servicioId = servicio.SolicitudInclusionId;

                        var transSolicitudInclusion = new OFV.Transacciones()
                        {
                            Fecha = DateTime.Now,
                            NombreContacto = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                            RegistroId = this.RegistroNuevo.RegistroId,
                            ModificacionCapital = 0m,
                            CapitalSocial = this.RegistroNuevo.CapitalSocial,
                            TipoSociedadId =
                                                                  this.SociedadRegistroNuevo.TipoSociedadId.Value2(),
                            RNCSolicitante = this.SociedadRegistroNuevo.Rnc,
                            ServicioId = servicioId,
                            UserName = User.Identity.Name.ToLower(),
                            CamaraId = this.CamaraId,
                            EstatusTransId = Helper.EstatusTransIdNuevo,
                            FechaReciboDGII =
                                                                  this.ReciboDgii.FechaReciboDGII == DateTime.MinValue
                                                                      ? null
                                                                      : this.ReciboDgii.FechaReciboDGII,
                            MontoDGII = this.ReciboDgii.MontoDGII,
                            NoReciboDGII = this.ReciboDgii.NoReciboDGII,
                            Solicitante = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                            TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono,
                            FechaAsamblea =
                                                                  this.SociedadRegistroNuevo.FechaAsamblea ==
                                                                  DateTime.MinValue
                                                                      ? null
                                                                      : this.SociedadRegistroNuevo.FechaAsamblea,
                            FaxContacto = this.RegistroNuevo.DireccionFax,
                            NombreSocialPersona =
                                                                  this.SociedadRegistroNuevo.NombreSocial
                        };

                        transConstitucion.SubTransacciones.Add(transSolicitudInclusion);
                        this.TransaccionesEnRegistro.Add(transConstitucion);

                        //Almaceno el index de la transaccion que se imprimira el registro mercantil
                        this.TransaccionIdIndex = this.TransaccionesEnRegistro.IndexOf(transConstitucion);
                    }
                    else if (this.RegistroNuevo.EsRenovacion)
                    {
                        OFV.Transacciones transRenovacion = null;
                        GuardarRenovacion(ref transRenovacion);

                        int tipoSocId;
                        int.TryParse(TipoSocIdQuery, out tipoSocId);

                        if (!TransaccionesValidator.ExisteTransaccionActivaMejora(this.CamaraId, this.ServicioId, transRenovacion.NumeroRegistro, Helper.IdEstatusTransaccionesDuplicar, tipoSocId))
                            this.TransaccionesEnRegistro.Add(transRenovacion);
                        else
                        {
                            ErrorMessage = "Ya existe una solicitud de este servicio.  Verifique el historico de transacciones.";
                            tnx.Rollback();
                            LimpiarGeneratedId();
                            return;
                        }
                    }
                    else
                    {
                        OFV.Transacciones transRenovacion = null;

                        //Si toca renovacion, se calcula
                        if (ValidarRenovacionNecesaria())
                            GuardarRenovacion(ref transRenovacion);

                        var servicioId = ServiciosDefault.Servicios.FirstOrDefault(a => a.TipoSociedadId == this.SociedadRegistroNuevo.TipoSociedadId).ServicioAdecuacionId;

                        int tipoSocId;
                        int.TryParse(TipoSocIdQuery, out tipoSocId);
                        if (!TransaccionesValidator.ExisteTransaccionActivaMejora(this.CamaraId, servicioId, this.RegistroNuevo.RegistroMercantil, Helper.EstatusTransaccionCerrados, tipoSocId))
                        {
                            var transAdecuacion = new OFV.Transacciones
                            {
                                Fecha = DateTime.Now,
                                RegistroId = this.RegistroNuevo.RegistroId,
                                ModificacionCapital = 0,
                                CapitalSocial = this.RegistroNuevo.CapitalSocial,
                                RNCSolicitante = this.SociedadRegistroNuevo.Rnc,
                                NombreContacto = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                                TipoSociedadId = this.SociedadRegistroNuevo.TipoSociedadId.Value2(),
                                ServicioId = servicioId,
                                UserName = User.Identity.Name.ToLower(),
                                CamaraId = this.CamaraId,
                                EstatusTransId = Helper.EstatusTransIdNuevo,
                                NumeroRegistro = this.RegistroNuevo.RegistroMercantil,
                                Solicitante = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                                TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono,
                                FechaAsamblea = this.SociedadRegistroNuevo.FechaAsamblea == DateTime.MinValue ? null : this.SociedadRegistroNuevo.FechaAsamblea,
                                FaxContacto = this.RegistroNuevo.DireccionFax,
                                NombreSocialPersona = this.SociedadRegistroNuevo.NombreSocial
                            };
                            this.TransaccionesEnRegistro.Add(transAdecuacion);

                            if (transRenovacion != null)
                                transAdecuacion.SubTransacciones.Add(transRenovacion);

                            //Almaceno el index de la transaccion que se imprimira el registro mercantil
                            this.TransaccionIdIndex = this.TransaccionesEnRegistro.IndexOf(transAdecuacion);
                        }
                        else
                        {
                            ErrorMessage = "Ya existe una solicitud de este servicio.  Verifique el historico de transacciones.";
                            tnx.Rollback();
                            LimpiarGeneratedId();
                            return;
                        }
                    }

                    foreach (var transacion in this.TransaccionesEnRegistro)
                        repTransacciones.Add(transacion);

                    repTransacciones.Save();

                    //2021-11-01:
                    if (this.TransaccionesEnRegistro != null)
                    {
                        this.RegistroNuevo.TransaccionId = this.TransaccionesEnRegistro[0].TransaccionId;
                        repRegistros.Save();
                    }


                    tnx.Commit();

                    if (!DefaultQueryString.Contains("nSolicitud="))
                        DefaultQueryString = String.Format("nSolicitud={0}", this.TransaccionesEnRegistro[0].TransaccionId);
                    else if (!DefaultQueryString.Contains("TipoSociedadId="))
                        DefaultQueryString = String.Format("TipoSociedadId={0}", this.TipoSociedadId);
                    else if (!DefaultQueryString.Contains("TipoSociedadId=") && !DefaultQueryString.Contains("nSolicitud="))
                        DefaultQueryString = String.Format("nSolicitud={0}&TipoSociedadId={1}", this.TransaccionesEnRegistro[0].TransaccionId, this.TipoSociedadId);

                    //TODO: LIMPIAR VARIABLE RENOVACION PERSONA FISICA
                    this.TransaccionesEnRegistro.Clear();
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    tnx.Rollback();
                    LimpiarGeneratedId();
                    throw;
                }
            }


            //Envio a pantalla de confirmacion
            Response.Redirect("/Operaciones/Shared/FormaEntrega.aspx" + DefaultQueryString);
        }

        /// <summary>
        /// Resetea el ID generado durante una transaccion que hizo RollBack
        /// </summary>
        private void LimpiarGeneratedId()
        {
            if (this.RegistroNuevo.EsNuevoRegistro)
                this.RegistroNuevo.RegistroId = 0;

            this.SociedadRegistroNuevo.RegistroId = this.RegistroNuevo.RegistroId;

            this.TransaccionesEnRegistro = new List<OFV.Transacciones>();
            this.TransaccionIdIndex = 0;
        }

        private void GuardarRenovacion(ref OFV.Transacciones transRenovacion)
        {
            var montoCapitalSocial = this.RegistroNuevo.CapitalSocial.Value2();

            var costoRenovacionNuevo = ObtenerCostoTransaccion(montoCapitalSocial, TipoTransaccionNm.Renovacion);
            var capAutorizado = this.RegistroSistemaActual.CapitalAutorizado.HasValue ? this.RegistroSistemaActual.CapitalAutorizado.Value : 0M;
            var costoRenovacionActual = ObtenerCostoTransaccion(capAutorizado, TipoTransaccionNm.Renovacion);
            var montoRenovacion = costoRenovacionNuevo - costoRenovacionActual;

            this.ServicioId = this.ServicioId == 0
                                 ? ServiciosDefault.Servicios.FirstOrDefault(
                                     a => a.TipoSociedadId == this.SociedadRegistroNuevo.TipoSociedadId).
                                       ServicioModificacionId
                                 : this.ServicioId;

            transRenovacion = new OFV.Transacciones
            {
                Fecha = DateTime.Now,
                RegistroId = RegistroSistemaActual.RegistroId,
                MontoDGII = montoRenovacion,
                ModificacionCapital = montoCapitalSocial,
                CapitalSocial = montoCapitalSocial,
                RNCSolicitante = this.SociedadRegistroNuevo.Rnc,
                NombreContacto = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                TipoSociedadId = this.SociedadRegistroNuevo.TipoSociedadId.Value2(),
                ServicioId = this.ServicioId,
                UserName = User.Identity.Name.ToLower(),
                CamaraId = this.CamaraId,
                EstatusTransId = 1,
                NumeroRegistro = this.RegistroNuevo.RegistroMercantil,
                Solicitante = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono,
                FechaAsamblea = this.SociedadRegistroNuevo.FechaAsamblea == DateTime.MinValue ? null : this.SociedadRegistroNuevo.FechaAsamblea,
                FaxContacto = this.RegistroNuevo.DireccionFax,
                NombreSocialPersona = this.SociedadRegistroNuevo.NombreSocial
            };
        }
        private void GuardarRenovacionPer(ref OFV.Transacciones transRenovacion)
        {
            var montoCapitalSocial = this.RegistroNuevo.CapitalSocial.Value2();

            var costoRenovacionNuevo = ObtenerCostoTransaccion(montoCapitalSocial, TipoTransaccionNm.Renovacion);
            var capAutorizado = this.RegistroSistemaActual.CapitalAutorizado.HasValue ? this.RegistroSistemaActual.CapitalAutorizado.Value : 0M;
            var costoRenovacionActual = ObtenerCostoTransaccion(capAutorizado, TipoTransaccionNm.Renovacion);
            var montoRenovacion = costoRenovacionNuevo - costoRenovacionActual;

            this.ServicioId = 421;

            transRenovacion = new OFV.Transacciones
            {
                Fecha = DateTime.Now,
                RegistroId = RegistroSistemaActual.RegistroId,
                MontoDGII = montoRenovacion,
                ModificacionCapital = montoCapitalSocial,
                CapitalSocial = montoCapitalSocial,
                RNCSolicitante = this.PersonasRegistroNuevo.Rnc,
                NombreContacto = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                TipoSociedadId = 7,
                ServicioId = this.ServicioId,
                UserName = User.Identity.Name.ToLower(),
                CamaraId = this.CamaraId,
                EstatusTransId = 40,
                NumeroRegistro = this.RegistroNuevo.RegistroMercantil,
                Solicitante = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono,
                FechaAsamblea = this.SociedadRegistroNuevo.FechaAsamblea == DateTime.MinValue ? null : this.SociedadRegistroNuevo.FechaAsamblea,
                FaxContacto = this.RegistroNuevo.DireccionFax,
                NombreSocialPersona = this.PersonasRegistroNuevo.PrimerNombre + " " + this.PersonasRegistroNuevo.SegundoApellido + " " + this.PersonasRegistroNuevo.PrimerApellido
                    + " " + this.PersonasRegistroNuevo.SegundoApellido
            };
        }

        /// <summary>
        /// Validacion: Determina si el usuario selecciono por lo menos un item en un control de lista
        /// </summary>
        protected static bool SeleccionoItemsEnListado(ListControl cbList)
        {
            bool seleccionoActividades = false;
            for (int i = 0; i < cbList.Items.Count; i++)
            {
                if (cbList.Items[i].Selected)
                {
                    seleccionoActividades = true;
                    break;
                }
            }
            return seleccionoActividades;
        }

        /// <summary>
        /// Verifrica si el registro actual esta vencido
        /// </summary>
        /// <returns></returns>
        protected bool ValidarRenovacionNecesaria()
        {
            if (!this.RegistroNuevo.EsNuevoRegistro)
                return this.RegistroSistemaActual.FechaVencimiento == null || RegistroSistemaActual.FechaVencimiento < DateTime.Today;
            return false;
        }

        /// <summary>
        /// Retorna el costo por transaccion
        /// </summary>
        /// <param name="capitalSocial"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        protected decimal ObtenerCostoTransaccion(decimal? capitalSocial, TipoTransaccionNm tipo)
        {
            if (!capitalSocial.HasValue)
                return -1;

            Decimal montoTransaccion = 0.0m;
            //Oficina.Tarifas tarifa;

            switch (tipo)
            {
                case TipoTransaccionNm.Renovacion:

                    var tarifa = new SRM.CamaraSRMEntities(EF.Helpers.GetCamaraConnString(this.CamaraId)).Tarifas.Where(a => a.MontoInicial >= capitalSocial.Value && a.MontoFinal <= capitalSocial.Value).FirstOrDefault();
                    montoTransaccion = tarifa != null ? tarifa.CostoRenovacion : montoTransaccion;

                    break;
                case TipoTransaccionNm.Adecuacion:
                    montoTransaccion = Helper.CostoAdecuacion;
                    break;
                case TipoTransaccionNm.Constitucion:
                    tarifa = new SRM.CamaraSRMEntities(EF.Helpers.GetCamaraConnString(this.CamaraId)).Tarifas.Where(a => a.MontoInicial >= capitalSocial.Value && a.MontoFinal <= capitalSocial.Value).FirstOrDefault();
                    montoTransaccion = tarifa != null ? tarifa.CostoContitucion : montoTransaccion;
                    break;
            }
            return montoTransaccion;
        }

        /// <summary>
        /// Limpia todos los objetos en sesion. Esto evita que se llene el formulario 2 veces 
        /// </summary>
        protected void LimpiarObjetosEnSesion()
        {
            RegistroSistemaActual = null;
            RegistroNuevo = null;
            ActividadesEnRegistro = null;
            ProductosEnRegistro = null;
            SociedadRegistroNuevo = null;
            SociosEnRegistro = null;
            SociosAdminEnRegistro = null;
            SociosAutorizadosFirma = null;
            ReferenciasBancariasRegistro = null;
            ReferenciasComercialesRegistro = null;
            SucursalesRegistro = null;
            TransaccionesEnRegistro = null;
            Session["bIsFormularionConfirmacion"] = null;
            Session["TransaccionIdIndex"] = null;
            Representantes = null;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.LoadSocios(CamaraSRMEntities, int)'
        protected void LoadSocios(SRM.CamaraSRMEntities dbSrm, int registroId)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.LoadSocios(CamaraSRMEntities, int)'
        {
            var socios = dbSrm.RegistrosSocios.Where(a => a.RegistroId == registroId).ToList();

            this.SociosEnRegistro = new List<OFV.Socios>();

            foreach (var item in socios)
            {
                var direcciones = dbSrm.Direcciones.Where(a => a.DireccionId == item.DireccionId).FirstOrDefault();

                SRM.Personas persona = null;
                SRM.Sociedades sociedad = null;

                switch (item.TipoSocio)
                {
                    case "P":
                        persona = dbSrm.Personas.FirstOrDefault(a => a.PersonaId == item.SocioId);
                        break;
                    case "S":
                        sociedad = dbSrm.Sociedades.FirstOrDefault(a => a.SociedadId == item.SocioId);
                        break;
                }

                var socio = new OFV.Socios
                {
                    RegistroId = item.RegistroId,
                    CargoId = item.CargoId,
                    TipoRelacion = item.TipoRelacion,
                    TipoSocio = item.TipoSocio,
                    DireccionCalle = direcciones.Calle,
                    DireccionCiudadId = direcciones.CiudadId,
                    DireccionSectorId = direcciones.SectorId,
                    DireccionNumero = direcciones.Numero,
                    NacionalidadId = direcciones.PaisId,
                    RegistroMercantil = this.RegistroNuevo.RegistroMercantil.HasValue ? this.RegistroNuevo.RegistroMercantil.ToString() : String.Empty,
                    Orden = item.Orden.HasValue ? item.Orden.Value : 0,
                    DireccionApartadoPostal = direcciones.ApartadoPostal,
                    Id = item.ID
                };

                if (persona != null)
                {
                    socio.PersonaPrimerNombre = persona.PrimerNombre;
                    socio.PersonaSegundoNombre = persona.SegundoNombre;
                    socio.PersonaPrimerApellido = persona.PrimerApellido;
                    socio.PersonaSegundoApellido = persona.SegundoApellido;
                    socio.Documento = persona.Documento;
                    socio.TipoDocumento = persona.TipoDocumento;
                    socio.PersonaEstadoCivil = persona.EstadoCivil;
                }

                if (sociedad != null)
                {
                    socio.SociedadNombreSocial = sociedad.NombreSocial;
                    socio.TipoDocumento = "R";
                    socio.Documento = sociedad.Rnc;
                }

                this.SociosEnRegistro.Add(socio);
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.LoadProductos(Registros)'
        protected void LoadProductos(SRM.Registros regActual)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.LoadProductos(Registros)'
        {
            //Creando Productos
            this.ProductosEnRegistro = new List<OFV.Productos>();

            foreach (var producto in regActual.Productos)
            {
                var newProducto = new OFV.Productos
                {
                    Descripcion = producto.Descripcion,
                    SistemaArmonizadoId = producto.SistemaArmonizadoId
                };

                this.ProductosEnRegistro.Add(newProducto);
            }

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.LoadActividades(Registros)'
        protected void LoadActividades(SRM.Registros regActual)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.LoadActividades(Registros)'
        {
            this.ActividadesEnRegistro = new List<OFV.RegistrosActividades>();

            foreach (var actividad in regActual.RegistrosActividades)
            {
                var newActividad = new OFV.RegistrosActividades
                {
                    AtividadId = actividad.AtividadId,
                    TipoActividadId = actividad.TipoActividadId
                };

                this.ActividadesEnRegistro.Add(newActividad);
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.LoadReferenciasComerciales(Registros)'
        protected void LoadReferenciasComerciales(SRM.Registros regActual)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.LoadReferenciasComerciales(Registros)'
        {
            this.ReferenciasComercialesRegistro = new List<OFV.ReferenciasComerciales>();

            foreach (var actividad in regActual.ReferenciasComerciales)
            {
                var newActividad = new OFV.ReferenciasComerciales
                {
                    Descripcion = actividad.Descripcion,
                    TipoReferencia = actividad.TipoReferencia
                };

                this.ReferenciasComercialesRegistro.Add(newActividad);
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.LoadReferenciasBancarias(Registros)'
        protected void LoadReferenciasBancarias(SRM.Registros regActual)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.LoadReferenciasBancarias(Registros)'
        {
            this.ReferenciasBancariasRegistro = new List<OFV.ReferenciasBancarias>();
            var banRef = regActual.ReferenciasBancarias.Select(a => a.BancoId);
            var dbComun = new ComunEF.CamaraComunEntities();
            var bancos = dbComun.Bancos.Where(a => banRef.Contains(a.BancoId)).ToList();

            foreach (var actividad in regActual.ReferenciasBancarias)
            {
                var newActividad = new OFV.ReferenciasBancarias
                {
                    BancoId = actividad.BancoId,
                    NombreBanco =
                                               bancos.FirstOrDefault(a => a.BancoId == actividad.BancoId).Descripcion,
                };
                this.ReferenciasBancariasRegistro.Add(newActividad);
            }

        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.LoadRegistroDataPer(CamaraSRMEntities, Registros)'
        protected void LoadRegistroDataPer(SRM.CamaraSRMEntities dbSRM, SRM.Registros regActual)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.LoadRegistroDataPer(CamaraSRMEntities, Registros)'
        {
            if (regActual != null)
            {
                //Sociedad relacionada al registro actual
                var SocAdecuada = regActual.PersonasRegistros.FirstOrDefault();

                //Objeto con el registro actual
                this.RegistroSistemaActual = regActual;

                if (regActual.Direcciones == null)
                    regActual.Direcciones = dbSRM.Direcciones.CreateObject();

                //Crear Informacion de Registro Existente
                this.RegistroNuevo = new OFV.Registros()
                {
                    RegistroMercantil = SocAdecuada.NumeroRegistro,
                    EsNuevoRegistro = false,
                    FechaEmision = regActual.FechaEmision == DateTime.MinValue ? null : regActual.FechaEmision,
                    Activos = regActual.Activos,
                    ActividadNegocio = regActual.ActividadNegocio,
                    NombreComercial = regActual.NombreComercial,
                    BienesRaices = regActual.BienesRaices,
                    CapitalAutorizado = regActual.CapitalAutorizado,
                    CapitalPagado = regActual.CapitalPagado,
                    CapitalSocial = regActual.CapitalSocial,
                    EmpleadosFemeninos = regActual.EmpleadosFemeninos,
                    EmpleadosMasculinos = regActual.EmpleadosMasculinos,
                    EmpleadosTotal = regActual.EmpleadosTotal,
                    FechaInicioOperacion = regActual.FechaInicioOperacion == DateTime.MinValue ? null : regActual.FechaInicioOperacion,
                    FechaVencimiento = regActual.FechaVencimiento == DateTime.MinValue ? null : regActual.FechaVencimiento,
                    MarcaFabrica = regActual.MarcaFabrica,
                    RegistroMarcaFabrica = regActual.RegistroMarcaFabrica,
                    NombreOperador = regActual.NombreOperador,
                    NumeroSocios = regActual.NumeroSocios,
                    PatenteInvencion = regActual.PatenteInversion,
                    RegistroPatenteInvencion = regActual.RegistroPatenteInversion,
                    RegistroNombreComercial = regActual.NombreComercial,
                    TotalAcciones = regActual.TotalAcciones,
                    DireccionApartadoPostal = regActual.Direcciones.ApartadoPostal,
                    DireccionCalle = regActual.Direcciones.Calle,
                    DireccionCiudadId = regActual.Direcciones.CiudadId,
                    DireccionEmail = regActual.Direcciones.Email,
                    DireccionExtension = regActual.Direcciones.Extension,
                    DireccionFax = regActual.Direcciones.Fax,
                    DireccionNumero = regActual.Direcciones.Numero,
                    DireccionSectorId = regActual.Direcciones.SectorId,
                    DireccionTelefonoCasa = regActual.Direcciones.TelefonoCasa,
                    DireccionSitioWeb = regActual.Direcciones.SitioWeb,
                    DireccionTelefonoOficina = regActual.Direcciones.TelefonoOficina

                };

                //var personaController = new SRM.PersonaFisicaController();
                //var pr = personaController.ObteneByPersonaIdCamara(PersonaId, CamaraId).FirstOrDefault();
                var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);
                var repDirecciones = new Repository<SRM.ViewDirecciones, SRM.CamaraSRMEntities>(dbSrm);
                var direccion = repDirecciones.SelectByKey(SRM.ViewDirecciones.PropColumns.DireccionId,
                                                                           SocAdecuada.Personas.DireccionId.Value);


                this.PersonasRegistroNuevo = new DataAccess.EF.OficinaVirtual.Personas()
                {
                    DireccionApartadoPostal = direccion.ApartadoPostal,
                    DireccionCalle = direccion.Calle,
                    DireccionCiudadId = direccion.CiudadId,
                    DireccionNumero = direccion.Numero,
                    DireccionSectorId = direccion.SectorId,
                    Documento = SocAdecuada.Personas.Documento,
                    EstadoCivil = SocAdecuada.Personas.EstadoCivil,
                    NacionalidadId = SocAdecuada.Personas.NacionalidadId,
                    PrimerNombre = SocAdecuada.Personas.PrimerNombre,
                    SegundoNombre = SocAdecuada.Personas.SegundoNombre,
                    PrimerApellido = SocAdecuada.Personas.PrimerApellido,
                    SegundoApellido = SocAdecuada.Personas.SegundoApellido,
                    TipoDocumento = SocAdecuada.Personas.TipoDocumento,
                    ProfesionId = SocAdecuada.Personas.ProfesionId,
                    RegistroId = SocAdecuada.RegistroId,
                    Rnc = SocAdecuada.Personas.Rnc,
                    Socios = null
                };

                //Load actividades Data
                LoadActividades(regActual);

                //Load Socios Data
                LoadSocios(dbSRM, regActual.RegistroId);

                //Load Productos
                this.LoadProductos(regActual);

                //Load Referencias Bancarias
                this.LoadReferenciasBancarias(regActual);

                //Load Referencias Comerciales
                this.LoadReferenciasComerciales(regActual);
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.LoadRegistroData(CamaraSRMEntities, Registros)'
        protected void LoadRegistroData(SRM.CamaraSRMEntities dbSRM, SRM.Registros regActual)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.LoadRegistroData(CamaraSRMEntities, Registros)'
        {
            if (regActual != null)
            {
                //Sociedad relacionada al registro actual
                var SocAdecuada = regActual.SociedadesRegistros.FirstOrDefault();

                //Objeto con el registro actual
                this.RegistroSistemaActual = regActual;

                if (regActual.Direcciones == null)
                    regActual.Direcciones = dbSRM.Direcciones.CreateObject();

                //Crear Informacion de Registro Existente
                this.RegistroNuevo = new OFV.Registros()
                {
                    RegistroMercantil = SocAdecuada.NumeroRegistro,
                    EsNuevoRegistro = false,
                    FechaEmision = regActual.FechaEmision == DateTime.MinValue ? null : regActual.FechaEmision,
                    Activos = regActual.Activos,
                    ActividadNegocio = regActual.ActividadNegocio,
                    NombreComercial = regActual.NombreComercial,
                    BienesRaices = regActual.BienesRaices,
                    CapitalAutorizado = regActual.CapitalAutorizado,
                    CapitalPagado = regActual.CapitalPagado,
                    CapitalSocial = regActual.CapitalSocial,
                    EmpleadosFemeninos = regActual.EmpleadosFemeninos,
                    EmpleadosMasculinos = regActual.EmpleadosMasculinos,
                    EmpleadosTotal = regActual.EmpleadosTotal,
                    FechaInicioOperacion = regActual.FechaInicioOperacion == DateTime.MinValue ? null : regActual.FechaInicioOperacion,
                    FechaVencimiento = regActual.FechaVencimiento == DateTime.MinValue ? null : regActual.FechaVencimiento,
                    MarcaFabrica = regActual.MarcaFabrica,
                    RegistroMarcaFabrica = regActual.RegistroMarcaFabrica,
                    NombreOperador = regActual.NombreOperador,
                    NumeroSocios = regActual.NumeroSocios,
                    PatenteInvencion = regActual.PatenteInversion,
                    RegistroPatenteInvencion = regActual.RegistroPatenteInversion,
                    RegistroNombreComercial = regActual.NombreComercial,
                    TotalAcciones = regActual.TotalAcciones,
                    DireccionApartadoPostal = regActual.Direcciones.ApartadoPostal,
                    DireccionCalle = regActual.Direcciones.Calle,
                    DireccionCiudadId = regActual.Direcciones.CiudadId,
                    DireccionEmail = regActual.Direcciones.Email,
                    DireccionExtension = regActual.Direcciones.Extension,
                    DireccionFax = regActual.Direcciones.Fax,
                    DireccionNumero = regActual.Direcciones.Numero,
                    DireccionSectorId = regActual.Direcciones.SectorId,
                    DireccionTelefonoCasa = regActual.Direcciones.TelefonoCasa,
                    DireccionSitioWeb = regActual.Direcciones.SitioWeb,
                    DireccionTelefonoOficina = regActual.Direcciones.TelefonoOficina,
                    CorreoEmpresa = regActual.Direcciones.Email,
                    SrmRegistroId = regActual.RegistroId

                };


                //Crear Informacion de Sociedad
                this.SociedadRegistroNuevo = new DataAccess.EF.OficinaVirtual.Sociedades()
                {
                    Rnc = SocAdecuada.Sociedades.Rnc,
                    NombreSocial = SocAdecuada.Sociedades.NombreSocial,
                    TipoSociedadId = SocAdecuada.Sociedades.TipoSociedadId,
                    TipoEnteReguladoId = SocAdecuada.Sociedades.TipoEnteReguladoId,
                    FechaAsamblea = SocAdecuada.Sociedades.FechaAsamblea == DateTime.MinValue ? null : SocAdecuada.Sociedades.FechaAsamblea,
                    FechaConstitucion = SocAdecuada.Sociedades.FechaConstitucion == DateTime.MinValue ? null : SocAdecuada.Sociedades.FechaConstitucion,
                    DuracionSociedad = SocAdecuada.Sociedades.DuracionSociedad,
                    DuraccionDirectiva = SocAdecuada.Sociedades.DuraccionDirectiva,
                    EsEnteRegulado = SocAdecuada.Sociedades.EsEnteRegulado,
                    EsNacional = SocAdecuada.Sociedades.EsNacional,
                    EstatusId = SocAdecuada.Sociedades.EstatusId,
                    NoResolucion = SocAdecuada.Sociedades.NoResolucion,
                    NombreSiglas = SocAdecuada.Sociedades.NombreSiglas,
                    SiglasConfig = SocAdecuada.Sociedades.SiglasConfig,
                    NacionalidadId = SocAdecuada.Sociedades.NacionalidadId,
                    NumeroNaveIndustrial = SocAdecuada.Sociedades.NumeroNaveIndustrial
                };

                //Crear Informacion de la sucursal.
                foreach (var sucursal in SocAdecuada.Sociedades.Suscursales)
                {
                    var direccion = dbSRM.Direcciones.FirstOrDefault(a => a.DireccionId == sucursal.DireccionId);

                    var newSucursal = new OFV.Sucursales()
                    {
                        Descripcion = sucursal.Descripcion,
                        DireccionApartadoPostal = direccion.ApartadoPostal,
                        DireccionCiudadId = direccion.CiudadId,
                        DireccionCalle = direccion.Calle,
                        DireccionExtension = direccion.Extension,
                        DireccionFax = direccion.Fax,
                        DireccionNumero = direccion.Numero,
                        DireccionTelefonoCasa = direccion.TelefonoCasa,
                        DireccionTelefonoOficina = direccion.TelefonoOficina,
                        DireccionSectorId = direccion.SectorId,
                        SociedadId = sucursal.SociedadId
                    };

                    this.SociedadRegistroNuevo.Sucursales.Add(newSucursal);
                }

                //Load actividades Data
                LoadActividades(regActual);

                //Load Socios Data
                LoadSocios(dbSRM, regActual.RegistroId);

                //Load Productos
                this.LoadProductos(regActual);

                //Load Referencias Bancarias
                this.LoadReferenciasBancarias(regActual);

                //Load Referencias Comerciales
                this.LoadReferenciasComerciales(regActual);
            }
        }

        /// <summary>
        /// Define el URL para el primer paso del proceso de registro. Es un helper para el UI de los steps
        /// </summary>
        /// <returns></returns>
        protected string ObtenerUrlPrimerPaso()
        {
            if (this.RegistroNuevo != null && this.RegistroNuevo.EsNuevoRegistro)
                return "NuevoRegistro.aspx";

            return "Adecuacion.aspx";
        }


        //protected override void OnLoad(EventArgs e)
        //{
        //    if (Session["RegistroNuevo"] == null
        //        | String.IsNullOrEmpty(RegistroNuevo.NombreComercial) && !Request.Url.AbsolutePath.Contains("NuevoRegistro.aspx"))
        //        Response.Redirect("~/Operaciones/Registro/NuevoRegistro.aspx");

        //    base.OnLoad(e);
        //}

        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.OnLoad(EventArgs)'
        protected override void OnLoad(EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.OnLoad(EventArgs)'
        {
            //Se busca la infomración extendida del perfil
            var profile = OficinaVirtualUserProfile.GetUserProfile(User.Identity.Name);

            //Si es la primera vez que un usuario hijo entra, debe cambiar su contraseña
            if (profile.UsuarioPadre != null && profile.DebeCambiarPass)
                Response.Redirect("/Account/ChangePassword.aspx");

            //Si el usuario no ha firmado su contrato se redirige a la pantalla de firma (solo se aplica a usuarios padre)
            if (!profile.ContratoFirmado.GetValueOrDefault() && profile.UsuarioPadre == null)
                Response.Redirect("/Empresas/FirmaContrato.aspx");

            base.OnLoad(e);
        }
    }

    ///<summary>
    /// Tipo de transaccion en el SRM
    ///</summary>
    public enum TipoTransaccionNm
    {
        ///<summary>
        /// Transacción de renovación
        ///</summary>
        Renovacion = 1,

        /// <summary>
        /// Transacción de adecuación a la nueva ley de sociedades
        /// </summary>
        Adecuacion = 2,

        /// <summary>
        /// Transacción de constitución de nueva sociedad/empresa
        /// </summary>
        Constitucion = 3
    }
}