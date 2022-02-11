using System;
using Telerik.Web.UI;

namespace CamaraComercio.Website.Empresas
{
    ///<summary>
    /// Página que muestra el detalle de una factura
    ///</summary>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class VerFacturas : SecurePage
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerFacturas.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerFacturas.Page_Load(object, EventArgs)'
        {

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerFacturas.rgridHistorico_OnItemCommand(object, GridCommandEventArgs)'
        protected void rgridHistorico_OnItemCommand(object sender, GridCommandEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerFacturas.rgridHistorico_OnItemCommand(object, GridCommandEventArgs)'
        {
            if (e.CommandName == "Pagar")
            {
                var key = rgridHistorico.MasterTableView.DataKeyValues[e.Item.ItemIndex];

                if (!DefaultQueryString.Contains("FacturaSrmId="))
                    DefaultQueryString = String.Format("FacturaSrmId={0}&CamaraId={1}", key["FacturaId"], key["CamaraID"]);

                Response.Redirect("~/TarjetaCredito/PagosTarjeta.aspx" + DefaultQueryString);
            }

        }
    }
}