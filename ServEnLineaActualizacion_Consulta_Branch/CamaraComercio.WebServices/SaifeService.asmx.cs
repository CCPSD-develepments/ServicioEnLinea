using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Web.Services;
using CamaraComercio.DataAccess.EF;
using CamaraComercio.Website;
using CamaraComercio.Website.Helpers;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using MembProv = CamaraComercio.DataAccess.EF.Membership;

namespace CamaraComercio.WebServices
{
    /// <summary>
    /// Servicio de integración para el SAIFE (creatuempresa.gob.do)
    /// </summary>
    [WebService(Namespace = "http://registromercantil.org.do/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class SaifeService : WebService
    {
        /// <summary>
        /// Ingresa una nueva transacción de solicitud de creación de empresas
        /// </summary>
        /// <param name="infoRegistro">Información de la empresa a registrar</param>
        /// <param name="camaraID">Cámara de comercio para la cual se genera la operación</param>
        /// <param name="token">Token de autenticación para aplicaciones externas</param>
        /// <returns></returns>
        [WebMethod(Description = "Ingresa una nueva transacción de solicitud de creación de empresas")]
        public int IngresarNuevaEmpresa(RegistroDTO infoRegistro, string camaraID, Guid token)
        {
            //Validacion del token
            var dbMemb = new MembProv.CamaraWebsiteAccountsEntities();
            if (dbMemb.camara_Systems.Where(s => s.SystemId == token && s.Active).Count() == 0)
                return -1;

            //Objetos de acceso a datos
            var dbOfv = new OFV.CamaraWebsiteEntities();
            var repRegistros = new Repository<OFV.Registros, OFV.CamaraWebsiteEntities>(dbOfv);
            var repSociedades = new Repository<OFV.Sociedades, OFV.CamaraWebsiteEntities>(dbOfv);
            var repTransacciones = new Repository<OFV.Transacciones, OFV.CamaraWebsiteEntities>(dbOfv);
            var repSocios = new Repository<OFV.Socios, OFV.CamaraWebsiteEntities>(dbOfv);

            //Creación de la solicitud
            using (var tnx = repRegistros.BeginTransaction())
            {
                try
                {
                    //Registro
                    #region Asignacion del Registro
                    var registro = new OFV.Registros()
                    {
                        GestorUsername = "SAIFE",
                        FechaSolicitud = DateTime.Now,
                        EntidadActiva = true,
                        ActividadNegocio = infoRegistro.ActividadNegocio,
                        Activos = infoRegistro.Activos,
                        BienesRaices = infoRegistro.BienesRaices,
                        CapitalAutorizado = infoRegistro.CapitalAutorizado,
                        CapitalPagado = infoRegistro.CapitalAutorizado,
                        CapitalSocial = infoRegistro.CapitalSocial,
                        CargoSolicitante = "REGISTRO WEB SAIFE",
                        DireccionApartadoPostal = infoRegistro.Direccion.ApartadoPostal,
                        DireccionCalle = infoRegistro.Direccion.Calle,
                        DireccionCiudad = infoRegistro.Direccion.Ciudad,
                        DireccionCiudadId = infoRegistro.Direccion.CiudadId,
                        DireccionEmail = infoRegistro.Direccion.Email,
                        DireccionExtension = infoRegistro.Direccion.Extension,
                        DireccionFax = infoRegistro.Direccion.Fax,
                        DireccionNumero = infoRegistro.Direccion.Numero,
                        DireccionSectorId = infoRegistro.Direccion.SectorId,
                        DireccionSitioWeb = infoRegistro.Direccion.SitioWeb,
                        DireccionTelefonoCasa = infoRegistro.Direccion.TelefonoCasa,
                        DireccionTelefonoOficina = infoRegistro.Direccion.TelefonoOficina,
                        EmpleadosFemeninos = infoRegistro.EmpleadosFemeninos,
                        EmpleadosMasculinos = infoRegistro.EmpleadosMasculinos,
                        EmpleadosTotal = infoRegistro.EmpleadosFemeninos + infoRegistro.EmpleadosFemeninos,
                        EsNuevoRegistro = true,
                        EsRenovacion = false,
                        FechaEmision = null,
                        FechaInicioOperacion = infoRegistro.FechaInicioOperacion,
                        FechaVencimiento = null,
                        NombreOperador = "",
                        NombreSolicitante = infoRegistro.NombreSolicitante,
                        NumeroSocios = infoRegistro.NumeroSocios,
                        MarcaFabrica = infoRegistro.MarcaFabrica,
                        RegistroMarcaFabrica = infoRegistro.NumeroRegistroMarcaFabrica,
                        NombreComercial = infoRegistro.NombreComercial,
                        RegistroNombreComercial = infoRegistro.NumeroRegistroNombreComercial,
                        PatenteInvencion = infoRegistro.PatenteInvencion,
                        RegistroPatenteInvencion = infoRegistro.NumeroRegistroPatenteInvencion,
                        TotalAcciones = infoRegistro.TotalAcciones
                    };
                    #endregion
                    repRegistros.Add(registro);
                    repRegistros.Save();

                    //Sociedad
                    #region Asignacion de la Sociedad
                    var sociedad = new OFV.Sociedades
                                       {
                                           RegistroId = registro.RegistroId,
                                           DuraccionDirectiva = infoRegistro.InfoSociedad.DuraccionDirectiva,
                                           DuracionSociedad = infoRegistro.InfoSociedad.DuracionSociedad,
                                           EsEnteRegulado = false,
                                           FechaAsamblea = infoRegistro.InfoSociedad.FechaAsamblea,
                                           FechaConstitucion = infoRegistro.InfoSociedad.FechaConstitucion,
                                           EsNacional = true,
                                           NacionalidadId = 1, //Rep. Dominicana
                                           NombreSocial = infoRegistro.InfoSociedad.NombreSocial,
                                           TieneCapitalSocial = (infoRegistro.CapitalSocial > 0),
                                           TipoSociedadId = infoRegistro.InfoSociedad.TipoSociedadId,
                                           EstatusId = 1
                                       };
                    #endregion
                    repSociedades.Add(sociedad);
                    repSociedades.Save();

                    //Colecciones - Asignacion de socios
                    var orden = 1;
                    foreach (var infoSocio in infoRegistro.Socios)
                    {
                        var socio = new OFV.Socios()
                                        {
                                            RegistroId = registro.RegistroId,
                                            RegistroMercantil = "",
                                            Orden = orden++,
                                            CantidadAcciones = infoSocio.CantidadAcciones,
                                            NacionalidadId = infoSocio.Nacionalidad,
                                            PersonaEstadoCivil = infoSocio.EstadoCivil,
                                            PersonaPrimerNombre = infoSocio.PrimerNombre,
                                            PersonaSegundoNombre = infoSocio.SegundoNombre,
                                            PersonaPrimerApellido = infoSocio.PrimerApellido,
                                            PersonaSegundoApellido = infoSocio.SegundoApellido,
                                            TipoSocio = infoSocio.TipoSocio,
                                            TipoRelacion = infoSocio.TipoRelacion,
                                            TipoDocumento = infoSocio.TipoDocumento,
                                            Documento = infoSocio.Documento,
                                            CargoId = infoSocio.CargoID,
                                            DireccionCalle = infoSocio.Direccion.Calle,
                                            DireccionApartadoPostal = infoSocio.Direccion.ApartadoPostal,
                                            DireccionCiudadId = infoSocio.Direccion.CiudadId,
                                            DireccionNumero = infoSocio.Direccion.Numero,
                                            DireccionSectorId = infoSocio.Direccion.SectorId
                                        };
                        repSocios.Add(socio);
                    }
                    repSocios.Save();

                    //Transacciones                    
                    var ServiciosDefault = (ServicioSection)WebConfigurationManager.GetWebApplicationSection("servicioSection");
                    var servicioId = ServiciosDefault.Servicios.FirstOrDefault(
                                    a => a.TipoSociedadId == sociedad.TipoSociedadId
                                    && a.TieneCapitalSocial == sociedad.TieneCapitalSocial)
                                    .ServicioConstitucionId;

                    #region Asinacion de la transaccion
                    var transConstitucion = new OFV.Transacciones
                                                {
                                                    Fecha = DateTime.Now,
                                                    NombreContacto = registro.NombreSolicitante,
                                                    RegistroId = registro.RegistroId,
                                                    ModificacionCapital = 0m,
                                                    CapitalSocial = registro.CapitalSocial,
                                                    TipoSociedadId =
                                                        sociedad.TipoSociedadId.Value2(),
                                                    RNCSolicitante = sociedad.Rnc,
                                                    ServicioId = servicioId,
                                                    UserName = User.Identity.Name,
                                                    CamaraId = camaraID,
                                                    EstatusTransId = 1,
                                                    Solicitante = registro.NombreSolicitante,
                                                    FechaReciboDGII = infoRegistro.InfoRecibo.FechaReciboDGII,
                                                    MontoDGII = infoRegistro.InfoRecibo.MontoDGII,
                                                    NoReciboDGII = infoRegistro.InfoRecibo.NoReciboDGII,
                                                    TelefonoContacto = registro.DireccionTelefonoOficina,
                                                    FechaAsamblea = sociedad.FechaAsamblea,
                                                    FaxContacto = registro.DireccionFax,
                                                    NombreSocialPersona = sociedad.NombreSocial

                                                };
                    #endregion
                    repTransacciones.Add(transConstitucion);
                    repTransacciones.Save();

                    tnx.Commit();

                    return transConstitucion.TransaccionId;
                }
                catch (Exception ex)
                {
                    tnx.Rollback();
                    var msg = ex.Message;
                    return -1;
                }
            }
        }

        /// <summary>
        /// Obtiene el estado actual de una transacción previa
        /// </summary>
        /// <param name="transaccionID">ID de la transacción</param>
        /// <returns></returns>
        [WebMethod(Description = "Obtiene el estao actual de una transaccion previa")]
        public EstadoExpedienteDTO ObtenerEstadoExpediente(int transaccionID)
        {
            var repTransacciones = new OFV.TransaccionesRepository();
            var trans = repTransacciones.SelectByKey(OFV.Transacciones.PropColumns.TransaccionId, transaccionID);
            
            //Revisión de transacción nula
            if (trans == null) return null;

            var dbOfv = new OFV.CamaraWebsiteEntities();
            var registro = dbOfv.Registros.Where(r => r.RegistroId == trans.RegistroId).FirstOrDefault();
            
            //Revisión de transacción no realizada por SAIFE
            if (registro == null || registro.GestorUsername != "SAIFE") return null;

            return new EstadoExpedienteDTO()
                       {
                           EstatusID = trans.EstatusTransId,
                           EstatusDescripcion = trans.EstatusTransacciones.EstatusTranNombre
                       };
        }

        #region Listados

        /// <summary>
        /// Obtiene un listado de todas las cámaras en el sistema
        /// </summary>
        /// <returns>Listado de Cámaras de Comercio del país</returns>
        [WebMethod (Description = "Obtiene un listado de todas las cámaras en el sistema")]
        public List<CamaraComercioDTO> ObtenerListadoCamaras()
        {
            var rep = new Comun.CamarasRepository();
            return rep.GetActivas().ToList().Select(c => new CamaraComercioDTO()
            {
                ID = c.ID,
                Nombre = c.Nombre,
                RNC = c.RNC,
                Direccion = c.Direccion
            }).ToList();
        }

        /// <summary>
        /// Obtiene un listado de todos los posibles tipos de empresas
        /// </summary>
        /// <returns>Listado con los tipos de empresas posibles en el sistema</returns>
        [WebMethod (Description = "Obtiene un listado de todos los posibles tipos de empresas")]
        public List<TipoSociedadDTO> ObtenerListadoTiposEmpresas()
        {
            var rep = new Repository<Comun.TipoSociedad, Comun.CamaraComunEntities>();
            return rep.SelectAll().Where(ts => ts.Visible == true).Select(ts => new TipoSociedadDTO()
                                                               {
                                                                   TipoSociedadID = ts.TipoSociedadId,
                                                                   Descripcion = ts.Descripcion,
                                                                   Siglas = ts.Etiqueta
                                                               }).ToList();
        }

        /// <summary>
        /// Obtiene un listado de todas las ciudades en Rep. Dominicana
        /// </summary>
        /// <returns></returns>
        [WebMethod (Description = "Obtiene un listado de todas las ciudades en Rep. Dominicana")]
        public List<CiudadDTO> ObtenerListadoCiudades()
        {
            var rep = new Comun.CiudadesRepository();
            return rep.FecthInDominicanRepublic(new List<int>(), 1)
                .Select(c => new CiudadDTO() {CiudadID = c.CiudadId, NombreCiudad = c.Nombre, PaisID = c.PaisId})
                .ToList();
        }

        /// <summary>
        /// Obtiene un listado de todos los sectores en la ciudad especificadas
        /// </summary>
        /// <param name="ciudadId">ID de la ciudad</param>
        /// <returns></returns>
        [WebMethod(Description = "Obtiene un listado de todos los sectores en la ciudad especificadas")]
        public List<SectorDTO> ObtenerListadoSectores(int ciudadId)
        {
            var rep = new Comun.SectoresRepository();
            return rep.FetchByCiudad(ciudadId)
                .Select(c => new SectorDTO() {CiudadID = c.CiudadId, NombreSector = c.Nombre, SectorID = c.SectorId})
                .ToList();
        }

        /// <summary>
        /// Obtiene un lsitado de todos los cargos que puede tener un socio/accionista
        /// </summary>
        /// <returns></returns>
        [WebMethod(Description = "Obtiene un lsitado de todos los cargos que puede tener un socio/accionista")]
        public List<CargoDTO> ObtenerListadoCargos()
        {
            var rep = new Comun.CargosRepository();
            return rep.SelectVisible()
                .Select(c => new CargoDTO(){CargoID = c.CargoId, Descripcion = c.Descripcion})
                .ToList();
        }
        #endregion
    }

    /// <summary>
    /// Representación para transferencia de datos de una cámara de comercio
    /// </summary>
    public class CamaraComercioDTO
    {
        /// <summary>
        /// ID Identificador de la cámara
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Nombre calificado de la cámara
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// RNC
        /// </summary>
        public string RNC { get; set; }

        /// <summary>
        /// Dirección Física de la cámara (formateada en HTML)
        /// </summary>
        public string Direccion { get; set; }
    }

    /// <summary>
    /// Representación para transferencia de datos del estato de un expediente
    /// </summary>
    public class EstadoExpedienteDTO
    {
        public int EstatusID { get; set; }
        public string EstatusDescripcion { get; set; }
    }

    /// <summary>
    /// Representación para transferencia de datos de los tipos de Sociedad
    /// </summary>
    public class TipoSociedadDTO
    {
        public int TipoSociedadID { get; set; }
        public string Descripcion { get; set; }
        public string Siglas { get; set; }
    }

    /// <summary>
    /// Representación para transferencia de datos de los países en el sistema
    /// </summary>
    public class PaisDTO
    {
        public int PaisID { get; set; }
        public string Nombre { get; set; }
    }

    /// <summary>
    /// Representación para transferencia de datos de las ciudades en el sistema
    /// </summary>
    public class CiudadDTO
    {
        public int CiudadID { get; set; }
        public int? PaisID { get; set; }
        public string NombreCiudad { get; set; }
    }

    /// <summary>
    /// Representación para transferencia de datos de los sectores en el sistema
    /// </summary>
    public class SectorDTO
    {
        public int SectorID { get; set; }
        public int CiudadID { get; set; }
        public string NombreSector { get; set; }
    }

    /// <summary>
    /// Representación para transferencia de datos de los posibles cargos de accionistas
    /// </summary>
    public class CargoDTO
    {
        public int CargoID { get; set; }
        public string Descripcion { get; set; }
    }

    /// <summary>
    /// Representación para transferencia de datos. Registro Nuevo
    /// </summary>
    public class RegistroDTO
    {
        #region Propiedades

        /// <summary>
        /// Capital Social de la sociedad/empresa en RD$
        /// </summary>
        public decimal? CapitalSocial
        { get; set; }

        /// <summary>
        /// Capital Suscrito y Pagado de la sociedad/empresa en RD$
        /// </summary>
        public decimal? CapitalAutorizado
        { get; set; }

        /// <summary>
        /// Cantidad de activos declarados en RD$
        /// </summary>
        public decimal? Activos
        { get; set; }

        /// <summary>
        /// Cantidad de activos declarados en RD$
        /// </summary>
        public decimal? BienesRaices
        { get; set; }

        /// <summary>
        /// Fecha de inicio de la operaciones en RD$
        /// </summary>
        public DateTime? FechaInicioOperacion
        { get; set; }

        /// <summary>
        /// Cantidad de empleados masculinos
        /// </summary>
        public int EmpleadosMasculinos
        { get; set; }

        /// <summary>
        /// Cantidad de empleados femeninos
        /// </summary>
        public int EmpleadosFemeninos
        { get; set; }

        /// <summary>
        /// Nombre del registro de nombre comercial en ONAPI (opcional)
        /// </summary>
        public string NombreComercial
        { get; set; }

        /// <summary>
        /// Numerodel registro de nombre comercial en ONAPI (opcional)
        /// </summary>
        public string NumeroRegistroNombreComercial
        { get; set; }

        /// <summary>
        /// Nombre del registro de marca de fábrica (opcional)
        /// </summary>
        public string MarcaFabrica
        { get; set; }

        /// <summary>
        /// Numero de registro de marca de fábrica (opcional)
        /// </summary>
        public string NumeroRegistroMarcaFabrica
        { get; set; }

        /// <summary>
        /// Nombre de patente de invención (opcional)
        /// </summary>
        public string PatenteInvencion
        { get; set; }

        /// <summary>
        /// Numero de registro de patente de invención (opcional)
        /// </summary>
        public string NumeroRegistroPatenteInvencion
        { get; set; }

        /// <summary>
        /// Descripción de la actividad comercial del negocio
        /// </summary>
        public string ActividadNegocio
        { get; set; }

        /// <summary>
        /// Cantidad de socios en la sociedad/empresa
        /// </summary>
        public int? NumeroSocios
        { get; set; }

        /// <summary>
        /// Número total de acciones emitidas
        /// </summary>
        public int? TotalAcciones
        { get; set; }

        /// <summary>
        /// Nombre de la persona que hace la solicitud de registro
        /// </summary>
        public string NombreSolicitante
        { get; set; }

        /// <summary>
        /// Dirección de la empresa
        /// </summary>
        public DireccionDTO Direccion
        { get; set; }

        /// <summary>
        /// Información sobre la sociedad
        /// </summary>
        public SociedadDTO InfoSociedad 
        { get; set; }

        /// <summary>
        /// Información sobre el recibo de la DGII
        /// </summary>
        public ReciboDGII InfoRecibo 
        { get; set; }

        public List<SociosEnRegistroDTO> Socios { get; set; }

        #endregion

        /// <summary>
        /// Clase Anindada. Información de la sociedad
        /// </summary>
        public class SociedadDTO
        {
            /// <summary>
            /// Tipo de la sociedad
            /// </summary>
            public int? TipoSociedadId
            { get; set; }

            /// <summary>
            /// Nombre Social de la empresa (puede diferir al nombre comercial)
            /// </summary>
            public string NombreSocial
            { get; set; }

            /// <summary>
            /// Fecha de constitución
            /// </summary>
            public DateTime? FechaConstitucion
            { get; set; }

            /// <summary>
            /// Duración en años de la sociedad. Dejar en blanco si es indefinida
            /// </summary>
            public string DuracionSociedad
            { get; set; }

            /// <summary>
            /// Fecha de la asamblea constitutiva
            /// </summary>
            public DateTime? FechaAsamblea
            { get; set; }

            /// <summary>
            /// Duración en años del órgano de dirección
            /// </summary>
            public int? DuraccionDirectiva
            { get; set; }

        }
    }

    /// <summary>
    /// Clase que representa una dirección física (usada para web services)
    /// </summary>
    public class DireccionDTO
    {
        public string Calle
        { get; set; }

        public string Numero
        { get; set; }

        public int? CiudadId
        { get; set; }

        public string Ciudad
        { get; set; }

        public int? SectorId
        { get; set; }

        public string ApartadoPostal
        { get; set; }

        public string TelefonoCasa
        { get; set; }

        public string TelefonoOficina
        { get; set; }

        public int? Extension
        { get; set; }

        public string Fax
        { get; set; }

        public string Email
        { get; set; }

        public string SitioWeb
        { get; set; }
    }

    /// <summary>
    /// Clase que representa un socio de una empresa o sociedad(usada para web services)
    /// </summary>
    public class SociosEnRegistroDTO
    {
        public string TipoSocio { get; set; }
        public string TipoRelacion { get; set; }
        public int? CargoID { get; set; }
        public string EstadoCivil { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public int? Nacionalidad { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int? CantidadAcciones { get; set; }
        public DireccionDTO Direccion { get; set; }
    }
}
