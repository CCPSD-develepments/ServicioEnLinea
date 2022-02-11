using CamaraComercio.DataAccess.EF.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace CamaraComercio.Website.Account
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin'
    public partial class UsersAdmin : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin'
    {
        private bool EsActivo
        {
            get
            {
                var item = Session["UsersAdmin_EsActivo"] != null ? (bool)Session["UsersAdmin_EsActivo"] : false;
                return item;
            }
            set
            {
                Session["UsersAdmin_EsActivo"] = value;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.Page_Load(object, EventArgs)'
        {
            //Usuario Actual
            this.odsUsers.SelectParameters["usuarioPadre"].DefaultValue = User.Identity.Name;

            if (IsPostBack) return;

            //Se busca la informacion del usuario. Si la propiedad "UsuarioPadre" no está vacía quiere decir que el usuario no tiene permisos para entrar a esta seccion
            var usuario = (OficinaVirtualUserProfile)ProfileBase.Create(User.Identity.Name);
            if (!usuario.IsGestorAdmin())
            {
                Master.ShowMessageError("Usted no tiene acceso ");
                Response.Redirect("~/Empresas/Oficina.aspx");
                //throw new HttpException(403, "Acceso Denegado/Prohibido");
            }

            this.hfCurrentUser.Value = User.Identity.Name;
            this.lblUsuarioPadre.Text = usuario.NombreSolicitante;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.lbAddUser_Click(object, EventArgs)'
        protected void lbAddUser_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.lbAddUser_Click(object, EventArgs)'
        {
            this.mvUsers.SetActiveView(this.ViewNewUser);
            this.txtNewUser.Text = string.Empty;
            this.txtNewEmail.Text = string.Empty;
            this.txtNewFullName.Text = string.Empty;
            this.txtCedula.Text = string.Empty;
            this.txtNewUser.Focus();

            this.gvUsers.SelectedIndexes.Clear();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.btnNewInsert_Click(object, EventArgs)'
        protected void btnNewInsert_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.btnNewInsert_Click(object, EventArgs)'
        {
            //revisar si es valida la pagina.
            if (this.IsValid)
            {
                //revisar si el usuario existe
                var membershipObj = Membership.FindUsersByName(this.txtNewUser.Text);
                if (membershipObj != null && membershipObj.Count > 0)
                {
                    this.GenerateCustomError("El nombre de usuario seleccionado ya está registrado", "NewUser");
                    return;
                }
                var membershipObjEmail = Membership.FindUsersByEmail(this.txtNewEmail.Text);
                if (membershipObjEmail != null && membershipObjEmail.Count > 0)
                {
                    this.GenerateCustomError("La dirección de correo especificada ya está asignado a otro usuario", "NewUser");
                    return;
                }

                //Revisar si la cedula existe
                if (OficinaVirtualUserProfile.ExisteDocumento(this.txtCedula.Text.RemoverFormato().Trim()))
                {
                    this.GenerateCustomError("El número de cédula ya está registrado con otro usuario", "NewUser");
                }

                //create user
                var user = Membership.CreateUser(this.txtNewUser.Text.Trim().ToLower(), this.txtPassword.Text.Trim(), this.txtNewEmail.Text.Trim().ToLower());

                if (user != null)
                {
                    //se trae el profile
                    var profile = (OficinaVirtualUserProfile)ProfileBase.Create(user.UserName);

                    //se asigna el usuario padre al usuario logeado
                    profile.UsuarioPadre = User.Identity.Name.ToLower();
                    profile.NombreSolicitante = this.txtNewFullName.Text.Trim();
                    txtCedulaEdit.Mask.RemoverFormato();
                    profile.TipoDocumento = this.ddlTipoDocumento.SelectedValue;
                    profile.RNC = this.txtCedula.Text.Trim();
                    profile.DebeCambiarPass = false;
                    profile.Phone = this.txtTelefono.Text.Trim();
                    profile.Extension = this.txtExtension.Text.Trim(); 
                    profile.bFirmaDigital = this.chkFirmaDigita.Checked;
                    //se crea el guid para el email de verificacion
                    var key = Guid.NewGuid();
                    profile.ActivateUserKey = key.ToString();
                    profile.IsActive = true;

                    //actualizando los datos del usuario
                    profile.Save();
                    user.IsApproved = true;
                    Membership.UpdateUser(user);

                    //enviar correo de verificacion
                    SendVerificationEmail(user.UserName.ToLower(), profile.NombreSolicitante, user.Email, key.ToString(), this.txtPassword.Text.Trim());

                    this.Master.ShowMessageError("El usuario ha sido creado satisfactoriamente.");
                    this.gvUsers.DataBind();
                    this.mvUsers.SetActiveView(this.ViewManageUsers);
                    MembershipHelper.LogUserActivity("Nuevo usuario creado por padre/administrador", user.UserName.ToLower());
                }
            }
        }

        private string CreateRandomPassword(int passwordLength)
        {
            const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            var chars = new char[passwordLength];
            var rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        private void SendVerificationEmail(string userName, string nombreSolicitante, string email, string providerUserKey, string password)
        {
            //Armar el correo a enviar
            var parametros = new Dictionary<string, string>();
            parametros.Add("[NombreSolicitante]", nombreSolicitante);
            parametros.Add("[UserName]", userName);
            parametros.Add("[Link]", $"{Helper.UrlPortal}/Account/Login.aspx");
            parametros.Add("[TempPassword]", password);

            MailBot.MailBot.SendMail(email, null, null, Helper.FromEmailCorreoCamara, "NUH", Helper.MailServer, 1, parametros);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.CheckBox1_CheckedChanged(object, EventArgs)'
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.CheckBox1_CheckedChanged(object, EventArgs)'
        {

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.gvUsers_ItemCommand(object, GridCommandEventArgs)'
        protected void gvUsers_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.gvUsers_ItemCommand(object, GridCommandEventArgs)'
        {
            //codigo para cuando se selecciona un usuario
            if (e.CommandName == "RowClick")
            {
                //buscar el usuario en la base de datos en base al username
                var item = (GridDataItem)e.Item;
                var userToEdit = Membership.GetUser(item["UserName"].Text);

                //set los valores en los textboxes
                this.txtUser.Text = userToEdit.UserName;
                this.txtEmail.Text = userToEdit.Email;

                //traer el profile para el full name
                var profile = (OficinaVirtualUserProfile)ProfileBase.Create(userToEdit.UserName);
                this.txtFullName.Text = profile.NombreSolicitante;

                this.ddlTipoDocumentoUpdate.ClearSelection();
                var tipoDocItem = this.ddlTipoDocumentoUpdate.Items.FindByValue(profile.TipoDocumento);
                if (tipoDocItem != null) tipoDocItem.Selected = true;

                //es compruenba el tiopo de doc. para setiat el control
                CambiarMacarParaEditar(profile.TipoDocumento);
                this.txtCedulaEdit.Text = profile.RNC.RemoverFormato();
                //

                this.txtTelefonoEdit.Text = profile.Phone;
                this.txtExtensionEdit.Text = profile.Extension;
                EsActivo = profile.IsActive;
                //habilitar el view de actualizacion
                this.mvUsers.SetActiveView(this.viewUpdateUser);

                var ctrl = new DataAccess.EF.OficinaVirtual.TransaccionesController();

                var dbWebsite = new DataAccess.EF.OficinaVirtual.CamaraWebsiteEntities();
                var dbComun = new DataAccess.EF.CamaraComun.CamaraComunEntities();
                //var trans = dbWebsite.Transacciones.Where(u => u.UserName == userToEdit.UserName)

                var trans = (from u in dbWebsite.Transacciones
                             where u.UserName == userToEdit.UserName && u.SubTransaccionId == null
                             join r in dbWebsite.Registros on u.RegistroId equals r.RegistroId
                             join s in dbWebsite.Sociedades on r.RegistroId equals s.RegistroId
                             select
                                 new
                                 {
                                     u.CamaraId,
                                     u.NumeroRegistro,
                                     u.ServicioId,
                                     s.NombreSocial,
                                     u.Fecha
                                 }).ToList();
                var servicioIds = trans.Select(t => t.ServicioId).Distinct().ToList();
                var numRegistros = trans.Select(t => t.NumeroRegistro).Distinct().ToList();

                var servicios = (from s in dbComun.Servicio
                                 where servicioIds.Contains(s.ServicioId)
                                 select new { s.DescripcionWeb, s.ServicioId }).ToList();


                var result = from t in trans
                             join s in servicios on t.ServicioId equals s.ServicioId
                             select new
                             {
                                 t.CamaraId,
                                 t.NumeroRegistro,
                                 t.ServicioId,
                                 t.NombreSocial,
                                 t.Fecha,
                                 NombreServicio = s.DescripcionWeb
                             };

                this.gvUserActivities.DataSource = result;
                this.gvUserActivities.DataBind();

            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.btnUpdate_Click(object, EventArgs)'
        protected void btnUpdate_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.btnUpdate_Click(object, EventArgs)'
        {
            //revisar si es valida la pagina.
            if (this.IsValid)
            {

                //buscar usuario a editar
                var user = Membership.GetUser(this.txtUser.Text.Trim());
                var profile = (OficinaVirtualUserProfile)ProfileBase.Create(this.txtUser.Text.Trim());

                var nuevaCedula = this.txtCedulaEdit.Text.Trim().FormatRnc();

                if (OficinaVirtualUserProfile.ExisteDocumento(nuevaCedula, profile.UserName))
                {
                    this.GenerateCustomError("El número de cédula ya está asignado a otro usuario", "UpdateUser");
                    return;
                }

                //setear el valor de activo o inactivo
                profile.IsActive = this.cbSetInactive.Checked;
                if (profile.IsActive != EsActivo && profile.IsActive == true)
                {
                    //se debe volver a verificar.
                    user.IsApproved = false;

                    //se crea el guid para el email de verificacion.
                    var key = System.Guid.NewGuid();
                    profile.ActivateUserKey = key.ToString();
                    //enviar correo de verificacion
                    SendVerificationEmail(user.UserName.ToLower(), profile.NombreSolicitante, user.Email, key.ToString(), user.GetPassword());
                }
                else user.IsApproved = false;

                //seteaer el valor del nombre completo.
                profile.NombreSolicitante = this.txtFullName.Text.Trim();
                profile.RNC = this.txtCedulaEdit.Text.Trim();
                profile.TipoDocumento = ddlTipoDocumentoUpdate.SelectedValue;
                profile.Phone = this.txtTelefonoEdit.Text.Trim();
                profile.Extension = this.txtExtensionEdit.Text.Trim();

                //actualizar usuario y perfil
                Membership.UpdateUser(user);
                profile.Save();

                var activoStr = user.IsApproved ? "Activo" : "Inactivo";

                MembershipHelper.LogUserActivity(string.Format("Usuario actualizado por padre ({0})", activoStr), user.UserName.ToLower());

                this.gvUsers.DataBind();
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.cvUsername_ServerValidate(object, ServerValidateEventArgs)'
        protected void cvUsername_ServerValidate(object source, ServerValidateEventArgs args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.cvUsername_ServerValidate(object, ServerValidateEventArgs)'
        {
            var usuariosController = new UsuariosController();
            if (usuariosController.ExisteUsuario(this.txtNewUser.Text.Trim()))
                args.IsValid = false;
            else
                args.IsValid = true;

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.cvEmail_ServerValidate(object, ServerValidateEventArgs)'
        protected void cvEmail_ServerValidate(object source, ServerValidateEventArgs args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.cvEmail_ServerValidate(object, ServerValidateEventArgs)'
        {
            if (MembershipHelper.ExisteCorreo(this.txtNewEmail.Text.Trim()))
                args.IsValid = false;
            else
                args.IsValid = true;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.lbNewUserDesc_Click(object, EventArgs)'
        protected void lbNewUserDesc_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.lbNewUserDesc_Click(object, EventArgs)'
        {

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.btnNewCancel_Click(object, EventArgs)'
        protected void btnNewCancel_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.btnNewCancel_Click(object, EventArgs)'
        {

            this.mvUsers.SetActiveView(this.ViewManageUsers);
            this.txtNewUser.Text = string.Empty;
            this.txtNewEmail.Text = string.Empty;
            this.txtNewFullName.Text = string.Empty;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.btnCancel_Click(object, EventArgs)'
        protected void btnCancel_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.btnCancel_Click(object, EventArgs)'
        {
            this.mvUsers.SetActiveView(this.ViewManageUsers);
            this.txtUser.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtFullName.Text = string.Empty;
            this.cbSetInactive.Checked = true;
            this.gvUsers.SelectedIndexes.Clear();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.RgridHistoricoItemDataBound(object, GridItemEventArgs)'
        protected void RgridHistoricoItemDataBound(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.RgridHistoricoItemDataBound(object, GridItemEventArgs)'
        {

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.lnkActivos_Click(object, EventArgs)'
        protected void lnkActivos_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.lnkActivos_Click(object, EventArgs)'
        {
            this.hfVerActivos.Value = "true";
            this.lnkActivos.Font.Bold = true;
            this.lnkInactivos.Font.Bold = false;
            hidePanels();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.lnkInactivos_Click(object, EventArgs)'
        protected void lnkInactivos_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.lnkInactivos_Click(object, EventArgs)'
        {
            this.hfVerActivos.Value = "false";
            this.lnkActivos.Font.Bold = false;
            this.lnkInactivos.Font.Bold = true;
            hidePanels();
        }

        private void hidePanels()
        {
            this.mvUsers.SetActiveView(ViewManageUsers);
        }


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.ddlTipoDocumentoUpdate_SelectedIndexChanged(object, EventArgs)'
        protected void ddlTipoDocumentoUpdate_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.ddlTipoDocumentoUpdate_SelectedIndexChanged(object, EventArgs)'
        {
            CambiarMacarParaEditar(ddlTipoDocumentoUpdate.SelectedValue);
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.CambiarMacarParaEditar(string)'
        public void CambiarMacarParaEditar(string tipo)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.CambiarMacarParaEditar(string)'
        {
            if (tipo == "P")
            {
                txtCedulaEdit.MaxLength = 15;
                txtCedulaEdit.Mask = "aaaaaaaaaaaaaaa";
                txtCedulaEdit.Text = String.Empty;
            }
            else
            {
                txtCedulaEdit.MaxLength = 11;
                txtCedulaEdit.Mask = "###-#######-#";
                txtCedulaEdit.Text = String.Empty;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.ddlTipoDocumento_SelectedIndexChanged(object, EventArgs)'
        protected void ddlTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAdmin.ddlTipoDocumento_SelectedIndexChanged(object, EventArgs)'
        {
            if (ddlTipoDocumento.SelectedValue == "C")
            {
                txtCedula.MaxLength = 11;
                txtCedula.Text = String.Empty;
                txtCedula.CssClass = "tb cedula tipsyBox";
            }
            else if (ddlTipoDocumento.SelectedValue == "P")
            {
                txtCedula.MaxLength = 15;
                txtCedula.Text = String.Empty;
                txtCedula.CssClass = "tb tipsyBox";
            }
            else
            {
                txtCedula.MaxLength = 11;
            }
        }
    }
}