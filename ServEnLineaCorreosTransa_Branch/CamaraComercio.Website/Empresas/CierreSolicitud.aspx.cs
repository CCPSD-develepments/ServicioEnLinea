using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.DataAccess.EF.SRM;
using CamaraComercio.Website.Helpers;
using CamaraComercio.Website.WSShareBase;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using ModuloPago;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Compilation;
using System.Web.Security;
using System.Web.UI;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website.Empresas
{
    ///<summary>
    /// Cierre de una solicitud
    ///</summary>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class CierreSolicitud : SecurePage
    {
        ///<summary>
        /// ID de la transacción a cerrar
        ///</summary>

        public int IdTransacciones
        {
            get { return Session["IdTransacciones"] != null ? int.Parse(Session["IdTransacciones"].ToString()) : 0; }
            set { Session["IdTransacciones"] = value; }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CierreSolicitud.FormularioSolicitud'
        protected TransaccionesDocumentos FormularioSolicitud
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CierreSolicitud.FormularioSolicitud'
        {
            get
            {
                if (Session["FormularioSolicitud"] == null) return null;
                return Session["FormularioSolicitud"] as OFV.TransaccionesDocumentos;
            }
            set { Session["FormularioSolicitud"] = value; }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CierreSolicitud.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CierreSolicitud.Page_Load(object, EventArgs)'
        {
            var factura = new OFV.Facturas();
            if (String.IsNullOrEmpty(Request.Params["nSolicitud"])) return;

            Int32 noSolicitud;
            Int32.TryParse(Request.QueryString["nSolicitud"], out noSolicitud);
            var db = new OFV.CamaraWebsiteEntities();

            if (noSolicitud > 0)
            {
                //var padreUser = User.Identity.Name.ToLower();

                //var rep = new DataAccess.EF.Membership.UsuariosController();
                //var usuariosHijo = rep.FetchByUsuarioPadre(User.Identity.Name, "1");
                //var hijos = new List<string>();
                //foreach (var item in usuariosHijo)
                //{
                //    hijos.Add(item.UserName.ToLower());
                //}

                var trans = (from t in db.Transacciones
                             where t.TransaccionId == noSolicitud && (t.UserName.Equals(User.Identity.Name.ToLower()) /*|| hijos.Contains(t.UserName)*/)
                             select t).FirstOrDefault();
                if (trans == null)
                {
                    Response.Redirect("~/Empresas/Oficina.aspx");
                }
            }

                //Aqui grabo el log de la transaccion que se creo
            LogTransaccionesMethods.GrabarLogTransacciones(noSolicitud, Request.RawUrl, true, User.Identity.Name);

            var nSolicitud = Request.Params["nSolicitud"];
            var FacturaId = Request.Params["FacturaId"];

            if (noSolicitud > 0)
            {
                factura = (from t in db.Facturas
                           where t.TransaccionId.HasValue && t.TransaccionId.Value == noSolicitud
                           select t).OrderByDescending(x => x.FacturaId).FirstOrDefault();

                if (factura != null) FacturaId = factura.FacturaId.ToString();
            }

            if (noSolicitud > 0)
            {
                var trans = (from t in db.Transacciones
                             where t.TransaccionId == noSolicitud
                             select t).FirstOrDefault();

                //if(trans != null && trans.SrmTransaccionId.HasValue && trans.SrmTransaccionId.Value > 0)
                //    panelConfirmacion.Visible = false;

                var estaEnSrm = trans != null && (trans.bLoadedInSRM.HasValue && trans.bLoadedInSRM.Value &&
                                                  trans.SrmTransaccionId.HasValue && trans.SrmTransaccionId.Value > 0);

                pnlCompletada.Visible = estaEnSrm;
                pnlNoCompletada.Visible = !estaEnSrm;

                if (trans != null && !trans.bPagada) panelFactura.Visible = false;

                if (estaEnSrm && !trans.EsCasoAperturado.Value2())
                {
                    if (Helper.ShareBaseEnabled)
                    {
                        OnlineTransaction onTran = GetOnlineTransaction(int.Parse(FacturaId), trans.TransaccionId);
                        OnlineDocument[] onDocs = GetOnlineDocuments(trans.TransaccionId, onTran);

                        var resp = AperturarCaso(onTran, onDocs, long.Parse(trans.FolderId));

                        if(resp == false)
                        {
                            var textoFirmadigital = "Error aperturando el caso --  transID = " + onTran.TransaccionId;
                            var parametros = new Dictionary<string, string>();
                            parametros.Add("[NombreCompleto]", textoFirmadigital);
                            var to = HtmlHelper.GetAppVariable("CorreoAperturaError").ToString();

                            //invocar envio de template Recuperación de Contraseña
                            MailBot.MailBot.SendMail(to, null, null,
                            Helper.FromEmailCorreoCamara, "APERTURA", Helper.MailServer, 1, parametros);
                        }


                        if (!resp)
                        {
                            ShowMessageError();
                            return;
                        }
                        else
                        {
                            trans.EsCasoAperturado = true;
                        }
                    }
                    trans.EstatusTransId = Helper.EstatusTransIdEnSRM;
                    db.SaveChanges();
                }
            }

            using (CamaraWebsiteEntities dbWebsite = new CamaraWebsiteEntities())
            {
                var transaccionDocumento = dbWebsite.TransaccionesDocumentos
                    .Where(d => d.TransaccionId == noSolicitud && d.TipoDocumentoId == 1560 && d.Usuario == User.Identity.Name)
                    .OrderByDescending(d => d.FechaEnvio)
                    .FirstOrDefault();

                FormularioSolicitud = transaccionDocumento;
                if (transaccionDocumento == null)
                {
                    panelDescargaDocumentos.Visible = false;
                }
            }
            //confimacion de que si la factuira es por solisitud de inclucion a nuava empresa que no
            //semuestre el botno de imprimir factura



            if (factura.TotalFactura == 0m && factura.PagoAnterior == 0m)
            {
                panelFactura.Visible = false;
            }

            //this.hlVerSolicitud.NavigateUrl = "~/Empresas/ImprimirSolicitud.aspx?nSolicitud=" + nSolicitud;
            this.hlVerFactura.NavigateUrl = "~/Empresas/ImprimirFactura.aspx?FacturaId=" + FacturaId;
            this.hlEnvioDatos.NavigateUrl = "~/Empresas/EnvioDatos.aspx?nSolicitud=" + nSolicitud;
            this.hlDetalleTransaccion.NavigateUrl = string.Format("~/Empresas/VerDetalleTransaccion.aspx?nSolicitud={0}&VerDetalle=true", nSolicitud);
        }

        //Todo: funcion a revisar para concatenar el impreso.
        private OnlineTransaction GetOnlineTransaction(int facturaId, int tranId)
        {
            OnlineTransaction onTran = new OnlineTransaction();
            var dbCamaraWebSite = new OFV.CamaraWebsiteEntities();
            var dbWeb = new CamaraWebsiteEntities();
            var dbCom = new CamaraComunEntities();

            var fact = dbWeb.Facturas.FirstOrDefault(a => a.FacturaId == facturaId && a.Transacciones.UserName == User.Identity.Name.ToLower());
            var tran = dbWeb.Transacciones.First(t => t.TransaccionId == tranId);
            var serv = dbCom.Servicio.FirstOrDefault(s => s.ServicioId == tran.ServicioId);
            var soc = dbCom.TipoSociedad.FirstOrDefault(s => s.TipoSociedadId == tran.TipoSociedadId);
            var camara = dbCom.Camaras.FirstOrDefault(s => s.ID == fact.CamaraId);
            var nonmeclatura = dbCom.Nomenclaturas.FirstOrDefault(s => s.CamaraId == fact.CamaraId);

            var dbSrm = DataAccess.EF.SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(fact.CamaraId);
            if (tran.RegistroId != 0 && tran.TipoSociedadId != 7)
            {
                var socCtrl = new SociedadesController();
                var registro = dbSrm.Registros.FirstOrDefault(a => a.RegistroId == fact.Transacciones.RegistroId);
                var SocReg = socCtrl.FindRegistro(tran.RegistroId, fact.CamaraId);
                var sociedad = socCtrl.FetchSociedadesRegistroBySociedadId(SocReg.SociedadId, fact.CamaraId);
                var direccion = dbSrm.Direcciones.FirstOrDefault(d => d.DireccionId == sociedad.DireccionId);
                onTran.Ciudad = direccion.CiudadDescripcion;
                if (!Helper.CorreoPrueba)
                    onTran.CorreoEmpresa = String.IsNullOrWhiteSpace(direccion.Email) ? "CORREO@EMPRESA.COM" : direccion.Email;
                else
                    onTran.CorreoEmpresa = "CORREO@EMPRESA.COM";
                onTran.Direccion = string.Format("{0}, {1}", direccion.Calle, direccion.SectorDescripcion);
                onTran.FechaRegistroMercantil = registro.FechaEmision.HasValue ? registro.FechaEmision.Value.ToString("yyyy/MM/dd") : ""; // P
            }
            if (tran.RegistroId != 0 && tran.TipoSociedadId == 7)
            {
                var perCtrl = new PersonaFisicaController();
                var registro = dbSrm.PersonasRegistros.FirstOrDefault(a => a.RegistroId == fact.Transacciones.RegistroId);
                var PerReg = perCtrl.ObteneByRegistroIdCamara(tran.RegistroId, fact.CamaraId).First();
                var persona = perCtrl.ObteneByPersonaIdCamara(PerReg.PersonaId, fact.CamaraId).First();
                var direccion = dbSrm.Direcciones.FirstOrDefault(d => d.DireccionId == persona.Personas.DireccionId);
                onTran.Ciudad = direccion.CiudadDescripcion;
                if (!Helper.CorreoPrueba)
                    onTran.CorreoEmpresa = String.IsNullOrWhiteSpace(direccion.Email) ? "CORREO@EMPRESA.COM" : direccion.Email;
                else
                    onTran.CorreoEmpresa = "CORREO@EMPRESA.COM";
                onTran.Direccion = string.Format("{0}, {1}", direccion.Calle, direccion.SectorDescripcion);
                onTran.FechaRegistroMercantil = registro.Registros.FechaEmision.HasValue ? registro.Registros.FechaEmision.Value.ToString("yyyy/MM/dd") : ""; // P
            }
            else
            {
                onTran.CorreoEmpresa = "CORREO@EMPRESA.COM";
                onTran.Direccion = "N/A";
                onTran.Ciudad = "N/A";
            }

            var user = Membership.GetUser(User.Identity.Name);
            #region Llenar props
            onTran.CamaraId = camara.Nombre.ToUpper();
            onTran.CapitalAutorizado = fact.Transacciones.CapitalSocial.Value2().ToString();
            onTran.Comentario = tran.Comentario;
            onTran.CorreoSolicitante = String.IsNullOrWhiteSpace(user.Email) ? "CORREO@SOLICITANTE.COM" : user.Email;

            onTran.Destino = "SERVICIO EN LINEA";

            if (tran.DepositarCansilleria == true)
            {
                onTran.Destino += " - CANCILLERIA";
            }

            // se verificar si se desea descargar el documento
            if (tran.ImprimirCopias == false && tran.ServicioId == 49)
            {
                onTran.Destino += " - NO IMPRIMIR";
            }
            else if (tran.ImprimirCopias == false && tran.ServicioId == 415)
            {
                onTran.Destino += " - NO IMPRIMIR";
            }


            onTran.EsDigital = "0";
            onTran.EsVentanillaUnica = tran.ServicioVentanillaUnica.HasValue && tran.ServicioVentanillaUnica.Value ? "1" : "0";
            onTran.FechaTransaccion = tran.Fecha.ToString("yyyy/MM/dd");
            onTran.Imagen = this.ObtenerImagenPdf(facturaId); //this.ObtenerImagenPdf(facturaId, tranId); 
            onTran.NoTransaccionVentanilla = "0"; // P n'umero de solicitud
            onTran.NombreRepresentante = tran.NombreContacto;
            onTran.NombreSolicitante = tran.NombreContacto;
            if (tran.TipoSociedadId != 7)
            {
                onTran.NumeroRegistroMercantil = fact.Transacciones.NumeroRegistro > 0 ? fact.Transacciones.NumeroRegistro.ToString() + nonmeclatura.Prefijo : String.Empty; // P
            }
            else
            {
                onTran.NumeroRegistroMercantil = fact.Transacciones.NumeroRegistro > 0 ? fact.Transacciones.NumeroRegistro.ToString() + nonmeclatura.Prefijo + "-PF" : String.Empty; // P
            }
            if (tran.RegistroId != 0)
            {
                onTran.NombreSocial = tran.NombreSocialPersona;
                onTran.TipoSociedad = soc.Descripcion;
                onTran.TipoEmpresa = soc.Etiqueta;
            }
            else
            {
                onTran.NombreSocial = tran.ANombreQuien;
                onTran.FechaRegistroMercantil = "";
                onTran.TipoSociedad = "";
                onTran.TipoEmpresa = "";
            }
            onTran.Origen = camara.Nombre.ToUpper(); // P
            onTran.Peso = (float)1.0;  // P tomar de la transacci'on
            onTran.RNC = fact.Transacciones.RNCSolicitante.FormatRnc(); // P
            onTran.RNCSolicitante = tran.RNCSolicitante;
            onTran.Servicio = this.GetSafeFilename(serv.Descripcion);
            onTran.TelSolicitante = tran.TelefonoContacto;
            onTran.TipoServicio = serv.TipoServicio.Descripcion;
            onTran.TipoServicioSufijo = serv.TipoServicio.Sufijo;
            onTran.TipoSolicitud = serv.ServicioInmediato.HasValue && serv.ServicioInmediato.Value ? "INMEDIATOS" : "NORMAL";
            onTran.TransaccionId = tran.SrmTransaccionId.ToString(); // Confirmar que este sea el lugar para enviar el SRM Transaccion Id
            onTran.UbicacionExterna = camara.Nombre.ToUpper();

            #endregion

            return onTran;
        }

        private OnlineDocument[] GetOnlineDocuments(int transId, OnlineTransaction onTran)
        {
            var db = new CamaraWebsiteEntities();
            var docs = db.TransaccionesDocumentos.Where(t => t.TransaccionId == transId);

            List<OnlineDocument> onDocs = new List<OnlineDocument>();

            #region Llenar docs
            foreach (var doc in docs)
            {
                string DocTypeName = string.Empty;
                using (var ccE = new CamaraComunEntities())
                {
                    DocTypeName = ccE.TipoDocumento.First(i => i.TipoDocumentoId == doc.TipoDocumentoId).DocumentoOnBaseDesc;
                }

                OnlineDocument d = new OnlineDocument();
                d.CamaraId = onTran.CamaraId;
                d.CantidadCopias = doc.CantidadCopia.ToString();
                d.CantidadOriginales = doc.CantidadOriginal.ToString();
                d.DocumentoId = doc.SBDocumentId != null ? doc.SBDocumentId.ToString() : "0";
                d.EsOriginal = "1";  // P

                d.EsRegistrable = "0";
                //d.FechaDocumento = doc.FechaDocumento.Value2().ToString("yyyy/MM/dd");
                d.FechaDocumento = doc.FechaDocumento != null 
                    ? string.Format("{0:yyyy/MM/dd}", doc.FechaDocumento) : string.Format("{0:yyyy/MM/dd}", DateTime.Today);
                d.Imprimir = "0";  // P
                d.NoRegistroMercantil = onTran.NumeroRegistroMercantil;
                d.NombreDocumento = DocTypeName;
                d.NumeroPagina = "0";
                //d.OnbaseDocumentTypeName = "";
                d.Origen = onTran.Origen;
                d.TransaccionId = onTran.TransaccionId;
                onDocs.Add(d);
            }

            #endregion

            return onDocs.ToArray();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CierreSolicitud.GetSafeFilename(string)'
        public string GetSafeFilename(string filename)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CierreSolicitud.GetSafeFilename(string)'
        {

            return string.Join("_", filename.Split(System.IO.Path.GetInvalidFileNameChars()));

        }

        private string ObtenerImagenPdf(int FacturaId)
        {
            StringWriter _writer = new StringWriter();
            HttpContext.Current.Server.Execute("~/Empresas/ImprimirFactura.aspx?FacturaId=" + FacturaId, _writer);
            string html = _writer.ToString();

            IronPdf.HtmlToPdf renderer = new IronPdf.HtmlToPdf();
            byte[] data = renderer.RenderHtmlAsPdf(html).BinaryData;

            return Convert.ToBase64String(data);
        }

        private bool AperturarCaso(OnlineTransaction onlineTran, OnlineDocument[] onlineDocs, long folderId)
        {
            if (Helper.ShareBaseEnabled)
            {
                var client = new OnlineChamberServiceClient();
                using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
                {

                    try
                    {
                        var user = HttpContext.Current.User.Identity.Name.ToLower();
                        var profile = OficinaVirtualUserProfile.GetUserProfile(user);
                        string userName = profile.NombreSolicitante.ToString();
                        var httpRequestProperty = new HttpRequestMessageProperty();
                        httpRequestProperty.Headers["token"] = Helper.ShareBaseToken;
                        OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;

                        client.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 40);

                        var response = client.AperturarCasoOnline(folderId, onlineTran, onlineDocs, userName);
                        return response.Success;

                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex) {
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                        return false;
                    }
                }
            }
            else
            {
                return true;
            }
        }

        private void ShowMessageError()
        {
            string script = @"<script type='text/javascript'>
                            ErrorAperturaCaso();
                        </script>";

            if (!ClientScript.IsClientScriptBlockRegistered("ErrorAperturaCaso"))
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorAperturaCaso", script);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CierreSolicitud.btnDownloadFormularioSolicitud_Click(object, EventArgs)'
        protected void btnDownloadFormularioSolicitud_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CierreSolicitud.btnDownloadFormularioSolicitud_Click(object, EventArgs)'
        {
            if (FormularioSolicitud == null)
            {
                Master.ShowMessageError("El Formulario de Solicitud no se ha generado");
                return;
            }

            using (CamaraWebsiteEntities dbWebsite = new CamaraWebsiteEntities())
            {
                dbWebsite.TransaccionesDocDescargas.AddObject(new OFV.TransaccionesDocDescargas
                {
                    DocContent = FormularioSolicitud.DocContent,
                    FechaDescarga = DateTime.Now,
                    NombreSocialOrComment = string.Empty,
                    TransaccionId = FormularioSolicitud.TransaccionId,
                    UserName = User.Identity.Name.ToLower()
                });
                dbWebsite.SaveChanges();
            }

            Response.Clear();
            Response.ContentType = FormularioSolicitud.DocContentType;
            Response.AddHeader("content-disposition", "attachment; filename=" + FormularioSolicitud.Nombre);
            Response.BufferOutput = true;
            Response.OutputStream.Write(FormularioSolicitud.DocContent, 0, FormularioSolicitud.DocContent.Length);
            Response.End();
        }
    }

    class CustomITextImageProvider : IImageProvider
    {
        #region IImageProvider Members
        public iTextSharp.text.Image GetImage(string src, Dictionary<string, string> imageProperties, ChainedProperties cprops, IDocListener doc)
        {
            string imageLocation = imageProperties["src"].ToString();
            string siteUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "");

            int paramIndex = siteUrl.IndexOf('?');
            siteUrl = siteUrl.Substring(0, paramIndex);
            if (siteUrl.EndsWith("/"))
                siteUrl = siteUrl.Substring(0, siteUrl.LastIndexOf("/"));

#pragma warning disable CS0219 // The variable 'image' is assigned but its value is never used
            iTextSharp.text.Image image = null;
#pragma warning restore CS0219 // The variable 'image' is assigned but its value is never used

            if (!imageLocation.StartsWith("http:") && !imageLocation.StartsWith("file:") && !imageLocation.StartsWith("https:") && !imageLocation.StartsWith("ftp:"))
                imageLocation = siteUrl + (imageLocation.StartsWith("/") ? "" : "/") + imageLocation;

            return iTextSharp.text.Image.GetInstance(imageLocation);
        }
        #endregion
    }
}