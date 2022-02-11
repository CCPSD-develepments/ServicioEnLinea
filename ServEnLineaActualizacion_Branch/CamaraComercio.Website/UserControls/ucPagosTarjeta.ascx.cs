using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.Website.DTO;
using CamaraComercio.Website.Helpers;
using CamaraComercio.Website.wsFacturacion;
using ModuloPago;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls;
using Facturas = CamaraComercio.DataAccess.EF.OficinaVirtual.Facturas;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using TransaccionDetalle = CamaraComercio.DataAccess.EF.OficinaVirtual.TransaccionDetalle;
using Transacciones = CamaraComercio.DataAccess.EF.OficinaVirtual.Transacciones;

namespace CamaraComercio.Website.UserControls
{
    ///<summary>
    /// Página principal para el pago de facturas mediante tarjetas de crédito
    ///</summary>
    public partial class ucPagosTarjeta : EnvioDatosUserControl
    {
        private const string SiglaExtranjera = "EXT";
        readonly ProcesarPagoVisanet pago = new ProcesarPagoVisanet();

        #region Propiedades
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.FacturaSrmId'
        protected int FacturaSrmId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.FacturaSrmId'
        {
            get { return !String.IsNullOrWhiteSpace(Request.QueryString["FacturaSrmId"]) ? int.Parse(Request.QueryString["FacturaSrmId"]) : 0; }
            set { DefaultQueryString = String.Format("FacturaSrmId={0}", value); }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.CostoServicio'
        protected Decimal CostoServicio
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.CostoServicio'
        {
            get
            {
                if (Session["CostoServicio"] == null)
                    Session["CostoServicio"] = 0M;

                return (Decimal)Session["CostoServicio"];
            }
            set
            {
                Session["CostoServicio"] = value;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.CostoTransaccion'
        protected Decimal CostoTransaccion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.CostoTransaccion'
        {
            get
            {
                if (Session["CostoTransaccion"] == null)
                    Session["CostoTransaccion"] = 0M;

                return (Decimal)Session["CostoTransaccion"];
            }
            set
            {
                Session["CostoTransaccion"] = value;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.Credito'
        protected Decimal Credito
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.Credito'
        {
            get
            {
                if (Session["Credito"] == null)
                    Session["Credito"] = 0M;

                return (Decimal)Session["Credito"];
            }
            set
            {
                Session["Credito"] = value;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.Transaccion'
        protected Transacciones Transaccion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.Transaccion'
        {
            get
            {
                if (Session["Transacciones"] == null)
                    Session["Transacciones"] = new Transacciones();

                return Session["Transacciones"] as Transacciones;
            }
            set { Session["Transacciones"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.ServiciosDefault'
        public static ServicioSection ServiciosDefault
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.ServiciosDefault'
        {
            get
            {
                return (ServicioSection)WebConfigurationManager.GetWebApplicationSection("servicioSection");
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.EsConstitucion'
        protected bool EsConstitucion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.EsConstitucion'
        {
            get
            {
                if (Transaccion == null)
                    return false;
                var service =
                    ServiciosDefault.Servicios.FirstOrDefault(s => s.TipoSociedadId == Transaccion.TipoSociedadId);

                return service != null && service.ServicioConstitucionId == Transaccion.ServicioId;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.EsCertificacionSimple'
        protected bool EsCertificacionSimple
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.EsCertificacionSimple'
        {
            get
            {
                var servicio = new CamaraComunEntities().Servicio.FirstOrDefault(a => a.ServicioId == Transaccion.ServicioId);
                return (servicio.ServicioFlowId == Helper.ServicioFlowIdNoRequiereAnalisis ||
                        Transaccion.TipoModeloId.HasValue);
            }
        }

        /// <summary>
        /// Parametro con el estatus de la transaccion (desde el transaccional)
        /// </summary>
        private string Status
        {
            get { return Request.GetParam("status"); }
        }

        /// <summary>
        /// Coleccion de errores retornados por la transacción
        /// </summary>
        private List<string> Errors
        {
            get
            { return Request.GetParam("errors").Split(',').ToList(); }
        }

        private int CantidadCertificaciones { get; set; }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.BackUrl'
        protected string BackUrl
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.BackUrl'
        {
            get
            {
                /*var noSolicitud = Request.QueryString["nSolicitud"];
                var tipoModeloId = Request.QueryString["TipoModeloId"];
                var esCertificacion = Request.QueryString["EsCertificacion"];
                var camaraId = Request.QueryString["CamaraId"];

                return $"~/Empresas/RevisionDocumentos.aspx?nSolicitud={noSolicitud}&TipoModeloId={tipoModeloId}&EsCertificacion={esCertificacion}&CamaraId={camaraId}";*/

                return $"~/Empresas/RevisionDocumentos.aspx{DefaultQueryString}";
            }
        }

        #endregion

        #region Eventos
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.ControlLoad(List<KeyValuePair<string, string>>)'
        public override void ControlLoad(List<KeyValuePair<string, string>> args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.ControlLoad(List<KeyValuePair<string, string>>)'
        {
            //Validacion de la hora de oficina
            if (!Utils.IsHorarioOficina())
                hfHoraOficina.Value = "1";

            //Parametros de Transaccional VisaNet
            var vDTO = new VisanetDTO();

            //Postback
            var pantallaIniciada = false;

            //Validacion de errores
            if (this.Status.ToLower() == "error")
            {
                var errores = Request.GetParam("Errors");
                Master.ShowMessageError("Ocurrio un error al intentar procesar su pago.");
            }

            if (pago.EsRepuestaVisanet)
            {
                var visanet = pago.RequestVisanet(EnumSystemType.CamaraOnline);

                if (!string.IsNullOrEmpty(visanet.AuthCode))
                {
                    vDTO.Amount = visanet.Amount;
                    vDTO.AuthCode = visanet.AuthCode;
                    vDTO.Currency = visanet.Currency;
                    vDTO.MerchantKey = visanet.MerchantKey;
                    vDTO.OrderID = visanet.OrderID;
                    vDTO.ReferenceCode = visanet.ReferenceCode;
                    vDTO.Tarjeta = visanet.Tarjeta;

                    ProcesarPagoTarjeta(vDTO);

                }
            }
            else if (pago.EsRepuestaAzul)
            {
                var visanet = pago.RequestAzul(EnumSystemType.CamaraOnline, this.Transaccion.CamaraId);
                if (visanet == null)
                {
                    Master.ShowMessageError(pago.Errores);
                }
                else if (!string.IsNullOrEmpty(visanet.AuthCode))
                {
                    vDTO.Amount = visanet.Amount;
                    vDTO.AuthCode = visanet.AuthCode;
                    vDTO.Currency = visanet.Currency;
                    vDTO.MerchantKey = visanet.MerchantKey;
                    vDTO.OrderID = visanet.OrderID;
                    vDTO.ReferenceCode = visanet.ReferenceCode;
                    vDTO.Tarjeta = visanet.Tarjeta;

                    ProcesarPagoTarjeta(vDTO, 0);

                }

                //vDTO.Amount = 200;
                //vDTO.AuthCode = string.Empty;
                //vDTO.Currency = 0;
                //vDTO.MerchantKey = string.Empty;
                //vDTO.OrderID = 000025;
                //vDTO.ReferenceCode = "256699";
                //vDTO.Tarjeta = "Prueba";

                //ProcesarPagoTarjeta(vDTO, 0);

                // Response.Redirect($"~/TarjetaCredito/Factura.aspx?transId={Convert.ToInt32(Session["transId"])}");
                // return;
            }
            else
            {
                //Registro de actividades
                Master.NombreActividad = "Envío de pago con Tarjeta de Crédito";
                int tipoServicio = 0;
                int.TryParse(Request.QueryString["TipoServicioId"], out tipoServicio);
                //Objeto de la transaccion
                this.Transaccion = new OFV.TransaccionesRepository().GetTransaccion(this.IdTransaciones, this.Page.User.Identity.Name);
                Session["transId"] = this.IdTransaciones;
                //Se inicia la pantalla
                InitInterface(Transaccion.CamaraId);
                pantallaIniciada = true;
                //if (tipoServicio.Equals(Helper.ServicioCopiasCertificadasId)) 
                //{
                //    LoadDataCopiasCertificadas();
                //    return;
                //}

                if (this.IdTransaciones == 0 && this.FacturaSrmId == 0)
                    SolicitudInvalidad();
                if (this.IdTransaciones > 0)
                    LoadData(this.IdTransaciones, Transaccion.CamaraId);
                if (this.FacturaSrmId > 0)
                    LoadDataFacturaSrm(this.FacturaSrmId);
                if (EsConstitucion)
                    hfServicio.Value = "1";

                //Validacion para certificaciones simples
                //Comente : Se puede pagar las siple en la camara
                bool esDigital = true;

                // Boolean.TryParse(Request.QueryString["EntregaDigital"], out esDigital);

                if (esDigital)
                {
                    //pnlExpress.Visible = false;
                    // this.rbFormaPago.Items[1].Enabled = false;
                    this.rbFormaPago.Items[0].Selected = true;
                }
                else
                {
                    this.rbFormaPago.Items[0].Selected = true;
                    // this.rbFormaPago.Items[1].Selected = true;
                }

                //Se revisa si la camara actual tiene permisos para procesar transacciones de tarjeta
                var dbComun = new CamaraComunEntities();
                var camara = dbComun.Camaras.FirstOrDefault(c => c.ID == this.CamaraId);
                if (camara != null && esDigital)
                {
                    var puedeVender = camara.PuedeVenderOnline.HasValue
                                                        ? camara.PuedeVenderOnline.Value
                                                        : false;
                    this.rbFormaPago.Items[0].Enabled = puedeVender;
                    this.rbFormaPago.Items[0].Selected = puedeVender;
                    //this.rbFormaPago.Items[1].Selected = !puedeVender;
                }

                if (this.Page.User.IsInRole("Testers"))
                {
                    this.rbFormaPago.Items[0].Enabled = true;
                    this.rbFormaPago.Items[0].Selected = true;
                    //this.rbFormaPago.Items[1].Selected = false;
                }
            }

            if (!pantallaIniciada)
            {
                var transId = Convert.ToInt32(Session["transId"]);
                this.IdTransaciones = transId;
                this.Transaccion = new OFV.TransaccionesRepository().GetTransaccion(transId, this.Page.User.Identity.Name);
                InitInterface(Transaccion.CamaraId);
                LoadData(transId, Transaccion.CamaraId);
            }

            //TODO: Force para que tarjeta de crédito no funcione en site en producción.
            //  var habilitarPago = Helper.HabilarPagoTarjeta(this.Transaccion.ServicioId) && (CamaraId.Equals("SDQ") || CamaraId.Equals("GOT"));

            //if (habilitarPago)
            {
                this.rbFormaPago.Items[0].Enabled = true;
                this.rbFormaPago.Items[0].Selected = true;
                //this.rbFormaPago.Items[1].Selected = false;
                //this.rbFormaPago.Items[1].Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "hidden";
            }
            //else
            //{
            //    this.rbFormaPago.Items[0].Enabled = false;
            //    this.rbFormaPago.Items[0].Selected = false;
            //    //this.rbFormaPago.Items[1].Selected = true;

            //}

            Int32 nSolicitud = Transaccion.TransaccionId;
            // if (!Int32.TryParse(Request.QueryString["nSolicitud"], out nSolicitud)) throw new Exception("No tiene numero de solicitud");
            //Aqui grabo el log de la transaccion que se creo
            LogTransaccionesMethods.GrabarLogTransacciones(nSolicitud, Request.RawUrl, false, this.Page.User.Identity.Name);
        }
        
        private void LoadDetalleFacturaCopiasCertificadas()
        {
            var detalle = new List<DetalleServicio>();

            detalle.Add(new DetalleServicio
            {
                Descripcion = "Copia Certificada",
                Costo = GetCostoCopiasCert()
            });

            detalle.Add(new DetalleServicio
            {
                Descripcion = "COBROS DE HOJAS (COPIAS CERTIFICADAS)",
                Costo = GetCostoCantPaginasCopiasCert(),
            });

            rpDetalleServicio.DataSource = detalle;
            rpDetalleServicio.DataBind();

            decimal total = 0;

            foreach (var item in detalle)
                total += item.Costo;

            var lbl = (Label)this.rpDetalleServicio.FindControlInFooter("txtCostoTotalTransaccion");
            total = decimal.Round(total, 2);
            lbl.Text = total.ToString();
            lblTotalTransaccion.Text = total.ToString();
        }

        private decimal GetCostoCantPaginasCopiasCert()
        {
            var dbComun = new CamaraComunEntities();

            var ser = (from servicio in dbComun.Servicio
                       where servicio.ServicioId.Equals(689)
                       select servicio).FirstOrDefault();

            decimal totalCopias = 0;

            foreach (var item in this.CopiasCertificadas)
            {
                decimal total = (item.CantPaginas * ser.CostoServicio);
                totalCopias += total;
            }
            return totalCopias;
        }

        private decimal GetCostoCopiasCert()
        {
            var dbComun = new CamaraComunEntities();

            var ser = (from servicio in dbComun.Servicio
                       where servicio.ServicioId.Equals(415)
                       select servicio).FirstOrDefault();

            return ser.CostoServicio;
        }

        private void LoadServiciosCopiasCertificadas()
        {
            //COPIA CERTIFICADA: 415,  COBROS DE HOJAS (COPIAS CERTIFICADAS): 686
            List<int> servicioIds = new List<int>() { 415, 689 };
            //Listado de servicios
            var dbComun = new CamaraComunEntities();
            var servicios = dbComun.Servicio.Where(s => servicioIds.Contains(s.ServicioId) && s.SiteVisible);
            this.rpServiciosSeleccionados.DataSource = servicios;
            this.rpServiciosSeleccionados.DataBind();
        }

        private void SolicitudInvalidad()
        {
            Session["ErrorMessage"] = "Solicitud no Existe. Por favor verificar y trate de nuevo.";
            Response.Redirect("~/Empresas/Oficina.aspx");
        }

        private void InitInterface(string camaraId)
        {
            var dbComun = new CamaraComunEntities();

            //Tipo de Empresa            
            var tipoEmpresa = String.Empty;
            var tipoSociedadField = this.TipoSociedadID > 0 ? this.TipoSociedadID : this.Transaccion.TipoSociedadId;
            if (tipoSociedadField > 0)
            {
                var obj = dbComun.TipoSociedad.Where(c => c.TipoSociedadId == tipoSociedadField).First();
                if (obj != null)
                    tipoEmpresa = obj.Etiqueta;
            }
            if (tipoEmpresa.Equals(SiglaExtranjera))
                this.txtTipoSociedad.Text = "Extranjera";
            else
                this.txtTipoSociedad.Text = tipoEmpresa;

            //this.litTipoEmpresaTit.Text = tipoEmpresa;

            //Tipos de comprobantes fiscales
            var ncfs = dbComun.TiposNcf.Where(t => t.SiteVisible);
            ddlTipoComprobantes.BindCollection(ncfs, TiposNcf.PropColumns.TipoNcfId, TiposNcf.PropColumns.Descripcion);
            ddlTipoComprobantes.SelectedIndex = ddlTipoComprobantes.Items.Count > 0 ? 1 : 0;

            //Si es certificación no se despliega la opción de transacción express
            var servicio = dbComun.Servicio.Where(s => s.ServicioId == this.Transaccion.ServicioId).FirstOrDefault();

            if (servicio != null && !Helper.ServicioVip(servicio.ServicioId))
                this.pnlExpress.Visible = false;

            //Información sobre la cámara
            var camara = dbComun.Camaras.FirstOrDefault(a => a.ID == camaraId);
            ltrNombreCamara.Text = camara.Nombre;
            ltrDireccionCamara.Text = camara.Direccion;

            //Si es una empresa nueva se deshabilita la opción de NCFs para el usuario actual
            var nuevaEmpStr = HttpHelpers.GetParameter("nuevaEmp", this.Context);
            bool nuevaEmpresa; Boolean.TryParse(nuevaEmpStr, out nuevaEmpresa);
            if (nuevaEmpresa)
                this.hfFormaEntrega.Value = this.FormaEntrega;

            //Si no es una constitución, se deshabilita la opción de cobros de los primeros documentos
            if (!EsConstitucion)
                this.litCostoServicio.Text = "";

            if (this.FormaEntrega == "F")
                mvFull.SetActiveView(vPagoFisico);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.ValidateNext()'
        public override bool ValidateNext()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.ValidateNext()'
        {
            if (this.ddlTipoComprobantes.SelectedItem.Value != "2")
            {
                var wsDGI = new WSMovilDGII.WSMovilDGIISoapClient();
                wsDGI.Open();
                var result = wsDGI.GetContribuyentes(this.RNC, 0, 0, 0, "");
                if (result == "0")
                {
                    Master.ShowMessageError("El contribuyente indicado es inválido.");
                    this.txtRnc.BorderColor = System.Drawing.Color.Red;
                    wsDGI.Close();
                    return false;
                }
                wsDGI.Close();
            }

            //Info de la transacción
            var db = new OFV.CamaraWebsiteEntities();
            var transId = IdTransaciones == 0 ? Convert.ToInt32(Session["transId"]) : IdTransaciones;
            var transaction = db.Transacciones.FirstOrDefault(t => t.TransaccionId == transId && t.UserName == this.Page.User.Identity.Name.ToLower());
            var registro = db.Registros.FirstOrDefault(r => r.RegistroId == transaction.RegistroId);
            bool save = false;
            var totalPago = CostoTransaccion - Credito;
            this.NombreSolicitante.NombreCompleto = this.txtNombre.Text;


            //Se guarda el nombre del solicitnate en la transacción
            if (NombreSolicitante.NombreCompleto.Length > 0 && RNC.Length > 0)
            {
                transaction.Solicitante = this.NombreSolicitante.NombreCompleto;
                transaction.RNCSolicitante = this.RNC;
                transaction.TipoComprobanteId = Convert.ToInt32(this.ddlTipoComprobantes.SelectedItem.Value);
                save = true;
            }
            if (chkExpress.Checked)
            {
                totalPago *= 2;
                transaction.Prioridad = chkExpress.Checked ? (byte)1 : (byte)0;
                save = true;
            }

            if (save) db.SaveChanges();

            //var returnUrl = ConfigurationManager.AppSettings["TransaccionalUrl"] + DefaultQueryString;
            var urlReturnPagoTransaccion = ConfigurationManager.AppSettings["TransaccionalUrlPaginaTransaccion"] + DefaultQueryString;
            if (totalPago > 0)
            {
                pago.RealizarPago(transId, totalPago, NombreSolicitante.NombreCompleto, !string.IsNullOrEmpty(RNC) ? RNC : string.Empty, urlReturnPagoTransaccion, EnumSystemType.CamaraOnline, transaction.CamaraId);
            }
            else
            {
                ProcesarTransaccionSinPago(transId);
            }

            return true;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.btnContinuar_Click(object, EventArgs)'
        protected void btnContinuar_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.btnContinuar_Click(object, EventArgs)'
        {
            ValidateNext();
        }

        
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.btnContinuarSinCosto_Click(object, EventArgs)'
        protected void btnContinuarSinCosto_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.btnContinuarSinCosto_Click(object, EventArgs)'
        {
            var db = new OFV.CamaraWebsiteEntities();
            var transaction = db.Transacciones.FirstOrDefault(t => t.TransaccionId == IdTransaciones && t.UserName == this.Page.User.Identity.Name.ToLower());
            transaction.bPagada = true;
            db.SaveChanges();

            Response.Redirect("~/Empresas/CierreSolicitud.aspx" + DefaultQueryString);
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.btnFormaPago_Click(object, EventArgs)'
        protected void btnFormaPago_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.btnFormaPago_Click(object, EventArgs)'
        {
            switch (rbFormaPago.SelectedValue)
            {
                case "1":
                    this.mvFull.SetActiveView(vGeneracionTicket);
                    break;
                case "2":
                    Int32 nSolicitud;
                    Int32.TryParse(Request.QueryString["nSolicitud"], out nSolicitud);

                    //int tiposervicioid = 0;
                    //int.TryParse(Request.QueryString["TipoServicioId"],out tiposervicioid);

                    //if (tiposervicioid.Equals(Helper.ServicioCopiasCertificadasId)) 
                    //{
                    //  nSolicitud =  SaveTransaccionCopiaCertificada();
                    //  if (nSolicitud > 0 && this.CopiasCertificadas.Count > 0) 
                    //  {
                    //    int res = SaveCopiasCertificadas(nSolicitud);
                    //    if (res <= 0) 
                    //    {
                    //        ErrorMessage = "Ha ocurrido un error al intentar procesar su transacción. Contacte al personal de soporte.";
                    //        return;
                    //    }
                    //    DefaultQueryString = string.Format("nSolicitud={0}", nSolicitud);
                    //  }
                    //}
                    ErrorMessage =
                        @"Su transacción ha sido guardada. Debe depositar los documentos 
                          en la camara seleccionada para completar su solicitud.";
                    //Aqui grabo el log de la transaccion que se creo
                    LogTransaccionesMethods.GrabarLogTransacciones(nSolicitud, "/Empresas/VerDetalleTransaccion.aspx" + DefaultQueryString, true, this.Page.User.Identity.Name);
                    Response.Redirect("/Empresas/VerDetalleTransaccion.aspx" + DefaultQueryString);
                    break;
            }
        }

        private int SaveCopiasCertificadas(int nSolicitud)
        {
            var dbWeb = new OFV.CamaraWebsiteEntities();

            foreach (var copia in this.CopiasCertificadas)
            {
                copia.TransaccionId = nSolicitud;
                dbWeb.TransaccionCopiasCertificadas.AddObject(copia);
            }

            return dbWeb.SaveChanges();
        }

        private int SaveTransaccionCopiaCertificada()
        {
            var transRep = new OFV.TransaccionesRepository();
            OFV.Transacciones trans = new Transacciones();
            OFV.Transacciones subTrans = new Transacciones();
            int transId = 0;
            int registroid = int.Parse(Request.QueryString["RegistroId"]);
            int tipoSociedadId = int.Parse(Request.QueryString["TipoSociedadId"]);
            int NoRegistro = 0;
            int.TryParse(txtNoRegistro.Text, out NoRegistro);
            var dbSRM = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);
            var soc = dbSRM.SociedadesRegistros.Where(s => s.NumeroRegistro == NoRegistro).FirstOrDefault();

            var profile = OficinaVirtualUserProfile.GetUserProfile(this.Page.User.Identity.Name.ToLower());

            trans.Fecha = DateTime.Now;
            trans.EstatusTransId = 21;
            trans.RegistroId = registroid;
            //servicioid copia certificada
            trans.ServicioId = 415;
            trans.CamaraId = this.CamaraId;
            trans.UserName = this.Page.User.Identity.Name.ToLower();
            trans.TipoSociedadId = tipoSociedadId;
            trans.Solicitante = profile.NombreSolicitante;
            trans.RNCSolicitante = profile.RNC;
            trans.NombreContacto = profile.NombreSolicitante;
            trans.TelefonoContacto = profile.Telefono;
            trans.NombreSocialPersona = this.txtDenominacion.Text;
            trans.NumeroRegistro = NoRegistro;
            trans.Tipo = 2;
            if (soc != null)
            {
                trans.FechaAsamblea = soc.Sociedades.FechaAsamblea;
                trans.CapitalSocial = soc.Registros.CapitalSocial;
            }


            transRep.Add(trans);

            transRep.Save();
            transId = trans.TransaccionId;

            transRep = new OFV.TransaccionesRepository();

            #region Subtransaccion
            subTrans.SubTransaccionId = trans.TransaccionId;
            subTrans.Fecha = DateTime.Now;
            subTrans.EstatusTransId = 21;
            subTrans.RegistroId = registroid;
            subTrans.ServicioId = 689;
            subTrans.CamaraId = this.CamaraId;
            subTrans.UserName = this.Page.User.Identity.Name.ToLower();
            subTrans.TipoSociedadId = tipoSociedadId;
            subTrans.Solicitante = profile.NombreSolicitante;
            subTrans.RNCSolicitante = profile.RNC;
            subTrans.NombreContacto = profile.NombreSolicitante;
            subTrans.TelefonoContacto = profile.Telefono;
            subTrans.NombreSocialPersona = this.txtDenominacion.Text;
            subTrans.NumeroRegistro = NoRegistro;
            subTrans.Tipo = 2;
            if (soc != null)
            {
                trans.FechaAsamblea = soc.Sociedades.FechaAsamblea;
                trans.CapitalSocial = soc.Registros.CapitalSocial;
            }
            #endregion

            transRep.Add(subTrans);
            transRep.Save();
            //Grabo el log de la transaccion.
            LogTransaccionesMethods.GrabarLogTransacciones(transId, "Solicitud Copias Certificadas", true, this.Page.User.Identity.Name);

            return transId;

        }

        #endregion

        #region Validaciones
        private void LoadData(int transaccionId, string camaraId)
        {
            //Load Transaccion
            var dbWebSite = new OFV.CamaraWebsiteEntities();
            var dbComun = new CamaraComunEntities();
            var trans = dbWebSite.Transacciones.FirstOrDefault(
                        t => t.TransaccionId == transaccionId && t.UserName == this.Page.User.Identity.Name.ToLower());

            if (trans == null)
            {
                ErrorMessage = "Numero de solicitud invalido o no existe.";
                Response.Redirect("~/Empresas/Oficina.aspx");
            }

            var helper = new TransaccionDevueltaHelper(Request);

            if (trans.bPagada && !helper.EstaDevuelta())
                Response.Redirect(String.Format("~/Empresas/CierreSolicitud.aspx?nSolicitud={0}", IdTransaciones));

            Transaccion = trans;

            //Nombre de la empresa
            var nombreSocial = String.Empty;
            if (trans.NumeroRegistro.HasValue)
            {
                var dbSRM = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId);
                var soc = dbSRM.SociedadesRegistros.Where(s => s.NumeroRegistro == trans.NumeroRegistro).FirstOrDefault();
                if (soc != null)
                    nombreSocial = soc.Sociedades.NombreSocial;
            }
            else
            {
                var registro = dbWebSite.Sociedades
                    .Where(s => s.RegistroId == trans.RegistroId)
                    .FirstOrDefault();
                nombreSocial = registro != null
                                   ? registro.NombreSocial
                                   : trans.NombreSocialPersona;
            }
            this.txtDenominacion.Text = nombreSocial;

            txtFecha.Text = trans.Fecha.ToStringDom();
            txtNoRegistro.Text = trans.NumeroRegistro.HasValue ? trans.NumeroRegistro.ToString() : String.Empty;
            pnlNumeroRegistro.Visible = trans.NumeroRegistro.HasValue;

            this.CamaraId = trans.CamaraId;

            chkExpress.Checked = Convert.ToBoolean(trans.Prioridad);

            SetCostoServicio(trans);

            LoadDocumentos((trans.Prioridad == 1));
            LoadDetalleFactura(trans);
            LoadServicios(trans);
            LoadCostoExpress(false, true);


            var factura = ObtenerFactura(transaccionId);
            Credito = factura?.TotalFactura ?? 0;
            lblCredito.Text = string.Format("{0:n}", Credito);
            lblTotal.Text = string.Format("{0:n}", CostoTransaccion - Credito);
        }

        private void LoadServicios(Transacciones trans)
        {
            var servicioIds = trans.GetServicioTransacciones();
            if (servicioIds.Count > 0 && servicioIds.FirstOrDefault() > 0)
            {
                //Listado de servicios
                var dbComun = new CamaraComunEntities();
                var servicios = dbComun.Servicio.Where(s => servicioIds.Contains(s.ServicioId) && s.SiteVisible);
                this.rpServiciosSeleccionados.DataSource = servicios;
                this.rpServiciosSeleccionados.DataBind();
            }
        }

        private void SetCostoServicio(OFV.Transacciones trans)
        {
            var repTransacciones = new OFV.TransaccionesRepository();
            CostoServicio = repTransacciones.GetCostoTransaccion(trans, Helper.PorcentajeVIP)
                            + repTransacciones.GetCostoTransaccionSub(trans, Helper.PorcentajeVIP, false, trans.Prioridad == 1);
        }

        private void LoadCostoExpress(bool persistExpress, bool bExpress)
        {
            var repServicio = new ServicioRepository();
            var costoServicio = repServicio.GetTotalServicio(Transaccion.ServicioId, Transaccion.CamaraId,
                                                             Transaccion.CapitalSocial,
                                                             Transaccion.ModificacionCapital, bExpress,
                                                             Helper.PorcentajeVIP, Transaccion);

            var docs = persistExpress
                           ? this.DocumentosSeleccionados
                           : this.DocumentosSeleccionados.Select(Utils.Clone).ToList();

            docs.ForEach(delegate (ServicioDocumentoRequerido doc)
            {
                doc.bExpress = bExpress;
                doc.PorcentajeVIP = Helper.PorcentajeVIP;
            });


            var costoVIP = this.CostoTransaccion + this.CostoTransaccion * Helper.PorcentajeVIP / 100;
            litCostoServicio.Text = String.Format("{0:n}", costoVIP);

            if (!persistExpress) return;

            CostoServicio = costoServicio;
            LoadDocumentos(bExpress);
            LoadDetalleFactura(Transaccion);
        }

        private void LoadDetalleFactura(Transacciones tnx)
        {
            var detalle = new List<DetalleServicio>();
            var repTransaccion = new OFV.TransaccionesRepository();
            var dbComun = new CamaraComunEntities();

            var repServicio = new ServicioRepository();
            tnx.Prioridad = chkExpress.Checked ? (byte)1 : (byte)0;

            var considerarMods = true;
            var servicio = dbComun.Servicio.First(s => s.ServicioId == tnx.ServicioId);
            int.TryParse(Request.QueryString["cantidadCertificaciones"], out int cantidadCertificaciones);
            CantidadCertificaciones = cantidadCertificaciones <= 0 ? 1 : cantidadCertificaciones;

            detalle.Add(
                new DetalleServicio()
                {
                    Descripcion = servicio.DescripcionWeb ?? servicio.Descripcion,
                    Cantidad = CantidadCertificaciones,
                    Costo = repTransaccion.GetCostoTransaccionCabecera(tnx, Helper.PorcentajeVIP)
                }
                );
            if (!servicio.SeCobraEnSubTransaccion && servicio.TransaccionJerarquia > 0 ||
                Helper.ServiciosHeaderIds.Contains(servicio.ServicioId))
                considerarMods = false;

            if (tnx.SubTransacciones.Count() > 0)
            {

                foreach (var subtnx in tnx.SubTransacciones)
                {
                    var detalleFact = new DetalleServicio
                    {
                        Descripcion = subtnx.NombreServicio,
                        Costo = repTransaccion.GetCostoTransaccionSub
                                                  (subtnx, Helper.PorcentajeVIP, considerarMods, tnx.Prioridad == 1)

                    };
                    if (detalleFact.Costo > 0)
                    {
                        servicio = dbComun.Servicio.First(s => s.ServicioId == subtnx.ServicioId);
                        detalleFact.Descripcion = servicio.DescripcionWeb ?? servicio.Descripcion;
                        detalle.Add(detalleFact);
                    }

                    if (considerarMods)
                    {
                        var repTemp = new ServicioRepository();
#pragma warning disable CS0219 // The variable 'subtotal' is assigned but its value is never used
                        var subtotal = 0M;
#pragma warning restore CS0219 // The variable 'subtotal' is assigned but its value is never used
                        var service = repTemp.GetServicio(subtnx.ServicioId).FirstOrDefault();
                        if (service != null && !service.SeCobraEnSubTransaccion && service.TransaccionJerarquia > 0)
                            considerarMods = false;
                    }
                }
            }


            detalle.Add(new DetalleServicio
            {
                Descripcion = "Registro de Documentos",
                Costo = GetCostoDocumentos(this.DocumentosSeleccionados, (tnx.Prioridad == 1))
            });



            rpDetalleServicio.DataSource = detalle;
            rpDetalleServicio.DataBind();

            if (detalle.Count > 0)
            {
                ((Label)this.rpDetalleServicio.FindControlInFooter("txtCostoTotalTransaccion")).Text =
                    String.Format("{0:n}",
                                  detalle.Sum(d => d.Costo * d.Cantidad));

                lblTotalTransaccion.Text = String.Format("{0:n}", detalle.Sum(d => d.Costo * d.Cantidad));
            }

            this.CostoTransaccion = detalle.Sum(d => d.Costo * d.Cantidad);
        }

        private void LoadDocumentos(bool esVip)
        {
            //Codigo Agregado para que funcione en el nuevo escenario.
            if (this.DocumentosSeleccionados.Count <= 0) LoadDocumentoSeleccionados();
            rpDocumentos.DataSource = this.DocumentosSeleccionados;
            rpDocumentos.DataBind();

            var costoDocumentos = GetCostoDocumentos(this.DocumentosSeleccionados, esVip);

            var ctrlCosto = this.rpDocumentos.FindControlInFooter("txtCostoTotalTransaccion");
            if (ctrlCosto is Label)
            {
                ((Label)ctrlCosto).Text = String.Format("{0:n}", CostoServicio + costoDocumentos);
                lblTotalTransaccion.Text = String.Format("{0:n}", CostoServicio + costoDocumentos);
            }
              

            ((Label)this.rpDocumentos.FindControlInFooter("txtCostoTransaccion")).Text = String.Format("{0:n}",
                                                                                                        costoDocumentos);

            lblTotalTransaccion.Text = String.Format("{0:n}", costoDocumentos);
        }

        private void LoadDocumentoSeleccionados()
        {
            var transacciones = new OFV.TransaccionDocumentosController();
            var repServicioRequerido = new ServicioDocumentoRequeridoRepository();
            var repServicioDocSeleccionados = transacciones.GetDocumentosSeleccionados(Transaccion.TransaccionId);

            var documentos = repServicioRequerido.GetDocumentosSeleccionados(Transaccion.ServicioId,
                                                                             Transaccion.TipoSociedadId,
                                                                             Transaccion.TransaccionId);

            foreach (var docSeleccionado in repServicioDocSeleccionados)
            {
                var docAgregar = documentos.FirstOrDefault(doc => doc.TipoDocumentoId == docSeleccionado.TipoDocumentoId);
                if (docAgregar == null) continue;


                this.DocumentosSeleccionados.Add(
                    new ServicioDocumentoRequerido
                    {
                        CantidadCopia = docSeleccionado.CantidadCopia,
                        CantidadOriginal = docSeleccionado.CantidadOriginal,
                        CostoCopia = docAgregar.TipoDocumento.CostoCopia,
                        CostoOriginal = docAgregar.TipoDocumento.CostoOriginal,
                        TipoDocumentoId = docAgregar.TipoDocumentoId,
                        Nombre = docAgregar.TipoDocumento.Nombre,
                        TipoSociedadId = Transaccion.TipoSociedadId,
                        ServicioId = Transaccion.ServicioId,
                        Requerido = docAgregar.Requerido
                    });
            }
        }

        private decimal GetCostoDocumentos(IEnumerable<ServicioDocumentoRequerido> listServicios, bool EsVip)
        {
            return EsConstitucion
                       ? listServicios.GetTotal(Helper.CantidadCopiasGratisNuevaEmpresa,
                                                Helper.CantidadOriginalGratisNuevaEmpresa, EsVip)
                       : listServicios.GetTotal(EsVip);

        }


        // Loading Factura From Camara
        private void LoadDataFacturaSrm(int facturaSrmId)
        {
            //Activo vista de Factura Srm
            this.MvFacturaTrans.ActiveViewIndex = 1;

            //Loading Data Factura
            var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);

            var factura = dbSrm.Facturas.FirstOrDefault(a => a.FacturaId == facturaSrmId);
            var detalles = factura.TransaccionDetalle.ToList();

            rpServComplementarios.DataSource = detalles;
            rpServComplementarios.DataBind();

            var lbl = (Label)this.rpServComplementarios.FindControlInFooter("txtCostoTransaccion");
            lbl.Text = String.Format("{0:n}", this.CostoServicio = detalles.Sum(a => a.TotalBruto).Value2());
        }


        #endregion

        #region Facturacion
        private Facturas GenerarFacturas(OFV.Transacciones tnx, string nombreTipoSociedad, IEnumerable<DTO.ServicioDTO> servicios,
            Dictionary<int, Decimal> costoServicios, int? tipoComprobanteId)
        {
            var repTransacciones = new OFV.TransaccionesRepository();
            var ultimaFactura = ObtenerFactura(tnx.TransaccionId);
            var Credito = (ultimaFactura != null && ultimaFactura.TotalFactura > 0) ? ultimaFactura.TotalFactura : 0;

            var servicio = servicios.FirstOrDefault(a => a.ServicioId == tnx.ServicioId);
            var nombreServicio = servicio.Descripcion;
            var cuentaServicio = servicio.Cuenta;
            //repTransacciones.GetCostoTransaccionCabecera(tnx, Helper.PorcentajeVIP);
            var costo = costoServicios[tnx.TransaccionId];
            var factura = new Facturas
            {
                Complementaria = false,
                Estado = 1,
                Fecha = DateTime.Now,
                TipoNcf = tipoComprobanteId > 0 ? tipoComprobanteId.ToString() : Helper.TipoComprobanteIdDefault,
                TransaccionId = tnx.TransaccionId,
                Usuario = this.Page.User.Identity.Name,
                CamaraId = tnx.CamaraId,
                PagoAnterior = Credito,
                CobroPorServicio = costo
            };

             
            var td = new TransaccionDetalle
            {
                //Cantidad = 1,
                Cantidad = CantidadCertificaciones,
                Cuenta = cuentaServicio,
                Detalle = nombreServicio + " - " + nombreTipoSociedad,
                PrecioUnitario = costo,
                Descuento = 0,
            };

            factura.TransaccionDetalle.Add(td);

            foreach (var subtnx in tnx.SubTransacciones)
            {
                var subt = subtnx;
                var service = servicios.FirstOrDefault(a => a.ServicioId == subt.ServicioId);

                if (service != null && !service.bFactura)
                    continue;

                costo = costoServicios[subtnx.TransaccionId]; //repTransacciones.GetCostoTransaccionSub(subtnx, Helper.PorcentajeVIP);
                td = new TransaccionDetalle
                {
                    Cantidad = 1,
                    Cuenta = service.Cuenta,
                    Detalle = service.Descripcion,
                    PrecioUnitario = costo,
                    Descuento = 0,
                };

                factura.TransaccionDetalle.Add(td);
            }

            var cantidadExonera = EsConstitucion ? Helper.CantidadOriginalGratisNuevaEmpresa : 0;

            var docCopias = this.DocumentosSeleccionados.Where(a => a.CostoOriginal > 0 && a.CantidadOriginal > 0).ToList();

            if (docCopias.Count > 0)
            {
                td = new TransaccionDetalle
                {
                    // Preguntar si se requiere cobrar por la cantidad de documentos subidos o por el servicio adquirido.
                    //Cantidad = 1,
                    Cantidad = (int)docCopias.Sum(a => a.CantidadOriginal) - cantidadExonera,
                    Cuenta = cuentaServicio,
                    Detalle = "Registro Documentos Originales",
                    FacturaId = factura.FacturaId,
                    PrecioUnitario = docCopias.FirstOrDefault().CostoOriginalFinal,
                    Descuento = 0m
                };

                if (td.Cantidad <= 0)
                {
                    td.Cantidad = 0; td.PrecioUnitario = 0;
                }

                factura.TransaccionDetalle.Add(td);
            }


            cantidadExonera = EsConstitucion ? Helper.CantidadCopiasGratisNuevaEmpresa : 0;

            //Documentos Copias
            docCopias = this.DocumentosSeleccionados.Where(a => a.CostoCopia > 0 && a.CantidadCopia > 0).ToList();

            if (docCopias.Count > 0)
            {
                td = new TransaccionDetalle
                {
                    // Preguntar si se requiere cobrar por la cantidad de documentos subidos o por el servicio adquirido.
                    //Cantidad = 1,
                    Cantidad = (int)docCopias.Sum(a => a.CantidadOriginal) - cantidadExonera,
                    Cuenta = cuentaServicio,
                    Detalle = "Registro Documentos Copias",
                    FacturaId = factura.FacturaId,
                    PrecioUnitario = docCopias.FirstOrDefault().CostoCopiaFinal,
                    Descuento = 0m
                };

                if (td.Cantidad <= 0)
                {
                    td.Cantidad = 0; td.PrecioUnitario = 0;
                }

                factura.TransaccionDetalle.Add(td);
            }



            factura.TotalFactura = factura.TransaccionDetalle.Sum(a => (a.Cantidad * a.PrecioUnitario) - a.Descuento);

            if (!factura.Credito.HasValue)
                factura.Credito = 0;  
            
            this.CostoTransaccion = factura.TotalFactura;
            factura.TotalFactura -= Credito;
            
            return factura;
        }

        private string SendInvoiceToAccounting(Facturas header, string rnc, string nombresolicitante, int? tipoComprobanteId)
        {
            if (!tipoComprobanteId.HasValue)
                throw new InvalidOperationException("No se especificó un tipo de comprobante para esta transacción");

            var facturacion = new ServicioFacturacion();
#pragma warning disable CS0168 // The variable 'outTipoNcfId' is declared but never used
            int outTipoNcfId;
#pragma warning restore CS0168 // The variable 'outTipoNcfId' is declared but never used

            var servicios = (from TransaccionDetalle data in header.TransaccionDetalle
                             select new wsFacturacion.Servicio
                             {
                                 Cantidad = data.Cantidad.ToString(),
                                 Codigo = data.Cuenta,
                                 Descripcion = data.Detalle,
                                 Descuento = data.Descuento,
                                 PrecioUnitario = data.PrecioUnitario,
                                 Total = data.PrecioUnitario,
                                 TransaccionId = header.TransaccionId.HasValue ? header.TransaccionId.Value : 0
                             }).ToArray();

            //Se están enviando campos en cero a gestión. No importa porque ya los maneja el sistema de gestión
            var tarjeta = new OFV.TransaccionesTarjeta()
            {
                AnoVencimiento = "",
                MesVencimiento = "",
                bCancelada = false,
                bProcesada = true,
                FacturaId = 0,
                FechaTransaccion = DateTime.Now,
                NombreBanco = "Nobox Transaccional",
                NumeroTarjeta = "",
                NombreTarjeta = "",
                TipoTarjeta = "1"
            };
            var pagos = new[]
                            {
                                new RegistroPago
                                    {
                                        Fecha = header.Fecha,
                                        MetodoPago = Helper.MetodoPago, // 2, Forma Pago Tarjeta Credito
                                        Monto = header.TotalFactura,
                                        Nota = tarjeta.NombreBanco,
                                        Refenrencia = tarjeta.NumeroTarjeta,
                                        TarjetaCredito = tarjeta.NumeroTarjeta
                                    }
                            };
            if (false)
            {
#pragma warning disable CS0162 // Unreachable code detected
                var factura = facturacion.GenerarFactura(rnc.RemoverFormato(),
#pragma warning restore CS0162 // Unreachable code detected
                    nombresolicitante, tipoComprobanteId.Value, header.CamaraId,
                    Helper.UsuarioFacturacion, servicios, pagos,false);

                return factura.NCF;
            }
            else
            {
                return string.Format("A0200102101000000") + (new Random(1)).Next(99).ToString();
            }
        }

        private Facturas ObtenerFactura(long transaccionId)
        {
            var db = new OFV.CamaraWebsiteEntities();
            var factura = (from t in db.Facturas
                           where t.TransaccionId.HasValue && t.TransaccionId.Value == transaccionId
                           select t).OrderByDescending(x => x.FacturaId).FirstOrDefault();

            return factura;
        }

        //Metodo que se llama después que el transaccional retorna un resultado
        private void ProcesarPagoTarjeta(VisanetDTO response, int transId = 0, string medioDePago = "")
        {

           
            var redirectUrl = String.Empty;

            var dbWebsite = new OFV.CamaraWebsiteEntities();
            var dbComun = new CamaraComunEntities();

            int transaccionId = 0;
            var factu = new OFV.Facturas();
            transaccionId = PagoVisanetService.GetTransaccionByOrderIdAndSystemType(response.OrderID,
                                                                                EnumSystemType.CamaraOnline);

            var transaccion = dbWebsite.Transacciones.FirstOrDefault(t => t.TransaccionId == transaccionId
                && t.UserName == this.Page.User.Identity.Name.ToLower());
            
            if (transaccion != null && transaccion.TransaccionId > 0)
            {
                #region Caching de propiedades fuera del Transaction Scope (para evitar llamar el MSDTC)
                var idServicio = dbWebsite.Transacciones
                                    .Where(t => t.TransaccionId == transaccion.TransaccionId)
                                    .Select(t => t.ServicioId).FirstOrDefault();
                if (idServicio == 0)
                {
                    Master.ShowMessageError("No existe una transacción pendiente. El pago no puede ser realizado. Intente nuevamente.");
                    return;
                }

                #region Verificacion de transaccion nula
               // if (transaccion.bPagada)
                //    redirectUrl = "~/Empresas/CierreSolicitud.aspx" + DefaultQueryString;

                //var verifyTransacion = dbWebsite.TransaccionesTarjeta.FirstOrDefault(
                //    a => a.Facturas.TransaccionId == transaccion.TransaccionId && a.bCancelada == false);
                //var transHelper = new TransaccionDevueltaHelper(Request);
                ////if (verifyTransacion != null && !transHelper.EstaDevuelta())
                //{
                //    Master.ShowMessageError("La transacción ha sido registrada anteriormente. Vea sus transacciones pendientes en <a href='/Empresas/Oficina.aspx'>transacciones en progreso.</a>");
                //    return;
                //}
                #endregion

                var tipoSociedad = dbComun.TipoSociedad
                    .FirstOrDefault(a => a.TipoSociedadId == transaccion.TipoSociedadId);
                var nombreTipoSociedad = tipoSociedad != null ? tipoSociedad.Descripcion : String.Empty;

                var nombresolicitante = this.NombreSolicitante;
                var rnc = this.RNC;

                //Asignando la transaccion como prioritaria.
                //transaccion.Prioridad = chkExpress.Checked ? (byte)1 : (byte)0;

                //Servicios a ser facturados
                var servicios = new List<DTO.ServicioDTO>();
                var costosServicios = new Dictionary<int, decimal>();
                var repTransaccion = new OFV.TransaccionesRepository();

                servicios.AddRange(dbComun.Servicio.Where(s => s.ServicioId == transaccion.ServicioId)
                        .Select(s => new DTO.ServicioDTO() { Descripcion = s.Descripcion, ServicioId = s.ServicioId, Cuenta = s.Cuenta, bFactura = s.SiteVisible })
                        .ToList());

                var considerarMods = true;

                costosServicios[transaccion.TransaccionId] = repTransaccion.GetCostoTransaccionCabecera(transaccion, Helper.PorcentajeVIP);

                //Validacion de servicios para los que no se cobran modificaciones extras
                var servicioInfo = dbComun.Servicio.Where(s => s.ServicioId == transaccion.ServicioId).FirstOrDefault();
                if (servicioInfo != null && !servicioInfo.SeCobraEnSubTransaccion && servicioInfo.TransaccionJerarquia > 0 ||
                   Helper.ServiciosHeaderIds.Contains(servicioInfo.ServicioId))
                    considerarMods = false;

                if (transaccion.SubTransacciones.Count() > 0)
                {
                    var ids = transaccion.SubTransacciones.Select(st => st.ServicioId).ToList();
                    servicios.AddRange(
                        dbComun.Servicio.Where(s => ids.Contains(s.ServicioId))
                            .Select(s => new DTO.ServicioDTO() { Descripcion = s.Descripcion, ServicioId = s.ServicioId, Cuenta = s.Cuenta })
                            .ToList());

                    foreach (var subtnx in transaccion.SubTransacciones)
                    {
                        if (!costosServicios.ContainsKey(subtnx.TransaccionId))
                            costosServicios[subtnx.TransaccionId] = repTransaccion
                               .GetCostoTransaccionSub(subtnx, Helper.PorcentajeVIP, considerarMods, transaccion.Prioridad == 1);

                        if (considerarMods)
                        {
                            var repTemp = new ServicioRepository();
#pragma warning disable CS0219 // The variable 'subtotal' is assigned but its value is never used
                            var subtotal = 0M;
#pragma warning restore CS0219 // The variable 'subtotal' is assigned but its value is never used
                            var service = repTemp.GetServicio(subtnx.ServicioId).FirstOrDefault();
                            if (service != null && !service.SeCobraEnSubTransaccion && service.TransaccionJerarquia > 0)
                                considerarMods = false;
                        }
                    }
                }

                dbComun.Dispose();

                #endregion
                using (var scope = new System.Transactions.TransactionScope())
                {
                    //Se marca la factura como pagada
                    transaccion.NombreContacto = String.IsNullOrEmpty(transaccion.NombreContacto)
                                                    ? nombresolicitante.NombreCompleto
                                                    : transaccion.NombreContacto;
                    transaccion.RNCSolicitante = String.IsNullOrEmpty(transaccion.RNCSolicitante)
                                                    ? rnc
                                                    : transaccion.RNCSolicitante;
                    transaccion.Solicitante = String.IsNullOrEmpty(transaccion.Solicitante)
                                                    ? nombresolicitante.NombreCompleto
                                                    : transaccion.Solicitante;

                    //Se crean las Facturas en el WebSite
                    var factura = GenerarFacturas(transaccion, nombreTipoSociedad, servicios, costosServicios, transaccion.TipoComprobanteId);
                    factura.Ncf = SendInvoiceToAccounting(factura, rnc, nombresolicitante.NombreCompleto, transaccion.TipoComprobanteId);
                    factu = factura;

                    dbWebsite.Facturas.AddObject(factura);

                    //Se agrega la informacion de la tarjeta de crédito
                    var tarjeta = new OFV.TransaccionesTarjeta()
                    {
                        AnoVencimiento = "",
                        MesVencimiento = "",
                        bCancelada = false,
                        bProcesada = true,
                        FacturaId = 0,
                        FechaTransaccion = DateTime.Now,
                        NombreBanco = "Nobox Transaccional",
                        NumeroTarjeta = response.Tarjeta,
                        NombreTarjeta = transaccion.NombreContacto,
                        TipoTarjeta = "1",
                        MedioDePago = medioDePago
                    };
                    factura.TransaccionesTarjeta.Add(tarjeta);

                    transaccion.NCF = factura.Ncf;
                    transaccion.TipoNcf = transaccion.TipoComprobanteId.ToString();
                    transaccion.bPagada = true;

                    dbWebsite.SaveChanges();

                    scope.Complete();

                }
                //Aqui grabo al srm
                var helper = new Helper();
                var Error = "";
                //Se graba al srm
                bool saved = helper.GrabarAlSrm(transaccion.CamaraId, transaccion.TransaccionId, transaccion.NombreContacto,
                                   transaccion.TelefonoContacto, out Error);
                //

                ErrorMessage = Error;
                if (saved)
                {
                    //Almaceno valor para poder imprimir
                    if (!DefaultQueryString.Contains("FacturaId="))
                        DefaultQueryString = String.Format("FacturaId={0}", factu.FacturaId);
                    redirectUrl = "/Empresas/CierreSolicitud.aspx" + DefaultQueryString;
                }
                else
                {
                    redirectUrl = string.Format("/Empresas/VerDetalleTransaccion.aspx?nSolicitud={0}&VerDetalle=true", transaccion.TransaccionId);
                }
            }

            if (!string.IsNullOrWhiteSpace(redirectUrl)) Response.Redirect(redirectUrl);
        }

        private void ProcesarTransaccionSinPago(int transaccionId = 0, string medioDePago = "")
        {
            var redirectUrl = String.Empty;

            var dbWebsite = new OFV.CamaraWebsiteEntities();
            var dbComun = new CamaraComunEntities();

          
            var factu = new OFV.Facturas();
           

            var transaccion = dbWebsite.Transacciones.FirstOrDefault(t => t.TransaccionId == transaccionId
                && t.UserName == this.Page.User.Identity.Name.ToLower());

            if (transaccion != null && transaccion.TransaccionId > 0)
            {
                #region Caching de propiedades fuera del Transaction Scope (para evitar llamar el MSDTC)
                var idServicio = dbWebsite.Transacciones
                                    .Where(t => t.TransaccionId == transaccion.TransaccionId)
                                    .Select(t => t.ServicioId).FirstOrDefault();
                if (idServicio == 0)
                {
                    Master.ShowMessageError("No existe una transacción pendiente. El pago no puede ser realizado. Intente nuevamente.");
                    return;
                }

                #region Verificacion de transaccion nula
                //if (transaccion.bPagada)
                //    redirectUrl = "~/Empresas/CierreSolicitud.aspx" + DefaultQueryString;

                //var verifyTransacion = dbWebsite.TransaccionesTarjeta.FirstOrDefault(
                //    a => a.Facturas.TransaccionId == transaccion.TransaccionId && a.bCancelada == false);

                //var transHelper = new TransaccionDevueltaHelper(Request);
                //if (verifyTransacion != null && !transHelper.EstaDevuelta())
                //{
                //    Master.ShowMessageError("La transacción ha sido registrada anteriormente. Vea sus transacciones pendientes en <a href='/Empresas/Oficina.aspx'>transacciones en progreso.</a>");
                //    return;
                //}
                #endregion

                var tipoSociedad = dbComun.TipoSociedad
                    .FirstOrDefault(a => a.TipoSociedadId == transaccion.TipoSociedadId);
                var nombreTipoSociedad = tipoSociedad != null ? tipoSociedad.Descripcion : String.Empty;

                var nombresolicitante = this.NombreSolicitante;
                var rnc = this.RNC;

                //Asignando la transaccion como prioritaria.
                //transaccion.Prioridad = chkExpress.Checked ? (byte)1 : (byte)0;

                //Servicios a ser facturados
                var servicios = new List<DTO.ServicioDTO>();
                var costosServicios = new Dictionary<int, decimal>();
                var repTransaccion = new OFV.TransaccionesRepository();

                servicios.AddRange(dbComun.Servicio.Where(s => s.ServicioId == transaccion.ServicioId)
                        .Select(s => new DTO.ServicioDTO() { Descripcion = s.Descripcion, ServicioId = s.ServicioId, Cuenta = s.Cuenta, bFactura = s.SiteVisible })
                        .ToList());

                var considerarMods = true;

                costosServicios[transaccion.TransaccionId] = repTransaccion.GetCostoTransaccionCabecera(transaccion, Helper.PorcentajeVIP);

                //Validacion de servicios para los que no se cobran modificaciones extras
                var servicioInfo = dbComun.Servicio.Where(s => s.ServicioId == transaccion.ServicioId).FirstOrDefault();
                if (servicioInfo != null && !servicioInfo.SeCobraEnSubTransaccion && servicioInfo.TransaccionJerarquia > 0 ||
                   Helper.ServiciosHeaderIds.Contains(servicioInfo.ServicioId))
                    considerarMods = false;

                if (transaccion.SubTransacciones.Count() > 0)
                {
                    var ids = transaccion.SubTransacciones.Select(st => st.ServicioId).ToList();
                    servicios.AddRange(
                        dbComun.Servicio.Where(s => ids.Contains(s.ServicioId))
                            .Select(s => new DTO.ServicioDTO() { Descripcion = s.Descripcion, ServicioId = s.ServicioId, Cuenta = s.Cuenta })
                            .ToList());

                    foreach (var subtnx in transaccion.SubTransacciones)
                    {
                        if (!costosServicios.ContainsKey(subtnx.TransaccionId))
                            costosServicios[subtnx.TransaccionId] = repTransaccion
                               .GetCostoTransaccionSub(subtnx, Helper.PorcentajeVIP, considerarMods, transaccion.Prioridad == 1);

                        if (considerarMods)
                        {
                            var repTemp = new ServicioRepository();
#pragma warning disable CS0219 // The variable 'subtotal' is assigned but its value is never used
                            var subtotal = 0M;
#pragma warning restore CS0219 // The variable 'subtotal' is assigned but its value is never used
                            var service = repTemp.GetServicio(subtnx.ServicioId).FirstOrDefault();
                            if (service != null && !service.SeCobraEnSubTransaccion && service.TransaccionJerarquia > 0)
                                considerarMods = false;
                        }
                    }
                }

                dbComun.Dispose();

                #endregion
                using (var scope = new System.Transactions.TransactionScope())
                {
                    //Se marca la factura como pagada
                    transaccion.NombreContacto = String.IsNullOrEmpty(transaccion.NombreContacto)
                                                    ? nombresolicitante.NombreCompleto
                                                    : transaccion.NombreContacto;
                    transaccion.RNCSolicitante = String.IsNullOrEmpty(transaccion.RNCSolicitante)
                                                    ? rnc
                                                    : transaccion.RNCSolicitante;
                    transaccion.Solicitante = String.IsNullOrEmpty(transaccion.Solicitante)
                                                    ? nombresolicitante.NombreCompleto
                                                    : transaccion.Solicitante;

                    //Se crean las Facturas en el WebSite
                    var factura = GenerarFacturas(transaccion, nombreTipoSociedad, servicios, costosServicios, transaccion.TipoComprobanteId);
                    factura.Ncf = SendInvoiceToAccounting(factura, rnc, nombresolicitante.NombreCompleto, transaccion.TipoComprobanteId);
                    factu = factura;

                    dbWebsite.Facturas.AddObject(factura);

                    //Se agrega la informacion de la tarjeta de crédito
                    var tarjeta = new OFV.TransaccionesTarjeta()
                    {
                        AnoVencimiento = "",
                        MesVencimiento = "",
                        bCancelada = false,
                        bProcesada = true,
                        FacturaId = 0,
                        FechaTransaccion = DateTime.Now,
                        NombreBanco = "Nobox Transaccional",
                        NumeroTarjeta = "0000-0000-0000-0000",
                        NombreTarjeta = transaccion.NombreContacto,
                        TipoTarjeta = "1",
                        MedioDePago = medioDePago
                    };
                    factura.TransaccionesTarjeta.Add(tarjeta);

                    transaccion.NCF = factura.Ncf;
                    transaccion.TipoNcf = transaccion.TipoComprobanteId.ToString();
                    transaccion.bPagada = true;

                    dbWebsite.SaveChanges();

                    scope.Complete();

                }
                //Aqui grabo al srm
                var helper = new Helper();
                var Error = "";
                //Se graba al srm
                bool saved = helper.GrabarAlSrm(transaccion.CamaraId, transaccion.TransaccionId, transaccion.NombreContacto,
                                   transaccion.TelefonoContacto, out Error);
                //

                ErrorMessage = Error;
                if (saved)
                {
                    //Almaceno valor para poder imprimir
                    DefaultQueryString = String.Format("FacturaId={0}", factu.FacturaId);
                    redirectUrl = "/Empresas/CierreSolicitud.aspx" + DefaultQueryString;
                }
                else
                {
                    redirectUrl = string.Format("/Empresas/VerDetalleTransaccion.aspx?nSolicitud={0}&VerDetalle=true",
                                                transaccion.TransaccionId);
                }
            }

            if (redirectUrl.Length > 0)
                Response.Redirect(redirectUrl);
        }


        private String RNC
        {
            get
            {
                if (txtRnc.Text.Length > 0)
                    return txtRnc.Text;

                if (!String.IsNullOrEmpty(this.Transaccion.RNCSolicitante))
                    return this.Transaccion.RNCSolicitante;

                if (this.Page.User.Identity.IsAuthenticated)
                {
                    var usr = OficinaVirtualUserProfile.GetUserProfile();
                    return usr != null ? usr.RNC : String.Empty;
                }

                return String.Empty;
            }
        }

        private Solicitante NombreSolicitante
        {
            get
            {
                var sol = new Solicitante();
                var usr = OficinaVirtualUserProfile.GetUserProfile();

                sol.NombreCompleto = txtNombre.Text.Length > 0
                                         ? txtNombre.Text
                                         : (!String.IsNullOrEmpty(this.Transaccion.NombreContacto))
                                               ? this.Transaccion.NombreContacto
                                               : (usr.NombreSolicitante.Length > 0)
                                                     ? usr.NombreSolicitante
                                                     : String.Empty;

                sol.PrimerNombre = (sol.NombreCompleto.IndexOf(" ") > 1)
                                       ? sol.NombreCompleto.Substring(0, sol.NombreCompleto.IndexOf(" "))
                                       : sol.NombreCompleto;
                sol.SegundoNombre = (sol.NombreCompleto.IndexOf(" ") != -1)
                                        ? sol.NombreCompleto.Substring(sol.NombreCompleto.IndexOf(" "))
                                        : sol.NombreCompleto;

                return sol;
            }
        }
        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.btnBack_Click(object, EventArgs)'
        protected void btnBack_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.btnBack_Click(object, EventArgs)'
        {
            Response.Redirect(BackUrl);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.btnBuscarRNC_Click(object, EventArgs)'
        protected void btnBuscarRNC_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.btnBuscarRNC_Click(object, EventArgs)'
        {
            var wsDGI = new WSMovilDGII.WSMovilDGIISoapClient();
            wsDGI.Open();
            var result = wsDGI.GetContribuyentes(this.RNC, 0, 0, 0, "");
            if (result == "0")
            {
                Master.ShowMessageError("El contribuyente indicado es inválido.");
                this.txtRnc.BorderColor = System.Drawing.Color.Red;
                wsDGI.Close();
                return;
            }
            wsDGI.Close();

            this.txtNombre.Text = result.FromAnonJSON<DGIIContribuyenteResp>().RGE_NOMBRE;
            this.NombreSolicitante.NombreCompleto = this.txtNombre.Text;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.DGIIContribuyenteResp'
        public class DGIIContribuyenteResp
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.DGIIContribuyenteResp'
        {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.DGIIContribuyenteResp.RGE_NOMBRE'
            public string RGE_NOMBRE { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.DGIIContribuyenteResp.RGE_NOMBRE'
        }
        
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.ddlTipoComprobantes_SelectedIndexChanged(object, EventArgs)'
        protected void ddlTipoComprobantes_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.ddlTipoComprobantes_SelectedIndexChanged(object, EventArgs)'
        {
            if (this.ddlTipoComprobantes.SelectedItem.Value != "2")
            {
                this.btnBuscarRNC.Visible = true;
                this.txtNombre.ReadOnly = true;
                this.txtNombre.Text = "";
                this.txtRnc.Text = "";
            }
            else
            {
                this.btnBuscarRNC.Visible = false;
                this.txtNombre.ReadOnly = false;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.txtRnc_TextChanged(object, EventArgs)'
        protected void txtRnc_TextChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucPagosTarjeta.txtRnc_TextChanged(object, EventArgs)'
        {

        }
    }

    /// <summary>
    /// Abstracción del nombre del solicitante
    /// </summary>
    class Solicitante
    {
        public string NombreCompleto { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
    }
}