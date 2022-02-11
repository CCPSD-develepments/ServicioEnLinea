using CamaraComercio.DataAccess.EF.Membership;
using CamaraComercio.Website.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CamaraComercio.Website.Account
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Register2'
    public partial class Register2 : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Register2'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Register2.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Register2.Page_Load(object, EventArgs)'
        {
            
        }

        [Obsolete]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Register2.btnRegister_Click(object, EventArgs)'
        protected void btnRegister_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Register2.btnRegister_Click(object, EventArgs)'
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

            //if (!string.IsNullOrWhiteSpace(txtNumeroRegistroMercantil.Text) && !ckbIsValidNumeroRegistroMercantil.Checked)
            //{
            //    var ctrl = new CustomValidator
            //    {
            //        IsValid = false,
            //        ErrorMessage = "El Número de Registro Mercantil no es válido",
            //        Display = ValidatorDisplay.None,
            //        ValidationGroup = "RegisterUserValidationGroup"
            //    };
            //    this.Page.Form.Controls.Add(ctrl);
            //    return;
            //}

            if (!string.IsNullOrWhiteSpace(txtCedula.Text.Trim()))
            {
                var userName = string.Empty;

                userName = UsuariosController.DevuelveUsernamePorDocumento(txtCedula.Text.Trim());

                if (!string.IsNullOrWhiteSpace(userName))
                {
                    if(UsuariosController.ValidadBorradoRegistroMas24HorasSinAprobar(userName.ToLower()))
                        Membership.DeleteUser(userName);
                    else
                    {
                        var ctrl = new CustomValidator
                        {
                            IsValid = false,
                            ErrorMessage = "Debe esperar más de 24 horas intentarse resgistrar con este documento.",
                            Display = ValidatorDisplay.None,
                            ValidationGroup = "RegisterUserValidationGroup"
                        };
                        this.Page.Form.Controls.Add(ctrl);
                        return;
                    }
                }
            }

            //crear usuario.
            var user = Membership.CreateUser(this.UserName.Text.Trim().ToLower(), this.Password.Text.Trim(), this.Email.Text.Trim());

            //marcar el usuario como no activo.
            user.IsApproved = false;
            Membership.UpdateUser(user);

            var profile = (OficinaVirtualUserProfile)ProfileBase.Create(this.UserName.Text.Trim().ToLower());

            //Propiedades del perfil
            profile.NombreSolicitante = this.NombreCompletoTextBox.Text.Trim();
            profile.TipoDocumento = this.ddlTipoDocumento.SelectedValue;
            profile.NumeroDocumento = this.txtCedula.Text.Trim();
            profile.Telefono = this.txtTelefono.Text;
            profile.bFirmaDigital = this.chkFirmaDigital.Checked;
   

            //Formatear cedula
            if (ddlTipoDocumento.SelectedValue == "Cedula")
                profile.NumeroDocumento = profile.NumeroDocumento.FormatRnc();


       
                //Si es gestor revisar dos propiedades adicionales
                profile.NombreEmpresa = string.Empty;
                profile.RNC = string.Empty;
            

            //Todos los usuarios son gestores. Se marca el padre como nulo 
            profile.UsuarioPadre = null;

            //Guardar el perfil
            profile.Save();

            try
            {
                string url = string.Empty;

                //enviar el mail de notificacion
               EnviarCorreo(user, profile, out url);

                //Guardar link de confirmacion en tabla de log
               LogTransaccionesMethods.GrabarLogTransacciones(0, url, true, user.UserName.ToLower());
                
                 
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                //rollback
                Membership.DeleteUser(user.UserName.ToLower());

                //poner mensaje
                //Master.ShowMessageError("Ha ocurrido un error en el proceso de registración de cuenta. Intentelo nuevamente.");
                var ctrl = new CustomValidator
                {
                    IsValid = false,
                    ErrorMessage = "No se ha podido crear el usuario, por favor intente nuevamente.",
                    Display = ValidatorDisplay.None,
                    ValidationGroup = "RegisterUserValidationGroup"
                };
                this.Page.Form.Controls.Add(ctrl);
                return;
            }
            //mandar mensaje de que fue creado el usuario
            String PopUp = "<script language='javascript'>alertify.alert('Servicio en linea', 'Registro completado con éxito. A su correo se le ha enviado un enlace para que continúe con el proceso de validación y activación de su usuario!', function(){window.location='/Account/PendingActivation.aspx'; });</script>";
            Page.RegisterStartupScript("PopScript", PopUp);

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Register2.CustomValidatorEmailDuplicado_ServerValidate(object, ServerValidateEventArgs)'
        protected void CustomValidatorEmailDuplicado_ServerValidate(object source, ServerValidateEventArgs args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Register2.CustomValidatorEmailDuplicado_ServerValidate(object, ServerValidateEventArgs)'
        {
            var usuario = Membership.GetUserNameByEmail(args.Value);
            args.IsValid = String.IsNullOrEmpty(usuario);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Register2.vcTipoCedula_ServerValidate(object, ServerValidateEventArgs)'
        protected void vcTipoCedula_ServerValidate(object source, ServerValidateEventArgs args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Register2.vcTipoCedula_ServerValidate(object, ServerValidateEventArgs)'
        {
            if (!Regex.IsMatch(args.Value, @"^\d+$") && ddlTipoDocumento.SelectedValue == "Cedula")
                args.IsValid = false;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Register2.vcExisteCedula_ServerValidate(object, ServerValidateEventArgs)'
        protected void vcExisteCedula_ServerValidate(object source, ServerValidateEventArgs args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Register2.vcExisteCedula_ServerValidate(object, ServerValidateEventArgs)'
        {
            //revisar si existeCedula
            if (UsuariosController.ExisteNoDocumento(this.txtCedula.Text.Trim()))
                args.IsValid = false;
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Register2.cvUserName_ServerValidate(object, ServerValidateEventArgs)'
        protected void cvUserName_ServerValidate(object source, ServerValidateEventArgs args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Register2.cvUserName_ServerValidate(object, ServerValidateEventArgs)'
        {
            //revisar si existe el usuario
            var uc = new UsuariosController();

            if (uc.ExisteUsuario(this.UserName.Text.Trim()))
                args.IsValid = false;
        }

#pragma warning disable CS1573 // Parameter 'linkAct' has no matching param tag in the XML comment for 'Register2.EnviarCorreo(MembershipUser, OficinaVirtualUserProfile, out string)' (but other parameters do)
        /// <summary>
        /// Envia un correo al usuario que se acaba de registrar para que valide su usuario
        /// </summary>
        /// <param name="user"></param>
        /// <param name="profile"></param>
        private static void EnviarCorreo(MembershipUser user, OficinaVirtualUserProfile profile, out string linkAct)
#pragma warning restore CS1573 // Parameter 'linkAct' has no matching param tag in the XML comment for 'Register2.EnviarCorreo(MembershipUser, OficinaVirtualUserProfile, out string)' (but other parameters do)
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

            MailBot.MailBot.SendMail(user.Email, null, null, Helper.FromEmailCorreoCamara, "RDU", Helper.MailServer, 1, parametros);
        }

        //protected void btnSearchEmpresa_ServerClick(object sender, EventArgs e)
        //{
            //if (string.IsNullOrWhiteSpace(txtNumeroRegistroMercantil.Text))
            //{
            //    ckbIsValidNumeroRegistroMercantil.Checked = false;
            //    var ctrl = new CustomValidator
            //    {
            //        IsValid = false,
            //        ErrorMessage = "Debe digitar el Número de Registro Mercantil",
            //        Display = ValidatorDisplay.None,
            //        ValidationGroup = "RegisterUserValidationGroup"
            //    };
            //    this.Page.Form.Controls.Add(ctrl);
            //    return;
            //}

            //if (!int.TryParse(txtNumeroRegistroMercantil.Text.Trim(), out int numeroRegistroMercantil))
            //{
            //  ckbIsValidNumeroRegistroMercantil.Checked = false;
            //    var ctrl = new CustomValidator
            //    {
            //        IsValid = false,
            //        ErrorMessage = "El Número de Registro Mercantil debe ser un número válido, no debe contener letras",
            //        Display = ValidatorDisplay.None,
            //        ValidationGroup = "RegisterUserValidationGroup"
            //    };
            //    this.Page.Form.Controls.Add(ctrl);
            //    return;
            //}

            //var ctrlSociedades = new DataAccess.EF.SRM.SociedadesController();
            //var sociedades = ctrlSociedades.FetchByRegistroAndCamara(numeroRegistroMercantil, "SDQ");
            //if (sociedades.Count == 0)
            //{
            // //   ckbIsValidNumeroRegistroMercantil.Checked = false;
            //    var ctrl = new CustomValidator
            //    {
            //        IsValid = false,
            //        ErrorMessage = "No se encontró ninguna sociedad con ese Número de Registro en la Cámara de Santo Domingo",
            //        Display = ValidatorDisplay.None,
            //        ValidationGroup = "RegisterUserValidationGroup"
            //    };
            //    this.Page.Form.Controls.Add(ctrl);
            //    return;
            //}

           // ckbIsValidNumeroRegistroMercantil.Checked = true;
          //  txtNombreEmpresa.Text = sociedades.First().NombreSocial;
        //}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Register2.txtNumeroRegistroMercantil_TextChanged(object, EventArgs)'
        protected void txtNumeroRegistroMercantil_TextChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Register2.txtNumeroRegistroMercantil_TextChanged(object, EventArgs)'
        {
           // ckbIsValidNumeroRegistroMercantil.Checked = false;
        }
    }
}