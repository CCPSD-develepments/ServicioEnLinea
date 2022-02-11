using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Profile;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.DataAccess.EF.Membership;
using Telerik.Web.UI;

namespace CamaraComercio.Website.Account
{
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "AccountSiteMap")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAuth'
    public partial class UsersAuth : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAuth'
    {

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAuth.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAuth.Page_Load(object, EventArgs)'
        {
            if (!IsPostBack)
            {
                var usuario = (OficinaVirtualUserProfile)ProfileBase.Create(User.Identity.Name);
                if (!usuario.IsGestorAdmin())
                    throw new HttpException(403, "Access Denied/Forbidden"); //TODO: nando, Cambiar esto a esconder los controles.
                
                //save usuario padre in hiddend field for object datasource param
                this.hfCurrentUser.Value = usuario.UserName.ToLower();

                this.lblUsuarioPadre.Text = usuario.NombreSolicitante;
                this.lblEmpresa.Text = String.Format(" para la empresa: <strong>{0}</strong> (RNC {1})", usuario.NombreEmpresa, usuario.RNC.FormatRnc());

                //bind dropdownlists
                var dbCamaras = new CamarasController();
                var camaras = dbCamaras.FetchAllActivas();

                //drop down list new Camara
                this.ddlCamara.DataSource = camaras;
                this.ddlCamara.DataTextField = "Nombre";
                this.ddlCamara.DataValueField = "ID";

                

                this.ddlCamara.DataBind();
                this.ddlCamara.Items.Insert(0, new ListItem("Seleccione una opción...", "Seleccione una opción..."));


                //drop down list
                this.ddlCamaraEdit.DataSource = camaras;
                this.ddlCamaraEdit.DataTextField = "Nombre";
                this.ddlCamaraEdit.DataValueField = "ID";                
                this.ddlCamaraEdit.DataBind();
                

                //drop down list no Registro
                var dbWebsite = new EmpresasPorUsuarioController();
                var noRegistros = dbWebsite.FetchAllByUserName(usuario.UserName);

                this.ddlNoRegistro.DataSource = noRegistros;
                this.ddlNoRegistro.DataTextField = "NombreEmpresa";
                this.ddlNoRegistro.DataValueField = "NoRegistro";
                this.ddlNoRegistro.DataBind();
                this.ddlNoRegistro.Items.Insert(0, new ListItem("Seleccione una opción...", "Seleccione una opción..."));

                this.ddlNoRegistroEdit.DataSource = noRegistros;
                this.ddlNoRegistroEdit.DataTextField = "NoRegistro";
                this.ddlNoRegistroEdit.DataValueField = "NoRegistro";
                this.ddlNoRegistroEdit.DataBind();

                

            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAuth.lbNewUserDesc_Click(object, EventArgs)'
        protected void lbNewUserDesc_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAuth.lbNewUserDesc_Click(object, EventArgs)'
        {
            this.txtCedula.Text = string.Empty;
            this.txtNewUser.Text = string.Empty;
            this.mvUsers.SetActiveView(this.mvUsers.Views[1]);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAuth.btnNewInsert_Click(object, EventArgs)'
        protected void btnNewInsert_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAuth.btnNewInsert_Click(object, EventArgs)'
        {
            if (Page.IsValid)
            {
                UsuariosController.UsuarioAutorizadoInsert(this.hfCurrentUser.Value, Convert.ToInt32(this.ddlNoRegistro.SelectedValue), this.ddlCamara.SelectedValue, this.txtCedula.Text.Trim().FormatRnc(), this.txtNewUser.Text.Trim());
                this.Master.ShowMessageError("El usuario ha sido autorizado satisfactoriamente.");
                this.mvUsers.ActiveViewIndex = 0;
                this.gvUsers.DataBind();
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAuth.btnUpdate_Click(object, EventArgs)'
        protected void btnUpdate_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAuth.btnUpdate_Click(object, EventArgs)'
        {
            if (Page.IsValid)
            {
                UsuariosController.UsuarioAutorizadoUpdate(this.hfCurrentUser.Value, Convert.ToInt32(this.ddlNoRegistroEdit.SelectedValue), this.ddlCamaraEdit.SelectedValue, this.txtCedulaEdit.Text.Trim(), this.txtUser.Text.Trim(), this.cbSetInactive.Checked);
                this.Master.ShowMessageError("El usuario ha sido actualizado satisfactoriamente.");
                this.mvUsers.ActiveViewIndex = 0;
                this.gvUsers.DataBind();
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAuth.gvUsers_ItemCommand(object, GridCommandEventArgs)'
        protected void gvUsers_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAuth.gvUsers_ItemCommand(object, GridCommandEventArgs)'
        {
            //codigo para cuando se selecciona un usuario
            if (e.CommandName == "RowClick")
            {
                //buscar el usuario en la base de datos en base al username
                GridDataItem item = (GridDataItem)e.Item;
                //var userToEdit = Membership.GetUser(item["UserName"].Text);


                //set los valores en los textboxes
                this.txtUser.Text = item["Nombre"].Text;
                this.txtCedulaEdit.Text = item["Cedula"].Text;


                var camara = ddlCamaraEdit.Items.FindByValue(item["CamaraID"].Text);
                this.ddlCamaraEdit.SelectedIndex = this.ddlCamaraEdit.Items.IndexOf(camara);

                var noRegistro = ddlNoRegistroEdit.Items.FindByValue(item["NoRegistro"].Text);
                this.ddlNoRegistroEdit.SelectedIndex = this.ddlNoRegistroEdit.Items.IndexOf(noRegistro);

                this.cbSetInactive.Checked = ((CheckBox)item["Activo"].Controls[0]).Checked;


                //habilitar el view de actualizacion
                this.mvUsers.ActiveViewIndex = 2;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAuth.btnNewCancel_Click(object, EventArgs)'
        protected void btnNewCancel_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAuth.btnNewCancel_Click(object, EventArgs)'
        {
            this.txtCedula.Text = string.Empty;
            this.txtNewUser.Text = string.Empty;
            this.mvUsers.ActiveViewIndex = 0;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAuth.btnCancel_Click(object, EventArgs)'
        protected void btnCancel_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAuth.btnCancel_Click(object, EventArgs)'
        {
            this.txtCedulaEdit.Text = string.Empty;
            this.txtUser.Text = string.Empty;
            this.mvUsers.ActiveViewIndex = 0;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAuth.cvKey_ServerValidate(object, ServerValidateEventArgs)'
        protected void cvKey_ServerValidate(object source, ServerValidateEventArgs args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAuth.cvKey_ServerValidate(object, ServerValidateEventArgs)'
        {
            //revisar si existe el key en la db.
            var userExists = UsuariosController.ExisteUsuarioAutorizado(this.hfCurrentUser.Value.ToString(), Convert.ToInt32(this.ddlNoRegistro.SelectedValue), this.txtCedula.Text.Trim(), this.ddlCamara.SelectedValue);

            if (userExists)
                args.IsValid = false;

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UsersAuth.gvUsers_ItemDataBound(object, GridItemEventArgs)'
        protected void gvUsers_ItemDataBound(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UsersAuth.gvUsers_ItemDataBound(object, GridItemEventArgs)'
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

     
    }
}