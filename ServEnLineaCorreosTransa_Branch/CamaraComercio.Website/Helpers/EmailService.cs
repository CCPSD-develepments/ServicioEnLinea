using System.Collections;
using NVelocity.Runtime;

namespace CamaraComercio.Website.Helpers
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using System.Reflection;
    using System.Threading;
    using Commons.Collections;
    using NVelocity;
    using NVelocity.App;

    public class EmailService : IEmailService
    {
        private readonly ExtendedProperties Properties;
        private VelocityEngine VelocityEngine;
        private Template Template;
        private VelocityContext Context;

        public EmailService()
        {
            //Configuration properties to identify the template path
            Properties = new ExtendedProperties();
            Properties.AddProperty(RuntimeConstants.RESOURCE_LOADER, "assembly");
            Properties.AddProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH,AppDomain.CurrentDomain.BaseDirectory+@"\Templates");
            
        }

        #region Implementation of IEmailService

        /// <summary>
        /// Sends the registration information to the username
        /// </summary>
        /// <param name="email">
        /// User's email
        /// </param>
        /// <param name="userName">
        /// User's username
        /// </param>
        /// <param name="password">
        /// User's password
        /// </param>
        /// <param name="activateUrl">
        /// Account activation url
        /// </param>
        /// <param name="serverName"></param>
        /// <param name="confirmationCode"></param>
        public void SendRegistrationInfo(string email, string userName, string password, string serverName, string confirmationCode)
        {
            //Assembly calling the method
            string caller = Assembly.GetCallingAssembly().GetName().Name;

            //Specifying that the loader assembly is not the service but the caller
            Properties.AddProperty("assembly.resource.loader.assembly", caller);

            string template = AppDomain.CurrentDomain.BaseDirectory + @"Templates";
            //caller + ".Templates.RegistrationInfo.vm";

            //Loading the template body
            string body = PrepareMailBodyWith(template, "UserName", userName,
                                                        "Password", password,
                                                        "Server", serverName,                                                        
                                                        "ConfirmationCode", confirmationCode);

            SendMailAsync("greenlight.nextmedia@gmail.com", email, "La Página: Registration Info", body);
        }

        /// <summary>
        /// Notifies the account activation after confirmation
        /// </summary>
        /// <param name="email">
        /// User's email
        /// </param>
        /// <param name="userName">
        /// Username
        /// </param>
        public void SendConfirmationMail(string email, string userName)
        {
            //Assembly calling the method
            string caller = Assembly.GetCallingAssembly().GetName().Name;

            //Specifying that the loader assembly is not the service but the caller
            Properties.AddProperty("assembly.resource.loader.assembly", caller);

            string template = caller + ".Templates.AccountConfirmation.vm";

            //Loading the template body
            string body = PrepareMailBodyWith(template, "UserName", userName);

            SendMailAsync("greenlight.nextmedia@gmail.com", email, "La Página: Account confirmation", body);
        }

        /// <summary>
        /// Sends the new password after a password reset
        /// </summary>
        /// <param name="email">
        /// User's email
        /// </param>
        /// <param name="userName">
        /// Username
        /// </param>
        /// <param name="password">
        /// New password
        /// </param>
        public void SendNewPassword(string email, string userName, string password)
        {
            //Assembly calling the method
            string caller = Assembly.GetCallingAssembly().GetName().Name;

            //Specifying that the loader assembly is not the service but the caller
            Properties.AddProperty("assembly.resource.loader.assembly", caller);

            string template = caller + ".Templates.NewPassword.vm";

            //Loading the template body
            string body = PrepareMailBodyWith(template, "UserName", userName, "Password", password);

            SendMailAsync("greenlight.nextmedia@gmail.com", email, "La Página: Account modification", body);
        }

        /// <summary>
        /// Notifies the author of an article that somebody commented
        /// one of his publications
        /// </summary>
        /// <param name="email">
        /// User's Email
        /// </param>
        /// <param name="articlePermaLink">
        /// Article permalink
        /// </param>
        /// <param name="userName">
        /// Username of the user who made the comment
        /// </param>
        /// <param name="comment">
        /// Comment body
        /// </param>
        public void SendArticleComment(string email, string articlePermaLink, string userName, string comment)
        {
            //Assembly calling the method
            string caller = Assembly.GetCallingAssembly().GetName().Name;

            //Specifying that the loader assembly is not the service but the caller
            Properties.AddProperty("assembly.resource.loader.assembly", caller);

            string template = caller + ".Templates.ArticleComment.vm";

            //Loading the template body
            string body = PrepareMailBodyWith(template, "UserName", userName, "PermaLink", articlePermaLink, "Comment", comment);

            SendMailAsync("greenlight.nextmedia@gmail.com", email, "La Página: Article comment", body);
        }

        /// <summary>
        /// Notifies the author of an article that somebody commented
        /// one of his publications
        /// </summary>
        /// <param name="email">
        /// User's Email
        /// </param>
        /// <param name="commentPermaLink">
        /// Comment permalink
        /// </param>
        /// <param name="userName">
        /// Username of the user who made the comment
        /// </param>
        /// <param name="comment">
        /// Comment body
        /// </param>
        public void SendChildComment(string email, string commentPermaLink, string userName, string comment)
        {
            //Assembly calling the method
            string caller = Assembly.GetCallingAssembly().GetName().Name;

            //Specifying that the loader assembly is not the service but the caller
            Properties.AddProperty("assembly.resource.loader.assembly", caller);

            string template = caller + ".Templates.ChildComment.vm";

            //Loading the template body
            string body = PrepareMailBodyWith(template, "UserName", userName, "PermaLink", commentPermaLink, "Comment", comment);

            SendMailAsync("greenlight.nextmedia@gmail.com", email, "La Página: Article comment", body);
        }

        public void FanFeedback()
        {
            throw new NotImplementedException();
        }

        public void BestArticles()
        {
            throw new NotImplementedException();
        }

        public void NewsLetter()
        {
            throw new NotImplementedException();
        }

        public void ResendEmailConfirmationKey(string email, string userName, string serverName, string emailConfirmationKey)
        {
            //Assembly calling the method
            string caller = Assembly.GetCallingAssembly().GetName().Name;

            //Specifying that the loader assembly is not the service but the caller
            Properties.AddProperty("assembly.resource.loader.assembly", caller);

            string template = AppDomain.CurrentDomain.BaseDirectory + @"Templates";// caller + ".Templates.EmailConfirmation.vm";
            Properties.AddProperty(RuntimeConstants.FILE_RESOURCE_LOADER_CACHE, template);
            //Loading the template body
            string body = PrepareMailBodyWith(template, "UserName", userName,
                                                        "Server", serverName,
                                                        "ConfirmationCode", emailConfirmationKey);

            SendMailAsync(email, email, "Camara de Comercio Sto. Dgo.: Activacion nueva cuenta.", body);
        }

        #endregion

        #region Private Members/Methods

        /// <summary>
        /// Builds up the body for a template
        /// </summary>
        /// <param name="template">
        /// Template name
        /// </param>
        /// <param name="pairs">
        /// Body parameters
        /// </param>
        /// <returns>
        /// Body with param values
        /// </returns>
        private string PrepareMailBodyWith(string template, params string[] pairs)
        {
            StringWriter writer = new StringWriter();

            //Creating the templating engine object
            VelocityEngine = new VelocityEngine();
            VelocityEngine.Init(Properties);
            //Loading the template
            //Template = VelocityEngine.GetTemplate("Proyectos\\CCPSDBID\\oficinavirtual\\src\\CamaraComercio.Website\\Templates\\RegistrationInfo.vm");
            Template = VelocityEngine.GetTemplate("RegistrationInfo.vm");
            
            //Creating context obj
            Context = new VelocityContext();

            for (int i = 0; i < pairs.Length; i += 2)
            {
                Context.Put(pairs[i], pairs[i + 1]);
            }

            //Merging the template
            Template.Merge(Context, writer);

            return writer.GetStringBuilder().ToString();
        }

        private static MailMessage BuildMessageWith(string fromAddress, string toAddress, string subject, string body)
        {
            MailMessage message = new MailMessage
                                      {
                                          From = new MailAddress(fromAddress, "La Página"),
                                          Subject = subject,
                                          Body = body,
                                          IsBodyHtml = true,
                                      };

            string[] tos = toAddress.Split(';');

            foreach (string to in tos)
            {
                message.To.Add(new MailAddress(to));
            }

            return message;
        }

        private void SendMail(string fromAddress, string toAddress, string subject, string body)
        {
            using (MailMessage mail = BuildMessageWith(fromAddress, toAddress, subject, body))
            {
                SendMail(mail);
            }
        }

        private void SendMail(MailMessage mail)
        {
            NetworkCredential networkCred = new NetworkCredential
                                                {
                                                    UserName = "no-reply@lapagina.net",
                                                    Password = "MAIL512lpg"
                                                };
            SmtpClient smtp = new SmtpClient
                                  {
                                      Host = "smtp.gmail.com",
                                      EnableSsl = true,
                                      UseDefaultCredentials = false,
                                      Credentials = networkCred,
                                      Port = 587
                                  };
            smtp.Send(mail);
        }

        private void SendMailAsync(string fromAddress, string toAddress, string subject, string body)
        {
            ThreadPool.QueueUserWorkItem(state => SendMail(fromAddress, toAddress, subject, body));
        }

        #endregion
    }
}