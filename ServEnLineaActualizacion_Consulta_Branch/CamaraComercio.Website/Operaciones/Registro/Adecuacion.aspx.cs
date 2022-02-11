using System;
using System.Linq;
using CamaraComercio.DataAccess.EF.SRM;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using EF = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website.Operaciones.Registro
{
    ///<summary>
    /// Página que inicia la adecuación de una empresa existente
    ///</summary>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class Adecuacion : FormularioPage
    {
        #region Private fields and Properties

        /// <summary>
        /// Llave Primaria de la Sociedad.  
        /// </summary>
        public int SociedadId
        {
            get
            {
                if (Session["sociedadId"] == null)
                    return 0;

                return int.Parse(Session["sociedadId"].ToString());
            }
            set { Session["sociedadId"] = value; }
        }

        /// <summary>
        /// Llave primaria del numero de registro mecartil de la empresa.
        /// </summary>
        public int RegistroId
        {
            get
            {
                return Session["registroId"] == null ? 0 : int.Parse(Session["registroId"].ToString());
            }
            set { Session["registroId"] = value; }
        }

#pragma warning disable CS0108 // 'Adecuacion.TipoSociedadId' hides inherited member 'FormularioPage.TipoSociedadId'. Use the new keyword if hiding was intended.
        /// <summary>
        /// Llave primaria del numero del tipo de sociedad.
        /// </summary>
        public int TipoSociedadId
#pragma warning restore CS0108 // 'Adecuacion.TipoSociedadId' hides inherited member 'FormularioPage.TipoSociedadId'. Use the new keyword if hiding was intended.
        {
            get
            {
                return Session["TipoSociedadId"] == null ? 0 : int.Parse(Session["TipoSociedadId"].ToString());
            }
            set { Session["TipoSociedadId"] = value; }
        }

        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Adecuacion.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Adecuacion.Page_Load(object, EventArgs)'
        {

            Form.DefaultButton = btnValidarNoRegistro.UniqueID;

            if (!IsPostBack)
            {

                //Se limpian los objetos en sesion
                LimpiarObjetosEnSesion();

                if (this.RegistroId > 0 && this.SociedadId > 0)
                    InitAdecuacionObligatoria();
            }
        }

        private void InitAdecuacionObligatoria()
        {
            var dbSRM = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);

            var regActual = dbSRM.SociedadesRegistros.Where(a => a.RegistroId == this.RegistroId && a.SociedadId == this.SociedadId)
            .Select(a => a.Registros).FirstOrDefault();

            LoadAdecuacionData(dbSRM, regActual);
        }

        // 01 - Validacion del Registro Mercantil y obtencion del objeto Empresa
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Adecuacion.btnValidarNoRegistro_Click(object, EventArgs)'
        protected void btnValidarNoRegistro_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Adecuacion.btnValidarNoRegistro_Click(object, EventArgs)'
        {
            //Mensaje de error
            //this.lblErrorRegistroMercantil.Text = "";

            int noRegistro = Convert.ToInt32(txtNoRegistroMercantil.Text);
            var dbSRM = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(ddlCamaras.SelectedValue);

            var regActual = dbSRM.SociedadesRegistros.Where(a => a.NumeroRegistro == noRegistro && a.Sociedades.Rnc == txtNoRnc.Text)
                .Select(a => a.Registros).FirstOrDefault();


            LoadAdecuacionData(dbSRM, regActual);
        }

        private void LoadAdecuacionData(SRM.CamaraSRMEntities dbSRM, SRM.Registros regActual)
        {
            if (regActual != null)
            {
                //Sociedad relacionada al registro actual
                var SocAdecuada = regActual.SociedadesRegistros.FirstOrDefault();

                if (SocAdecuada.bAdecuada.HasValue && SocAdecuada.bAdecuada.Value)
                {
                    Master.ShowMessageError("La empresa fue adecuada a la nueva legislación satisfactoriamente.");
                    return;
                }

                //Objeto con el registro actual
                this.RegistroSistemaActual = regActual;

                if (regActual.Direcciones == null)
                    regActual.Direcciones = dbSRM.Direcciones.CreateObject();

                //Crear Informacion de Registro Existente
                this.RegistroNuevo = new EF.Registros
                {
                    RegistroMercantil = SocAdecuada.NumeroRegistro,
                    EsNuevoRegistro = false,
                    FechaEmision = regActual.FechaEmision,
                    Activos = regActual.Activos,
                    ActividadNegocio = regActual.ActividadNegocio,
                    NombreComercial = regActual.NombreComercial,
                    BienesRaices = regActual.BienesRaices,
                    CapitalAutorizado = regActual.CapitalAutorizado,
                    CapitalPagado = regActual.CapitalPagado,
                    CapitalSocial = regActual.CapitalSocial,
                    EmpleadosFemeninos = regActual.EmpleadosFemeninos,
                    EmpleadosMasculinos = regActual.EmpleadosMasculinos,
                    EmpleadosTotal = regActual.EmpleadosTotal,
                    FechaInicioOperacion = regActual.FechaInicioOperacion,
                    FechaVencimiento = regActual.FechaVencimiento,
                    MarcaFabrica = regActual.MarcaFabrica,
                    RegistroMarcaFabrica = regActual.RegistroMarcaFabrica,
                    NombreOperador = regActual.NombreOperador,
                    NumeroSocios = regActual.NumeroSocios,
                    PatenteInvencion = regActual.PatenteInversion,
                    RegistroPatenteInvencion = regActual.RegistroPatenteInversion,
                    RegistroNombreComercial = regActual.NombreComercial,
                    TotalAcciones = regActual.TotalAcciones,
                    DireccionApartadoPostal = regActual.Direcciones.ApartadoPostal,
                    DireccionCalle = regActual.Direcciones.Calle,
                    DireccionCiudadId = regActual.Direcciones.CiudadId,
                    DireccionEmail = regActual.Direcciones.Email,
                    DireccionExtension = regActual.Direcciones.Extension,
                    DireccionFax = regActual.Direcciones.Fax,
                    DireccionNumero = regActual.Direcciones.Numero,
                    DireccionSectorId = regActual.Direcciones.SectorId,
                    DireccionTelefonoCasa = regActual.Direcciones.TelefonoCasa,
                    DireccionSitioWeb = regActual.Direcciones.SitioWeb,
                    DireccionTelefonoOficina = regActual.Direcciones.TelefonoOficina,
                    DireccionCiudad = regActual.Direcciones.CiudadDescripcion

                };


                //Crear Informacion de Sociedad
                this.SociedadRegistroNuevo = new DataAccess.EF.OficinaVirtual.Sociedades
                {
                    Rnc = this.txtNoRnc.Text,
                    NombreSocial = SocAdecuada.Sociedades.NombreSocial,
                    TipoSociedadId = SocAdecuada.Sociedades.TipoSociedadId,
                    TipoEnteReguladoId = SocAdecuada.Sociedades.TipoEnteReguladoId,
                    FechaAsamblea = SocAdecuada.Sociedades.FechaAsamblea,
                    FechaConstitucion = SocAdecuada.Sociedades.FechaConstitucion,
                    DuracionSociedad = SocAdecuada.Sociedades.DuracionSociedad,
                    DuraccionDirectiva = SocAdecuada.Sociedades.DuraccionDirectiva,
                    EsEnteRegulado = SocAdecuada.Sociedades.EsEnteRegulado,
                    EsNacional = SocAdecuada.Sociedades.EsNacional,
                    EstatusId = SocAdecuada.Sociedades.EstatusId,
                    NoResolucion = SocAdecuada.Sociedades.NoResolucion,
                    NombreSiglas = SocAdecuada.Sociedades.NombreSiglas,
                    SiglasConfig = SocAdecuada.Sociedades.SiglasConfig,
                    NacionalidadId = SocAdecuada.Sociedades.NacionalidadId,
                    NumeroNaveIndustrial = SocAdecuada.Sociedades.NumeroNaveIndustrial
                };

                //Crear Informacion de la sucursal.
                foreach (var sucursal in SocAdecuada.Sociedades.Suscursales)
                {
                    Suscursales sucursal1 = sucursal;
                    var direccion = dbSRM.Direcciones.FirstOrDefault(a => a.DireccionId == sucursal1.DireccionId);

                    var newSucursal = new EF.Sucursales
                    {
                        Descripcion = sucursal.Descripcion,
                        DireccionApartadoPostal = direccion.ApartadoPostal,
                        DireccionCiudadId = direccion.CiudadId,
                        DireccionCalle = direccion.Calle,
                        DireccionExtension = direccion.Extension,
                        DireccionFax = direccion.Fax,
                        DireccionNumero = direccion.Numero,
                        DireccionTelefonoCasa = direccion.TelefonoCasa,
                        DireccionTelefonoOficina = direccion.TelefonoOficina,
                        DireccionSectorId = direccion.SectorId,
                        SociedadId = sucursal.SociedadId
                    };

                    this.SociedadRegistroNuevo.Sucursales.Add(newSucursal);
                }

                //Load actividades Data
                LoadActividades(regActual);

                //Load Socios Data
                LoadSocios(dbSRM, regActual.RegistroId);

                //Load Productos
                this.LoadProductos(regActual);

                //Load Referencias Bancarias
                this.LoadReferenciasBancarias(regActual);

                //Load Referencias Comerciales
                this.LoadReferenciasComerciales(regActual);

                //Se Activa que los proximos formularios actualicen la interfaz con los datos en session.
                IsFormularionConfirmacion = true;

                if (this.RegistroId == 0 && this.SociedadId == 0)
                    //Se Especifica la camara donde se registra la sociedad.
                    this.CamaraId = ddlCamaras.SelectedValue;

                //Cambio del View activo
                Response.Redirect("DatosGenerales.aspx");
            }
            else
            {
                Master.ShowMessageError("El número de registro sometido no existe en el sistema del Registro Mercantil. Intentalo nuevamente.");
            }
        }

        // 02 - Redirecciona al usuario a la pantalla de nuevo Registro.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Adecuacion.btnLinkNuevoregsitro_Click(object, EventArgs)'
        protected void btnLinkNuevoregsitro_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Adecuacion.btnLinkNuevoregsitro_Click(object, EventArgs)'
        {
            Response.Redirect("NuevoRegistro.aspx");
        }
    }
}