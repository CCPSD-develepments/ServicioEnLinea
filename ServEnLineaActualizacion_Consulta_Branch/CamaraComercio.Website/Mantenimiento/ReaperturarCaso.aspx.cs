using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.DataAccess.EF.SRM;
using CamaraComercio.Website.TarjetaCredito;
using CamaraComercio.Website.WSShareBase;
using Hammock;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website.Mantenimiento
{
    public partial class ReaperturarCaso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            var authenticated = HttpContext.Current.User.Identity.IsAuthenticated;
            if (!authenticated)
            {
                Response.Redirect("~/Account/Login.aspx");
            }

            if (Helper.ReaperturarCasoAccesoActivo)
            {
                if (!Helper.ReaperturarCasoAccesoUsers.Contains(User.Identity.Name.ToLower()))
                {
                    Response.Redirect("~/Empresas/Oficina.aspx");
                }
            }

        }

        protected void btnProceder_Click(object sender, EventArgs e)
        {
            int nSolicitud;
            int.TryParse(txtProceder.Text, out nSolicitud);

            if (nSolicitud != 0)
            {
                var dbWeb = new CamaraWebsiteEntities();
                var tran = dbWeb.Transacciones.FirstOrDefault(t => t.SrmTransaccionId == nSolicitud);
                if (tran == null)
                {
                    lblMensaje.Text = "No se ha encontrado NoSolicitud";
                    return;

                }
                var fac = (from t in dbWeb.Facturas
                           where t.TransaccionId.HasValue && t.TransaccionId.Value == tran.TransaccionId
                           select t).OrderByDescending(x => x.FacturaId).FirstOrDefault();
                if(fac != null)
                {
                    OnlineTransaction onTran = GetOnlineTransaction(fac.FacturaId, tran.TransaccionId);
                    OnlineDocument[] onDocs = GetOnlineDocuments(tran.TransaccionId, onTran);
                    var resp = AperturarCaso(onTran, onDocs, long.Parse(tran.FolderId), tran.UserName.ToLower());
                    if (!resp)
                    {
                        lblMensaje.Text = "Error aperturando caso";
                        return;
                    }
                    else
                    {
                        tran.EsCasoAperturado = true;
                    }
                    tran.EstatusTransId = Helper.EstatusTransIdEnSRM;
                    dbWeb.SaveChanges();
                    lblMensaje.Text = "Listo";

                }
                else
                {
                    lblMensaje.Text = "No se encontró factura";
                    return;
                }
            }
            else
            {
                lblMensaje.Text = "No se encontró Solicitud";
                return;
            }
        }

        private OnlineTransaction GetOnlineTransaction(int facturaId, int tranId)
        {
            OnlineTransaction onTran = new OnlineTransaction();
            var dbCamaraWebSite = new OFV.CamaraWebsiteEntities();
            var dbWeb = new CamaraWebsiteEntities();
            var dbCom = new CamaraComunEntities();

            var fact = dbWeb.Facturas.FirstOrDefault(a => a.FacturaId == facturaId);
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

            var user = Membership.GetUser(tran.UserName.ToLower());
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

        private bool AperturarCaso(OnlineTransaction onlineTran, OnlineDocument[] onlineDocs, long folderId, string userName)
        {
            if (Helper.ShareBaseEnabled)
            {
                var client = new OnlineChamberServiceClient();
                using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
                {
                    var httpRequestProperty = new HttpRequestMessageProperty();
                    httpRequestProperty.Headers["token"] = Helper.ShareBaseToken;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;

                    var response = client.AperturarCasoOnline(folderId, onlineTran, onlineDocs, userName);
                    return response.Success;
                }
            }
            else
            {
                return true;
            }
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

        public string GetSafeFilename(string filename)
        {
            return string.Join("_", filename.Split(System.IO.Path.GetInvalidFileNameChars()));
        }

        protected void BtnEnviarSrmtransaccion_Click(object sender, EventArgs e)
        {
            var checkncf = (Checkboxncf.Checked)? true : false;    
            PagosTarjeta PagoTarj = new PagosTarjeta();
            var result = PagoTarj.ProcesarTransaccionMandarSRM(Convert.ToInt32(txttransaccionsrm.Text), checkncf);
            var trax = txttransaccionsrm.Text;
            var dbWeb = new CamaraWebsiteEntities();
            var resultadofbd = dbWeb.TransaccionesEmpBHD.Where(x => x.reference == trax).FirstOrDefault();
            
            if(resultadofbd!= null)
            {

                using (var db = new CamaraWebsiteEntities())
                {
                    var resultt = db.TransaccionesEmpBHD.Where(x => x.reference == trax).FirstOrDefault();
                    if (resultt != null)
                    {
                        resultt.Estatus = 2;
                        db.SaveChanges();
                    }
                }
            }

            txttransaccionsrm.Text = "";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + result + "');", true);
        }

    }
}