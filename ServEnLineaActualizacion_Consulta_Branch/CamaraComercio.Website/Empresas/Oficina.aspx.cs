using System;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.Website.Helpers;
using CamaraComercio.DataAccess.EF.Membership;
using System.Collections.Generic;
using System.ComponentModel;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.DataAccess.EF.CamaraComun;
using USER = CamaraComercio.DataAccess.EF.Membership;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Web.Security;
//using CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website.Empresas
{
    ///<summary>
    /// Página de entrada a la Oficina Virtual
    ///</summary>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class Oficina : SecurePage
    {
        #region private field and properties

        /// <summary>
        /// Cantidad de empresa autorizadas que tiene el usuario activo.
        /// </summary>
        public int cantEmpresas { get; set; }

        /// <summary>
        /// Cantidad de empresas pendientes que tiene el usuario activo.
        /// </summary>
        public int cantEmpresasPendientes { get; set; }

        /// <summary>
        /// Cantidad de constituciones solicitadas por el usuario
        /// </summary>
        public int cantEmpresasNuevas { get; set; }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Oficina.UsuarioPadre'
        public string UsuarioPadre
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Oficina.UsuarioPadre'
        {
            get
            {
                if (Session["usuarioPadre"] != null)
                {
                    return Session["usuarioPadre"].ToString();
                }

                Session["usuarioPadre"] = UsuariosController.GetUsuarioPadreByUsername(User.Identity.Name.ToLower());
                return Session["usuarioPadre"].ToString();
            }
        }

        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Oficina.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Oficina.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;

            TransaccionesController transaccionesController = new TransaccionesController();
            bool hasTransaccionesDevueltas = transaccionesController.HasTransaccionesDevueltas(User.Identity.Name.ToLower());
            if (hasTransaccionesDevueltas)
            {
                Master.ShowMessageError("Usted tiene un(as) transaccion(es) devuelta(s) por proble(mas), favor revisar");
            }

           
            //Nombre de la propiedad
            Master.NombreActividad = "Visualización de Portafolios de empresas registradas";

            //Usuario autenticado y en rol. Si no está autenticado se redirije al login
            var user = HttpContext.Current.User.Identity.Name;
            if (String.IsNullOrEmpty(user)) Response.Redirect(Helper.NoboxLogin, false);

            //Se busca la infomración extendida del perfil
            var profile = OficinaVirtualUserProfile.GetUserProfile(user);

            //Si es la primera vez que un usuario hijo entra, debe cambiar su contraseña
            if (profile.UsuarioPadre != null && profile.DebeCambiarPass)
                Response.Redirect("/Account/ChangePassword.aspx");

            //Si el usuario no ha firmado su contrato se redirige a la pantalla de firma
            if (!profile.ContratoFirmado.GetValueOrDefault())
                Response.Redirect("/Empresas/FirmaContrato.aspx");

            //Nombre del usuario actual
            this.lblNombreUsuario.Text = profile.NombreSolicitante;


 //ClientScript.GetPostBackEventReference(this, string.Empty);
            //2022-01-25:
            //new busqueda:           
            TransaccionesController tran = new TransaccionesController();
            var lData = tran.GetTransaccionesByFilter(user, "Todas", 9999, "", null, null, "");
            // rgridHistorico.DataSource = null;
            rgridHistorico.Rebind();
            rgridHistorico.DataSource = lData;
            rgridHistorico.DataBind();
            ddAdecuacion.AutoPostBack = true;



            //Elementos del UI
            //this.lblUsuarioActual.Text = profile.NombreSolicitante; 
            RederMessageWarningDiv();


            //new 2021-07-05, get transacciones BHd, valida estado, update:
            var authenticated = HttpContext.Current.User.Identity.IsAuthenticated;
            if (!authenticated)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            //   getWhileLoopData(); //2021-08-11


            if (ErrorMessage.Length <= 0) return;
            Master.ShowMessageError(ErrorMessage);
            ErrorMessage = String.Empty;
                    

        }

        /// <summary>
        /// Renderiza una ventana de advertencia que indica al usuario que posee mensajes aun no leidos
        /// </summary>
        private void RederMessageWarningDiv()
        {
            var ctrl = new OFV.MensajesController();
            if (ctrl.CountUnreadByUser(this.CurrentUser.UserName.ToLower()) > 0)
            {
                this.ltlWarningDiv.Text =
                    "<div id=\"warning\">Usted posee nuevos mensajes en su buz&oacute;n. Para verlos haga click en la pesta&ntilde;a de " +
                    "Mensajes <div class=\"close\"><a href=\"#\">X</a></div></div >";
            }
        }

        #region Paging and Late Bindings

        /// <summary>
        /// Databinding de la tabla de historial de transacciones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Obsolete("Este metodo se debe de borrar")]
        protected void RgridHistoricoItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridPagerItem)
            {
                var pager = (GridPagerItem)e.Item;
                var lbl = (Label)pager.FindControl("ChangePageSizeLabel");
                lbl.Text = "Tamaño de página: ";
            }
        }

        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Oficina.Page_PreRenderComplete(object, EventArgs)'
        protected void Page_PreRenderComplete(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Oficina.Page_PreRenderComplete(object, EventArgs)'
        {
            cantEmpresas = rgridEmp.Items.Count;
            cantEmpresasPendientes = rgridPendientes.Items.Count;
            cantEmpresasNuevas = rgridNuevasPendientes.Items.Count;

            //Si el usuario no tiene empresas asignadas se envia a la página de asistencia para nuevos usuarios
            if (cantEmpresas == 0 && cantEmpresasPendientes == 0 && cantEmpresasNuevas == 0)
                Response.Redirect("InicioUsuario.aspx");

            //Se esconden los paneles para las solicitudes pendientes
            this.pnlEmpresasPendientes.Visible = cantEmpresasPendientes > 0;
            this.pnlConstitucionesPendientes.Visible = cantEmpresasNuevas > 0;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Oficina.odsMsg_Selecting(object, ObjectDataSourceSelectingEventArgs)'
        protected void odsMsg_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Oficina.odsMsg_Selecting(object, ObjectDataSourceSelectingEventArgs)'
        {
            e.InputParameters["usuarioPadre"] = this.UsuarioPadre;
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Oficina.GenericItemDataBindHandler(object, GridItemEventArgs)'
        protected void GenericItemDataBindHandler(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Oficina.GenericItemDataBindHandler(object, GridItemEventArgs)'
        {
            if (!(e.Item is GridPagerItem)) return;

            var pager = (GridPagerItem)e.Item;
            var lbl = (Label)pager.FindControl("ChangePageSizeLabel");
            lbl.Text = "Tamaño de página: ";
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Oficina.rgridMsg_ItemDataBound(object, GridItemEventArgs)'
        protected void rgridMsg_ItemDataBound(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Oficina.rgridMsg_ItemDataBound(object, GridItemEventArgs)'
        {
            if (e.Item is GridPagerItem)
            {
                var pager = (GridPagerItem)e.Item;
                var lbl = (Label)pager.FindControl("ChangePageSizeLabel");
                lbl.Text = "Tamaño de página: ";
            }

            if (e.Item is GridDataItem)
            {
                var dataItem = (GridDataItem)e.Item;

                if (dataItem["Usuario"].Text == User.Identity.Name && string.IsNullOrEmpty(dataItem["FechaLectura"].Text))
                {
                    e.Item.Font.Bold = true;
                }

            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Oficina.ddAdecuacion_SelectedIndexChanged(object, EventArgs)'
        protected void ddAdecuacion_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Oficina.ddAdecuacion_SelectedIndexChanged(object, EventArgs)'
        {

            if (!IsPostBack) return;

            DropDownList ddl = ((System.Web.UI.WebControls.DropDownList)sender);

            Session["EstatusHistorico"] = ddl.SelectedValue;

            List<Transacciones> ListaTransaccionSRM = new List<Transacciones>();

            var user = User.Identity.Name.ToLower();
            TransaccionesController tran = new TransaccionesController();
            txtNumSolicitud.Text = "";
            txtNumeroRM.Text = "";
            txtPersonaFisicaNombre.Text = "";
            txtSociedadNombre.Text = "";

            switch (ddl.SelectedValue)
            {
                case "Todas": // Incompletas
                             // Session["EstatusHistorico"] = -1;
                    pnlNumSolicitud.Visible = false;
                    pnlNumeroRM.Visible = false;
                    pnlEstadoSol.Visible = false;
                    pnlSociedadRM.Visible = false;
                    pnlPersonaFRM.Visible = false;
                    pnlFechasCons.Visible = false;

                    //2022-01-25:
                    //new busqueda:
                  
                    var lData = tran.GetTransaccionesByFilter(user, "Todas", 9999, "", null, null, "");                   
                    rgridHistorico.Rebind();
                    rgridHistorico.DataSource = lData;
                    rgridHistorico.DataBind();
                    ddAdecuacion.AutoPostBack = true;


                    break;
                case "Fecha": // Ningunas


                    pnlNumeroRM.Visible = false;
                    pnlNumSolicitud.Visible = false;
                    pnlEstadoSol.Visible = false;
                    pnlSociedadRM.Visible = false;
                    pnlPersonaFRM.Visible = false;
                    pnlFechasCons.Visible = true;
                   
                    //2022-01-25:
                    //new busqueda:
                  
                    var lData1 = tran.GetTransaccionesByFilter(user, "Todas", 9999, "", null, null, "");
                    rgridHistorico.Rebind();
                    rgridHistorico.DataSource = lData1;
                    rgridHistorico.DataBind();
                    ddAdecuacion.AutoPostBack = true;


                    break;
                case "RM": // Todas
                           // Session["EstatusHistorico"] = 9999;
                    pnlNumeroRM.Visible = true;
                    pnlNumSolicitud.Visible = false;
                    pnlEstadoSol.Visible = false;
                    pnlSociedadRM.Visible = false;
                    pnlPersonaFRM.Visible = false;
                    pnlFechasCons.Visible = false;

                    
                    //2022-01-25:
                    //new busqueda:
                  
                    var lData2 = tran.GetTransaccionesByFilter(user, "Todas", 9999, "", null, null, "");
                    rgridHistorico.Rebind();
                    rgridHistorico.DataSource = lData2;
                    rgridHistorico.DataBind();
                    ddAdecuacion.AutoPostBack = true;

                    break;
                case "SolicitudId":
                    // Session["EstatusHistorico"] = 14;
                    pnlNumSolicitud.Visible = true;
                    pnlNumeroRM.Visible = false;
                    pnlEstadoSol.Visible = false;
                    pnlSociedadRM.Visible = false;
                    pnlPersonaFRM.Visible = false;
                    pnlFechasCons.Visible = false;

                    //2022-01-25:
                    //new busqueda:
                    var lData3 = tran.GetTransaccionesByFilter(user, "Todas", 9999, "", null, null, "");
                    rgridHistorico.Rebind();
                    rgridHistorico.DataSource = lData3;
                    rgridHistorico.DataBind();
                    ddAdecuacion.AutoPostBack = true;

                    break;
                case "Estado":
                    //      Session["EstatusHistorico"] = 18;
                    pnlSociedadRM.Visible = false;
                    pnlPersonaFRM.Visible = false;
                    pnlNumeroRM.Visible = false;
                    pnlNumSolicitud.Visible = false;
                    pnlEstadoSol.Visible = true;
                    pnlFechasCons.Visible = false;

                    //2022-01-25:
                    //new busqueda:
                    var lData4 = tran.GetTransaccionesByFilter(user, "Todas", 9999, "", null, null, "");
                    rgridHistorico.Rebind();
                    rgridHistorico.DataSource = lData4;
                    rgridHistorico.DataBind();
                    ddAdecuacion.AutoPostBack = true;


                    break;
                case "Sociedad":
                    // Session["EstatusHistorico"] = 1;
                    pnlSociedadRM.Visible = true;
                    pnlPersonaFRM.Visible = false;
                    pnlNumeroRM.Visible = false;
                    pnlNumSolicitud.Visible = false;
                    pnlEstadoSol.Visible = false;
                    pnlFechasCons.Visible = false;

                  
                    rgridHistorico.DataBind();

                    break;
                case "Persona":
                    // Session["EstatusHistorico"] = 1;
                    pnlPersonaFRM.Visible = true;
                    pnlSociedadRM.Visible = false;
                    pnlNumeroRM.Visible = false;
                    pnlNumSolicitud.Visible = false;
                    pnlEstadoSol.Visible = false;
                    pnlFechasCons.Visible = false;

                   
                    rgridHistorico.DataBind();
                    break;
            }

         //   rgridHistorico.DataBind(); on 2022-02-07
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Oficina.rgridEmp_ItemDataBound(object, GridItemEventArgs)'
        protected void rgridEmp_ItemDataBound(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Oficina.rgridEmp_ItemDataBound(object, GridItemEventArgs)'
        {

            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                var tipoSociedadId = ((System.Data.DataRowView)(item.DataItem)).Row["TipoSociedadId"].ToString();
                var numeroRegistro = ((System.Data.DataRowView)(item.DataItem)).Row["NumeroRegistro"].ToString();
                var camara = ((System.Data.DataRowView)(item.DataItem)).Row["CamaraId"].ToString();
                int tipoSociedad;
                int.TryParse(tipoSociedadId, out tipoSociedad);
                var lblFecha = (Label)item.FindControl("lblFechaConstitucion");
                var lblTipoSociedad = (Label)item.FindControl("lblTipoEntidad");
                var imgStatus = (Image)item.FindControl("EstadoImg");

                var repTipoSociedad = new DataAccess.EF.Repository<TipoSociedad, CamaraComunEntities>(new CamaraComunEntities());
                var tipoSociedadEtiqueta = repTipoSociedad.SelectByKey(TipoSociedad.PropColumns.TipoSociedadId, tipoSociedad);
                if (tipoSociedadEtiqueta != null)
                {
                    lblTipoSociedad.Text = tipoSociedadEtiqueta.Etiqueta.ToString();
                }

                if (tipoSociedad == 7)
                {
                    int numeroR;
                    int.TryParse(numeroRegistro, out numeroR);
                    var ctrlPersona = new SRM.PersonaFisicaController();
                    var personas = ctrlPersona.ObteneByRegistroCamara(numeroR, camara);
                    if (personas.Count == 0) lblFecha.Text = "N/A";
                    else
                    {
                        foreach (var empresa in personas)
                        {
                            if (empresa.Registros.FechaInicioOperacion != null)
                            {
                                DateTime date = (DateTime)empresa.Registros.FechaInicioOperacion;
                                lblFecha.Text = date.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                lblFecha.Text = "";
                            }
                        }
                    }
                }
                else
                {
                    int numeroR;
                    int.TryParse(numeroRegistro, out numeroR);
                    var ctrlSociedad = new SRM.SociedadesController();
                    var sociedades = ctrlSociedad.FetchByRegistroAndCamara(numeroR, camara);
                    if (sociedades.Count == 0) lblFecha.Text = "N/A";
                    else
                    {
                        foreach (var empresa in sociedades)
                        {
                            if (empresa.FechaConstitucion != null)
                            {
                                DateTime date = (DateTime)empresa.FechaConstitucion;
                                lblFecha.Text = date.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                lblFecha.Text = "";
                            }
                            switch (empresa.EstatusId)
                            {
                                case 1:
                                    imgStatus.ImageUrl = "/res/img/icons/bullet_green.png";
                                    break;
                                case 2:
                                    imgStatus.ImageUrl = "/res/img/icons/bullet_red.png";
                                    break;
                                case 3:
                                    imgStatus.ImageUrl = "/res/img/icons/bullet_black.png";
                                    break;
                                case 4:
                                    imgStatus.ImageUrl = "/res/img/icons/bullet_black.png";
                                    break;
                                case 5:
                                    imgStatus.ImageUrl = "/res/img/icons/bullet_black.png";
                                    break;
                            }

                            imgStatus.ToolTip = empresa.Estatus;
                        }
                    }
                }

            }
            if (!(e.Item is GridPagerItem)) return;

            var pager = (GridPagerItem)e.Item;
            var lbl = (Label)pager.FindControl("ChangePageSizeLabel");
            lbl.Text = "Tamaño de página: ";
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Oficina.rgridPendientes_ItemDataBound(object, GridItemEventArgs)'
        protected void rgridPendientes_ItemDataBound(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Oficina.rgridPendientes_ItemDataBound(object, GridItemEventArgs)'
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                var transId = ((System.Data.DataRowView)(item.DataItem)).Row["TransaccionId"].ToString();
                var tipoSociedadId = ((System.Data.DataRowView)(item.DataItem)).Row["TipoSociedadId"].ToString();
                var numeroRegistro = ((System.Data.DataRowView)(item.DataItem)).Row["NumeroRegistro"].ToString();
                var camara = ((System.Data.DataRowView)(item.DataItem)).Row["CamaraId"].ToString();
                int tipoSociedad;
                int.TryParse(tipoSociedadId, out tipoSociedad);
                var lblFecha = (Label)item.FindControl("lblFechaConstitucion");
                var lblTipoSociedad = (Label)item.FindControl("lblTipoEntidad");
                var imgStatus = (Image)item.FindControl("EstadoImg");

                var repTipoSociedad = new DataAccess.EF.Repository<TipoSociedad, CamaraComunEntities>(new CamaraComunEntities());
                var tipoSociedadEtiqueta = repTipoSociedad.SelectByKey(TipoSociedad.PropColumns.TipoSociedadId, tipoSociedad);
                if (tipoSociedadEtiqueta != null)
                {
                    lblTipoSociedad.Text = tipoSociedadEtiqueta.Etiqueta.ToString();
                }

                if (tipoSociedad == 7)
                {
                    int numeroR;
                    int.TryParse(numeroRegistro, out numeroR);
                    var ctrlPersona = new SRM.PersonaFisicaController();
                    var personas = ctrlPersona.ObteneByRegistroCamara(numeroR, camara);
                    if (personas.Count == 0) lblFecha.Text = "N/A";
                    else
                    {
                        foreach (var empresa in personas)
                        {
                            if (empresa.Registros.FechaInicioOperacion != null)
                            {
                                DateTime date = (DateTime)empresa.Registros.FechaInicioOperacion;
                                lblFecha.Text = date.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                lblFecha.Text = "";
                            }
                        }
                    }
                }
                else
                {
                    int numeroR;
                    int.TryParse(numeroRegistro, out numeroR);
                    var ctrlSociedad = new SRM.SociedadesController();
                    var sociedades = ctrlSociedad.FetchByRegistroAndCamara(numeroR, camara);
                    if (sociedades.Count == 0) lblFecha.Text = "N/A";
                    else
                    {
                        foreach (var empresa in sociedades)
                        {
                            if (empresa.FechaConstitucion != null)
                            {
                                var date = (DateTime)empresa.FechaConstitucion;
                                lblFecha.Text = date.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                lblFecha.Text = "";
                            }
                        }
                    }
                }

            }
            if (!(e.Item is GridPagerItem)) return;

            var pager = (GridPagerItem)e.Item;
            var lbl = (Label)pager.FindControl("ChangePageSizeLabel");

            lbl.Text = "Tamaño de página: ";
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Oficina.rgridTransaccionesDevueltas_NeedDataSource(object, GridNeedDataSourceEventArgs)'
        protected void rgridTransaccionesDevueltas_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Oficina.rgridTransaccionesDevueltas_NeedDataSource(object, GridNeedDataSourceEventArgs)'
        {
            var userId = User.Identity.Name.ToLower();
            var transacciones = new OFV.TransaccionesController().ObtenerTransaccionesProblema(userId);
            rgridTransaccionesDevueltas.DataSource = "";
            rgridTransaccionesDevueltas.DataSource = transacciones;
            rgridTransaccionesDevueltas.VirtualItemCount = transacciones.Count;
        }

        //Transacciones Pagos Boton BHD:
        public void getWhileLoopData()
        {

            string htmlStr = "";

            var userId = User.Identity.Name.ToLower();

            //buscar transacciones pendientes:
            var LTransaccionesBHD = new OFV.TransaccionesController().ObtenerTransaccionesBHD(userId);
            //buscar transacciones pendientes <> 1:
            var LTransaccionesBHDDist1 = new OFV.TransaccionesController().ObtenerTransaccionesBHD(userId);

            List<TransaccionesEmpBHD> people = new List<TransaccionesEmpBHD>();

            foreach (var item in LTransaccionesBHD)
            {
                //para mandar el token priemro de cada transaccion: 
                string URL = ConfigurationManager.AppSettings["urltokenunico"].ToString();
                string DATA2 = @"{
                ""scope"": ""pagosSometidos"",
                ""clientId"": ""clientIdString"",
                ""clientSecret"": ""clientSecretString"",
                ""channel"": ""BDP"",
                ""transactionId"": " + item.TransactionId + "}";

                DATA2 = DATA2.Replace("clientIdString", ConfigurationManager.AppSettings["clientId"].ToString());
                DATA2 = DATA2.Replace("clientSecretString", ConfigurationManager.AppSettings["clientSecret"].ToString());


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = DATA2.Length;

                var test = request.GetResponseAsync();


                using (Stream webStream = request.GetRequestStream())

                using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
                {
                    requestWriter.Write(DATA2);
                }

                string ResultadoBanner = "";
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string response = responseReader.ReadToEnd();
                    string[] words = response.Split('\"');
                    ResultadoBanner = words[3];
                }

                Task<string> ff = TestMethodAsync(item.TransactionId.Trim(), item.SolicitudId.Value, ResultadoBanner);


                people.Add(new TransaccionesEmpBHD() { Id = item.Id, reference = item.reference, TransactionId = item.TransactionId, EstadoString = "Pendiente" });
            }

            foreach (var item in LTransaccionesBHD)
            {
                if (item.Estatus == 3)
                {
                    people.Add(new TransaccionesEmpBHD() { Id = item.Id, reference = item.reference, TransactionId = item.TransactionId, EstadoString = "Reaperturar" });
                }
                if (item.Estatus == 2)
                {
                    people.Add(new TransaccionesEmpBHD() { Id = item.Id, reference = item.reference, TransactionId = item.TransactionId, EstadoString = "Completada" });
                }

            }

            //if (!IsPostBack)
            //{
            //    this.gvPendientesAutorizar.DataSource = people;
            //    this.gvPendientesAutorizar.DataBind();

            //}
            //else
            //{
            //    this.gvPendientesAutorizar.DataSource = people;
            //    this.gvPendientesAutorizar.DataBind();
            //}


            // return htmlStr;
        }


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionBHDEmpresa.ResultadoPago(string, string, string)'
        public void ResultadoPago(string Referencia, string transaccionid, string token)
        {
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionBHDEmpresa.ResultadoPago(string, string, string)'


            string URL = ConfigurationManager.AppSettings["urlConsultar"].ToString();


            string DATA3 = @"{
                ""transactionId"": ""transactionIdVariable"",
                ""channel"": ""BDP"",
                ""reference"": ""referenceVariable"",
                ""providerId"": ""providerIdString"",
                ""serviceId"": ""serviceIdString"" };";

            var tran = transaccionid.Trim();
            var refe = Referencia.Trim();

            DATA3 = DATA3.Replace("transactionIdVariable", tran);
            DATA3 = DATA3.Replace("referenceVariable", refe);
            DATA3 = DATA3.Replace("providerIdString", ConfigurationManager.AppSettings["providerId"].ToString());
            DATA3 = DATA3.Replace("serviceIdString", ConfigurationManager.AppSettings["serviceId"].ToString());


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = DATA3.Length;

            var test = request.GetResponseAsync();
            request.Headers.Add("Authorization", token.Trim());

            using (Stream webStream = request.GetRequestStream())

            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(DATA3);
            }


            WebResponse webResponse = request.GetResponse();


            using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
            using (StreamReader responseReader = new StreamReader(webStream))
            {
                string response = responseReader.ReadToEnd();
                string[] words = response.Split('\"');
                var ResultadoBanner = words[3];
            }
        }

        //---------------------
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RevisionBHDEmpresa.TestMethodAsync(string, string, string)'
        public async Task<string> TestMethodAsync(string transaccionid, int referencia, string token)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RevisionBHDEmpresa.TestMethodAsync(string, string, string)'
        {

            string URL = Helper.urlBHDConsultar; // "https://api-sqa.bhdleon.com.do/bhdleon/boton/v2/clientes/pagos/sometidos/consultar";
            var ResultadoPago = "";

            var userId = User.Identity.Name.ToLower();

            try
            {
                var apicallObject = new
                {
                    transactionId = transaccionid,
                    channel = "BDP",
                    reference = referencia.ToString(),
                    providerId = Helper.providerIdBHD, // "90909106",
                    serviceId = Helper.serviceIdBHD,// "123456803",
                };

                if (apicallObject != null)
                {
                    var bodyContent = JsonConvert.SerializeObject(apicallObject);
                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(bodyContent.ToString(), Encoding.UTF8, "application/json");
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token); // _token = access token

                        var response = await client.PostAsync(URL, content); // _url =api endpoint url

                        if (response != null)
                        {
                            var jsonString = await response.Content.ReadAsStringAsync();
                            try
                            {
                                string[] words = jsonString.Split('\"');
                                ResultadoPago = words[37];

                                //  if (ResultadoPago == "001")                                    
                                if (ResultadoPago == Helper.IdEstadoBHDEmpresarial)
                                {
                                    using (var db = new CamaraWebsiteEntities())
                                    {
                                        //buscar transacciones pendientes <> 1:
                                        var LTransaccionesBHDDist1 = new OFV.TransaccionesController().LTransaccionesBHDById(userId, referencia);
                                       
                                        if (LTransaccionesBHDDist1 != null)
                                        {
                                            //   result.Estatus = 3;
                                            // db.SaveChanges();

                                            new OFV.TransaccionesController().ActualizarEstadosBHD(referencia, Helper.IdEstadoBHDLocal); //ver porque el estado 3
                                        }
                                    }

                                }
                                else //008 //rechazado
                                    if (ResultadoPago == Helper.IdEstadoBHDEmpresarialRechazo)
                                {
                                    using (var db = new CamaraWebsiteEntities())
                                    {
                                        //buscar transacciones pendientes <> 1:
                                        var LTransaccionesBHDDist1 = new OFV.TransaccionesController().LTransaccionesBHDById(userId, referencia);
                                      

                                        if (LTransaccionesBHDDist1 != null)
                                        {

                                            new OFV.TransaccionesController().ActualizarEstadosBHD(referencia, Helper.IdEstadoBHDLocalRechazado); //ver porque el estado 3
                                        }
                                    }

                                }


                                return ResultadoPago.ToString();
                            }
                            catch (Exception e)
                            {
                                Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                                throw e;
                            }
                        }
                    }
                }

                return null;

            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                throw ex;
               
            }
        }


   
        //Buscar:          

        protected void GetByFilter(object sender, EventArgs e)
        {
           try
            { 

            var user = Membership.GetUser(User.Identity.Name);
            var buscarPor = ddAdecuacion.SelectedValue;
            var ValorBuscar = 0;
            var _nombreSoc = "";
            var _tipoSociedad = "";

            DateTime _fDesde = Convert.ToDateTime(DateTime.Now.Date); //mm/dd/yyyy
            DateTime _fHasta = Convert.ToDateTime(DateTime.Now.Date);//mm/dd/yyyy

            var _tipoSoc = ddlTipoSociedad.SelectedValue;

            if (buscarPor == "RM" && _tipoSoc == "-1")
                return;


            switch (buscarPor)
            {
                case "Todas":
                             
                    break;
                case "Fecha":

                  
                    _fDesde = Convert.ToDateTime(dtFechaDesde.SelectedDate); //mm/dd/yyyy
                     _fHasta = Convert.ToDateTime(dtFechaHasta.SelectedDate);//mm/dd/yyyy

                    break;
                case "RM":

                    ValorBuscar = Convert.ToInt32(txtNumeroRM.Text);
                    _tipoSociedad = ddlTipoSociedad.SelectedValue;

                    break;
                case "SolicitudId":
                    ValorBuscar = Convert.ToInt32(txtNumSolicitud.Text);
                    break;
                case "Estado":
                 
                    break;
                case "Sociedad":
                    _nombreSoc = txtSociedadNombre.Text;

                    break;
                case "Persona":
                    _nombreSoc = txtPersonaFisicaNombre.Text;
                    break;
            }

           
            //new 2022-02-07:
            List<Transacciones> ListaTransaccionSRM = new List<Transacciones>();
            rgridHistorico.Rebind();
            rgridHistorico.DataSource = ListaTransaccionSRM;
            rgridHistorico.DataBind();
            ddAdecuacion.AutoPostBack = true;


            TransaccionesController tran = new TransaccionesController();
            var lData = tran.GetTransaccionesByFilter(user.UserName, buscarPor,
                ValorBuscar, _nombreSoc, _fDesde, _fHasta, _tipoSociedad);

            // rgridHistorico.DataSource = null;
            rgridHistorico.Rebind();
            rgridHistorico.DataSource = lData;
            rgridHistorico.DataBind();

            ddAdecuacion.AutoPostBack = true;


            } //errores
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

            }

        }

       
        protected void ddlEstadoSol_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 

            //new 2022-02-07:
            List<Transacciones> ListaTransaccionSRM = new List<Transacciones>();
            rgridHistorico.Rebind();
            rgridHistorico.DataSource = ListaTransaccionSRM;
            rgridHistorico.DataBind();
            ddAdecuacion.AutoPostBack = true;

            var user = Membership.GetUser(User.Identity.Name);

            var _Estadoid = !string.IsNullOrEmpty(ddlEstadoSol.SelectedValue) ? Convert.ToInt32(ddlEstadoSol.SelectedValue) : 0;
            TransaccionesController transaccion = new TransaccionesController();
            var lData = transaccion.GetTransaccionesByFilter(user.UserName, "Estado", _Estadoid);
                       
            rgridHistorico.DataSource = lData;
            rgridHistorico.DataBind();
        
            ddAdecuacion.AutoPostBack = true;

            } //errores
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

            }

        }

        public void GetDataEstado()
        {
            try
            { 
            if (ddlEstadoSol != null)
            {

                //new 2022-02-07:
                //List<Transacciones> ListaTransaccionSRM = new List<Transacciones>();
                //rgridHistorico.Rebind();
                //rgridHistorico.DataSource = ListaTransaccionSRM;
                //rgridHistorico.DataBind();
                //ddAdecuacion.AutoPostBack = true;


                var user = Membership.GetUser(User.Identity.Name);
                var _Estadoid = !string.IsNullOrEmpty(ddlEstadoSol.SelectedValue) ? Convert.ToInt32(ddlEstadoSol.SelectedValue) : 0;

                TransaccionesController transaccion = new TransaccionesController();
                var lData = transaccion.GetTransaccionesByFilterPaging(user.UserName, "Estado", _Estadoid);
                               
                rgridHistorico.DataSource = lData;             

                ddAdecuacion.AutoPostBack = true;
            }

            } //errores
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);               

            }
        }

        protected void ddlTipoSociedad_SelectedIndexChanged(object sender, EventArgs e)
        {           
            txtNumeroRM.Text = "";

            rgridHistorico.DataBind();

        }

       

        protected void rgridHistorico_PageIndexChanged(object source, GridPageChangedEventArgs e)
        {
            try
            { 

            var user = Membership.GetUser(User.Identity.Name);

            var buscarPor = ddAdecuacion.SelectedValue;
            var ValorBuscar = 0;
            var _nombreSoc = "";
            var _tipoSociedad = "";

            DateTime _fDesde = Convert.ToDateTime(DateTime.Now.Date); //mm/dd/yyyy
            DateTime _fHasta = Convert.ToDateTime(DateTime.Now.Date);//mm/dd/yyyy               

            switch (buscarPor)
            {
                case "Todas": // Incompletas

                    //2022-01-25:
                    //new busqueda:
               //     var user = User.Identity.Name.ToLower();
                    TransaccionesController tran = new TransaccionesController();
                    var lData = tran.GetTransaccionesByFilter(user.UserName, "Todas", 9999, "", null, null, "");
                    rgridHistorico.Rebind();
                    rgridHistorico.DataSource = lData;
                    rgridHistorico.DataBind();
                    ddAdecuacion.AutoPostBack = true;

                    break;
                case "Fecha": // Ningunas
                    _fDesde = Convert.ToDateTime(dtFechaDesde.SelectedDate); //mm/dd/yyyy
                    _fHasta = Convert.ToDateTime(dtFechaHasta.SelectedDate);//mm/dd/yyyy
                    break;
                case "RM": // rm
                  
                    ValorBuscar = string.IsNullOrEmpty(txtNumeroRM.Text) ? 0 : Convert.ToInt32(txtNumeroRM.Text);
                    _tipoSociedad = ddlTipoSociedad.SelectedValue;

                    break;
                case "SolicitudId":
                    ValorBuscar = string.IsNullOrEmpty(txtNumSolicitud.Text) ? 0: Convert.ToInt32(txtNumSolicitud.Text);
                    break;
                case "Estado":

                    GetDataEstado();

                    break;
                case "Sociedad":
                    _nombreSoc = txtSociedadNombre.Text;

                    break;
                case "Persona":
                    _nombreSoc = txtPersonaFisicaNombre.Text;
                    break;
            }

            if (buscarPor != "Estado")
            {
                TransaccionesController tran = new TransaccionesController();
                var lData = tran.GetTransaccionesByFilter(user.UserName, buscarPor, ValorBuscar, _nombreSoc, _fDesde, _fHasta, _tipoSociedad);
                // rgridHistorico.DataSource = null;
                rgridHistorico.Rebind();
                rgridHistorico.DataSource = lData;
                rgridHistorico.DataBind();

                ddAdecuacion.AutoPostBack = true;
            }

            } //errores
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

            }

        }

        protected void dtFechaHasta_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {

        }
    }
}