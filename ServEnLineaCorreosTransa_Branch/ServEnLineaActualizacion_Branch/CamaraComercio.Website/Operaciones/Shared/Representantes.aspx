<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Representantes.aspx.cs"
    Inherits="CamaraComercio.Website.Operaciones.Shared.Representantes" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Form CSS -->
    <link href="/res/css/interface.css" rel="stylesheet" type="text/css" />
    <link href="/res/css/Grid.Ccpsd.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            background-color: White;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="smManager" runat="server">
        </asp:ScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline">
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="pnlAjaxLoading" runat="server" Transparency="00"
            BackgroundPosition="Center" IsSticky="true" Style="position: relative; margin-left: 40%"
            Width="20%">
            <div style="text-align: center; background: white; border: 1px solid #eeeeee">
                <p>
                    &nbsp;</p>
                <p>
                    Cargando los datos...</p>
                <img src="/res/img/icons/Progress.gif" alt="Progress"/>
                <p>
                    &nbsp;</p>
            </div>
        </telerik:RadAjaxLoadingPanel>
        <h1>
            Representantes</h1>
        <telerik:RadGrid ID="rgAdmin" runat="server" DataSourceID="odsRepresentantes" GridLines="None"
            OnInsertCommand="rgAdmin_InsertCommand" OnUpdateCommand="rgAdmin_UpdateCommand"
            CssClass="Ccpsd" EnableEmbeddedSkins="False" Skin="Ccpsd" 
            onitemcommand="rgAdmin_ItemCommand" onitemdatabound="rgAdmin_ItemDataBound">
            <HeaderContextMenu EnableEmbeddedSkins="False" runat="server">
            </HeaderContextMenu>
            <MasterTableView AutoGenerateColumns="False" CellSpacing="-1" CommandItemDisplay="Top"
                CommandItemSettings-AddNewRecordText="Agregar Nuevo Registro" CommandItemSettings-RefreshText="Refrescar"
                DataKeyNames="PersonaId" DataSourceID="odsRepresentantes">
                <RowIndicatorColumn>
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
                <ExpandCollapseColumn>
                    <HeaderStyle Width="20px" />
                </ExpandCollapseColumn>
                <NoRecordsTemplate>
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; border: 1px solid black">
                        <tr>
                            <td align="center">
                                No Hay representantes agregados.
                            </td>
                        </tr>
                    </table>
                </NoRecordsTemplate>
                <CommandItemSettings AddNewRecordText="Agregar Representante" RefreshText="Refrescar" />
                <Columns>
                    <telerik:GridEditCommandColumn CancelImageUrl="Cancel.gif" EditImageUrl="~/res/img/icons/Edit.gif"
                        ButtonType="ImageButton" EditText="Editar" InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif">
                        <ItemStyle Width="16px" />
                    </telerik:GridEditCommandColumn>
                    <telerik:GridTemplateColumn HeaderText="Nombre" UniqueName="TemplateColumn1">
                        <ItemTemplate>
                            <asp:Label ID="lblNombreAdmin" runat="server" Text='<%# Eval("PrimerNombre") + " " + Eval("SegundoNombre") + " "+ Eval("PrimerApellido") + " " + Eval("SegundoApellido") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="Documento" HeaderText="Cédula/Pasaporte" UniqueName="column1">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CausesValidation="false" CommandName="Select" 
                                Text="Seleccionar" ID="lnkSelect"></asp:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <EditFormSettings EditColumn-CancelText="Cancelar" EditColumn-EditText="Editar" EditColumn-InsertText="Insertar"
                    EditColumn-UpdateText="Actualizar" EditFormType="WebUserControl" UserControlName="/UserControls/RepresentanteDetails.ascx">
                    <EditColumn CancelImageUrl="Cancel.gif" CancelText="Cancelar" EditImageUrl="~/res/img/icons/Edit.gif"
                        EditText="Editar" InsertImageUrl="Update.gif" InsertText="Insertar" UpdateImageUrl="Update.gif"
                        UpdateText="Actualizar">
                    </EditColumn>
                </EditFormSettings>
            </MasterTableView>
            <FilterMenu EnableEmbeddedSkins="False">
            </FilterMenu>
            <StatusBarSettings LoadingText="Cargando..." />
        </telerik:RadGrid>
        <asp:ObjectDataSource ID="odsRepresentantes" runat="server" />
    
        <div class="clear" />
        <p>
            &nbsp;
        </p>
        <a href="#" class="btn" style="float:right; margin-right:20px" onclick="javascript:parent.$.fancybox.close();">Cerrar ventana</a>
        <div class="clear" />
    </div>
    </form>
</body>
</html>
