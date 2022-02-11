using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Profile;
using CamaraComercio.DataAccess.EF.Membership;
using System.Text.RegularExpressions;

namespace CamaraComercio.Website.Account
{
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "AccountSiteMap")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MyProfile'
    public partial class MyProfile : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MyProfile'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MyProfile.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MyProfile.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;

            Master.HideNavigation();

            if (User.Identity.IsAuthenticated)
            {
                //buscar user por username.
                var user = Membership.GetUser(User.Identity.Name);

                //buscar el profile del user
                var userProfile = (OficinaVirtualUserProfile)ProfileBase.Create(user.UserName);

                //llenar los campos
                this.txtUsuario.Text = user.UserName.ToLower();
                this.txtNombre.Text = userProfile.NombreSolicitante;
                this.txtEmail.Text = user.Email;
                this.ddlTipoDocumento.Items.FindByValue(userProfile.TipoDocumento.FirstOrDefault().ToString()).Selected = true;
                if (ddlTipoDocumento.SelectedValue == "C")
                    this.txtNoDocumento.Text = userProfile.NumeroDocumento.RemoverFormato();
                else
                    this.txtNoDocumento.Text = userProfile.NumeroDocumento;

                //revisar si es gestor o no y desabilitar campos si es necesario.
                if (!userProfile.IsGestorAdmin()) //esto indica que no es gestor administrativo
                {
                    this.divEmpresa.Visible = false;

                    this.rfvEmpresa.Enabled = false;
                    this.rfvRNC.Enabled = false;
                }
                else
                {
                    //llenar los campos con los datos RNC y Empresa
                    this.txtEmpresa.Text = userProfile.NombreEmpresa;
                    this.txtRNC.Text = userProfile.RNC.RemoverFormato();
                }
            }
            else
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MyProfile.btnSave_Click(object, EventArgs)'
        protected void btnSave_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MyProfile.btnSave_Click(object, EventArgs)'
        {
            if (this.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    //buscar user por username.
                    var user = Membership.GetUser(User.Identity.Name);

                    //buscar el profile del user
                    var userProfile = (OficinaVirtualUserProfile)ProfileBase.Create(user.UserName.ToLower());

                    //actualizar los datos en los objetos user y profile
                    userProfile.NombreSolicitante = this.txtNombre.Text.Trim();

                    user.Email = this.txtEmail.Text;
                    userProfile.TipoDocumento = this.ddlTipoDocumento.SelectedValue;

                    //formatear cedula
                    var cedula = this.txtNoDocumento.Text.Trim();


                    if (this.ddlTipoDocumento.SelectedValue == "C")
                    {
                        //remplazar guiones por espacio.
                        cedula = cedula.Replace("-", string.Empty);
                        //formatear cedula con helper.
                        cedula = cedula.FormatRnc();
                    }
                    userProfile.NumeroDocumento = cedula;

                    //agregar informacion de empresa
                    userProfile.NombreEmpresa = this.txtEmpresa.Text.Trim();
                    userProfile.RNC = this.txtRNC.Text.Trim().FormatRnc();

                    //persistir en bd perfil y usuario
                    userProfile.Save();
                    Membership.UpdateUser(user);

                    this.lblResultado.Text = "La información ha sido actualizada satisfactoriamente.";
                }
                else
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
        }


        /// <summary>
        /// Verifica que un correo de un usuario no exista previamente en la base de datos del Membership
        /// </summary>
        /// <param name="emailNuevoUsuario"></param>
        /// <returns></returns>
        private bool ExisteCorreo(string emailNuevoUsuario)
        {
            string usuario = Membership.GetUserNameByEmail(emailNuevoUsuario);
            return (!String.IsNullOrEmpty(usuario));
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MyProfile.cvEmail_ServerValidate(object, ServerValidateEventArgs)'
        protected void cvEmail_ServerValidate(object source, ServerValidateEventArgs args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MyProfile.cvEmail_ServerValidate(object, ServerValidateEventArgs)'
        {
            //revisar si no existe
            if (!MembershipHelper.ExisteCorreo(this.txtEmail.Text.Trim()))
            {
                //si no existe is valid = true
                args.IsValid = true;
                return;
            }
            else //si existe
            {
                //revisar traer el mail del usuario de la bd
                var email = UsuariosController.GetEmailByUsername(this.txtUsuario.Text.Trim());

                //comparar a ver si es el mismo
                if (email == this.txtEmail.Text.Trim())
                {
                    //si es el mismo is valid = true
                    args.IsValid = true;
                }
                else
                    args.IsValid = false;
            }





        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MyProfile.cvNoDocumento_ServerValidate(object, ServerValidateEventArgs)'
        protected void cvNoDocumento_ServerValidate(object source, ServerValidateEventArgs args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MyProfile.cvNoDocumento_ServerValidate(object, ServerValidateEventArgs)'
        {
            //if (this.ddlTipoDocumento.SelectedValue == "C")
            //{

            //    //remplazar guiones por espacio.
            //    var cedula = this.txtNoDocumento.Text.Trim().Replace("-",string.Empty);

            //    //matchear que sea cedula (11 digitos sin espacios)
            //    Match match = Regex.Match(cedula, @"^[0-9]{11}$", RegexOptions.IgnoreCase);

            //    if (match.Success)
            //        args.IsValid = true;
            //    else
            //        args.IsValid = false;
            //}
            //else
            //    args.IsValid = true;
        }
    }
}