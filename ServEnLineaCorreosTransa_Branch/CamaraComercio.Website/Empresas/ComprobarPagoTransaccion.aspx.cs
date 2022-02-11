using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.Website.Helpers;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using System.Transactions;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Configuration;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace CamaraComercio.Website
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DeleteTransaccion'
    public partial class ComprobarPagoTransaccion : CamaraComercio.Website.Operaciones.FormularioPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DeleteTransaccion'
    {
        CamaraWebsiteEntities dbOFV = null;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DeleteTransaccion.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DeleteTransaccion.Page_Load(object, EventArgs)'
        {

        }



#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DeleteTransaccion.btnBack_Click(object, EventArgs)'
        protected void btnBack_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DeleteTransaccion.btnBack_Click(object, EventArgs)'
        {
            Response.Redirect("~/Empresas/Oficina.aspx");
        }

        protected void btnComprobar_Click(object sender, EventArgs e)
        {
            //new 2021-07-05, get transacciones BHd, valida estado, update:
            int transId;
            int.TryParse(Request["nSolicitud"], out transId);
            var authenticated = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (!authenticated)
            {
                Response.Redirect("~/Account/Login.aspx");
            }

            //COMPROBAR
            getWhileLoopData(transId);


            Response.Redirect(String.Format("/Empresas/VerDetalleTransaccion.aspx?nSolicitud={0}&VerDetalle=true", transId));

        }


        //BHD, COMPROBAR PAGO - 2021-07-10: 
        //---------------------
        //Transacciones Pagos Boton BHD:
        public void getWhileLoopData(int transId)
        {
            string htmlStr = "";
            var userId = User.Identity.Name.ToLower();
            //buscar transacciones pendientes:        

            //try
            //{          

            var LTransaccionBHD = new OFV.TransaccionesController().LTransaccionesBHDById(userId, transId);
            //buscar transacciones pendientes <> 1:
            if (LTransaccionBHD != null)
            {
                //para mandar el token priemro de cada transaccion: 
                string URL = ConfigurationManager.AppSettings["urltokenunico"].ToString();
                string DATA2 = @"{
                ""scope"": ""pagosSometidos"",
                ""clientId"": ""clientIdString"",
                ""clientSecret"": ""clientSecretString"",
                ""channel"": ""BDP"",
                ""transactionId"": " + LTransaccionBHD.TransactionId + "}";

                DATA2 = DATA2.Replace("clientIdString", ConfigurationManager.AppSettings["clientId"].ToString());
                DATA2 = DATA2.Replace("clientSecretString", ConfigurationManager.AppSettings["clientSecret"].ToString());


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = DATA2.Length;

                var test = request.GetResponseAsync();


                using (Stream webStream = request.GetRequestStream())

                using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
                {
                    requestWriter.Write(DATA2);
                }

                string ResultadoBanner = "";
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string response = responseReader.ReadToEnd();
                    string[] words = response.Split('\"');
                    ResultadoBanner = words[3];
                }

                Task<string> ff = TestMethodAsync(LTransaccionBHD.TransactionId.Trim(), LTransaccionBHD.SolicitudId.Value, ResultadoBanner);


            }

            // return htmlStr;
        }


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionBHDEmpresa.ResultadoPago(string, string, string)'
        public void ResultadoPago(string Referencia, string transaccionid, string token)
        {
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionBHDEmpresa.ResultadoPago(string, string, string)'


           string URL = ConfigurationManager.AppSettings["urlConsultar"].ToString();


            string DATA3 = @"{
                ""transactionId"": ""transactionIdVariable"",
                ""channel"": ""BDP"",
                ""reference"": ""referenceVariable"",
                ""providerId"": ""providerIdString"",
                ""serviceId"": ""serviceIdString"" };";

            var tran = transaccionid.Trim();
            var refe = Referencia.Trim();

            DATA3 = DATA3.Replace("transactionIdVariable", tran);
            DATA3 = DATA3.Replace("referenceVariable", refe);
            DATA3 = DATA3.Replace("providerIdString", ConfigurationManager.AppSettings["providerId"].ToString());
            DATA3 = DATA3.Replace("serviceIdString", ConfigurationManager.AppSettings["serviceId"].ToString());


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = DATA3.Length;

            var test = request.GetResponseAsync();
            request.Headers.Add("Authorization", token.Trim());

            using (Stream webStream = request.GetRequestStream())

            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(DATA3);
            }


            WebResponse webResponse = request.GetResponse();


            using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
            using (StreamReader responseReader = new StreamReader(webStream))
            {
                string response = responseReader.ReadToEnd();
                string[] words = response.Split('\"');
                var ResultadoBanner = words[3];
            }
        }

        //---------------------
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionBHDEmpresa.TestMethodAsync(string, string, string)'
        public async Task<string> TestMethodAsync(string transaccionid, int referencia, string token)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionBHDEmpresa.TestMethodAsync(string, string, string)'
        {

            string URL = Helper.urlBHDConsultar; // "https://api-sqa.bhdleon.com.do/bhdleon/boton/v2/clientes/pagos/sometidos/consultar";
            var ResultadoPago = "";

            var userId = User.Identity.Name.ToLower();

            try
            {
                var apicallObject = new
                {
                    transactionId = transaccionid,
                    channel = "BDP",
                    reference = referencia,
                    providerId = Helper.providerIdBHD, // "90909106",
                    serviceId = Helper.serviceIdBHD,// "123456803",
                };

                if (apicallObject != null)
                {
                    var bodyContent = JsonConvert.SerializeObject(apicallObject);
                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(bodyContent.ToString(), System.Text.Encoding.UTF8, "application/json");
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token); // _token = access token

                        var response = await client.PostAsync(URL, content); // _url =api endpoint url

                        if (response != null)
                        {
                            var jsonString = await response.Content.ReadAsStringAsync();
                            try
                            {
                                string[] words = jsonString.Split('\"');
                                ResultadoPago = words[37];

                                //  if (ResultadoPago == "001")                                    
                                if (ResultadoPago == Helper.IdEstadoBHDEmpresarial) // ha sido validado y aprobado correctamente:
                                {
                                    using (var db = new CamaraWebsiteEntities())
                                    {
                                        //buscar transacciones pendientes <> 1:
                                        var LTransaccionesBHDDist1 = new OFV.TransaccionesController().LTransaccionesBHDById(userId, Convert.ToInt32(referencia));
                                        //  var result = LTransaccionesBHDDist1.Where(x => x.reference == referencia).FirstOrDefault();


                                        if (LTransaccionesBHDDist1 != null)
                                        {

                                            new OFV.TransaccionesController().ActualizarEstadosBHD(referencia, Helper.IdEstadoBHDLocal); //ver porque el estado 3
                                        }
                                    }

                                    Master.ShowMessageError("El pago ha sido aprobado, ya puede completar la solicitud.");

                                }
                                else //008 //rechazado
                                if (ResultadoPago == Helper.IdEstadoBHDEmpresarialRechazo)
                                {
                                    using (var db = new CamaraWebsiteEntities())
                                    {
                                        //buscar transacciones pendientes <> 1:
                                        var LTransaccionesBHDDist1 = new OFV.TransaccionesController().LTransaccionesBHDById(userId, Convert.ToInt32(referencia));
                                        //  var result = LTransaccionesBHDDist1.Where(x => x.reference == referencia).FirstOrDefault();


                                        if (LTransaccionesBHDDist1 != null)
                                        {

                                            new OFV.TransaccionesController().ActualizarEstadosBHD(referencia, Helper.IdEstadoBHDLocalRechazado); //ver porque el estado 3
                                        }
                                    }

                                    Master.ShowMessageError("El pago ha sido rechazado por el banco.");

                                }

                                return ResultadoPago.ToString();
                            }
                            catch (Exception e)
                            {
                                throw e;
                            }
                        }
                    }
                }

                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }








    }
}