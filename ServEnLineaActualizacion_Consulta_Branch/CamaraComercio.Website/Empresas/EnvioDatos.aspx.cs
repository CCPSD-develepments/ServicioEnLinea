using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.Website.Helpers;
using CamaraComercio.DataAccess.EF.SRM;
using CamaraComercio.Website.WSShareBase;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web;
using Telerik.Web.UI;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace CamaraComercio.Website.Empresas
{
    ///<summary>
    /// Página para el envío de datos a las Cámaras
    ///</summary>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class EnvioDatos : EnvioDatosPage
    {
#pragma warning disable CS0169 // The field 'EnvioDatos.totalFactura' is never used
        private decimal totalFactura;
#pragma warning restore CS0169 // The field 'EnvioDatos.totalFactura' is never used
#pragma warning disable CS0414 // The field 'EnvioDatos.CertificacionId' is assigned but its value is never used
        private static int CertificacionId = 7;
#pragma warning restore CS0414 // The field 'EnvioDatos.CertificacionId' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'EnvioDatos.CopiaCertificadaId' is assigned but its value is never used
        private static int CopiaCertificadaId = 39;
#pragma warning restore CS0414 // The field 'EnvioDatos.CopiaCertificadaId' is assigned but its value is never used

        /// <summary>
        /// Contiene el Id de la Camara.
        /// </summary>
        protected new String CamaraId
        {
            get
            {
                if (Session["CamaraId"] == null)
                    Session["CamaraId"] = String.Empty;

                return Session["CamaraId"].ToString();
            }
            set
            {
                Session["CamaraId"] = value;
            }
        }
#pragma warning disable CS0109 // The member 'EnvioDatos.CantidadDocaSubir' does not hide an accessible member. The new keyword is not required.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.CantidadDocaSubir'
        protected new int CantidadDocaSubir
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.CantidadDocaSubir'
#pragma warning restore CS0109 // The member 'EnvioDatos.CantidadDocaSubir' does not hide an accessible member. The new keyword is not required.
        {
            get
            {
                if (Session["CantidadDocaSubir"] == null)
                    Session["CantidadDocaSubir"] = 0;

                return (int)Session["CantidadDocaSubir"];
            }
            set
            {
                Session["CantidadDocaSubir"] = value;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.DocSeleccionados'
        protected List<int?> DocSeleccionados { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.DocSeleccionados'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.Page_Load(object, EventArgs)'
        {
            if (Page.IsPostBack) return;

            this.hfSessionID.Value = this.Session.SessionID;
            var strNumSolicitud = Request.QueryString["nSolicitud"];

            if (!String.IsNullOrEmpty(strNumSolicitud))
            {
                hfsolicitudID.Value = strNumSolicitud;
                hfusuarioID.Value = User.Identity.Name.ToLower();

                //buscar el servicioid y el tiposociedadid
                int nSolicitud;
                if (!Int32.TryParse(strNumSolicitud, out nSolicitud))
                    SolicitudInvalidad();

                //Transaccion y Hidden Fields
                var trans = TransaccionesController.GetTransaccionById(nSolicitud);
                //Tipo Sociedad ID
                if (trans.TipoSociedadId == 0)
                    trans.TipoSociedadId = 2;

                //  var dbUsers = new DataAccess.EF.Membership.CamaraWebsiteAccountsEntities();
                using (var dbUsers = new DataAccess.EF.Membership.CamaraWebsiteAccountsEntities())
                {

                    var uHijos = dbUsers.ViewProfileProperties
                                .Where(c => c.UsuarioPadre == User.Identity.Name)
                                .ToList().Select(c => c.UserName.ToLower());

                    if (trans != null)
                    {
                        if (trans.UserName != User.Identity.Name.ToLower() && !uHijos.Contains(trans.UserName.ToLower()))
                        {
                            Session["ErrorMessage"] = "Usted no puede enviar datos de una solicitud inexistente.";
                            Response.Redirect("~/Empresas/Oficina.aspx");
                        }

                        LoadDocSeleccionados(nSolicitud);
                        CantidadDocaSubir = CalcularDocparaSubir(nSolicitud);

                        lblNumSolicitudTitulo.Text = lblNumSolicitud.Text = trans.TransaccionId.ToString();
                        this.hfServicioId.Value = trans.ServicioId.ToString();
                        this.hfTipoSociedadId.Value = trans.TipoSociedadId.ToString();

                        this.CamaraId = trans.CamaraId;

                        var comun = new CamaraComunEntities();
                        var vistaDocumentoReq = comun.ServicioDocumentoRequeridoComentario.FirstOrDefault(x => x.ServicioId == trans.ServicioId && x.TipoSociedadId == trans.TipoSociedadId);
                        var comentario = string.Empty;
                        if (vistaDocumentoReq != null) comentario = !string.IsNullOrWhiteSpace(vistaDocumentoReq.ComentarioWeb) ? vistaDocumentoReq.ComentarioWeb : "";
                        if (!string.IsNullOrWhiteSpace(comentario))
                        {
                            pnlComentarioServicio.Visible = true;
                            lblMensaje.Visible = true;
                            lblMensaje.Text = comentario;
                        }

                        LogTransaccionesMethods.GrabarLogTransacciones(trans.TransaccionId, Request.RawUrl, false, User.Identity.Name.ToLower());
                    }
                    else
                        SolicitudInvalidad();

                    odsDocsRequeridos.DataBind();
                    //if (CantidadDocaSubir != rgriddocumentosEnviados.Items.Count)
                    //{
                    //    divUpload.Visible = true;
                    //}
                    //else if (CantidadDocaSubir == rgriddocumentosEnviados.Items.Count)
                    //{
                    //    divUpload.Visible = false;
                    //}

                    //var repDocumentos = new Comun.TipoDocumentoRepository();
                    //var docList = repDocumentos.SelectAll(true).Distinct().ToList();
                    //this.ddlTipoDocumento.BindCollection(docList,
                    //    Comun.TipoDocumento.PropColumns.TipoDocumentoId,
                    //    Comun.TipoDocumento.PropColumns.Nombre);
                }
            }
            else
            {
                ErrorMessage = "Transacción no existe.";
                Response.Redirect("Oficina.aspx");
            }
            
        }


        private void SolicitudInvalidad()
        {
            Session["ErrorMessage"] = "Solicitud no Existe. Por favor verificar y trate de nuevo.";
            Response.Redirect("~/Empresas/Oficina.aspx");
        }

        private void LoadDocSeleccionados(int transaccionId)
        {
            var db = new CamaraWebsiteEntities();
            this.DocSeleccionados =
                db.TransaccionesDocumentos.Where(a => a.TransaccionId == transaccionId).Select(a => a.TipoDocumentoId).
                    ToList();
        }


        //Cantidad de documentos para subir
        private int CalcularDocparaSubir(int transaccionId)
        {
            int Cantidad = 0;
            var tbTranDocSel = new CamaraWebsiteEntities();
            var list = tbTranDocSel.TransaccionDocSeleccionado.Where(x => x.TransaccionId == transaccionId);

            foreach (var item in list)
            {
                if (item.TipoDocumentoId == 1551) Cantidad += item.CantidadCopia;
                else Cantidad++;
            }
            return Cantidad;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.rgriddocumentos_ItemDataBound(object, GridItemEventArgs)'
        protected void rgriddocumentos_ItemDataBound(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.rgriddocumentos_ItemDataBound(object, GridItemEventArgs)'
        {
            if (e.Item is GridDataItem)
            {
                int nSolicitud;
                int.TryParse(Request.QueryString["nSolicitud"], out nSolicitud);
                GridDataItem item = e.Item as GridDataItem;
                var data = (item.DataItem as TipoDocumento);
                var cant = new CamaraWebsiteEntities().TransaccionDocSeleccionado.FirstOrDefault(x => x.TransaccionId == nSolicitud && x.TipoDocumentoId == data.TipoDocumentoId);
                var lblCant = (Label)e.Item.FindControl("cantCopiasDocReq");
                lblCant.Text = string.Format("{0}", cant.TipoDocumentoId == 1551 ? cant.CantidadCopia : 1);

            }

            if (e.Item is GridPagerItem)
            {
                var pager = (GridPagerItem)e.Item;
                var lbl = (Label)pager.FindControl("ChangePageSizeLabel");
                lbl.Text = "Tamaño de página: ";
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.rgriddocumentosEnviados_ItemDataBound(object, GridItemEventArgs)'
        protected void rgriddocumentosEnviados_ItemDataBound(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.rgriddocumentosEnviados_ItemDataBound(object, GridItemEventArgs)'
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                var box = (CheckBox)item.FindControl("chkFirmasDigital");
                var HelpImg = (System.Web.UI.WebControls.Image)item.FindControl("HelpImg");

                var data = (e.Item.DataItem as TransaccionesDocumentos);
                HelpImg.ToolTip = Helper.TooltipFirmaDigitalEnvioDatos;
                box.Checked = data.FirmaDigital.HasValue ? data.FirmaDigital.Value : false;
                if (data.TipoDocumentoId == 1560)
                {
                    var ddlTipoDocumento = (DropDownList)item.FindControl("ddlTiposDocumentos");
                    ddlTipoDocumento.Enabled = false;
                    item.FindControl("btnDeleteDocument").Visible = false;
                }

                var docExist = new CamaraWebsiteEntities().TransaccionesDocumentos.Any(x => x.TransaccionId == data.TransaccionId && x.TipoDocumentoId == 1560);

                if (data.TipoDocumentoId != 1560)
                {
                    var ddlTipoDocumento = (DropDownList)item.FindControl("ddlTiposDocumentos");
                    for (int i = 0; ddlTipoDocumento.Items.Count > i; i++)
                    {
                        if (docExist && ddlTipoDocumento.Items[i].Value.Equals("1560"))
                        {
                            ddlTipoDocumento.Items[i].Enabled = false;
                        }
                    }
                }

            }

            if (!(e.Item is GridPagerItem)) return;
            var pager = (GridPagerItem)e.Item;
            var lbl = (Label)pager.FindControl("ChangePageSizeLabel");
            lbl.Text = "Tamaño de página: ";


        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.rgriddocumentosEnviados_ItemCreated(object, GridItemEventArgs)'
        protected void rgriddocumentosEnviados_ItemCreated(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.rgriddocumentosEnviados_ItemCreated(object, GridItemEventArgs)'
        {
            if (!(e.Item is GridDataItem)) return;

            var dataItem = (e.Item.DataItem as TransaccionesDocumentos);
            if (dataItem == null) return;
            DropDownList control = e.Item.FindControl("ddlTiposDocumentos") as DropDownList;
            CheckBox controlFirma = e.Item.FindControl("chkFirmasDigital") as CheckBox;
            if (control != null)
            {

                control.SelectedValue = dataItem.TipoDocumentoId.HasValue
                                            ? dataItem.TipoDocumentoId.Value.ToString()
                                            : null;
                if (dataItem.TipoDocumentoId == 1560)
                {
                    controlFirma.Enabled = false;
                }
            }

        }

        private int ObtenerTipoServicio(int servicioId)
        {
            var dbComun = new CamaraComunEntities();
            var servicio = dbComun.Servicio.FirstOrDefault(t => t.ServicioId == servicioId);

            if (servicio != null) return servicio.TipoServicioId;

            return 0;
        }

        /// <summary>
        /// Crea una Transaccion en el SRM.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEnviarTransaccion_Click(object sender, EventArgs e)
        {

            if (!Page.IsValid || !IsValido()) return;
            //Si los documentos fueron cargados exitosamente, entonces enviar a la pantalla de pago.

#if !DEBUG
            var res = ValidateDocuments();
            if (res.Count != 0)
            {
                string str = string.Empty;
                foreach (var r in res)
                    str += string.Format("{0}, ", r);
                Master.ShowMessageError(string.Format("Alguno de los archivos no tiene una firma digital valida. Favor revisar los archivos {0}. Puede continuar ", str));
                return;
            }
#endif

            // Agregar valor en transaccionDocumento
            var documentoActualizar = new CamaraWebsiteEntities();
            var db = new CamaraComunEntities();
            int nSolicitud;
            Int32.TryParse(Request.QueryString["nSolicitud"], out nSolicitud);
            var docSelCant = documentoActualizar.TransaccionesDocumentos.Where(x => x.TransaccionId == nSolicitud);
            var docSel = documentoActualizar.TransaccionDocSeleccionado.Where(x => x.TransaccionId == nSolicitud);

            var cantidadTipoArchivo = docSel.Count();
            if (cantidadTipoArchivo > rgriddocumentosEnviados.Items.Count)
            {
                Master.ShowMessageError("Debe subir por lo menos uno de cada tipo de documento");
                return;
            }

            foreach (var item in docSelCant)
            {
                var count = documentoActualizar.TransaccionesDocumentos.Where(x => x.TransaccionId == item.TransaccionId
                                && x.TipoDocumentoId == item.TipoDocumentoId /*&& x.TipoDocumentoId != 1551*/).ToList();
                var nombreDoc = db.TipoDocumento.FirstOrDefault(x => x.TipoDocumentoId == item.TipoDocumentoId);
                var comparar = item.TipoDocumentoId == 1551
                    ? docSel.FirstOrDefault(x => x.TipoDocumentoId == item.TipoDocumentoId).CantidadCopia : 1;
                if (count.Count() > comparar)
                { 
                    var tranDocumento = documentoActualizar.TransaccionDocSeleccionado
                        .FirstOrDefault(x => x.TransaccionId == item.TransaccionId && x.TipoDocumentoId == item.TipoDocumentoId);
                    string result = string.Format("Solo puede subir {0} archivos del tipo de documento {1}"
                        , tranDocumento.TipoDocumentoId == 1551 ? tranDocumento.CantidadCopia : 1, nombreDoc.Nombre);
                    Master.ShowMessageError(result);
                    return;
                }
            }

            foreach (var item in docSelCant)
            {
                var TransaccionesDocumentos = documentoActualizar.TransaccionDocSeleccionado.FirstOrDefault(x => x.TransaccionId == item.TransaccionId && x.TipoDocumentoId == item.TipoDocumentoId);
                var nombreDoc = db.TipoDocumento.FirstOrDefault(x => x.TipoDocumentoId == item.TipoDocumentoId);
                item.CantidadCopia = TransaccionesDocumentos.TipoDocumentoId == 1551 ? 1 : TransaccionesDocumentos.CantidadCopia;
                item.CantidadOriginal = TransaccionesDocumentos.CantidadOriginal;
                item.Descripcion = nombreDoc.Nombre;

            }
            documentoActualizar.SaveChanges();


            //GrabarFormularioSolicitud(this.IdTransaciones);
            var val = CrearDocumentosEnShareBase();
            if (!val)
            {
                Master.ShowMessageError("Error al cargar los documentos en ShareBase, revise que el documento que intenta cargar esté en el formato debido.");
                return;
            }
            Master.ShowMessageError("Succes!");

            Response.Redirect("~/TarjetaCredito/PagosTarjeta.aspx" + DefaultQueryString);

            #region comentarioBtnEnviar
            //var db = new CamaraWebsiteEntities();
            //var transaccion = db.Transacciones.FirstOrDefault(t => t.TransaccionId == this.IdTransaciones);
            //switch (transaccion.TipoSociedadId)
            //{
            //    case 1:
            //        Response.Redirect("~/Formularios/SociedadAnonima.aspx" + DefaultQueryString);
            //        break;
            //    case 2:
            //        Response.Redirect("~/Formularios/SociedadResponsabilidadLimitada.aspx" + DefaultQueryString);
            //        break;
            //    case 3:
            //        Response.Redirect("~/Formularios/SociedadNombreColectivo.aspx" + DefaultQueryString);
            //        break;
            //    case 4:
            //        Response.Redirect("~/Formularios/SociedadCSimple.aspx" + DefaultQueryString);
            //        break;
            //    case 5:
            //        Response.Redirect("~/Formularios/SociedadCPorAcciones.aspx" + DefaultQueryString);
            //        break;
            //    case 16:
            //        Response.Redirect("~/Formularios/SociedadAnonimasSimplificada.aspx" + DefaultQueryString);
            //        break;
            //    case 13:
            //        Response.Redirect("~/Formularios/SociedadExtranjera.aspx" + DefaultQueryString);
            //        break;
            //    default:
            //        break;
            //}
            #endregion

            #region Envio de datos al srm
            //Creating Repositories
            //var context = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(CamaraId);
            //var repTransaccion = new SRM.TransaccionesRepository(context);
            //var repSubTransaccion = new SRM.SubTransaccionesRepository(context);
            //var repFacturas = new SRM.FacturasSrmRepository(context);
            //var repDetalle = new SRM.TransaccionDetalleRepository(context);
            //var repFormasPago = new SRM.FormaPagoRepository(context);
            //var repUsuario = new SRM.UsuarioRepository(context);
            //var repDocumentos = new SRM.DocumentosTransaccionesRepository(context);
            //var repTransaccinesSociedades = new SRM.TransaccionesSociedadesRepository(context);
            //var repSeguimiento = new DataAccess.EF.Repository<SRM.SeguimientoTransacciones, SRM.CamaraSRMEntities>(context);

            //var dbWebSite = new CamaraWebsiteEntities();
            //var dbComun = new CamaraComunEntities();

            ////Variable usada para reglas de calculo en las subtransacciones
            //var considerarMods = true;

            ////Objetos de la transaccion en website necesarios para crear la información dentro del SRM
            //var tranId = int.Parse(hfsolicitudID.Value);
            //var trans = dbWebSite.Transacciones.Where(a => a.TransaccionId == tranId).FirstOrDefault();
            //var factura = dbWebSite.Facturas.Where(f => f.TransaccionId == tranId).FirstOrDefault();
            //var tipoSociedad = dbComun.TipoSociedad.FirstOrDefault(t => t.TipoSociedadId == trans.TipoSociedadId);
            // var esCertificacion = Helper.HabilarPagoTarjeta(trans.ServicioId);
            // var estatusId = ObtenerTipoServicio(trans.ServicioId) == CertificacionId
            //                 ? Helper.EstatusTransIdCertificacion
            //                 : Helper.EstatusTransIdAnalisis;

            ////Validando factura este pagada.
            //if (!trans.bPagada && trans.ServicioId != Helper.ServicioInclusionId)
            //{
            //    Master.ShowMessageError("La factura debe ser pagada en su totalidad para poder enviar la solicitud.");
            //    return;
            //}
            //if (factura == null && trans.ServicioId != Helper.ServicioInclusionId)
            //{
            //    Master.ShowMessageError("Hay un error con los datos de su factura. Por favor contactar al personal de soporte");
            //    return;
            //}

            //var servicio = dbComun.Servicio.Where(a => a.ServicioId == trans.ServicioId).FirstOrDefault();

            //#region Transaccion principal

            //var tipoSer = ObtenerTipoServicio(trans.ServicioId);
            //var esCertOCopiaCert = (tipoSer == CertificacionId || tipoSer == CopiaCertificadaId);
            ////Creando Transaccion Principal
            //var transSrm = new Transacciones
            //                   {
            //                       TipoServicioId = servicio.ServicioId,
            //                       TipoTransaccionId = servicio.TipoServicioId,
            //                       Fecha = trans.Fecha,
            //                       RNCSolicitante = trans.RNCSolicitante,
            //                       NombreContacto = this.txtPersonaContacto.Text.Length > 0 ? this.txtPersonaContacto.Text : trans.NombreContacto,
            //                       TelefonoContacto = this.txtTelefonoContacto.Text.Length > 0 ? this.txtTelefonoContacto.Text : trans.TelefonoContacto,
            //                       Salicitante = trans.Solicitante,
            //                       Servicio = servicio.Descripcion,
            //                       Estatus = esCertOCopiaCert ? Helper.EstatusTransIdCertificacion : Helper.EstatusTransIdAnalisis,
            //                       DesdeOfv = true,
            //                       Tipo = trans.TipoSociedadId == Helper.TipoSociedadPersonaFisica
            //                                  ? 1
            //                                  : 0,
            //                       Prioridad = trans.Prioridad == 1 ? "0" : "1",
            //                       TipoServicio = servicio.TipoServicio.Descripcion,
            //                       FaxContacto = trans.FaxContacto,
            //                       NoReciboDGII = trans.NoReciboDGII,
            //                       FechaReciboDGII = trans.FechaReciboDGII,
            //                       CustomInt1 = trans.TipoSociedadId,
            //                       CustomInt2 = trans.NumeroRegistro,
            //                       CustomString1 = trans.NombreSocialPersona,
            //                       CustomString2 = String.Empty,
            //                       CustomString3 = String.Empty,
            //                       CustomDecimal1 = trans.CapitalSocial,
            //                       CustomDecimal2 = trans.ModificacionCapital,
            //                       FlowId = Guid.NewGuid(),
            //                       ComentarioHtml = trans.Comentario,
            //                       TransaccionIdAnterior = trans.TransaccionId

            //                   };
            //repTransaccion.Add(transSrm);

            //#endregion

            //#region Subtransacciones
            ////Validacion para subtransacciones. Hay algunas que no se cobran dependiendo del primer servicio seleccionado
            //if (!servicio.SeCobraEnSubTransaccion && servicio.TransaccionJerarquia > 0 ||
            //       Helper.ServiciosHeaderIds.Contains(servicio.ServicioId))
            //    considerarMods = false;

            //var subtransList = new List<SRM.SubTransacciones>();
            //foreach (var subtrans in trans.SubTransacciones)
            //{
            //    var subserv = dbComun.Servicio.Where(a => a.ServicioId == subtrans.ServicioId).FirstOrDefault();
            //    var subTransSrm = new SRM.SubTransacciones()
            //    {
            //        TipoServicioId = subserv.ServicioId,
            //        TipoTransaccionId = subserv.TipoServicioId,
            //        Servicio = subserv.Descripcion,
            //        Estatus = Helper.EstatusTransIdAnalisis,
            //        TipoServicio = subserv.TipoServicio.Descripcion,
            //        CustomInt1 = trans.TipoSociedadId,
            //        CustomInt2 = trans.NumeroRegistro,
            //        CustomString1 = trans.NombreSocialPersona,
            //        CustomString2 = String.Empty,
            //        CustomString3 = String.Empty,
            //        CustomDecimal1 = trans.CapitalSocial,
            //        CustomDecimal2 = trans.ModificacionCapital,
            //        FechaModificacion = DateTime.Now,
            //        FlowId = Guid.NewGuid(),

            //    };
            //    subtransList.Add(subTransSrm);

            //}
            //#endregion

            //#region Detalle Transaccion


            //var listTransDetalle = new List<SRM.TransaccionDetalle>();
            //var transDetalle = dbWebSite.TransaccionDetalle.Where(t => t.FacturaId == factura.FacturaId);

            //if (transDetalle.Count() > 0)
            //{
            //    listTransDetalle.AddRange(
            //        transDetalle.Select(td =>
            //                            new SRM.TransaccionDetalle()
            //                                {
            //                                    Cantidad = td.Cantidad,
            //                                    Cuenta = td.Cuenta,
            //                                    Detalle = td.Detalle,
            //                                    PrecioUnitario = td.PrecioUnitario,
            //                                    Total = td.Total,
            //                                    TotalBruto = td.TotalBruto
            //                                }
            //            )
            //        );
            //}

            //#endregion

            //#region Factura / Pagos

            //totalFactura = listTransDetalle.Sum(l => l.Total).GetValueOrDefault();
            //var facturaSrm = new SRM.Facturas
            //{
            //    Complementaria = false,
            //    Estado = 1,
            //    Fecha = DateTime.Now,
            //    Ncf = factura.Ncf,
            //    TipoNcf = (factura.TipoNcf != null) ? ((factura.TipoNcf == "1") ? "Factura con Valor Fiscal" : (factura.TipoNcf == "2") ? "Factura para Consumidor Final" : (factura.TipoNcf == "14") ? "Factura para Regímenes Especiales" : "Factura para Organismos Gubernamentales") : "",
            //    Usuario = Helper.UsuarioFacturacion,
            //    CamaraId = CamaraId,
            //    TotalFactura = totalFactura
            //};
            //repFacturas.Add(facturaSrm);

            //var formasPagoSrm = new SRM.FormasPagos()
            //{
            //    Valor = totalFactura,
            //    ValorEntregado = totalFactura,
            //    ValorDevuelto = 0m,
            //    FormaPago = Helper.MetodoPago.ToString(),
            //    FechaCuadre = DateTime.Today.Date,
            //    Tasa = 1m,
            //    Referencia = "Orden enviada por website",
            //    NoTarjeta = String.Empty
            //};

            //#endregion

            //#region Documentos

            //var documentosSrm = new List<SRM.DocumentosTransacciones>();
            //foreach (var doc in trans.TransaccionesDocumentos)
            //{
            //    var tipoDoc = dbComun.TipoDocumento.FirstOrDefault(d => d.TipoDocumentoId == doc.TipoDocumentoId);
            //    if (tipoDoc == null) continue;

            //    var docSrm = new SRM.DocumentosTransacciones()
            //                     {
            //                         WebDocumentoId = doc.TransaccionesDocumentosId,
            //                         Analizado = false,
            //                         Comentario = "Documento enviado desde portal Web",
            //                         FechaDocumento = doc.FechaDocumento,
            //                         NoOriginales = 1,
            //                         NoCopias = 0,
            //                         CheckValidated = true,
            //                         Deleted = false,
            //                         FechaModificacion = DateTime.Now,
            //                         rowguid = Guid.NewGuid(),
            //                         Documento = tipoDoc.Nombre,
            //                         Registrable = tipoDoc.Registrable,
            //                         CostoOriginal = tipoDoc.CostoOriginal,
            //                         CostoCopia = tipoDoc.CostoCopia,
            //                         DocumentoId = doc.TipoDocumentoId.GetValueOrDefault()
            //                     };
            //    documentosSrm.Add(docSrm);
            //}

            //#endregion

            //#region Transacciones Sociedades
            //var transSoc = new SRM.TransaccionesSociedades();

            //if (esCertificacion)
            //{
            //    var sociedadId = 0;
            //    if (trans.RegistroId > 0)
            //    {
            //        sociedadId = context.SociedadesRegistros.Where(a => a.RegistroId.Equals(trans.RegistroId))
            //                            .FirstOrDefault()
            //                            .SociedadId;                          
            //    }


            //    transSoc.FechaModificacion = DateTime.Now;
            //    transSoc.rowguid = Guid.NewGuid();
            //    transSoc.SociedadId = sociedadId;   
            //}

            //#endregion

            //var srmUpdated = false;
            //using (var scope = new System.Transactions.TransactionScope())
            //{
            //    using (var tnx = repTransaccion.BeginTransaction())
            //    {
            //        try
            //        {
            //            //Se guarda la transaccion y se obtiene el ID 
            //            repTransaccion.Save();
            //            var transId = transSrm.TransaccionId;

            //            //Si es certificacion grabar la Transacciones Sociedad
            //            if (esCertificacion)
            //            {
            //                transSoc.TransaccionId = transId;
            //                repTransaccinesSociedades.Add(transSoc);
            //                repTransaccinesSociedades.Save();
            //            }

            //            //Se actualizan las subtransacciones
            //            foreach (var subtransItem in subtransList)
            //            {
            //                subtransItem.TransaccionId = transId;
            //                repSubTransaccion.Add(subtransItem);
            //            }
            //            repSubTransaccion.Save();

            //            //Se somete la factura y se obtiene el Id
            //            facturaSrm.TransaccionId = transId;
            //            repFacturas.Save();
            //            var facturaId = facturaSrm.FacturaId;

            //            //Se actualiza el detalle de la factura
            //            foreach (var transDetalleItem in listTransDetalle)
            //            {
            //                transDetalleItem.FacturaId = facturaId;
            //                repDetalle.Add(transDetalleItem);
            //            }
            //            repDetalle.Save();

            //            //Se actualiza la forma de pagos
            //            formasPagoSrm.FacturaId = facturaId;
            //            repFormasPago.Add(formasPagoSrm);
            //            repFormasPago.Save();

            //            //Se actualizan los documentos adjuntos
            //            foreach (var docInTrans in documentosSrm)
            //            {
            //                docInTrans.FacturaId = facturaId;
            //                docInTrans.TransaccionId = transId;
            //                repDocumentos.Add(docInTrans);
            //            }
            //            repDocumentos.Save();

            //            //Se asigna la transacción a un analista
            //            var usuarioAntId = repUsuario.GetUsuarioIdByUsername(Helper.UsuarioFacturacion);

            //           repTransaccion.AsignarTransaccion(transId, estatusId, usuarioAntId);

            //            //Se actualiza el objeto web (para poder tener el tracking)
            //            trans.SrmTransaccionId = transId;
            //            trans.bLoadedInSRM = true;

            //            //Commit de la transacción. Se usa la variable srmUpdated para no tener que usar el MSDTC entre dos bases de datos distintas
            //            tnx.Commit();
            //            scope.Complete();
            //            srmUpdated = true;
            //        }
            //        catch (Exception ex)
            //        {
            //            tnx.Rollback();
            //            ErrorMessage = "Ha ocurrido un error al intentar procesar su transacción. Contacte al personal de soporte.";
            //        }
            //    }
            //}

            //if (srmUpdated)
            //    dbWebSite.SaveChanges();

            //btnEnvioTransaccion.Enabled = !trans.SrmTransaccionId.HasValue;            

            //ErrorMessage = "Su Transacción se ha enviado para ser procesada por un analista.";
            //Response.Redirect("~/Empresas/Oficina.aspx");
            #endregion
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.LoadTransaccionDocFromControl(CamaraWebsiteEntities)'
        public void LoadTransaccionDocFromControl(CamaraWebsiteEntities dbWebsite)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.LoadTransaccionDocFromControl(CamaraWebsiteEntities)'
        {
            foreach (GridDataItem item in rgriddocumentosEnviados.Items)
            {
                if (item.ItemType != GridItemType.Item || item.ItemType == GridItemType.AlternatingItem) continue;

                var keys = rgriddocumentosEnviados.MasterTableView.DataKeyValues[item.ItemIndex];
                var transactionDocumentoId = keys["TransaccionesDocumentosId"] as Int32?;

                var ctrlNombre = item.FindControl("DescripcionLabel") as Label;
                var nombre = ctrlNombre != null ? ctrlNombre.Text : String.Empty;

                var ctrlTipoDoc = item.FindControl("ddlTiposDocumentos") as DropDownList;
                var tipoDoc = (ctrlTipoDoc != null || ctrlTipoDoc.SelectedValue == null)
                    ? ctrlTipoDoc.SelectedValue : String.Empty;

                var transDoc = dbWebsite.TransaccionesDocumentos.FirstOrDefault(a => a.TransaccionesDocumentosId == transactionDocumentoId);
                transDoc.Descripcion = nombre;
                transDoc.TipoDocumentoId = int.Parse(tipoDoc);
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.LoadDocsREqueridoEnviados()'
        public bool LoadDocsREqueridoEnviados()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.LoadDocsREqueridoEnviados()'
        {
            var docsEnviados = new List<int>();
            var docsRequeridos = new List<int>();
            LoadDocSeleccionados(int.Parse(lblNumSolicitud.Text));
            rgriddocumentos.DataBind();
            rgriddocumentosEnviados.DataBind();


            foreach (GridItem gridItem in rgriddocumentosEnviados.Items)
            {

                var datakey = rgriddocumentosEnviados.MasterTableView.DataKeyValues[gridItem.ItemIndex];
                int tipoDocumentoId = -1;
                if (datakey["TipoDocumentoId"] != null)
                    int.TryParse(datakey["TipoDocumentoId"].ToString(), out tipoDocumentoId);

                if (tipoDocumentoId > 0)
                    docsEnviados.Add(tipoDocumentoId);
            }

            foreach (GridItem gridItem in rgriddocumentos.Items)
            {
                var datakey = rgriddocumentos.MasterTableView.DataKeyValues[gridItem.ItemIndex];
                int tipoDocumentoId = -1;
                if (datakey["TipoDocumentoId"] != null)
                    int.TryParse(datakey["TipoDocumentoId"].ToString(), out tipoDocumentoId);
                bool requerido = Convert.ToBoolean(datakey["Requerido"]);
                //if (tipoDocumentoId > 0 && requerido)   
                if (tipoDocumentoId > 0)
                    docsRequeridos.Add(tipoDocumentoId);
            }

            foreach (var docrequerido in docsRequeridos)
            {
                if (!docsEnviados.Contains(docrequerido))
                    return false;

            }

            int calNsolCantDoc;
            Int32.TryParse(Request.QueryString["nSolicitud"], out calNsolCantDoc);
            int cantDocSeleccionadoLoad = CalcularDocparaSubir(calNsolCantDoc);

            //if (rgriddocumentosEnviados.Items.Count < cantDocSeleccionadoLoad)
            //{
            //    divUpload.Visible = true;
            //    Master.ShowMessageError("Puede agregar mas documentos");
            //}
            //else if (cantDocSeleccionadoLoad == rgriddocumentosEnviados.Items.Count)
            //{
            //    divUpload.Visible = false;
            //    Master.ShowMessageError("Ya se han Seleccionado todos los documentos");
            //}

            return true;
            //var comparison = docsEnviados.FindAll(docsRequeridos.Contains);

            //return comparison.Count == docsRequeridos.Count;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.IsValido()'
        protected bool IsValido()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.IsValido()'
        {
            if (!LoadDocsREqueridoEnviados())
            {
                var websiteDb = new CamaraWebsiteEntities();
                var db = new CamaraComunEntities();
                int nSolicitud;
                string result = "";

                int.TryParse(Request.QueryString["nSolicitud"], out nSolicitud);

                var doc = websiteDb.TransaccionDocSeleccionado.Where(x => x.TransaccionId == nSolicitud);
                foreach (var item in doc)
                {
                    string sum;
                    var a = db.TipoDocumento.First(x => x.TipoDocumentoId == item.TipoDocumentoId);
                    if (item.TipoDocumentoId == 1551)
                    {
                        sum = $"|| Debe subir entre 1 a {item.CantidadCopia} archivo(s) del documento {a.Nombre} || ";

                    }
                    else if (item.TipoDocumentoId == 1560)
                    {
                        sum = "";
                    }
                    else
                    {
                        sum = $"|| Debe subir {item.CantidadCopia} archivo(s) del documento {a.Nombre} || ";
                    }
                    result += sum;
                }


                Master.ShowMessageError(result);
                return false;
            }

            return true;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.btnUploadDocumento_Click(object, EventArgs)'
        protected void btnUploadDocumento_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.btnUploadDocumento_Click(object, EventArgs)'
        {
            if (rgriddocumentosEnviados.Items.Count == CantidadDocaSubir)
            {
                Master.ShowMessageError("Ya se han subido todos los documentos");
                return;
            }
            if (this.uploadDocumento.FileName.Length > 0)
            {
                var file = this.uploadDocumento.FileBytes;
                var idusuario = this.CurrentUser.UserName.ToLower();
                var descripcion = this.uploadDocumento.FileName;
                var contentType = this.uploadDocumento.PostedFile.ContentType;

                var strNumSolicitud = Request.QueryString["nSolicitud"];
                int nSolicitud;
                Int32.TryParse(strNumSolicitud, out nSolicitud);
                if (nSolicitud == 0)
                {
                    Master.ShowMessageError("Error al intentar subir el documento. Intente nuevamente más tarde");
                    return;
                }

                var sguid = Guid.NewGuid();
                var status = OFV.TransaccionDocumentosController
                    .savedocuments(nSolicitud, descripcion, DateTime.Now, idusuario, sguid, file, contentType);
            }

            LoadDocsREqueridoEnviados();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.btnUploadDocumentoIE_Click(object, EventArgs)'
        protected void btnUploadDocumentoIE_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.btnUploadDocumentoIE_Click(object, EventArgs)'
        {
            if (this.uploadDocumentoIE.FileName.Length > 0)
            {
                var file = this.uploadDocumentoIE.FileBytes;
                var idusuario = this.CurrentUser.UserName.ToLower();
                var descripcion = this.uploadDocumentoIE.FileName;
                var contentType = this.uploadDocumentoIE.PostedFile.ContentType;

                var strNumSolicitud = Request.QueryString["nSolicitud"];
                int nSolicitud;
                Int32.TryParse(strNumSolicitud, out nSolicitud);
                if (nSolicitud == 0)
                {
                    Master.ShowMessageError("Error al intentar subir el documento. Intente nuevamente más tarde");
                    return;
                }

                var sguid = Guid.NewGuid();
                var status = OFV.TransaccionDocumentosController
                    .savedocuments(nSolicitud, descripcion, DateTime.Now, idusuario, sguid, file, contentType);
            }

            LoadDocsREqueridoEnviados();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.rgriddocumentosEnviados_ItemCommand(object, GridCommandEventArgs)'
        protected void rgriddocumentosEnviados_ItemCommand(object source, GridCommandEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.rgriddocumentosEnviados_ItemCommand(object, GridCommandEventArgs)'
        {
            if (e.CommandName == "Delete")
            {

                TransaccionesDocumentos td;
                int.TryParse(e.CommandArgument.ToString(), out int transaccionDocumentoId);
                using (var db = new CamaraWebsiteEntities())
                {
                    td = db.TransaccionesDocumentos.First(t => t.TransaccionesDocumentosId == transaccionDocumentoId);

                    if (td.SBDocumentId != null)
                    {
                        if (!DeleteDocumentFromShareBase(td))
                        {
                            Master.ShowMessageError("Error al borrar el documento de Sharebase.");
                            return;
                        }
                    }
                    //if (!(divUpload.Visible)) divUpload.Visible = true;
                    new OFV.TransaccionDocumentosController().DeleteDocumentosEnviados(transaccionDocumentoId);

                    LoadDocsREqueridoEnviados();
                }
            }
        }

        /*
         * Metodo para validar que los documentos seleccionados posean firma digital.
         * Retorna los documentos rechazados.
         */
        private List<string> ValidateDocuments()
        {
            OnlineChamberServiceClient client = new OnlineChamberServiceClient();
            var docsReq = new List<int>();
            rgriddocumentosEnviados.DataBind();
            var docsRec = new List<string>();

            // Tomar los documentsId del grid;
            foreach (GridDataItem gridItem in rgriddocumentosEnviados.Items)
            {
                CheckBox chk = (CheckBox)gridItem.FindControl("chkFirmasDigital");

                var datakey = rgriddocumentosEnviados.MasterTableView.DataKeyValues[gridItem.ItemIndex];
                int tranDocId = -1;
                if (datakey["TransaccionesDocumentosId"] != null)
                    int.TryParse(datakey["TransaccionesDocumentosId"].ToString(), out tranDocId);

                if (tranDocId > 0)
                    docsReq.Add(tranDocId);

            }


            using (var db = new CamaraWebsiteEntities())
            {
                var docs = db.TransaccionesDocumentos
                    .Where(t => t.TransaccionId == this.IdTransaciones)
                    .Where(p => docsReq.Any(d => d == p.TransaccionesDocumentosId))
                    .Select(d => new
                    {
                        d.TransaccionesDocumentosId,
                        d.TipoDocumentoId,
                        d.DocContent,
                        d.NombreArchivo,
                        d.Nombre,
                        d.FirmaDigital
                    }).ToList();

                if (docs.Count != 0)
                {
                    foreach (var d in docs)
                    {
                        if (d.FirmaDigital.HasValue ? d.FirmaDigital.Value : false)
                        {
                            using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
                            {
                                var httpRequestProperty = new HttpRequestMessageProperty();
                                httpRequestProperty.Headers["token"] = Helper.ShareBaseToken;
                                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
                                var converted = Convert.ToBase64String(d.DocContent);
                                var val = client.ValidateDocument(converted);
                                if (!val.Success)
                                    docsRec.Add(d.Nombre);
                                else
                                {
                                    var td = db.TransaccionesDocumentos.FirstOrDefault<TransaccionesDocumentos>(c => c.TransaccionesDocumentosId == d.TransaccionesDocumentosId);
                                    td.FirmaDigital = val.Success;
                                    db.SaveChanges();
                                }

                            }
                        }
                    }
                }
            }
            client.Close();
            return docsRec;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.CheckedChanged(object, EventArgs)'
        protected void CheckedChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.CheckedChanged(object, EventArgs)'
        {
            foreach (GridDataItem dataItem in rgriddocumentosEnviados.MasterTableView.Items)
            {
                dataItem.Selected = true;
            }
        }

        /*
         * Metodo para crear los documentos en ShareBase 
         */
        private bool CrearDocumentosEnShareBase()
        {
            if (Helper.ShareBaseEnabled)
            {
                var client = new OnlineChamberServiceClient();
                var docsRq = new List<int>();
                //rgriddocumentosEnviados.DataBind();
                foreach (GridItem gridItem in rgriddocumentosEnviados.Items)
                {
                    var datakey = rgriddocumentosEnviados.MasterTableView.DataKeyValues[gridItem.ItemIndex];
                    //var ck = gridItem.FindControl("chkFirmasDigital") as CheckBox;
                    //if (datakey["chkFirmasDigital"] != null)
                    //    bool.TryParse(datakey["chkFirmasDigital"].ToString(), out ck);


                    int tranDocId = -1;
                    if (datakey["TransaccionesDocumentosId"] != null)
                        int.TryParse(datakey["TransaccionesDocumentosId"].ToString(), out tranDocId);

                    if (tranDocId > 0)
                        docsRq.Add(tranDocId);

                }

                using (var db = new CamaraWebsiteEntities())
                {
                    var docs = db.TransaccionesDocumentos.Where(t => docsRq.Any<int>(i => i == t.TransaccionesDocumentosId))
                        .Select(d => new
                        {
                            d.TransaccionesDocumentosId,
                            d.DocContent,
                            IdSolicitud = d.TransaccionId,
                            d.Transacciones.FolderId,
                            d.TipoDocumentoId,
                            d.SBDocumentId
                        }).ToList();

                    using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
                    {
                        foreach (var d in docs)
                        {
                            if (d.SBDocumentId != null)
                                continue;

                            string DocTypeName = string.Empty;
                            using (var ccE = new CamaraComunEntities())
                            {
                                DocTypeName = ccE.TipoDocumento.First(i => i.TipoDocumentoId == d.TipoDocumentoId).DocumentoOnBaseDesc;
                            }

                            var httpRequestProperty = new HttpRequestMessageProperty();
                            httpRequestProperty.Headers["token"] = Helper.ShareBaseToken;
                            var doc = new DocumentData()
                            {
                                DocumentTypeName = DocTypeName,
                                Base64 = Convert.ToBase64String(d.DocContent)
                            };
                            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
                            var val = new CamaraComercio.Website.WSShareBase.BasicOperationResultOfstring();
                            if(d.SBDocumentId == null)
                                val = client.CreateDocumentOnSharebase(long.Parse(d.FolderId), d.IdSolicitud.ToString(), doc);

                            if (!val.Success)
                                return val.Success;
                            else
                            {
                                var td = db.TransaccionesDocumentos
                                    .FirstOrDefault(t => t.TransaccionesDocumentosId == d.TransaccionesDocumentosId);
                                td.SBDocumentId = val.Entity;
                                db.SaveChanges();
                            }
                        }
                    }
                }
                client.Close();
            }

            return true;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.GetSafeFilename(string)'
        public string GetSafeFilename(string filename)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.GetSafeFilename(string)'
        {

            return string.Join("_", filename.Split(System.IO.Path.GetInvalidFileNameChars()));

        }

        private bool DeleteDocumentFromShareBase(TransaccionesDocumentos td)
        {
            if (Helper.ShareBaseEnabled)
            {
                var client = new OnlineChamberServiceClient();
                using (var db = new CamaraWebsiteEntities())
                {
                    using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
                    {
                        var httpRequestProperty = new HttpRequestMessageProperty();
                        httpRequestProperty.Headers["token"] = Helper.ShareBaseToken;

                        OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
                        var val = client.DeleteDocumentOnSharebase(long.Parse(td.SBDocumentId));
                        return val.Success;
                    }
                }
            }
            return true;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.BackUrl'
        protected string BackUrl
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.BackUrl'
        {
            get
            {
                /*var noSolicitud = Request.QueryString["nSolicitud"];
                var tipoModeloId = Request.QueryString["TipoModeloId"];
                var esCertificacion = Request.QueryString["EsCertificacion"];
                var camaraId = Request.QueryString["CamaraId"];

                return $"~/Empresas/RevisionDocumentos.aspx?nSolicitud={noSolicitud}&TipoModeloId={tipoModeloId}&EsCertificacion={esCertificacion}&CamaraId={camaraId}";*/

                var helper = new TransaccionDevueltaHelper(Request);
                string queryString = DefaultQueryString;
                if (helper.EstaDevuelta() && !queryString.Contains("estado="))
                    queryString += "&estado=devuelto";

                return $"~/Empresas/RevisionDocumentos.aspx{queryString}";
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.btnBack_Click(object, EventArgs)'
        protected void btnBack_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.btnBack_Click(object, EventArgs)'
        {
            Response.Redirect(BackUrl);
        }


        // filtro ddl si archivo existe
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.SelectAllByTransId(int)'
        public IList<TipoDocumento> SelectAllByTransId(int TransaccionId)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.SelectAllByTransId(int)'
        {
            var db = new CamaraComunEntities();
            var dbWebSite = new CamaraWebsiteEntities();

            var DocSeleccionados = dbWebSite.TransaccionDocSeleccionado.Where(a => a.TransaccionId == TransaccionId).Select(a => a.TipoDocumentoId).ToList();

            var result = db.TipoDocumento.Where(a => DocSeleccionados.Contains(a.TipoDocumentoId) && a.SiteVisible)
                .OrderBy(a => a.Nombre).ToList();

            var otro = db.TipoDocumento.Where(a => a.Nombre == "Otros").FirstOrDefault();
            if (otro == null) return result;

            result.Add(otro);
            return result;
        }
    }
}