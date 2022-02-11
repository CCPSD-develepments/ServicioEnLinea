<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RevisionBHDEmpresa.aspx.cs" Inherits="CamaraComercio.Website.Mantenimiento.RevisionBHDEmpresa" %>--%>

    <%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="RevisionBHDEmpresa.aspx.cs" Inherits="CamaraComercio.Website.Mantenimiento.RevisionBHDEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 

     <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                        </telerik:RadScriptManager>

    <br />
                                   

                            <telerik:RadGrid ID="gvUserActivities" runat="server" AutoGenerateColumns="False" Width="50%"
                                    GridLines="None">
                                    <ClientSettings>
                                    </ClientSettings>
                                    <MasterTableView>
                                        <RowIndicatorColumn>
                                            <HeaderStyle Width="20px" />
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn>
                                            <HeaderStyle Width="20px" />
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="Id" HeaderText="Id" UniqueName="Empresa1">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="reference" HeaderText="Referencia/No. Transacción" UniqueName="Empresa2">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TransactionId" HeaderText="Transaccion (BHD)" UniqueName="Empresa">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EstadoString" HeaderText="Estado" UniqueName="Empresa">
                                            </telerik:GridBoundColumn>
                                          
                                            

                                           
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>

<br />
<br />    
</asp:Content>
