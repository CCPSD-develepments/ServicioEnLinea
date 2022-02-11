using CamaraComercio.DataAccess.EF.SRM;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.Website.Helpers;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.Website.Empresas;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using iTextSharp.text;
using iTextSharp.text.pdf;
using CamaraComercio.Website.WSShareBase;
using System.Globalization;
using System.IO;

namespace CamaraComercio.Website.Formularios
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa'
    public partial class SolicitudIinclusionEmpresa : FormularioPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa'
    {
        #region Atributtes
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.camCtrl'
        public CamarasController camCtrl = new CamarasController();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.camCtrl'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.dbContext'
        public CamaraSRMEntities dbContext;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.dbContext'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.socCtrl'
        public SociedadesController socCtrl = new SociedadesController();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.socCtrl'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.perCtrl'
        public PersonaFisicaController perCtrl = new PersonaFisicaController();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.perCtrl'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.registro'
        public DataAccess.EF.SRM.Registros registro;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.registro'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.persona'
        public DataAccess.EF.SRM.Personas persona;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.persona'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.orgGest'
        public List<ViewRegistrosSocios> orgGest = new List<ViewRegistrosSocios>();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.orgGest'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.transaccion'
#pragma warning disable CS0108 // 'SolicitudIinclusionEmpresa.transaccion' hides inherited member 'FormularioPage.transaccion'. Use the new keyword if hiding was intended.
        public OFV.Transacciones transaccion
#pragma warning restore CS0108 // 'SolicitudIinclusionEmpresa.transaccion' hides inherited member 'FormularioPage.transaccion'. Use the new keyword if hiding was intended.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.transaccion'
        {
            get
            {
                return dbWeb.Transacciones.First(t => t.TransaccionId == this.IdTransaciones);
            }
        }

        Camaras camara;
        cvw_SociedadesRegistros sociedadReg;
        PersonasRegistros personaReg;
        OficinaVirtualUserProfile usuarioActual;
        DataAccess.EF.SRM.Direcciones direccion;
        DataAccess.EF.CamaraComun.Sectores sector;
        DataAccess.EF.CamaraComun.Ciudades ciudad;
        OFV.Facturas factura;
        DataAccess.EF.CamaraComun.Servicio serv;
#pragma warning disable CS0169 // The field 'SolicitudIinclusionEmpresa.referenciasBancarias' is never used
        List<DataAccess.EF.SRM.ReferenciasBancarias> referenciasBancarias;
#pragma warning restore CS0169 // The field 'SolicitudIinclusionEmpresa.referenciasBancarias' is never used
#pragma warning disable CS0169 // The field 'SolicitudIinclusionEmpresa.referenciasComerciales' is never used
        List<DataAccess.EF.SRM.ReferenciasComerciales> referenciasComerciales;
#pragma warning restore CS0169 // The field 'SolicitudIinclusionEmpresa.referenciasComerciales' is never used
        List<CamaraComercio.DataAccess.EF.SRM.Sociedades> EntesReg = new List<CamaraComercio.DataAccess.EF.SRM.Sociedades>();
#pragma warning disable CS0169 // The field 'SolicitudIinclusionEmpresa.PersonasAutorizadas' is never used
        List<ViewRegistrosSocios> PersonasAutorizadas;
#pragma warning restore CS0169 // The field 'SolicitudIinclusionEmpresa.PersonasAutorizadas' is never used
        #endregion

        #region Props
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.SociedadId'
        public int SociedadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.SociedadId'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["SociedadId"])) return 0;
                int.TryParse(Request.QueryString["SociedadId"], out int sociedadId);
                return sociedadId;
            }

        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.PersonaId'
        public int PersonaId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.PersonaId'
         {
              get
              {
                  if (string.IsNullOrWhiteSpace(Request.QueryString["PersonaId"])) return 0;
                  int.TryParse(Request.QueryString["PersonaId"], out int sociedadId);
                  return sociedadId;
              }
         }   

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.CantidadCertificaciones'
        public int CantidadCertificaciones
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.CantidadCertificaciones'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["cantidadCertificaciones"])) return 0;
                int.TryParse(Request.QueryString["cantidadCertificaciones"], out int cantCert);
                return cantCert <= 0 ? 0 : cantCert;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.RequiereDocs'
#pragma warning disable CS0108 // 'SolicitudIinclusionEmpresa.RequiereDocs' hides inherited member 'FormularioPage.RequiereDocs'. Use the new keyword if hiding was intended.
        public bool RequiereDocs
#pragma warning restore CS0108 // 'SolicitudIinclusionEmpresa.RequiereDocs' hides inherited member 'FormularioPage.RequiereDocs'. Use the new keyword if hiding was intended.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.RequiereDocs'
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["requiereDocs"])
                            ? Request.QueryString["requiereDocs"] == "1"
                            : false;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.RegistroId'
        public int RegistroId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.RegistroId'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["RegistroId"])) return 0;
                int.TryParse(Request.QueryString["RegistroId"], out int registroId);
                return registroId;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.CamaraId'
#pragma warning disable CS0108 // 'SolicitudIinclusionEmpresa.CamaraId' hides inherited member 'EnvioDatos.CamaraId'. Use the new keyword if hiding was intended.
        public string CamaraId
#pragma warning restore CS0108 // 'SolicitudIinclusionEmpresa.CamaraId' hides inherited member 'EnvioDatos.CamaraId'. Use the new keyword if hiding was intended.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.CamaraId'
        {
            get
            {
                return string.IsNullOrWhiteSpace(Request.QueryString["CamaraId"]) ? string.Empty : Request.QueryString["CamaraId"];
            }
        }

        //public int IdTransaciones
        //{
        //    get
        //    {
        //        if (string.IsNullOrWhiteSpace(Request.QueryString["IdTransaccion"])) return 0;
        //        int.TryParse(Request.QueryString["IdTransaccion"], out int transaccionId);
        //        return transaccionId;
        //    }
        //}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.DbContext'
        public CamaraSRMEntities DbContext
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.DbContext'
        {
            get
            {
                if (dbContext == null) dbContext = new CamaraSRMEntities(DataAccess.EF.Helpers.GetCamaraConnString(CamaraId));
                return dbContext;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.Socios'
        public List<ViewRegistrosSocios> Socios
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.Socios'
        {
            get
            {
                var items = Session["ACTDGENSOC"] != null ? Session["ACTDGENSOC"] as List<ViewRegistrosSocios> : null;
                return items != null ? items : new List<ViewRegistrosSocios>();
            }
            set
            {
                Session["ACTDGENSOC"] = value;
            }
        }
        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.Page_Load(object, EventArgs)'
#pragma warning disable CS0108 // 'SolicitudIinclusionEmpresa.Page_Load(object, EventArgs)' hides inherited member 'EnvioDatos.Page_Load(object, EventArgs)'. Use the new keyword if hiding was intended.
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS0108 // 'SolicitudIinclusionEmpresa.Page_Load(object, EventArgs)' hides inherited member 'EnvioDatos.Page_Load(object, EventArgs)'. Use the new keyword if hiding was intended.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;

            InitInterface();
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.InitInterface()'
        public void InitInterface()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.InitInterface()'
        {
            if (!IsValidRequestParameters()) return;

            if( transaccion.TipoSociedadId != 7)
            {
                #region entities
                camara = camCtrl.FetchByID(this.CamaraId).First();
                registro = DbContext.Registros.FirstOrDefault(d => d.RegistroId == RegistroId);
                sociedadReg = socCtrl.FetchSociedadesRegistroBySociedadId(SociedadId, CamaraId);
                usuarioActual = OficinaVirtualUserProfile.GetUserProfile(transaccion.UserName);

                if (sector != null)
                {
                    ciudad = dbCom.Ciudades.FirstOrDefault(c => c.CiudadId == sector.CiudadId);
                }
                factura = dbWeb.Facturas.FirstOrDefault(t => t.TransaccionId == this.IdTransaciones);

                serv = dbCom.Servicio.FirstOrDefault(s => s.ServicioId == transaccion.ServicioId);
                #endregion

                //litTipoSociedad.Text = sociedadReg.SufijoSociedad;
                // Datos del Gestor
                txtSolicitante.Text = transaccion.Solicitante.ToUpper();
                txtNombreCont.Text = transaccion.NombreContacto;
                //var user = Membership.GetUser(User.Identity.Name);
                //if (user != null) txtEmail.Text = user.Email;

                //Actualizacion de datos: solo para el servicioid= 650, 398, y 401, traer el correo desde transacciones:
                if (transaccion.ServicioId == 650 || transaccion.ServicioId == 401 || transaccion.ServicioId == 398)
                {
                    txtEmail.Text = transaccion.CorreoContacto;
                    this.Formulario.Registro.DireccionEmail = transaccion.CorreoEmpresa;

                    //OfvDbContext = new CamaraWebsiteEntities();

                    //var ofvRegistro = OfvDbContext.Registros.FirstOrDefault(d => d.SrmRegistroId == RegistroId && d.TransaccionId == transaccion.TransaccionId);
                    //if (ofvRegistro != null)
                    //{
                    //    this.Formulario.Registro.DireccionEmail = ofvRegistro.DireccionEmail;
                    //}

                    if (transaccion.CorreoEmpresa == null)
                    {
                        var user = Membership.GetUser(User.Identity.Name);

                        if (user != null)
                        {
                            txtEmail.Text = user.Email;
                        }
                    }
                }
                else// condicion temporal //ep: 2021-10-29
                {
                    var user = Membership.GetUser(User.Identity.Name);
                    if (user != null)
                    {
                        txtEmail.Text = user.Email;
                    }
                }

                txtTelefono.Text = transaccion.TelefonoContacto.FormatTelefono();
                txtCedula.Text = usuarioActual.NumeroDocumento.FormatRnc();

                // llenar los controles de confirmacion de datos
                //camara
                lblCamara.Text = transaccion.CamaraId;
                //Tipo de empresa
                var dbSrm = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(transaccion.CamaraId);
                this.lblEmpresa.Text = dbSrm.SociedadesRegistros.FirstOrDefault(s => s.RegistroId == transaccion.RegistroId).Sociedades.NombreSocial;
                //Tipo de sociedad
                var repTipoSociedad = new DataAccess.EF.Repository<TipoSociedad, CamaraComunEntities>(new CamaraComunEntities());
                var tipoSociedad = repTipoSociedad.SelectByKey(TipoSociedad.PropColumns.TipoSociedadId, transaccion.TipoSociedadId);
                if (tipoSociedad != null) this.lblTipoEmpresa.Text = tipoSociedad.Descripcion.ToUpper();
                else this.lblTipoEmpresa.Text = "N/A";
                //no Reguistro
                lblNoRegistro.Text = string.Format("{0}SD",transaccion.NumeroRegistro);
                //Fecha recepcion
                lblFechaRecepcion.Text = transaccion.Fecha.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                // numero transacio 
                lblTransaccion.Text = transaccion.TransaccionId.ToString();

                // Servicio
                txtServicio.Text = serv.Descripcion;
            }
            else
            {
                #region entities
                camara = camCtrl.FetchByID(this.CamaraId).First();
                persona = DbContext.Personas.FirstOrDefault(d => d.PersonaId == PersonaId);
                personaReg = perCtrl.ObteneByRegistroCamara(PersonaId, CamaraId).FirstOrDefault();
                usuarioActual = OficinaVirtualUserProfile.GetUserProfile(transaccion.UserName);

                direccion = DbContext.Direcciones.FirstOrDefault(d => d.DireccionId == persona.DireccionId);
                sector = dbCom.Sectores.FirstOrDefault(s => s.SectorId == direccion.SectorId);
                if (sector != null)
                {
                    ciudad = dbCom.Ciudades.FirstOrDefault(c => c.CiudadId == sector.CiudadId);
                }
                factura = dbWeb.Facturas.FirstOrDefault(t => t.TransaccionId == this.IdTransaciones);

                serv = dbCom.Servicio.FirstOrDefault(s => s.ServicioId == transaccion.ServicioId);
                #endregion

                //litTipoSociedad.Text = sociedadReg.SufijoSociedad;
                // Datos del Gestor
                txtSolicitante.Text = transaccion.Solicitante.ToUpper();
                txtNombreCont.Text = transaccion.NombreContacto;
                var user = Membership.GetUser(User.Identity.Name);
                if (user != null)
                    txtEmail.Text = user.Email;
                txtTelefono.Text = transaccion.TelefonoContacto.FormatTelefono();
                txtCedula.Text = usuarioActual.NumeroDocumento.FormatRnc();

                // llenar los controles de confirmacion de datos
                //camara
                lblCamara.Text = transaccion.CamaraId;
                //Tipo de empresa
                var dbSrm = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(transaccion.CamaraId);
                var nEmpresa = dbSrm.PersonasRegistros.FirstOrDefault(s => s.RegistroId == transaccion.RegistroId);
                var nombreCompleto = persona.PrimerNombre + " " + persona.SegundoNombre + " " + persona.PrimerApellido + " " + persona.SegundoApellido;
                this.lblEmpresa.Text = nombreCompleto;
                //Tipo de sociedad
                var repTipoSociedad = new DataAccess.EF.Repository<TipoSociedad, CamaraComunEntities>(new CamaraComunEntities());
                var tipoSociedad = repTipoSociedad.SelectByKey(TipoSociedad.PropColumns.TipoSociedadId, transaccion.TipoSociedadId);
                if (tipoSociedad != null) this.lblTipoEmpresa.Text = tipoSociedad.Descripcion;
                else this.lblTipoEmpresa.Text = "N/A";
                //no Reguistro
                lblNoRegistro.Text = transaccion.NumeroRegistro.ToString();
                //Fecha recepcion
                lblFechaRecepcion.Text = transaccion.Fecha.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                // numero transacio 
                lblTransaccion.Text = transaccion.TransaccionId.ToString();

                // Servicio
                txtServicio.Text = serv.Descripcion;
            }

            
        }

        private void SetSucursalesDataSource(List<Suscursales> sucursales)
        {
            //sucursalRepeater.DataSource = sucursales;
            //sucursalRepeater.DataBind();
        }

        private List<Suscursales> LoadSucursales()
        {
            var sucursales = DbContext.Suscursales.Where(s => s.SociedadId == this.SociedadId).ToList();
            return sucursales;
        }

        private void LoadOrgGestor()
        {
            var registroSociosController = new RegistrosSociosController();
            var sociosAdministracion = registroSociosController.FetchAllSociosByRegistroIdAndTipoRelacion(RegistroId, CamaraId, "C");
            orgGest = new List<ViewRegistrosSocios>();

            foreach (var socio in sociosAdministracion)
                if (!orgGest.Any(d => d.SocioId == socio.SocioId)) orgGest.Add(socio);
        }

        private List<ViewRegistrosSocios> LoadSociosAccionistas()
        {
            var registroSociosController = new RegistrosSociosController();
            var sociosAccionistas = registroSociosController.FetchAllSociosByRegistroIdAndTipoRelacion(RegistroId, CamaraId, "A");

            var Socios = new List<ViewRegistrosSocios>();

            foreach (var socio in sociosAccionistas)
                if (!Socios.Any(d => d.SocioId == socio.SocioId)) Socios.Add(socio);

            return Socios;

        }

        private List<ViewRegistrosSocios> LoadSociosAutorizadosAFirma()
        {
            var registroSociosController = new RegistrosSociosController();

            var sociosFirmasAutorizadas = registroSociosController.FetchAllSociosByRegistroIdAndTipoRelacion(RegistroId, CamaraId, "F");

            var Socios = new List<ViewRegistrosSocios>();

            foreach (var socio in sociosFirmasAutorizadas)
                if (!Socios.Any(d => d.SocioId == socio.SocioId)) Socios.Add(socio);

            return Socios;

        }

        private List<ViewRegistrosSocios> LoadcomisariosCuenta()
        {
            var registroSociosController = new RegistrosSociosController();

            var sociosComisarios = registroSociosController.FetchAllSociosByRegistroIdAndTipoRelacion(RegistroId, CamaraId, "O");

            var Socios = new List<ViewRegistrosSocios>();

            foreach (var socio in sociosComisarios)
                if (!Socios.Any(d => d.SocioId == socio.SocioId)) Socios.Add(socio);

            return Socios;

        }

        private bool IsValidRequestParameters()
        {
#pragma warning disable CS0472 // The result of the expression is always 'true' since a value of type 'int' is never equal to 'null' of type 'int?'
            if(IdTransaciones != null)
#pragma warning restore CS0472 // The result of the expression is always 'true' since a value of type 'int' is never equal to 'null' of type 'int?'
            {
                if(IdTransaciones == 0)
                {
                    txtMessageTitle.InnerText = "No hay una transaccion";
                    mainMultiView.SetActiveView(failView);
                    return false;
                }
                var trans = new CamaraWebsiteEntities().Transacciones.FirstOrDefault(x => x.TransaccionId == IdTransaciones);
                if(trans.ServicioId == 686)
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

                    if (IdTransaciones <= 0)
                    {
                        txtMessageTitle.InnerText = "Debe especificar la transaccion";
                        mainMultiView.SetActiveView(failView);
                        return false;
                    }

                    return true;
                }
                else
                {
                    if(PersonaId <= 0)
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
                    if (IdTransaciones <= 0)
                    {
                        txtMessageTitle.InnerText = "Debe especificar la transaccion";
                        mainMultiView.SetActiveView(failView);
                        return false;
                    }
                    return true;
                }
            }
            else
            {
                return false;
            }
            
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.LoadEntesRegulados()'
        public void LoadEntesRegulados()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudIinclusionEmpresa.LoadEntesRegulados()'
        {
            var EntesRegulados = DbContext.ViewRegistrosSocios.Where(v => v.RegistroId == this.RegistroId).ToList();

            foreach (var ente in EntesRegulados)
            {
                var socCtrl = new SociedadesController();

                var sr = socCtrl.FindRegistro(ente.RegistroId, this.CamaraId);
                if (sr != null && sr.Sociedades.EsEnteRegulado)
                    if (!EntesReg.Any(s => sr.SociedadId == s.SociedadId)) EntesReg.Add(sr.Sociedades);
            }
        }
    }
}