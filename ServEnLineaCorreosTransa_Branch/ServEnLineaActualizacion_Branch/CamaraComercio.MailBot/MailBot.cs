using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using System.IO;
using System.Web;

namespace CamaraComercio.MailBot
{
    public class MailBot
    {
        //no instantiation.
        private MailBot() { }

        
        private static void SendMailWithService(string to, string cc, string bcc, string from, string templateCode, int sourceID, Dictionary<string, string> parameters)
        {
            //get template.
            var dal = new DataAccess();
            var dt = dal.GetTemplate(templateCode);

            if (dt != null)
            {
                int templateID = Convert.ToInt32(dt.Rows[0]["TemplateID"]);
                bool isHTML = Convert.ToBoolean(dt.Rows[0]["IsHTML"]);
                string mailText = dt.Rows[0]["TemplateText"].ToString();
                string subject = dt.Rows[0]["Subject"].ToString();

                //replace parametres.
                foreach (KeyValuePair<string, string> param in parameters)
                {
                    mailText = mailText.Replace(param.Key, param.Value);
                    subject = subject.Replace(param.Key, param.Value);
                }

                //insert into mailbot.
                dal.InsertMail(to, cc, bcc, from, isHTML, mailText, templateID, sourceID, subject);
            }

        }

        private static bool SendMailNow(string to, string cc, string bcc, string from, 
            string host, string templateCode, int sourceID, Dictionary<string, string> parameters,  string usuariodigital = "", string solicitanteDigital = "",
            string ActividadDigital = "", string cantidaddigital = "")
        {
            var result = false;
            
            //Build mail based on template
            var dal = new DataAccess();
            var dt = dal.GetTemplate(templateCode);


            if(templateCode == "APERTURA") {


                // int templateID = Convert.ToInt32(dt.Rows[0]["TemplateID"]);
                string mailText = ""; // dt.Rows[0]["TemplateText"].ToString();
                string subject = "Servicio en linea"; //dt.Rows[0]["Subject"].ToString();


                foreach (KeyValuePair<string, string> param in parameters)
                {
                    mailText = param.Value;
                    //subject = subject.Replace(param.Key, param.Value);
                }

                var mailServer = new SmtpClient()
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Host = host,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("Cámara de Comercio y Produción de Santo Domingo", "Uq_KPdgFxH3rT69it2mWyQ")
                };

                //create mail message.
                var mailMessage = new MailMessage(from, to, subject, mailText);
                if (!string.IsNullOrEmpty(cc))
                {
                    var ccemail = cc.Split(',');

                    for (int i = 0; i < ccemail.Length; i++)
                    {
                        mailMessage.CC.Add(new MailAddress(ccemail[i]));
                    }

                }
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.IsBodyHtml = false;

                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                mailServer.Send(mailMessage);
                return  true;
            }

            if (templateCode == "FIRMA")
            {

                string body = "";

                // int templateID = Convert.ToInt32(dt.Rows[0]["TemplateID"]);
                bool isHTML = true; // Convert.ToBoolean(dt.Rows[0]["IsHTML"]);
                string mailText = ""; // dt.Rows[0]["TemplateText"].ToString();
                string subject = "Servicio en linea"; //dt.Rows[0]["Subject"].ToString();


                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/") + "ConfirmacionCertificadoDigital.html"))
                {
                    body = reader.ReadToEnd();
                }
              


                body = body.Replace("{Cliente}", usuariodigital + " / " + solicitanteDigital);
                body = body.Replace("{Fecha}", DateTime.Now.ToShortDateString());
                body = body.Replace("{Servicios}", ActividadDigital);
                body = body.Replace("{UrlCancelacion}", "");
                body = body.Replace("{Direccion}", "Avenida 27 de Febrero esq. Tiradentes No. 256, Torre Friusa.");
                body = body.Replace("{Logo}", "https://www.camarasantodomingo.do/Media/assets/images/layout/logo.png");
                body = body.Replace("{Camara}", "Cámara de Comercio y Producción");
                body = body.Replace("{mensajeCamara}", "");

                mailText = body;


                //replace parametres.
                //foreach (KeyValuePair<string, string> param in parameters)
                //{
                //    mailText =  param.Value;
                //    //subject = subject.Replace(param.Key, param.Value);
                //}

                //Send mail
                var mailServer = new SmtpClient()
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Host = host,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("Cámara de Comercio y Produción de Santo Domingo", "Uq_KPdgFxH3rT69it2mWyQ")
                };

                //create mail message.
                var mailMessage = new MailMessage(from, to, subject, mailText);
                if (!string.IsNullOrEmpty(cc))
                {
                    var ccemail = cc.Split(',');

                    for (int i = 0; i < ccemail.Length; i++)
                    {
                        mailMessage.CC.Add(new MailAddress(ccemail[i]));
                    }
                   
                }
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.IsBodyHtml = true;

                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                mailServer.Send(mailMessage);

                result = true;


            }
            else
            {
                if (dt != null)
                {
                    int templateID = Convert.ToInt32(dt.Rows[0]["TemplateID"]);
                    bool isHTML = Convert.ToBoolean(dt.Rows[0]["IsHTML"]);
                    string mailText = dt.Rows[0]["TemplateText"].ToString();
                    string subject = dt.Rows[0]["Subject"].ToString();

                    //replace parametres.
                    foreach (KeyValuePair<string, string> param in parameters)
                    {
                        mailText = mailText.Replace(param.Key, param.Value);
                        subject = subject.Replace(param.Key, param.Value);
                    }

                    //Send mail
                    var mailServer = new SmtpClient()
                    {
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Host = host,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential("Cámara de Comercio y Produción de Santo Domingo", "Uq_KPdgFxH3rT69it2mWyQ")
                    };

                    //create mail message.
                    var mailMessage = new MailMessage(from, to, subject, mailText);
                    if (!string.IsNullOrEmpty(cc))
                    {
                        mailMessage.CC.Add(new MailAddress(cc));
                    }
                    mailMessage.BodyEncoding = Encoding.UTF8;
                    mailMessage.IsBodyHtml = Convert.ToBoolean(isHTML);

                    ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                    mailServer.Send(mailMessage);

                    result = true;
                }

            }


            return result;
        }

        public static bool SendMailWithAttachmentNow(string to, string cc, string bcc, string from, string templateCode, int sourceID, Dictionary<string, byte[]> attachments, Dictionary<string, string> parameters)
        {
            var result = true;
            
            //Build mail based on template
            var dal = new DataAccess();

            DataTable dt = dal.GetTemplate(templateCode);

            if (dt != null)
            {
                int templateID = Convert.ToInt32(dt.Rows[0]["TemplateID"]);
                bool isHTML = Convert.ToBoolean(dt.Rows[0]["IsHTML"]);
                string mailText = dt.Rows[0]["TemplateText"].ToString();
                string subject = dt.Rows[0]["Subject"].ToString();

                //replace parametres.
                foreach (KeyValuePair<string, string> param in parameters)
                {
                    mailText = mailText.Replace(param.Key, param.Value);
                    subject = subject.Replace(param.Key, param.Value);
                }

                //Send mail
                var mailServer = new SmtpClient();

                //create mail message.
                MailMessage mailMessage = new MailMessage(from, to, subject, mailText);
                if (!string.IsNullOrEmpty(cc))
                {
                    mailMessage.CC.Add(new MailAddress(cc));
                }
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.IsBodyHtml = Convert.ToBoolean(isHTML);
             
                //add attachments
                foreach (KeyValuePair<string, byte[]> item in attachments)
                {
                    //add the bytes from the 
                    mailMessage.Attachments.Add(new Attachment(new MemoryStream(item.Value), item.Key));
                }

                try
                {
                    mailServer.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    result = false;
                }

            }
            return result;
        }


        public static bool SendMail(string to, string cc, string bcc, string from, string templateCode, 
            string host, int sourceID, Dictionary<string, string> parameters, string usuariodigital = "" , string solicitanteDigital = "",
            string ActividadDigital = "", string cantidaddigital = "")
        {

            //Session["UsarioDigital"] = HttpContext.Current.User.Identity.Name;
            //Session["SolicitanteDigital"] = profile.NombreSolicitante.ToString();
            //Session["ActividadDigital"] = Texto + " " + ", por el tiempo de " + tiempo + " ano ,";
            //Session["CantidadDigital"] = Cantidad;

            return SendMailNow(to, cc, bcc, from, host ,templateCode, sourceID, parameters ,  usuariodigital ,  solicitanteDigital ,
             ActividadDigital,  cantidaddigital );
            //SendMailWithService(to, cc, bcc, from, templateCode, sourceID, parameters);
        }
    }
}
