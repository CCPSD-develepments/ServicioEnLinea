using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website.Operaciones.Registro
{
    /// <summary>
    /// Página donde se definen los datos generales de una sociedad/empresa/persona
    /// </summary>
    
    public partial class DatosGenerales : FormularioPage
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.Page_Load(object, EventArgs)'
        {
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

            // Paises
            var colPaises = dbComun.Paises
                .Where(c => c.Nombre.Length > 0)
                .OrderBy(c => c.Nombre).ToList()
                .Select(c => new { c.PaisId, Nombre = info.ToTitleCase(c.Nombre.ToLower()) });
            ddlPais.BindCollection(colPaises, Comun.Paises.PropColumns.PaisId, Comun.Paises.PropColumns.Nombre);

            //Pais default
            if (this.SociedadRegistroNuevo.NacionalidadId.HasValue && this.SociedadRegistroNuevo.NacionalidadId > 0)
            {
                this.ddlPais.Items.FindByValue(this.SociedadRegistroNuevo.NacionalidadId.ToString()).Selected = true;
            }
            else
            {
                var paisDefault = dbComun.Paises.FirstOrDefault(p => p.PaisId == Helper.IdPaisRD);
                if (paisDefault != null)
                {
                    this.ddlPais.Items.FindByValue(paisDefault.PaisId.ToString()).Selected = true;
                    this.hfPaisIdRepDominicana.Value = paisDefault.PaisId.ToString();
                }
            }

            //Tipos de sociedades que permiten establecer la nacionalidad distinta a República Dominicana
            var sbExtranjeras = new StringBuilder();
            Helper.TipoSociedadExtranjera.ForEach(c => sbExtranjeras.AppendFormat("{0},", c));
            this.hfEmpresasExtranjeras.Value = sbExtranjeras.ToString().Trim().TrimEnd(',');

            //Ciudades (siempre en Rep Dominicana)
            var colCiudades = new Comun.CiudadesRepository().FecthInDominicanRepublic(Helper.CiudadesPrincipales, Helper.IdPaisRD);
            colCiudades.ForEach(a => { a.Nombre = info.ToTitleCase(a.Nombre.ToLower()); });
            ddlCiudad.BindCollection(colCiudades, Comun.Ciudades.PropColumns.CiudadId, Comun.Ciudades.PropColumns.Nombre);

            //Sectores por Default
            var ciudadDefaultId = Convert.ToInt32(this.ddlCiudad.SelectedItem.Value);
            var colSectores = new Comun.SectoresRepository().FetchByCiudad(ciudadDefaultId).ToList();
            colSectores.ForEach(a => { a.Nombre = info.ToTitleCase(a.Nombre.ToLower()); });
            ddlSector.BindCollection(colSectores, Comun.Sectores.PropColumns.SectorId, Comun.Sectores.PropColumns.Nombre);

            //Mostrando Dropdown para paises en caso de extranjeras
            var mostrarExtr = Helper.TipoSociedadExtranjera.Contains(this.SociedadRegistroNuevo.TipoSociedadId.Value2());
            this.pnlNacionalidad.Visible = mostrarExtr;
            this.litTipoRegistroHeader.Visible = mostrarExtr;
        }


        /// <summary>
        /// Carga de datos existentes
        /// </summary>
        private void LoadExistingValues()
        {
            //Registro
            if (RegistroNuevo != null && RegistroNuevo.EsNuevoRegistro)
            {
                var dbComun = new Comun.CamaraComunEntities();
                var tipoSociedad =
                    dbComun.TipoSociedad.Where(t => t.TipoSociedadId == this.SociedadRegistroNuevo.TipoSociedadId).FirstOrDefault();
                if (tipoSociedad != null && !String.IsNullOrEmpty(tipoSociedad.Etiqueta))
                {
                    this.lblTipoEmpresaActual.Text = tipoSociedad.Etiqueta;
                    this.lblTipoEmpresaHeader.Text = tipoSociedad.Etiqueta;
                }

                this.lblFechaVencimiento.Text = "A determinar";

                this.lblTipoEmpresaActual.Visible = false;
                this.lblLblTipoEmpresaActual.Visible = false;
                this.lbllblFechaEmision.Visible = false;
                this.lblFechaEmision.Visible = false;
                this.lblFechaVencimiento.Visible = false;
                this.lbllblFechaVencimiento.Visible = false;

                this.lblFechaEmision.Text = Utils.FormatearFecha(DateTime.Now);
                this.lblDenominacionSocialHeader.Text = SociedadRegistroNuevo.NombreSocial;

            }
            else
            {
                //Datos generales de la empresa
                var soc = RegistroSistemaActual.SociedadesRegistros.FirstOrDefault();
                this.lblDenominacionSocialHeader.Text = soc.Sociedades.NombreSocial;
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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.btnDatosGeneralesLlenos_Click(object, EventArgs)'
        protected void btnDatosGeneralesLlenos_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.btnDatosGeneralesLlenos_Click(object, EventArgs)'
        {
            //Datos de la sociedad
            this.SociedadRegistroNuevo.NombreSocial = this.lblDenominacionSocialHeader.Text;

            var nacionalidadId = 0;
            if (Int32.TryParse(this.ddlPais.SelectedItem.Value, out nacionalidadId))
                this.SociedadRegistroNuevo.NacionalidadId = nacionalidadId;

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
            this.RegistroNuevo.DireccionSectorId = ddlSector.SelectedItem != null ? Convert.ToInt32(ddlSector.SelectedItem.Value) : (int?)null;
            this.RegistroNuevo.DireccionApartadoPostal = this.txtApartadoPostal.Text;
            this.RegistroNuevo.DireccionTelefonoCasa = this.txtTelefonoPrimario.Text.RemoverFormato().Trim() + " " +
                                                          this.txtTelefonoPrimarioExtension.Text.RemoverFormato().Trim();
            this.RegistroNuevo.DireccionTelefonoOficina = this.txtTelefonoSecundario.Text.RemoverFormato().Trim() + " " +
                                                       this.txtTelefonoSecundarioExtension.Text.RemoverFormato().Trim();

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
            if (this.hfActividades.Value.Length > 0)
            {
                var lineasAct = this.hfActividades.Value.Split(';');

                foreach (var linea in lineasAct.Where(linea => linea.Trim().Length > 0))
                {
                    var actividad = linea.Split(',');
                    this.ActividadesEnRegistro.Add(new OFV.RegistrosActividades
                    {
                        TipoActividadId = Convert.ToInt32(actividad[0]),
                        FechaModificacion = DateTime.Now
                    });
                }

                //foreach (var actividad in this.ActividadesEnRegistro)
                //{
                //    var dbComun = new Comun.CamaraComunEntities();

                //    var query = (from comun in dbComun.ActividadesCIIU
                //                where comun.ActividadID.Equals(actividad.TipoActividadId)
                //                select comun).First();

                //    actividad.CodigoCIIU = query.CodigoCIIU;
                //}

            }

            //Productos y servicios
            this.ProductosEnRegistro = new List<OFV.Productos>();
            if (this.hfProductos.Value.Length > 0)
            {
                var productos = this.hfProductos.Value.Split(',');
                foreach (var producto in productos)
                {
                    var strProducto = producto.Trim().ToLower().Replace(";","");
                    if (strProducto == "null" || strProducto == "undefined") continue;
                   
                    this.ProductosEnRegistro
                        .Add(new OFV.Productos { Descripcion = producto });
                }
            }

            Response.Redirect("DatosSociedad.aspx" + DefaultQueryString);
        }

        // 03 - Llenado de interfaz para modificación
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.LoadFormData()'
        protected void LoadFormData()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.LoadFormData()'
        {
            this.lblDenominacionSocialHeader.Text = this.SociedadRegistroNuevo.NombreSocial;

            //Objeto Registro
            this.RegistroSistemaActual.FechaEmision = this.RegistroNuevo.FechaEmision;
            this.RegistroSistemaActual.FechaVencimiento = this.RegistroNuevo.FechaVencimiento;
            this.txtDireccionEmpCalle.Text = this.RegistroNuevo.DireccionCalle;
            this.txtDireccionEmpNumero.Text = this.RegistroNuevo.DireccionNumero;
            
            ddlCiudad.SelectedValue = this.RegistroNuevo.DireccionCiudadId != null ?
                this.RegistroNuevo.DireccionCiudadId.ToString() :
                String.Empty;
            
            ddlSector.SelectedValue = this.RegistroNuevo.DireccionSectorId != null ?
                this.RegistroNuevo.DireccionSectorId.ToString() :
                String.Empty;
            
            this.txtApartadoPostal.Text = this.RegistroNuevo.DireccionApartadoPostal;

            if (!String.IsNullOrWhiteSpace(this.RegistroNuevo.DireccionTelefonoCasa))
            {
                var telefono = this.RegistroNuevo.DireccionTelefonoCasa.RemoverFormato();
                this.txtTelefonoPrimario.Text = telefono.Substring(0, 10);

                if (telefono.Length > 10)
                    this.txtTelefonoPrimarioExtension.Text = telefono.Substring(10, telefono.Length - 10);
            }

            if (!String.IsNullOrWhiteSpace(this.RegistroNuevo.DireccionTelefonoOficina))
            {
                var telefono = this.RegistroNuevo.DireccionTelefonoOficina.RemoverFormato();
                this.txtTelefonoSecundario.Text = telefono.Substring(0, 10);

                if (telefono.Length > 10)
                    this.txtTelefonoSecundarioExtension.Text = telefono.Substring(10, telefono.Length - 10);
            }

            this.txtFax.Text = this.RegistroNuevo.DireccionFax.RemoverFormato();
            this.txtEmail.Text = this.RegistroNuevo.DireccionEmail;
            this.txtWebsite.Text = this.RegistroNuevo.DireccionSitioWeb;
            this.txtActividadDescripcion.Text = this.RegistroNuevo.ActividadNegocio;

            //Fechas de emision
            this.RegistroNuevo.FechaVencimiento = this.RegistroSistemaActual.FechaVencimiento != null
                                                ? this.RegistroSistemaActual.FechaVencimiento.Value
                                                : DateTime.Today.AddYears(2);

            //Productos en Registro
            if (this.ProductosEnRegistro.Count > 0)
            {
                var sb = new StringBuilder();
                foreach (var producto in this.ProductosEnRegistro)
                {
                    if (!String.IsNullOrEmpty(producto.Descripcion))
                    sb.Append(producto.Descripcion + ",");
                }
                this.hfProductos.Value = sb.ToString().TrimEnd(',');
            }

            //Actividades
            if (this.ActividadesEnRegistro.Count > 0)
            {
                var dbComun = new Comun.CamaraComunEntities();
                var actividadesList = this.ActividadesEnRegistro.Where(a => a.TipoActividadId > 0).Select(a => a.TipoActividadId).Distinct();
                var actividadesEnDb = dbComun.Actividades.Where(a => actividadesList.Contains(a.ActividadID));

                var sb = new StringBuilder();
                foreach (var actividad in actividadesEnDb)
                {
                    if (actividad != null && actividad.ActividadID > 0)
                    {
                        sb.Append(String.Format("{0},{1};", actividad.ActividadID, actividad.DescripconLarga));
                    }
                }
                this.hfActividades.Value = sb.ToString().TrimEnd(',');
            }

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.customvalTxtPrincipalesProductos_ServerValidate(object, ServerValidateEventArgs)'
        protected void customvalTxtPrincipalesProductos_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.customvalTxtPrincipalesProductos_ServerValidate(object, ServerValidateEventArgs)'
        {

        }

    }
}
