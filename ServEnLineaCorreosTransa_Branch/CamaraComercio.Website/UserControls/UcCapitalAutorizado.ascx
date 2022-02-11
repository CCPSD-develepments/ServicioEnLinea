<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcCapitalAutorizado.ascx.cs"
    Inherits="CamaraComercio.Website.UserControls.UcCapitalAutorizado" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
    <asp:View ID="View1" runat="server">
        <fieldset>
            <legend>Información de la Empresa</legend>
            <ol>
                <li><span>Capital Suscrito y Pagado :</span>
                    <asp:Literal ID="ltCapAutorizado" runat="server"></asp:Literal>
                </li>
                <li>
                    <label for="txtCapAutorizado">
                        Nuevo Capital Suscrito y Pagado :</label>
                    <telerik:RadNumericTextBox ID="txtCapitalSocialNuevo" runat="server" CssClass="tb"
                        Culture="Spanish (Dominican Republic)" EmptyMessage="Capital Social Nuevo" Type="Currency"
                        Skin="" IncrementSettings-InterceptArrowKeys="false" IncrementSettings-InterceptMouseWheel="false">
                    </telerik:RadNumericTextBox>
                    <asp:RequiredFieldValidator SetFocusOnError="true" ID="RequiredFieldValidator7" runat="server"
                        ControlToValidate="txtCapitalSocialNuevo" CssClass="validator" ValidationGroup="3">El capital social es requerido</asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvCapitalSocialNuevo" runat="server" CssClass="validator"
                        Type="Currency" MaximumValue="999999999.99" ValidationGroup="3" ControlToValidate="txtCapitalSocialNuevo">
                El capital social minimo requerido para este tipo de sociedad es <%=String.Format("{0:n}", rvCapitalSocialNuevo.MinimumValue) %>
                    </asp:RangeValidator>
                </li>
                <li>&nbsp; </li>
            </ol>
        </fieldset>
    </asp:View>
</asp:MultiView>