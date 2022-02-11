<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.Master" AutoEventWireup="true" CodeBehind="WebWizard.aspx.cs" Inherits="CamaraComercio.Website.Empresas.WebWizard" %>

<%@ MasterType VirtualPath="~/res/nobox.master" %>
<%@ Register Assembly="CamaraComercio.Website" Namespace="CamaraComercio.Website.Helpers.ExtendedControls" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/ucRevisionDocumentos.ascx" TagPrefix="uc1" TagName="ucRevisionDocumentos" %>
<%@ Register Src="~/UserControls/ucFormularioDeSolicitud.ascx" TagPrefix="uc1" TagName="ucFormularioDeSolicitud" %>
<%@ Register Src="~/UserControls/ucEnvioDatos.ascx" TagPrefix="uc1" TagName="ucEnvioDatos" %>
<%@ Register Src="~/UserControls/ucPagosTarjeta.ascx" TagPrefix="uc1" TagName="ucPagosTarjeta" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- Plugins -->
    <!-- Estilos de tablas -->
    <link href="/res/css/tableStyles.css" rel="stylesheet" type="text/css" />

    <!-- CSS -->
    <link href="/res/css/buttons.css" rel="stylesheet" type="text/css" />
    <!-- jQuery UI -->
    <script src="/res/js/json2.js" type="text/javascript"></script>

    <!-- Manejo del Upload client side -->
    <script src="/res/js/ui.adecuacion.js" type="text/javascript"></script>
    <script src="/res/js/ui.enviodatos.js" type="text/javascript"></script>

    <script src="/res/js/jquery.alphanumeric.js" type="text/javascript"></script>
    <script src="/res/js/ui.spinner.js" type="text/javascript"></script>
    <script src="/res/js/jquery.formatCurrency-1.4.0.min.js" type="text/javascript"></script>
    <script src="/res/js/jquery.tools.min.js" type="text/javascript"></script>
    <script src="/res/js/ui.revisiondocumentos.js" type="text/javascript"></script>
    <!--Styles-->
    <style type="text/css">
        .tooltip {
            display: none;
            background: transparent url(/res/img/black_arrow.png);
            font-size: 10px;
            height: 70px;
            width: 160px;
            padding: 25px;
            color: #fff;
        }

        .txtUpDown {
            text-align: center !important;
        }

        #wizHeader li .prevStep {
            background-color: #669966;
        }

            #wizHeader li .prevStep:after {
                border-left-color: #669966 !important;
            }

        #wizHeader li .currentStep {
            background-color: #C36615;
        }

            #wizHeader li .currentStep:after {
                border-left-color: #C36615 !important;
            }

        #wizHeader li .nextStep {
            background-color: #C2C2C2;
        }

            #wizHeader li .nextStep:after {
                border-left-color: #C2C2C2 !important;
            }

        #wizHeader {
            list-style: none;
            overflow: hidden;
            font: 18px Helvetica, Arial, Sans-Serif;
            margin: 0px;
            padding: 0px;
        }

            #wizHeader li {
                float: left;
            }

                #wizHeader li a {
                    color: white;
                    text-decoration: none;
                    padding: 10px 0 10px 55px;
                    background: brown; /* fallback color */
                    background: hsla(34,85%,35%,1);
                    position: relative;
                    display: block;
                    float: left;
                }

                    #wizHeader li a:after {
                        content: " ";
                        display: block;
                        width: 0;
                        height: 0;
                        border-top: 50px solid transparent; /* Go big on the size, and let overflow hide */
                        border-bottom: 50px solid transparent;
                        border-left: 30px solid hsla(34,85%,35%,1);
                        position: absolute;
                        top: 50%;
                        margin-top: -50px;
                        left: 100%;
                        z-index: 2;
                    }

                    #wizHeader li a:before {
                        content: " ";
                        display: block;
                        width: 0;
                        height: 0;
                        border-top: 50px solid transparent;
                        border-bottom: 50px solid transparent;
                        border-left: 30px solid white;
                        position: absolute;
                        top: 50%;
                        margin-top: -50px;
                        margin-left: 1px;
                        left: 100%;
                        z-index: 1;
                    }

                #wizHeader li:first-child a {
                    padding-left: 10px;
                }

                #wizHeader li:last-child {
                    padding-right: 50px;
                }

                #wizHeader li a:hover {
                    background: #FE9400;
                }

                    #wizHeader li a:hover:after {
                        border-left-color: #FE9400 !important;
                    }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <div>
                    <h1 id="detalles">
                        <span class="right normal">
                            <asp:Label runat="server" ID="lblNombreEmpresa" /></span>SOLICITUD DE SERVICIOS
                    </h1>
                </div>
            </div>
            <div id="content_body">
                <telerik:RadScriptManager ID="radScriptManager1" runat="server" EnablePageMethods="true">
                </telerik:RadScriptManager>
                <asp:Wizard ID="Wizard1" runat="server" DisplaySideBar="false" Width="100%">
                    <WizardSteps>
                        <asp:WizardStep ID="WizardStep1" runat="server" Title="Revisión de Documentos">
                            <uc1:ucRevisionDocumentos runat="server" id="ucRevisionDocumentos" />
                        </asp:WizardStep>
                        <asp:WizardStep ID="WizardStep2" runat="server" Title="Formulario de Solicitud">
                            <uc1:ucFormularioDeSolicitud runat="server" id="ucFormularioDeSolicitud" />
                        </asp:WizardStep>
                        <asp:WizardStep ID="WizardStep3" runat="server" Title="Envío de Datos">
                            <uc1:ucEnvioDatos runat="server" id="ucEnvioDatos" />
                        </asp:WizardStep>
                        <asp:WizardStep ID="WizardStep4" runat="server" Title="Costos por Servicios">
                            <uc1:ucPagosTarjeta runat="server" id="ucPagosTarjeta" />
                        </asp:WizardStep>
                    </WizardSteps>
                    <HeaderTemplate>
                        <ul id="wizHeader">
                            <asp:Repeater ID="SideBarList" runat="server">
                                <ItemTemplate>
                                    <li><a class="<%# GetClassForWizardStep(Container.DataItem) %>" title="<%#Eval("Name")%>">
                                        <%# Eval("Name")%></a> </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </HeaderTemplate>
                </asp:Wizard>
            </div>
        </div>
    </div>
</asp:Content>
