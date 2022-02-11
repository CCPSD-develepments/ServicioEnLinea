using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using TipoSocio = CamaraComercio.DataAccess.EF.CamaraComun.TipoSocio;

namespace CamaraComercio.Website.Operaciones.Ventanilla
{
    ///<summary>
    /// Página que muestra la confirmación de la solicitud, antes de ser enviada a la base de datos
    ///</summary>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class Confirmacion : FormularioPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            //Log de actividades
            Master.NombreActividad = "Confirmación de registro de nueva empresa";

            //Asignación de enlaces en el Step-Menu
            if (!DefaultQueryString.Contains("action=edit"))
                DefaultQueryString = "action=edit";

            //Llenado de datos de la solicitud
            LoadData();

            //Cambios a nombres de elementos gráficos
            RenderizarControles(this.Controls);
        }


        /// <summary>
        /// Carga de datos desde los objetos que están en sesión
        /// </summary>
        private void LoadData()
        {
            //Acceso a DAL datos comunes
            var dbComun = new Comun.CamaraComunEntities();

            //DATOS GENERALES
            litRazonSocial.ToSpan(this.SociedadRegistroNuevo.NombreSocial);

            var nacionalidad = dbComun.Paises.FirstOrDefault(p => p.PaisId == this.SociedadRegistroNuevo.NacionalidadId);
            litNacionalidad.ToSpan(nacionalidad != null ? nacionalidad.Nombre : "Rep. Dominicana");

            var tipoSociedad = dbComun.TipoSociedad.FirstOrDefault(a => a.TipoSociedadId == this.SociedadRegistroNuevo.TipoSociedadId);
            litTipoEmpresa.ToSpan(tipoSociedad != null ? tipoSociedad.Descripcion : String.Empty);

            //TODO: Amhed: Activar de nuevo dependiendo el tipo de empresa
            //litFechaEmision.ToSpan(Utils.FormatearFecha(RegistroNuevo.FechaEmision.Value2()));
            //litFechaVencimiento.ToSpan(Utils.FormatearFecha(RegistroNuevo.FechaVencimiento.Value2()));

            litTelefonoPrimario.ToSpan(this.RegistroNuevo.DireccionTelefonoOficina.FormatTelefono());
            litTelefonoSecundario.ToSpan(this.RegistroNuevo.DireccionTelefonoCasa.FormatTelefono());
            litFax.ToSpan(this.RegistroNuevo.DireccionFax.FormatTelefono());
            litEmail.ToSpan(this.RegistroNuevo.DireccionEmail);
            litWebsite.ToSpan(this.RegistroNuevo.DireccionSitioWeb);
            litDescripcionNegocio.ToSpan(this.RegistroNuevo.ActividadNegocio);

            //Productos
            var sbProductos = new StringBuilder();
            foreach (var producto in this.ProductosEnRegistro)
            {
                sbProductos.Append(producto.Descripcion + "<br/>");
            }
            litPrincipalesProductos.ToSpan(sbProductos.ToString());

            //Actividades
            var sbActividades = new StringBuilder();
            var actividadesList = dbComun.Actividades.ToList();
            foreach (var actividad in this.ActividadesEnRegistro)
            {
                RegistrosActividades actItem = actividad;
                sbActividades.AppendLine(actividadesList
                                .Where(a => a.ActividadID == actItem.TipoActividadId)
                                .FirstOrDefault().Descripcion
                                + "<br/>");
            }
            litActividades.ToSpan(sbActividades.ToString());
            litDireccion.ToSpan(Utils.ConstruirDireccion(this.RegistroNuevo, null));


            //DATOS DE LA SOCIEDAD
            litCapitalSocial.ToSpan(this.RegistroNuevo.CapitalSocial > 0
                                        ? "RD$" + this.RegistroNuevo.CapitalSocial.Value2().ToString("n")
                                        : String.Empty);
            litCapitalSuscrito.ToSpan(this.RegistroNuevo.CapitalPagado > 0
                                        ? "RD$" + this.RegistroNuevo.CapitalPagado.Value2().ToString("n")
                                        : String.Empty);

            litBienesRaices.ToSpan("RD$" + this.RegistroNuevo.BienesRaices.Value2().ToString("n"));
            litActivos.ToSpan("RD$" + this.RegistroNuevo.Activos.Value2().ToString("n"));

            //Fecha de inicio de operacion es opcional
            if (this.RegistroNuevo.FechaInicioOperacion.HasValue && this.RegistroNuevo.FechaInicioOperacion != DateTime.MinValue)
                litFechaInicio.ToSpan(Utils.FormatearFecha(this.RegistroNuevo.FechaInicioOperacion.Value2()));
            
            litFechaAsamblea.ToSpan(Utils.FormatearFecha(this.SociedadRegistroNuevo.FechaAsamblea.Value2()));

            //Referencias Bancarias
            var sbRefBancarias = new StringBuilder();
            foreach (var refbancaria in this.ReferenciasBancariasRegistro)
            {
                sbRefBancarias.Append(refbancaria.NombreBanco + "<br/>");
            }
            litReferenciasBancarias.ToSpan(sbRefBancarias.ToString());

            //Referencias Comerciales
            var sbRefComerciales = new StringBuilder();
            foreach (var refComercial in this.ReferenciasComercialesRegistro)
            {
                sbRefComerciales.Append(refComercial.Descripcion + "<br/>");
            }
            litReferenciasComerciales.ToSpan(sbRefComerciales.ToString());

            //Otros
            int duracionSociedad;
            Int32.TryParse(this.SociedadRegistroNuevo.DuracionSociedad, out duracionSociedad);
            litDuracionSociedad.ToSpan(duracionSociedad > 0 ? this.SociedadRegistroNuevo.DuracionSociedad : "INDEFINIDA");

            if (this.SociedadRegistroNuevo.DuraccionDirectiva.HasValue && this.SociedadRegistroNuevo.DuraccionDirectiva > 0)
                litDuracionConsejo.ToSpan(this.SociedadRegistroNuevo.DuraccionDirectiva);

            //Entes Regulados
            var sbEnteRegulado = new StringBuilder();
            if (this.SociedadRegistroNuevo.EsEnteRegulado && this.SociedadRegistroNuevo.TipoEnteReguladoId > 0)
            {
                var descEnteRegulado = dbComun.TiposEnteRegulado.Where(
                                        t => t.TipoEnteReguladoId == this.SociedadRegistroNuevo.TipoEnteReguladoId)
                                        .FirstOrDefault();
                sbEnteRegulado.Append(String.Format("{0} - {1}", this.SociedadRegistroNuevo.NoResolucion, descEnteRegulado.Descripcion));
            }
            else
            {
                sbEnteRegulado.Append("Ente no regulado");
            }
            litregulacion.ToSpan(sbEnteRegulado.ToString());

            var strEmpleados = String.Format("M: {0} / F: {1}",
                                                   this.RegistroNuevo.EmpleadosMasculinos,
                                                   this.RegistroNuevo.EmpleadosFemeninos);

            litEmpleados.ToSpan(strEmpleados);

            //Sucursales
            var sbSucursales = new StringBuilder();
            foreach (var sucursal in this.SucursalesRegistro)
            {
                sbSucursales.Append(sucursal.Descripcion + "<br/>");
            }
            litSucursales.ToSpan(sbSucursales.ToString());
            litNombreComercial.ToSpan(this.RegistroNuevo.NombreComercial);

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

                socioenGrid.Cargos = FormatearCargosSocio(socio, tipoSocios, cargosList);

                socioListGrid.Add(socioenGrid);
            }

            //this.gvSocios.DataSource = sociosFormatted;
            this.gvSociosT.DataSource = socioListGrid;
            this.gvSociosT.DataBind();
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

                if (tipoSocio.TipoSocioId == "C")
                    sb.AppendFormat("{0} - {1}, ", tipoSocio.Descripcion, tipoCargo.Descripcion);
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

                if (socio.PersonaSegundoNombre.Length > 0)
                    sb.Append(socio.PersonaSegundoNombre);

                sb.Append(socio.PersonaPrimerApellido + " ");

                if (socio.PersonaSegundoApellido.Length > 0)
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
        protected void btnConfirmarDatos_Click(object sender, EventArgs e)
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
            if (RegistroNuevo.EsNuevoRegistro)
                DefaultQueryString = "nuevaEmp=true";

            GuardarObjetosRegistro();

        }
        protected void btnModificarDatos_Click(object sender, EventArgs e)
        {
            IsFormularionConfirmacion = true;
            Response.Redirect("DatosGenerales.aspx" + DefaultQueryString);
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
    }
    #endregion
}