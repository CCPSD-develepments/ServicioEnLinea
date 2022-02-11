using System;
using System.Net;
using System.Web.Script.Serialization;
using Hammock;
using Hammock.Web;

namespace CamaraComercio.Website.Helpers
{
    ///<summary>
    /// Clase que encapsula todas las interacciones con las aplicaciones web de Nobox
    ///</summary>
    public class NoboxHelper
    {
        /// <summary>
        /// Método utilizado para invocar un handshake entre la aplicación de VU/OFV 
        /// y las apps del website que corren bajo PHP en otro contexto
        /// </summary>
        /// <param name="username">Nombre de usuario</param>
        /// <param name="password">contraseña</param>
        /// <returns></returns>
        public string DelegateLogin(string username, string password)
        {
            var token = String.Empty;
            var client = new RestClient()
                                 {Authority = Helper.NoboxAPI};

            var request = new RestRequest {Method = WebMethod.Post};

            request.AddParameter("op", "DelegateLogin");
            request.AddParameter("username", username.ToLower());
            request.AddParameter("password", password);

            var response = client.Request(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var js = new JavaScriptSerializer();
                var noboxResponse = (NoboxResponse)js.Deserialize(response.Content, typeof(NoboxResponse));

                if (noboxResponse != null && noboxResponse.response == "success")
                    token = noboxResponse.token;
            }

            return token;
        }

        /// <summary>
        /// Representa una respuesta desde Nobox para el delegate del login
        /// </summary>
        public class NoboxResponse
        {
            /// <summary>
            /// Mensaje de respuesta. En minúscula para poder serializar
            /// </summary>
            public string response { get; set; }
            /// <summary>
            /// Token de autenticación. En minúscula para poder serializar
            /// </summary>
            public string token { get; set; }
        }
    }

}