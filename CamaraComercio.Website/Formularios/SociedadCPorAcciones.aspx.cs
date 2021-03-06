using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
using System.ServiceModel.Channels;
using CamaraComercio.DataAccess.EF.SRM;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.Website.Helpers;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.Website.Empresas;
using System.Web.Security;
using iTextSharp.text;
using iTextSharp.text.pdf;
using CamaraComercio.Website.WSShareBase;
using System.Globalization;
using SRM = CamaraComercio.DataAccess.EF.SRM;

namespace CamaraComercio.Website.Formularios
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones'
    public partial class SociedadCPorAcciones : FormularioPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones'
    {
        #region Atributtes
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.camCtrl'
        public CamarasController camCtrl = new CamarasController();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.camCtrl'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.dbContext'
        public CamaraSRMEntities dbContext;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.dbContext'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.socCtrl'
        public SociedadesController socCtrl = new SociedadesController();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.socCtrl'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.registro'
        public DataAccess.EF.SRM.Registros registro;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.registro'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.orgGest'
        public List<ViewRegistrosSocios> orgGest = new List<ViewRegistrosSocios>();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.orgGest'

#pragma warning disable CS0169 // The field 'SociedadCPorAcciones.camara' is never used
        Camaras camara;
#pragma warning restore CS0169 // The field 'SociedadCPorAcciones.camara' is never used
#pragma warning disable CS0169 // The field 'SociedadCPorAcciones.sociedadReg' is never used
        cvw_SociedadesRegistros sociedadReg;
#pragma warning restore CS0169 // The field 'SociedadCPorAcciones.sociedadReg' is never used
        OficinaVirtualUserProfile usuarioActual;
#pragma warning disable CS0169 // The field 'SociedadCPorAcciones.direccion' is never used
        DataAccess.EF.SRM.Direcciones direccion;
#pragma warning restore CS0169 // The field 'SociedadCPorAcciones.direccion' is never used
#pragma warning disable CS0169 // The field 'SociedadCPorAcciones.sector' is never used
        DataAccess.EF.CamaraComun.Sectores sector;
#pragma warning restore CS0169 // The field 'SociedadCPorAcciones.sector' is never used
#pragma warning disable CS0169 // The field 'SociedadCPorAcciones.ciudad' is never used
        DataAccess.EF.CamaraComun.Ciudades ciudad;
#pragma warning restore CS0169 // The field 'SociedadCPorAcciones.ciudad' is never used
#pragma warning disable CS0169 // The field 'SociedadCPorAcciones.factura' is never used
        OFV.Facturas factura;
#pragma warning restore CS0169 // The field 'SociedadCPorAcciones.factura' is never used
        DataAccess.EF.CamaraComun.Servicio serv;
        DataAccess.EF.CamaraComun.TipoServicio tipServ;
#pragma warning disable CS0169 // The field 'SociedadCPorAcciones.referenciasBancarias' is never used
        List<DataAccess.EF.SRM.ReferenciasBancarias> referenciasBancarias;
#pragma warning restore CS0169 // The field 'SociedadCPorAcciones.referenciasBancarias' is never used
#pragma warning disable CS0169 // The field 'SociedadCPorAcciones.referenciasComerciales' is never used
        List<DataAccess.EF.SRM.ReferenciasComerciales> referenciasComerciales;
#pragma warning restore CS0169 // The field 'SociedadCPorAcciones.referenciasComerciales' is never used
        List<CamaraComercio.DataAccess.EF.SRM.Sociedades> EntesReg = new List<CamaraComercio.DataAccess.EF.SRM.Sociedades>();
        #endregion

        #region Props
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.SociedadId'
        public int SociedadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.SociedadId'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["SociedadId"])) return 0;
                int.TryParse(Request.QueryString["SociedadId"], out int sociedadId);
                return sociedadId;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.CantidadCertificaciones'
        public int CantidadCertificaciones
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.CantidadCertificaciones'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["cantidadCertificaciones"])) return 0;
                int.TryParse(Request.QueryString["cantidadCertificaciones"], out int cantCert);
                return cantCert <= 0 ? 0 : cantCert;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.RegistroId'
        public int RegistroId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.RegistroId'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["RegistroId"])) return 0;
                int.TryParse(Request.QueryString["RegistroId"], out int registroId);
                return registroId;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.CamaraId'
#pragma warning disable CS0108 // 'SociedadCPorAcciones.CamaraId' hides inherited member 'EnvioDatos.CamaraId'. Use the new keyword if hiding was intended.
        public string CamaraId
#pragma warning restore CS0108 // 'SociedadCPorAcciones.CamaraId' hides inherited member 'EnvioDatos.CamaraId'. Use the new keyword if hiding was intended.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.CamaraId'
        {
            get
            {
                return string.IsNullOrWhiteSpace(Request.QueryString["CamaraId"]) ? string.Empty : Request.QueryString["CamaraId"];
            }
        }



#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.DbContext'
        public CamaraSRMEntities DbContext
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.DbContext'
        {
            get
            {
                if (dbContext == null) dbContext = new CamaraSRMEntities(DataAccess.EF.Helpers.GetCamaraConnString(CamaraId));
                return dbContext;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.Socios'
        public List<ViewRegistrosSocios> Socios
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.Socios'
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


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.Page_Load(object, EventArgs)'
#pragma warning disable CS0108 // 'SociedadCPorAcciones.Page_Load(object, EventArgs)' hides inherited member 'EnvioDatos.Page_Load(object, EventArgs)'. Use the new keyword if hiding was intended.
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS0108 // 'SociedadCPorAcciones.Page_Load(object, EventArgs)' hides inherited member 'EnvioDatos.Page_Load(object, EventArgs)'. Use the new keyword if hiding was intended.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;

            InitInterface();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.InitInterface()'
        public void InitInterface()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociedadCPorAcciones.InitInterface()'
        {
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
            //txtSolicitante.Text = transaccion.Solicitante;
            txtNombreCont.Text = transaccion.NombreContacto;
            var user = Membership.GetUser(User.Identity.Name);
            if (user != null) txtEmail.Text = user.Email;
            //txtRNC1.Text = transaccion.RNCSolicitante.FormatRnc();
            txtTelefono.Text = transaccion.TelefonoContacto.FormatTelefono();

            usuarioActual = OficinaVirtualUserProfile.GetUserProfile(transaccion.UserName);
            txtCedula.Text = usuarioActual.NumeroDocumento.FormatRnc();

            // Datos de la sociedad
            txtRazSocial.Text = this.Formulario.Sociedad.NombreSocial;
            txtTipoSocietario.Text = dbCom.TipoSociedad.FirstOrDefault(x => x.TipoSociedadId == this.Formulario.Sociedad.TipoSociedadId).Descripcion;
            txtNoRegistro.Text = string.Format("{0}SD", this.Formulario.Registro.RegistroMercantil);
            txtRNCSoc.Text = !string.IsNullOrWhiteSpace(this.Formulario.Sociedad.Rnc) ? this.Formulario.Sociedad.Rnc.FormatRnc(): "N/A";
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

            txtTel1.Text = !string.IsNullOrWhiteSpace(this.Formulario.Registro.DireccionTelefonoCasa) 
                ? this.Formulario.Registro.DireccionTelefonoCasa.FormatTelefono() : "N/A";
            txtTel2.Text = !string.IsNullOrWhiteSpace(this.Formulario.Registro.DireccionTelefonoOficina)
                ? this.Formulario.Registro.DireccionTelefonoOficina.FormatTelefono() : "N/A";
            txtCorreoSociedad.Text = !string.IsNullOrWhiteSpace(this.Formulario.Registro.DireccionEmail)
                ? this.Formulario.Registro.DireccionEmail : "N/A";
            txtPagWeb.Text = !string.IsNullOrWhiteSpace(this.Formulario.Registro.DireccionSitioWeb)
                ? this.Formulario.Registro.DireccionSitioWeb :"N/A";
            if(Formulario.Sociedad.NacionalidadId != null)
                txtNacionalidad.Text = dbCom.Paises.FirstOrDefault(c => c.PaisId == Formulario.Sociedad.NacionalidadId).Nombre;
            txtFechaEmision.Text = this.Formulario.Registro.FechaEmision != null 
                ? string.Format("{0:dd/MM/yyyy}", this.Formulario.Registro.FechaEmision) : "N/A";
            txtFechaVenc.Text = this.Formulario.Registro.FechaVencimiento != null 
                ? string.Format ("{0:dd/MM/yyyy}", this.Formulario.Registro.FechaVencimiento) : "N/A";
            txtFechaConst.Text = this.Formulario.Sociedad.FechaConstitucion != null
                ? string.Format("{0:dd/MM/yyyy}", this.Formulario.Sociedad.FechaConstitucion) : "N/A";
            txtDuracionSociedad.Text = this.Formulario.Sociedad.DuracionSociedad.Equals("DEFINIDA") ? this.Formulario.Sociedad.DuraccionDirectiva.ToString() : this.Formulario.Sociedad.DuracionSociedad;
            txtEstadoSociedad.Text = estatus != null ? estatus.Descripcion : "N/A";
            // Empleadoas
            txtMasculino.Text = this.Formulario.Registro.EmpleadosMasculinos.ToString();
            txtFemenino.Text = this.Formulario.Registro.EmpleadosFemeninos.ToString();
            txtTotal.Text = this.Formulario.Registro.EmpleadosTotal.ToString();
            //nombre comercial
            txtNombreComercial.Text = this.Formulario.Registro.NombreComercial;
            txtRegitroNComercial.Text = this.Formulario.Registro.RegistroNombreComercial;
            // desc
            txtDesc.Text = this.Formulario.Registro.ActividadNegocio;
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
            txtMonto.Text = this.Formulario.Registro.CapitalAutorizado!= null ? string.Format("{0:c}", this.Formulario.Registro.CapitalAutorizado) 
                : "0.00";
            txtMoneda.Text = dbCom.TipoMoneda.FirstOrDefault(c => c.TipoMonedaId == Formulario.Registro.TipoMonedaCapitalAutorizado).Abreviatura;
            //
            //txtDuracionOrganoGestor.Text = this.Formulario.Sociedad.DuracionSociedad;
            this.txtFechaAsamb.Text = !string.IsNullOrWhiteSpace(Formulario.Sociedad.FechaAsamblea.ToString())
                ? string.Format("{0:dd/MM/yyyy}", Formulario.Sociedad.FechaAsamblea) : "N/A";

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
            setComanditados(Formulario.SociosComanditados.ToList());
            if (SociosC.Visible)
            {
                txtTotalSociosComanditado.Text = Formulario.SociosComanditados.Count().ToString();
                int tcomanditados = 0;
                foreach (var item in Formulario.SociosComanditados)
                {
                    tcomanditados += item.CantidaCuotasAcciones;
                }
                txtTotalAccionesComanditado.Text = tcomanditados.ToString();
            }
            

            SetComanditarios(Formulario.SociosComanditarios.ToList());
            if (SociosCo.Visible)
            {
                txtTotalSociosComanditario.Text = Formulario.SociosComanditarios.Count().ToString();
                int tcomanditarios = 0;
                foreach (var item in Formulario.SociosComanditarios)
                {
                    tcomanditarios += item.CantidaCuotasAcciones;
                }
                txtTotalAccionesComanditario.Text = tcomanditarios.ToString();
            }
            

            SetProducto(dbSRM.Productos.Where(p => p.RegistroId == Formulario.Registro.SrmRegistroId).ToList());
            //OrganoGestion
            SetOrgGestorDataSource(Formulario.OrganoGestion.ToList());

            if(Formulario.ConsejoVigilancia != null)
                SetConsejoVigilanciaDataSource(Formulario.ConsejoVigilancia.ToList());
            else
                SociosVi.Visible = false;
            // Socios con Firmas autorizadas
            SetSociosAutorizadosDataSource(Formulario.SociosFirmas.ToList());
            SetComisario(Formulario.Comisarios.ToList());
            //Load Entes Regulados

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
        }

        private void setComanditados(List<SociosComanditados> Comanditados)
        {
            if (Comanditados.Count() < 1)
            {
                SociosC.Visible = false;
            }
            else
            {
                ComanditadosRep.DataSource = Comanditados;
                ComanditadosRep.DataBind();
            }
        }
        private void SetComanditarios(List<SociosComanditarios> Comanditarios)
        {
            if (Comanditarios.Count() < 1)
            {
                SociosCo.Visible = false;
            }
            else
            {
                ComanditariosRep.DataSource = Comanditarios;
                ComanditariosRep.DataBind();
            }
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
                SociosCom.Visible = false;
            }
            else
            {
                sociosComisario.DataSource = comisarios;
                sociosComisario.DataBind();
            }
        }

#pragma warning disable CS0108 // 'SociedadCPorAcciones.CreateFolderOnShareBase(int)' hides inherited member 'FormularioPage.CreateFolderOnShareBase(int)'. Use the new keyword if hiding was intended.
        private bool CreateFolderOnShareBase(int TransId)
#pragma warning restore CS0108 // 'SociedadCPorAcciones.CreateFolderOnShareBase(int)' hides inherited member 'FormularioPage.CreateFolderOnShareBase(int)'. Use the new keyword if hiding was intended.
        {
            var db = new CamaraWebsiteEntities();
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

            return true;
        }

        private void SetConsejoVigilanciaDataSource(ICollection<ConsejoVigilancia> consejoVigilancia)
        {
            if (consejoVigilancia.Count() < 1)
            {
                SociosVi.Visible = false;
            }
            else
            {
                consejoRep.DataSource = consejoVigilancia;
                consejoRep.DataBind();
            }
        }

        private void SetOrgGestorDataSource(List<OrganoGestion> organoGestion)
        {
            if (organoGestion.Count < 1)
            {
                SociosGe.Visible = false;
            }
            else
            {
                orgGestionRepeater.DataSource = organoGestion;
                orgGestionRepeater.DataBind();
            }
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

        private void SetSociosAutorizadosDataSource(List<SociosFirmas> SociosAut)
        {
            if (SociosAut.Count() < 1)
            {
                SociosFi.Visible = false;
            }
            else
            {
                sociosAutRep.DataSource = SociosAut;
                sociosAutRep.DataBind();
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

    }
}