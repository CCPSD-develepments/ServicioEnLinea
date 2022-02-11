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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatoGenerales'
    public partial class DatoGenerales : SecurePage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatoGenerales'
    {
        #region Attributes

        private DataAccess.EF.CamaraComun.CamaraComunEntities _comunDbContext;
        private CamaraSRMEntities _srmDbContext;
        private OFV.CamaraWebsiteEntities _ofvDbContext;



#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ActualizarDatoGenerales.CamaraId'
        public string CamaraId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ActualizarDatoGenerales.CamaraId'
        {
            get
            {
                return string.IsNullOrWhiteSpace(Request.QueryString["CamaraId"]) ? string.Empty : Request.QueryString["CamaraId"];
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ActualizarDatoGenerales.SociedadId'
        public int SociedadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ActualizarDatoGenerales.SociedadId'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["SociedadId"])) return 0;
                int.TryParse(Request.QueryString["SociedadId"], out int sociedadId);
                return sociedadId;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ActualizarDatoGenerales.RegistroId'
        public int RegistroId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ActualizarDatoGenerales.RegistroId'
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["RegistroId"])) return 0;
                int.TryParse(Request.QueryString["RegistroId"], out int registroId);
                return registroId;
            }
        }


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ActualizarDatoGenerales.SrmDbContext'
        public CamaraSRMEntities SrmDbContext
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ActualizarDatoGenerales.SrmDbContext'
        {
            get
            {
                if (_srmDbContext == null) _srmDbContext = new CamaraSRMEntities(DataAccess.EF.Helpers.GetCamaraConnString(CamaraId));
                return _srmDbContext;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ActualizarDatoGenerales.OfvDbContext'
        public OFV.CamaraWebsiteEntities OfvDbContext
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ActualizarDatoGenerales.OfvDbContext'
        {
            get
            {
                if (_ofvDbContext == null) _ofvDbContext = new OFV.CamaraWebsiteEntities();
                return _ofvDbContext;
            }
        }



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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ActualizarDatoGenerales.ComunDbContext'
        public DataAccess.EF.CamaraComun.CamaraComunEntities ComunDbContext
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ActualizarDatoGenerales.ComunDbContext'
        {
            get
            {
                if (_comunDbContext == null) _comunDbContext = new DataAccess.EF.CamaraComun.CamaraComunEntities();
                return _comunDbContext;
            }
        }



        public int ServicioId

        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["nservId"])) return 0;
                int.TryParse(Request.QueryString["nservId"], out int servicioId);
                return servicioId;
            }
        }


        public int SolicitudId

        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["nSolicitud"])) return 0;
                int.TryParse(Request.QueryString["nSolicitud"], out int solicitudId);
                return solicitudId;
            }
        }



        #endregion


        private void UpdateTransaction(long transId)
        {
            try
            { 

            var ofvRegistro = OfvDbContext.Registros.FirstOrDefault(d => d.SrmRegistroId == RegistroId && d.TransaccionId == transId);
            var ofvSociedad = OfvDbContext.Sociedades.FirstOrDefault(d => d.SrmSociedadId == SociedadId && d.TransaccionId == transId);

            var transSpecification = new Specification<DataAccess.EF.OficinaVirtual.Transacciones>(x => x.TransaccionId == transId);

            var repTransaccion = new DataAccess.EF.OficinaVirtual.TransaccionesRepository();
            var transaccion = repTransaccion.SelectAll(transSpecification).FirstOrDefault();


            transaccion.TelefonoContacto = ((OficinaVirtualUserProfile)Context.Profile).Telefono;

            //2021-08-26// actualizacion:
            transaccion.CorreoContacto = txtCorreoContacto.Text;
            transaccion.CorreoEmpresa = txtCorreoEmpresa.Text;

            var result = repTransaccion.Save() > 0;


            //registro:
            #region Registro

            //  var ofvRegistro = OfvDbContext.Registros.FirstOrDefault(d => d.SrmRegistroId == RegistroId && d.TransaccionId == transaccionId);
            if (ofvRegistro != null)
            {


                ofvRegistro.DireccionEmail = txtCorreoEmpresa.Text;// txtCorreo.Text;           
                ofvRegistro.DireccionTelefonoCasa = txtTelefonoCasa.Text?.RemoverFormato();
                ofvRegistro.DireccionTelefonoOficina = txtTelefonoOficina.Text?.RemoverFormato();
                //NEW EP:
                ofvRegistro.CorreoEmpresa = txtCorreoEmpresa.Text;
                ofvRegistro.CorreoContacto = txtCorreoContacto.Text;
            }

            OfvDbContext.SaveChanges();

            #endregion

            //   return result ? transaccion : null;
            //2021-11-02;
            var rpath = DefaultQueryString;// + "&nservId=" + this.ServicioId;
            Response.Redirect("/Empresas/RevisionDocumentos.aspx" + rpath);



                //  string queryString = Request.QueryString.ToString();
                //  Response.Redirect("/Empresas/RevisionDocumentos.aspx" +"?"+ queryString); 2021-11-02

            } //errores
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

            }
        }

        public void CargarDatosTransaccion(long transId)
        {
            try
            { 
            //   var ofvRegistro = OfvDbContext.Registros.FirstOrDefault(d => d.SrmRegistroId == RegistroId && d.TransaccionId == transId);
            //    var ofvSociedad = OfvDbContext.Sociedades.FirstOrDefault(d => d.SrmSociedadId == SociedadId && d.TransaccionId == transId);

            var user = Membership.GetUser(User.Identity.Name);
            //if (user != null)
            //    txtCorreoContacto.Text = user.Email;




            var ofvRegistro = OfvDbContext.Registros.FirstOrDefault(d => d.SrmRegistroId == RegistroId && d.TransaccionId == transId);

            if (ofvRegistro == null)
            {
                var registro = SrmDbContext.Registros.FirstOrDefault(d => d.RegistroId == RegistroId);
                var registroM = SrmDbContext.SociedadesRegistros.FirstOrDefault(x => x.RegistroId == registro.RegistroId);

                txtTelefonoCasa.Text = registro.Direcciones.TelefonoCasa;
                txtTelefonoOficina.Text = registro.Direcciones.TelefonoOficina;
                //new: 2021-08-23
                txtCorreoEmpresa.Text = registro.Direcciones.Email; // empresa                                                                  
                txtCorreoContacto.Text = user.Email;

            }
            else
            if (ofvRegistro != null) //new: 2021-08-23
            {            

                txtTelefonoCasa.Text = ofvRegistro.DireccionTelefonoCasa;
                txtTelefonoOficina.Text = ofvRegistro.DireccionTelefonoOficina;
                
                txtCorreoEmpresa.Text = ofvRegistro.DireccionEmail; // empresa                                                                  
                txtCorreoContacto.Text = user.Email;

            }


            } //errores
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

            }


        }


        private string GetQueryString(OFV.Transacciones transaction)
        {
            
            var stringBuilder = new StringBuilder();
         try
           {

            stringBuilder.AppendFormat("?SociedadId={0}", SociedadId);
            stringBuilder.AppendFormat("&RegistroId={0}", RegistroId);
            stringBuilder.AppendFormat("&CamaraId={0}", CamaraId);
            stringBuilder.AppendFormat("&EsCertificacion={0}", 0);
            stringBuilder.AppendFormat("&EntregaDigital={0}", false);

            var servicio = ComunDbContext.Servicio.FirstOrDefault(d => d.ServicioId == ServicioId);
            if (servicio == null) stringBuilder.AppendFormat("&TipoServicioId={0}", servicio.ServicioId);
            else stringBuilder.AppendFormat("&TipoServicioId={0}", servicio.TipoServicioId);

            //   stringBuilder.AppendFormat("&TipoSociedadId={0}", transaction.TipoSociedadId);
            //  stringBuilder.AppendFormat("&nSolicitud={0}", SolicitudId);


            if (transaction != null)
            {
                var context = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);
                var trSDQ = context.Transacciones.FirstOrDefault(x => x.TransaccionIdAnterior == transaction.TransaccionId && x.DesdeOfv);
                if (trSDQ != null)
                    if (trSDQ.VieneProblemas) stringBuilder.AppendFormat("&BorrarDocumentos={0}", "true");

            }


            } //errores
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

            }

            return stringBuilder.ToString();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            try
            { 

            CargarDatosTransaccion(SolicitudId);

            var queryString = Request.Path + GetQueryString(Transaccion);

           String fullURL = "";
          //  String urlFinal = "";

            if (!queryString.Contains("nSolicitud"))
            {

                fullURL = String.Format(queryString + "&nSolicitud={0}", SolicitudId);
            }

            if (!queryString.Contains("nservId"))
            {

                fullURL = String.Format(fullURL + "&nservId={0}", ServicioId);
            }



            LogTransaccionesMethods.GrabarLogTransacciones(SolicitudId, fullURL, false, User.Identity.Name);

            } //errores
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SolicitudId > 0)
            {
                //someter cambios:
                UpdateTransaction(SolicitudId);

            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Helper.NoboxMainpage);
        }
    }

}