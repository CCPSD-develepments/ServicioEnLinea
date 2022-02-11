using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Net.Mail;
using System.Web.Profile;
using System.Text.RegularExpressions;

namespace CamaraComercio.Website.Account
{
    ///<summary>
    /// Página que sirve para solicitar un reinicio de contraseña
    ///</summary>
    public partial class ForgotPassword : System.Web.UI.Page
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ForgotPassword.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ForgotPassword.Page_Load(object, EventArgs)'
        {
            Session["RecuperarPass"] = true;

           if (IsPostBack) return;
           Master.HideNavigation();

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ForgotPassword.passwordRecovery_SendingMail(object, MailMessageEventArgs)'
        protected void passwordRecovery_SendingMail(object sender, MailMessageEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ForgotPassword.passwordRecovery_SendingMail(object, MailMessageEventArgs)'
        {
            //Buscar el GUID del usuario (UserID)
            MembershipUser user = Membership.GetUser(this.passwordRecovery.UserName.ToLower());

            //Traer el Mensaje a enviar
            MailMessage msg = e.Message;
           

            //Armar el link de confirmacion

            //Crear guid de reseteo password para link
            Guid key = Guid.NewGuid();

            //salvar el GUID en el profile 
            var profile = (OficinaVirtualUserProfile)ProfileBase.Create(user.UserName.ToLower());
            profile.PasswordResetKey = key.ToString();
            profile.Save();
   
            string url = string.Format("{0}/Account/ForgotPasswordVerification.aspx?key={1}",  Helper.UrlPortal, key.ToString());

            //Armar el correo a enviar

            var parametros = new Dictionary<string, string>();
            parametros.Add("[NombreCompleto]", profile.NombreSolicitante);
            parametros.Add("[Link]", url);

            //invocar envio de template Recuperación de Contraseña
            MailBot.MailBot.SendMail(user.Email, null, null,
                Helper.FromEmailCorreoCamara, "RDC", Helper.MailServer, 1, parametros);

            //cancela el envio del mail que envía automático el control de membership para que solo llegue el de Mailbot.
            e.Cancel = true;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ForgotPassword.passwordRecovery_VerifyingUser(object, LoginCancelEventArgs)'
        protected void passwordRecovery_VerifyingUser(object sender, LoginCancelEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ForgotPassword.passwordRecovery_VerifyingUser(object, LoginCancelEventArgs)'
        {

            //Instantiate the regular expression.
            var r = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);

            // Match the regular expression.
            var m = r.Match(this.passwordRecovery.UserName.ToLower());

            //check if email is valid.
            if (m.Success)
            {
                var user = Membership.GetUserNameByEmail(this.passwordRecovery.UserName.ToLower());

                if (user != null)
                {
                    var userMS = Membership.FindUsersByEmail(this.passwordRecovery.UserName.ToLower());
                    if (userMS != null && userMS.Count > 0)
                    {
                        userMS[user].UnlockUser();
                    }

                    this.passwordRecovery.UserName = user.ToLower();
                }
            }
            else
            {
                var user = Membership.FindUsersByName(this.passwordRecovery.UserName);
                if (user != null && user.Count > 0)
                {
                    user[this.passwordRecovery.UserName].UnlockUser();
                }
            }
        }
    }
}