using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.Website.Helpers.ExtendedControls;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using Telerik.Web.UI;
using System.Linq;

namespace CamaraComercio.Website.UserControls
{
    ///<summary>
    /// User Control que maneja la administración de socios
    ///</summary>
    public partial class ManejoSocios : UserControl, IExtendedControlOfv, IOfvUserControl
    {
        #region Propiedades

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.SociedadRegistroNuevo'
        protected Sociedades SociedadRegistroNuevo
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.SociedadRegistroNuevo'
        {
            get
            {
                if (Session["SociedadRegistroNuevo"] == null)
                    Session["SociedadRegistroNuevo"] = new Sociedades();
                return (Sociedades)Session["SociedadRegistroNuevo"];
            }
            set { Session["SociedadRegistroNuevo"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.SociosEnRegistro'
        protected List<Socios> SociosEnRegistro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.SociosEnRegistro'
        {
            get
            {
                if (Session["Socios"] == null)
                    Session["Socios"] = new List<Socios>();
                return (List<Socios>)Session["Socios"];
            }
            set
            {
                Session["Socios"] = value;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.TipoSociedadId'
        protected int TipoSociedadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.TipoSociedadId'
        {
            get
            {
                return Session["TipoSociedadId"] != null
                           ? int.Parse(Session["TipoSociedadId"].ToString())
                           : this.SociedadRegistroNuevo.TipoSociedadId.Value2();
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.TipoSociedadIdQuery'
        protected int TipoSociedadIdQuery
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.TipoSociedadIdQuery'
        {
            get
            {
                var tipoSociedadId = 0;
                if (!String.IsNullOrEmpty(Request.QueryString["TipoSociedadId"]))
                    Int32.TryParse(Request.QueryString["TipoSociedadId"], out tipoSociedadId);
                return tipoSociedadId;
            }
        }

        ///<summary>
        /// Listado de socios a renderizar
        ///</summary>
        public IEnumerable<TipoSociedadSocio> ListSociosRender
        {
            get
            {
                var dbComun = new CamaraComunEntities();
                if (Session["SociosRender"] == null)
                    Session["SociosRender"] = dbComun.TipoSociedadSocio.Include("TipoSocio").Where(
                        tp => tp.TipoSociedadId == TipoSociedadIdQuery).ToList();

                return (List<TipoSociedadSocio>)Session["SociosRender"];
            }
        }
        ///<summary>
        /// Miembro de la interfaz IExtendedControlOfv, necesario para asignar nombres de forma dinámica
        ///</summary>
        public string PropertyName
        { get; set; }

        ///<summary>
        /// Tipo de Relacion
        ///</summary>
        public string TipoRelacion { get; set; }

        /// <summary>
        /// Indica si se está instanciando el control para una modificación o registro de nueva empresa
        /// </summary>
        public bool EsModificacion { get; set; }

        #endregion

        /// <summary>
        /// Override del método OnInit para asignación de datasources
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            //Data Source Socios
            odsSocios.TypeName = "CamaraComercio.Website.SocioUI";
            odsSocios.SelectMethod = "FindDistinct";
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.Page_Load(object, EventArgs)'
        {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.Enable(bool)'
        public void Enable(bool enable)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.Enable(bool)'
        {
            RecursiveEnable(this, enable);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.RecursiveEnable(Control, bool)'
        public void RecursiveEnable(Control ctrl, bool enable)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.RecursiveEnable(Control, bool)'
        {
            if (ctrl == null) return;

            if (ctrl is WebControl)
            {
                var webCtrl = ((WebControl) ctrl);
                webCtrl.Enabled = enable;
            }

            foreach (Control child in ctrl.Controls)
                RecursiveEnable(child, enable);
        }

        /// <summary>
        /// Mensaje para los grids vacios
        /// </summary>
        public string MensajeRecordsVacios
        {
            set { rgSocios.MasterTableView.NoMasterRecordsText = value; }
        }

        /// <summary>
        /// Formatea el nombre de un socio en el grid
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="segundoNombre"></param>
        /// <param name="apellido"></param>
        /// <param name="segundoApellido"></param>
        /// <param name="repNombre"></param>
        /// <param name="repSegundoNombre"></param>
        /// <param name="repApellido"></param>
        /// <param name="repSegundoApellido"></param>
        /// <returns></returns>
        public string FormatNombreSocio(string nombre, string segundoNombre, string apellido, string segundoApellido,
            string repNombre, string repSegundoNombre, string repApellido, string repSegundoApellido)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("{0} {1} {2} {3} ", nombre, segundoNombre, apellido, segundoApellido);
            if (repNombre.Length > 0 || repSegundoNombre.Length > 0 || repApellido.Length > 0 || repSegundoApellido.Length > 0)
                sb.AppendFormat("(Representado por {0} {1} {2} {3})", repNombre, repSegundoNombre, repApellido, repSegundoApellido);
            return sb.ToString();
        }

        /// <summary>
        /// Despliegue de errores en el grid de socios
        /// </summary>
        /// <param name="eventArgs"></param>
        /// <param name="error"></param>
        private void DisplayError(IGridCommandEvent eventArgs, string error)
        {
            if (eventArgs == null) throw new ArgumentNullException("eventArgs");
            var lblError = new Label
            {
                Text = error,
                ForeColor = Color.Red
            };
            rgSocios.Controls.Add(lblError);
            eventArgs.Canceled = true;
        }

        #region Socios Grid Event Handlers

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.RadGrid1_InsertCommand(object, GridCommandEventArgs)'
        protected void RadGrid1_InsertCommand(object source, GridCommandEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.RadGrid1_InsertCommand(object, GridCommandEventArgs)'
        {
            this.rgSocios.ShowHeader = true;
            var userControl = e.Item.FindControl(GridEditFormItem.EditFormUserControlID) as UserControl;
            var socio = RadUtils.GetSocioFromControl(TipoRelacion, userControl, 0);
                socio.Modificado = true;

            var message = InsertSociosInRepeater(userControl, socio);
            if (!String.IsNullOrWhiteSpace(message))
                DisplayError(e, message);

        }
        private String InsertSociosInRepeater(UserControl userControl, Socios socio)
        {
            var result = 0;

            //Validacion de grupos
            var validGroup = RadUtils.CheckValidationGroupInRepeater
                (userControl, "rpRepeater", "chkTipoSocio", "hfGrupoValidacion");
            if (!validGroup)
            {
                return "Ha seleccionado cargos que no pueden ser ocupados por el mismo socio.";
            }

            foreach (var item in ListSociosRender)
            {
                var isOtroTipoSocio = RadUtils.GetCheckboxInsideRepeater(userControl, "rpRepeater", "chkTipoSocio",
                                                                         "hfTipoSocioId",
                                                                         item.TipoSocioId);
                if (!isOtroTipoSocio) continue;
                result += 1;
                var newSocio = Utils.Clone<Socios>(socio);
                newSocio.TipoRelacion = item.TipoSocioId;

                var cargo = RadUtils.GetDropDownValueInsideRepeater(userControl, "rpRepeater",
                                                                    "chkTipoSocio",
                                                                    "hfTipoSocioId", "ddlCargoSocios",
                                                                    item.TipoSocioId);


                var cantAcciones = RadUtils.GetTextBoxValueInsideRepeater<RadTextBox>(userControl, "rpRepeater",
                                                                          "txtAcciones",
                                                                          "hfTipoSocioId",
                                                                          item.TipoSocioId);
                if (item.RecibeAcciones.Value2())
                {
                    var cant = 0;
                    Int32.TryParse(cantAcciones, out cant);
                    if (cant == 0)
                        return "Debe especificar el monto de acciones o cuotas sociales.";
                    newSocio.CantidadAcciones = cant;
                }
                newSocio.CargoId = String.IsNullOrWhiteSpace(cargo) ? (int?)null : int.Parse(cargo);

                SocioUI.Insert(newSocio);
                socio.Id = newSocio.Id;
            }

            return result == 0 && this.ListSociosRender.Sum(a => a.CantMinSocio) > 0
                       ? "Debe Seleccionar al Menos un TIPO DE CARGO."
                       : String.Empty;
        }
        
        private String UpdateSociosInRepeater(UserControl userControl, Socios socio)
        {
            var result = 0;

            //Validacion de grupos
            var validGroup = RadUtils.CheckValidationGroupInRepeater
                (userControl, "rpRepeater", "chkTipoSocio", "hfGrupoValidacion");
            if (!validGroup)
            {
                return "Ha seleccionado cargos que no pueden ser ocupados por el mismo socio.";
            }

            foreach (var item in ListSociosRender)
            {
                var isOtroTipoSocio = RadUtils.GetCheckboxInsideRepeater(userControl, "rpRepeater", "chkTipoSocio",
                                                                         "hfTipoSocioId",
                                                                         item.TipoSocioId);
                Socios newSocio = Utils.Clone<Socios>(socio);
                newSocio.TipoRelacion = item.TipoSocioId;
                var socioDel = SocioUI.FindById(newSocio.Id, newSocio.TipoRelacion);

                if (!isOtroTipoSocio)
                {
                    if (socioDel != null)
                        SocioUI.Delete(socioDel);
                }
                else
                {
                    result += 1;
                    var cargo = RadUtils.GetDropDownValueInsideRepeater(userControl, "rpRepeater",
                                                                        "chkTipoSocio",
                                                                        "hfTipoSocioId", "ddlCargoSocios",
                                                                        item.TipoSocioId);

                    newSocio.CargoId = String.IsNullOrWhiteSpace(cargo) ? (int?)null : int.Parse(cargo);
                    if (item.RecibeCargo.Value2() && newSocio.CargoId == -1)
                        return "Debe seleccionar un cargo";

                    var cantAcciones = RadUtils.GetTextBoxValueInsideRepeater<RadTextBox>(userControl, "rpRepeater",
                                                                                          "txtAcciones",
                                                                                          "hfTipoSocioId",
                                                                                          item.TipoSocioId);
                    if (item.RecibeAcciones.Value2())
                    {
                        int cant = 0;
                        int.TryParse(cantAcciones, out cant);
                        if (cant == 0)
                            return "Debe especificar el monto de acciones o cuotas sociales.";
                        newSocio.CantidadAcciones = cant;
                    }


                    if (socioDel == null)
                        SocioUI.Insert(newSocio);
                    else
                        SocioUI.Update(newSocio, newSocio.TipoRelacion);

                    socio.Id = newSocio.Id;
                }
            }
            return result == 0 && this.ListSociosRender.Sum(a => a.CantMinSocio) > 0
                       ? "Debe Seleccionar al Menos un TIPO DE CARGO."
                       : String.Empty;
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.RadGrid1_UpdateCommand(object, GridCommandEventArgs)'
        protected void RadGrid1_UpdateCommand(object source, GridCommandEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.RadGrid1_UpdateCommand(object, GridCommandEventArgs)'
        {
            this.rgSocios.ShowHeader = true;
            var editedItem = e.Item as GridEditableItem;
            var userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            if (editedItem == null)
                throw new System.Net.WebException("Error al intentar acceder al grid en SocioDetails.ascx");

            //Se obtiene el ID del socio
            int socioId = Convert.ToInt32(editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["Id"].ToString());

            //Se envia un error en caso de que el ID del socio sea 0
            if (socioId == 0)
            {
                rgSocios.Controls.Add(new LiteralControl("Error al seleccionar al socio."));
                e.Canceled = true;
                return;
            }

            //Obtener la Instancia del Socio
            var socio = RadUtils.GetSocioFromControl(TipoRelacion, userControl, socioId);
                socio.Modificado = true;

            //Determinar si Socio es del organo de administracion
            var message = UpdateSociosInRepeater(userControl, socio);
            if (!String.IsNullOrWhiteSpace(message))
                DisplayError(e, message);
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.RadGrid1_DeleteCommand(object, GridCommandEventArgs)'
        protected void RadGrid1_DeleteCommand(object source, GridCommandEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.RadGrid1_DeleteCommand(object, GridCommandEventArgs)'
        {
            //Se obtiene el ID del socio
            int socioId = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"].ToString());
            try
            {
                //Se elimina el socio
                SocioUI.Delete(socioId);
            }
            catch (Exception ex)
            {
                DisplayError(e, string.Format("No fue posible eliminar el socio. Razon: {0}", ex.Message));
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.rapUpdate_PreRender(object, EventArgs)'
        protected void rapUpdate_PreRender(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.rapUpdate_PreRender(object, EventArgs)'
        {
            this.pnlCantidadSocios.Visible = (this.rgSocios.Items.Count == 0);

        }

        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.rgSocios_DataBound(object, EventArgs)'
        protected void rgSocios_DataBound(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.rgSocios_DataBound(object, EventArgs)'
        {

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.rgSocios_ItemDataBound(object, GridItemEventArgs)'
        protected void rgSocios_ItemDataBound(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.rgSocios_ItemDataBound(object, GridItemEventArgs)'
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                var socio = (Socios)e.Item.DataItem;
                
                //Cargos
                var cargos = SocioUI.CargosDelSocio(socio.Id, this.TipoSociedadIdQuery);
                var lbl = e.Item.FindControl("lblCargosSocio") as Label;
                lbl.Text = cargos;

                //Formateo del nombre cuando tiene representantes
                var reps = Session["Representantes"] as List<Personas>;
                if (socio.RepresentanteId != null && socio.RepresentanteId > 0 && reps != null)
                {
                    var representante = reps.Where(r => r.PersonaId == socio.RepresentanteId).FirstOrDefault();
                    if (representante == null) return;
                    
                    var lblNombre = e.Item.FindControl("lblNombre") as Label;
                    if (lblNombre == null) return;
                    
                    lblNombre.Text = lblNombre.Text.Trim() + String.Format(" (Representado por {0})" , representante.NombreCompleto);

                    //Formateo del RM cuando se trata de una empresa
                    if (!String.IsNullOrEmpty(socio.RegistroMercantil))
                    {
                        var lblDocumento = e.Item.FindControl("DocumentoLabel") as Label;
                        if (lblDocumento != null)
                            lblDocumento.Text = socio.RegistroMercantil;
                    }
                }
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.rgSocios_EditCommand(object, GridCommandEventArgs)'
        protected void rgSocios_EditCommand(object source, GridCommandEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.rgSocios_EditCommand(object, GridCommandEventArgs)'
        {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.rgSocios_ItemEvent(object, GridItemEventArgs)'
        protected void rgSocios_ItemEvent(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.rgSocios_ItemEvent(object, GridItemEventArgs)'
        {
            this.rgSocios.ShowHeader = !e.Item.IsInEditMode;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.rgSocios_ItemCommand(object, GridCommandEventArgs)'
        protected void rgSocios_ItemCommand(object source, GridCommandEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ManejoSocios.rgSocios_ItemCommand(object, GridCommandEventArgs)'
        {
            if (e.CommandName == "Cancel")
                this.rgSocios.ShowHeader = true;
        }
    }
}
