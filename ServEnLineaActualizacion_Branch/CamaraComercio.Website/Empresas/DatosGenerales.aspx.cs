using CamaraComercio.DataAccess.EF;
using CamaraComercio.DataAccess.EF.SRM;
using CamaraComercio.Website.Helpers;
using CamaraComercio.Website.WSShareBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Web.Security;
using System.Web.UI.WebControls;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using SRM = CamaraComercio.DataAccess.EF.SRM;

namespace CamaraComercio.Website.Empresas
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales'
    public partial class DatosGenerales : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales'
    {
        #region Attributes

        private DataAccess.EF.CamaraComun.CamaraComunEntities _comunDbContext;
        private CamaraSRMEntities _srmDbContext;
        private OFV.CamaraWebsiteEntities _ofvDbContext;

        #endregion

        #region Properties

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.SociedadId'
        public int SociedadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.SociedadId'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["SociedadId"])) return 0;
                int.TryParse(Request.QueryString["SociedadId"], out int sociedadId);
                return sociedadId;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.RegistroId'
        public int RegistroId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.RegistroId'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["RegistroId"])) return 0;
                int.TryParse(Request.QueryString["RegistroId"], out int registroId);
                return registroId;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.nSolicitud'
        public int nSolicitud
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.nSolicitud'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["nSolicitud"])) return 0;
                int.TryParse(Request.QueryString["nSolicitud"], out int solicitudId);
                return solicitudId;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.CamaraId'
        public string CamaraId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.CamaraId'
        {
            get
            {
                return string.IsNullOrWhiteSpace(Request.QueryString["CamaraId"]) ? string.Empty : Request.QueryString["CamaraId"];
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.Socios'
        public List<OFV.Socios> Socios
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.Socios'
        {
            get
            {
                var items = Session["ACTDGENSOC"] != null ? Session["ACTDGENSOC"] as List<OFV.Socios> : null;
                return items != null ? items : new List<OFV.Socios>();
            }
            set
            {
                Session["ACTDGENSOC"] = value;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.Paises'
        public IList<DataAccess.EF.CamaraComun.Paises> Paises
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.Paises'
        {
            get
            {
                var items = Session["Actualizar_Datos_Generales_Paises"] != null ? Session["Actualizar_Datos_Generales_Paises"] as IList<DataAccess.EF.CamaraComun.Paises> : null;
                return items != null ? items : new List<DataAccess.EF.CamaraComun.Paises>();
            }
            set
            {
                Session["Actualizar_Datos_Generales_Paises"] = value;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.Ciudades'
        public IList<DataAccess.EF.CamaraComun.Ciudades> Ciudades
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.Ciudades'
        {
            get
            {
                var items = Session["Actualizar_Datos_Generales_Ciudades"] != null ? Session["Actualizar_Datos_Generales_Ciudades"] as IList<DataAccess.EF.CamaraComun.Ciudades> : null;
                return items != null ? items : new List<DataAccess.EF.CamaraComun.Ciudades>();
            }
            set
            {
                Session["Actualizar_Datos_Generales_Ciudades"] = value;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.Sectores'
        public IList<DataAccess.EF.CamaraComun.Sectores> Sectores
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.Sectores'
        {
            get
            {
                var items = Session["Actualizar_Datos_Generales_Sectores"] != null ? Session["Actualizar_Datos_Generales_Sectores"] as IList<DataAccess.EF.CamaraComun.Sectores> : null;
                return items != null ? items : new List<DataAccess.EF.CamaraComun.Sectores>();
            }
            set
            {
                Session["Actualizar_Datos_Generales_Sectores"] = value;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.ComunDbContext'
        public DataAccess.EF.CamaraComun.CamaraComunEntities ComunDbContext
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.ComunDbContext'
        {
            get
            {
                if (_comunDbContext == null) _comunDbContext = new DataAccess.EF.CamaraComun.CamaraComunEntities();
                return _comunDbContext;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.SrmDbContext'
        public CamaraSRMEntities SrmDbContext
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.SrmDbContext'
        {
            get
            {
                if (_srmDbContext == null) _srmDbContext = new CamaraSRMEntities(DataAccess.EF.Helpers.GetCamaraConnString(CamaraId));
                return _srmDbContext;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.OfvDbContext'
        public OFV.CamaraWebsiteEntities OfvDbContext
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.OfvDbContext'
        {
            get
            {
                if (_ofvDbContext == null) _ofvDbContext = new OFV.CamaraWebsiteEntities();
                return _ofvDbContext;
            }
        }

        /*private int transaccionId
        {
            get
            {
                var item = Session["Actualizar_Datos_TransaccionID"] != null ? (int)Session["Actualizar_Datos_TransaccionID"] : 0;
                return item;
            }
            set
            {
                Session["Actualizar_Datos_TransaccionID"] = value;
            }
        }*/

        private OFV.Transacciones Transaccion
        {
            get
            {
                var item = Session["Actualizar_Datos_Generales_Transaccion"] != null ? Session["Actualizar_Datos_Generales_Transaccion"] as OFV.Transacciones : null;
                return item;
            }
            set
            {
                Session["Actualizar_Datos_Generales_Transaccion"] = value;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.sectorSelectedId'
        public int sectorSelectedId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.sectorSelectedId'
        {
            get
            {
                var item = (int)Session["sectorSelectedId"];
                return item;
            }
            set
            {
                Session["sectorSelectedId"] = value;
            }
        }


        public string sectorSelectedNombre

        {
            get
            {
                var item = Session["sectorSelectedNombre"].ToString();
                return item;
            }
            set
            {
                Session["sectorSelectedNombre"] = value;
            }
        }

        public string _ServicioId

        {
            get
            {
                var item = Session["sectorSelectedNombre"].ToString();
                return item;
            }
            set
            {
                Session["sectorSelectedNombre"] = value;
            }
        }

        public int Actua_ServicioId //2021-09-07, ServicioActualizacion, Duplicado, Renovacion

        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["nservId"])) return 0;
                int.TryParse(Request.QueryString["nservId"], out int Actua_ServicioId);
                return Actua_ServicioId;
            }
        }

        //ppf
#pragma warning disable CS0109 // The member 'Renovacion.PersonaId' does not hide an accessible member. The new keyword is not required.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Renovacion.PersonaId'
        public new int PersonaId

        {
            get
            {
                return String.IsNullOrWhiteSpace(Request.QueryString["PersonaId"]) ? 0 : int.Parse(Request.QueryString["personaId"]);
            }
            set { Session["personaId"] = value; }
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
            
        }



        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.Page_Load(object, EventArgs)'
        {
           try
            { 

            if (IsPostBack) return;

            // Response.Redirect($"~/Empresas/RevisionDocumentos.aspx{GetQueryString(transaction)}");
            if (nSolicitud == 0 && Transaccion == null)
            {
                //if(transaccionId==0)
                Transaccion = RegisterTransaction();
                
            }
            //if (Transaccion.TransaccionId > 0) // ojo ep
            //{
            //    Transaccion = UpdateTransaction(Transaccion.TransaccionId);
            //}

            

            if (!IsValidRequestParameters()) return;

            InitInterface();

            //2021-09-08: 
            var comentario = Helper.mMensajesActualizacion;

            if (!string.IsNullOrWhiteSpace(comentario))
            {
                pnlComentarioServicio.Visible = true;
                lblMensaje.Visible = true;
                lblMensaje.Text = comentario;
            }


            if (Transaccion != null && Transaccion.ServicioId == 398) // mejorar esta rutina, 2021-09-06:
            {
                pnlDatosGenerales.Visible = false;
                pnlFaxSocios.Visible = false;
                pnlTelefonos.Visible = true;
                pnlPaginasWeb.Visible = false;
                pnlCorreos.Visible = true;
            }
            else
               if (Transaccion != null && Transaccion.ServicioId == 401)
            {
                pnlDatosGenerales.Visible = false;
                pnlFaxSocios.Visible = false;
                pnlTelefonos.Visible = true;
                pnlPaginasWeb.Visible = false;
                pnlCorreos.Visible = true;
            }

            if (string.IsNullOrEmpty(txtCorreoContacto.Text) && string.IsNullOrEmpty(txtCorreoEmpresa.Text) && string.IsNullOrEmpty(txtTelefonoCasa.Text)
                 && string.IsNullOrEmpty(txtTelefonoOficina.Text))
            {
                btnSave.Text = "Actualizar";
            }
            else
            {
                btnSave.Text = "Completar";
            }

            btnSave.Text = "Completar";


            } //errores
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

            }

        }

        private void InitInterface()
        {
            try
            { 

            LoadBancos();
            LoadPaises();
            LoadCiudades();
            LoadSectores();

            LoadSocios();
            SetRepeaterDataSource();

            var queryString = Request.Path + GetQueryString(Transaccion);
            LogTransaccionesMethods.GrabarLogTransacciones(Transaccion.TransaccionId, queryString, false, User.Identity.Name);

            } //errores
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

            }

        }

        private bool CreateFolderOnShareBase(int TransId)
        {
            var db = new OFV.CamaraWebsiteEntities();
            var trans = db.Transacciones.FirstOrDefault(t => t.TransaccionId == TransId);
            if (Helper.ShareBaseEnabled)
            {
                var client = new WSShareBase.OnlineChamberServiceClient();
                BasicOperationResultOfstring resp;
                using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
                {
                    var httpRequestProperty = new HttpRequestMessageProperty();
                    httpRequestProperty.Headers["token"] = Helper.ShareBaseToken;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;

                    resp = client.CreateFolderOnSharebase(trans.TransaccionId.ToString(), Helper.NombreCarpetaShareBase);
                    trans.FolderId = resp.Entity;
                    db.SaveChanges();
                    client.Close();
                }
                return resp.Success;
            }
            else
            {
                return true;
            }
        }

        private bool LoadFromDB(int transactionId)
        {
            try
            { 

            var user = Membership.GetUser(User.Identity.Name);
            //if (user != null)
            //    txtCorreoContacto.Text = user.Email;

           

            #region Registro
            var ofvRegistro = OfvDbContext.Registros.FirstOrDefault(d => d.SrmRegistroId == RegistroId && d.TransaccionId == transactionId);

            if (ofvRegistro == null)
            {
                var registro = SrmDbContext.Registros.FirstOrDefault(d => d.RegistroId == RegistroId);
                var registroM = SrmDbContext.SociedadesRegistros.FirstOrDefault(x => x.RegistroId == registro.RegistroId);

                #region transaccion srm:
              //  var srmTransac = SrmDbContext.Transacciones.FirstOrDefault(d => d.CustomInt2 == registroM.NumeroRegistro);

               // var srmTransac = SrmDbContext.Transacciones.Where(d => d.CustomInt2 == registroM.NumeroRegistro).OrderByDescending(u => u.TransaccionId).FirstOrDefault(); // last

              

                #endregion transaccion srm

                if (registro != null)
                {
                    ofvRegistro = new OFV.Registros
                    {
                        SrmRegistroId = registro.RegistroId,
                        TransaccionId = transactionId,
                        RegistroMercantil = registroM.NumeroRegistro,
                        FechaEmision = registro.FechaEmision,
                        FechaVencimiento = registro.FechaVencimiento,
                        CapitalSocial = registro.CapitalSocial,
                        CapitalAutorizado = registro.CapitalAutorizado,
                        CapitalPagado = registro.CapitalPagado,
                        Activos = registro.Activos,
                        BienesRaices = registro.BienesRaices,
                        FechaInicioOperacion = registro.FechaInicioOperacion,
                        NombreComercial = registro.NombreComercial,
                        RegistroNombreComercial = registro.RegistroNombreComercial,
                        MarcaFabrica = registro.MarcaFabrica,
                        RegistroMarcaFabrica = registro.RegistroMarcaFabrica,
                        PatenteInvencion = registro.PatenteInversion,
                        RegistroPatenteInvencion = registro.RegistroPatenteInversion,
                        NombreOperador = registro.NombreOperador,
                        ActividadNegocio = registro.ActividadNegocio,
                        NumeroSocios = registro.NumeroSocios,
                        TotalAcciones = registro.TotalAcciones,
                        //EsNuevoRegistro = registro.EsNuevoRegistro,
                        DireccionCalle = registro.Direcciones.Calle,
                        DireccionNumero = registro.Direcciones.Numero,
                        DireccionCiudadId = registro.Direcciones.CiudadId,
                        DireccionCiudad = registro.Direcciones.CiudadDescripcion,
                        DireccionSectorId = registro.Direcciones.SectorId,
                        //NombreSolicitante = registro.NombreSolicitante,
                        //CargoSolicitante = registro.CargoSolicitante,
                        GestorUsername = User.Identity.Name.ToLower(),
                        FechaSolicitud = DateTime.Now,
                        //EntidadActiva = registro.EntidadActiva,
                        //EsRenovacion = registro.EsRenovacion,
                        TipoMonedaCapitalSocial = registro.TipoMonedaCapitalSocial,
                        TipoMonedaCapitalAutorizado = registro.TipoMonedaCapitalAutorizado,
                        TipoMonedaCapitalPagado = registro.TipoMonedaCapitalPagado,
                        TipoMonedaActivos = registro.TipoMonedaActivos,
                        TipoMonedaBienesRaices = registro.TipoMonedaBienesRaices,
                        ActividadIdCIUU = registro.ActividadIdCIUU,
                        ActividadCIUU = registro.ActividadCIUU,
                        ActividadIdCIUU2 = registro.ActividadIdCIUU2,
                        ActividadCIUU2 = registro.ActividadCIUU2,
                        Id_Cierre_Fiscal = registro.Id_Cierre_Fiscal,
                        FechaAsamblea1 = registro.FechaAsamblea1,
                        FechaAsamblea2 = registro.FechaAsamblea2,
                        EmpleadosMasculinos = registro.EmpleadosMasculinos,
                        EmpleadosFemeninos = registro.EmpleadosFemeninos,
                        DireccionSitioWeb = registro.Direcciones.SitioWeb,

                        
                        DireccionTelefonoCasa = registro.Direcciones.TelefonoCasa,
                        DireccionTelefonoOficina = registro.Direcciones.TelefonoOficina,
                        DireccionFax = registro.Direcciones.Fax,
                        //new: 2021-08-23
                        DireccionEmail = registro.Direcciones.Email, // empresa
                        CorreoEmpresa = registro.Direcciones.Email, // CorreoEmpresa,                                               
                        CorreoContacto =  user.Email,
                       
                    };

                    OfvDbContext.Registros.AddObject(ofvRegistro);
                    OfvDbContext.SaveChanges();

                    #region Socios 
                    var registroSocios = (from socio in SrmDbContext.ViewRegistrosSocios
                                          join persona in SrmDbContext.Personas on socio.SocioId equals persona.PersonaId
                                          where socio.RegistroId == RegistroId
                                          select new { Socio = socio, Persona = persona }
                                          );

                    foreach (var socioData in registroSocios)
                    {
                        var nacionaliadaid = ComunDbContext.Paises.FirstOrDefault(c => c.Nombre.Equals(socioData.Socio.Nacionalidad)).PaisId;
                        var ofvSocio = new OFV.Socios
                        {
                            RegistroId = ofvRegistro.RegistroId,
                            TransaccionId = transactionId,
                            SrmId = socioData.Socio.ID,
                            SrmSocioId = socioData.Socio.SocioId,
                            PersonaPrimerNombre = socioData.Persona.PrimerNombre,
                            PersonaSegundoNombre = socioData.Persona.SegundoNombre,
                            PersonaPrimerApellido = socioData.Persona.PrimerApellido,
                            PersonaSegundoApellido = socioData.Persona.SegundoApellido,
                            RegistroMercantil = socioData.Socio.NumeroRM,
                            DireccionCiudadId = socioData.Socio.CiudadId,
                            DireccionNombreCiudad = socioData.Socio.Ciudad,
                            DireccionSectorId = socioData.Socio.SectorId,
                            DireccionNombreSector = socioData.Socio.Sector,
                            DireccionCalle = socioData.Socio.Calle,
                            DireccionNumero = socioData.Socio.Numero,
                            DireccionApartadoPostal = socioData.Socio.ApartadoPostal,
                            NacionalidadId = nacionaliadaid,
                            IdentificacionTributariaPais = socioData.Socio.Pais,
                            TipoSocio = socioData.Socio.TipoSocio,
                            TipoRelacion = socioData.Socio.TipoRelacion,
                            Documento = socioData.Socio.Documento?.RemoverFormato(),
                            TipoDocumento = socioData.Persona.TipoDocumento,
                            PersonaEstadoCivil = socioData.Socio.EstadoCivil.ToLower().Equals("soltero(a)") ? "S" : "C",
                            CargoId = socioData.Socio.CargoId,
                            CantidadAcciones = Convert.ToInt32(socioData.Socio.CantidaCuotasAcciones)

                        };
                        OfvDbContext.Socios.AddObject(ofvSocio);
                    }

                    var registroSociedades = (from socio in SrmDbContext.ViewRegistrosSocios
                                              join sociedad in SrmDbContext.Sociedades on socio.SocioId equals sociedad.SociedadId
                                              where socio.RegistroId == RegistroId
                                              select new { Socio = socio, Sociedad = sociedad });

                    foreach (var socioData in registroSociedades)
                    {
                        int nacionalidadid;
                        if (socioData.Socio.Nacionalidad != null)
                            nacionalidadid = ComunDbContext.Paises.FirstOrDefault(x => x.Nombre.Equals(socioData.Socio.Nacionalidad)).PaisId;
                        else
                            nacionalidadid = 0;

                        var ofvSocio = new OFV.Socios
                        {
                            RegistroId = ofvRegistro.RegistroId,
                            TransaccionId = transactionId,
                            SrmId = socioData.Socio.ID,
                            SrmSocioId = socioData.Socio.SocioId,
                            PersonaPrimerNombre = socioData.Sociedad.NombreSocial,
                            DireccionCiudadId = socioData.Socio.CiudadId,
                            DireccionNombreCiudad = socioData.Socio.Ciudad,
                            DireccionSectorId = socioData.Socio.SectorId,
                            DireccionNombreSector = socioData.Socio.Sector,
                            DireccionCalle = socioData.Socio.Calle,
                            DireccionNumero = socioData.Socio.Numero,
                            DireccionApartadoPostal = socioData.Socio.ApartadoPostal,
                            NacionalidadId = nacionalidadid,
                            IdentificacionTributariaPais = socioData.Socio.Pais,
                            TipoSocio = socioData.Socio.TipoSocio,
                            TipoRelacion = socioData.Socio.TipoRelacion,
                            RegistroMercantil = socioData.Socio.NumeroRM,
                            TipoDocumento = "",
                            Documento = socioData.Socio.Documento?.RemoverFormato(),
                            CantidadAcciones = Convert.ToInt32(socioData.Socio.CantidaCuotasAcciones)

                        };
                        OfvDbContext.Socios.AddObject(ofvSocio);
                    }
                    OfvDbContext.SaveChanges();
                    #endregion

                    #region Referencias Comerciales
                    var srmReferenciasComerciales = SrmDbContext.ReferenciasComerciales.Where(a => a.RegistroId == RegistroId).ToList();
                    foreach (var item in srmReferenciasComerciales)
                    {
                        OfvDbContext.ReferenciasComerciales.AddObject(new OFV.ReferenciasComerciales
                        {
                            RegistroId = ofvRegistro.RegistroId,
                            Descripcion = item.Descripcion,
                            FechaModificacion = item.FechaModificacion,
                            TipoReferencia = item.TipoReferencia
                        });
                    }
                    OfvDbContext.SaveChanges();
                    #endregion

                    #region Referencias Bancarias
                    var srmReferenciasBancarias = SrmDbContext.ReferenciasBancarias.Where(a => a.RegistroId == RegistroId).ToList();
                    foreach (var item in srmReferenciasBancarias)
                    {
                        OfvDbContext.ReferenciasBancarias.AddObject(new OFV.ReferenciasBancarias
                        {
                            BancoId = item.BancoId,
                            FechaModificacion = item.FechaModificacion,
                            NombreBanco = item.BancoDescripcion,
                            RegistroId = ofvRegistro.RegistroId
                        });
                    }
                    OfvDbContext.SaveChanges();
                    #endregion

                    #region Sucursales
                    var srmSucursales = SrmDbContext.Suscursales.Where(a => a.SociedadId == SociedadId);
                    foreach (var item in srmSucursales)
                    {
                        int? direccionId = item.DireccionId != null ? item.DireccionId : 0;
                        var direccion = SrmDbContext.Direcciones.First(x => x.DireccionId == direccionId);
                        OfvDbContext.Sucursales.AddObject(new OFV.Sucursales
                        {
                            SociedadId = item.SociedadId,
                            Descripcion = item.Descripcion,
                            DireccionId = item.DireccionId,
                            FechaModificacion = item.FechaModificacion,
                            DireccionCalle = direccion != null ? direccion.Calle : null,
                            DireccionNumero = direccion != null ? direccion.Numero : null,
                            DireccionCiudadId = direccion != null ? direccion.CiudadId : null,
                            DireccionSectorId = direccion != null ? direccion.SectorId : null,
                            DireccionApartadoPostal = direccion != null ? direccion.ApartadoPostal : null,
                            DireccionTelefonoCasa = direccion != null ? direccion.TelefonoCasa : null,
                            DireccionTelefonoOficina = direccion != null ? direccion.TelefonoOficina : null,
                            DireccionExtension = direccion != null ? direccion.Extension : null,
                            DireccionFax = direccion != null ? direccion.Fax : null,
                            DireccionEmail = direccion != null ? direccion.Email : null
                        });
                    }
                    OfvDbContext.SaveChanges();
                    #endregion


                }
                else
                {
                    return false;
                }
            }
            #endregion

            #region Sociedad
            var ofvSociedad = OfvDbContext.Sociedades.FirstOrDefault(d => d.SrmSociedadId == SociedadId && d.TransaccionId == transactionId);

            if (ofvSociedad == null)
            {
                var sociedad = SrmDbContext.Sociedades.FirstOrDefault(d => d.SociedadId == SociedadId);
                if (sociedad != null)
                {
                    ofvSociedad = new OFV.Sociedades
                    {
                        SrmSociedadId = sociedad.SociedadId,
                        TransaccionId = transactionId,
                        RegistroId = ofvRegistro.RegistroId,
                        TipoSociedadId = sociedad.TipoSociedadId,
                        NombreSocial = sociedad.NombreSocial,
                        Rnc = sociedad.Rnc,
                        EsNacional = sociedad.EsNacional,
                        NacionalidadId = sociedad.NacionalidadId,
                        FechaConstitucion = sociedad.FechaConstitucion,
                        DuracionSociedad = sociedad.DuracionSociedad,
                        FechaAsamblea = sociedad.FechaAsamblea,
                        DuraccionDirectiva = sociedad.DuraccionDirectiva,
                        EstatusId = sociedad.EstatusId,
                        EsEnteRegulado = sociedad.EsEnteRegulado,
                        TipoEnteReguladoId = sociedad.TipoEnteReguladoId,
                        NoResolucion = sociedad.NoResolucion,
                        NumeroNaveIndustrial = sociedad.NumeroNaveIndustrial,
                        NombreSiglas = sociedad.NombreSiglas,
                        SiglasConfig = sociedad.SiglasConfig,
                        //AccionesNominales = sociedad.AccionesNominales,
                        //AccionesNoNominales = sociedad.AccionesNoNominales,
                        FechaEnteRegulado = sociedad.FechaEnteRegulado
                    };

                    // Actualizando los datos de dirección desde la sociedad...
                    var direccion = SrmDbContext.Direcciones.FirstOrDefault(d => d.DireccionId == sociedad.DireccionId);
                    ofvRegistro.DireccionApartadoPostal = ofvRegistro.DireccionApartadoPostal ?? direccion?.ApartadoPostal;
                    ofvRegistro.DireccionCalle = ofvRegistro.DireccionCalle ?? direccion?.Calle;
                    ofvRegistro.DireccionCiudad = ofvRegistro.DireccionCiudad ?? direccion?.CiudadDescripcion;
                    ofvRegistro.DireccionCiudadId = ofvRegistro.DireccionCiudadId ?? direccion?.CiudadId;
                    ofvRegistro.DireccionEmail = ofvRegistro.DireccionEmail ?? direccion?.Email;
                    ofvRegistro.DireccionExtension = ofvRegistro.DireccionExtension ?? direccion?.Extension;
                    ofvRegistro.DireccionFax = ofvRegistro.DireccionFax ?? direccion?.Fax;
                    ofvRegistro.DireccionNumero = ofvRegistro.DireccionNumero ?? direccion?.Numero;
                    ofvRegistro.DireccionSectorId = ofvRegistro.DireccionSectorId ?? direccion?.SectorId;
                    ofvRegistro.DireccionSitioWeb = ofvRegistro.DireccionSitioWeb ?? direccion?.SitioWeb;
                    ofvRegistro.DireccionTelefonoCasa = ofvRegistro.DireccionTelefonoCasa ?? direccion?.TelefonoCasa;
                    ofvRegistro.DireccionTelefonoOficina = ofvRegistro.DireccionTelefonoOficina ?? direccion?.TelefonoOficina;

                    OfvDbContext.Sociedades.AddObject(ofvSociedad);
                    OfvDbContext.SaveChanges();
                }
            }
            #endregion

            #region Llenando los datos...
            txtEmpleadosM.Text = ofvRegistro.EmpleadosMasculinos?.ToString();
            txtEmpleadosF.Text = ofvRegistro.EmpleadosFemeninos?.ToString();
            txtPaginaWeb.Text = ofvRegistro.DireccionSitioWeb;
         //   txtCorreo.Text = ofvRegistro.DireccionEmail;
            //txtApartadoPostal.Text = ofvRegistro.DireccionApartadoPostal;
            txtTelefonoCasa.Text = ofvRegistro.DireccionTelefonoCasa?.RemoverFormato();
            txtTelefonoOficina.Text = ofvRegistro.DireccionTelefonoOficina?.RemoverFormato();
            //txtExtension.Text = ofvRegistro.DireccionExtension?.ToString();
            txtFax.Text = ofvRegistro.DireccionFax?.RemoverFormato();
            txtReferenciasComerciales.Text = string.Join("*", ofvRegistro.ReferenciasComerciales.Select(d => d.Descripcion));
            txtRnc.Text = ofvSociedad.Rnc.FormatRnc();
            if (!string.IsNullOrWhiteSpace(ofvSociedad.Rnc))
            {
                var sociedad = SrmDbContext.Sociedades.FirstOrDefault(d => d.SociedadId == SociedadId);
                if(!string.IsNullOrWhiteSpace(sociedad.Rnc.FormatRnc()))
                    txtRnc.ReadOnly = true;
                else
                    txtRnc.ReadOnly = false;
            }
            else
            {
                txtRnc.ReadOnly = false;
            }

            txtNombreComercial.Text = ofvSociedad.NombreSocial;
            txtFechaAsamblea.SelectedDate = ofvSociedad.FechaAsamblea;

            //new actualizacion de datos// 2021-08-23:
           // txtCorreoContacto.Text = ofvRegistro.CorreoContacto;
            txtCorreoContacto.Text = ofvRegistro.CorreoContacto;
            txtCorreoEmpresa.Text = ofvRegistro.CorreoEmpresa;

            LoadBancos();
            foreach (var referenciasBancaria in ofvRegistro.ReferenciasBancarias)
            {
                var item = ddlReferenciasBancarias.Items.FindByValue(referenciasBancaria.BancoId.ToString());
                if (item == null) continue;

                item.Selected = true;
            }
                #endregion

            } //errores
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

            }

            return true;


        }

        private void Save(int transaccionId)
        {
            #region Registro

            var ofvRegistro = OfvDbContext.Registros.FirstOrDefault(d => d.SrmRegistroId == RegistroId && d.TransaccionId == transaccionId);
            if (ofvRegistro != null)
            {
                ofvRegistro.EmpleadosMasculinos = string.IsNullOrEmpty(txtEmpleadosM.Text) ? 0 : Convert.ToInt32(txtEmpleadosM.Text);
                ofvRegistro.EmpleadosFemeninos = string.IsNullOrEmpty(txtEmpleadosF.Text) ? 0 : Convert.ToInt32(txtEmpleadosF.Text);
                ofvRegistro.EmpleadosTotal = ofvRegistro.EmpleadosMasculinos + ofvRegistro.EmpleadosFemeninos;
                ofvRegistro.DireccionSitioWeb = txtPaginaWeb.Text;
                ofvRegistro.DireccionEmail = txtCorreoEmpresa.Text;// txtCorreo.Text;
                //ofvRegistro.DireccionApartadoPostal = txtApartadoPostal.Text;
                ofvRegistro.DireccionTelefonoCasa = txtTelefonoCasa.Text?.RemoverFormato();
                ofvRegistro.DireccionTelefonoOficina = txtTelefonoOficina.Text?.RemoverFormato();
                //ofvRegistro.DireccionExtension = string.IsNullOrWhiteSpace(txtExtension.Text) ? ofvRegistro.DireccionExtension : Convert.ToInt32(txtExtension.Text);
                ofvRegistro.DireccionFax = txtFax.Text;

                //NEW EP:
                ofvRegistro.CorreoEmpresa = txtCorreoEmpresa.Text;
                ofvRegistro.CorreoContacto = txtCorreoContacto.Text;
            }

            OfvDbContext.SaveChanges();

            #endregion

            #region Sociedad

            var ofvSociedad = OfvDbContext.Sociedades.FirstOrDefault(d => d.SrmSociedadId == SociedadId && d.TransaccionId == transaccionId);
            if (ofvSociedad != null)
            {
                ofvSociedad.Rnc = txtRnc.Text.RemoverFormato();
                ofvSociedad.NombreSocial = txtNombreComercial.Text;
                ofvSociedad.FechaAsamblea = txtFechaAsamblea.SelectedDate;
                OfvDbContext.SaveChanges();
            }

            #endregion

            #region Referencias Comerciales
            foreach (var item in ofvRegistro.ReferenciasComerciales.ToList())
            {
                OfvDbContext.ReferenciasComerciales.DeleteObject(item);
            }
            OfvDbContext.SaveChanges();

            var referenciasComerciales = txtReferenciasComerciales.Text.Split('*');
            foreach (var item in referenciasComerciales)
            {
                OfvDbContext.ReferenciasComerciales.AddObject(new OFV.ReferenciasComerciales
                {
                    RegistroId = ofvRegistro.RegistroId,
                    Descripcion = item.ToUpper(),
                    FechaModificacion = DateTime.Now,
                    TipoReferencia = "C",
                    TransaccionId = transaccionId
                });
            }
            OfvDbContext.SaveChanges();

            #endregion

            #region Referencias Bancarias
            Dictionary<string, string> referenciasBancarias = new Dictionary<string, string>();
            foreach (ListItem item in ddlReferenciasBancarias.Items)
            {
                if (item.Selected) referenciasBancarias.Add(item.Value, item.Text);
            }

            foreach (var oldReferenciaBancaria in ofvRegistro.ReferenciasBancarias.ToList())
            {
                OfvDbContext.ReferenciasBancarias.DeleteObject(oldReferenciaBancaria);
            }
            OfvDbContext.SaveChanges();

            foreach (var referenciaBancaria in referenciasBancarias)
            {
                OfvDbContext.ReferenciasBancarias.AddObject(new OFV.ReferenciasBancarias
                {
                    BancoId = int.Parse(referenciaBancaria.Key),
                    FechaModificacion = DateTime.Now,
                    NombreBanco = Convert.ToString(referenciaBancaria.Value),
                    RegistroId = ofvRegistro.RegistroId,
                    TransaccionId = transaccionId
                });
            }
            OfvDbContext.SaveChanges();
            #endregion

            //TODO: cambiar el cambio en todos 
            #region Socios
            var sociosTransaccion = new List<OFV.Socios>();
            //var ofvRegistroSocioTransaccion = OfvDbContext.Registros.FirstOrDefault(d => d.SrmRegistroId == RegistroId && d.TransaccionId == Transaccion.TransaccionId);
            foreach (var socio in OfvDbContext.Socios.Where(x => x.TransaccionId == transaccionId))
            {
                OfvDbContext.Detach(socio);
                sociosTransaccion.Add(socio);
            }

            foreach (var socio in Socios)
            {
                //OfvDbContext.Socios.ApplyCurrentValues(socio);
                foreach (var socioTransa in sociosTransaccion.Where(s => s.SrmSocioId == socio.SrmSocioId))
                {
                    var sourceSocio = OfvDbContext.Socios.FirstOrDefault(x => x.Id == socioTransa.Id && transaccionId == socioTransa.TransaccionId);
                    sourceSocio.RegistroId = socioTransa.RegistroId;
                    sourceSocio.SrmId = socioTransa.SrmId;
                    sourceSocio.SrmSocioId = socioTransa.SrmSocioId;
                    
                    sourceSocio.DireccionCiudadId = socio.DireccionCiudadId != null ? socio.DireccionCiudadId : socioTransa.DireccionCiudadId;
                    sourceSocio.DireccionNombreCiudad = socio.DireccionNombreCiudad != null ? socio.DireccionNombreCiudad : socioTransa.DireccionNombreCiudad;
                    sourceSocio.DireccionSectorId = socio.DireccionSectorId != null ? socio.DireccionSectorId : socioTransa.DireccionSectorId;
                    sourceSocio.DireccionNombreSector = socio.DireccionNombreSector != null ? socio.DireccionNombreSector : socioTransa.DireccionNombreSector;
                    sourceSocio.DireccionCalle = socio.DireccionCalle != null ? socio.DireccionCalle : socioTransa.DireccionCalle;
                    sourceSocio.NacionalidadId = socio.NacionalidadId != null ? socio.NacionalidadId : socioTransa.NacionalidadId;
                    sourceSocio.IdentificacionTributariaPais = socio.IdentificacionTributariaPais != null ? socio.IdentificacionTributariaPais : socioTransa.IdentificacionTributariaPais;
                    sourceSocio.Documento = socio.Documento != null ? socio.Documento : socioTransa.Documento;
                    if(!string.IsNullOrEmpty(socio.PersonaPrimerApellido) || !string.IsNullOrEmpty(socio.PersonaSegundoNombre) || !string.IsNullOrEmpty(socio.PersonaSegundoApellido))
                    sourceSocio.PersonaEstadoCivil = (socio.PersonaEstadoCivil == "Casado(a)") ? "C" : "S";

                    //OfvDbContext.Socios.Attach(sourceSocio);
                    //OfvDbContext.Socios.ApplyCurrentValues(socioTransa);
                }
            }
            OfvDbContext.SaveChanges();

            #endregion
        }

        private OFV.Transacciones RegisterTransaction(int? modeloId = null)
        {
            var repSociedades = new SociedadesController();
           var registro = repSociedades.FindRegistro(this.RegistroId, this.CamaraId) ?? new SociedadesRegistros();

            //para PF:
            var dbSRM = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);
            var ctrlPersona = new SRM.PersonaFisicaController();
            //pf:

            var regActual = dbSRM.PersonasRegistros.Where(a => a.RegistroId == this.RegistroId && a.PersonaId == this.PersonaId)
                            .Select(a => a.Registros).FirstOrDefault();
            
            var personas = ctrlPersona.ObteneByRegistroIdCamara(RegistroId, CamaraId).FirstOrDefault();
            var transaccion = new OFV.Transacciones();

            //  var ofvRegistroPF = OfvDbContext.Registros.FirstOrDefault(d => d.SrmRegistroId == RegistroId && d.TransaccionId == transaccionId);


            if (this.TipoSociedadId != 7)
            {

                transaccion = new OFV.Transacciones
                {
                    Fecha = DateTime.Now,
                    NombreContacto = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                    RegistroId = registro.RegistroId,
                    ModificacionCapital = 0m,
                    CapitalSocial = registro.Registros.CapitalSocial,
                    TipoSociedadId = registro.Sociedades.TipoSociedadId.HasValue ? registro.Sociedades.TipoSociedadId.Value : 0,
                    RNCSolicitante = registro.Sociedades.Rnc,
                    ServicioId = Actua_ServicioId, // 401,
                    UserName = User.Identity.Name.ToLower(),
                    CamaraId = CamaraId,
                    EstatusTransId = Helper.EstatusTransIdNuevo,
                    Solicitante = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante,
                    TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono,
                    FechaAsamblea = registro.Sociedades.FechaAsamblea,
                    NombreSocialPersona = registro.Sociedades.NombreSocial,
                    TipoModeloId = modeloId,
                    NumeroRegistro = registro.NumeroRegistro,
                    Comentario = string.Empty,
                    //2021-08-26// actualizacion:
                    CorreoContacto = txtCorreoContacto.Text,
                    CorreoEmpresa = txtCorreoEmpresa.Text
                };
            }
            else
                       

            if (personas != null)
            {
                 transaccion = new OFV.Transacciones
                {
                    TransaccionId = -1,
                    Fecha = DateTime.Now,
                    NombreContacto = personas.Registros.NombreSolicitante,
                    RegistroId = this.RegistroId,
                    ModificacionCapital = personas.Registros.CapitalSocial,
                    CapitalSocial = personas.Registros.CapitalSocial,
                    TipoSociedadId = this.TipoSociedadId,
                    RNCSolicitante = personas.Personas.Rnc,
                    UserName = User.Identity.Name.ToLower(),
                    CamaraId = this.CamaraId,
                    EstatusTransId = Helper.EstatusTransIdNuevo,
                    Solicitante = personas.Registros.NombreSolicitante,
                   // FechaReciboDGII = personas.Personas.FechaReciboDGII,
                    MontoDGII = 0,// this.ReciboDGII.MontoDGII,
                                  // NoReciboDGII = this.ReciboDGII.NoReciboDGII,
                    CorreoContacto = txtCorreoContacto.Text,
                    CorreoEmpresa = txtCorreoEmpresa.Text,
                    NumeroRegistro = personas.NumeroRegistro,
                     ServicioId = Actua_ServicioId, // 401,

                 };
            }



            var repTransaccion = new DataAccess.EF.OficinaVirtual.TransaccionesRepository();
            repTransaccion.Add(transaccion);


            var result = repTransaccion.Save() > 0;
            //transaccionId = transaccion.TransaccionId;

            if (string.IsNullOrEmpty(transaccion.FolderId))
                CreateFolderOnShareBase(transaccion.TransaccionId);



            //2021-08-26// actualizacion:
            transaccion.CorreoContacto = txtCorreoContacto.Text;// ofvRegistro.CorreoContacto;

            if (transaccion.ServicioId == 398) // mejorar esta rutina, 2021-09-06:
            {
                pnlDatosGenerales.Visible = false;
                pnlFaxSocios.Visible = false;
                pnlTelefonos.Visible = true;
                pnlPaginasWeb.Visible = false;
                pnlCorreos.Visible = true;
            }
            else
                 if (transaccion.ServicioId == 401)
            {
                pnlDatosGenerales.Visible = false;
                pnlFaxSocios.Visible = false;
                pnlTelefonos.Visible = true;
                pnlPaginasWeb.Visible = false;
                pnlCorreos.Visible = true;
            }


            return result ? transaccion : null;
        }

        private OFV.Transacciones UpdateTransaction(long transId, int? modeloId = null)
        {
            var ofvRegistro = OfvDbContext.Registros.FirstOrDefault(d => d.SrmRegistroId == RegistroId && d.TransaccionId == transId);
            var ofvSociedad = OfvDbContext.Sociedades.FirstOrDefault(d => d.SrmSociedadId == SociedadId && d.TransaccionId == transId);

            var transSpecification = new Specification<DataAccess.EF.OficinaVirtual.Transacciones>(x => x.TransaccionId == transId);

            var repTransaccion = new DataAccess.EF.OficinaVirtual.TransaccionesRepository();
            var transaccion = repTransaccion.SelectAll(transSpecification).FirstOrDefault();

            //transaccion.Fecha = DateTime.Now;
            //transaccion.NombreContacto = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante;
            //transaccion.RegistroId = ofvRegistro.SrmRegistroId.Value2();
            //transaccion.ModificacionCapital = 0m;
            //transaccion.CapitalSocial = ofvRegistro.CapitalSocial;
            //transaccion.TipoSociedadId = ofvSociedad.TipoSociedadId.Value2();
            //transaccion.RNCSolicitante = ofvSociedad.Rnc;
          //  transaccion.ServicioId = Actua_ServicioId;// 401;
            //transaccion.UserName = User.Identity.Name.ToLower();
            //transaccion.CamaraId = CamaraId;
            //transaccion.EstatusTransId = Helper.EstatusTransIdNuevo;
            //transaccion.Solicitante = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante;
            transaccion.TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono;
          //  transaccion.FechaAsamblea = ofvSociedad.FechaAsamblea;
          //  transaccion.NombreSocialPersona = ofvSociedad.NombreSocial;
         //   transaccion.TipoModeloId = modeloId;
        //  transaccion.NumeroRegistro = ofvRegistro.RegistroMercantil;
            transaccion.Comentario = string.Empty;

            //2021-08-26// actualizacion:
            transaccion.CorreoContacto = txtCorreoContacto.Text;// ofvRegistro.CorreoContacto;
            transaccion.CorreoEmpresa = txtCorreoEmpresa.Text;// ofvRegistro.CorreoEmpresa;


            //2021-09-21:

            if (transaccion.ServicioId == 398) // mejorar esta rutina, 2021-09-06:
            {
                pnlDatosGenerales.Visible = false;
                pnlFaxSocios.Visible = false;
                pnlTelefonos.Visible = true;
                pnlPaginasWeb.Visible = false;
                pnlCorreos.Visible = true;
            }
            else
            if (transaccion.ServicioId == 401)
            {
                pnlDatosGenerales.Visible = false;
                pnlFaxSocios.Visible = false;
                pnlTelefonos.Visible = true;
                pnlPaginasWeb.Visible = false;
                pnlCorreos.Visible = true;
            }



            var result = repTransaccion.Save() > 0;

            return result ? transaccion : null;
        }

        private void LoadSocios()
        {
            Socios = new List<OFV.Socios>();

            var ofvRegistro = OfvDbContext.Registros.FirstOrDefault(d => d.SrmRegistroId == RegistroId && d.TransaccionId == Transaccion.TransaccionId);
            var f = OfvDbContext.Socios.Where(x => x.RegistroId == ofvRegistro.RegistroId).ToList();
            var socCiudadcioResult = new DataAccess.EF.CamaraComun.Ciudades();
            foreach (var socioData in OfvDbContext.Socios.Where(x => x.RegistroId == ofvRegistro.RegistroId))
            {
                if (!string.IsNullOrEmpty(socioData.PersonaEstadoCivil))
                {
                    socioData.PersonaEstadoCivil = socioData.PersonaEstadoCivil.ToLower().Equals("c") ? "Casado(a)" : "Soltero(a)";
                }
                if (!Socios.Any(d => d.SrmSocioId == socioData.SrmSocioId))
                {
                    if (socioData.DireccionNombreCiudad == null)
                    {
                        using (DataAccess.EF.CamaraComun.CamaraComunEntities dbCamaraComun = new DataAccess.EF.CamaraComun.CamaraComunEntities())
                        {
                            if (socioData.DireccionCiudadId != null)

                                socCiudadcioResult = dbCamaraComun.Ciudades.FirstOrDefault(c => c.PaisId == socioData.DireccionCiudadId);
                                if(socCiudadcioResult != null)
                                    socioData.DireccionNombreCiudad = socCiudadcioResult.Nombre?? null;
                        }
                    }
                    if (socioData.DireccionNombreSector == null)
                    {
                        using (DataAccess.EF.CamaraComun.CamaraComunEntities dbCamaraComun = new DataAccess.EF.CamaraComun.CamaraComunEntities())
                        {
                            socioData.DireccionNombreSector = dbCamaraComun.Sectores.FirstOrDefault(c => c.SectorId == socioData.DireccionSectorId)?.Nombre ?? "N/A";
                        }
                    }
                    OfvDbContext.Socios.Detach(socioData);
                    Socios.Add(socioData);
                }
            }
        }

        private void LoadPaises()
        {
            using (var dbComun = new DataAccess.EF.CamaraComun.CamaraComunEntities())
            {
                Paises = dbComun.Paises.ToList();
            }

            var items = Paises.Select(d => new ListItem
            {
                Value = d.PaisId.ToString(),
                Text = d.Nombre
            }).ToArray();
            ddlSocioPais.Items.Clear();
            ddlSocioPais.Items.AddRange(items);
        }

        private void LoadCiudades()
        {
            using (var dbComun = new DataAccess.EF.CamaraComun.CamaraComunEntities())
            {
                Ciudades = dbComun.Ciudades.ToList();
            }

            var items = Ciudades.Select(d => new ListItem
            {
                Value = d.CiudadId.ToString(),
                Text = d.Nombre
            }).ToArray();
            ddlSocioCiudades.Items.Clear();
            ddlSocioCiudades.Items.AddRange(items);
        }

        private void LoadSectores()
        {
            if (string.IsNullOrWhiteSpace(ddlSocioCiudades.SelectedValue) || !int.TryParse(ddlSocioCiudades.SelectedValue, out int ciudadId))
            {
                Sectores = new List<DataAccess.EF.CamaraComun.Sectores>();
                return;
            }

            using (var dbComun = new DataAccess.EF.CamaraComun.CamaraComunEntities())
            {
                Sectores = dbComun.Sectores.Where(d => d.CiudadId == ciudadId).ToList();
            }

            var items = Sectores.Select(d => new ListItem
            {
                Value = d.SectorId.ToString(),
                Text = d.Nombre
            }).ToArray();
            if (ddlSocioSectores.Items.Count != 0)
            {
                sectorSelectedId = Convert.ToInt32(ddlSocioSectores.SelectedValue);
                sectorSelectedNombre = ddlSocioSectores.SelectedItem.ToString();
            }

            ddlSocioSectores.Items.Clear();
            ddlSocioSectores.Items.AddRange(items);
        }

        private void LoadBancos()
        {
            using (DataAccess.EF.CamaraComun.CamaraComunEntities dbCamaraComun = new DataAccess.EF.CamaraComun.CamaraComunEntities())
            {
                var bancos = dbCamaraComun.Bancos.OrderBy(d => d.Descripcion).ToList();
                var referenciasBancarias = OfvDbContext.ReferenciasBancarias.Where(x => x.TransaccionId == Transaccion.TransaccionId);
                foreach (var banco in bancos)
                {
                    var item = new ListItem
                    {
                        Selected = referenciasBancarias.Any(x => x.BancoId == banco.BancoId),
                        Text = banco.Descripcion,
                        Value = banco.BancoId.ToString()
                    };

                    if (ddlReferenciasBancarias.Items.FindByValue(item.Value) == null) ddlReferenciasBancarias.Items.Add(item);
                }
            }
        }

        private bool IsValidRequestParameters()
        {
            if (SociedadId <= 0)
            {
                txtMessageTitle.InnerText = "Debe especificar la Empresa";
                mainMultiView.SetActiveView(failView);
                return false;
            }

            if (string.IsNullOrWhiteSpace(CamaraId))
            {
                txtMessageTitle.InnerText = "Debe especificar la Cámara";
                mainMultiView.SetActiveView(failView);
                return false;
            }

            if (!LoadFromDB(Transaccion.TransaccionId))
            {
                txtMessageTitle.InnerText = "La Empresa a la que intenta actualizar los datos no existe";
                mainMultiView.SetActiveView(failView);
                return false;
            }

            return true;
        }

        private void SetRepeaterDataSource()
        {
            List<ViewSociosGenerales> socios = new List<ViewSociosGenerales>();
            var paises = ComunDbContext.Paises.ToList();
            foreach (var item in Socios)
            {
                string nacionalidadNombre = string.Empty;
                var paisesResult = paises.FirstOrDefault(c => c.PaisId == item.NacionalidadId);
                if(paisesResult != null)
                    nacionalidadNombre = paisesResult.Nombre;

                socios.Add
                    (
                        new ViewSociosGenerales
                        {
                            SrmId = item.SrmId.ToString(),
                            DireccionApartadoPostal = item.DireccionApartadoPostal,
                            DireccionCalle = item.DireccionCalle,
                            DireccionNombreCiudad = item.DireccionNombreCiudad,
                            DireccionNombreSector = item.DireccionNombreSector,
                            Documento = item.Documento,
                            PersonaEstadoCivil = item.PersonaEstadoCivil,
                            PersonaPrimerApellido = item.PersonaPrimerApellido,
                            PersonaPrimerNombre = item.PersonaPrimerNombre,
                            PersonaSegundoApellido = item.PersonaSegundoApellido,
                            PersonaSegundoNombre = item.PersonaSegundoNombre,
                            Nacionalidad = nacionalidadNombre
                        }
                    );
            }
            sociosRepeater.DataSource = socios;
            sociosRepeater.DataBind();
        }

        private string GetQueryString(OFV.Transacciones transaction)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("?SociedadId={0}", SociedadId);
            stringBuilder.AppendFormat("&RegistroId={0}", RegistroId);
            stringBuilder.AppendFormat("&CamaraId={0}", CamaraId);
            stringBuilder.AppendFormat("&EsCertificacion={0}", 0);
            stringBuilder.AppendFormat("&EntregaDigital={0}", false);

            var servicio = ComunDbContext.Servicio.FirstOrDefault(d => d.ServicioId == transaction.ServicioId);
            if (servicio == null) stringBuilder.AppendFormat("&TipoServicioId={0}", servicio.ServicioId);
            else stringBuilder.AppendFormat("&TipoServicioId={0}", servicio.TipoServicioId);

            stringBuilder.AppendFormat("&TipoSociedadId={0}", transaction.TipoSociedadId);
            stringBuilder.AppendFormat("&nSolicitud={0}", transaction.TransaccionId);


            if (transaction != null)
            {
                var context = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);
                var trSDQ = context.Transacciones.FirstOrDefault(x => x.TransaccionIdAnterior == transaction.TransaccionId && x.DesdeOfv);
                if (trSDQ != null)
                    if (trSDQ.VieneProblemas) stringBuilder.AppendFormat("&BorrarDocumentos={0}", "true");
                
            }

            return stringBuilder.ToString();
        }



#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.btnSave_Click(object, EventArgs)'
        protected void btnSave_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.btnSave_Click(object, EventArgs)'
        {
            var helper = new TransaccionDevueltaHelper(Request);
            //if (!helper.EstaDevuelta())
            //{
            //    //transaccion = RegisterTransaction();
            //    if (Transaccion != null)
            //    {
            //        var servicio = ComunDbContext.Servicio.FirstOrDefault(d => d.ServicioId == Transaccion.ServicioId);
            //        if (servicio == null) stringBuilder.AppendFormat("&TipoServicioId={0}", servicio.ServicioId);
            //        else stringBuilder.AppendFormat("&TipoServicioId={0}", servicio.TipoServicioId);

            //        stringBuilder.AppendFormat("&TipoSociedadId={0}", Transaccion.TipoSociedadId);
            //        stringBuilder.AppendFormat("&nSolicitud={0}", Transaccion.TransaccionId);

            //        Save();
            //        Response.Redirect($"~/Empresas/RevisionDocumentos.aspx{stringBuilder.ToString()}");
            //    }
            //}
            //else
            //{
            var transaction = UpdateTransaction(Transaccion.TransaccionId);
            if (transaction != null)
            {
                Save(transaction.TransaccionId);
                Transaccion = null;
                Response.Redirect($"~/Empresas/RevisionDocumentos.aspx{GetQueryString(transaction)}");
            }
        }
        //}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.sociosRepeater_ItemCommand(object, RepeaterCommandEventArgs)'
        protected void sociosRepeater_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.sociosRepeater_ItemCommand(object, RepeaterCommandEventArgs)'
        {
            switch (e.CommandName.ToLower())
            {
                case "edit":
                    if (e.CommandArgument == null) return;
                    if (!int.TryParse(e.CommandArgument.ToString(), out int socioId)) return;

                    var socio = Socios.FirstOrDefault(d => d.SrmId == socioId);
                    if (socio == null) return;

                    txtSocioId.Value = socio.SrmId.ToString();

                    if(socio.NacionalidadId != 0)
                        ddlSocioPais.SelectedValue = socio.NacionalidadId?.ToString();

                    txtSocioNombre.Text = string.Format("{0} {1} {2} {3}", socio.PersonaPrimerNombre, socio.PersonaSegundoNombre, socio.PersonaPrimerApellido, socio.PersonaSegundoApellido);
                    if (socio.PersonaEstadoCivil != null)
                    {
                        divEstadoCivil.Visible = true;
                        ddlSocioEstadoCivil.SelectedValue = socio.PersonaEstadoCivil.ToLower().Equals("soltero(a)") ? "S" : "C";
                    }
                    else if (socio.PersonaEstadoCivil == null)
                    {
                        divEstadoCivil.Visible = false;
                    }
                    txtSocioDocumento.Text = socio.Documento;
                    if (socio.PersonaPrimerApellido == null || socio.PersonaPrimerApellido == string.Empty)
                    {
                        lblSocioDocumento.Visible = false;
                        txtSocioDocumento.Visible = false;
                    }
                    else
                    {
                        lblSocioDocumento.Visible = true;
                        txtSocioDocumento.Visible = true;
                    }
                    if (socio.TipoDocumento == "P") txtSocioDocumento.ReadOnly = false;
                    else txtSocioDocumento.ReadOnly = true;

                    ddlSocioCiudades.SelectedValue = socio.DireccionCiudadId?.ToString();
                    LoadSectores();
                    ddlSocioSectores.SelectedValue = socio.DireccionSectorId?.ToString();
                    txtSocioDireccionCalle.Text = socio.DireccionCalle;
                    txtSocioDireccionNumero.Text = socio.DireccionNumero;
                    txtSocioDireccionApartadoPostal.Text = socio.DireccionApartadoPostal;

                    lblSocioDireccionNumero.Visible = false;
                    txtSocioDireccionNumero.Visible = false;
                    lblSocioDireccionApartadoPostal.Visible = false;
                    txtSocioDireccionApartadoPostal.Visible = false;

                    mainMultiView.SetActiveView(socioEditView);
                    break;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.btnCancelSocio_Click(object, EventArgs)'
        protected void btnCancelSocio_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.btnCancelSocio_Click(object, EventArgs)'
        {
            mainMultiView.SetActiveView(succesfullView);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.btnSaveSocio_Click(object, EventArgs)'
        protected void btnSaveSocio_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.btnSaveSocio_Click(object, EventArgs)'
        {
            if (string.IsNullOrWhiteSpace(ddlSocioPais.SelectedValue))
            {
                Master.ShowMessageError("Debe seleccionar un País");
                return;
            }

            if (string.IsNullOrWhiteSpace(ddlSocioEstadoCivil.SelectedValue))
            {
                Master.ShowMessageError("Debe seleccionar un Estado Civil");
                return;
            }

            //if (string.IsNullOrWhiteSpace(txtSocioDocumento.Text))
            //{
            //    Master.ShowMessageError("El Documento es requerido");
            //    return;
            //}

            if (string.IsNullOrWhiteSpace(ddlSocioCiudades.SelectedValue))
            {
                Master.ShowMessageError("Debe seleccionar una Ciudad");
                return;
            }

            if (string.IsNullOrWhiteSpace(ddlSocioSectores.SelectedValue))
            {
                Master.ShowMessageError("Debe seleccionar un Sector");
                return;
            }

            //if (string.IsNullOrWhiteSpace(txtSocioDireccionCalle.Text))
            //{
            //    Master.ShowMessageError("La Calle es requerida");
            //    return;
            //}

            //if (string.IsNullOrWhiteSpace(txtSocioDireccionNumero.Text))
            //{
            //    Master.ShowMessageError("El Número es requerido");
            //    return;
            //}

            int.TryParse(txtSocioId.Value, out int socioId);
            if (socioId <= 0)
            {
                Master.ShowMessageError("El Socio no existe");
                return;
            }

            var item = Socios.FirstOrDefault(d => d.SrmId == socioId);
            if (item == null)
            {
                Master.ShowMessageError("El Socio no existe");
                return;
            }

            var index = Socios.IndexOf(item);

            Socios[index].SrmId = socioId;
            Socios[index].NacionalidadId = Convert.ToInt32(ddlSocioPais.SelectedValue);
            //Socios[index].Pais = ddlSocioPais.SelectedItem.Text;
            if (ddlSocioEstadoCivil.SelectedValue.ToLower().Equals("d"))
            {
                Socios[index].PersonaEstadoCivil = null;
            }
            else
            {
                Socios[index].PersonaEstadoCivil = ddlSocioEstadoCivil.SelectedValue.ToLower().Equals("c") ? "Casado(a)" : "Soltero(a)";
            }
            if (Socios[index].TipoDocumento == "P")
            {
                Socios[index].Documento = txtSocioDocumento.Text;
            }

            //Socios[index].Ciudad = ddlSocioCiudades.SelectedItem.Text;
            Socios[index].DireccionCiudadId = Convert.ToInt32(ddlSocioCiudades.SelectedValue);
            //Socios[index].Sector = ddlSocioSectores.SelectedItem.Text;
            LoadSectores();
            Socios[index].DireccionSectorId = Convert.ToInt32(ddlSocioSectores.SelectedValue);
            Socios[index].DireccionCalle = txtSocioDireccionCalle.Text.ToUpper();
            Socios[index].DireccionNumero = txtSocioDireccionNumero.Text;
#pragma warning disable CS0472 // The result of the expression is always 'true' since a value of type 'int' is never equal to 'null' of type 'int?'
            Socios[index].DireccionSectorId = sectorSelectedId != null ? sectorSelectedId : Convert.ToInt32(ddlSocioSectores.SelectedValue);
#pragma warning restore CS0472 // The result of the expression is always 'true' since a value of type 'int' is never equal to 'null' of type 'int?'
            Socios[index].DireccionNombreSector = String.IsNullOrEmpty(sectorSelectedNombre) ? ddlSocioSectores.SelectedItem.ToString() : sectorSelectedNombre;
            Socios[index].DireccionCiudadId = Convert.ToInt32(ddlSocioCiudades.SelectedValue);
            Socios[index].DireccionNombreCiudad = ddlSocioCiudades.SelectedItem.ToString();
            Socios[index].DireccionApartadoPostal = txtSocioDireccionApartadoPostal.Text;

            SetRepeaterDataSource();
            mainMultiView.SetActiveView(succesfullView);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.ddlSocioCiudades_SelectedIndexChanged(object, EventArgs)'
        protected void ddlSocioCiudades_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.ddlSocioCiudades_SelectedIndexChanged(object, EventArgs)'
        {
            LoadSectores();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.btnCancel_Click(object, EventArgs)'
        protected void btnCancel_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.btnCancel_Click(object, EventArgs)'
        {
            Response.Redirect(Helper.NoboxMainpage);
        }

        protected void txtCorreoEmpresa_TextChanged(object sender, EventArgs e)
        {
            var valorActual = txtCorreoEmpresa.Text;
        }


        //2021-10-08:
        protected void btnSaveEmpty_Click(object sender, EventArgs e)
        {
            return;
        }

    }
    //

    public class ViewSociosGenerales

    {

        public string SrmId { get; set; }

        public string PersonaPrimerNombre { get; set; }

        public string PersonaSegundoNombre { get; set; }

        public string PersonaPrimerApellido { get; set; }

        public string PersonaSegundoApellido { get; set; }

        public string DireccionCalle { get; set; }

        public string DireccionApartadoPostal { get; set; }

        public string DireccionNombreSector { get; set; }

        public string DireccionNombreCiudad { get; set; }

        public string Nacionalidad { get; set; }

        public string PersonaEstadoCivil { get; set; }

        public string Documento { get; set; }

    }
}