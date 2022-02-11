using System;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF.Membership;
using CamaraComercio.Website;
using Telerik.Web.UI;

public partial class admin_controls_edit_user_modal : System.Web.UI.UserControl
{
    #region Global Variables for membership user

    // declare global variables
    string username;
    MembershipUser user;

    #endregion

    #region On Page_Prerender

    private void Page_PreRender(object sender, EventArgs e)
    {
        // Load the User Roles into checkboxes.
        UserRoles.DataSource = Roles.GetAllRoles();
        UserRoles.DataBind();

        // if detailsview is not in edit mode, disable checkboxes
        if (UserInfo.CurrentMode != DetailsViewMode.Edit)
        {
            foreach (ListItem checkbox in UserRoles.Items)
            {
                checkbox.Enabled = false;
            }
        }

        // Bind checkboxes to the User's own set of roles.
        string[] userRoles = Roles.GetRolesForUser(username);
        foreach (string role in userRoles)
        {
            ListItem checkbox = UserRoles.Items.FindByValue(role);
            checkbox.Selected = true;
        }
    }

    #endregion

    #region On Page_Load

    private void Page_Load(object sender, EventArgs e)
    {
        // check if username exists in the query string
        username = Request.QueryString["username"];
        if (username == null || username == "")
        {
            Response.Redirect("users-a-z.aspx");
        }

        // get membership user account based on username sent in query string
        user = Membership.GetUser(username);
        UserUpdateMessage.Text = "";
        this.hfCurrentUser.Value = username;

        // get selected user's password
        //try
        //{
            //if (user.IsLockedOut == true)
            //{
            //    lblCurrentPassword.Text = "To see current Password, Unlock the User first.";
            //}
            //else
            //{
            //    //string password = Membership.Providers["dbSqlMemberShipProviderAdmin"].GetPassword(username, null);
            //    //lblCurrentPassword.Text = password;
            //}
        //}
        //catch (Exception ex)
        //{
        //    UserUpdateMessage.Text = "OOps! This user has been deleted already! " + "Error: " + ex.Message;
        //}

        // Get User's Profile
        if (!Page.IsPostBack)
        {

            //buscar usuario padre.
            var usuarioPadre = UsuariosController.GetInfoUsuarioPadreByUserName(username);
            if (usuarioPadre != null)
            {
                ViewState["usuarioPadre"] = usuarioPadre.UserName;


                //setear valores de usuario principal
                this.lblUsuarioPadre.Text = string.Format("Usuario Principal: {0} - {1}", usuarioPadre.NombreSolicitante, usuarioPadre.UserName);

                //setear valores de empresa
                this.lblEmpresa.Text = string.Format("Nombre Empresa: {0}", usuarioPadre.NombreEmpresa);



                //bind subusuarios dropdown
                var db = new UsuariosController();
                var subUsers = db.FetchByUsuarioPadre(usuarioPadre.UserName);

                this.ddlUsuarios.DataSource = subUsers;
                this.ddlUsuarios.DataTextField = "UserName";
                this.ddlUsuarios.DataValueField = "UserName";
                this.ddlUsuarios.DataBind();

                //reviar si es un sub usuario.
                if (username == usuarioPadre.UserName)
                {
                    //quitar el tab de informacion de la empresa.
                    this.TabPanel3.Visible = true;
                }

                //buscar info de usuario seleccionado.
                var usuarioSeleccionado = UsuariosController.GetInfoUsuarioByUserName(username);
                this.txtFullName.Text = usuarioSeleccionado.NombreSolicitante;

            }
            
        }
    }

    #endregion

    #region Update Profile Procedure

    public void SaveProfile()
    {
        //// get the selected user's profile
        //ProfileCommon profile = Profile;
        //if (username.Length > 0)
        //    profile = Profile.GetProfile(username);

        //// Personal Info
        //profile.Personal.FirstName = txtFirstName.Text;
        //profile.Personal.LastName = txtLastName.Text;
        //profile.Personal.Gender = ddlGenders.SelectedValue;
        //if (txtBirthDate.Text.Trim().Length > 0)
        //    profile.Personal.BirthDate = DateTime.Parse(txtBirthDate.Text);
        //profile.Personal.Occupation = ddlOccupations.SelectedValue;
        //profile.Personal.Website = txtWebsite.Text;

        //// Address Info
        //profile.Address.Country = ddlCountries.SelectedValue;
        //profile.Address.Address = txtAddress.Text;
        //profile.Address.AptNumber = txtAptNumber.Text;
        //profile.Address.City = txtCity.Text;
        //profile.Address.State = ddlStates1.Text;
        //profile.Address.PostalCode = txtPostalCode.Text;

        //// Contact Info
        //profile.Contacts.DayPhone = txtDayTimePhone.Text;
        //profile.Contacts.DayPhoneExt = txtDayTimePhoneExt.Text;
        //profile.Contacts.EveningPhone = txtEveningPhone.Text;
        //profile.Contacts.EveningPhoneExt = txtEveningPhoneExt.Text;
        //profile.Contacts.CellPhone = txtCellPhone.Text;
        //profile.Contacts.Fax = txtHomeFax.Text;

        //// Company Info
        //profile.Company.Company = txbCompanyName.Text;
        //profile.Company.Address = txbCompanyAddress.Text;
        //profile.Company.City = txbCompanyCity.Text;
        //profile.Company.State = ddlStates2.SelectedValue;
        //profile.Company.PostalCode = txbCompanyZip.Text;
        //profile.Company.Phone = txbCompanyPhone.Text;
        //profile.Company.Fax = txbCompanyFax.Text;
        //profile.Company.Website = txbCompanyWebsite.Text;

        //// Subscriptions
        //profile.Preferences.Newsletter = ddlNewsletter.SelectedValue;

        //// this is what we will call from the button click to save the user's profile
        //profile.Save();
    }

    #endregion

    #region Update Profile Button Click

    protected void btnUpdateProfile_Click(object sender, EventArgs e)
    {
        //SaveProfile();
        //lblProfileMessage.Text = "Profile saved successfully!";
    }

    #endregion

    #region Delete Profile Button Click

    protected void btnDeleteProfile_Click(object sender, EventArgs e)
    {
        //ProfileManager.DeleteProfile(username);
        //lblProfileMessage.Text = "Profile deleted successfully!";

        //// refresh the page to clear post back data from form fields
        //Response.Redirect("edit_user_modal_success.aspx");
    }

    #endregion

    #region Update Membership User Info

    protected void UserInfo_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        // Need to handle the update manually because MembershipUser does not have a
        // parameterless constructor  

        user.Email = (string)e.NewValues[0];
        user.Comment = (string)e.NewValues[1];
        user.IsApproved = (bool)e.NewValues[2];

        try
        {
            // Update user info:
            Membership.UpdateUser(user);

            // Update user roles:
            UpdateUserRoles();

            UserUpdateMessage.Text = "Update Successful.";

            // make cancel button available
            e.Cancel = true;

            // make detailsview read only
            UserInfo.ChangeMode(DetailsViewMode.ReadOnly);
        }
        catch (Exception ex)
        {
            // if there is a problem
            UserUpdateMessage.Text = "Update Failed: " + ex.Message;

            e.Cancel = true;
            UserInfo.ChangeMode(DetailsViewMode.ReadOnly);
        }
    }

    #endregion

    #region Update User Roles

    private void UpdateUserRoles()
    {
        // add or remove user from role based on selection
        foreach (ListItem rolebox in UserRoles.Items)
        {
            if (rolebox.Selected)
            {
                if (!Roles.IsUserInRole(username, rolebox.Text))
                {
                    Roles.AddUserToRole(username, rolebox.Text);
                }
            }
            else
            {
                if (Roles.IsUserInRole(username, rolebox.Text))
                {
                    Roles.RemoveUserFromRole(username, rolebox.Text);
                }
            }
        }
    }

    #endregion

    #region Delete User

    public void DeleteUser(object sender, EventArgs e)
    {
        // Membership.DeleteUser(username, false);
        ProfileManager.DeleteProfile(username);
        Membership.DeleteUser(username, true);
        Response.Redirect("edit_user_modal_success.aspx");
    }

    #endregion

    #region Unlock User

    public void UnlockUser(object sender, EventArgs e)
    {

        // Unlock the user.
        user.UnlockUser();

        // DataBind the DetailsView to reflect changes.
        UserInfo.DataBind();
    }

    #endregion

    #region Add New Role

    public void AddRole(object sender, EventArgs e)
    {
        // create new roles
        try
        {
            Roles.CreateRole(NewRole.Text);
            ConfirmationMessage.InnerText = "The new role was added.";
        }
        catch (Exception ex)
        {
            ConfirmationMessage.InnerText = ex.Message;
        }
    }

    #endregion

    #region Change Password Button Click

    public void ChangePassword_OnClick(object sender, EventArgs args)
    {
        // check for user name in query string
        username = Request.QueryString["username"];
        if (username == null || username == "")
        {
            Response.Redirect("users.aspx");
        }

        // if user name exists in query string, get user from database
        MembershipUser u = Membership.GetUser(username);

        // try to update user password
        try
        {
            if (u.ChangePassword(u.GetPassword(), PasswordTextbox.Text))
            {
                this.lblPassword.Text = "La contraseña ha sido cambiada satisfactoriamente."; 
            }
            else
            {
                this.lblPassword.Text = "La contraseña ha sido cambiada satisfactoriamente."; 
            }
        }
        catch (Exception e)
        {
            Msg.Text = "Ha ocurrido un error: " + Server.HtmlEncode(e.Message) + ". Intente nuevamente.";
        }
    }

    #endregion

    #region Change Password Question and Answer

    protected void ChangePasswordQuestion_OnClick(object sender, EventArgs e)
    {
        try
        {
            // assign user name in query string to variable
            username = Request.QueryString["username"];

            // check if user exists in database
            MembershipUser mu = Membership.GetUser(username);

            // change password question and answer
            Boolean result = mu.ChangePasswordQuestionAndAnswer(qaCurrentPassword.Text, qaNewQuestion.Text, qaNewAnswer.Text);

            if (result)
            {
                Msg.Text = "Password Question and Answer changed.";
            }
            else
            {
                Msg.Text = "Password Question and Answer change failed.";
            }
        }
        catch (Exception ex)
        {
            Msg.Text = "Change failed. Please re-enter your values and try again. " + ex.Message; ;
        }
    }

    #endregion

    protected void lnkCambiarUsuarioPadre_Click(object sender, EventArgs e)
    {
        this.pnlCambiarUsuarioPadre.Visible = true;
    }

    protected void lnkCambiar_Click(object sender, EventArgs e)
    {
       
    }

    protected void lnkCambiar_Click1(object sender, EventArgs e)
    {

    }

    protected void lnkCambiar_Click2(object sender, EventArgs e)
    {
        //se desactiva el usuario y se capturan los hijos a cambiar de padre.
        var subUsuarios = UsuariosController.DesactivarUsuarioPadre(ViewState["usuarioPadre"].ToString());

        var sUsuarios = "<ul>";

        //se itera sobre los subUsuarios cambiando sus usarios padre
        foreach (var user in subUsuarios)
        {
            var profile = (OficinaVirtualUserProfile)ProfileBase.Create(user.UserName);
            profile.UsuarioPadre = ddlUsuarios.SelectedValue;
            profile.Save();
            sUsuarios += String.Format("<li>{0} - {1}</li>", user.NombreSolicitante, user.UserName);
        }

        sUsuarios += "</ul>";

        //crear resumen de importacion,
        litResumenCambio.Text = String.Format("<span>El usuario principal ha sido cambiado a {0}</span><br /> <span>Usuarios Afectados:</span><br />{1}",ddlUsuarios.SelectedValue,  subUsuarios); 
    }

    protected void btnUpdateProfile_Click1(object sender, EventArgs e)
    {
        var profile = (OficinaVirtualUserProfile)ProfileBase.Create(user.UserName);
        profile.NombreSolicitante = this.txtFullName.Text.Trim();
        profile.Save();

        this.lblProfileMessage.Text = "El perfil se ha actulizado con éxito.";
    }

    protected void gvActivities_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridPagerItem)
        {
            GridPagerItem pager = (GridPagerItem)e.Item;
            Label lbl = (Label)pager.FindControl("ChangePageSizeLabel");
            lbl.Visible = false;

            RadComboBox combo = (RadComboBox)pager.FindControl("PageSizeComboBox");
            combo.Visible = false;
        } 
    }


    //protected void gvUsers_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
    //{
    //    //codigo para cuando se selecciona un usuario
    //    if (e.CommandName == "RowClick")
    //    {
    //        //buscar el usuario en la base de datos en base al username
    //        GridDataItem item = (GridDataItem)e.Item;
    //        var userToEdit = Membership.GetUser(item["UserName"].Text);

    //        //set los valores en los textboxes
    //        this.txtUser.Text = userToEdit.UserName;
    //        this.txtEmail.Text = userToEdit.Email;


    //        //traer el profile para el full name
    //        var profile = (OficinaVirtualUserProfile)ProfileBase.Create(userToEdit.UserName);
    //        this.txtFullName.Text = profile.NombreSolicitante;
    //        //this.cbSetInactive.Checked = !profile.IsActive;

    //        //habilitar el view de actualizacion
    //        this.mvUsers.SetActiveView(this.viewUpdateUser);
    //    }
    //}

}
