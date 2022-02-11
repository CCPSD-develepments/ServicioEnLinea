using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using Telerik.Web.UI;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using Cargos = CamaraComercio.DataAccess.EF.OficinaVirtual.Cargos;
using Ciudades = CamaraComercio.DataAccess.EF.OficinaVirtual.Ciudades;
using Sociedades = CamaraComercio.DataAccess.EF.OficinaVirtual.Sociedades;

namespace CamaraComercio.Website.UserControls
{
    ///<summary>
    ///</summary>
    public partial class SocioDetails : UserControl
    {
        /// <summary>
        /// Indica si se está instanciando el control para una modificación o registro de nueva empresa
        /// </summary>
        public bool EsModificacion { 
            get { return this.Page is Operaciones.Modificaciones.DatosSociedad; } 
        }

        ///<summary>
        /// Constructor por defecto
        ///</summary>
        public SocioDetails()
        {
            DataItem = null;
        }

        #region Propiedades
        ///<summary>
        /// Acceso al Item de datos bindeado
        ///</summary>
        public object DataItem { get; set; }

        /// <summary>
        /// Modo de edicion está habilitado en el grid
        /// </summary>
        public bool EditModeEnabled { get; set; }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioDetails.SociedadRegistroNuevo'
        protected Sociedades SociedadRegistroNuevo
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioDetails.SociedadRegistroNuevo'
        {
            get
            {
                if (Session["SociedadRegistroNuevo"] == null)
                    Session["SociedadRegistroNuevo"] = new Sociedades();
                return (Sociedades)Session["SociedadRegistroNuevo"];
            }
            set { Session["SociedadRegistroNuevo"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioDetails.TipoSociedadId'
        protected int TipoSociedadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioDetails.TipoSociedadId'
        {
            get
            {
                return Session["TipoSociedadId"] != null
                           ? int.Parse(Session["TipoSociedadId"].ToString())
                           : this.SociedadRegistroNuevo.TipoSociedadId.Value2();
            }
        }
        private List<Comun.TipoSociedadSocio> ListSociosRender
        {
            get
            {
                var dbComun = new Comun.CamaraComunEntities();

                Session["SociosRender"] = dbComun.TipoSociedadSocio.Include("TipoSocio").Where(
                    tp => tp.TipoSociedadId == TipoSociedadId).ToList();

                return (List<Comun.TipoSociedadSocio>)Session["SociosRender"];
            }
        }
        #endregion

        #region Eventos
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioDetails.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioDetails.Page_Load(object, EventArgs)'
        {
            DisableRepValidator();
            InitializeUI();
            AssignClientEvents(); 
        }

        /// <summary>
        /// Asigna algunos eventos en el UI para asistir al usuario con pistas visuales
        /// </summary>
        private void AssignClientEvents()
        {   
            this.txtDocumento.Attributes.Add("onblur", "javascript:$('#txtDocumentoComment').hide();");
            this.txtDocumento.Attributes.Add("onfocus", "javascript:$('#txtDocumentoComment').show(); $('#txtDocumentoComment').removeClass('hiddenObj')");
            this.txtDocumentoEmpresa.Attributes.Add("onblur", "javascript:$('#txtDocumentoEmpresaComment').hide();");
            this.txtDocumentoEmpresa.Attributes.Add("onfocus", "javascript:$('#txtDocumentoEmpresaComment').show();");
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioDetails.Page_PreRender(object, EventArgs)'
        protected void Page_PreRender(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioDetails.Page_PreRender(object, EventArgs)'
        {
            if (RepresentanteUI.FindAll().Count() != ddlRepresentante.Items.Count - 1 ||
                RepresentanteUI.FindAll().Count() != ddlRepresentanteEmpresa.Items.Count - 1)
            {
                ddlRepresentanteEmpresa.Items.Clear();
                ddlRepresentanteEmpresa.Items
                    .Add(new ListItem("Seleccione un Representante", "0"));
                ddlRepresentanteEmpresa.DataBind();

                ddlRepresentante.Items.Clear();
                ddlRepresentante.Items
                    .Add(new ListItem("Seleccione un Representante", "0"));
                ddlRepresentante.DataBind();

                //Se revisa si se escogio un representante especifico y se asigna
                if (Session["repIdSelect"] != null)
                {
                    int id;
                    if (Int32.TryParse(Session["repIdSelect"].ToString(), out id))
                    {
                        if (ddlRepresentante.Items.FindByValue(id.ToString()) != null)
                            ddlRepresentante.Items.FindByValue(id.ToString()).Selected = true;

                        if (ddlRepresentanteEmpresa.Items.FindByValue(id.ToString()) != null)
                            ddlRepresentanteEmpresa.Items.FindByValue(id.ToString()).Selected = true;
                    }
                    Session["repIdSelect"] = null;
                }
            }

            //Se bindea la lista
            if (rpRepeater.Items.Count == 0)
                ReloadTipoSocios();

            //Si luego de hacer el bind todavía sigue vacío, entonces se esconden los headers
            if (rpRepeater.Items.Count == 0)
            {
                this.lblAccionesHeader.Visible = false;
                this.litTipoCargos.Visible = false;
            }

            //Sociedad
            var sociedad = this.SociedadRegistroNuevo;
            if (Helper.TipoSociedadNoEmpresasMenoresEdad.Contains(sociedad.TipoSociedadId.Value2()))
            {
                var result =
                    ddlTipoDatos.Items.Cast<ListItem>().Where(li => li.Value == "1" || li.Value == "2").ToList();
                result.ForEach(r =>
                {
                    ddlTipoDatos.Items.Remove(r);
                    ddlTipoDatosEmpresa.Items.Remove(r);
                });
            }

            //Load verification for Empresas
            if (!(DataItem is Telerik.Web.UI.GridInsertionObject))
            {
                if (btnUpdate.Visible)
                {
                    if (!string.IsNullOrEmpty(litTipoDocumento.Text))
                    {
                        if (litTipoDocumento.Text == "C")
                        {
                            ddlTipoDocumento.SelectedIndex = 0;
                            lbltxtDocumento.Text = "Cédula";
                            //regexCedula.Enabled = true;
                        }
                        else
                        {
                            ddlTipoDocumento.SelectedIndex = 1;
                            lbltxtDocumento.Text = "Pasaporte";
                            //regexCedula.Enabled = false;
                        }
                    }

                    if (!string.IsNullOrEmpty(litCiudadID.Text) && !string.IsNullOrEmpty(litSectorID.Text))
                    {
                        //Se marca la ciudad
                        ddlCiudades.SelectedValue = litCiudadID.Text;

                        //Se refresca el listado de sectores de la ciudad
                        ddlSectores.DataBind();

                        if (ddlSectores.Items.Count > 0)
                        {
                            try
                            {
                                //Se marca el sector
                                ddlSectores.SelectedValue = litSectorID.Text;
                            }
                            catch (Exception)
                            {
                                ddlSectores.SelectedIndex = 0;
                            }
                        }
                    }

                    var socio = (DataItem as Socios);
                    if (socio == null) return;

                    if (txtSegundoNombre.Text.Length == 0 && !EditModeEnabled && socio.TipoSocio == "S")
                    {
                        mvDatosGenerales.ActiveViewIndex = 1;
                        ddlTipoDatosEmpresa.SelectedValue = "1";
                        ddlTipoDatos.SelectedValue = "1";
                    }

                    if (socio.TipoSocio == "P" && socio.TipoDocumento == "O" && socio.PersonaPrimerNombre == "AL PORTADOR")
                    {
                        ddlTipoDatosPortador.SelectedValue = "4";
                        mvDatosGenerales.SetActiveView(vSocioPortador);
                        ToggleControls(false);
                    }

                    if (socio.RepresentanteId > 0)
                    {
                        mvDatosGenerales.SetActiveView(vSocioEmpresa);
                        ddlRepresentanteEmpresa.SelectedValue = ddlRepresentante.SelectedValue = socio.RepresentanteId.ToString();
                        
                        ddlTipoDatos.SelectedValue = socio.TipoSocio == "S" ? "1" : "2";
                    }
                }
            }

        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioDetails.ddlTipoDatos_SelectedIndexChanged(object, EventArgs)'
        protected void ddlTipoDatos_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioDetails.ddlTipoDatos_SelectedIndexChanged(object, EventArgs)'
        {
            var ddl = (DropDownList)sender;

            EditModeEnabled = true;
            ToggleControls(true);

            foreach (RepeaterItem item in rpRepeater.Items)
            {
                var ddlCargos = item.FindControl("ddlCargoSocios") as DropDownList;
                if (ddlCargos != null)
                    ddlCargos.BindCollection(GetCargosFiltradosPorSocio(), Cargos.PropColumns.CargoId,
                                             Cargos.PropColumns.Descripcion);
            }

            switch (ddl.SelectedItem.Value)
            {
                case "0":
                case "2":
                    ddlTipoDatos.SelectedValue = ddl.SelectedValue;
                    mvDatosGenerales.SetActiveView(vSocioPersona);
                    vSocioPersona_Load(vSocioPersona, EventArgs.Empty);
                    break;

                case "1":
                    ddlTipoDatosEmpresa.SelectedValue = "1";
                    mvDatosGenerales.SetActiveView(vSocioEmpresa);
                    break;

                case "4":
                    ddlTipoDatosPortador.SelectedValue = "4";
                    mvDatosGenerales.SetActiveView(vSocioPortador);
                    ToggleControls(false);
                    break;

                default:
                    break;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioDetails.ddlTipoDocumento_SelectedIndexChanged(object, EventArgs)'
        protected void ddlTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioDetails.ddlTipoDocumento_SelectedIndexChanged(object, EventArgs)'
        {
            //ReloadTipoSocios();

            if (ddlTipoDocumento.SelectedValue == "P")
            {
                litTipoDocumento.Text = "P";
                regexCedula.Enabled = false;
                lbltxtDocumento.Text = "Pasaporte";                
            }
            else
            {
                litTipoDocumento.Text = "C";
                regexCedula.Enabled = true;
                lbltxtDocumento.Text = "Cédula";
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioDetails.rpRepeater_ItemCreated(object, RepeaterItemEventArgs)'
        protected void rpRepeater_ItemCreated(object source, RepeaterItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioDetails.rpRepeater_ItemCreated(object, RepeaterItemEventArgs)'
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;

            var chkBox = e.Item.FindControl("chkTipoSocio") as CheckBox;
            var ddl = e.Item.FindControl("ddlCargoSocios") as DropDownList;
            var txt = e.Item.FindControl("txtAcciones") as RadTextBox;

            var tipoSocio = e.Item.DataItem as Comun.TipoSociedadSocio;
            if (tipoSocio == null) return;
            
            //Validacion del textbox de acciones para tipos de empresas que no las reciben
            if (txt != null)
            {
                txt.Visible = tipoSocio.RecibeAcciones.HasValue && tipoSocio.RecibeAcciones.Value;

                if (txt.Visible)
                {
                    var rep = new PropiedadesPorSociedadRepository();
                    var nombreAcciones = rep.GetPropiedadesByTipo(this.TipoSociedadId)
                        .Where(p => p.PropiedadesUI.Nombre == "Acciones")
                        .FirstOrDefault();
                    if (nombreAcciones != null)
                    {
                        txt.EmptyMessage = nombreAcciones.Descripcion;
                        txt.Text = String.Empty;
                    }
                }
            }

            var socios = this.ListSociosRender;
            if (chkBox != null)
            {
                //Accionistas opcionales
                chkBox.Text = tipoSocio.Descripcion;
                if (tipoSocio.CantMinSocio.GetValueOrDefault() == 0)
                    chkBox.Text += " (Opcional)";
                var totalSocio = SocioUI.FindAll(tipoSocio.TipoSocioId).Count();
                var cantSocios = socios.Where(a => a.TipoSocioId == tipoSocio.TipoSocioId).Sum(a => a.CantMaxSocio);
                if (cantSocios > 0)
                    chkBox.Enabled = cantSocios > totalSocio;

            }

            //Tipos de socios que reciben cargos
            if (ddl != null)
            {
                if (tipoSocio.RecibeCargo.HasValue && tipoSocio.RecibeCargo.Value)
                {
                    var cargos = GetCargosFiltradosPorSocio();
                    ddl.BindCollection(cargos, Cargos.PropColumns.CargoId, Cargos.PropColumns.Descripcion);
                    if (cargos.Count == 0)
                    {
                        if (chkBox != null) chkBox.Visible = false;
                        ddl.Visible = false;
                    }
                }
                else
                    ddl.Visible = false;
            }

            //Valores seleccionados
            var socio = (DataItem as Socios);
            if (socio == null && litSocio.Text.Length > 0)
                socio = SocioUI.FindById(int.Parse(litSocio.Text), tipoSocio.TipoSocioId);
            if (socio == null) return;
            var currentSocio = SocioUI.FindById(socio.Id, tipoSocio.TipoSocioId);
            if (currentSocio == null) return;
            chkBox.Checked = true;

            if (currentSocio.CargoId.Value2() > 0)
            {
                var ddlSelected = ddl.Items.FindByValue(currentSocio.CargoId.Value2().ToString());
                if (ddlSelected != null)
                    ddl.SelectedValue = currentSocio.CargoId.Value2().ToString();
                else
                    ddl.SelectedIndex = 0;
            }

            txt.Text = currentSocio.CantidadAcciones.Value2().ToString();
            
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioDetails.GetCargosFiltradosPorSocio()'
        protected List<Comun.Cargos> GetCargosFiltradosPorSocio()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioDetails.GetCargosFiltradosPorSocio()'
        {
            var tipoSocioId = String.Empty;
            var view = mvDatosGenerales.GetActiveView().ID;
            switch (view)
            {
                case "vSocioPersona":
                    tipoSocioId = ddlTipoDatos.SelectedValue;
                    break;
                case "vSocioEmpresa":
                    tipoSocioId = ddlTipoDatosEmpresa.SelectedValue;
                    break;
            }

            var repCargos = new Comun.CargosRepository();
            bool puedeSerEmpresa = tipoSocioId == "1"; //TipoEmpresa 
            var cargos = repCargos.SelectByTipoSociedadId(this.TipoSociedadId, puedeSerEmpresa, this.EsModificacion);

            return cargos;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioDetails.vSocioPersona_Load(object, EventArgs)'
        protected void vSocioPersona_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioDetails.vSocioPersona_Load(object, EventArgs)'
        {
            //Si es menor de edad, se deshabilitan las opciones de cédula
            if (ddlTipoDatos.SelectedValue == "2")
            {
                this.ddlTipoDocumento.Visible = false;
                this.txtDocumento.Visible = false;
                this.ddlEstadoCivil.Visible = false;
                this.lbltxtDocumento.Visible = false;
                this.lblEstadoCivil.Visible = false;
                this.lblddTipoDocumento.Visible = false;
                //this.regexCedula.Enabled = false;
                this.rfvCedula.Enabled = false;
                this.pnlMenorEdad.Visible = true;
            }
            else
            {
                this.ddlTipoDocumento.Visible = true;
                this.txtDocumento.Visible = true;
                this.ddlEstadoCivil.Visible = true;
                this.lbltxtDocumento.Visible = true;
                this.lblEstadoCivil.Visible = true;
                this.lblddTipoDocumento.Visible = true;
                //this.regexCedula.Enabled = true;
                this.rfvCedula.Enabled = false;
                this.pnlMenorEdad.Visible = false;
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Inicializa el UI con los valores correspondientes
        /// </summary>
        private void InitializeUI()
        {
            var dbComun = new Comun.CamaraComunEntities();

            //Ciudades
            if (ddlCiudades.Items.Count == 0)
            {
                var repCiudades = new Comun.CiudadesRepository();
                var colCiudades = repCiudades.FecthInDominicanRepublic(Helper.CiudadesPrincipales, Helper.IdPaisRD);
                this.ddlCiudades.BindCollection(colCiudades, Ciudades.PropColumns.CiudadId, Ciudades.PropColumns.Nombre);
            }

            //Estados Civiles
            if (ddlEstadoCivil.Items.Count == 0)
            {
                var civils = EstadoCivil.FetchAll();
                ddlEstadoCivil.BindCollection(civils, "Value", "Text");
            }

            //Paises
            var paises = dbComun.Paises.OrderBy(p => p.Nombre).ToList();
            var paisesF = paises.Where(p => !String.IsNullOrWhiteSpace(p.Nombre));
            if (ddlNacionalidadPersona.Items.Count == 0)
                ddlNacionalidadPersona.BindCollection(paisesF, Paises.PropColumns.PaisId, Paises.PropColumns.Nombre, Helper.IdPaisRD.ToString());
            if (ddlNacionalidadEmpresa.Items.Count == 0)
                ddlNacionalidadEmpresa.BindCollection(paisesF, Paises.PropColumns.PaisId, Paises.PropColumns.Nombre, Helper.IdPaisRD.ToString());

            //Validación del repeater de tipos de socios
            //var sm = ScriptManager.GetCurrent(this.Page);
            if (rpRepeater.Items.Count == 0)
                ReloadTipoSocios();

            //Acciones al portador para empresas que lo permiten
            var tiposPersonas = ObtenerTiposPersonas().ToArray();
            if (ddlTipoDatos.Items.Count == 0)
            {
                this.ddlTipoDatos.Items.AddRange(tiposPersonas);
                this.ddlTipoDatos.DataBind();
                this.ddlTipoDatos.SelectedIndex = 0;
            }
            if (ddlTipoDatosEmpresa.Items.Count == 0)
            {
                this.ddlTipoDatosEmpresa.Items.AddRange(tiposPersonas);
                this.ddlTipoDatosEmpresa.DataBind();
                this.ddlTipoDatosEmpresa.SelectedIndex = 0;
            }
            if (ddlTipoDatosPortador.Items.Count == 0)
            {
                this.ddlTipoDatosPortador.Items.AddRange(tiposPersonas);
                this.ddlTipoDatosPortador.DataBind();
                this.ddlTipoDatosPortador.SelectedIndex = 0;
            }

            //A las empresas de un único dueño no se les asignan acciones. Por eso se esconde el header
            if (Helper.TipoSociedadNoEmpresasMenoresEdad.Contains(this.TipoSociedadId) && rpRepeater.Items.Count > 0)
            {
                var lblAccionesHeader = rpRepeater.FindControlInHeader("lblAccionesHeader");
                if (lblAccionesHeader != null)
                    lblAccionesHeader.Visible = false;
            }

        }

        /// <summary>
        /// Obtiene los valores que se van a renderizar dentro de los dropdownlists de tipos de personas
        /// </summary>
        /// <returns></returns>
        private List<ListItem> ObtenerTiposPersonas()
        {
            var col = new List<ListItem>
                          {
                              new ListItem("Persona", "0"),
                              new ListItem("Empresa", "1"),
                              new ListItem("Menor de Edad", "2")
                          };

            var autorizadosAp = Helper.TipoSociedadAlPortador;
            if (autorizadosAp.Contains(this.TipoSociedadId))
                col.Add(new ListItem("Al Portador", "4"));

            return col;
        }

        /// <summary>
        /// Inicializa los tipos de socios
        /// </summary>
        private void ReloadTipoSocios()
        {
            rpRepeater.DataSource = null;
            rpRepeater.DataSource = ListSociosRender;
            rpRepeater.DataBind();

            this.lblAccionesHeader.Visible = false;
            foreach (RepeaterItem item in rpRepeater.Items)
            {
                var txt = item.FindControl("txtAcciones");
                if (txt != null && txt.Visible)
                {
                    this.lblAccionesHeader.Visible = true;
                    break;
                }
            }
        }

        /// <summary>
        /// Esconde y muestra los controles en el user control
        /// </summary>
        /// <param name="enabled"></param>
        private void ToggleControls(bool enabled)
        {
            this.pnlDireccion.Visible = enabled;

            if (!enabled)
            {
                for (var i = 1; i < this.rpRepeater.Items.Count; i++)
                {
                    //Instancia del row
                    var row = this.rpRepeater.Items[i];

                    //Se esconden todos los controles
                    var chk = row.FindControl("chkTipoSocio");
                    if (chk != null && chk is CheckBox)
                    {
                        chk.Visible = false;
                    }

                    var ddl = row.FindControl("ddlCargoSocios");
                    if (ddl != null && ddl is DropDownList)
                        ddl.Visible = false;
                }
            }
        }

        /// <summary>
        /// Deshabilita el validator para los representantes
        /// </summary>
        private void DisableRepValidator()
        {
            reqRepresentante.Enabled = ddlTipoDatos.SelectedValue != "0";
        }

        #endregion
    }
}