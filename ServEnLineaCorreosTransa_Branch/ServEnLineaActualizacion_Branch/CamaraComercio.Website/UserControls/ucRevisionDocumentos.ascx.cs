using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls;
using CamaraComercio.Website.Helpers;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using Telerik.Web.UI;
using CamaraComercio.DataAccess.EF.CamaraComun;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text.RegularExpressions;

namespace CamaraComercio.Website.UserControls
{
    ///<summary>
    /// Página para la revisión de documentos requeridos en una transacción
    ///</summary>
    public partial class ucRevisionDocumentos : EnvioDatosUserControl
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.TipoSociedadId'
        public int TipoSociedadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.TipoSociedadId'
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["TipoSociedadId"])
                           ? int.Parse(Request.QueryString["TipoSociedadId"])
                           : 0;
            }
            
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.TipoServicioId'
        public int TipoServicioId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.TipoServicioId'
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["TipoServicioId"])
                           ? int.Parse(Request.QueryString["TipoServicioId"])
                           : 0;
            }
            
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.RegistroId'
        public int RegistroId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.RegistroId'
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["registroId"])
                           ? int.Parse(Request.QueryString["registroId"])
                           : 0;
            }

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.EsCertificacion'
        public bool EsCertificacion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.EsCertificacion'
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["esCertificacion"])
                            ? Request.QueryString["esCertificacion"] == "1"
                            : false;
            }
        }

        /// <summary>
        /// Limpia los objetos en sesion
        /// </summary>
        protected void LimpiarObjetosSession()
        {
            DocumentosSeleccionados = null;
            DocumentosAgregados = null;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.ControlLoad(List<KeyValuePair<string, string>>)'
        public override void ControlLoad(List<KeyValuePair<string, string>> args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.ControlLoad(List<KeyValuePair<string, string>>)'
        {
            LimpiarObjetosSession();
            

            //Objetos de acceso a datos
            var db = new CamaraWebsiteEntities();
            var dbComun = new Comun.CamaraComunEntities();

            //Transaccion
            var trans = db.Transacciones.FirstOrDefault(a => (a.TransaccionId == IdTransaciones)
                && a.UserName == this.Page.User.Identity.Name.ToLower());
            if (trans == null) return;

            pnlAgregarDocumento.Visible = !Helper.HabilarPagoTarjeta(trans.ServicioId);

            // Hide controles de cantidad de certificaciones
            if (!EsCertificacion)
            {
                lbCertificaciones.Visible = false;
                txtCantidadCertificaciones.Visible = false;
            }
            else
            {
                lbCertificaciones.Visible = true;
                txtCantidadCertificaciones.Visible = true;
            }


            //Variable de servicios solicitados
            var servicioIds = trans.GetServicioTransacciones();

            //Tipo Sociedad ID
            if (trans.TipoSociedadId == 0)
                trans.TipoSociedadId = 2;

            hfTipoSociedadId.Value = trans.TipoSociedadId.ToString();

            //Tipo de Sociedad
            /*var tipo = dbComun.TipoSociedad.Where(c => c.TipoSociedadId == this.TipoSociedadID);
            if (tipo.Count() > 0)
                this.litTipoEmpresa.Text = tipo.First().Etiqueta;*/

            //Servicio(s)
            this.FormaEntrega = Request.QueryString["formaEntrega"];
            Session["Servicios"] = servicioIds;
            if (servicioIds.Count > 0 && servicioIds.FirstOrDefault() > 0)
            {
                //Listado de servicios
                var servicios = dbComun.Servicio.Where(s => servicioIds.Contains(s.ServicioId) && s.SiteVisible);
                this.rpServiciosSeleccionados.DataSource = servicios;
                this.rpServiciosSeleccionados.DataBind();

                var tipoSocId = (trans.TipoSociedadId > 0)
                                    ? trans.TipoSociedadId
                                    : this.TipoSociedadID;

                //Copias exoneradas
                var servSection = (ServicioSection)WebConfigurationManager.GetWebApplicationSection("servicioSection");
                var qry = servSection.Servicios.Where(s => s.TipoSociedadId == tipoSocId)
                                     .Select(s => s.ServicioConstitucionId).ToList();
                if (qry.Count() > 0)
                {
                    if (servicios.Count() > 0 && qry.Contains(servicios.FirstOrDefault().ServicioId))
                    {
                        this.hfCantExOriginal.Value = Helper.CantidadOriginalGratisNuevaEmpresa.ToString();
                        this.hfCantExCopia.Value = Helper.CantidadCopiasGratisNuevaEmpresa.ToString();

                        //Solo se muestra este aviso si la forma de entrega es física
                        if (this.FormaEntrega == "F")
                            this.litCopiasExoneradas.Visible = true;
                    }
                }
            }
            
            //Aqui grabo el log de la transaccion que se creo
            LogTransaccionesMethods.GrabarLogTransacciones(this.IdTransaciones, Request.RawUrl, false, this.Page.User.Identity.Name);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.FolderId'
        public string FolderId;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.FolderId'
        
        private void HideControles()
        {
            rpGrupoDoc.Visible = rpGrupoDoc.Items.Count > 0;
            pnDocRequeridos.Visible = rgriddocumentos.Items.Count > 0;

            
            //if ( (!rpGrupoDoc.Visible && !pnDocRequeridos.Visible) || this.hfServicioId.Value == Helper.ServicioCertificacionId.ToString())
            if (!rpGrupoDoc.Visible && !pnDocRequeridos.Visible)
                mv1.SetActiveView(v2);
        }

        // 01 - Cargando documentos requeridos por grupos
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.rpGrupoDoc_ItemDataBound(object, RepeaterItemEventArgs)'
        protected void rpGrupoDoc_ItemDataBound(object sender, RepeaterItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.rpGrupoDoc_ItemDataBound(object, RepeaterItemEventArgs)'
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var item = e.Item.DataItem as int?;
                if (item.HasValue)
                    odsDocsRequeridosPorGrupo.SelectParameters["grupo"].DefaultValue = item.Value.ToString();
                var grid = e.Item.FindControl("rgriddocumentos") as RadGrid;
                if (grid != null)
                {
                    grid.DataSource = odsDocsRequeridosPorGrupo.Select();
                    grid.DataBind();
                }
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.ValidateNext()'
        public override bool ValidateNext()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.ValidateNext()'
        {
            if (!rpGrupoDoc.Visible && !pnDocRequeridos.Visible)
            {
                int.TryParse(txtCantidadCertificaciones.Text, out int cantidadCopiasCertificaciones);
                if (cantidadCopiasCertificaciones <= 0)
                {
                    Master.ShowMessageError("La cantidad de Certificaciones debe ser mayor a 0");
                    return false;
                }
            }

            if (CreateDocumentosRequeridos())
            {
                SaveDocSeleccionados();
                var db = new CamaraWebsiteEntities();
                var transaccion = db.Transacciones.FirstOrDefault(a => a.TransaccionId.Equals(IdTransaciones) || a.TransaccionId.Equals(this.IdTransaciones));

                var helper = new TransaccionDevueltaHelper(Request);

                ViewState["cantidadCertificaciones"] = txtCantidadCertificaciones.Text;
                ViewState["requiereDocs"] = pnDocRequeridos.Visible ? 1 : 0;
                ViewState["estado"] = helper.EstaDevuelta() ? "devuelto" : "normal";
            }

            return true;
        }

        // 02 - Especificando valores
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.btnContinuar_Click(object, EventArgs)'
        protected void btnContinuar_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.btnContinuar_Click(object, EventArgs)'
        {
            if (!rpGrupoDoc.Visible && !pnDocRequeridos.Visible)
            {
                int.TryParse(txtCantidadCertificaciones.Text, out int cantidadCopiasCertificaciones);
                if (cantidadCopiasCertificaciones <= 0)
                {
                    Master.ShowMessageError("La cantidad de Certificaciones debe ser mayor a 0");
                    return;
                }
            }

            if (CreateDocumentosRequeridos())
            {
                SaveDocSeleccionados();
                var db = new CamaraWebsiteEntities();
                var transaccion = db.Transacciones.FirstOrDefault(a => a.TransaccionId.Equals(IdTransaciones));

                var helper = new TransaccionDevueltaHelper(Request);

                #region UrlForm
                string queryString = DefaultQueryString;
                if (!queryString.Contains("requireDocs="))
                    queryString += pnDocRequeridos.Visible ? "&requiereDocs=1" : "&requiereDocs=0";

                if (!queryString.Contains("cantidadCertificaciones="))
                {
                    queryString += string.Format("&cantidadCertificaciones={0}", txtCantidadCertificaciones.Text);
                }
                else
                {
                    queryString = Regex.Replace(queryString, "cantidadCertificaciones=(.*)\\&?", 
                        string.Format("cantidadCertificaciones={0}", txtCantidadCertificaciones.Text));
                }

                if (helper.EstaDevuelta() && !queryString.Contains("estado="))
                    queryString += "&estado=devuelto";

                switch (transaccion.TipoSociedadId)
                {
                    case 1:
                        Response.Redirect("~/Formularios/SociedadAnonima.aspx" + queryString);
                        break;
                    case 2:
                        Response.Redirect("~/Formularios/SociedadResponsabilidadLimitada.aspx" + queryString);
                        break;
                    case 3:
                        Response.Redirect("~/Formularios/SociedadNombreColectivo.aspx" + queryString);
                        break;
                    case 4:
                        Response.Redirect("~/Formularios/SociedadCSimple.aspx" + queryString);
                        break;
                    //case 5:
                    //    Response.Redirect("~/Formularios/SociedadCPorAcciones.aspx" + queryString);
                    //    break;
                    case 16:
                        Response.Redirect("~/Formularios/SociedadAnonimasSimplificada.aspx" + queryString);
                        break;
                    case 13:
                        Response.Redirect("~/Formularios/SociedadExtranjera.aspx" + queryString);
                        break;
                    default:
                        Response.Redirect("~/Formularios/SociedadEIRL.aspx" + queryString);
                        //Response.Redirect("~/Empresas/EnvioDatos.aspx" + queryString);
                        break;
                }
                #endregion
            }
        }

        //Guardando documentos selecconados
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.SaveDocSeleccionados()'
        protected void SaveDocSeleccionados()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.SaveDocSeleccionados()'
        {
            var db = new CamaraWebsiteEntities();
            var result = db.TransaccionDocSeleccionado.Where(a => a.TransaccionId == IdTransaciones);

            foreach (var item in result)
                db.DeleteObject(item);

            db.SaveChanges();
            foreach (var tran in this.DocumentosSeleccionados
                        .Select(item => new TransaccionDocSeleccionado
                        {
                            TransaccionId = IdTransaciones,
                            TipoDocumentoId = item.TipoDocumentoId,
                            CantidadCopia = item.CantidadCopia,
                            CantidadOriginal = item.CantidadOriginal,
                            FechaDocumento = item.Fecha
                        }
                    ))
                db.TransaccionDocSeleccionado.AddObject(tran);

            db.SaveChanges();
        }

        //Definiendo documentos requeridos
        private bool CreateDocumentosRequeridos()
        {
            txtCosto.Text = String.Empty;

            //Cargando documentos requeridos seleccionados
            this.DocumentosSeleccionados = new List<Comun.ServicioDocumentoRequerido>();

            foreach (GridDataItem item in rgriddocumentos.Items)
                LoadDocumento(rgriddocumentos, item);

            if (this.DocumentosSeleccionados.Count != rgriddocumentos.Items.Count)
            {
                Master.ShowMessageError("Selecciona la cantidad de todos los documentos requeridos para continuar. Intentelo nuevamente.");
                return false;
            }

            foreach (RepeaterItem rpitem in rpGrupoDoc.Items)
            {
                var radGrid = rpitem.FindControl("rgriddocumentos") as RadGrid;
                if (radGrid == null) continue;
                var docsSeleccionados = this.DocumentosSeleccionados.Count;
                foreach (GridDataItem item in radGrid.Items)
                    LoadDocumento(radGrid, item);

                //Validators para calendarios
                foreach (GridDataItem item in radGrid.Items)
                {
                    var cal = item.FindControl("radFechaDocumento") as RadDatePicker;
                    var txt1 = item.FindControl("txtCantidadDoc") as TextBox;
                    var txt2 = item.FindControl("txtCantidadDocOriginal") as TextBox;
                    if (cal != null && txt1 != null && txt2 != null)
                    {
                        Int32 cant1, cant2;
                        Int32.TryParse(txt1.Text, out cant1);
                        Int32.TryParse(txt2.Text, out cant2);
                        if (cant1 + cant2 > 0 && cal.SelectedDate == null)
                        {
                            Master.ShowMessageError("Existen documentos sin fecha asignada.");
                            return false;
                        }
                    }
                }

                //Validacion de documentos por grupo
                if (docsSeleccionados != this.DocumentosSeleccionados.Count) continue;
                Master.ShowMessageError("Selecciona al menos un documento por grupo.");
                return false;
            }

            //Verificando Documentos agregados.
            var docsNoOriginales = this.DocumentosSeleccionados.Any(
                    a => a.CantidadOriginal == 0 && a.TipoDocumento.Registrable && a.Requerido == true &&
                    !Helper.TipoSociedadExtranjera.Contains(a.TipoSociedadId));

            if (docsNoOriginales)
            {
                Master.ShowMessageError(
                    "Deposita al menos un documento original de los documentos registrables para poder continuar. Intentalo nuevamente.");
                return false;
            }

            SetDocumentosAgregados();
            var existeDocSinCantidad = this.DocumentosAgregados.Any(a => a.CantidadOriginal == 0);
            if (existeDocSinCantidad)
            {
                Master.ShowMessageError("Debes seleccionar por lo menos un original para cada documento agregado. Intentalo nuevamente.");
                return false;
            }

            for (var i = 0; i < this.DocumentosAgregados.Count(); i++)
            {
                var item = this.gDocumentosAgregados.Items[i];
                Int32 cantidadOriginal, cantidadCopia;
                int.TryParse(((TextBox)item.FindControl("txtCantidadDocOriginal")).Text, out cantidadOriginal);
                int.TryParse(((TextBox)item.FindControl("txtCantidadDoc")).Text, out cantidadCopia);

                this.DocumentosAgregados[i].CantidadCopia = cantidadCopia;
                this.DocumentosAgregados[i].CantidadOriginal = cantidadOriginal;
                this.DocumentosSeleccionados.Add(this.DocumentosAgregados[i]);
            }

            return true;
        }


        /// <summary>
        /// Load ServicioDocumentoRequerido From Grid
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="item"></param>
        private void LoadDocumento(RadGrid grid, GridDataItem item)
        {
            var keys = grid.MasterTableView.DataKeyValues[item.ItemIndex];

            var cantidadCopia = 0;
            var cantidadOriginal = 0;

            DateTime? fechaDocumento;
            var fechaCal = item.FindControl("radFechaDocumento") as RadDatePicker;
            var fechaLabel = item.FindControl("FechaLabel") as Label;

            if (fechaCal != null)
                fechaDocumento = fechaCal.SelectedDate;
            else
            {
                var fechaStr = fechaLabel.Text;
                DateTime fechaTemp;
                if (DateTime.TryParse(fechaStr, out fechaTemp) && fechaTemp > DateTime.MinValue)
                    fechaDocumento = fechaTemp;
                else
                    fechaDocumento = DateTime.Today;
            }

            var myCantidadCopia = item["TipoDocumento.CantidadCopia"].Text;

            int.TryParse(((TextBox)item.FindControl("txtCantidadDocOriginal")).Text, out cantidadOriginal);
            int.TryParse(((TextBox)item.FindControl("txtCantidadDoc")).Text, out cantidadCopia);

            if (cantidadCopia <= 0 && cantidadOriginal <= 0) return;

            this.DocumentosSeleccionados.Add(new Comun.ServicioDocumentoRequerido
            {
                Agregado = false,
                Fecha = fechaDocumento,
                CantidadCopia = cantidadCopia,
                CantidadOriginal = cantidadOriginal,
                Grupo = (int)keys["Grupo"],
                Requerido = (bool)keys["Requerido"],
                ServicioId = (int)keys["ServicioId"],
                TipoSociedadId = (int)keys["TipoSociedadId"],
                TipoDocumentoId = (int)keys["TipoDocumentoID"],
                Nombre = keys["TipoDocumento.Nombre"].ToString(),
                CostoCopia = (decimal)keys["TipoDocumento.CostoCopia"],
                CostoOriginal = (decimal)keys["TipoDocumento.CostoOriginal"],
                TipoDocumento =
                                                         new TipoDocumento
                                                         {
                                                             TipoDocumentoId = (int)keys["TipoDocumentoID"],
                                                             Registrable = keys["TipoDocumento.Registrable"] != null
                                                                        ? (bool)keys["TipoDocumento.Registrable"]
                                                                        : true
                                                         }
            });
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.Page_PreRenderComplete(object, EventArgs)'
        protected void Page_PreRenderComplete(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.Page_PreRenderComplete(object, EventArgs)'
        {
            //Oculto controles grid cuando no existan documentos.
            HideControles();
            SetOriginalValue(rgriddocumentos);

            foreach (RepeaterItem item in rpGrupoDoc.Items)
            {
                if (item.ItemType != ListItemType.Item && item.ItemType != ListItemType.AlternatingItem) continue;
                var grid = item.FindControl("rgriddocumentos") as RadGrid;
                if (grid == null) continue;

                SetOriginalValue(grid);
            }

            if (rpGrupoDoc.Items.Count == 0)
                rpGrupoDoc.Visible = false;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.SetOriginalValue(RadGrid)'
        protected void SetOriginalValue(RadGrid grid)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.SetOriginalValue(RadGrid)'
        {
            foreach (GridDataItem item in grid.Items)
            {
                var txtOriginal = ((TextBox)item.FindControl("txtCantidadDocOriginal"));
                var txtCantidadDoc = ((TextBox)item.FindControl("txtCantidadDoc"));
                var hfOriginal = ((HiddenField)item.FindControl("hfCostoOriginal"));
                var lblOriginal = ((Label)item.FindControl("lblOriginal"));
                var hfRegistrable = ((HiddenField)item.FindControl("hfEsRegistrable"));

                if (FormaEntrega == "D" || FormaEntrega == "d")
                    txtCantidadDoc.Visible = false;

                switch (hfRegistrable.Value)
                {
                    case "False":
                        txtOriginal.Visible = false;
                        lblOriginal.Visible = true;
                        txtCantidadDoc.Visible = true;
                        break;
                    default:
                        //txtOriginal.Text = "1";
                        //txtOriginal.ReadOnly = true;
                        break;
                }
                decimal costo = 0;
                decimal.TryParse(txtCosto.Text, out costo);
                txtCosto.Text = (costo + Convert.ToDecimal(hfOriginal.Value)).ToString();
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.btnAgregar_Click(object, EventArgs)'
        protected void btnAgregar_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.btnAgregar_Click(object, EventArgs)'
        {
            if (this.ddlDocumentos.SelectedIndex > 0)
                AgregarDocumento();
        }

        private void AgregarDocumento()
        {
            var docs = new TipoDocumentoRepository();
            var tipoDocumentoId = int.Parse(ddlDocumentos.SelectedValue);
            var tipoDocumento = docs.SelectByID(tipoDocumentoId);

            this.DocumentosAgregados.Add(new ServicioDocumentoRequerido
            {
                Agregado = true,
                CantidadCopia = 0,
                CantidadOriginal = 0,
                TipoDocumentoId = tipoDocumento.TipoDocumentoId,
                Nombre = ddlDocumentos.SelectedItem.Text,
                CostoCopia = tipoDocumento.CostoCopia,
                CostoOriginal = tipoDocumento.CostoOriginal,
                Fecha = radFechaDocumento.SelectedDate
            });

            gDocumentosAgregados.DataSource = this.DocumentosAgregados;
            gDocumentosAgregados.DataBind();

        }

        private void SetDocumentosAgregados()
        {
            int index = 0;
            foreach (GridDataItem item in gDocumentosAgregados.Items)
            {
                var cantidadOriginal = 0;
                int.TryParse(((TextBox)item.FindControl("txtCantidadDocOriginal")).Text, out cantidadOriginal);
                var cantidadCopia = 0;
                int.TryParse(((TextBox)item.FindControl("txtCantidadDoc")).Text, out cantidadCopia);

                this.DocumentosAgregados[index].CantidadCopia = cantidadCopia;
                this.DocumentosAgregados[index].CantidadOriginal = cantidadOriginal;
                index++;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.gDocumentosAgregados_Command(object, EventArgs)'
        protected void gDocumentosAgregados_Command(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.gDocumentosAgregados_Command(object, EventArgs)'
        {
            var btn = (ImageButton)sender;
            var index = int.Parse(btn.CommandArgument);

            this.DocumentosAgregados.RemoveAt(index);

            gDocumentosAgregados.DataSource = this.DocumentosAgregados;
            gDocumentosAgregados.DataBind();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.rgriddocumentos_ItemDataBound(object, GridItemEventArgs)'
        protected void rgriddocumentos_ItemDataBound(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.rgriddocumentos_ItemDataBound(object, GridItemEventArgs)'
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                var doc = (ServicioDocumentoRequerido)e.Item.DataItem;
                if (doc.TipoDocumento != null && !doc.TipoDocumento.Registrable)
                {
                    var reqFecha = (RequiredFieldValidator)e.Item.FindControl("reqFecha");
                    var radFechaDocumento = (RadDatePicker)e.Item.FindControl("radFechaDocumento");

                    reqFecha.Enabled = false;
                    reqFecha.Visible = false;
                    radFechaDocumento.Visible = false;
                }
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.ddlDocumentos_DataBound(object, EventArgs)'
        protected void ddlDocumentos_DataBound(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.ddlDocumentos_DataBound(object, EventArgs)'
        {
            //FOrce para que se escoja el primer item agregado manualmente antes que los items databound
            this.ddlDocumentos.SelectedIndex = 0;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.rpServiciosSeleccionados_ItemCommand(object, RepeaterCommandEventArgs)'
        protected void rpServiciosSeleccionados_ItemCommand(object source, RepeaterCommandEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ucRevisionDocumentos.rpServiciosSeleccionados_ItemCommand(object, RepeaterCommandEventArgs)'
        {

        }
    }
}