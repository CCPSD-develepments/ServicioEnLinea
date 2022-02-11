using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace CamaraComercio.Website.Empresas
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EmpresasPorGestores'
    public partial class EmpresasPorGestores : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EmpresasPorGestores'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EmpresasPorGestores.Profile'
        protected OficinaVirtualUserProfile Profile;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EmpresasPorGestores.Profile'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EmpresasPorGestores.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EmpresasPorGestores.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;

            FillData();
            lblNombreGestor.InnerText = Profile.NombreSolicitante;
        }

        private void FillData()
        {
            Profile = OficinaVirtualUserProfile.GetUserProfile(Request.Params["UserName"]);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EmpresasPorGestores.btnSave_Click(object, EventArgs)'
        protected void btnSave_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EmpresasPorGestores.btnSave_Click(object, EventArgs)'
        {
            var userName = Request.Params["UserName"];
            foreach (GridDataItem item in rgridEmp.MasterTableView.Items)
            {
                TableCell registroCell = item["RegistroId"];
                TableCell camaraCell = item["CamaraID"];
                TableCell checkEmpresaCell = item["CheckEmpresa"];
                TableCell TipoSociedadIdCell = item["TipoSociedadId"];
                int tipoSociedad;
                int.TryParse(TipoSociedadIdCell.Text, out tipoSociedad);

                int.TryParse(registroCell.Text, out var noRegistro);
                var camaraId = camaraCell.Text;
                CheckBox checkBox = (CheckBox)checkEmpresaCell.FindControl("checkEmpresa");

                using (CamaraWebsiteEntities dbContext = new CamaraWebsiteEntities())
                {
                    var old = dbContext.EmpresasPorUsuario.FirstOrDefault(d => d.Usuario == userName && d.Estado == (short)EmpresaPorUsuarioEstado.Activo && d.CamaraID == camaraId && d.NoRegistro == noRegistro);

                    if (!checkBox.Checked && old != null) dbContext.EmpresasPorUsuario.DeleteObject(old);
                    else if (checkBox.Checked && old != null) old.FechaUltModificacion = DateTime.Now;
                    else if (checkBox.Checked && old == null)
                    {
                        dbContext.EmpresasPorUsuario.AddObject(new EmpresasPorUsuario
                        {
                            CamaraID = camaraId,
                            NoRegistro = noRegistro,
                            Estado = (short)EmpresaPorUsuarioEstado.Activo,
                            FechaCreacion = DateTime.Now,
                            FechaSolicitud = DateTime.Now,
                            FechaUltModificacion = DateTime.Now,
                            Usuario = userName.ToLower(),
                            EsPersona = tipoSociedad == 7? true: false
                        });
                    }

                    dbContext.SaveChanges();
                }
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EmpresasPorGestores.rgridEmp_ItemDataBound(object, GridItemEventArgs)'
        protected void rgridEmp_ItemDataBound(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EmpresasPorGestores.rgridEmp_ItemDataBound(object, GridItemEventArgs)'
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                TableCell registroCell = item["RegistroId"];
                TableCell camaraCell = item["CamaraID"];
                TableCell checkEmpresaCell = item["CheckEmpresa"];
                var imgStatus = (Image)item.FindControl("EstadoImg");
                var lblTipoSociedad = (Label)item.FindControl("lblTipoEntidad");
                var tipoSociedadId = ((System.Data.DataRowView)(item.DataItem)).Row["TipoSociedadId"].ToString();
                int tipoSociedad;
                int.TryParse(tipoSociedadId, out tipoSociedad);

                var Estado = ((System.Data.DataRowView)(item.DataItem)).Row["Estado"].ToString();
                var EstadoId = ((System.Data.DataRowView)(item.DataItem)).Row["EstadoId"].ToString();
                int estadoId;
                int.TryParse(EstadoId, out estadoId);

                var repTipoSociedad = new DataAccess.EF.Repository<TipoSociedad, CamaraComunEntities>(new CamaraComunEntities());
                var tipoSociedadEtiqueta = repTipoSociedad.SelectByKey(TipoSociedad.PropColumns.TipoSociedadId, tipoSociedad);
                if (tipoSociedadEtiqueta != null)
                {
                    lblTipoSociedad.Text = tipoSociedadEtiqueta.Etiqueta.ToString();
                }

                if (tipoSociedad != 7)
                {
                    switch (estadoId)
                    {
                        case 1:
                            imgStatus.ImageUrl = "/res/img/icons/bullet_green.png";
                            break;
                        case 2:
                            imgStatus.ImageUrl = "/res/img/icons/bullet_red.png";
                            break;
                        case 3:
                            imgStatus.ImageUrl = "/res/img/icons/bullet_black.png";
                            break;
                        case 4:
                            imgStatus.ImageUrl = "/res/img/icons/bullet_black.png";
                            break;
                        case 5:
                            imgStatus.ImageUrl = "/res/img/icons/bullet_black.png";
                            break;
                    }
                    imgStatus.ToolTip = Estado;
                }


                int.TryParse(registroCell.Text, out var noRegistro);
                var camaraId = camaraCell.Text;
                CheckBox checkBox = (CheckBox)checkEmpresaCell.FindControl("checkEmpresa");

                using (CamaraWebsiteEntities dbContext = new CamaraWebsiteEntities())
                {
                    var userName = Request.Params["UserName"];
                    var isChecked = dbContext.EmpresasPorUsuario.Any(d => d.Usuario == userName && d.Estado == (short)EmpresaPorUsuarioEstado.Activo && d.CamaraID == camaraId && d.NoRegistro == noRegistro);
                    checkBox.Checked = isChecked;
                }
            }
        }
    }
}