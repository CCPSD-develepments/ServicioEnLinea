using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.Website.Helpers;
using CamaraComercio.Website.Helpers.ExtendedControls;
using CamaraComercio.Website.Operaciones.Registro;
using CamaraComercio.Website.UserControls;
using Telerik.Web.UI;
using EF = CamaraComercio.DataAccess.EF;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using OFVper = CamaraComercio.DataAccess.EF.OficinaVirtual;
using System.Web.Configuration;
using CamaraComercio.DataAccess.EF;

namespace CamaraComercio.Website.Operaciones.Modificaciones
{
    /// <summary>
    /// Representa cualquiera de las páginas de modificacion de un registro mercantil
    /// </summary>
    public class ModificacionPage : SecurePage
    {
        #region Propiedades

        #region Implementacion de Controles Dinámicos de acuerdo al tipo de Sociedad
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.PropiedadesSociedadActual'
        public IEnumerable<OFV.PropiedadesPorSociedad> PropiedadesSociedadActual
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.PropiedadesSociedadActual'
        {
            get
            {
                return Session["PropiedadesSociedadActual"] != null
                           ? (IEnumerable<OFV.PropiedadesPorSociedad>)Session["PropiedadesSociedadActual"]
                           : null;
            }
            set { Session["PropiedadesSociedadActual"] = value; }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.PersonasRegistroNuevo'
        protected OFVper.Personas PersonasRegistroNuevo
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.PersonasRegistroNuevo'
        {
            get
            {
                if (Session["PersonaRegistroNuevo"] == null)
                    Session["PersonaRegistroNuevo"] = new OFV.Personas();
                return (OFV.Personas)Session["PersonaRegistroNuevo"];
            }
            set { Session["PersonaRegistroNuevo"] = value; }
        }
        #endregion

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

                            control.Visible = prop.Required;
                            if (control is LabelOfv)
                            {
                                ((LabelOfv)control).Text = prop.Descripcion;
                                continue;
                            }
                            if (control is RequiredValidatorOfv)
                            {
                                ((RequiredValidatorOfv)control).Enabled = prop.Required;
                                continue;
                            }
                            if (control is RangeValidatorOfv)
                            {
                                if (prop.LowerLimit.HasValue && prop.LowerLimit > -1)
                                {
                                    var rval = (RangeValidatorOfv)control;
                                    rval.Enabled = true;
                                    rval.MinimumValue = Convert.ToInt32(prop.LowerLimit).ToString();
                                }

                                if (prop.UpperLimit.HasValue && prop.UpperLimit > 0)
                                {
                                    var rval = (RangeValidatorOfv)control;
                                    rval.Enabled = true;
                                    rval.MaximumValue = Convert.ToInt32(prop.UpperLimit).ToString();
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.Redirect'
        protected bool Redirect;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.Redirect'

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


        /// <summary>
        /// Acceso al área de configuración para servicios dentro del Web.config
        /// </summary>
        public static ServicioSection ServiciosDefault
        {
            get
            {
                return (ServicioSection)WebConfigurationManager.GetWebApplicationSection("servicioSection");
            }
        }

        /// <summary>
        /// ID's de transacciones siendo modificadas 
        /// </summary>
        public int IdTransaciones
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["IdTransacciones"])
                           ? int.Parse(Request.QueryString["IdTransacciones"])
                           : 0;
            }
            set { DefaultQueryString = String.Format("nSolicitud={0}", value); }
        }

        /// <summary>
        /// Llave Primaria de la Sociedad.  
        /// </summary>
        public int SociedadId
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["sociedadId"])
                           ? int.Parse(Request.QueryString["sociedadId"])
                           : 0;
            }
            set { DefaultQueryString = String.Format("sociedadId={0}", value); }
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
        public int TipoSociedadId
        {
            get
            {
                var tsid = 0;
                if (!String.IsNullOrWhiteSpace(Request.QueryString["TipoSociedadId"]))
                {
                    var str = Request.QueryString["TipoSociedadId"];
                    if (str.Contains(","))
                    {
                        tsid = Int32.Parse(str.Substring(0, str.IndexOf(",")));
                    }
                    else
                    {
                        tsid = Int32.Parse(str);
                    }
                }
                return tsid;
            }
            set { DefaultQueryString = String.Format("TipoSociedadId={0}", value); }
        }

        /// <summary>
        /// Servicio de Modificacion seleccionado
        /// </summary>
        public int ServicioId
        {
            get { return Session["ServicioId"] != null ? int.Parse(Session["ServicioId"].ToString()) : 0; }
            set { Session["ServicioId"] = value; }
        }

        /// <summary>
        /// Camara que realizara la transaccion.
        /// </summary>
        public String CamaraId
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["CamaraId"])
                           ? Request.QueryString["CamaraId"]
                           : String.Empty;
            }
            set { DefaultQueryString = String.Format("CamaraId={0}", value); }
        }

        /// <summary>
        /// Xml que sera enviado a la camara para ser procesado.
        /// </summary>
        [Obsolete("Metodo no utilizado, ya no se envia el XML")]
        public String InstanceXML
        {
            get
            {
                if (Session["InstanceXML"] == null)
                    Session["InstanceXML"] = String.Empty;

                return Session["InstanceXML"].ToString();
            }
            set
            {
                Session["InstanceXML"] = value;
            }
        }

        /// <summary>
        /// Representación de tabla intermedia entre Sociedades y Registros
        /// </summary>
        public SRM.SociedadesRegistros SociedadRegistro
        {
            get
            {
                if (Session["SociedadRegistro"] == null)
                    return null;

                return (SRM.SociedadesRegistros)Session["SociedadRegistro"];
            }
            set { Session["SociedadRegistro"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.PersonasRegistro'
        public SRM.PersonasRegistros PersonasRegistro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.PersonasRegistro'
        {
            get
            {
                if (Session["PersonasRegistro"] == null)
                    return null;

                return (SRM.PersonasRegistros)Session["PersonasRegistro"];
            }
            set { Session["PersonasRegistro"] = value; }
        }

        /// <summary>
        /// Capital Social Actualizado
        /// </summary>
        public decimal CapitalSocialOriginal
        {
            get
            {
                if (Session["CapitalSocialOriginal"] == null)
                    return 0m;

                return Decimal.Parse(Session["CapitalSocialOriginal"].ToString());
            }
            set { Session["CapitalSocialOriginal"] = value; }
        }

        /// <summary>
        /// TipoSociedadActualizada
        /// </summary>
        public int NuevoTipoSociedad
        {
            get
            {
                return Session["NuevoTipoSociedad"] == null ? 0 : int.Parse(Session["NuevoTipoSociedad"].ToString());
            }
            set { Session["NuevoTipoSociedad"] = value; }
        }


        /// <summary>
        /// Indica si al momento de la modificación se incluira la Renovación.
        /// </summary>
        public bool IncluirRenovacion
        {
            get
            {
                return Session["IncluirRenovacion"] == null
                           ? false
                           : bool.Parse(Session["IncluirRenovacion"].ToString());
            }
            set { Session["IncluirRenovacion"] = value; }
        }
        #endregion

        #region Metodos de acceso a datos
        /// <summary>
        /// Guardado de los cambios en los objetos que están en memoria
        /// </summary>
        public void GuardarObjetoModificacion()
        {
            try
            {
                if (this.SociedadRegistro == null)
                    InitializeSociedad();

                //Creando Transaccion
                var transModificacion = new OFV.Transacciones
                                            {
                                                TransaccionId = -1,
                                                Fecha = DateTime.Now,
                                                NombreContacto =
                                                    ((OficinaVirtualUserProfile)this.Context.Profile).NombreSolicitante,
                                                RegistroId = this.RegistroId,
                                                NumeroRegistro = this.SociedadRegistro.NumeroRegistro,
                                                ModificacionCapital = this.RegistroNuevo.CapitalSocial,
                                                CapitalSocial = this.RegistroNuevo.CapitalSocial,
                                                TipoSociedadId = this.TipoSociedadId,
                                                RNCSolicitante = this.SociedadRegistro.Sociedades.Rnc,
                                                ServicioId = this.ServicioId,
                                                UserName = User.Identity.Name.ToLower(),
                                                CamaraId = this.CamaraId,
                                                EstatusTransId = Helper.EstatusTransIdNuevo,
#pragma warning disable CS0618 // 'ModificacionPage.InstanceXML' is obsolete: 'Metodo no utilizado, ya no se envia el XML'
                                                InstanceXML = this.InstanceXML,
#pragma warning restore CS0618 // 'ModificacionPage.InstanceXML' is obsolete: 'Metodo no utilizado, ya no se envia el XML'
                                                FechaReciboDGII = this.ReciboDGII.FechaReciboDGII,
                                                NoReciboDGII = this.ReciboDGII.NoReciboDGII,
                                                MontoDGII = this.ReciboDGII.MontoDGII
                                            };

                if (this.TransaccionesEnRegistro.TransaccionId < 0)
                    this.TransaccionesEnRegistro.SubTransacciones.Add(transModificacion);
                else
                    this.TransaccionesEnRegistro = transModificacion;

            }
            catch (Exception)
            {
                ErrorMessage = "Ha Ocurrido un error. Por favor intente de nuevo.";
            }
        }

        /// <summary>
        /// Commit de los cambios hacia la base de datos
        /// </summary>
        public void SubmitChanges()
        {
            var db = new OFV.CamaraWebsiteEntities();
            var repTransacciones = new EF.Repository<OFV.Transacciones, OFV.CamaraWebsiteEntities>(db);

            using (var tnx = repTransacciones.BeginTransaction())
            {
                try
                {
                    if (IsFormularionConfirmacion && this.TipoSociedadId != 7)
                        GuardarObjetosRegistro(db, tnx);
                    if (IsFormularionConfirmacion && this.TipoSociedadId == 7)
                        GuardarObjetosRegistroPer(db, tnx);

                    if (EsTransformacion)
                        GuardarServicioAumento();

                    //Registro de Renovación.
                    if (this.RegistroNuevo.EsRenovacion || IncluirRenovacion)
                        GuardarRenovacion();

                    repTransacciones.Add(this.TransaccionesEnRegistroFinal);
                    repTransacciones.Save();

                    //Se agrega el numero para que pueda seguir con la seleccion de documentos.
                    IdTransaciones = this.TransaccionesEnRegistroFinal.TransaccionId;

                    tnx.Commit();
                    Redirect = true;
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    ErrorMessage = "Ha Ocurrido un Error, Por favor intente mas tarde.";
                    tnx.Rollback();
                    LimpiarGeneratedId();
                    throw;
                }
            }
        }

        private void GuardarServicioAumento()
        {
            var tnx = GetTransModificacion();



            var capitalSocial = this.SociedadRegistro.Registros.CapitalSocial.GetValueOrDefault() > 0
                                    ? this.SociedadRegistro.Registros.CapitalSocial
                                    : this.SociedadRegistro.Registros.CapitalAutorizado;

            if (capitalSocial > this.CapitalSocialOriginal)
            {
                var servicioId = ServiciosDefault.Servicios.First(a =>
                                                                  a.TipoSociedadId ==
                                                                  this.SociedadRegistroNuevo.TipoSociedadId).
                                                                  ServicioTransformacionAumentoId;

                tnx.ServicioId = servicioId;


            }
            else if (capitalSocial < this.CapitalSocialOriginal)
            {
                var servicioId = ServiciosDefault.Servicios.First(a => a.TipoSociedadId ==
                                                                  this.SociedadRegistroNuevo.TipoSociedadId).
                                                                    ServicioTransformacionReduccionId;

                tnx.ServicioId = servicioId;
            }

            //Si el servicio ya fue registrado, suspendiendo el registro automatico.
            if (this.TransaccionesEnRegistroFinal.GetServicioTransacciones().Contains(tnx.ServicioId))
                return;


            //Si no Existe Servicio a Registrar Retorno
            if (tnx.ServicioId < 1)
                return;

            if (this.TransaccionesEnRegistroFinal.TransaccionId == 0)
                this.TransaccionesEnRegistroFinal = tnx;
            else
                this.TransaccionesEnRegistroFinal.SubTransacciones.Add(tnx);

        }

        private void GuardarRenovacion()
        {
            var fechaVenc = this.RegistroNuevo.FechaVencimiento ?? DateTime.Today;
            var fechaIni = new DateTime(Math.Max(fechaVenc.Ticks, DateTime.Parse("01/01/2003").Ticks));
            int cantidadPeriodos = Convert.ToInt32(Math.Ceiling((DateTime.Today - fechaIni).TotalDays / 365.25 / 2));

            if(this.TipoSociedadId != 7)
            {
                var tipoSociedad = this.SociedadRegistroNuevo.TipoSociedadId;

                var servicioId = ServiciosDefault.Servicios.FirstOrDefault
                    (a => a.TipoSociedadId == tipoSociedad)
                    .ServicioRenovacionSimpleId;

                if (this.TransaccionesEnRegistroFinal.TransaccionId == 0)
                {
                    Transacciones tnx = GetTransModificacion();
                    tnx.ServicioId = servicioId;
                    this.TransaccionesEnRegistroFinal = tnx;
                    cantidadPeriodos--;
                }

                for (int i = 0; i < (cantidadPeriodos - 1); i++)
                {
                    Transacciones tnx = GetTransModificacion();
                    tnx.ServicioId = servicioId;
                    this.TransaccionesEnRegistroFinal.SubTransacciones.Add(tnx);
                }
            }
            else
            {

                if (this.TransaccionesEnRegistroFinal.TransaccionId == 0)
                {
                    Transacciones tnx = GetTransModificacion();
                    tnx.ServicioId = 421;
                    this.TransaccionesEnRegistroFinal = tnx;
                    cantidadPeriodos--;
                }

                for (int i = 0; i < (cantidadPeriodos - 1); i++)
                {
                    Transacciones tnx = GetTransModificacion();
                    tnx.ServicioId = 421;
                    this.TransaccionesEnRegistroFinal.SubTransacciones.Add(tnx);
                }
            }

        }
        
        /// <summary>
        /// Inicializa un objeto con la sociedad siendo trabajada en el momento
        /// </summary>
        public void InitializeSociedad()
        {
            var dbSRM = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);

            this.SociedadRegistro =
                dbSRM.SociedadesRegistros.Include("Sociedades").Include("Registros").Where(
                    a => a.RegistroId == this.RegistroId && a.SociedadId == this.SociedadId)
                    .FirstOrDefault();

            if (this.TipoSociedadId == 0)
            {
                this.TipoSociedadId = this.SociedadRegistro.Sociedades.TipoSociedadId.Value2();
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.InitializePersona()'
        public void InitializePersona()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.InitializePersona()'
        {
            var ctrlPersona = new SRM.PersonaFisicaController();
            var personas = ctrlPersona.ObteneByRegistroIdCamara(RegistroId, CamaraId).FirstOrDefault();
            this.PersonasRegistro = personas;

            if (this.TipoSociedadId == 0)
            {
                this.TipoSociedadId = 7;
            }
        }

        /// <summary>
        /// Guarda todos los objetos del formulario relacionados al registro
        /// </summary>
        protected void GuardarObjetosRegistro(OFV.CamaraWebsiteEntities dbOfv, DbTransaction tnx)
        {
            var repRegistros = new EF.Repository<OFV.Registros, OFV.CamaraWebsiteEntities>(dbOfv);
            var repSociedades = new EF.Repository<OFV.Sociedades, OFV.CamaraWebsiteEntities>(dbOfv);
            var repRegistrosActividades = new EF.Repository<OFV.RegistrosActividades, OFV.CamaraWebsiteEntities>(dbOfv);
            var repProductos = new EF.Repository<OFV.Productos, OFV.CamaraWebsiteEntities>(dbOfv);
            var repRefBancarias = new EF.Repository<OFV.ReferenciasBancarias, OFV.CamaraWebsiteEntities>(dbOfv);
            var repRefComerciales =
                new EF.Repository<OFV.ReferenciasComerciales, OFV.CamaraWebsiteEntities>(dbOfv);
            var repSucursales = new EF.Repository<OFV.Sucursales, OFV.CamaraWebsiteEntities>(dbOfv);
            var repSocios = new EF.Repository<OFV.Socios, OFV.CamaraWebsiteEntities>(dbOfv);
            var repTransacciones = new EF.Repository<OFV.Transacciones, OFV.CamaraWebsiteEntities>(dbOfv);
            var repPersonas = new EF.Repository<OFV.Personas, OFV.CamaraWebsiteEntities>(dbOfv);

            this.RegistroNuevo.GestorUsername = HttpContext.Current.Profile.UserName.ToLower();
            this.RegistroNuevo.FechaSolicitud = DateTime.Now;

            //Objetos que definen la sociedad
            this.RegistroNuevo.EntidadActiva = true;
            repRegistros.Add(this.RegistroNuevo);
            repRegistros.Save();

            this.SociedadRegistroNuevo.RegistroId = this.RegistroNuevo.RegistroId;
            repSociedades.Add(this.SociedadRegistroNuevo);
            repSociedades.Save();

            //Actividades
            List<int> listActividades = new List<int>();
            foreach (var actividad in this.ActividadesEnRegistro)
            {
                if (!listActividades.Contains(actividad.TipoActividadId))
                {
                    actividad.RegistroId = this.RegistroNuevo.RegistroId;
                    actividad.FechaModificacion = DateTime.Now;
                    listActividades.Add(actividad.TipoActividadId);
                    repRegistrosActividades.Add(actividad);
                }
            }
            repRegistrosActividades.Save();

            //Productos
            List<string> productos = new List<string>();
            foreach (var producto in this.ProductosEnRegistro)
            {
                if (!productos.Contains(producto.Descripcion))
                {
                    producto.RegistroId = this.RegistroNuevo.RegistroId;
                    producto.FechaModificacion = DateTime.Now;
                    productos.Add(producto.Descripcion);
                    repProductos.Add(producto);
                }
            }
            repProductos.Save();

            //Referencias Bancarias
            List<int> bancos = new List<int>();
            foreach (var refBancaria in this.ReferenciasBancariasRegistro)
            {
                if (!bancos.Contains(refBancaria.BancoId))
                {
                    refBancaria.RegistroId = this.RegistroNuevo.RegistroId;
                    refBancaria.FechaModificacion = DateTime.Now;
                    bancos.Add(refBancaria.BancoId);
                    repRefBancarias.Add(refBancaria);
                }
            }
            repRefBancarias.Save();

            //Referencias Comerciales
            List<string> listRefComercial = new List<string>();
            foreach (var refComercial in this.ReferenciasComercialesRegistro)
            {
                if (!listRefComercial.Contains(refComercial.Descripcion))
                {
                    refComercial.RegistroId = this.RegistroNuevo.RegistroId;
                    refComercial.FechaModificacion = DateTime.Now;
                    refComercial.TipoReferencia = "C";
                    listRefComercial.Add(refComercial.Descripcion);
                    repRefComerciales.Add(refComercial);
                }
            }
            repRefComerciales.Save();

            //Sucursales
            List<string> listSucursales = new List<string>();
            foreach (var sucursal in SucursalesRegistro)
            {
                if (!listSucursales.Contains(sucursal.Descripcion))
                {
                    sucursal.SociedadId = this.SociedadRegistroNuevo.SociedadId;
                    sucursal.FechaModificacion = DateTime.Now;
                    listSucursales.Add(sucursal.Descripcion);
                    repSucursales.Add(sucursal);
                }
            }
            repSucursales.Save();

            //Socios
            var sociosRepresentados = this.SociosEnRegistro.Where(a => a.RepresentanteId > 0).ToList();
            foreach (var socios in sociosRepresentados)
            {
                var socios1 = socios;

                socios1.RegistroId = this.RegistroNuevo.RegistroId;
                var representantes1 =
                    this.Representantes.FirstOrDefault(a => a.PersonaId == socios1.RepresentanteId);

                var repFromDb =
                    repPersonas.Session.Personas.FirstOrDefault(a => a.Documento == representantes1.Documento
                                                                     && a.TipoDocumento == representantes1.TipoDocumento);
                if (repFromDb != null)
                    repFromDb.Socios.Add(socios1);
                else
                {
                    representantes1.Socios.Add(socios1);
                    repPersonas.Add(representantes1);
                }
            }
            repPersonas.Save();

            //Representantes
            List<string> listSocios = new List<string>();
            foreach (var socio in this.SociosEnRegistro)
            {
                string cksocio = string.Format("{0},{1},{2},{3},{4},{5}", socio.TipoSocio, socio.TipoRelacion, socio.CargoId, socio.TipoDocumento, socio.Documento, socio.PersonaPrimerNombre);
                if (!listSocios.Contains(cksocio))
                {
                    socio.RegistroId = this.RegistroNuevo.RegistroId;
                    socio.RepresentanteId = null;
                    socio.RepresentanteId = null;
                    socio.RegistroMercantil = this.RegistroNuevo.RegistroMercantil.HasValue
                                                  ? this.RegistroNuevo.RegistroMercantil.Value.ToString()
                                                  : String.Empty;
                    socio.Orden += 1;
                    listSocios.Add(cksocio);
                    repSocios.Add(socio);
                }
            }
            repSocios.Save();


            //Transacciones
            var servicioList = !String.IsNullOrWhiteSpace(Request.QueryString["ServicioId"])
                                             ? Request.QueryString["ServicioId"].Split(',').Select(a => int.Parse(a)).
                                               ToList()
                                             : new List<int>();

            var dbComun = new Comun.CamaraComunEntities();
            var servicioFacturar = dbComun.Servicio.Where(a => servicioList.Contains(a.ServicioId))
                    .OrderBy(a => a.ServicioJerarquia).ThenBy(a => a.TransaccionJerarquia) .ToList();

            if (servicioList.Count == 0 && this.ServicioId > 0)
            {
                servicioFacturar.Add(dbComun.Servicio.FirstOrDefault(a => a.ServicioId == this.ServicioId));
                servicioList.Add(this.ServicioId);
            }

            var index = 0;
            foreach (var servicio in servicioFacturar)
            {
                var cantidadSubTrans = servicioList.Where(s => s == servicio.ServicioId).Count();
                for (var i = 0; i < cantidadSubTrans; i++)
                {
                    var newTransaccion = this.TransaccionesEnRegistro.GetTransaccionByServicioId(servicio.ServicioId) ??
                                     GetTransModificacion();
                    newTransaccion.ServicioId = servicio.ServicioId;
                    newTransaccion.NombreSocialPersona = this.SociedadRegistroNuevo.NombreSocial;

                    if (index == 0)
                    {
                        newTransaccion.RegistroId = this.RegistroId;
                        newTransaccion.NumeroRegistro = this.RegistroNuevo.RegistroMercantil;
                        newTransaccion.FechaAsamblea = this.SociedadRegistroNuevo.FechaAsamblea;

                        this.TransaccionesEnRegistroFinal = newTransaccion;
                    }
                    else
                    {
                        this.TransaccionesEnRegistroFinal.SubTransacciones.Add(newTransaccion);
                    }
                    index++;
                }
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.GuardarObjetosRegistroPer(CamaraWebsiteEntities, DbTransaction)'
        protected void GuardarObjetosRegistroPer(OFV.CamaraWebsiteEntities dbOfv, DbTransaction tnx)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.GuardarObjetosRegistroPer(CamaraWebsiteEntities, DbTransaction)'
        {
            var repRegistros = new EF.Repository<OFV.Registros, OFV.CamaraWebsiteEntities>(dbOfv);
            var repRegistrosActividades = new EF.Repository<OFV.RegistrosActividades, OFV.CamaraWebsiteEntities>(dbOfv);
            var repProductos = new EF.Repository<OFV.Productos, OFV.CamaraWebsiteEntities>(dbOfv);
            var repRefBancarias = new EF.Repository<OFV.ReferenciasBancarias, OFV.CamaraWebsiteEntities>(dbOfv);
            var repRefComerciales =
                new EF.Repository<OFV.ReferenciasComerciales, OFV.CamaraWebsiteEntities>(dbOfv);
            var repSucursales = new EF.Repository<OFV.Sucursales, OFV.CamaraWebsiteEntities>(dbOfv);
            var repSocios = new EF.Repository<OFV.Socios, OFV.CamaraWebsiteEntities>(dbOfv);
            var repTransacciones = new EF.Repository<OFV.Transacciones, OFV.CamaraWebsiteEntities>(dbOfv);
            var repPersonas = new EF.Repository<OFV.Personas, OFV.CamaraWebsiteEntities>(dbOfv);

            this.RegistroNuevo.GestorUsername = HttpContext.Current.Profile.UserName.ToLower();
            this.RegistroNuevo.FechaSolicitud = DateTime.Now;

            this.RegistroNuevo.EntidadActiva = true;

            //Transacciones
            var servicioList = !String.IsNullOrWhiteSpace(Request.QueryString["ServicioId"])
                                             ? Request.QueryString["ServicioId"].Split(',').Select(a => int.Parse(a)).
                                               ToList()
                                             : new List<int>();

            var dbComun = new Comun.CamaraComunEntities();
            var servicioFacturar = dbComun.Servicio.Where(a => servicioList.Contains(a.ServicioId))
                    .OrderBy(a => a.ServicioJerarquia).ThenBy(a => a.TransaccionJerarquia).ToList();

            if (servicioList.Count == 0 && this.ServicioId > 0)
            {
                servicioFacturar.Add(dbComun.Servicio.FirstOrDefault(a => a.ServicioId == this.ServicioId));
                servicioList.Add(this.ServicioId);
            }
            var nombreCompleto = String.Format(PersonasRegistroNuevo.NombreCompleto);
            var index = 0;
            foreach (var servicio in servicioFacturar)
            {
                var cantidadSubTrans = servicioList.Where(s => s == servicio.ServicioId).Count();
                for (var i = 0; i < cantidadSubTrans; i++)
                {
                    var newTransaccion = this.TransaccionesEnRegistro.GetTransaccionByServicioId(servicio.ServicioId) ??
                                     GetTransModificacion();
                    newTransaccion.ServicioId = servicio.ServicioId;
                    newTransaccion.NombreSocialPersona = nombreCompleto;

                    if (index == 0)
                    {
                        newTransaccion.RegistroId = this.RegistroId;
                        newTransaccion.NumeroRegistro = this.RegistroNuevo.RegistroMercantil;
                        newTransaccion.FechaAsamblea = this.SociedadRegistroNuevo.FechaAsamblea;

                        this.TransaccionesEnRegistroFinal = newTransaccion;
                    }
                    else
                    {
                        this.TransaccionesEnRegistroFinal.SubTransacciones.Add(newTransaccion);
                    }
                    index++;
                }
            }
        }

        private Transacciones GetTransModificacion()
        {
            if (this.TipoSociedadId != 7)
            {
                if (SociedadRegistro == null)
                    InitializeSociedad();

                return new OFV.Transacciones
                {
                    TransaccionId = -1,
                    Fecha = DateTime.Now,
                    NombreContacto = this.RegistroNuevo.NombreSolicitante,
                    RegistroId = this.RegistroId,
                    ModificacionCapital = this.RegistroNuevo.CapitalSocial,
                    CapitalSocial = this.RegistroNuevo.CapitalSocial,
                    TipoSociedadId = this.SociedadRegistroNuevo.TipoSociedadId.Value2(),
                    RNCSolicitante = this.SociedadRegistroNuevo.Rnc,
                    UserName = User.Identity.Name.ToLower(),
                    CamaraId = this.CamaraId,
                    EstatusTransId = Helper.EstatusTransIdNuevo,
                    Solicitante = this.RegistroNuevo.NombreSolicitante,
                    FechaReciboDGII = this.ReciboDGII.FechaReciboDGII,
                    MontoDGII = this.ReciboDGII.MontoDGII,
                    NoReciboDGII = this.ReciboDGII.NoReciboDGII,
                    TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono,
                    NumeroRegistro = this.RegistroNuevo.RegistroMercantil

                };
            }
            else
            {
                if (PersonasRegistro == null)
                    InitializePersona();

                return new OFV.Transacciones
                {
                    TransaccionId = -1,
                    Fecha = DateTime.Now,
                    NombreContacto = this.RegistroNuevo.NombreSolicitante,
                    RegistroId = this.RegistroId,
                    ModificacionCapital = this.RegistroNuevo.CapitalSocial,
                    CapitalSocial = this.RegistroNuevo.CapitalSocial,
                    TipoSociedadId = this.TipoSociedadId,
                    RNCSolicitante = this.PersonasRegistroNuevo.Rnc,
                    UserName = User.Identity.Name.ToLower(),
                    CamaraId = this.CamaraId,
                    EstatusTransId = Helper.EstatusTransIdNuevo,
                    Solicitante = this.RegistroNuevo.NombreSolicitante,
                    FechaReciboDGII = this.ReciboDGII.FechaReciboDGII,
                    MontoDGII = this.ReciboDGII.MontoDGII,
                    NoReciboDGII = this.ReciboDGII.NoReciboDGII,
                    TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono,
                    NumeroRegistro = this.PersonasRegistro.NumeroRegistro

                };
            }

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

            var montoTransaccion = 0.0m;
            var dbSrm = new SRM.CamaraSRMEntities(EF.Helpers.GetCamaraConnString(this.CamaraId));

            switch (tipo)
            {
                case TipoTransaccionNm.Renovacion:
                case TipoTransaccionNm.Constitucion:
                    var tarifa = dbSrm.Tarifas.Where(a => a.MontoInicial >= capitalSocial.Value
                                        && a.MontoFinal <= capitalSocial.Value).FirstOrDefault();
                    montoTransaccion = tarifa != null ? tarifa.CostoRenovacion : montoTransaccion;
                    break;

                case TipoTransaccionNm.Adecuacion:
                    montoTransaccion = Helper.CostoAdecuacion;
                    break;
            }
            return montoTransaccion;
        }

        /// <summary>
        /// Cargado de socios a los datagrids
        /// </summary>
        /// <param name="dbSrm"></param>
        /// <param name="registroId"></param>
        protected void LoadSocios(SRM.CamaraSRMEntities dbSrm, int registroId)
        {
            var socios = dbSrm.RegistrosSocios.Where(a => a.RegistroId == registroId).ToList();
            this.SociosEnRegistro = new List<OFV.Socios>();

            foreach (var item in socios)
            {
                if (item == null) continue;
                var direcciones = dbSrm.Direcciones.FirstOrDefault(a => a.DireccionId == item.DireccionId);

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
                                    RegistroMercantil = this.RegistroNuevo.RegistroMercantil.Value2().ToString(),
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

                var socioAdded =
                    this.SociosEnRegistro.FirstOrDefault(
                        s =>
                        s.Documento == socio.Documento && s.TipoDocumento == socio.TipoDocumento &&
                        s.PersonaPrimerNombre == socio.PersonaPrimerNombre &&
                        s.PersonaPrimerApellido == socio.PersonaPrimerApellido);

                if (socioAdded != null)
                    socio.Id = socioAdded.Id;

                this.SociosEnRegistro.Add(socio);
            }
        }
        /// <summary>
        /// Carga los productos registrados en la coleccion que está en memoria
        /// </summary>
        /// <param name="regActual"></param>
        protected void LoadProductos(SRM.Registros regActual)
        {
            //Creando Productos
            this.ProductosEnRegistro = new List<OFV.Productos>();
            foreach (var newProducto in regActual.Productos
                                        .Select(producto => new OFV.Productos
                                        {
                                            Descripcion = producto.Descripcion,
                                            SistemaArmonizadoId = producto.SistemaArmonizadoId
                                        }))
            { this.ProductosEnRegistro.Add(newProducto); }
        }
        /// <summary>
        /// Carga las actividades comerciales en la colección que está en memoria
        /// </summary>
        /// <param name="regActual"></param>
        protected void LoadActividades(SRM.Registros regActual)
        {
            this.ActividadesEnRegistro = new List<OFV.RegistrosActividades>();
            foreach (var newActividad in regActual.RegistrosActividades
                    .Select(actividad => new OFV.RegistrosActividades
                    {
                        AtividadId = actividad.AtividadId,
                        TipoActividadId = actividad.TipoActividadId
                    }))
            { this.ActividadesEnRegistro.Add(newActividad); }
        }
        /// <summary>
        /// Carga las referencias bancarias en la colección que está en memoria
        /// </summary>
        /// <param name="regActual"></param>
        protected void LoadReferenciasComerciales(SRM.Registros regActual)
        {
            this.ReferenciasComercialesRegistro = new List<OFV.ReferenciasComerciales>();
            foreach (var newActividad in regActual.ReferenciasComerciales
                .Select(actividad => new OFV.ReferenciasComerciales
                {
                    Descripcion = actividad.Descripcion,
                    TipoReferencia = actividad.TipoReferencia
                }))
            { this.ReferenciasComercialesRegistro.Add(newActividad); }
        }
        /// <summary>
        /// Carga las referencias bancarias en la colección que está en memoria
        /// </summary>
        /// <param name="regActual"></param>
        protected void LoadReferenciasBancarias(SRM.Registros regActual)
        {
            this.ReferenciasBancariasRegistro = new List<OFV.ReferenciasBancarias>();
            var banRef = regActual.ReferenciasBancarias.Select(a => a.BancoId);
            var dbComun = new Comun.CamaraComunEntities();
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

        /// <summary>
        /// Carga la data del registro de SRM en los objetos que están en memoria
        /// </summary>
        /// <param name="dbSRM"></param>
        /// <param name="regActual"></param>
        protected void LoadRegistroData(SRM.CamaraSRMEntities dbSRM, SRM.Registros regActual)
        {
            if (regActual == null) return;

            //Sociedad relacionada al registro actual
            var SocAdecuada = regActual.SociedadesRegistros.FirstOrDefault();

            //En caso de que el registro ya tenga asignado un capital social o pagado nuevo
            Decimal? capitalSocial = 0, capitalPagado = 0;
            //if (this.RegistroNuevo != null)
            //{
            //    capitalSocial = this.RegistroNuevo.CapitalSocial ?? 0m;
            //    capitalPagado = this.RegistroNuevo.CapitalPagado ?? 0m;
            //}

            //Objeto con el registro actual
            this.RegistroSistemaActual = regActual;
            if (regActual.Direcciones == null)
                regActual.Direcciones = dbSRM.Direcciones.CreateObject();
            
            //Crear Informacion de Registro Existente
            this.RegistroNuevo = new OFV.Registros
                                     {
                                         RegistroMercantil = SocAdecuada.NumeroRegistro,
                                         EsNuevoRegistro = false,
                                         FechaEmision = regActual.FechaEmision,
                                         Activos = regActual.Activos,
                                         ActividadNegocio = regActual.ActividadNegocio,
                                         BienesRaices = regActual.BienesRaices,
                                         CapitalAutorizado = regActual.CapitalAutorizado,
                                         CapitalPagado = capitalPagado > 0 ? capitalPagado : regActual.CapitalPagado,
                                         CapitalSocial = capitalSocial > 0 
                                                        ? capitalSocial 
                                                        : (regActual.CapitalSocial.GetValueOrDefault() > 0 
                                                                ? regActual.CapitalSocial.GetValueOrDefault() 
                                                                : regActual.CapitalAutorizado),
                                         EmpleadosFemeninos = regActual.EmpleadosFemeninos,
                                         EmpleadosMasculinos = regActual.EmpleadosMasculinos,
                                         EmpleadosTotal = regActual.EmpleadosTotal,
                                         FechaInicioOperacion = regActual.FechaInicioOperacion,
                                         FechaVencimiento = regActual.FechaVencimiento,
                                         MarcaFabrica = regActual.MarcaFabrica,
                                         RegistroMarcaFabrica = regActual.RegistroMarcaFabrica,
                                         NombreOperador = regActual.NombreOperador,
                                         NumeroSocios = regActual.NumeroSocios,
                                         PatenteInvencion = regActual.PatenteInversion,
                                         RegistroPatenteInvencion = regActual.RegistroPatenteInversion,
                                         NombreComercial = regActual.NombreComercial,
                                         RegistroNombreComercial = regActual.RegistroNombreComercial,
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

            if (RegistroNuevo.FechaInicioOperacion.GetValueOrDefault() == DateTime.MinValue)
                RegistroNuevo.FechaInicioOperacion = null;

            if (RegistroNuevo.FechaVencimiento.GetValueOrDefault() == DateTime.MinValue)
                RegistroNuevo.FechaVencimiento = null;

            if (RegistroNuevo.FechaSolicitud.GetValueOrDefault() == DateTime.MinValue)
                RegistroNuevo.FechaSolicitud = null;

            if (RegistroNuevo.FechaEmision.GetValueOrDefault() == DateTime.MinValue)
                RegistroNuevo.FechaEmision = null;

            //Crear Informacion de Sociedad
            this.SociedadRegistroNuevo = new OFV.Sociedades
                                             {
                                                 Rnc = SocAdecuada.Sociedades.Rnc,
                                                 NombreSocial = SocAdecuada.Sociedades.NombreSocial,
                                                 TipoSociedadId = SocAdecuada.Sociedades.TipoSociedadId,
                                                 TipoEnteReguladoId = SocAdecuada.Sociedades.TipoEnteReguladoId,
                                                 FechaAsamblea = SocAdecuada.Sociedades.FechaAsamblea,
                                                 FechaConstitucion = SocAdecuada.Sociedades.FechaConstitucion,
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

            //var TestSelect  = SocAdecuada.Sociedades
            //                             let direccion = dbSRM.Direcciones.FirstOrDefault(a => a.DireccionId == sucursal.DireccionId).

            var Direccionid_ = SocAdecuada.Sociedades.Suscursales.FirstOrDefault(); 

            if (Direccionid_ != null && Direccionid_.DireccionId != null) {
                //Crear Informacion de la sucursal.
                foreach (var newSucursal in from sucursal in SocAdecuada.Sociedades.Suscursales
                                            let direccion = dbSRM.Direcciones.FirstOrDefault(a => a.DireccionId == sucursal.DireccionId)

                                            select new OFV.Sucursales
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
                                            })

                { this.SociedadRegistroNuevo.Sucursales.Add(newSucursal); }
            }

            //Load actividades Data
            this.LoadActividades(regActual);
            //Load Socios Data
            this.LoadSocios(dbSRM, regActual.RegistroId);
            //Load Productos
            this.LoadProductos(regActual);
            //Load Referencias Bancarias
            this.LoadReferenciasBancarias(regActual);
            //Load Referencias Comerciales
            this.LoadReferenciasComerciales(regActual);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.LoadRegistroDataPer(CamaraSRMEntities, Registros)'
        protected void LoadRegistroDataPer(SRM.CamaraSRMEntities dbSRM, SRM.Registros regActual)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.LoadRegistroDataPer(CamaraSRMEntities, Registros)'
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

        #endregion

        #region Metodos (utils)
        /// <summary>
        /// Función de Paginación
        /// </summary>
        protected void GoNextPage()
        {
            var queryString = DefaultQueryString.Replace("%2c", ",");   
            var index = Paginas.LastIndexOf("~" + Request.Path + queryString);
            if (++index < Paginas.Count)
                Response.Redirect(Paginas[index]);
        }

        /// <summary>
        /// Reinicia el ID de los objetos que se guardaron en la base de datos luego de un rollback
        /// </summary>
        private void LimpiarGeneratedId()
        {
            if (this.RegistroNuevo.EsNuevoRegistro)
                this.RegistroNuevo.RegistroId = 0;
            this.SociedadRegistroNuevo.RegistroId = this.RegistroNuevo.RegistroId;
            this.TransaccionesEnRegistro = new OFV.Transacciones();
        }

        /// <summary>
        /// Validacion: Determina si el usuario selecciono por lo menos un item en un control de lista
        /// </summary>
        protected static bool SeleccionoItemsEnListado(ListControl cbList)
        {
            var seleccionoActividades = false;
            for (var i = 0; i < cbList.Items.Count; i++)
            {
                if (!cbList.Items[i].Selected) continue;
                seleccionoActividades = true;
                break;
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
            TransaccionesEnRegistroFinal = null;
            Session["bIsFormularionConfirmacion"] = null;
            Session["TransaccionIdIndex"] = null;
            Paginas = null;
            Session.Remove("IncluirRenovacion");
        }

        /// <summary>
        /// Initializa el registro a trabajar
        /// </summary>
        protected void InitializeSessionData()
        {
            InitializeSociedad();

            var dbSRM = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);
            var regActual = dbSRM.SociedadesRegistros.Where(a => a.RegistroId == this.RegistroId && a.SociedadId == this.SociedadId)
                            .Select(a => a.Registros).FirstOrDefault();
            this.LoadRegistroData(dbSRM, regActual);
            this.IsFormularionConfirmacion = true;

            var capSocialOriginalCheck = regActual.CapitalSocial.GetValueOrDefault();
            this.CapitalSocialOriginal = capSocialOriginalCheck > 0 
                                         ? capSocialOriginalCheck
                                         : regActual.CapitalAutorizado.GetValueOrDefault();

            if (this.EsTransformacion)
                this.SociedadRegistroNuevo.TipoSociedadId = this.NuevoTipoSociedad;
        }

        #endregion

        #region Propiedades en Sesion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.ServiciosSeleccionados'
        public List<Int32> ServiciosSeleccionados
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.ServiciosSeleccionados'
        {
            get
            {
                if (Session["ServicioSeleccionados"] == null)
                    Session["ServicioSeleccionados"] = new List<Int32>();

                return Session["ServicioSeleccionados"] as List<Int32>;
            }
            set { Session["ServicioSeleccionados"] = value; }
        }

        ///<summary>
        /// IDs de servicios seleccionados en la URL
        ///</summary>
        public List<Int32> ServiciosSeleccionadosPorUrl
        {
            get
            {
                var listado = new List<int>();

                if (!String.IsNullOrWhiteSpace(Request.QueryString["ServicioId"]))
                {
                    var split = Request.QueryString["ServicioId"].Split(',');
                    foreach (var s in split)
                    {
                        var id = 0;
                        if (Int32.TryParse(s, out id))
                            listado.Add(id);
                    }
                }

                return listado;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.Paginas'
        protected List<String> Paginas
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.Paginas'
        {
            get
            {
                if (Session["Paginas"] == null)
                    Session["Paginas"] = new List<String>();

                return (List<String>)Session["Paginas"];
            }
            set { Session["Paginas"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.TransaccionesEnRegistro'
        protected OFV.Transacciones TransaccionesEnRegistro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.TransaccionesEnRegistro'
        {
            get
            {
                if (Session["TransaccionesEnRegistro"] == null)
                    Session["TransaccionesEnRegistro"] = new OFV.Transacciones();
                return (OFV.Transacciones)Session["TransaccionesEnRegistro"];
            }
            set { Session["TransaccionesEnRegistro"] = value; }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.TransaccionesEnRegistroFinal'
        protected OFV.Transacciones TransaccionesEnRegistroFinal
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.TransaccionesEnRegistroFinal'
        {
            get
            {
                if (Session["TransaccionesEnRegistroFinal"] == null)
                    Session["TransaccionesEnRegistroFinal"] = new OFV.Transacciones();
                return (OFV.Transacciones)Session["TransaccionesEnRegistroFinal"];
            }
            set { Session["TransaccionesEnRegistroFinal"] = value; }
        }



#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.RegistroNuevo'
        protected OFV.Registros RegistroNuevo
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.RegistroNuevo'
        {
            get
            {
                if (Session["RegistroNuevo"] == null)
                    Session["RegistroNuevo"] = new OFV.Registros();
                return (OFV.Registros)Session["RegistroNuevo"];
            }
            set { Session["RegistroNuevo"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.SociedadRegistroNuevo'
        protected OFV.Sociedades SociedadRegistroNuevo
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.SociedadRegistroNuevo'
        {
            get
            {
                if (Session["SociedadRegistroNuevo"] == null)
                    Session["SociedadRegistroNuevo"] = new OFV.Sociedades();
                return (OFV.Sociedades)Session["SociedadRegistroNuevo"];
            }
            set { Session["SociedadRegistroNuevo"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.RegistroSistemaActual'
        protected SRM.Registros RegistroSistemaActual
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.RegistroSistemaActual'
        {
            get
            {
                if (Session["RegistroSistemaActual"] == null)
                    Session["RegistroSistemaActual"] = new SRM.Registros();
                return (SRM.Registros)Session["RegistroSistemaActual"];
            }
            set { Session["RegistroSistemaActual"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.Bancos'
        protected List<Comun.Bancos> Bancos
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.Bancos'
        {
            get
            {
                if (Session["Bancos"] == null)
                    Session["Bancos"] = new List<Comun.Bancos>();
                return (List<Comun.Bancos>)Session["Bancos"];
            }
            set { Session["Bancos"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.ActividadesEnRegistro'
        protected List<OFV.RegistrosActividades> ActividadesEnRegistro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.ActividadesEnRegistro'
        {
            get
            {
                if (Session["ActividadesEnRegistro"] == null)
                    Session["ActividadesEnRegistro"] = new List<OFV.RegistrosActividades>();
                return (List<OFV.RegistrosActividades>)Session["ActividadesEnRegistro"];
            }
            set { Session["ActividadesEnRegistro"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.ProductosEnRegistro'
        protected List<OFV.Productos> ProductosEnRegistro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.ProductosEnRegistro'
        {
            get
            {
                if (Session["ProductosEnRegistro"] == null)
                    Session["ProductosEnRegistro"] = new List<OFV.Productos>();
                return (List<OFV.Productos>)Session["ProductosEnRegistro"];
            }
            set { Session["ProductosEnRegistro"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.SociosEnRegistro'
        protected List<OFV.Socios> SociosEnRegistro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.SociosEnRegistro'
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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.SociosAdminEnRegistro'
        protected List<OFV.Socios> SociosAdminEnRegistro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.SociosAdminEnRegistro'
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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.SociosAutorizadosFirma'
        protected List<OFV.Socios> SociosAutorizadosFirma
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.SociosAutorizadosFirma'
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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.Representantes'
        protected List<OFV.Personas> Representantes
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.Representantes'
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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.ReferenciasBancariasRegistro'
        protected List<OFV.ReferenciasBancarias> ReferenciasBancariasRegistro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.ReferenciasBancariasRegistro'
        {
            get
            {
                if (Session["ReferenciasBancariasRegistro"] == null)
                    Session["ReferenciasBancariasRegistro"] = new List<OFV.ReferenciasBancarias>();
                return (List<OFV.ReferenciasBancarias>)Session["ReferenciasBancariasRegistro"];
            }
            set { Session["ReferenciasBancariasRegistro"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.ReferenciasComercialesRegistro'
        protected List<OFV.ReferenciasComerciales> ReferenciasComercialesRegistro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.ReferenciasComercialesRegistro'
        {
            get
            {
                if (Session["ReferenciasComercialesRegistro"] == null)
                    Session["ReferenciasComercialesRegistro"] = new List<OFV.ReferenciasComerciales>();
                return (List<OFV.ReferenciasComerciales>)Session["ReferenciasComercialesRegistro"];
            }
            set { Session["ReferenciasComercialesRegistro"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.SucursalesRegistro'
        protected List<OFV.Sucursales> SucursalesRegistro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.SucursalesRegistro'
        {
            get
            {
                if (Session["SucursalesRegistro"] == null)
                    Session["SucursalesRegistro"] = new List<OFV.Sucursales>();
                return (List<OFV.Sucursales>)Session["SucursalesRegistro"];
            }
            set { Session["SucursalesRegistro"] = value; }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.IsFormularionConfirmacion'
        protected bool IsFormularionConfirmacion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.IsFormularionConfirmacion'
        {
            get
            {
                return Session["bIsFormularionConfirmacion"] != null && (bool)Session["bIsFormularionConfirmacion"];
            }
            set
            {
                Session["bIsFormularionConfirmacion"] = value;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.RegistroCargado'
        protected bool RegistroCargado
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.RegistroCargado'
        {
            get { return Session["bRegistroCargadoMod"] != null && (bool) Session["bRegistroCargadoMod"]; }
            set { Session["bRegistroCargadoMod"] = value; }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.EsTransformacion'
        protected bool EsTransformacion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.EsTransformacion'
        {
            get
            {
                return Session["EsTransaformacion"] != null && (bool)Session["EsTransaformacion"];
            }
            set
            {
                Session["EsTransaformacion"] = value;
            }

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.ReciboDGII'
        protected ReciboDGII ReciboDGII
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.ReciboDGII'
        {
            get
            {
                if (Session["ReciboDGII"] == null)
                    Session["ReciboDGII"] = new ReciboDGII();
                return (ReciboDGII)Session["ReciboDGII"];
            }
            set { Session["ReciboDGII"] = value; }
        }

        #endregion

        /// <summary>
        /// Función recursiva que habilita/deshabilita los controles en los formularios de modificación
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="ctrlPermitidos"></param>
        public static void HabilitarControlesMod(Control ctrl, ref IEnumerable<String> ctrlPermitidos)
        {
            var ctrlID = ctrl.ID;
            if (ctrl is WebControl)
            {
                var wctrl = ((WebControl)ctrl);

                if (!String.IsNullOrEmpty(ctrl.ID) //Ignora controles sin ID
                && !ctrlPermitidos.Contains(ctrl.ID) //Ignora controles en la lista de permitidos
                && !ctrlID.ToLower().StartsWith("btn") //Ignora los botones
                && !ctrlID.ToLower().StartsWith("hf") //Ignora los Hidden Fields
                && !ctrlID.ToLower().StartsWith("scriptmanager") //ignora los script managers
                && !ctrlID.ToLower().StartsWith("radajaxmanager") //ignora los rad ajax managers
                && !ctrlID.ToLower().StartsWith("radajaxpanel") //ignora los rad ajax managers
                && !ctrlID.ToLower().StartsWith("pnl") //ignora los paneles que están en el master page
                && !ctrlID.ToLower().StartsWith("lnk") //ignora los enlaces
                && !ctrlID.ToLower().StartsWith("errorbox") //ignora los validation summaries
                && !(ctrl is BaseValidator))
                    wctrl.Enabled = false;
                else
                    wctrl.CssClass = wctrl.CssClass + " editable";

                //Validacion para Textboxes
                if ((wctrl is TextBox && ((TextBox)wctrl).Text.Length == 0) || (wctrl is RadTextBox && ((RadTextBox)wctrl).Text.Length == 0))
                {
                    wctrl.Enabled = true;
                    wctrl.CssClass = wctrl.CssClass + " editable";
                }
            }

            //User controls
            if (ctrl is IOfvUserControl
                && !String.IsNullOrEmpty(ctrl.ID)
                && ctrlPermitidos != null
                && ctrlPermitidos.Count() > 0)
                ((IOfvUserControl)ctrl).Enable(ctrlPermitidos.Contains(ctrlID));

            //Control de socios
            if (ctrlID != null && ctrlID.ToLower().Contains("manejosocios"))
            {
                ((ManejoSocios)ctrl).Enable(ctrlPermitidos.Contains(ctrlID));
                return;
            }

            //Llamada recursiva
            foreach (Control child in ctrl.Controls)
                HabilitarControlesMod(child, ref ctrlPermitidos);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.OnLoad(EventArgs)'
        protected override void OnLoad(EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionPage.OnLoad(EventArgs)'
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
}