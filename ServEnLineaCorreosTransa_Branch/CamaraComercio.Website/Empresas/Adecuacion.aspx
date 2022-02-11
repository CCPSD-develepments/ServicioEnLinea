<%@ Page Title="" Language="C#" MasterPageFile="~/res/nobox.master" AutoEventWireup="true"
    CodeBehind="Adecuacion.aspx.cs" Inherits="CamaraComercio.Website.Empresas.Adecuacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Adecuación Requerida</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_24">
        <div class="grid_24">
            <div id="content_header">
                <h1>
                    Adecuación Obligatoria
                </h1>
            </div>
            <div id="content_body">
                <fieldset class="form-fieldset">
                    <p>
                        Su sociedad/empresa debe ser adecuada a la nueva ley de sociedades antes de usted
                        poder realizar cualquier operación.
                    </p>
                    <div id="wrapper" style="text-align: center">
                        <div class="infoBox">
                            <div class="infoContent">
                                <a href="/Operaciones/Registro/Adecuacion.aspx" class="btn">Adecuación de Sociedad</a>
                                <p>
                                    Selecciona esta opción si desea Adecuar una empresa a la nueva ley de sociedades
                                    de la República Dominicana.
                                </p>
                                <div class="clear" />
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
            <div class="clear" />
        </div>
        <!-- end grid_24 -->
    </div>
</asp:Content>
