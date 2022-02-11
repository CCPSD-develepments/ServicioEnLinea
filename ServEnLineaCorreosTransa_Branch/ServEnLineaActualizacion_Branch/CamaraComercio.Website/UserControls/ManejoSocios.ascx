<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManejoSocios.ascx.cs"
    Inherits="CamaraComercio.Website.UserControls.ManejoSocios" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<link href="/res/css/Grid.Ccpsd.css" rel="stylesheet" type="text/css" />
<telerik:RadAjaxPanel ID="rapUpdate" runat="server" LoadingPanelID="pnlAjaxLoading"
    CssClass="panelSociosUpdate" OnPreRender="rapUpdate_PreRender">
    
    <telerik:RadGrid ID="rgSocios" runat="server" DataSourceID="odsSocios" GridLines="None"
        OnInsertCommand="RadGrid1_InsertCommand" OnDeleteCommand="RadGrid1_DeleteCommand"
        OnUpdateCommand="RadGrid1_UpdateCommand" 
        ondatabound="rgSocios_DataBound" 
        onitemdatabound="rgSocios_ItemDataBound" 
        oneditcommand="rgSocios_EditCommand" onitemcommand="rgSocios_ItemCommand" 
        onitemevent="rgSocios_ItemEvent" Skin="NoboxGrid" EnableEmbeddedSkins="False">
        <HeaderContextMenu EnableEmbeddedSkins="True">
        </HeaderContextMenu>
        <ValidationSettings ValidationGroup="socio" />
        <MasterTableView AutoGenerateColumns="False" CellSpacing="-1" CommandItemDisplay="Top"
            ClientIDMode="AutoID" CommandItemSettings-AddNewRecordText="Ingresar Propietario/Socio/Accionista"
            CommandItemSettings-RefreshText="Refrescar" DataKeyNames="Id" DataSourceID="odsSocios">
            <RowIndicatorColumn>
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn>
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <CommandItemSettings AddNewRecordText="Ingresar Propietario/Socio/Accionista" RefreshText="Refrescar" />
            <NoRecordsTemplate>
            </NoRecordsTemplate>
            <Columns>
                <telerik:GridEditCommandColumn CancelImageUrl="Cancel.gif" EditImageUrl="~/res/img/icons/Edit.gif"
                    ButtonType="ImageButton" EditText="Editar" InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif">
                    <ItemStyle Width="16px" />
                </telerik:GridEditCommandColumn>
                <telerik:GridButtonColumn CommandName="Delete" ConfirmText="Esta seguro que desea eliminar este socio?"
                    ConfirmTitle="Remover Socio" ButtonType="ImageButton" ImageUrl="~/res/img/icons/del.gif"
                    Text="Eliminar" UniqueName="column2">
                    <ItemStyle Width="16px" />
                </telerik:GridButtonColumn>
                <telerik:GridTemplateColumn HeaderText="Nombre" UniqueName="TemplateColumn1">
                    <ItemTemplate>
                        <asp:Label ID="lblNombre" runat="server" 
                        Text='<%# Eval("PersonaPrimerNombre") + " "
                        + Eval("PersonaSegundoNombre") + " " 
                        + Eval("PersonaPrimerApellido") + " " 
                        + Eval("PersonaSegundoApellido") %>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Dirección" UniqueName="TemplateColumn">
                    <ItemTemplate>
                        <asp:Label ID="lblDireccion" runat="server" 
                        Text='<%# 
                                Eval("DireccionCalle") + " #" + Eval("DireccionNumero") + " "+ Eval("DireccionApartadoPostal") 
                                + ", " + Eval("DireccionNombreSector") + ", " + Eval("DireccionNombreCiudad")%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="Documento" 
                    HeaderText="Cédula/Pasaporte/RM" UniqueName="Documento">
                    <ItemTemplate>
                        <asp:Label ID="DocumentoLabel" runat="server" Text='<%# Eval("Documento") %>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="CantidadAcciones" HeaderText="Cuotas/Acciones" UniqueName="CantidadAcciones">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn UniqueName="Cargos" HeaderText="Cargos">
                    <ItemTemplate>
                        <asp:Label runat="server" id="lblCargosSocio"></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            <EditFormSettings EditColumn-CancelText="Cancelar" EditColumn-EditText="Editar" EditColumn-InsertText="Insertar"
                EditColumn-UpdateText="Actualizar" EditFormType="WebUserControl" UserControlName="/UserControls/SocioDetails.ascx">
                <EditColumn CancelImageUrl="Cancel.gif" CancelText="Cancelar" EditImageUrl="~/res/img/icons/Edit.gif"
                    EditText="Editar" InsertImageUrl="Update.gif" InsertText="Insertar" UniqueName="EditCommandColumn1"
                    UpdateImageUrl="Update.gif" UpdateText="Actualizar">
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
        <FilterMenu EnableEmbeddedSkins="True">
        </FilterMenu>
        <StatusBarSettings LoadingText="Cargando..." />
    </telerik:RadGrid>
    <asp:Panel runat="server" ID="pnlCantidadSocios" ForeColor="Firebrick" Style="text-align: center">
        <asp:Label runat="server" ID="lblUnicoDueno" Visible="false">
            Debe ingresar los datos del propietario
        </asp:Label>
    </asp:Panel>
    <asp:ObjectDataSource ID="odsSocios" runat="server" />
    <br />
    <telerik:RadAjaxLoadingPanel ID="pnlAjaxLoading" runat="server" Transparency="00"
        BackgroundPosition="Center" IsSticky="true" Style="position: relative; margin-left: 40%"
        Width="20%">
        <div style="text-align: center; background: white; border: 1px solid #eeeeee">
            <p>
                &nbsp;</p>
            <p>
                Cargando los datos...</p>
            <img src="/res/img/icons/Progress.gif" />
            <p>
                &nbsp;</p>
        </div>
    </telerik:RadAjaxLoadingPanel>
</telerik:RadAjaxPanel>
