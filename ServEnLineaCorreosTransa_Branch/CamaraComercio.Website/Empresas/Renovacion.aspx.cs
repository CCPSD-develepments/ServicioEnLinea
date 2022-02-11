using System;
using System.Collections.Generic;
using System.Linq;
using CamaraComercio.Website.Operaciones.Registro;
using CamaraComercio.DataAccess.EF.SRM;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.Website.Empresas
{
    ///<summary>
    /// Renovación simple de un registro mercantil
    ///</summary>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class Renovacion : CamaraComercio.Website.Operaciones.Modificaciones.ModificacionPage
    {
        #region Private fields and Properties

        /// <summary>
        /// Llave Primaria de la Sociedad.  
        /// </summary>
        public new int SociedadId
        {
            get
            {
                return String.IsNullOrWhiteSpace(Request.QueryString["sociedadId"]) ? 0 : int.Parse(Request.QueryString["sociedadId"]);
            }
            set { Session["sociedadId"] = value; }
        }
#pragma warning disable CS0109 // The member 'Renovacion.PersonaId' does not hide an accessible member. The new keyword is not required.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Renovacion.PersonaId'
        public new int PersonaId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Renovacion.PersonaId'
#pragma warning restore CS0109 // The member 'Renovacion.PersonaId' does not hide an accessible member. The new keyword is not required.
        {
            get
            {
                return String.IsNullOrWhiteSpace(Request.QueryString["PersonaId"]) ? 0 : int.Parse(Request.QueryString["personaId"]);
            }
            set { Session["personaId"] = value; }
        }


        /// <summary>
        /// Llave primaria del numero de registro mecartil de la empresa.
        /// </summary>
        public new int RegistroId
        {
            get
            {
                return String.IsNullOrWhiteSpace(Request.QueryString["registroId"]) ? 0 : int.Parse(Request.QueryString["registroId"]);

            }
            set { Session["registroId"] = value; }
        }

        /// <summary>
        /// Llave primaria del numero del tipo de sociedad.
        /// </summary>
        public new int TipoSociedadId
        {
            get
            {
                return String.IsNullOrWhiteSpace(Request.QueryString["TipoSociedadId"])
                           ? 0
                           : int.Parse(Request.QueryString["TipoSociedadId"]);
            }
            set { Session["TipoSociedadId"] = value; }
        }


        #endregion

        private bool IsValidRequestParameters()
        {
            if (this.TipoSociedadId != 7)
            {
                if (SociedadId <= 0)
                {
                    txtMessageTitle.InnerText = "Debe especificar la Empresa";
                    mvRenovacion.SetActiveView(failView);
                    return false;
                }
            }
            else
            {
                if (PersonaId <= 0)
                {
                    txtMessageTitle.InnerText = "Debe especificar la Empresa";
                    mvRenovacion.SetActiveView(failView);
                    return false;
                }
            }
           

            if (string.IsNullOrWhiteSpace(CamaraId))
            {
                txtMessageTitle.InnerText = "Debe especificar la Cámara";
                mvRenovacion.SetActiveView(failView);
                return false;
            }

            return true;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Renovacion.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Renovacion.Page_Load(object, EventArgs)'
        {
            //Postback
            if (IsPostBack) return;

            if (!IsValidRequestParameters()) return;


            if(Session["labelregistrovencido"] == null)
            {
                Session["labelregistrovencido"] = "Su Registro Mercantil está vencido";
            }

            labelregistrovencido.Text = Session["labelregistrovencido"].ToString();

            if (this.TipoSociedadId != 7)
            {
                var dbSrm = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);
                var dbComun = new Comun.CamaraComunEntities();

                if (this.SociedadId == 0)
                {
                    Master.ShowMessageError("Se ha intentado renovar una empresa no existente");
                    this.mvRenovacion.SetActiveView(vNoExiste);
                }

                var sociedad = dbSrm.Sociedades.FirstOrDefault(s => s.SociedadId == this.SociedadId);
                if (sociedad != null)
                {
                    this.litNombreEmpresaTitM.Text = sociedad.NombreSocial;
                    var tipoSociedad = dbComun.TipoSociedad.FirstOrDefault(ts => ts.TipoSociedadId == sociedad.TipoSociedadId);
                    /*if (tipoSociedad != null && tipoSociedad.Etiqueta.Length > 0)
                        this.litTipoEmpresaTit.Text = tipoSociedad.Etiqueta;*/
                }


                //Servicio ID de renovación)
                /*this.ServicioId = this.ServicioId == 0
                                      ? ServiciosDefault.Servicios
                                            .FirstOrDefault(a => a.TipoSociedadId == this.TipoSociedadId).
                                            ServicioRenovacionSimpleId
                                      : this.ServicioId;

                var serviciosAVerificar = new List<int>
                                                    {
                                                        ServiciosDefault.Servicios
                                                            .FirstOrDefault(a => a.TipoSociedadId == this.TipoSociedadId).
                                                            ServicioRenovacionSimpleId,
                                                        ServiciosDefault.Servicios
                                                            .FirstOrDefault(a => a.TipoSociedadId == this.TipoSociedadId).
                                                            ServicioRenovacionSimpleId
                                                    };*/

                //Escondido de ventana para empresas extranjeras
                this.pnlRenovacionTransf.Visible = false; // !Helper.TipoSociedadExtranjera.Contains(this.TipoSociedadId);

                //Se verifica si existe una renovación pendiente para esta empresa
                /*var soc = new SociedadesController().FetchBySociedadId(this.SociedadId, this.CamaraId).FirstOrDefault();
                var existeTrans = TransaccionesValidator.ExisteTransaccionActiva(this.CamaraId, serviciosAVerificar,
                                                                                 soc.NumeroRegistro,
                                                                                 Helper.EstatusTransaccionCerrados);
                if (existeTrans)
                {
                    //Si existe una transaccion se busca para dirigir al usuario a la pantalla de ver detalles
                    var transRep = new OFV.TransaccionesRepository();
                    var trans = transRep.GetTransaccionActiva(serviciosAVerificar, soc.NumeroRegistro,
                                                              Helper.EstatusTransaccionCerrados);
                    this.mvRenovacion.SetActiveView(vTransExistente);
                    this.lnkVerDetalle.NavigateUrl =
                        String.Format("/Empresas/VerDetalleTransaccion.aspx?nSolicitud={0}",
                                      trans.TransaccionId);
                }*/
            }
            else
            {
                var dbSrm = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);
                var dbComun = new Comun.CamaraComunEntities();

                if (this.PersonaId == 0)
                {
                    Master.ShowMessageError("Se ha intentado renovar una empresa no existente");
                    this.mvRenovacion.SetActiveView(vNoExiste);
                }

                var persona = dbSrm.Personas.FirstOrDefault(s => s.PersonaId == this.PersonaId);
                if (persona != null)
                {
                    var nombreCompleto = persona.PrimerNombre + " " + persona.SegundoNombre + " " + persona.PrimerApellido + " " + persona.SegundoApellido;
                    this.litNombreEmpresaTitM.Text = nombreCompleto;
                    var tipoSociedad = dbComun.TipoSociedad.FirstOrDefault(ts => ts.TipoSociedadId == this.TipoSociedadId);

                    //Escondido de ventana para empresas extranjeras
                    this.pnlRenovacionTransf.Visible = false;
                }
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Renovacion.hlRenovacion_Click(object, EventArgs)'
        protected void hlRenovacion_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Renovacion.hlRenovacion_Click(object, EventArgs)'
        {
            if (this.TipoSociedadId != 7)
            {
                var dbSRM = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);
                var regActual = dbSRM.SociedadesRegistros.Where(a => a.RegistroId == this.RegistroId && a.SociedadId == this.SociedadId)
                                .Select(a => a.Registros).FirstOrDefault();


               




                this.LoadRegistroData(dbSRM, regActual);

                this.RegistroNuevo.EsRenovacion = true;
                this.IsFormularionConfirmacion = true;

                this.ServicioId =
                ServiciosDefault.Servicios.FirstOrDefault(
                a => a.TipoSociedadId == this.SociedadRegistroNuevo.TipoSociedadId).ServicioRenovacionSimpleId;

                var sociedadescontroller = new DataAccess.EF.SRM.SociedadesController();
                var sociedadRegistro = sociedadescontroller.FetchSociedadesRegistroBySociedadId(SociedadId, CamaraId);

                if (TransaccionesValidator.ExisteTransaccionActivaMejora(this.CamaraId, this.ServicioId, sociedadRegistro.NumeroRegistro, Helper.IdEstatusTransaccionesDuplicar, this.TipoSociedadId))
                {
                    ErrorMessage = "Ya existe una solicitud de este servicio. Verifique el historico de transacciones.";
                    Master.ShowMessageError(ErrorMessage);
                    return;
                }
            }
            else
            {
                var dbSRM = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);
                var regActual = dbSRM.PersonasRegistros.Where(a => a.RegistroId == this.RegistroId && a.PersonaId== this.PersonaId)
                                .Select(a => a.Registros).FirstOrDefault();

               

                this.LoadRegistroDataPer(dbSRM, regActual);
                this.RegistroNuevo.EsRenovacion = true;
                this.IsFormularionConfirmacion = true;
                this.ServicioId =421;
                var personaController = new DataAccess.EF.SRM.PersonaFisicaController();
                var personaRegistro = personaController.ObteneByPersonaIdCamara(this.PersonaId, CamaraId).FirstOrDefault();

                if (TransaccionesValidator.ExisteTransaccionActivaMejora(this.CamaraId, this.ServicioId, personaRegistro.NumeroRegistro, Helper.IdEstatusTransaccionesDuplicar, this.TipoSociedadId))
                {
                    ErrorMessage = "Ya existe una solicitud de este servicio.  Verifique el historico de transacciones.";
                    Master.ShowMessageError(ErrorMessage);
                    return;
                }
            }

            SubmitChanges();
            if (Redirect)
                Response.Redirect("~/Empresas/RevisionDocumentos.aspx" + DefaultQueryString);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Renovacion.lbRenovacionMod_Click(object, EventArgs)'
        protected void lbRenovacionMod_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Renovacion.lbRenovacionMod_Click(object, EventArgs)'
        {
            this.IsFormularionConfirmacion = true;
            if (!DefaultQueryString.Contains("EsRenovacion="))
                DefaultQueryString = "EsRenovacion=" + 1 + "&TipoServicioId=" + Helper.TipoServicioId;
            Response.Redirect("~/Operaciones/Modificaciones/SolicitudOperacion.aspx" + DefaultQueryString);

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Renovacion.lnkRenovacionTrans_Click(object, EventArgs)'
        protected void lnkRenovacionTrans_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Renovacion.lnkRenovacionTrans_Click(object, EventArgs)'
        {
            this.IsFormularionConfirmacion = true;
            if (!DefaultQueryString.Contains("EsRenovacion="))
                DefaultQueryString = "EsRenovacion=" + 1 + "&TipoServicioId=" + Helper.TipoServicioIdTransformacion;
            Response.Redirect("~/Operaciones/Modificaciones/SolicitudOperacion.aspx" + DefaultQueryString);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Renovacion.lnkRenovacionCierre_Click(object, EventArgs)'
        protected void lnkRenovacionCierre_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Renovacion.lnkRenovacionCierre_Click(object, EventArgs)'
        {
            this.IsFormularionConfirmacion = true;
            DefaultQueryString = "EsRenovacion=" + 1 + "&TipoServicioId=" + Helper.TipoServicioIdCierreRegistral;
            Response.Redirect("~/Operaciones/Modificaciones/SolicitudOperacion.aspx" + DefaultQueryString);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Renovacion.lnkSolicitudCertificacion_Click(object, EventArgs)'
        protected void lnkSolicitudCertificacion_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Renovacion.lnkSolicitudCertificacion_Click(object, EventArgs)'
        {
            this.IsFormularionConfirmacion = true;
            if (!DefaultQueryString.Contains("TipoServicioId="))
                DefaultQueryString = "TipoServicioId=" + Helper.TipoServicioIdTransformacion;
            Response.Redirect("~/Operaciones/Shared/Certificaciones.aspx" + DefaultQueryString);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Renovacion.lnkCopiasCertificadas_Click(object, EventArgs)'
        protected void lnkCopiasCertificadas_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Renovacion.lnkCopiasCertificadas_Click(object, EventArgs)'
        {
            if(this.TipoSociedadId != 7)
            {
                if (this.RegistroId > 0 && this.CamaraId.Length > 0 && this.SociedadId > 0)
                {
                    this.IsFormularionConfirmacion = true;
                    const string urlCopiasCert = "/Operaciones/Shared/CopiasCert.aspx?SociedadId={0}&RegistroId={1}&CamaraId={2}&TipoSociedadId={3}&TipoServicioId={4}";
                    Response.Redirect(String.Format(urlCopiasCert, this.SociedadId, this.RegistroId, this.CamaraId, this.TipoSociedadId, Helper.ServicioCopiasCertificadasId));
                }
            }
            else
            {
                if (this.RegistroId > 0 && this.CamaraId.Length > 0 && this.PersonaId > 0)
                {
                    this.IsFormularionConfirmacion = true;
                    const string urlCopiasCert = "/Operaciones/Shared/CopiasCert.aspx?SociedadId={0}&RegistroId={1}&CamaraId={2}&TipoSociedadId={3}&TipoServicioId={4}&PersonaId={5}";
                    Response.Redirect(String.Format(urlCopiasCert, this.SociedadId, this.RegistroId, this.CamaraId, this.TipoSociedadId, Helper.ServicioCopiasCertificadasId,this.PersonaId));
                }
            }
        }
    }
}