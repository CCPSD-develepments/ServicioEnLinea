using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF.SRM;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website.Operaciones.Modificaciones
{
    ///<summary>
    /// Pantalla de modificaciones - datos generales
    ///</summary>
    public partial class DatosGenerales : ModificacionPage
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;

            //Carga inicial de datos
            LoadData();

            //Si es la primera vez que se llama este formulario, se cargan valores existentes
            if (!IsFormularionConfirmacion)
                InitializeSessionData();

            LoadExistingValues();

            if (IsFormularionConfirmacion)
                LoadFormData();

            //Cerrando controles si se trata de una modificación
            var tipoServicios = new Comun.CamaraComunEntities().Servicio
                .Where(s => this.ServiciosSeleccionadosPorUrl.Contains(s.ServicioId))
                .Select(s => s.TipoServicioId).Distinct().ToList();

            var autorizados = new OFV.PropiedadesModUIRepository()
                .GetControlesByServicioIDs(this.ServiciosSeleccionadosPorUrl);
            HabilitarControlesMod(this.Form, ref autorizados);

            this.ViewState["ciudadOriginalId"] = this.ddlCiudad.SelectedItem.Value;
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


            //Ciudades
            var paisDefaultId = Convert.ToInt32(this.ddlPais.SelectedItem.Value);

            var colCiudades = new Comun.CiudadesRepository().FecthInDominicanRepublic(Helper.CiudadesPrincipales, Helper.IdPaisRD);
            colCiudades.ForEach(a => { a.Nombre = info.ToTitleCase(a.Nombre.ToLower()); });
            ddlCiudad.BindCollection(colCiudades, Comun.Ciudades.PropColumns.CiudadId, Comun.Ciudades.PropColumns.Nombre);


            //Sectores por Default
            var ciudadDefaultId = Convert.ToInt32(this.ddlCiudad.SelectedItem.Value);
            var colSectores = new Comun.SectoresRepository().FetchByCiudad(ciudadDefaultId).ToList();
            colSectores.ForEach(a => { a.Nombre = info.ToTitleCase(a.Nombre.ToLower()); });
            ddlSector.BindCollection(colSectores, Comun.Sectores.PropColumns.SectorId, Comun.Sectores.PropColumns.Nombre);

        }


        /// <summary>
        /// Carga de datos existentes
        /// </summary>
        private void LoadExistingValues()
        {
            var dbEntities = new Comun.CamaraComunEntities();

            var colEmpresas = dbEntities.TipoSociedad.Where(ts => ts.SiteVisible == true).ToList();
            this.ddAdecuacion.BindCollection(colEmpresas, Comun.TipoSociedad.PropColumns.TipoSociedadId, Comun.TipoSociedad.PropColumns.Descripcion);

            if (RegistroNuevo != null && RegistroNuevo.EsNuevoRegistro)
            {
                this.lblFechaVencimiento.Text = "A determinar";
                this.lblFechaEmision.Text = Utils.FormatearFecha(DateTime.Now, false);

            }
            else
            {
                //Datos generales de la empresa
                var soc = RegistroSistemaActual.SociedadesRegistros.FirstOrDefault();
                this.litNombreEmpresaTit.Text = soc.Sociedades.NombreSocial;

                var tipoEmpresa = dbEntities.TipoSociedad
                    .Where(d => d.TipoSociedadId == soc.Sociedades.TipoSociedadId)
                    .FirstOrDefault();

                this.litTimpoEmpresaTit.Text = tipoEmpresa != null ? tipoEmpresa.Etiqueta : String.Empty;

                this.lblFechaEmision.Text = RegistroSistemaActual.FechaEmision != null
                                                ? Utils.FormatearFecha(RegistroSistemaActual.FechaEmision.Value)
                                                : "No disponible";
                this.lblFechaVencimiento.Text = RegistroSistemaActual.FechaVencimiento != null
                                                ? Utils.FormatearFecha(RegistroSistemaActual.FechaVencimiento.Value)
                                                : "No disponible";


                //Validacion de la renovacion
                if (ValidarRenovacionNecesaria())
                {
                    this.pnlRenovacionVencida.Visible = true;
                }
            }
        }

        // 02 - Llenado de los datos de la empresa
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.btnDatosGeneralesLlenos_Click(object, EventArgs)'
        protected void btnDatosGeneralesLlenos_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.btnDatosGeneralesLlenos_Click(object, EventArgs)'
        {
            if (!EsValido()) return;

            //Variable que indica si la empresa a constituir es extranjera
            var esExtranjera = Helper.TipoSociedadExtranjera.Contains(Int32.Parse(ddAdecuacion.SelectedValue));

            //Asignacion de valores al objeto sociedad            
            this.SociedadRegistroNuevo.TipoSociedadId = TipoSociedadId;
            this.SociedadRegistroNuevo.NombreSocial = this.txtDenominacionSocial.Text;
            var nacionalidadId = 0;
            if (Int32.TryParse(this.ddlPais.SelectedItem.Value, out nacionalidadId))
                this.SociedadRegistroNuevo.NacionalidadId = nacionalidadId;
            this.SociedadRegistroNuevo.EsNacional = esExtranjera;

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

            if (ddlSector.SelectedItem != null)
                this.RegistroNuevo.DireccionSectorId = Convert.ToInt32(ddlSector.SelectedItem.Value);
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
                //                 where comun.ActividadID.Equals(actividad.TipoActividadId)
                //                 select comun).First();

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
                    var strProducto = producto.Trim().ToLower().Replace(";", "");
                    if (strProducto == "null" || strProducto == "undefined") continue;

                    this.ProductosEnRegistro
                        .Add(new OFV.Productos { Descripcion = producto });
                }
            }

            Response.Redirect("DatosSociedad.aspx" + DefaultQueryString);
        }

        /// <summary>
        /// Validaciones adicionales del formulario
        /// </summary>
        /// <returns></returns>
        private bool EsValido()
        {
            //Variables
            var esValido = true;

            //Comprobación de domicilio
            if (this.ddlCiudad.Enabled)
            {
                var ciudadId = this.ddlCiudad.SelectedItem.Value;
                var ciudadOriginalId = Convert.ToString(this.ViewState["ciudadOriginalId"]);
                if (ciudadId == ciudadOriginalId)
                {
                    esValido = false;
                    this.GenerateCustomError("Debe escoger una ciudad distinta a la ciudad actual", "2");
                }
            }

            //Comprobacion de actividades
            var listaActs = new List<OFV.RegistrosActividades>();
            if (this.hfActividades.Value.Length == 0)
            {
                esValido = false;
                this.GenerateCustomError("Debe seleccionar por lo menos una actividad", "2");
            }
            else
            {
                var lineasAct = this.hfActividades.Value.Split(';');
                listaActs.AddRange(lineasAct.Where(linea => linea.Trim().Length > 0)
                    .Select(linea => linea.Split(',')).Select(actividad => new OFV.RegistrosActividades
                    {
                        TipoActividadId = Convert.ToInt32(actividad[0]),
                        FechaModificacion = DateTime.Now
                    }));

                if (listaActs.Count() == 0)
                {
                    esValido = false;
                    this.GenerateCustomError("Debe seleccionar por lo menos una actividad", "2");
                }
            }

            return esValido;
        }

        // 03 - Llenado de interfaz para modificación
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.LoadFormData()'
        protected void LoadFormData()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.LoadFormData()'
        {

            //Asignacion de valores al objeto sociedad
            this.ddAdecuacion.SelectedValue = this.SociedadRegistroNuevo.TipoSociedadId != null ?
                this.SociedadRegistroNuevo.TipoSociedadId.ToString() :
                String.Empty;

            if (this.SociedadRegistroNuevo.TipoSociedadId != this.TipoSociedadId
                && this.TipoSociedadId > 0)
            {
                var dbComun = new Comun.CamaraComunEntities();
                var tipoSoc = dbComun.TipoSociedad.FirstOrDefault(c => c.TipoSociedadId == this.TipoSociedadId);
                if (tipoSoc != null)
                    this.lblNuevoTipoSociedad.Text = "Transformación a " + tipoSoc.Descripcion;
            }


            this.litNombreEmpresaTit.Text = this.SociedadRegistroNuevo.NombreSocial;
            this.txtDenominacionSocial.Text = this.SociedadRegistroNuevo.NombreSocial;

            this.ddAdecuacion.SelectedValue = this.SociedadRegistroNuevo.TipoSociedadId.HasValue ?
                this.SociedadRegistroNuevo.TipoSociedadId.ToString() :
                String.Empty;

            this.RegistroSistemaActual.FechaEmision = this.RegistroNuevo.FechaEmision;
            this.RegistroSistemaActual.FechaVencimiento = this.RegistroNuevo.FechaVencimiento;
            this.txtDireccionEmpCalle.Text = this.RegistroNuevo.DireccionCalle;
            this.txtDireccionEmpNumero.Text = this.RegistroNuevo.DireccionNumero;

            ddlCiudad.SelectedValue = this.RegistroNuevo.DireccionCiudadId != null ?
                                      this.RegistroNuevo.DireccionCiudadId.ToString() :
                                      String.Empty;

            int selectedCiudadIdd;
            if (int.TryParse(ddlCiudad.SelectedValue, out selectedCiudadIdd))
            {
                var colSectores = new Comun.SectoresRepository().FetchByCiudad(selectedCiudadIdd).ToList();
                colSectores.ForEach(a => { a.Nombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(a.Nombre.ToLower()); });
                ddlSector.BindCollection(colSectores, Comun.Sectores.PropColumns.SectorId,
                                         Comun.Sectores.PropColumns.Nombre);

                if (this.RegistroNuevo.DireccionSectorId != null && this.RegistroNuevo.DireccionSectorId > 0)
                {
                    var item = ddlSector.Items.FindByValue(this.RegistroNuevo.DireccionSectorId.ToString());
                    if (item != null)
                    {
                        ddlSector.SelectedItem.Selected = false;
                        item.Selected = true;
                    }
                }
            }

            this.txtApartadoPostal.Text = this.RegistroNuevo.DireccionApartadoPostal;

            if (!String.IsNullOrWhiteSpace(this.RegistroNuevo.DireccionTelefonoOficina))
            {
                var telefono = this.RegistroNuevo.DireccionTelefonoOficina.RemoverFormato();

                if (telefono.Length > 10)
                {
                    this.txtTelefonoSecundario.Text = telefono.Substring(0, 10);
                    this.txtTelefonoSecundarioExtension.Text = telefono.Substring(9, telefono.Length - 10);
                }
                else
                {
                    this.txtTelefonoSecundario.Text = telefono;
                }
            }

            if (!String.IsNullOrWhiteSpace(this.RegistroNuevo.DireccionTelefonoCasa))
            {
                var telefono = this.RegistroNuevo.DireccionTelefonoCasa.RemoverFormato();

                if (telefono.Length > 10)
                {
                    this.txtTelefonoPrimario.Text = telefono.Substring(0, 10);
                    this.txtTelefonoPrimarioExtension.Text = telefono.Substring(9, telefono.Length - 10);
                }
                else
                {
                    this.txtTelefonoPrimario.Text = telefono;
                }
            }

            this.txtFax.Text = this.RegistroNuevo.DireccionFax.RemoverFormato();
            this.txtEmail.Text = this.RegistroNuevo.DireccionEmail.Length > 0
                                ? this.RegistroNuevo.DireccionEmail
                                : String.Empty;
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
                if (!string.IsNullOrEmpty(this.ActividadesEnRegistro.First().CodigoCIIU))
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
                else
                    this.ActividadesEnRegistro = new List<OFV.RegistrosActividades>();
            }

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.ddlCiudad_SelectedIndexChanged(object, EventArgs)'
        protected void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DatosGenerales.ddlCiudad_SelectedIndexChanged(object, EventArgs)'
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

    }
}