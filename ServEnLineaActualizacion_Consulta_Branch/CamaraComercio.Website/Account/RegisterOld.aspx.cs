using System;
using System.Collections.Generic;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF.Membership;
using System.Text.RegularExpressions;
using CamaraComercio.Website.Helpers;

namespace CamaraComercio.Website.Account
{
    ///<summary>
    /// Página utilizada para registrar un nuevo usuario en el sistema
    ///</summary>
    public partial class Register : Page
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Register.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Register.Page_Load(object, EventArgs)'
        {
            Master.HideNavigation();
        }

        #region Register
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Register.btnRegister_Click(object, EventArgs)'
        protected void btnRegister_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Register.btnRegister_Click(object, EventArgs)'
        {
            //Validación de página válida
            if (!Page.IsValid)
                return;

            if (!this.chkTerminosUso.Checked)
            {
                var ctrl = new CustomValidator
                {
                    IsValid = false,
                    ErrorMessage = "Debe aceptar los términos de uso del portal",
                    Display = ValidatorDisplay.None,
                    ValidationGroup = "RegisterUserValidationGroup"
                };
                this.Page.Form.Controls.Add(ctrl);
                return;
            }

            //crear usuario.
            var user = Membership.CreateUser(this.UserName.Text.Trim(), this.Password.Text.Trim(), this.Email.Text.Trim());

            //marcar el usuario como no activo.
            user.IsApproved = false;
            Membership.UpdateUser(user);

            var profile = (OficinaVirtualUserProfile)ProfileBase.Create(this.UserName.Text.Trim());

            //Propiedades del perfil
            profile.NombreSolicitante = this.NombreCompletoTextBox.Text.Trim();
            profile.TipoDocumento = this.ddlTipoDocumento.SelectedValue;
            profile.NumeroDocumento = this.txtCedula.Text.Trim();
            profile.Telefono = this.txtTelefono.Text;

            //Formatear cedula
            if (ddlTipoDocumento.SelectedValue == "Cedula")
                profile.NumeroDocumento = profile.NumeroDocumento.FormatRnc();

            //Si es gestor revisar dos propiedades adicionales
            profile.NombreEmpresa = this.txtNombreEmpresa.Text.Trim();
            profile.RNC = this.txtNombreCompleto.Text.Trim();
            
            //Todos los usuarios son gestores. Se marca el padre como nulo 
            profile.UsuarioPadre = null;

            //Guardar el perfil
            profile.Save();

            try
            {
                string url= string.Empty;

                //enviar el mail de notificacion
                EnviarCorreo(user, profile, out url);

                //Guardar link de confirmacion en tabla de log
                LogTransaccionesMethods.GrabarLogTransacciones(0, url, true, user.UserName);
                //
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                //rollback
                Membership.DeleteUser(user.UserName);

                //poner mensaje
                Master.ShowMessageError("Ha ocurrido un error en el proceso de registración de cuenta. Intentelo nuevamente.");
                return;
            }

            //redireccionar al pending activation
            Response.Redirect("/Account/PendingActivation.aspx");
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Register.CustomValidatorEmailDuplicado_ServerValidate(object, ServerValidateEventArgs)'
        protected void CustomValidatorEmailDuplicado_ServerValidate(object source, ServerValidateEventArgs args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Register.CustomValidatorEmailDuplicado_ServerValidate(object, ServerValidateEventArgs)'
        {
            var usuario = Membership.GetUserNameByEmail(args.Value);
            args.IsValid = String.IsNullOrEmpty(usuario);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Register.vcTipoCedula_ServerValidate(object, ServerValidateEventArgs)'
        protected void vcTipoCedula_ServerValidate(object source, ServerValidateEventArgs args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Register.vcTipoCedula_ServerValidate(object, ServerValidateEventArgs)'
        {
            if (!Regex.IsMatch(args.Value, @"^\d+$") && ddlTipoDocumento.SelectedValue == "Cedula")
                args.IsValid = false;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Register.vcExisteCedula_ServerValidate(object, ServerValidateEventArgs)'
        protected void vcExisteCedula_ServerValidate(object source, ServerValidateEventArgs args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Register.vcExisteCedula_ServerValidate(object, ServerValidateEventArgs)'
        {
            //revisar si el mail existe
            if (UsuariosController.ExisteNoDocumento(this.txtCedula.Text.Trim()))
                args.IsValid = false;
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Register.cvUserName_ServerValidate(object, ServerValidateEventArgs)'
        protected void cvUserName_ServerValidate(object source, ServerValidateEventArgs args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Register.cvUserName_ServerValidate(object, ServerValidateEventArgs)'
        {
            //revisar si existe el usuario
            var uc = new UsuariosController();

            if (uc.ExisteUsuario(this.UserName.Text.Trim()))
                args.IsValid = false;
        }
        #endregion

#pragma warning disable CS1573 // Parameter 'linkAct' has no matching param tag in the XML comment for 'Register.EnviarCorreo(MembershipUser, OficinaVirtualUserProfile, out string)' (but other parameters do)
        /// <summary>
        /// Envia un correo al usuario que se acaba de registrar para que valide su usuario
        /// </summary>
        /// <param name="user"></param>
        /// <param name="profile"></param>
        private static void EnviarCorreo(MembershipUser user, OficinaVirtualUserProfile profile, out string linkAct)
#pragma warning restore CS1573 // Parameter 'linkAct' has no matching param tag in the XML comment for 'Register.EnviarCorreo(MembershipUser, OficinaVirtualUserProfile, out string)' (but other parameters do)
        {
            linkAct = string.Empty;
            //check for nulls
            if (user == null || user.ProviderUserKey == null) return;

            //Armar el link de confirmacion            
            var url = string.Format("{0}/account/Activacionusuario.aspx?id={1}", Helper.UrlPortal, user.ProviderUserKey);

            linkAct = url;

            //Armar correo a enviar
            var parametros = new Dictionary<string, string>
                                 {
                                     {"[NombreCompleto]", profile.NombreSolicitante},
                                     {"[UserName]", user.UserName},
                                     {"[link]", url}
                                 };

            MailBot.MailBot.SendMail(user.Email, null, null, Helper.FromEmailCorreoCamara, "RDU",
                Helper.MailServer, 1, parametros);
        }
    }
}