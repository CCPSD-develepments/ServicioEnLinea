<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManejoSucursales.ascx.cs" Inherits="CamaraComercio.Website.UserControls.ManejoSucursales" %>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="200px" 
    width="300px" HorizontalAlign="NotSet" LoadingPanelID="pnlAjaxLoading">
    <telerik:RadGrid ID="rgSucursales" runat="server" EnableEmbeddedSkins="False"  
    
        Skin="NoboxGrid" AutoGenerateColumns="False" GridLines="None" 
        DataSourceID="odsSucursales">
        <MasterTableView DataSourceID="odsSucursales">
            <CommandItemSettings AddNewRecordText="Ingresar Propietario/Socio/Accionista" RefreshText="Refrescar" />
            <NoRecordsTemplate>
            </NoRecordsTemplate>
            <RowIndicatorColumn>
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn>
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <Columns>
                 <telerik:GridEditCommandColumn CancelImageUrl="Cancel.gif" EditImageUrl="~/res/img/icons/Edit.gif"
                    ButtonType="ImageButton" EditText="Editar" InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif">
                    <ItemStyle Width="16px" />
                </telerik:GridEditCommandColumn>
                <telerik:GridButtonColumn CommandName="Delete" ConfirmText="Esta seguro que desea eliminar este socio?"
                    ConfirmTitle="Remover Socio" ButtonType="ImageButton" ImageUrl="~/res/img/icons/del.gif"
                    Text="Eliminar" UniqueName="column">
                    <ItemStyle Width="16px" />
                </telerik:GridButtonColumn>
                <telerik:GridBoundColumn DataField="Descripcion" HeaderText="Descripción" 
                    UniqueName="Descripcion">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="DireccionTelefonoOficina" 
                    HeaderText="Telefono" UniqueName="Telefono">
                </telerik:GridBoundColumn>
            </Columns>
             <EditFormSettings EditColumn-CancelText="Cancelar" EditColumn-EditText="Editar" EditColumn-InsertText="Insertar"
                EditColumn-UpdateText="Actualizar" EditFormType="WebUserControl" UserControlName="/UserControls/SucursalesDetails.ascx">
                <EditColumn CancelImageUrl="Cancel.gif" CancelText="Cancelar" EditImageUrl="/res/img/icons/Edit.gif"
                    EditText="Editar" InsertImageUrl="Update.gif" InsertText="Insertar" UniqueName="EditCommandColumn1"
                    UpdateImageUrl="Update.gif" UpdateText="Actualizar">
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
        <FilterMenu EnableEmbeddedSkins="False">
        </FilterMenu>
        <HeaderContextMenu EnableEmbeddedSkins="False">
        </HeaderContextMenu>
         <StatusBarSettings LoadingText="Cargando..." />
    </telerik:RadGrid>
    <asp:ObjectDataSource ID="odsSucursales" runat="server" 
        SelectMethod="GetSucursalesByNumeroRegistro" 
        TypeName="CamaraComercio.DataAccess.EF.OficinaVirtual.SucursalRepository" 
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="30064" Name="numeroRegistro" 
                QueryStringField="noRegistro" Type="Int32" />
            <asp:QueryStringParameter DefaultValue="SDQ" Name="camaraID" 
                QueryStringField="camaraId" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
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

