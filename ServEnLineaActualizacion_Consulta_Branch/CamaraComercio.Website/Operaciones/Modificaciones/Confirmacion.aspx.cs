using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using Telerik.Web.UI;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using TipoSocio = CamaraComercio.DataAccess.EF.CamaraComun.TipoSocio;
namespace CamaraComercio.Website.Operaciones.Modificaciones
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Confirmacion'
    public partial class Confirmacion : ModificacionPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Confirmacion'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Confirmacion.SectoresList'
        public List<Comun.Sectores> SectoresList;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Confirmacion.SectoresList'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Confirmacion.CiudadesList'
        public List<Comun.Ciudades> CiudadesList;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Confirmacion.CiudadesList'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Confirmacion.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Confirmacion.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;

            LoadData();
            RenderizarControles(this.Controls);
            HideElements();

        }

        /// <summary>
        /// Se esconden los elementos que están vacios para los nuevos registros
        /// </summary>
        private void HideElements()
        {
            if (!this.RegistroNuevo.RegistroMercantil.HasValue || this.RegistroNuevo.RegistroMercantil.Value == 0)
                this.litNoRegistro.Text = "-";

            if (String.IsNullOrEmpty(this.SociedadRegistroNuevo.Rnc))
                this.litRnc.Text = "-";

            if (!this.lblCapitalSuscritoTitle.Visible || this.lblCapitalSuscritoTitle.Text.Length == 0)
            {
                this.litCapitalSuscrito.Text = "";
            }
        }

        /// <summary>
        /// Carga de datos desde los objetos que están en sesión
        /// </summary>
        private void LoadData()
        {
            //Acceso a DAL datos comunes
            var dbWebSite = new CamaraWebsiteEntities();
            var dbComun = new Comun.CamaraComunEntities();

            //Objetos de Registro y Sociedad originales (para comparación)
            var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);
            var socOrg = dbSrm.Sociedades.Where(s => s.SociedadId == this.SociedadId).FirstOrDefault();
            var regOrg = socOrg.SociedadesRegistros.FirstOrDefault().Registros;

            //HEADER
            this.lblNombreEmpresa.Text = this.SociedadRegistroNuevo.NombreSocial;
            this.lblTipoEmpresa.Text = dbComun.TipoSociedad.FirstOrDefault(c => c.TipoSociedadId == this.TipoSociedadId).Etiqueta;

            //DATOS GENERALES
            litNoRegistro.ToSpan(this.RegistroNuevo.RegistroMercantil);
            litRnc.ToSpan(this.SociedadRegistroNuevo.Rnc.FormatRnc(), this.SociedadRegistroNuevo.Rnc.FormatRnc() == socOrg.Rnc.FormatRnc());
            litRazonSocial.ToSpan(this.SociedadRegistroNuevo.NombreSocial, this.SociedadRegistroNuevo.NombreSocial == socOrg.NombreSocial);

            //Nacionalidad
            var nacionalidad = dbComun.Paises.Where(p => p.PaisId == this.SociedadRegistroNuevo.NacionalidadId).FirstOrDefault();
            litNacionalidad.ToSpan(nacionalidad != null ? nacionalidad.Nombre : "Rep. Dominicana");

            var tipoSociedad = dbComun.TipoSociedad.FirstOrDefault(a => a.TipoSociedadId == this.SociedadRegistroNuevo.TipoSociedadId);
            if (tipoSociedad != null)
                litTipoEmpresa.ToSpan(tipoSociedad.Descripcion, this.SociedadRegistroNuevo.TipoSociedadId == socOrg.TipoSociedadId);
            else
                litTipoEmpresa.ToSpan(String.Empty);

            litTelefonoPrimario.ToSpan(this.RegistroNuevo.DireccionTelefonoCasa.FormatTelefono(),
                this.RegistroNuevo.DireccionTelefonoCasa.RemoverFormato() == regOrg.Direcciones.TelefonoCasa.RemoverFormato());

            litTelefonoSecundario.ToSpan(this.RegistroNuevo.DireccionTelefonoOficina.FormatTelefono(),
                this.RegistroNuevo.DireccionTelefonoOficina.RemoverFormato() == regOrg.Direcciones.TelefonoOficina.RemoverFormato());

            litFax.ToSpan(this.RegistroNuevo.DireccionFax.FormatTelefono(),
                this.RegistroNuevo.DireccionFax.RemoverFormato() == regOrg.Direcciones.Fax.RemoverFormato());

            litEmail.ToSpan(this.RegistroNuevo.DireccionEmail,
                this.RegistroNuevo.DireccionEmail == regOrg.Direcciones.Email);

            litWebsite.ToSpan(this.RegistroNuevo.DireccionSitioWeb,
                this.RegistroNuevo.DireccionSitioWeb == regOrg.Direcciones.SitioWeb);

            litDescripcionNegocio.ToSpan(this.RegistroNuevo.ActividadNegocio,
                this.RegistroNuevo.ActividadNegocio == regOrg.ActividadNegocio);

            //Productos
            var sbProductos = new StringBuilder();
            var prodsOrg = regOrg.Productos.ToList();
            foreach (var producto in this.ProductosEnRegistro)
            {
                if (producto == null) continue;

                var descripcion = producto.Descripcion.Replace(";null", "").Replace("null", "")
                                                            .Replace(";undefined", "").Replace("undefined", "")
                                                            .Replace(";","").Trim();

                if (!String.IsNullOrEmpty(descripcion))
                {
                    var prodCheck = prodsOrg.Where(p => p.Descripcion.Replace(";null", "").Replace("null", "")
                                                            .Replace(";undefined", "").Replace("undefined", "")
                                                            .Replace(";", "").Trim() == descripcion);
                    if (prodCheck.Count() == 0)
                        sbProductos.AppendFormat("<span class='modified'>{0}</span><br/>", descripcion);
                    else
                        sbProductos.Append(descripcion + "<br/>");
                }
            }
            litPrincipalesProductos.ToSpan(sbProductos.ToString());

            //Actividades
            var sbActividades = new StringBuilder();
            var actividadesList = dbComun.Actividades;
            var activOrg = regOrg.RegistrosActividades.ToList();
            foreach (var actividad in this.ActividadesEnRegistro.Distinct())
            {
                var actItem = actividad;
                if (actividad.TipoActividadId == 0)
                    continue;

                var activOrgCheck = activOrg.Where(a => a.TipoActividadId == actividad.TipoActividadId);
                var nombreActividad = actividadesList
                                        .Where(a => a.ActividadID == actItem.TipoActividadId)
                                        .FirstOrDefault().Descripcion;

                if (activOrgCheck.Count() == 0)
                    sbActividades.AppendFormat("<span class='modified'>{0}</span><br/>", nombreActividad);
                else
                    sbActividades.AppendLine(nombreActividad+ "<br/>");
            }
            litActividades.ToSpan(sbActividades.ToString());
            
            //Direccion
            litDireccion.ToSpan(Utils.ConstruirDireccion(this.RegistroNuevo, regOrg));

            //DATOS DE LA SOCIEDAD
            if (this.SociedadRegistroNuevo.TieneCapitalSocial)
            {
                var capSocialStr = this.RegistroNuevo.CapitalSocial > 0
                                    ? "RD$" + this.RegistroNuevo.CapitalSocial.Value2().ToString("n")
                                    : String.Empty;
                var capSocialIgual = this.RegistroNuevo.CapitalSocial.Value2() == regOrg.CapitalSocial.Value2() ||
                                      this.RegistroNuevo.CapitalSocial.Value2() == regOrg.CapitalAutorizado.Value2() ;
                litCapitalSocial.ToSpan(capSocialStr, capSocialIgual);
            }
            else
            {
                litCapitalSocial.ToSpan("SIN CAPITAL SOCIAL");
            }


            
            var capSuscritoStr = this.RegistroNuevo.CapitalPagado > 0
                                        ? "RD$" + this.RegistroNuevo.CapitalPagado.Value2().ToString("n")
                                        : String.Empty;
            litCapitalSuscrito.ToSpan(capSuscritoStr,
                                        this.RegistroNuevo.CapitalPagado.Value2() == regOrg.CapitalPagado.Value2());
            

            var bienesRaicesStr = "RD$" + this.RegistroNuevo.BienesRaices.Value2().ToString("n");
            litBienesRaices.ToSpan(bienesRaicesStr, this.RegistroNuevo.BienesRaices.Value2() == regOrg.BienesRaices.Value2());

            var activosStr = "RD$" + this.RegistroNuevo.Activos.Value2().ToString("n");
            litActivos.ToSpan(activosStr, this.RegistroNuevo.Activos.Value2() == regOrg.Activos.Value2());

            //Revisión de fechas para evitar error de MinDate
            if (this.RegistroNuevo.FechaInicioOperacion.HasValue && this.RegistroNuevo.FechaInicioOperacion != DateTime.MinValue)
                litFechaInicio.ToSpan(Utils.FormatearFecha(this.RegistroNuevo.FechaInicioOperacion.Value2()));

            if (this.SociedadRegistroNuevo.FechaAsamblea.HasValue && this.SociedadRegistroNuevo.FechaAsamblea != DateTime.MinValue)
                litFechaAsamblea.ToSpan(Utils.FormatearFecha(this.SociedadRegistroNuevo.FechaAsamblea.Value2()));

            //Referencias Bancarias
            var sbRefBancarias = new StringBuilder();
            var refBancariasOrg = regOrg.ReferenciasBancarias.ToList();
            foreach (var refbancaria in this.ReferenciasBancariasRegistro)
            {
                var refBancariaCheck = refBancariasOrg.Where(r => r.BancoId == refbancaria.BancoId);
                if (refBancariaCheck.Count() == 0)
                    sbRefBancarias.AppendFormat("<span class='modified'>{0}</span><br/>", refbancaria.NombreBanco);
                else
                    sbRefBancarias.Append(refbancaria.NombreBanco + "<br/>");
            }
            litReferenciasBancarias.ToSpan(sbRefBancarias.ToString());

            //Referencias Comerciales
            var sbRefComerciales = new StringBuilder();
            var refComercialesOrg = regOrg.ReferenciasComerciales.ToList();
            foreach (var refComercial in this.ReferenciasComercialesRegistro)
            {
                var refComercialCheck = refComercialesOrg
                    .Where(r => r.Descripcion.Trim().Replace(",","") == refComercial.Descripcion.Trim().Replace(",",""));
                if (refComercialCheck.Count() == 0)
                    sbRefComerciales.AppendFormat("<span class='modified'>{0}</span><br/>", refComercial.Descripcion);
                else
                    sbRefComerciales.Append(refComercial.Descripcion + "<br/>");
            }
            litReferenciasComerciales.ToSpan(sbRefComerciales.ToString());

            //Otros
            int duracionSociedad;
            Int32.TryParse(this.SociedadRegistroNuevo.DuracionSociedad, out duracionSociedad);
            var duracionSociedadStr = duracionSociedad > 0 ? this.SociedadRegistroNuevo.DuracionSociedad : "INDEFINIDA";
            
            var comparacionDuracion = this.SociedadRegistroNuevo.DuracionSociedad == socOrg.DuracionSociedad;
            if (duracionSociedadStr == "INDEFINIDA" && socOrg.DuracionSociedad.Contains("INDEFINIDA"))
                comparacionDuracion = true;
            litDuracionSociedad.ToSpan(duracionSociedadStr, comparacionDuracion);

            if (this.SociedadRegistroNuevo.DuraccionDirectiva.HasValue && this.SociedadRegistroNuevo.DuraccionDirectiva > 0)
                litDuracionConsejo.ToSpan(this.SociedadRegistroNuevo.DuraccionDirectiva, 
                    this.SociedadRegistroNuevo.DuraccionDirectiva == socOrg.DuraccionDirectiva);
            else
            {
                this.SociedadRegistroNuevo.DuraccionDirectiva = 0;
                litDuracionConsejo.Text = "-";
            }

            //Entes Regulados
            var sbEnteRegulado = new StringBuilder();
            if (this.SociedadRegistroNuevo.EsEnteRegulado && this.SociedadRegistroNuevo.TipoEnteReguladoId > 0)
            {
                var descEnteRegulado = dbComun.TiposEnteRegulado.Where(
                                        t => t.TipoEnteReguladoId == this.SociedadRegistroNuevo.TipoEnteReguladoId)
                                        .FirstOrDefault();
                sbEnteRegulado.Append(String.Format("{0} - {1}", 
                    this.SociedadRegistroNuevo.NoResolucion, descEnteRegulado.Descripcion));
            }
            else
            {
                sbEnteRegulado.Append("Ente no regulado");
            }
            litregulacion.ToSpan(sbEnteRegulado.ToString(), 
                this.SociedadRegistroNuevo.TipoEnteReguladoId.GetValueOrDefault() == socOrg.TipoEnteReguladoId.GetValueOrDefault());

            //Empleados
            var sbEmpleados = new StringBuilder();
            sbEmpleados.AppendFormat(
                this.RegistroNuevo.EmpleadosMasculinos != regOrg.EmpleadosMasculinos
                    ? "<span class='modified'>M: {0} </span> /"
                    : "M: {0} / ", this.RegistroNuevo.EmpleadosMasculinos);
            sbEmpleados.AppendFormat(
                this.RegistroNuevo.EmpleadosFemeninos != regOrg.EmpleadosFemeninos
                    ? "<span class='modified'>F: {0}</span>"
                    : "F: {0}", this.RegistroNuevo.EmpleadosFemeninos);
            litEmpleados.ToSpan(sbEmpleados.ToString());

            //Sucursales
            var sbSucursales = new StringBuilder();
            var sucursalesOrg = socOrg.Suscursales.ToList();
            foreach (var sucursal in this.SucursalesRegistro)
            {
                var check = sucursalesOrg.Where(s => s.Descripcion == sucursal.Descripcion);
                if (check.Count() == 0)
                    sbSucursales.AppendFormat("<span class='modified'>{0}</span><br/>", sucursal.Descripcion);
                else
                    sbSucursales.Append(sucursal.Descripcion + "<br/>");
            }
            litSucursales.ToSpan(sbSucursales.ToString());
            
            litNombreComercial.ToSpan(this.RegistroNuevo.NombreComercial, this.RegistroNuevo.NombreComercial == regOrg.NombreComercial);
            litRegistroOnapi.ToSpan(this.RegistroNuevo.RegistroNombreComercial, this.RegistroNuevo.RegistroNombreComercial == regOrg.RegistroNombreComercial);

            //Socios
            var socioList = this.SociosEnRegistro.Select(
                s => new SociosDTO()
                         {
                             ID = s.Id,
                             TipoSocio = s.TipoSocio,
                             TipoRelacion = s.TipoRelacion,
                             CargoId = s.CargoId,
                             TipoDocumento = s.TipoDocumento,
                             Documento = s.Documento,
                             SociedadNombreSocial = s.SociedadNombreSocial,
                             PersonaPrimerNombre = s.PersonaPrimerNombre,
                             PersonaSegundoNombre = s.PersonaSegundoNombre,
                             PersonaPrimerApellido = s.PersonaPrimerApellido,
                             PersonaSegundoApellido = s.PersonaSegundoApellido,
                             CantidadAcciones = s.CantidadAcciones,
                             Representante = ObtenerDatosRepresentante(s.RepresentanteId),
                             Direccion = FormatearDireccion(s.DireccionCalle, s.DireccionNumero, s.DireccionCiudadId, s.DireccionSectorId),
                             Modificado = s.Modificado
                         }
                );

            //Listado de IDs unicos
            var socioListGrid = new List<SociosGridDTO>();
            var ids = socioList.Select(c => c.ID).Distinct();
            var cargosList = dbComun.Cargos.ToList();
            var tipoSocios = dbComun.TipoSociedadSocio
                            .Where(ts => ts.TipoSociedadId == this.TipoSociedadId).ToList();
            foreach (var id in ids)
            {
                var socioenGrid = new SociosGridDTO();
                var socio = socioList.Where(s => s.ID == id);

                socioenGrid.Nombre = FormatearNombreSocio(socio.First());
                socioenGrid.Documento = socio.First().Representante == null ? socio.First().Documento : socio.First().Representante.Documento;

                var accionista = socio.Where(s => s.TipoRelacion == "A").FirstOrDefault();
                if (accionista != null)
                    socioenGrid.Cuotas = accionista.CantidadAcciones;

                socioenGrid.Direccion = socioenGrid.Nombre.Trim() != "AL PORTADOR"
                                            ? socio.FirstOrDefault().Direccion
                                            : String.Empty;
                socioenGrid.Cargos = FormatearCargosSocio(socio, tipoSocios, cargosList);
                socioenGrid.Modificado = socio.Where(s => s.Modificado).Count() > 0;

                socioListGrid.Add(socioenGrid);
            }

            //this.gvSocios.DataSource = sociosFormatted;
            this.gvSociosT.DataSource = socioListGrid;
            this.gvSociosT.DataBind();

            //Listado de servicios
            var listaServicios = new List<String>();
            var trans = this.TransaccionesEnRegistro;
            listaServicios.Add(trans.NombreServicio);
            listaServicios.AddRange(from subTrans in trans.SubTransacciones
                                    where !string.IsNullOrEmpty(subTrans.NombreServicio)
                                    select subTrans.NombreServicio);

            var sb = new StringBuilder();
            sb.Append("<ul>");
            foreach (var serv in listaServicios)
            {
                sb.AppendFormat("<li>{0}</li>", serv);
            }
            sb.Append("</ul>");
            this.litListadoServicios.Text = sb.ToString();
        }

#pragma warning disable CS1573 // Parameter 'sectorId' has no matching param tag in the XML comment for 'Confirmacion.FormatearDireccion(string, string, int?, int?)' (but other parameters do)
        /// <summary>
        /// Formatea la dirección de un socio
        /// </summary>
        /// <param name="calle"></param>
        /// <param name="numero"></param>
        /// <param name="ciudadId"></param>
        /// <returns></returns>
        private string FormatearDireccion(string calle, string numero, int? ciudadId, int? sectorId)
#pragma warning restore CS1573 // Parameter 'sectorId' has no matching param tag in the XML comment for 'Confirmacion.FormatearDireccion(string, string, int?, int?)' (but other parameters do)
        {
            Comun.CamaraComunEntities dbComun = null;
            if (this.SectoresList == null || this.SectoresList.Count == 0)
            {
                dbComun = new CamaraComunEntities();
                this.SectoresList = dbComun.Sectores.ToList();
            }
            if (this.CiudadesList == null || this.CiudadesList.Count == 0)
            {
                if (dbComun == null)
                    dbComun = new CamaraComunEntities();

                this.CiudadesList = dbComun.Ciudades.ToList();
            }

            var sb = new StringBuilder();
            if (calle.Length > 0)
            {
                sb.Append(calle);
                if (numero.Length > 0)
                    sb.Append(" " + numero + ". ");
            }

            if (sectorId.HasValue && sectorId > 0)
            {
                var sector = this.SectoresList.Where(s => s.SectorId == sectorId).FirstOrDefault();
                if (sector != null && !String.IsNullOrEmpty(sector.Nombre))
                    sb.Append(sector.Nombre + ", ");
            }

            if (ciudadId.HasValue && ciudadId > 0)
            {
                var ciudad = this.CiudadesList.Where(c => c.CiudadId == ciudadId).FirstOrDefault();
                if (ciudad != null && !string.IsNullOrEmpty(ciudad.Nombre))
                    sb.Append(ciudad.Nombre);
            }

            return sb.ToString();
        }

        #region Despliegue de Socios
        private static string FormatearCargosSocio(IEnumerable<SociosDTO> socioList,
            IEnumerable<Comun.TipoSociedadSocio> tipoSociosList,
            IEnumerable<Comun.Cargos> tipoCargoList)
        {
            var sb = new StringBuilder();
            foreach (var socio in socioList)
            {
                var tipoSocio = tipoSociosList.Where(ts => ts.TipoSocioId == socio.TipoRelacion).FirstOrDefault();
                var tipoCargo = tipoCargoList.Where(tc => tc.CargoId == socio.CargoId).FirstOrDefault();

                if (tipoSocio == null) continue;

                var cargo = tipoCargo != null ? tipoCargo.Descripcion : String.Empty;

                if (tipoSocio.TipoSocioId == "C")
                    sb.AppendFormat("{0} - {1}, ", tipoSocio.Descripcion, cargo);
                else
                    sb.Append(tipoSocio.Descripcion + ", ");
            }
            return sb.ToString().Trim().TrimEnd(',');
        }

        /// <summary>
        /// Formatea el nombre del socio
        /// </summary>
        /// <param name="socio"></param>
        /// <returns></returns>
        private static string FormatearNombreSocio(SociosDTO socio)
        {
            var sb = new StringBuilder();
            if (socio.Representante != null)
            {
                //Empresas y menores de edad
                if (socio.TipoSocio == "S")
                    sb.AppendFormat("{0} ", socio.PersonaPrimerNombre.Trim());
                else
                    sb.AppendFormat("{0} {1} ", socio.PersonaPrimerNombre.Trim(), socio.PersonaPrimerApellido.Trim());

                sb.AppendFormat("(Representado por {0} {1}", socio.Representante.PersonaPrimerNombre,
                                socio.Representante.PersonaPrimerApellido);
            }
            else
            {
                //Personas físicas
                sb.Append(socio.PersonaPrimerNombre + " ");

                if (!String.IsNullOrEmpty(socio.PersonaSegundoNombre))
                    sb.Append(socio.PersonaSegundoNombre + " ");

                sb.Append(socio.PersonaPrimerApellido + " ");

                if (!String.IsNullOrEmpty(socio.PersonaSegundoApellido))
                    sb.Append(socio.PersonaSegundoApellido);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Asocia un Representante a un SocioDTO para fines de despliegue en pantalla
        /// </summary>
        /// <param name="representanteId">ID del representante</param>
        /// <returns></returns>
        private SociosDTO ObtenerDatosRepresentante(int? representanteId)
        {
            //Chequeo para nulos
            if (!representanteId.HasValue) return null;

            //Se busca el objeto en la colección de representantes
            var rep = this.Representantes.Where(r => r.PersonaId == representanteId).FirstOrDefault();
            if (rep == null) return null;

            var socio = new SociosDTO()
                            {
                                ID = rep.PersonaId,
                                Documento = rep.Documento,
                                TipoDocumento = rep.TipoDocumento,
                                PersonaPrimerNombre = rep.PrimerNombre,
                                PersonaSegundoNombre = rep.SegundoNombre,
                                PersonaPrimerApellido = rep.PrimerApellido,
                                PersonaSegundoApellido = rep.SegundoApellido
                            };
            return socio;
        }
        #endregion

        //05 - Revision de datos
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Confirmacion.btnConfirmarDatos_Click(object, EventArgs)'
        protected void btnConfirmarDatos_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Confirmacion.btnConfirmarDatos_Click(object, EventArgs)'
        {
            //Validacion del registro. No puede estar vacio
            if (RegistroNuevo.EsNuevoRegistro && RegistroNuevo.RegistroId != 0)
            {
                Master.ShowMessageError("El registro se envio satisfactoriamente. Si quieres solicitar otro registro vuelve a tu <a href='/default.aspx'>Portafolio de Empresas</a>");
                return;
            }

            //Actualizar Informacion de Solicitante
            this.RegistroNuevo.NombreSolicitante = ((OficinaVirtualUserProfile)Context.Profile).NombreSolicitante;
            this.RegistroNuevo.CargoSolicitante = String.Empty;

            SubmitChanges();

            if (!String.IsNullOrWhiteSpace(ErrorMessage))
            {
                Master.ShowMessageError(ErrorMessage);
                ErrorMessage = String.Empty;
                return;
            }

            //Envio a pantalla de confirmacion
            if (Redirect)
                Response.Redirect("~/Operaciones/Shared/FormaEntrega.aspx" + DefaultQueryString);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Confirmacion.btnModificarDatos_Click(object, EventArgs)'
        protected void btnModificarDatos_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Confirmacion.btnModificarDatos_Click(object, EventArgs)'
        {
            IsFormularionConfirmacion = true;
            this.TransaccionesEnRegistro = null;

            var url = Paginas[0];
            if (!url.Contains("&revisionDatos"))
                url += "&revisionDatos=1";

            Response.Redirect(url);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Confirmacion.CalcularyDesplegarCostos(int)'
        protected void CalcularyDesplegarCostos(int cantidadDocumentos)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Confirmacion.CalcularyDesplegarCostos(int)'
        {
            var sb = new StringBuilder();
            var costoTotal = 0m;

            sb.Append("<div class='window'>");
            sb.Append("<Table>");
            sb.Append("<h1>Costos Estimados</h1>");

            if (this.RegistroNuevo.EsNuevoRegistro)
            {
                var costoConstitucion = ObtenerCostoTransaccion(this.RegistroNuevo.CapitalSocial,
                                                                    TipoTransaccionNm.Constitucion);
                costoTotal += costoConstitucion;

                sb.Append("<tr>");
                sb.Append("<td class='window_titulo'> Matriculaci&oacute;n: </td>");
                sb.Append(String.Format("<td align='right'>{0}</td>", costoConstitucion.ToString("n")));
                sb.Append("</tr>");
            }
            else
            {
                if (ValidarRenovacionNecesaria())
                {
                    var renovacionNueva = ObtenerCostoTransaccion(this.RegistroNuevo.CapitalSocial, TipoTransaccionNm.Renovacion);
                    var renovacionActual = ObtenerCostoTransaccion(this.RegistroSistemaActual.CapitalAutorizado.Value2(), TipoTransaccionNm.Renovacion);
                    var renovacionTotal = renovacionNueva - renovacionActual;

                    costoTotal += renovacionTotal;

                    sb.Append("<tr>");
                    sb.Append("<td class='window_titulo'> Renovaci&oacute;n: </td>");
                    sb.Append(String.Format("<td align='right'>{0}</td>", renovacionTotal.ToString("n")));
                    sb.Append("</tr>");
                }

                sb.Append("<tr>");
                sb.Append("<td class='window_titulo'> Adecuaci&oacute;n: </td>");
                sb.Append(String.Format("<td align='right'>{0}</td>", Helper.CostoAdecuacion.ToString("n")));
                sb.Append("</tr>");
            }

            var costoOriginales = Helper.CostoDepositoOriginal * cantidadDocumentos;
            costoTotal += costoOriginales;
            sb.Append("<tr>");
            sb.Append("<td class='window_titulo'> Documentos Originales: </td>");
            sb.Append(String.Format("<td align='right'>{0}</td>", costoOriginales.ToString("n")));
            sb.Append("</tr>");

            var costoCopias = Helper.CostoDepositoCopia * cantidadDocumentos;
            costoTotal += costoCopias;
            sb.Append("<tr>");
            sb.Append("<td class='window_titulo'> Copias: </td>");
            sb.Append(String.Format("<td align='right'>{0}</td>", costoCopias.ToString("n")));
            sb.Append("</tr>");

            sb.Append("<tr>");
            sb.Append("<td class='window_titulo window_total'> TOTAL </td>");
            sb.Append(String.Format("<td class='window_total' align='right'>{0}</td>", costoTotal.ToString("n")));
            sb.Append("</tr>");

            sb.Append("</Table>");
            sb.Append("</div>");
            //this.litCostosEstimados.Text = sb.ToString();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Confirmacion.gvSociosT_ItemDataBound(object, GridItemEventArgs)'
        protected void gvSociosT_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Confirmacion.gvSociosT_ItemDataBound(object, GridItemEventArgs)'
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                var socio = e.Item.DataItem as SociosGridDTO;
                if (socio == null) return;

                if (socio.Modificado)
                    e.Item.CssClass = "modified";
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Confirmacion.gvSociosT_NeedDataSource(object, GridNeedDataSourceEventArgs)'
        protected void gvSociosT_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Confirmacion.gvSociosT_NeedDataSource(object, GridNeedDataSourceEventArgs)'
        {

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Confirmacion.btnImprimir_Click(object, EventArgs)'
        protected void btnImprimir_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Confirmacion.btnImprimir_Click(object, EventArgs)'
        {

        }
    }

    #region Clases anidadas
    ///<summary>
    /// Representación para el UI de un socio
    ///</summary>
    public class SociosDTO
    {
        /// <summary>
        /// Llave principal
        /// </summary>
        public int? ID { get; set; }
        ///<summary>
        /// Identificador del tipo de socio
        ///</summary>
        public string TipoSocio { get; set; }
        /// <summary>
        /// Tipo de relación del socio con la sociedad
        /// </summary>
        public string TipoRelacion { get; set; }
        /// <summary>
        /// Cargo asignado dentro del consejo de dirección (si posee)
        /// </summary>
        public int? CargoId { get; set; }
        /// <summary>
        /// Tipo de documento: Cedula, pasaporte, u otro
        /// </summary>
        public string TipoDocumento { get; set; }
        /// <summary>
        /// Número de documento
        /// </summary>
        public string Documento { get; set; }
        /// <summary>
        /// Nombre de la empresas/sociedad en caso de que el socio/acconista sea un persona moral
        /// </summary>
        public string SociedadNombreSocial { get; set; }
        /// <summary>
        /// Primer nombre del Accionista/Socio
        /// </summary>
        public string PersonaPrimerNombre { get; set; }
        /// <summary>
        /// Segundo nombre del Accionista/Socio
        /// </summary>
        public string PersonaSegundoNombre { get; set; }
        /// <summary>
        /// Primer apellido del Accionista/Socio
        /// </summary>
        public string PersonaPrimerApellido { get; set; }
        /// <summary>
        /// Segundo apellido del Accionista/Socio
        /// </summary>
        public string PersonaSegundoApellido { get; set; }
        /// <summary>
        /// Cantidad de acciones o cuotas sociales que la persona posee
        /// </summary>
        public int? CantidadAcciones { get; set; }

        /// <summary>
        /// Representante de un accionista. En el caso de empresas y menores de edad
        /// </summary>
        public SociosDTO Representante { get; set; }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosDTO.RepresentanteId'
        public int? RepresentanteId { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosDTO.RepresentanteId'
        /// <summary>
        /// Direccion
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Indica si el socio fue modificado a nivel de UI
        /// </summary>
        public bool Modificado { get; set; }

    }
    ///<summary>
    /// Representación para el UI de varios socios en un Datagrid (solo se usa para confirmacion.aspx)
    ///</summary>
    public class SociosGridDTO
    {
        ///<summary>
        /// Nombre formateado del socio
        ///</summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Cargos ocupados en el consejo de dirección
        /// </summary>
        public string Cargos { get; set; }

        /// <summary>
        /// Número de documento
        /// </summary>
        public string Documento { get; set; }

        /// <summary>
        /// Cantidad de acciones que el socio posee
        /// </summary>
        public int? Cuotas { get; set; }
        
        /// <summary>
        /// Dirección del socio
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Indica que se modificó un socio a nivel de UI
        /// </summary>
        public bool Modificado { get; set; }
    }
    #endregion
}