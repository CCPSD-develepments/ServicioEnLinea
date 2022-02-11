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
using SRM = CamaraComercio.DataAccess.EF.SRM;

namespace CamaraComercio.Website.Formularios
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL'
    public partial class SociedadEIRL : FormularioPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL'
    {
        #region Atributtes
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.camCtrl'
        public CamarasController camCtrl = new CamarasController();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.camCtrl'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.dbContext'
        public CamaraSRMEntities dbContext;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.dbContext'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.socCtrl'
        public SociedadesController socCtrl = new SociedadesController();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.socCtrl'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.registro'
        public DataAccess.EF.SRM.Registros registro;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.registro'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.orgGest'
        public List<ViewRegistrosSocios> orgGest = new List<ViewRegistrosSocios>();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.orgGest'

#pragma warning disable CS0108 // 'SociedadEIRL.transaccion' hides inherited member 'FormularioPage.transaccion'. Use the new keyword if hiding was intended.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.transaccion'
        public OFV.Transacciones transaccion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.transaccion'
#pragma warning restore CS0108 // 'SociedadEIRL.transaccion' hides inherited member 'FormularioPage.transaccion'. Use the new keyword if hiding was intended.
        {
            get
            {
                return dbWeb.Transacciones.First(t => t.TransaccionId == this.IdTransaciones);
            }
        }

#pragma warning disable CS0169 // The field 'SociedadEIRL.camara' is never used
        Camaras camara;
#pragma warning restore CS0169 // The field 'SociedadEIRL.camara' is never used
#pragma warning disable CS0169 // The field 'SociedadEIRL.sociedadReg' is never used
        cvw_SociedadesRegistros sociedadReg;
#pragma warning restore CS0169 // The field 'SociedadEIRL.sociedadReg' is never used
        OficinaVirtualUserProfile usuarioActual;
#pragma warning disable CS0169 // The field 'SociedadEIRL.direccion' is never used
        DataAccess.EF.SRM.Direcciones direccion;
#pragma warning restore CS0169 // The field 'SociedadEIRL.direccion' is never used
#pragma warning disable CS0169 // The field 'SociedadEIRL.sector' is never used
        DataAccess.EF.CamaraComun.Sectores sector;
#pragma warning restore CS0169 // The field 'SociedadEIRL.sector' is never used
#pragma warning disable CS0169 // The field 'SociedadEIRL.ciudad' is never used
        DataAccess.EF.CamaraComun.Ciudades ciudad;
#pragma warning restore CS0169 // The field 'SociedadEIRL.ciudad' is never used
#pragma warning disable CS0169 // The field 'SociedadEIRL.factura' is never used
        OFV.Facturas factura;
#pragma warning restore CS0169 // The field 'SociedadEIRL.factura' is never used
        DataAccess.EF.CamaraComun.Servicio serv;
        DataAccess.EF.CamaraComun.TipoServicio tipServ;
#pragma warning disable CS0169 // The field 'SociedadEIRL.referenciasBancarias' is never used
        List<DataAccess.EF.SRM.ReferenciasBancarias> referenciasBancarias;
#pragma warning restore CS0169 // The field 'SociedadEIRL.referenciasBancarias' is never used
#pragma warning disable CS0169 // The field 'SociedadEIRL.referenciasComerciales' is never used
        List<DataAccess.EF.SRM.ReferenciasComerciales> referenciasComerciales;
#pragma warning restore CS0169 // The field 'SociedadEIRL.referenciasComerciales' is never used
        #endregion
        List<CamaraComercio.DataAccess.EF.SRM.Sociedades> EntesReg = new List<CamaraComercio.DataAccess.EF.SRM.Sociedades>();
#pragma warning disable CS0169 // The field 'SociedadEIRL.PersonasAutorizadas' is never used
        List<ViewRegistrosSocios> PersonasAutorizadas;
#pragma warning restore CS0169 // The field 'SociedadEIRL.PersonasAutorizadas' is never used
        #region Props
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.SociedadId'
        public int SociedadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.SociedadId'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["SociedadId"])) return 0;
                int.TryParse(Request.QueryString["SociedadId"], out int sociedadId);
                return sociedadId;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.CantidadCertificaciones'
        public int CantidadCertificaciones
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.CantidadCertificaciones'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["cantidadCertificaciones"])) return 0;
                int.TryParse(Request.QueryString["cantidadCertificaciones"], out int cantCert);
                return cantCert <= 0 ? 0 : cantCert;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.RegistroId'
        public int RegistroId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.RegistroId'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["RegistroId"])) return 0;
                int.TryParse(Request.QueryString["RegistroId"], out int registroId);
                return registroId;
            }
        }

#pragma warning disable CS0108 // 'SociedadEIRL.CamaraId' hides inherited member 'EnvioDatos.CamaraId'. Use the new keyword if hiding was intended.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.CamaraId'
        public string CamaraId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.CamaraId'
#pragma warning restore CS0108 // 'SociedadEIRL.CamaraId' hides inherited member 'EnvioDatos.CamaraId'. Use the new keyword if hiding was intended.
        {
            get
            {
                return string.IsNullOrWhiteSpace(Request.QueryString["CamaraId"]) ? string.Empty : Request.QueryString["CamaraId"];
            }
        }



#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.DbContext'
        public CamaraSRMEntities DbContext
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.DbContext'
        {
            get
            {
                if (dbContext == null) dbContext = new CamaraSRMEntities(DataAccess.EF.Helpers.GetCamaraConnString(CamaraId));
                return dbContext;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.Socios'
        public List<ViewRegistrosSocios> Socios
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.Socios'
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.Page_Load(object, EventArgs)'
#pragma warning disable CS0108 // 'SociedadEIRL.Page_Load(object, EventArgs)' hides inherited member 'EnvioDatos.Page_Load(object, EventArgs)'. Use the new keyword if hiding was intended.
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS0108 // 'SociedadEIRL.Page_Load(object, EventArgs)' hides inherited member 'EnvioDatos.Page_Load(object, EventArgs)'. Use the new keyword if hiding was intended.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;

            InitInterface();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.InitInterface()'
        public void InitInterface()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.InitInterface()'
        {
            try { 

            if (!IsValidRequestParameters()) return;

            if (transaccion.ServicioId == 650)
            {
                bool a = SetFormularioModelViewOFV(transaccion.TransaccionId, RegistroId, SociedadId);
                if (!a)
                {
                    return;
                }
            }
            else
            {
                bool a = SetFormularioModelViewSRM(transaccion.TransaccionId, RegistroId, SociedadId);
                if (!a)
                {
                    return;
                }
            }
            var dbSRM = new SRM.CamaraSRMEntities(DataAccess.EF.Helpers.GetCamaraConnString(transaccion.CamaraId));
            var sucursales = LoadSucursales();
            var estatus = dbCom.EstadoRegistro.FirstOrDefault(a => a.EstadoRegistroId == Formulario.Sociedad.EstatusId);
            serv = dbCom.Servicio.FirstOrDefault(s => s.ServicioId == transaccion.ServicioId);
            tipServ = dbCom.TipoServicio.FirstOrDefault(s => serv.TipoServicioId == s.TipoServicioId);
            //litTipoSociedad.Text = sociedadReg.SufijoSociedad;
            // Datos del Gestor
            //txtSolicitante.Text = transaccion.Solicitante.ToUpper();
            txtNombreCont.Text = !string.IsNullOrEmpty(transaccion.NombreContacto) ? transaccion.NombreContacto.ToUpper() : transaccion.NombreContacto;
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
            //txtRNC1.Text = transaccion.RNCSolicitante.FormatRnc();
            txtTelefono.Text = transaccion.TelefonoContacto.FormatTelefono();

            usuarioActual = OficinaVirtualUserProfile.GetUserProfile(transaccion.UserName);
            txtCedula.Text = usuarioActual.NumeroDocumento.FormatRnc();

            // Datos de la sociedad
            txtRazSocial.Text = this.Formulario.Sociedad.NombreSocial;
            txtTipoSocietario.Text = dbCom.TipoSociedad.FirstOrDefault(x => x.TipoSociedadId == this.Formulario.Sociedad.TipoSociedadId).Descripcion;
            txtDuracionSociedad.Text = this.Formulario.Sociedad.DuracionSociedad.Equals("DEFINIDA") ? this.Formulario.Sociedad.DuraccionDirectiva.ToString() : this.Formulario.Sociedad.DuracionSociedad;
            txtNoRegistro.Text = string.Format("{0}SD", this.Formulario.Registro.RegistroMercantil);
            txtRNCSoc.Text = !string.IsNullOrWhiteSpace(this.Formulario.Sociedad.Rnc) 
                ? this.Formulario.Sociedad.Rnc.FormatRnc(): "N/A";
            var direcionCalle = !string.IsNullOrWhiteSpace(this.Formulario.Registro.DireccionCalle)
                ? this.Formulario.Registro.DireccionCalle + "," : "";
            var direccionSector = !string.IsNullOrWhiteSpace(this.Formulario.Registro.DireccionSector)
                ? this.Formulario.Registro.DireccionSector + "," : "";
            var direccionCiudad = !string.IsNullOrWhiteSpace(this.Formulario.Registro.DireccionCiudad)
                ? this.Formulario.Registro.DireccionCiudad + "." : "";

            txtDireccionSociedad.Text = string.Format(
                "{0} {1} {2}",
                direcionCalle,
                direccionSector,
                direccionCiudad
                );

            txtTel1.Text = this.Formulario.Registro.DireccionTelefonoCasa.FormatTelefono();
            txtTel2.Text = this.Formulario.Registro.DireccionTelefonoOficina.FormatTelefono();
            txtCorreoSociedad.Text = IsNullorEmptyNA(this.Formulario.Registro.DireccionEmail);
            txtPagWeb.Text = IsNullorEmptyNA(this.Formulario.Registro.DireccionSitioWeb);
            if (Formulario.Sociedad.NacionalidadId != null)
                txtNacionalidad.Text = dbCom.Paises.FirstOrDefault(c => c.PaisId == Formulario.Sociedad.NacionalidadId).Nombre;
            else
                txtNacionalidad.Text = "N/A";
            txtFechaEmision.Text = FormatoFecha(this.Formulario.Registro.FechaEmision);
            txtFechaVenc.Text = FormatoFecha(this.Formulario.Registro.FechaVencimiento);
            txtFechaConst.Text = FormatoFecha(this.Formulario.Sociedad.FechaConstitucion);
            
            txtEstadoSociedad.Text = estatus != null ? estatus.Descripcion : "N/A";
            // Empleadoas
            txtMasculino.Text = this.Formulario.Registro.EmpleadosMasculinos.ToString();
            txtFemenino.Text = this.Formulario.Registro.EmpleadosFemeninos.ToString();
            txtTotal.Text = this.Formulario.Registro.EmpleadosTotal.ToString();
            //nombre comercial
            txtNombreComercial.Text = IsNullorEmptyNA(this.Formulario.Registro.NombreComercial);
            txtRegitroNComercial.Text = IsNullorEmptyNA(this.Formulario.Registro.RegistroNombreComercial);
            // desc
            txtDesc.Text = IsNullorEmptyNA(this.Formulario.Registro.ActividadNegocio);
            var actividades = dbSRM.RegistrosActividades.Where(c => c.RegistroId == Formulario.Registro.SrmRegistroId);
            foreach (var item in actividades)
            {
                if (string.IsNullOrWhiteSpace(txtActividad.Text))
                    txtActividad.Text = item.TipoActividadDescripcion + ", ";
                else
                    txtActividad.Text += item.TipoActividadDescripcion + ", ";

            }
            if (actividades.Count() == 0)
                txtActividad.Text = "N/A";
            else if (!string.IsNullOrWhiteSpace(txtActividad.Text))
            {
                int fin;
                fin = txtActividad.Text.Length - 2;
                var result = txtActividad.Text.Substring(0, fin);
                txtActividad.Text = result;
                txtActividad.Text = txtActividad.Text + ".";
            }
            //Capital social
            txtMonto.Text = string.Format("{0:c}", this.Formulario.Registro.CapitalAutorizado != null ? this.Formulario.Registro.CapitalAutorizado : 0);
            txtMoneda.Text = dbCom.TipoMoneda.FirstOrDefault(c => c.TipoMonedaId == Formulario.Registro.TipoMonedaCapitalAutorizado).Abreviatura;
            //
            //txtDuracionOrganoGestor.Text = this.Formulario.Sociedad.DuracionSociedad;
            this.txtFechaAsamb.Text = FormatoFecha(Formulario.Sociedad.FechaAsamblea);

            // Servicio
            txtServicio.Text = tipServ.Descripcion.ToUpper() + " - " + serv.Descripcion;

            // Sucursales
            SetSucursalesDataSource(sucursales);
            /*if(sucursales.Count == 0)
            {
                lbSucursales.Visible = true;
                tblSucursales.Visible = false;
            }*/


            //Socios
            SetSociosDataSource(Formulario.Socios.ToList());
            SetProducto(dbSRM.Productos.Where(p => p.RegistroId == Formulario.Registro.SrmRegistroId).ToList());
            //OrganoGestion
            SetOrgGestorDataSource(Formulario.OrganoGestion.ToList());

            // Socios con Firmas autorizadas
            var autorizados = Formulario.SociosFirmas.ToList();
            SetSociosAutorizadosDataSource(autorizados);
            SetComisario(Formulario.Comisarios.ToList());
            //Load Entes Regulados
            LoadEntesRegulados();
            SetEntesRegDataSource();

            //if(EntesReg.Count == 0)
            //{
            //    lbEntesReg.Visible = true;
            //    tblEntesReg.Visible = false;
            //}
            //Referencias Comerciales
            txtReferenciasComerciales.Text = string.Join(",", Formulario.ReferenciaComercial.Select(d => d.Descripcion));
            if (string.IsNullOrEmpty(txtReferenciasComerciales.Text))
                txtReferenciasComerciales.Text = "N/A";

            // Referencias Bancarias
            txtRefBancarias.Text = string.Join(",", Formulario.ReferenciaBancaria.Select(d => d.NombreBanco));
            if (string.IsNullOrEmpty(txtRefBancarias.Text))
                txtRefBancarias.Text = "N/A";


            var trans = TransaccionesController.GetTransaccionById(IdTransaciones);
            if (string.IsNullOrEmpty(trans.FolderId))
                CreateFolderOnShareBase(trans.TransaccionId);

            } //errores
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

            }

        }

        private string FormatoFecha(DateTime? fecha)
        {
            string result = "N/A";

            if (fecha != null)
                result = string.Format("{0:dd/MM/yyyy}", fecha);

            return result;
        }

        private string IsNullorEmptyNA(string val)
        {
            string result = !string.IsNullOrWhiteSpace(val)
                ? val : "N/A";
            return result;
        }

        private void SetProducto(List<SRM.Productos> productos)
        {
            if (productos.Count() < 1)
            {
                this.productos.Visible = false;
            }
            else
            {
                productosRepeater.DataSource = productos;
                productosRepeater.DataBind();
            }
        }

        private void SetComisario(List<Comisario> comisarios)
        {
            if (comisarios.Count() < 1)
            {
                ComisarioDiv.Visible = false;
            }
            else
            {
                sociosComisario.DataSource = comisarios;
                sociosComisario.DataBind();
            }
        }

        private void SetSociosDataSource(List<Socio> socios)
        {
            if (socios.Count() < 1)
            {
                propietarioDiv.Visible = false;
            }
            else
            {
                sociosRep.DataSource = socios;
                sociosRep.DataBind();
            }
        }

        private void SetOrgGestorDataSource(List<OrganoGestion> organoGestions)
        {
            if (organoGestions.Count() < 1)
            {
                GestorDiv.Visible = false;
            }
            else
            {
                orgGestionRepeater.DataSource = organoGestions;
                orgGestionRepeater.DataBind();
            }
        }

        private void SetSociosAutorizadosDataSource(List<SociosFirmas> SociosAut)
        {
            if (SociosAut.Count() < 1)
            {
                firmaDiv.Visible = false;
            }
            else
            {
                sociosAutRep.DataSource = SociosAut;
                sociosAutRep.DataBind();
            }
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

        private void SetSucursalesDataSource(List<Suscursales> sucursales)
        {
            if (sucursales.Count() < 1)
            {
                this.sucursales.Visible = false;
            }
            else
            {
                sucursalRepeater.DataSource = sucursales;
                sucursalRepeater.DataBind();
            }
        }

        private List<Suscursales> LoadSucursales()
        {
            var sucursales = DbContext.Suscursales.Where(s => s.SociedadId == this.SociedadId).ToList();
            return sucursales;
        }

        private List<ViewRegistrosSocios> LoadOrgGestor()
        {
            var registroSociosController = new RegistrosSociosController();
            return registroSociosController.FetchAllSociosByRegistroIdAndTipoRelacion(RegistroId, CamaraId, "C");

        }

        private void LoadSocios()
        {
            var registroSociosController = new RegistrosSociosController();
            var sociosAccionistas = registroSociosController.FetchAllSociosByRegistroIdAndTipoRelacion(RegistroId, CamaraId, "A");


            Socios = new List<ViewRegistrosSocios>();

            foreach (var socio in sociosAccionistas)
            {
                if (!Socios.Any(d => d.SocioId == socio.SocioId)) Socios.Add(socio);
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

            if (IdTransaciones <= 0)
            {
                txtMessageTitle.InnerText = "Debe especificar la transaccion";
                mainMultiView.SetActiveView(failView);
                return false;
            }


            return true;
        }

        private void SetEntesRegDataSource()
        {
            if (EntesReg.Count() < 1)
            {
                entesRegTbl.Visible = false;
            }
            else
            {
                entesRegRep.DataSource = EntesReg;
                entesRegRep.DataBind();
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.LoadEntesRegulados()'
        public void LoadEntesRegulados()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadEIRL.LoadEntesRegulados()'
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