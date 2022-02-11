using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using Encoder = System.Text.Encoder;

namespace GoogleCompiler
{
    class HttpHelper
    {
        public static bool PerformQuery(NameValueCollection postValues, out string response)
        {
            WebClient httpClient = new WebClient();
            httpClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            Uri requestUri = new Uri("http://closure-compiler.appspot.com/compile");

            //Realizando el post        
            try
            {
                byte[] responseArray = httpClient.UploadValues(requestUri, "POST", postValues);

                response = Encoding.ASCII.GetString(responseArray);
                return true;
            }
            catch (WebException ex)
            {
                //System.Diagnostics.EventLog.WriteEntry("Application", "Error al realizar el post " + ex.Message);
                response = string.Empty;
                return false;
            }

        }

      
    }

}
