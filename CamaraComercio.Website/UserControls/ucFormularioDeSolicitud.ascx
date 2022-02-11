<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFormularioDeSolicitud.ascx.cs" Inherits="CamaraComercio.Website.UserControls.ucFormularioDeSolicitud" %>

<%@ Register Assembly="CamaraComercio.Website" Namespace="CamaraComercio.Website.Helpers.ExtendedControls" TagPrefix="cc1" %>

                 <asp:MultiView runat="server" ID="mainMultiView" ActiveViewIndex="0">
                  <asp:View runat="server" ID="succesfullView">
                    <fieldset class="form-fieldset">
                    <h4 style="align-content: center;" align="center">Datos del Gestor</h4>
                    <div id="gestorData">
                        <ul>
                            <li>
                                <asp:Label ID="lbSolicitante" AssociatedControlID="txtSolicitante" Text="Solicitante: " runat="server"></asp:Label>
                                <asp:Label ID="txtSolicitante" Text="" runat="server" ReadOnly="True" CssClass="tb" Height="16px" Width="250px"></asp:Label>
                                <br />
                                <br />
                            </li>
                            <li>
                                <asp:Label ID="lbNombreCont" AssociatedControlID="txtNombreCont" Text="Nombre de la persona de Contacto: " runat="server"></asp:Label>
                                <asp:Label ID="txtNombreCont" Text="" runat="server" ReadOnly="True" CssClass="tb" Height="16px" Width="200px"></asp:Label>
                                <br />
                                <br />
                            </li>
                            <li>
                                <asp:Label ID="lbEmail" AssociatedControlID="txtEmail" Text="Correo Electronico: " runat="server"></asp:Label>
                                <asp:Label ID="txtEmail" runat="server" CssClass="tb" Height="16px" Width="250px" ReadOnly="True"></asp:Label>
                                <br />
                                
                                <br />
                            </li>
                            <li>
                                <asp:Label ID="lbRNC1" Text="RNC/Cedula de Solicitante: " AssociatedControlID="txtRNC1" runat="server"></asp:Label>
                                <asp:Label ID="txtRNC1" Text="" runat="server" CssClass="tb" Height="16px" Width="130px" ReadOnly="True"></asp:Label>
                                <br />
                                <br />
                            </li>
                            <li>
                                <asp:Label ID="lbCedula" Text="Cedula de Contacto: " AssociatedControlID="txtCedula" runat="server"></asp:Label>
                                <asp:Label ID="txtCedula" Text="" runat="server" CssClass="tb" Height="16px" Width="130px" ReadOnly="True"></asp:Label>
                                <br />
                                <br />
                            </li>
                            <li>
                                <asp:Label ID="lbTelefono" Text="Telefono: " runat="server" AssociatedControlID="txtTelefono"></asp:Label>
                                <asp:Label ID="txtTelefono" Text="" runat="server" CssClass="tb" Height="16px" Width="130px" ReadOnly="True"></asp:Label>
                                <br />
                                <br />

                            </li>
                        </ul>
                    </div>
                    <div id="sociedadData">
                        <h4 style="align-content: center;" align="center"> Datos de la Sociedad</h4>
                            <br />
                            <br />
                         <ul>
                            <li>
                                <asp:Label ID="lbRazSocial" Text="Razon Social: " AssociatedControlID="txtRazSocial" runat="server"></asp:Label>
                                <asp:Label ID="txtRazSocial" Text="" runat="server" CssClass="tb" Height="16px" Width="280px" ReadOnly="True"></asp:Label>
                                <br />
                                <br />
                            </li>
                            <li>
                                <asp:Label ID="lbNoRegistro" Text="Registro No:" AssociatedControlID="txtNoRegistro" runat="server"></asp:Label>
                                <asp:Label ID="txtNoRegistro" Text="" runat="server" CssClass="tb" Height="16px" Width="103px" ReadOnly="True"></asp:Label>
                                <br />
                                <br />
                            </li>
                            <li>
                                <asp:Label ID="lbDireccionSociedad" Text="Direccion de Sociedad: " AssociatedControlID="txtDireccionSociedad" runat="server"></asp:Label>
                                <asp:Label ID="txtDireccionSociedad" Text="" runat="server" CssClass="tb" Height="16px" Width="280px" ReadOnly="True"></asp:Label>
                                <br />
                                <br />
                            </li>
                            <li>
                                <asp:Label ID="lbTel1" Text="Telefono 1: " AssociatedControlID="txtTel1" runat="server"></asp:Label>
                                <asp:Label ID="txtTel1" Text="" runat="server" CssClass="tb" Height="16px" Width="130px" ReadOnly="True"></asp:Label>
                                <br />
                                <br />
                            </li>
                            <li>
                                <asp:Label ID="lbTel2" Text="Telefono 2: " AssociatedControlID="txtTel2" runat="server"></asp:Label>
                                <asp:Label ID="txtTel2" Text="" runat="server" CssClass="tb" Height="16px" Width="130px" ReadOnly="True"></asp:Label>
                                <br />
                                <br />
                            </li>
                            <li>
                                <asp:Label ID="lbFecaConst" Text="Fecha Acto Constitutivo: " AssociatedControlID="txtFechaConst" runat="server"></asp:Label>
                                <asp:Label ID="txtFechaConst" Text="" runat="server" CssClass="tb" Height="16px" Width="130px" ReadOnly="True"></asp:Label>
                                <br />
                                <br /> 
                            </li>
                            <li>
                                <asp:Label ID="lbFechaEmision" Text="Fecha Emision: " AssociatedControlID="txtFechaEmision" runat="server"></asp:Label>
                                <asp:Label ID="txtFechaEmision" Text="" runat="server" CssClass="tb" Height="16px" Width="130px" ReadOnly="True"></asp:Label>
                                <br />
                                <br />
                            </li>
                            <li>
                                <asp:Label ID="lbNombreCom" Text="Nombre Comercial: " AssociatedControlID="txtNombreCom" runat="server"></asp:Label>
                                <asp:Label ID="txtNombreCom" Text="" runat="server" CssClass="tb" Height="16px" Width="244px" ReadOnly="True"></asp:Label>
                                <br />
                                <br />
                            </li>
                            <li>
                                 <asp:Label ID="lbRNCSociedad" Text="RNC Sociedad: " AssociatedControlID="txtRNCSoc" runat="server"></asp:Label>
                                <asp:Label ID="txtRNCSoc" Text="" runat="server" CssClass="tb" Height="16px" Width="103px" ReadOnly="True"></asp:Label>
                                <br />
                                <br />
                             </li>
                             <li>
                                <asp:Label ID="lbPagWeb" Text="Pagina Web: " AssociatedControlID="txtPagWeb" runat="server"></asp:Label>
                                <asp:Label ID="txtPagWeb" Text="" runat="server" CssClass="tb" Height="16px" Width="280px" ReadOnly="True"></asp:Label>
                                <br />
                                <br />
                              </li>
                             <li>
                                 <asp:Label ID="lbFechaVenc" Text="Fecha Vencimiento: " AssociatedControlID="txtFechaVenc" runat="server"></asp:Label>
                                <asp:Label ID="txtFechaVenc" Text="" runat="server" CssClass="tb" Height="16px" Width="103px" ReadOnly="True"></asp:Label>
                                <br />
                                <br />
                             </li>
                             <li>
                                 <asp:Label ID="lbEstadoAct" Text="Estado Actual: " AssociatedControlID="txtEstadoSociedad" runat="server"></asp:Label>
                                <asp:Label ID="txtEstadoSociedad" Text="" runat="server" CssClass="tb" Height="16px" Width="103px" ReadOnly="True"></asp:Label>
                                <br />
                                 <br />
                              </li>
                             <li>
                                <asp:Label ID="lnDuracionSociedad" runat="server" AssociatedControlID="txtDuracionSociedad" Text="Duracion Sociedad: " Height="16px" Width="212px"></asp:Label>
                                <asp:Label ID="txtDuracionSociedad" runat="server" Text="" CssClass="tb" Height="16px"></asp:Label>
                             </li>
                                
                           
                            <li>
                                <br />
                                
                                <div id="sucursales" class="RadGrid RadGrid_NoboxGrid">
                                    <h4 style="align-content: center; height: 2px;" align="center">&nbsp;Sucursales</h4>
                                    <br />
                                    <table class="rgMasterTable" style="width: 100%; table-layout: auto; empty-cells: show;" cellspacing="0" align="center">
                                        <thead>
                                            <tr>
                                                <th class="rgHeader" style="width: 9px"></th>
                                                <th class="rgHeader">Descripcion</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="sucursalRepeater" runat="server">
                                                <ItemTemplate>
                                                    <tr class="rgRow">
                                                        <td></td>
                                                        <td><span><%# Eval("Descripcion") %></span></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                    
                                </div>
                            </li>
                          </ul>
                    </div>
                    <div id="servicio">
                            <br />
                            <asp:Label ID="lbServicio" Text="Servicio: " runat="server" AssociatedControlID="txtServicio" Font-Size="14px" Height="26px" Width="174px"></asp:Label>
                            <asp:Label ID="txtServicio" Text="" runat="server" CssClass="tb" Height="16px" Width="313px" ReadOnly="True"></asp:Label>
                            <br />
                            <br />
                    </div>
                    <div id="Socios">
                        <br />
                        <div id="OrganoGestor" class="RadGrid RadGrid_NoboxGrid">
                            <h4 style="align-content: center;" align="center">Datos Organo de Gestion / Gerentes</h4>
                            <table class="rgMasterTable" style="width: 97%; table-layout: auto; empty-cells: show;" cellspacing="0" align="center">
                                <thead>
                                    <tr>
                                        <th class="rgHeader" style="width: 10px"></th>
                                        <th class="rgHeader">Cargo</th>
                                        <th class="rgHeader">Nombre</th>
                                        <th class="rgHeader">Cedula</th>
                                        <th class="rgHeader">Direccion</th>
                                        <th class="rgHeader">Nacionalidad</th>
                                        <th class="rgHeader">EstadoCivil</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="orgGestionRepeater" runat="server">
                                        <ItemTemplate>
                                            <tr class="rgRow">
                                                <td></td>
                                                <td><span><%# Eval("Cargo") %></span></td>
                                                <td><span><%# Eval("Accionista") %></span></td>
                                                <td><span><%# CamaraComercio.Website.ExtensionMethods.FormatRnc(((CamaraComercio.DataAccess.EF.SRM.ViewRegistrosSocios)Container.DataItem).Documento) %></span></td>
                                                <td><span><%# Eval("Calle") + ", " + Eval("Sector") + ", " + Eval("Ciudad") %></span></td>
                                                <td><span><%# Eval("Nacionalidad") %></span></td>
                                                <td><span><%# Eval("EstadoCivil") %></span></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                            <h2 runat="server" style="display: none;"> No hay datos para mostrar. </h2>
                            <br />
                            <asp:Label ID="lnDuracionDirectiva" runat="server" CssClass="infoHeader" AssociatedControlID="txtDuracionDir" Text="Duracion Organo de Gestion: " Width="258px"></asp:Label>
                            <br />
                            <asp:Label ID="txtDuracionDir" runat="server" Text=""></asp:Label>
                            <br />
                            <br />
                            <br />
                            <h4 style="align-content: center; height: 5px;" align="center">Datos de los Socios</h4>
                            <br />
                            <table class="rgMasterTable" style="width: 97%; table-layout: auto; empty-cells: show;" cellspacing="0" align="center">
                                <thead>
                                    <tr>
                                        <th class="rgHeader" style="width: 8px"></th>
                                        <th class="rgHeader">Nombre</th>
                                        <th class="rgHeader">Registro Mercantil/Registro Publico</th>
                                        <th class="rgHeader">Nombre</th>
                                        <th class="rgHeader">Cedula</th>
                                        <th class="rgHeader">Direccion</th>
                                        <th class="rgHeader">EstadoCivil</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="sociosRep" runat="server">
                                        <ItemTemplate>
                                            <tr class="rgRow">
                                                <td></td>
                                                <td><span><%# Eval("Accionista") %></span></td>
                                                <td><span><%# Eval("NumeroRM") %></span></td>
                                                <td><span><%# CamaraComercio.Website.ExtensionMethods.FormatRnc(((CamaraComercio.DataAccess.EF.SRM.ViewRegistrosSocios)Container.DataItem).Documento) %></span></td>
                                                <td><span><%# Eval("Calle") + ", " + Eval("Sector") + ", " + Eval("Ciudad") %></span></td>
                                                <td><span><%# Eval("Nacionalidad") %></span></td>
                                                <td><span><%# Eval("EstadoCivil") %></span></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                            <h2 runat="server" style="display: none;"> No hay datos para mostrar. </h2>
                            <br />
                            <asp:Label ID="lnDuracionDirectiva0" runat="server" CssClass="infoHeader" AssociatedControlID="txtTotalSocios" Text="Total Socios: "  Width="209px"></asp:Label>
                            <br />
                            <asp:Label ID="txtTotalSocios" runat="server" Text="" CssClass="tb"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="Label1" runat="server" CssClass="infoHeader" AssociatedControlID="txtTotalAcciones" Text="CantidadCuotasSociales: " Width="210px"></asp:Label>
                            <br />
                            <asp:Label ID="txtTotalAcciones" runat="server" Text="" CssClass="tb"></asp:Label>
                            <br />
                            <br />
                            <br />
                            <h4 style="align-content: center; height: 5px;" align="center">Datos de Personas Autorizadas A Firmar</h4>
                            <br />
                            <table class="rgMasterTable" style="width: 97%; table-layout: auto; empty-cells: show;" cellspacing="0" align="center">
                                <thead>
                                    <tr>
                                        <th class="rgHeader" style="width: 8px"></th>
                                        <th class="rgHeader">Nombre</th>
                                        <th class="rgHeader">Cargo</th>
                                        <th class="rgHeader">Cedula</th>
                                        <th class="rgHeader">Direccion</th>
                                        <th class="rgHeader">Nacionalidad</th>
                                        <th class="rgHeader">EstadoCivil</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="sociosAutRep" runat="server">
                                        <ItemTemplate>
                                            <tr class="rgRow">
                                                <td></td>
                                                <td><span><%# Eval("Accionista") %></span></td>
                                                <td><span><%# Eval("Cargo") %></span></td>
                                                <td><span><%# CamaraComercio.Website.ExtensionMethods.FormatRnc(((CamaraComercio.DataAccess.EF.SRM.ViewRegistrosSocios)Container.DataItem).Documento) %></span></td>
                                                <td><span><%# Eval("Calle") + ", " + Eval("Sector") + ", " + Eval("Ciudad") %></span></td>
                                                <td><span><%# Eval("Nacionalidad") %></span></td>
                                                <td><span><%# Eval("EstadoCivil") %></span></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                            <h2 runat="server" style="display: none;"> No hay datos para mostrar. </h2>
                            <br />
                        </div>
                           
                                <div id="entesRegTbl" class="RadGrid RadGrid_NoboxGrid">
                                     <h4 style="align-content: center; height: 2px;" align="center">&nbsp;Entes Regulados</h4>
                                    <br />
                                    <table class="rgMasterTable" style="width: 100%; table-layout: auto; empty-cells: show;" cellspacing="0" align="center">
                                        <thead style="text-align: center;">
                                            <tr>
                                                <th class="rgHeader" style="width: 9px"></th>
                                                <th class="rgHeader">Tipo de Ente Regulado</th>
                                                <th class="rgHeader">No. Resolucion</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="entesRegRep" runat="server">
                                                <ItemTemplate>
                                                    <tr class="rgRow">
                                                        <td></td>
                                                        <td><span><%# Eval("EnteReguladoDescripcion") %></span></td>
                                                        <td><span><%# Eval("NoResolucion") %></span></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                    
                                    <br />
                                </div>
                            </div>
                       <hr />
                    <div id="refs">
                        <ul>
                            <li>
                            </li>
                            <li>
                                <label for="txtReferenciasComerciales">
                                Referencias Comerciales
                                </label>
                                <asp:Label ID="txtReferenciasComerciales" runat="server" ClientIDMode="Static" CssClass="commentCtrl" ReadOnly="True" />
                                <asp:HiddenField ID="hfReferenciasComerciales" runat="server" ClientIDMode="Static" />
                            </li>
                            <li>
                                <label for="txtRefBancarias">
                                    Referencias Bancarias
                                </label>
                                <asp:Label ID="txtRefBancarias" ClientIDMode="Static" runat="server" CssClass="commentCtrl" ReadOnly="True"/>
                                <asp:HiddenField ID="hfRefBancarias" ClientIDMode="Static" runat="server" />
                            </li>
                        </ul>
                    </div>
                    <div id="fechaAsamblea">
                        <asp:Label ID="lbFechaAsamble" Text="Fecha Ultima Asamblea: " AssociatedControlID="txtFechaAsamb" runat="server" ReadOnly="True"></asp:Label>
                        <asp:Label ID="txtFechaAsamb" Text="" runat="server" ReadOnly="True"></asp:Label>
                            
                        <br />
                        <br />
                    </div>
            
                    <asp:Button ID="ConfirmarDatos" runat="server" Text="Confirmar Datos" OnClick="ConfirmarDatos_Click" CssClass="btn btnFormNext" />
                    
                </fieldset>
                      </asp:View>
                     <asp:View runat="server" ID="failView">
                            <div class="sectDetailBlue">
                                <h2 id="txtMessageTitle" runat="server"></h2>
                            </div>
                        </asp:View>
                     </asp:MultiView>
