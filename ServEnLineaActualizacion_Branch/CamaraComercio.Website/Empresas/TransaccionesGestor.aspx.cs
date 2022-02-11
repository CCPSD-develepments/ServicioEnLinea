using System;

namespace CamaraComercio.Website.Empresas
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransaccionesGestor'
    public partial class TransaccionesGestor : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransaccionesGestor'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransaccionesGestor.UserName'
        protected string UserName;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransaccionesGestor.UserName'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransaccionesGestor.Profile'
        protected OficinaVirtualUserProfile Profile;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransaccionesGestor.Profile'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransaccionesGestor.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransaccionesGestor.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;

            FillData();
            lblNombreGestor.InnerText = Profile.NombreSolicitante;
        }

        private void FillData()
        {
            UserName = Request.Params["UserName"];
            Profile = OficinaVirtualUserProfile.GetUserProfile(UserName.ToLower());
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransaccionesGestor.odsEmpresasNuevas_Selecting(object, ObjectDataSourceSelectingEventArgs)'
        protected void odsEmpresasNuevas_Selecting(object sender, System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransaccionesGestor.odsEmpresasNuevas_Selecting(object, ObjectDataSourceSelectingEventArgs)'
        {
            e.InputParameters["username"] = UserName.ToLower();
        }
    }
}