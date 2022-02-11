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
using Telerik.Web.UI;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website.UserControls
{
    ///<summary>
    /// Página para el envío de datos a las Cámaras
    ///</summary>
    public partial class ucEnvioDatos : EnvioDatosUserControl
    {
#pragma warning disable CS0169 // The field 'ucEnvioDatos.totalFactura' is never used
        private decimal totalFactura;
#pragma warning restore CS0169 // The field 'ucEnvioDatos.totalFactura' is never used
#pragma warning disable CS0414 // The field 'ucEnvioDatos.CertificacionId' is assigned but its value is never used
        private static int CertificacionId = 7;
#pragma warning restore CS0414 // The field 'ucEnvioDatos.CertificacionId' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'ucEnvioDatos.CopiaCertificadaId' is assigned but its value is never used
        private static int CopiaCertificadaId = 39;
#pragma warning restore CS0414 // The field 'ucEnvioDatos.CopiaCertificadaId' is assigned but its value is never used

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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.DocSeleccionados'
        protected List<int?> DocSeleccionados { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.DocSeleccionados'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.ControlLoad(List<KeyValuePair<string, string>>)'
        public override void ControlLoad(List<KeyValuePair<string, string>> args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.ControlLoad(List<KeyValuePair<string, string>>)'
        {
            this.hfSessionID.Value = this.Session.SessionID;
            var strNumSolicitud = this.IdTransaciones.ToString();

            if (!String.IsNullOrEmpty(strNumSolicitud))
            {
                hfsolicitudID.Value = strNumSolicitud;
                hfusuarioID.Value = this.Page.User.Identity.Name;

                //buscar el servicioid y el tiposociedadid
                int nSolicitud;
                if (!Int32.TryParse(strNumSolicitud, out nSolicitud))
                    SolicitudInvalidad();

                //Transaccion y Hidden Fields
                var trans = TransaccionesController.GetTransaccionById(nSolicitud);
                //Tipo Sociedad ID
                if (trans.TipoSociedadId == 0)
                    trans.TipoSociedadId = 2;

                var dbUsers = new DataAccess.EF.Membership.CamaraWebsiteAccountsEntities();

                var uHijos = dbUsers.ViewProfileProperties
                            .Where(c => c.UsuarioPadre == this.Page.User.Identity.Name)
                            .ToList().Select(c => c.UserName.ToLower());

                if (trans != null)
                {
                    if (trans.UserName != this.Page.User.Identity.Name && !uHijos.Contains(trans.UserName))
                    {
                        Session["ErrorMessage"] = "Usted no puede enviar datos de una solicitud inexistente.";
                        Response.Redirect("~/Empresas/Oficina.aspx");
                    }

                    LoadDocSeleccionados(nSolicitud);

                    this.hfServicioId.Value = trans.ServicioId.ToString();
                    this.hfTipoSociedadId.Value = trans.TipoSociedadId.ToString();

                    this.CamaraId = trans.CamaraId;
                    var helper = new TransaccionDevueltaHelper(Request);
                    if (helper.EstaDevuelta())
                    {
                        btnEnvioTransaccion.Enabled = true;
                    }
                    else
                    {
                        btnEnvioTransaccion.Enabled = !trans.SrmTransaccionId.HasValue;
                    }
                }
                else
                    SolicitudInvalidad();

                odsDocsRequeridos.DataBind();

                //var repDocumentos = new Comun.TipoDocumentoRepository();
                //var docList = repDocumentos.SelectAll(true).Distinct().ToList();
                //this.ddlTipoDocumento.BindCollection(docList,
                //    Comun.TipoDocumento.PropColumns.TipoDocumentoId,
                //    Comun.TipoDocumento.PropColumns.Nombre);
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.rgriddocumentos_ItemDataBound(object, GridItemEventArgs)'
        protected void rgriddocumentos_ItemDataBound(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.rgriddocumentos_ItemDataBound(object, GridItemEventArgs)'
        {
            if (e.Item is GridPagerItem)
            {
                var pager = (GridPagerItem)e.Item;
                var lbl = (Label)pager.FindControl("ChangePageSizeLabel");
                lbl.Text = "Tamaño de página: ";
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.rgriddocumentosEnviados_ItemDataBound(object, GridItemEventArgs)'
        protected void rgriddocumentosEnviados_ItemDataBound(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.rgriddocumentosEnviados_ItemDataBound(object, GridItemEventArgs)'
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                var box = (CheckBox)item.FindControl("chkFirmasDigital");
                var data = (e.Item.DataItem as TransaccionesDocumentos);
                box.Checked = data.FirmaDigital.HasValue ? data.FirmaDigital.Value : false;
            }

            if (!(e.Item is GridPagerItem)) return;
            var pager = (GridPagerItem)e.Item;
            var lbl = (Label)pager.FindControl("ChangePageSizeLabel");
            lbl.Text = "Tamaño de página: ";


        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.rgriddocumentosEnviados_ItemCreated(object, GridItemEventArgs)'
        protected void rgriddocumentosEnviados_ItemCreated(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.rgriddocumentosEnviados_ItemCreated(object, GridItemEventArgs)'
        {
            if (!(e.Item is GridDataItem)) return;

            var control = e.Item.FindControl("ddlTiposDocumentos") as DropDownList;
            var dataItem = (e.Item.DataItem as TransaccionesDocumentos);

            if (dataItem == null) return;

            if (control != null)
                control.SelectedValue = dataItem.TipoDocumentoId.HasValue
                                            ? dataItem.TipoDocumentoId.Value.ToString()
                                            : null;
        }

        private int ObtenerTipoServicio(int servicioId)
        {
            var dbComun = new CamaraComunEntities();
            var servicio = dbComun.Servicio.FirstOrDefault(t => t.ServicioId == servicioId);

            if (servicio != null) return servicio.TipoServicioId;

            return 0;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.ValidateNext()'
        public override bool ValidateNext()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.ValidateNext()'
        {
            if (!Page.IsValid || !IsValido()) return false;
            //Si los documentos fueron cargados exitosamente, entonces enviar a la pantalla de pago.

            if (Helper.ShareBaseEnabled)
            {
                var res = ValidateDocuments();
                if (res.Count != 0)
                {
                    string str = string.Empty;
                    foreach (var r in res)
                        str += string.Format("{0}, ", r);
                    Master.ShowMessageError(string.Format("Alguno de los archivos no tiene una firma digital valida. Favor revisar los archivos {0}. Puede continuar ", str));
                    return false;
                }


                //GrabarFormularioSolicitud(this.IdTransaciones);
                var val = CrearDocumentosEnShareBase();
                if (!val)
                {
                    Master.ShowMessageError("Error al cargar los documentos en ShareBase.");
                    return false;
                }
            }

            Master.ShowMessageError("Succes!");

            return true;
            //Response.Redirect("~/TarjetaCredito/PagosTarjeta.aspx" + DefaultQueryString);
        }

        /// <summary>
        /// Crea una Transaccion en el SRM.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEnviarTransaccion_Click(object sender, EventArgs e)
        {
            ValidateNext();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.LoadTransaccionDocFromControl(CamaraWebsiteEntities)'
        public void LoadTransaccionDocFromControl(CamaraWebsiteEntities dbWebsite)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.LoadTransaccionDocFromControl(CamaraWebsiteEntities)'
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.LoadDocsREqueridoEnviados()'
        public bool LoadDocsREqueridoEnviados()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.LoadDocsREqueridoEnviados()'
        {
            var docsEnviados = new List<int>();
            var docsRequeridos = new List<int>();
            LoadDocSeleccionados(this.IdTransaciones);
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
            return true;
            //var comparison = docsEnviados.FindAll(docsRequeridos.Contains);

            //return comparison.Count == docsRequeridos.Count;

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.IsValido()'
        protected bool IsValido()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.IsValido()'
        {
            if (!LoadDocsREqueridoEnviados())
            {
                Master.ShowMessageError("Hemos detectado que no ha incluido todos los documentos requeridos. Intentelo nuevamente.");
                return false;
            }

            return true;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.btnUploadDocumento_Click(object, EventArgs)'
        protected void btnUploadDocumento_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.btnUploadDocumento_Click(object, EventArgs)'
        {
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.btnUploadDocumentoIE_Click(object, EventArgs)'
        protected void btnUploadDocumentoIE_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.btnUploadDocumentoIE_Click(object, EventArgs)'
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






#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.rgriddocumentosEnviados_ItemCommand(object, GridCommandEventArgs)'
        protected void rgriddocumentosEnviados_ItemCommand(object source, GridCommandEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.rgriddocumentosEnviados_ItemCommand(object, GridCommandEventArgs)'
        {
            if (e.CommandName == "Delete")
            {
                TransaccionesDocumentos td;
                int.TryParse(e.CommandArgument.ToString(), out int transaccionDocumentoId);
                using (var db = new CamaraWebsiteEntities())
                    td = db.TransaccionesDocumentos.First(t => t.TransaccionesDocumentosId == transaccionDocumentoId);

                if (td.SBDocumentId != null)
                {
                    if (DeleteDocumentFromShareBase(td))
                    {
                        Master.ShowMessageError("Error al borrar el documento de Sharebase.");
                        return;
                    }
                }

                new OFV.TransaccionDocumentosController().DeleteDocumentosEnviados(transaccionDocumentoId);
                LoadDocsREqueridoEnviados();
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.CheckedChanged(object, EventArgs)'
        protected void CheckedChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.CheckedChanged(object, EventArgs)'
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
                            d.SBDocumentId
                        }).ToList();

                    using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
                    {
                        foreach (var d in docs)
                        {
                            if (!string.IsNullOrEmpty(d.SBDocumentId))
                                continue;


                            var x = db.TransaccionesDocumentos.First(t => t.TransaccionesDocumentosId == d.TransaccionesDocumentosId);
                            string DocTypeName = string.Empty;
                            using (var ccE = new CamaraComunEntities())
                            {
                                DocTypeName = ccE.TipoDocumento.First(i => i.TipoDocumentoId == x.TipoDocumentoId).DocumentoOnBaseDesc;
                            }

                            var httpRequestProperty = new HttpRequestMessageProperty();
                            httpRequestProperty.Headers["token"] = Helper.ShareBaseToken;
                            var doc = new DocumentData()
                            {
                                DocumentTypeName = DocTypeName,
                                Base64 = Convert.ToBase64String(d.DocContent)
                            };
                            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
                            var val = client.CreateDocumentOnSharebase(long.Parse(d.FolderId), d.IdSolicitud.ToString(), doc);

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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.GetSafeFilename(string)'
        public string GetSafeFilename(string filename)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucEnvioDatos.GetSafeFilename(string)'
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
    }
}