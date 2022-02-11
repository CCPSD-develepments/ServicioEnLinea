using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamaraComercio.Website.Operaciones.Registro;
using Telerik.Web.UI;
using CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website.Operaciones.Shared
{
    ///<summary>
    /// Pagina que administra la creación de representantes. 
    /// Estos son usados para Empresas y Menores de edad
    ///</summary>
    public partial class Representantes : FormularioPage
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Representantes.OnInit(EventArgs)'
        protected override void OnInit(EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Representantes.OnInit(EventArgs)'
        {
            //Data Source Socios
            odsRepresentantes.TypeName = "CamaraComercio.Website.RepresentanteUI";
            odsRepresentantes.SelectMethod = "FindAll";
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Representantes.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Representantes.Page_Load(object, EventArgs)'
        {
        }


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Representantes.rgAdmin_InsertCommand(object, GridCommandEventArgs)'
        protected void rgAdmin_InsertCommand(object source, GridCommandEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Representantes.rgAdmin_InsertCommand(object, GridCommandEventArgs)'
        {
            var userControl = e.Item.FindControl(GridEditFormItem.EditFormUserControlID) as UserControl;
            var socio = RadUtils.GetRepresentanteFromControl(userControl, 0);

            try
            {
                //Se inserta el socio
                RepresentanteUI.Insert(socio);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                ErrorMessage = "No se pudo agregar representante. Intente de nuevo.";
                e.Canceled = true;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Representantes.rgAdmin_UpdateCommand(object, GridCommandEventArgs)'
        protected void rgAdmin_UpdateCommand(object source, GridCommandEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Representantes.rgAdmin_UpdateCommand(object, GridCommandEventArgs)'
        {
            var editedItem = e.Item as GridEditableItem;
            var userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            if (editedItem != null)
            {
                //Se obtiene el ID del socio
                var socioId = Convert.ToInt32(editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["PersonaId"].ToString());

                //Se envia un error en caso de que el ID del socio sea 0
                if (socioId == 0)
                {
                    ErrorMessage = "No se pudo agregar representante. Intente de nuevo.";
                    e.Canceled = true;
                    return;
                }

                //Obtener la Instancia del Socio
                var socio = RadUtils.GetRepresentanteFromControl(userControl, socioId);

                try
                {
                    //Se actualiza el socio
                    RepresentanteUI.Update(socio);
                    //Se refresca el listado de socios y administradores
                    rgAdmin.DataBind();
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    ErrorMessage = "No fue posible insertar el socio. ";
                    e.Canceled = true;
                }
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Representantes.rgAdmin_DeleteCommand(object, GridCommandEventArgs)'
        protected void rgAdmin_DeleteCommand(object source, GridCommandEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Representantes.rgAdmin_DeleteCommand(object, GridCommandEventArgs)'
        {
            //Se obtiene el ID del socio
            int personaId = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["PersonaId"].ToString());
            try
            {
                //Se elimina el socio
                RepresentanteUI.Delete(personaId);

                //NOTA: Se pudiera eliminar del Organo de Administración, pero es posible que el usuario 
                //no sea socio/accionista, pero miembro del organo.
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                ErrorMessage = "No fue posible eliminar el socio.";
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Representantes.rgAdmin_ItemCommand(object, GridCommandEventArgs)'
        protected void rgAdmin_ItemCommand(object source, GridCommandEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Representantes.rgAdmin_ItemCommand(object, GridCommandEventArgs)'
        {
            if (e.CommandName == "Select")
            {
                int personaId = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["PersonaId"].ToString());
                Session["repIdSelect"] = personaId;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Representantes.rgAdmin_ItemDataBound(object, GridItemEventArgs)'
        protected void rgAdmin_ItemDataBound(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Representantes.rgAdmin_ItemDataBound(object, GridItemEventArgs)'
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem
                || e.Item.ItemType == GridItemType.SelectedItem)
            {
                var ctrl = e.Item.FindControl("lnkSelect") as LinkButton;
                if (ctrl != null) ctrl.Attributes.Add("onclick", "javascript:parent.$.fancybox.close();");
            }
        }
    }
}