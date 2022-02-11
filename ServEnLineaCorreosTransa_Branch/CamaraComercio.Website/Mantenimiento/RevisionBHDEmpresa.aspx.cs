using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.Website.TarjetaCredito;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CamaraComercio.Website.Mantenimiento
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionBHDEmpresa'
    public partial class RevisionBHDEmpresa : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionBHDEmpresa'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionBHDEmpresa.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionBHDEmpresa.Page_Load(object, EventArgs)'
        {
            var authenticated = HttpContext.Current.User.Identity.IsAuthenticated;
            if (!authenticated)
            {
                Response.Redirect("~/Account/Login.aspx");
            }

            getWhileLoopData();
        }


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionBHDEmpresa.lbNewUserDesc_Click(object, EventArgs)'
        protected void lbNewUserDesc_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionBHDEmpresa.lbNewUserDesc_Click(object, EventArgs)'
        {

        }

     

      


        public void getWhileLoopData()

        {

            string htmlStr = "";

            var db = new CamaraWebsiteEntities();
            var registro = db.TransaccionesEmpBHD.Where(x => x.Estatus == 1).ToList();
            List<TransaccionesEmpBHD> people = new List<TransaccionesEmpBHD>();

            foreach (var item in registro)
            {
                //para mandar el token priemro de cada transaccion: 
                string URL = ConfigurationManager.AppSettings["urltokenunico"].ToString();
                string DATA2 = @"{
                ""scope"": ""pagosSometidos"",
                ""clientId"": ""clientIdString"",
                ""clientSecret"": ""clientSecretString"",
                ""channel"": ""BDP"",
                ""transactionId"": " + item.TransactionId+"}";

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

                Task<string> ff =  TestMethodAsync(item.TransactionId.Trim(), item.reference.Trim(),  ResultadoBanner);
                
                
                people.Add(new TransaccionesEmpBHD() { Id = item.Id, reference = item.reference, TransactionId = item.TransactionId, EstadoString = "Pendiente" });
            }

            foreach (var item in db.TransaccionesEmpBHD.Where(x => x.Estatus != 1).ToList())
            {
                if(item.Estatus == 3)
                {
                    people.Add(new TransaccionesEmpBHD() { Id = item.Id, reference = item.reference, TransactionId = item.TransactionId, EstadoString = "Reaperturar" });
                }
                if (item.Estatus == 2)
                {
                    people.Add(new TransaccionesEmpBHD() { Id = item.Id, reference = item.reference, TransactionId = item.TransactionId, EstadoString = "Completada" });
                }

                }

            if (!IsPostBack)
            {
                this.gvUserActivities.DataSource = people;
                this.gvUserActivities.DataBind();

            }
            else
            {
                this.gvUserActivities.DataSource = people;
                this.gvUserActivities.DataBind();
            }


           // return htmlStr;
        }


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionBHDEmpresa.ResultadoPago(string, string, string)'
        public void ResultadoPago(string Referencia, string transaccionid, string token) {
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


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionBHDEmpresa.TestMethodAsync(string, string, string)'
        public async Task<string> TestMethodAsync(string transaccionid , string  referencia, string token)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionBHDEmpresa.TestMethodAsync(string, string, string)'
        {

            string URL = "https://api-sqa.bhdleon.com.do/bhdleon/boton/v2/clientes/pagos/sometidos/consultar";
            var ResultadoPago = "";
            try
            {
                var apicallObject = new
                {
                    transactionId = transaccionid,
                    channel = "BDP",
                    reference = referencia,
                    providerId = "90909106",
                    serviceId = "123456803",
                };

                if (apicallObject != null)
                {
                    var bodyContent = JsonConvert.SerializeObject(apicallObject);
                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(bodyContent.ToString(), Encoding.UTF8, "application/json");
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
                                
                                if (ResultadoPago == "001")
                                {
                                    using (var db = new CamaraWebsiteEntities())
                                    {
                                        var result = db.TransaccionesEmpBHD.Where(x => x.reference == referencia).FirstOrDefault();
                                        if (result != null)
                                        {
                                            result.Estatus = 3;
                                            db.SaveChanges();
                                        }
                                    }
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