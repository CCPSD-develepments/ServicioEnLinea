using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website.Operaciones.Ventanilla
{
    /// <summary>
    /// Página donde se definen los datos generales de una sociedad/empresa/persona
    /// </summary>
    
    public partial class DatosGenerales : FormularioPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Form.DefaultButton = btnDatosGeneralesLlenos.UniqueID;
            if (IsPostBack) return;

            LoadData();
            LoadExistingValues();

            if (!DefaultQueryString.Contains("action=edit"))
                DefaultQueryString = "action=edit";

            //Eventos Client-Side
            if (IsFormularionConfirmacion || this.IsEditMode)
                LoadFormData();
        }

        private void LoadData()
        {
            var dbComun = new Comun.CamaraComunEntities();
            var info = CultureInfo.CurrentCulture.TextInfo;

            //Actividades Economicas
            var colActividades = dbComun.Actividades
                .OrderBy(a => a.Descripcion).ToList()
                .Select(a => new { a.ActividadID, Descripcion = info.ToTitleCase(a.Descripcion.ToLower()) });
            cblActividades.BindCollection(colActividades, Comun.Actividades.PropColumns.ActividadID, Comun.Actividades.PropColumns.Descripcion);

            // Paises
            var colPaises = dbComun.Paises
                .Where(c => c.Nombre.Length > 0)
                .OrderBy(c => c.Nombre).ToList()
                .Select(c => new { c.PaisId, Nombre = info.ToTitleCase(c.Nombre.ToLower()) });
            ddlPais.BindCollection(colPaises, Comun.Paises.PropColumns.PaisId, Comun.Paises.PropColumns.Nombre);

            //Pais default
            var paisDefault = dbComun.Paises.FirstOrDefault(p => p.PaisId == Helper.IdPaisRD);
            if (paisDefault != null)
            {
                this.ddlPais.Items.FindByValue(paisDefault.PaisId.ToString()).Selected = true;
                this.hfPaisIdRepDominicana.Value = paisDefault.PaisId.ToString();
            }

            //Tipos de sociedades que permiten establecer la nacionalidad distinta a República Dominicana
            var sbExtranjeras = new StringBuilder();
            Helper.TipoSociedadExtranjera.ForEach(c => sbExtranjeras.AppendFormat("{0},", c));
            this.hfEmpresasExtranjeras.Value = sbExtranjeras.ToString().Trim().TrimEnd(',');


            //Ciudades
            var paisDefaultId = Convert.ToInt32(this.ddlPais.SelectedItem.Value);

            var colCiudades = new Comun.CiudadesRepository().FecthInDominicanRepublic(Helper.CiudadesPrincipales, paisDefaultId);
            colCiudades.ForEach(a => { a.Nombre = info.ToTitleCase(a.Nombre.ToLower()); });
            ddlCiudad.BindCollection(colCiudades, Comun.Ciudades.PropColumns.CiudadId, Comun.Ciudades.PropColumns.Nombre);


            //Sectores por Default
            var ciudadDefaultId = Convert.ToInt32(this.ddlCiudad.SelectedItem.Value);
            var colSectores = new Comun.SectoresRepository().FetchByCiudad(ciudadDefaultId).ToList();
            colSectores.ForEach(a => { a.Nombre = info.ToTitleCase(a.Nombre.ToLower()); });
            ddlSector.BindCollection(colSectores, Comun.Sectores.PropColumns.SectorId, Comun.Sectores.PropColumns.Nombre);

            HideDropDownLocalidad();

        }

        /// <summary>
        /// Esconde el dropdown de localidad
        /// </summary>
        private void HideDropDownLocalidad()
        {
            if (ddlSector.Items.Count == 0)
            {
                ddlSector.Visible = false;
                lblSectores.Visible = true;
            }

            if (ddlCiudad.Items.Count == 0)
            {
                ddlCiudad.Visible = false;
                txtCiudad.Visible = true;
            }
        }

        /// <summary>
        /// Carga de datos existentes
        /// </summary>
        private void LoadExistingValues()
        {
            var dbEntities = new Comun.CamaraComunEntities();

            //Tipos de sociedades a registrar
            var colEmpresas = dbEntities.TipoSociedad.Where(ts => ts.SiteVisible == true).ToList();
            if (this.RegistroNuevo.EsNuevoRegistro)
            {
                var colEmpresasOrden =colEmpresas.FindAll(a => Helper.TipoSociedadOrdenConstitucion.Contains(a.TipoSociedadId));
                colEmpresasOrden.AddRange(
                    colEmpresas.FindAll(a => !Helper.TipoSociedadOrdenConstitucion.Contains(a.TipoSociedadId)));

                colEmpresas = colEmpresasOrden;
            }
            this.ddAdecuacion.BindCollection(colEmpresas, 
                Comun.TipoSociedad.PropColumns.TipoSociedadId, 
                Comun.TipoSociedad.PropColumns.Descripcion);

            //Registro
            if (RegistroNuevo != null && RegistroNuevo.EsNuevoRegistro)
            {
                this.lblFechaVencimiento.Text = "A determinar";
                this.lblTipoEmpresaActual.Text = "Nueva Empresa";

                this.lblTipoEmpresaActual.Visible = false;
                this.lblLblTipoEmpresaActual.Visible = false;
                this.lbllblFechaEmision.Visible = false;
                this.lblFechaEmision.Visible = false;
                this.lblFechaVencimiento.Visible = false;
                this.lbllblFechaVencimiento.Visible = false;

                this.lblFechaEmision.Text = Utils.FormatearFecha(DateTime.Now);
                this.lblDenominacionSocial.Text = SociedadRegistroNuevo.NombreSocial;

            }
            else
            {
                //Datos generales de la empresa
                var soc = RegistroSistemaActual.SociedadesRegistros.FirstOrDefault();
                this.lblDenominacionSocial.Text = soc.Sociedades.NombreSocial;
                this.lblFechaEmision.Text = RegistroSistemaActual.FechaEmision != null
                                                ? Utils.FormatearFecha(RegistroSistemaActual.FechaEmision.Value)
                                                : "No disponible";
                this.lblFechaVencimiento.Text = RegistroSistemaActual.FechaVencimiento != null
                                                ? Utils.FormatearFecha(RegistroSistemaActual.FechaVencimiento.Value)
                                                : "No disponible";
                this.lblTipoEmpresaActual.Text = soc.Sociedades.TipoSociedad ?? "No disponible";


                //Validacion de la renovacion
                if (ValidarRenovacionNecesaria())
                {
                    this.pnlRenovacionVencida.Visible = true;
                }
            }
        }

        /// <summary>
        /// Filtro de los sectores en base a la ciudad escogida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            var info = CultureInfo.CurrentCulture.TextInfo;
            var ciudadId = ddlCiudad.SelectedItem != null ? int.Parse(ddlCiudad.SelectedValue) : 0;

            var colSectores = new Comun.SectoresRepository().FetchByCiudad(ciudadId).ToList();
            colSectores.ForEach(a => { a.Nombre = info.ToTitleCase(a.Nombre.ToLower()); });

            ddlSector.BindCollection(colSectores, Comun.Sectores.PropColumns.SectorId, Comun.Sectores.PropColumns.Nombre);

            if (ddlSector.Items.Count == 0)
            {
                ddlSector.Visible = false;
                lblSectores.Text = "No Aplica";
            }
            else
            {
                ddlSector.Visible = true;
                lblSectores.Text = String.Empty;
            }
        }

        // 02 - Llenado de los datos de la empresa
        protected void btnDatosGeneralesLlenos_Click(object sender, EventArgs e)
        {
            #region Validaciones
            //Se valida que el usuario haya escogido por lo menos una actividad comercial
            lblErrorActividades.Text = "";
            if (!SeleccionoItemsEnListado(cblActividades))
            {
                lblErrorActividades.Text = "Debe seleccionar por lo menos un tipo de actividad comercial";
                return;
            }

            //Se valida que el usuario haya escogido por lo menos tres productos
            this.lblErrorActividades.Text = "";
            int cantidadProductos;
            Int32.TryParse(this.hfCantidadProductos.Value, out cantidadProductos);
            if (cantidadProductos == 0)
            {
                this.txtPrincipalesProductosReq.Text = "Debe ingresar por lo menos un producto";
                return;
            }
            #endregion

            //Variable que indica si la empresa a constituir es extranjera
            var esExtranjera = Helper.TipoSociedadExtranjera.Contains(Int32.Parse(ddAdecuacion.SelectedValue));
            
            //Asignacion de valores al objeto sociedad
            var tipoSociedadID = Convert.ToInt32(this.ddAdecuacion.SelectedItem.Value);
            this.TipoSociedadId = tipoSociedadID;
            this.SociedadRegistroNuevo.TipoSociedadId = tipoSociedadID;
            this.SociedadRegistroNuevo.NombreSocial = this.lblDenominacionSocial.Text;
            
            this.SociedadRegistroNuevo.EsNacional = esExtranjera;
            this.SociedadRegistroNuevo.TieneCapitalSocial = true;

            //Coleccion de reglas del Business Logic
            this.PropiedadesSociedadActual = new OFV.PropiedadesPorSociedadRepository().GetPropiedadesByTipo(TipoSociedadId);

            //Para empresas nuevas se omite la asignacion del registro mercantil
            if (!this.RegistroNuevo.EsNuevoRegistro)
            {
                var soc = this.RegistroSistemaActual.SociedadesRegistros.FirstOrDefault();
                if (soc != null)
                    this.RegistroNuevo.RegistroMercantil = Convert.ToInt32(soc.NumeroRegistro);
            }

            this.RegistroNuevo.FechaEmision = this.RegistroSistemaActual.FechaEmision;
            this.RegistroNuevo.FechaVencimiento = this.RegistroSistemaActual.FechaVencimiento;
            this.RegistroNuevo.DireccionCalle = this.txtDireccionEmpCalle.Text;
            this.RegistroNuevo.DireccionNumero = this.txtDireccionEmpNumero.Text;
            this.RegistroNuevo.DireccionCiudadId = ddlCiudad.SelectedItem != null ? Convert.ToInt32(ddlCiudad.SelectedItem.Value) : (int?)null;

            if (esExtranjera)
            {
                this.RegistroNuevo.DireccionSectorId = ddlSector.SelectedItem != null ? Convert.ToInt32(ddlSector.SelectedItem.Value) : (int?)null;
                this.RegistroNuevo.DireccionCiudadId = ddlCiudad.SelectedItem != null ? Convert.ToInt32(ddlCiudad.SelectedItem.Value) : (int?)null;
                this.RegistroNuevo.DireccionCiudad = ddlCiudad.SelectedItem != null ? ddlCiudad.SelectedItem.Text : String.Empty;
            }
            else
            {
                this.RegistroNuevo.DireccionCiudad = txtCiudad.Text.Length > 0 ? txtCiudad.Text : String.Empty;
            }

            this.RegistroNuevo.DireccionApartadoPostal = this.txtApartadoPostal.Text;
            this.RegistroNuevo.DireccionTelefonoOficina = this.txtTelefonoPrimario.Text.RemoverFormato() + " " +
                                                          this.txtTelefonoPrimarioExtension.Text.RemoverFormato();
            this.RegistroNuevo.DireccionTelefonoCasa = this.txtTelefonoSecundario.Text.RemoverFormato() + " " +
                                                       this.txtTelefonoSecundarioExtension.Text.RemoverFormato();
            this.RegistroNuevo.DireccionFax = this.txtFax.Text.RemoverFormato();
            this.RegistroNuevo.DireccionEmail = this.txtEmail.Text;
            this.RegistroNuevo.DireccionSitioWeb = this.txtWebsite.Text;
            this.RegistroNuevo.ActividadNegocio = this.txtActividadDescripcion.Text;

            //Fechas de emision
            this.RegistroNuevo.FechaEmision = this.RegistroSistemaActual.FechaEmision != null
                                               ? this.RegistroSistemaActual.FechaEmision.Value
                                               : DateTime.Today;
            this.RegistroNuevo.FechaVencimiento = this.RegistroSistemaActual.FechaVencimiento != null
                                                ? this.RegistroSistemaActual.FechaVencimiento.Value
                                                : DateTime.Today.AddYears(2);

            //Actividades Comerciales
            this.ActividadesEnRegistro = new List<OFV.RegistrosActividades>();
            for (var i = 0; i < cblActividades.Items.Count; i++)
            {
                if (cblActividades.Items[i].Selected)
                {
                    var actividad = new OFV.RegistrosActividades { TipoActividadId = Convert.ToInt32(cblActividades.Items[i].Value) };
                    ActividadesEnRegistro.Add(actividad);
                }
            }

            //Productos y servicios
            this.ProductosEnRegistro = new List<OFV.Productos>();
            if (this.hfProductos.Value.Length > 0)
            {
                var productos = this.hfProductos.Value.Split(',');
                foreach (var producto in productos)
                {
                    this.ProductosEnRegistro
                        .Add(new OFV.Productos { Descripcion = producto });
                }
            }

            Response.Redirect("DatosSociedad.aspx" + DefaultQueryString);
        }

        // 03 - Llenado de interfaz para modificación
        protected void LoadFormData()
        {
            //Asignacion de valores al objeto sociedad
            this.ddAdecuacion.SelectedValue = this.SociedadRegistroNuevo.TipoSociedadId != null ?
                this.SociedadRegistroNuevo.TipoSociedadId.ToString() :
                String.Empty;

            this.lblDenominacionSocial.Text = this.SociedadRegistroNuevo.NombreSocial;
            this.ddAdecuacion.SelectedValue = this.SociedadRegistroNuevo.TipoSociedadId.HasValue ?
                this.SociedadRegistroNuevo.TipoSociedadId.ToString() :
                String.Empty;

            //Objeto Registro
            this.RegistroSistemaActual.FechaEmision = this.RegistroNuevo.FechaEmision;
            this.RegistroSistemaActual.FechaVencimiento = this.RegistroNuevo.FechaVencimiento;
            this.txtDireccionEmpCalle.Text = this.RegistroNuevo.DireccionCalle;
            this.txtDireccionEmpNumero.Text = this.RegistroNuevo.DireccionNumero;
            
            ddlCiudad.SelectedValue = this.RegistroNuevo.DireccionCiudadId != null ?
                this.RegistroNuevo.DireccionCiudadId.ToString() :
                String.Empty;
            txtCiudad.Text = this.RegistroNuevo.DireccionCiudad;
            
            ddlSector.SelectedValue = this.RegistroNuevo.DireccionSectorId != null ?
                this.RegistroNuevo.DireccionSectorId.ToString() :
                String.Empty;
            
            this.txtApartadoPostal.Text = this.RegistroNuevo.DireccionApartadoPostal;

            if (!String.IsNullOrWhiteSpace(this.RegistroNuevo.DireccionTelefonoOficina))
            {
                var telefono = this.RegistroNuevo.DireccionTelefonoOficina.RemoverFormato();
                this.txtTelefonoPrimario.Text = telefono.Substring(0, 10);

                if (telefono.Length > 10)
                    this.txtTelefonoPrimarioExtension.Text = telefono.Substring(9, telefono.Length - 10);
            }

            if (!String.IsNullOrWhiteSpace(this.RegistroNuevo.DireccionTelefonoCasa))
            {
                var telefono = this.RegistroNuevo.DireccionTelefonoCasa.RemoverFormato();
                this.txtTelefonoSecundario.Text = telefono.Substring(0, 10);

                if (telefono.Length > 10)
                    this.txtTelefonoSecundarioExtension.Text = telefono.Substring(9, telefono.Length - 10);
            }

            this.txtFax.Text = this.RegistroNuevo.DireccionFax.RemoverFormato();
            this.txtEmail.Text = this.RegistroNuevo.DireccionEmail;
            this.txtWebsite.Text = this.RegistroNuevo.DireccionSitioWeb;
            this.txtActividadDescripcion.Text = this.RegistroNuevo.ActividadNegocio;

            //Fechas de emision
            this.RegistroNuevo.FechaVencimiento = this.RegistroSistemaActual.FechaVencimiento != null
                                                ? this.RegistroSistemaActual.FechaVencimiento.Value
                                                : DateTime.Today.AddYears(2);

            //Actividades
            foreach (var ddlItem in this.ActividadesEnRegistro
                .Select(item => cblActividades.Items.FindByValue(item.TipoActividadId.ToString())))
            {
                ddlItem.Selected = true;
            }

            if (this.ProductosEnRegistro.Count > 0)
            {
                var sb = new StringBuilder();
                foreach (var producto in this.ProductosEnRegistro)
                {
                    sb.Append(producto.Descripcion + ",");
                }
                this.hfProductos.Value = sb.ToString().TrimEnd(',');
            }

            HideDropDownLocalidad();
        }

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
