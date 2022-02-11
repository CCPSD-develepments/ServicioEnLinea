<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Optimo.aspx.cs" Inherits="CamaraComercio.Website.Empresas.Optimo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <title>...</title>
        <link href="~/res/css/bootstrap.css" rel="stylesheet" />
        <link href="/res/css/nobox.css" rel="stylesheet" type="text/css" />
        <script src="/res/js/jquery-1.4.1.min.js" type="text/javascript"></script>
        <style>
            * {
            padding: 0;
            margin: 0;
            box-sizing: border-box;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            }
            html, body {
            height:100%;
            width: 100%;
            background-image: url('/res/img/fondo.jpg');
            }
            body {
                /*display: flex;
                flex: 0 0 auto;*/
                /*position:relative;*/
                min-height: 700px;
                min-width:100%;
                align-items: stretch;
                flex-direction: column;
                justify-content: space-between;
            }
            .header, .footer {
            /*background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#1E5478), color-stop(100%,#0a2c42));*/
            background: -o-linear-gradient(rgba(29, 83, 119, 50), rgb(3, 45, 70));
		    background: -moz-linear-gradient(rgba(29, 83, 119, 50), rgb(3, 45, 70));
		    background: -webkit-linear-gradient(rgba(29, 83, 119, 50), rgb(3, 45, 70));
		    background: linear-gradient(rgba(29, 83, 119, 50), rgb(3, 45, 70));
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#1e5799', endColorstr='#032D46',GradientType=0 ); /* IE6-9 */
            /*background-image: linear-gradient(to bottom left, #23527c 0%, #16D611 50%, #23527c 80%);*/
            color: white;
            text-align:center;
            height:1px;
            }
            .header {
            height: 100px;
            display: flex;
            width:100%;
            justify-content: space-between;
            align-items: center;
            padding-left: 10px;
            padding-right: 10px;
            background-color: rgba(238, 238, 238, 1);
            }
            .header > .left-logo {
                display: block;
                width: 270px;
                height: 100px;
                background-image: url('/res/img/logo.jpg');
                background-repeat: no-repeat;
                background-position: left top;
            }
            main {
            flex: 1;
            display: flex;
            padding: 50px 150px;
            min-width:450px;
            min-height:550px;
            }
            #contenedor {
            height:100%;
            width:100%;
            padding:15px;
            min-width:400px;
            min-height:500px;
            background-color: #ffffff;
            margin-right: 10px;
            border-radius: 10px;
            /*overflow:hidden;*/
        }
            #recuadroContinuar{
                background-color:#f6f6f6;
                padding:10px;
            }
            .loader {
                  border: 16px solid #f3f3f3;
                  border-radius: 50%;
                  border-top: 16px solid #3498db;
                  width: 120px;
                  height: 120px;
                  -webkit-animation: spin 2s linear infinite; /* Safari */
                  animation: spin 2s linear infinite;
                }
                
                /* Safari */
                @-webkit-keyframes spin {
                  0% { -webkit-transform: rotate(0deg); }
                  100% { -webkit-transform: rotate(360deg); }
                }
                
                @keyframes spin {
                  0% { transform: rotate(0deg); }
                  100% { transform: rotate(360deg); }
                }
        </style>
    </head>
    <body>
        <header class="header">
            <a href="javascript:void(0)" class="left-logo"></a>

            
        </header>
        <main>
            <form runat="server">
            <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server"></telerik:RadStyleSheetManager>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            <div id="contenedor">

            <h2 style="color:#237392;">Transacciones con más de trienta(30) dias</h2>
            <div id="recuadroContinuar" style="vertical-align:central">
                        <strong>
                            <asp:Label runat="server" ID="lblMensaje" style="font-size: 15px;" Text=""></asp:Label>
                        </strong>
                </div>
            <telerik:RadGrid ID="rgridAborrar" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                GridLines="None" DataSourceID="" AllowSorting="True"
                                Skin="NoboxGrid" EnableEmbeddedSkins="false" OnNeedDataSource="rgridAborrar_NeedDataSource">
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                    <MasterTableView DataSourceID="" NoMasterRecordsText="No se han encontrado registros">
                                <Columns>
                                    <telerik:GridBoundColumn DataField="TransaccionID" DataType="System.Int32" HeaderText="No. Solicitud" SortExpression="RegistroID" UniqueName="TransaccionID">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CamaraID" HeaderText="Camara" SortExpression="CamaraID"
                                        UniqueName="CamaraID" Visible="false">
                                    </telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn DataField="FechaSolicitud" DataType="System.DateTime" HeaderText="Fecha"
                                        SortExpression="FechaSolicitud" DataFormatString="{0:dd/MM/yyyy}" UniqueName="FechaSolicitud">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="RegistroID" DataType="System.Int32" HeaderText="No. Registro"
                                        SortExpression="RegistroID" UniqueName="RegistroID">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="SociedadID" DataType="System.Int32" HeaderText="SociedadID"
                                        SortExpression="SociedadID" UniqueName="SociedadID" Visible="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TipoSociedadID" DataType="System.Int32" HeaderText="TipoSociedadID"
                                        SortExpression="TipoSociedadID" UniqueName="TipoSociedadID" Visible="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NombreSocial" HeaderText="Nombre Social" SortExpression="NombreSocial"
                                        UniqueName="NombreSocial">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn DataField="SiglasTipoSociedad" HeaderText="Tipo" SortExpression="SiglasTipoSociedad"
                                        UniqueName="SiglasTipoSociedad" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="SiglasTipoSociedadLabel" runat="server" Text='<%# Eval("SiglasTipoSociedad") %>'
                                                ToolTip='<%# Eval("TipoSociedad") %>'></asp:Label>
                                        </ItemTemplate>

                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="Servicio" HeaderText="Servicio"
                                        SortExpression="Servicio" UniqueName="Servicio">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="EstatusTransaccion" HeaderText="Estado"
                                        SortExpression="EstatusTransaccion" UniqueName="Estado">
                                    </telerik:GridBoundColumn>
                                </Columns>

                            </MasterTableView>
                            <PagerStyle PagerTextFormat="Change page: {4} &amp;nbsp;{5} registros en {1} páginas." />
                            <FilterMenu EnableEmbeddedSkins="False">
                            </FilterMenu>
                            <HeaderContextMenu EnableEmbeddedSkins="False">
                            </HeaderContextMenu>
                 </telerik:RadGrid>
                <br />


                <asp:Button Text="Continuar" runat="server" CssClass="btn btn-right" 
                    ID="btnContinuar" OnClientClick="op()" OnClick="btnContinuar_Click" 
                    usesubmitbehavior="false"/>
                    <a class="btn btn-right" href="/account/logout.aspx">Cancelar y Cerrar sesión</a>
                <div  id="test" style="visibility:hidden; align-items: center;">
                    <center style="padding-top:150px;">
                        <div style="opacity:1" class="loader"></div>
                        <h2 style="opacity:1; color:white; background-color:rgba(0, 0, 0, 0.15);" >Espere por favor, se está trabajando!</h2>
                    </center>
                </div>
            </div>
            </form>
        </main>
        <script type="text/javascript">

            (function (global) {

                if (typeof (global) === "undefined") {
                    throw new Error("window is undefined");
                }

                var _hash = "!";
                var noBackPlease = function () {
                    global.location.href += "#";

                    // making sure we have the fruit available for juice (^__^)
                    global.setTimeout(function () {
                        global.location.href += "!";
                    }, 50);
                };

                global.onhashchange = function () {
                    if (global.location.hash !== _hash) {
                        global.location.hash = _hash;
                    }
                };

                global.onload = function () {
                    noBackPlease();

                    // disables backspace on page except on input fields and textarea..
                    document.body.onkeydown = function (e) {
                        var elm = e.target.nodeName.toLowerCase();
                        if (e.which === 8 && (elm !== 'input' && elm !== 'textarea')) {
                            e.preventDefault();
                        }
                        // stopping event bubbling up the DOM tree..
                        e.stopPropagation();
                    };
                }

            })(window);

            function op() {
                $('#test').css("width", "100%");
                $('#test').css("min-height", "100%");
                $('#test').css("opacity", "1");
                $('#test').css("background-color", "rgb(0, 0, 0,0.5)");
                $('#test').css("background-color", "rgba(0, 0, 0,0.5)");
                $('#test').css("height", "auto");
                $('#test').css("position", "fixed");
                $('#test').css("top", "0");
                $('#test').css("left", "0");
                $('#test').css("background-size","100% 100%");
                $('#test').css("visibility", "visible");
            };
        </script>

    </body>
</html>
