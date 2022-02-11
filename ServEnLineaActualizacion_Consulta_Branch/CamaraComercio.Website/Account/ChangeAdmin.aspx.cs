using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace CamaraComercio.Website.Account
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ChangeAdmin'
    public partial class ChangeAdmin : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ChangeAdmin'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ChangeAdmin.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ChangeAdmin.Page_Load(object, EventArgs)'
        {
            this.odsUsers.SelectParameters["usuarioPadre"].DefaultValue = User.Identity.Name;

            if (IsPostBack) return;

            //Se busca la informacion del usuario. Si la propiedad "UsuarioPadre" no está vacía quiere decir que el usuario no tiene permisos para entrar a esta seccion
            var usuario = (OficinaVirtualUserProfile)ProfileBase.Create(User.Identity.Name);
            if (!usuario.IsGestorAdmin())
                throw new HttpException(403, "Acceso Denegado/Prohibido");
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ChangeAdmin.gvUsers_ItemCommand(object, GridCommandEventArgs)'
        protected void gvUsers_ItemCommand(object source, GridCommandEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ChangeAdmin.gvUsers_ItemCommand(object, GridCommandEventArgs)'
        {
            var selectedUserName = e.Item.Cells[4].Text;
            if (String.IsNullOrEmpty(selectedUserName))
            {
                Master.ShowMessageError("Error al intentar seleccionar el usuario");
                return;
            }

            var currentAdmin = OficinaVirtualUserProfile.GetUserProfile(User.Identity.Name);
            var newAdmin = OficinaVirtualUserProfile.GetUserProfile(selectedUserName);

            if (currentAdmin == null || newAdmin == null)
            {
                Master.ShowMessageError("Error al intentar seleccionar el usuario");
                return;
            }

            var rep = new DataAccess.EF.Membership.UsuariosController();
            var usuariosHijo = rep.FetchByUsuarioPadre(User.Identity.Name, "1");
            foreach (var hijo in usuariosHijo)
            {
                var hijoProfile = OficinaVirtualUserProfile.GetUserProfile(hijo.UserName);
                if (hijoProfile != null)
                {
                    if (hijoProfile.UserName == newAdmin.UserName)
                        hijoProfile.UsuarioPadre = null;
                    else
                        hijoProfile.UsuarioPadre = newAdmin.UserName.ToLower();
                    
                    hijoProfile.Save();
                }
            }

            currentAdmin.UsuarioPadre = newAdmin.UserName.ToLower();
            currentAdmin.Save();

            newAdmin.UsuarioPadre = null;
            newAdmin.ContratoFirmado = false;
            newAdmin.Save();

            this.mv.SetActiveView(vConfirm);
        }
    }
}