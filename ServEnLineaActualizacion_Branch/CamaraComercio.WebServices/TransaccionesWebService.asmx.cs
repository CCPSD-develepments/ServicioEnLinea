using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.Website;

namespace CamaraComercio.WebServices
{
    /// <summary>
    /// Summary description for TransaccionesWebService
    /// </summary>
    [WebService(Namespace = "http://www.registromercantil.org.do/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TransaccionesWebService : System.Web.Services.WebService
    {
        /// <summary>
        /// Retorna el objeto de Transaccion Srm por el TransaccionId de SRM
        /// </summary>
        /// <param name="transactionId"></param>
        /// <param name="camaraId"></param>
        /// <returns></returns>
        [WebMethod]
        public TransaccionSrmDto GetTransaccionSrmBySrmId(int transactionId, string camaraId)
        {
            var srm = new TransaccionSrm();
            srm.InitializeWithSrm(transactionId, camaraId);
            return new TransaccionSrmDto(srm);
        }

        /// <summary>
        /// Retorna el Objeto de Transaccion Srm por el TransaccionId de Website
        /// </summary>
        /// <param name="transactionId"></param>
        /// <param name="camaraId"></param>
        /// <returns></returns>
        [WebMethod]
        public TransaccionSrmDto GetTransaccionSrmByTransId(int transactionId, string camaraId)
        {
            var srm = new TransaccionSrm();
            srm.InitializeWithWebSite(transactionId, camaraId);
            return new TransaccionSrmDto(srm);
        }

        /// <summary>
        /// Obtiene todos los documentos asociados a una transacción el SRM.
        /// </summary>
        /// <param name="srmTransaccionId">Id de la transacción en el SRM.</param>
        /// <returns></returns>
        [WebMethod(Description = "Obtiene todos los documentos registrados en una transaccion del WebSite con SrmID")]
        public List<TransaccionesDocumentosDto> GetTransaccionesDocumentos(int srmTransaccionId)
        {
            var tnx = new TransaccionesController();
            var docs = tnx.GetTransaccionesDocumentos(srmTransaccionId);

            return docs.Select(a => Utils.Clone<TransaccionesDocumentosDto, TransaccionesDocumentos>(a)).ToList();
        }

        /// <summary>
        /// Obtiene el documento para visualizar.
        /// </summary>
        /// <param name="id">Id del docuemnto registrado en el Website.</param>
        /// <param name="srmTransaccionId">Id de la transacción en el SRM.</param>
        /// <returns></returns>
        [WebMethod(Description = "Obtiene un documento registrado en una transaccion del WebSite con SrmID y el Id de documento")]
        public TransaccionesDocumentosDto GetTransaccionesDocumento(int id, int srmTransaccionId)
        {
            var tnx = new TransaccionesController();
            var docs = tnx.GetTransaccionesDocumentos(id, srmTransaccionId);
            var result = Utils.Clone<TransaccionesDocumentosDto, TransaccionesDocumentos>(docs);
            return result;
        }

        /// <summary>
        /// Actualiza el objeto Transaccion del Web con el TransaccionId de SRM e indica que ya fue cargado.
        /// </summary>
        /// <param name="transaccionId">Id de la transacción en el Web site.</param>
        /// <param name="bLoadedSrm">Flag que ini</param>
        /// <param name="srmTransaccionId">Id de la transacción en el SRM.</param>
        /// <returns></returns>
        [WebMethod(Description = "Actualiza el objeto Transaccion del Web con el TransaccionId de SRM e indica que ya fue cargado.")]
        public int UpdateTransacciones(int transaccionId, bool bLoadedSrm, int srmTransaccionId)
        {
            var tnx = new TransaccionesController();
            return tnx.UpdateTransacciones(transaccionId, bLoadedSrm, srmTransaccionId);
        }

        /// <summary>
        /// Actualiza el objeto Transaccion del Web con el bDataLoadedInSRM indicando que los datos fueron cargados por el analista en SRM..
        /// </summary>
        /// <param name="transaccionId">Id de la transacción en el Web site.</param>
        /// <param name="bDataLoadedInSRM">Flag que indica si los datos fueron cargados en SRM</param>
        /// <returns></returns>
        [WebMethod(Description = "Actualiza el objeto Transaccion del Web con el TransaccionId indicando que los datos fueron cargados por el analista en SRM.")]
        public int UpdateTransaccionesDataLoaded(int transaccionId, bool bDataLoadedInSRM)
        {
            var tnx = new TransaccionesController();
            return tnx.UpdateTransacciones(transaccionId, bDataLoadedInSRM,0);
        }

        /// <summary>
        /// Actualiza el objeto Transaccion del Web como pagado desde el SRM.
        /// </summary>
        /// <param name="transaccionId">Id de la transacción en el Web site.</param>
        /// <returns></returns>
        [WebMethod(Description = "Actualiza el objeto Transaccion del Web como pagado desde el SRM")]
        public int MarkPaidTransaccion(int transaccionId)
        {
            var tnx = new TransaccionesController();
            return tnx.UpdateTransaccionPagada(transaccionId);
        }

        /// <summary>
        /// Obtiene la transaccion asociada al ID.
        /// </summary>
        /// <param name="transaccionId">Id de la transacción en el Web site.</param>
        /// <returns></returns>
        [WebMethod]
        public TransaccionesDto GetTransaccionById(int transaccionId, string camaraId)
        {
            var db = new CamaraWebsiteEntities();
            var query =
                db.Transacciones.Where(
                    a => a.TransaccionId == transaccionId && a.CamaraId == camaraId);
            var trans = query.FirstOrDefault();
            return new TransaccionesDto(trans);
        }

        /// <summary>
        /// Obtiene la transaccion asociada al Srm Id
        /// </summary>
        /// <param name="transaccionSrmId">Id de la transacción del Srm.</param>
        /// <returns></returns>
        [WebMethod]
        public TransaccionesDto GetTransaccionBySrmId(int transaccionSrmId, string camaraId)
        {
            var db = new CamaraWebsiteEntities();
            var query = db.Transacciones.Where(a => a.SrmTransaccionId == transaccionSrmId && a.CamaraId == camaraId);
            var trans = query.FirstOrDefault();
            return new TransaccionesDto(trans);
        }

        /// <summary>
        /// Obtiene la transaccion asociada al Rnc o cédula
        /// </summary>
        /// <param name="rncOrCedula">Cédula or Rnc de la Transacción.</param>
        /// <returns></returns>
        [WebMethod]
        public TransaccionesDto GetTransaccionByRncOrCedula(String rncOrCedula, string camaraId)
        {
            var db = new CamaraWebsiteEntities();
            var query =
                db.Transacciones.Where(
                    a => a.RNCSolicitante == rncOrCedula && a.CamaraId == camaraId);
            var trans = query.FirstOrDefault();
            return new TransaccionesDto(trans);
        }

        /// <summary>
        /// Obtener las copias registradas de una transaccion.
        /// </summary>
        /// <param name="transaccionId">id de la transaccion.</param>
        /// <returns></returns>
        [WebMethod]
        public List<CopiasRegistradasDto> GetCopiasRegistradas(int transaccionId) 
        {
            var db = new CamaraWebsiteEntities();

            var query = from cop in db.TransaccionCopiasCertificadas
                        where cop.TransaccionId.Equals(transaccionId)
                        select new CopiasRegistradasDto
                        {
                            TransaccionId = cop.TransaccionId,
                            Ruta = cop.Ruta,
                            NombreDocumento = cop.NombreDocumento,
                            FechaDocumento = cop.FechaDocumento,
                            CantPaginas = cop.CantPaginas,

                        };

            return query.ToList() ;
        }

    }

    public class TransaccionesDocumentosDto
    {

        public int TransaccionesDocumentosId { get; set; }
        public int TransaccionId { get; set; }
        public int TipoDocumentoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string NombreArchivo { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string Usuario { get; set; }
        public byte[] DocContent { get; set; }
        public Guid RowId { get; set; }
        public string DocContentType { get; set; }
        public int CantidadCopia { get; set; }
        public int CantidadOriginal { get; set; }
        public decimal CostoOriginal { get; set; }
        public decimal CostoCopia { get; set; }
        public bool EsRegistrable { get; set; }
        public int? Grupo { get; set; }
        public DateTime? FechaDocumento { get; set; }

    }

    //public class TransaccionesDocSelectDto
    //{
    //    public String TipoDocumentoId { get; set; }
    //    public int CantidadCopia { get; set; }
    //    public int CantidadOriginal { get; set; }
    //}

    [Serializable]
    public class TransaccionSrmDto
    {

        public TransaccionesDto Transaccion { get; set; }
        public RegistrosDto Registro { get; set; }
        public SociedadesDto Sociedad { get; set; }
        public FacturaDto Factura { get; set; }
        public List<SociosDto> Socios { get; set; }
        public List<ProductosDto> Productos { get; set; }
        public List<RegistrosActividadesDto> RegistroActividades { get; set; }
        public List<ReferenciasComercialesDto> ReferenciasComerciales { get; set; }
        public List<ReferenciasBancariasDto> ReferenciasBancarias { get; set; }
        public List<SucursalesDto> Sucursales { get; set; }
        public List<TransaccionDetalleDto> TransaccionDetalle { get; set; }

        public TransaccionSrmDto(TransaccionSrm entity)
        {
            if (entity.Transaccion != null)
                this.Transaccion = new TransaccionesDto(entity.Transaccion);

            if (entity.Registro != null)
                this.Registro = new RegistrosDto(entity.Registro);

            if (entity.Sociedad != null)
                this.Sociedad = new SociedadesDto(entity.Sociedad);

            this.Socios = new List<SociosDto>();
            this.Productos = new List<ProductosDto>();
            this.RegistroActividades = new List<RegistrosActividadesDto>();
            this.ReferenciasBancarias = new List<ReferenciasBancariasDto>();
            this.ReferenciasComerciales = new List<ReferenciasComercialesDto>();
            this.Sucursales = new List<SucursalesDto>();
            this.TransaccionDetalle = new List<TransaccionDetalleDto>();

            if (entity.Factura != null)
                this.Factura = new FacturaDto(entity.Factura);

            if (entity.Socios != null)
                foreach (var socio in entity.Socios)
                    this.Socios.Add(new SociosDto(socio));

            if (entity.Productos != null)
                foreach (var producto in entity.Productos)
                    this.Productos.Add(new ProductosDto(producto));

            if (entity.RegistroActividades != null)
                foreach (var producto in entity.RegistroActividades)
                    this.RegistroActividades.Add(new RegistrosActividadesDto(producto));

            if (entity.ReferenciasBancarias != null)
                foreach (var producto in entity.ReferenciasBancarias)
                    this.ReferenciasBancarias.Add(new ReferenciasBancariasDto(producto));

            if (entity.ReferenciasComerciales != null)
                foreach (var producto in entity.ReferenciasComerciales)
                    this.ReferenciasComerciales.Add(new ReferenciasComercialesDto(producto));

            if (entity.Sociedad != null && entity.Sociedad.Sucursales.Count() > 0)
                foreach (var sucursal in entity.Sociedad.Sucursales)
                    this.Sucursales.Add(new SucursalesDto(sucursal));


            if (entity.Factura != null && entity.TransaccionDetalle != null)
                foreach (var detalle in entity.TransaccionDetalle)
                    this.TransaccionDetalle.Add(new TransaccionDetalleDto(detalle));

        }

        public TransaccionSrmDto()
        {

        }
    }
    public class SucursalesDto
    {
        #region Primitive Properties

        public int SucursalId { get; set; }

        public int SociedadId { get; set; }

        public string Descripcion { get; set; }

        public int? DireccionId { get; set; }

        public System.DateTime FechaModificacion { get; set; }

        public string DireccionCalle { get; set; }

        public string DireccionNumero { get; set; }

        public int? DireccionCiudadId { get; set; }

        public int? DireccionSectorId { get; set; }

        public string DireccionApartadoPostal { get; set; }

        public string DireccionTelefonoCasa { get; set; }

        public string DireccionTelefonoOficina { get; set; }

        public int? DireccionExtension { get; set; }

        public string DireccionFax { get; set; }

        #endregion

        public SucursalesDto()
        {

        }

        public SucursalesDto(Sucursales entity)
        {
            this.SucursalId = entity.SucursalId;
            this.SociedadId = entity.SociedadId;
            this.Descripcion = entity.Descripcion;
            this.DireccionId = entity.DireccionId;
            this.FechaModificacion = entity.FechaModificacion;
            this.DireccionCalle = entity.DireccionCalle;
            this.DireccionNumero = entity.DireccionNumero;
            this.DireccionCiudadId = entity.DireccionCiudadId;
            this.DireccionSectorId = entity.DireccionSectorId;
            this.DireccionApartadoPostal = entity.DireccionApartadoPostal;
            this.DireccionTelefonoCasa = entity.DireccionTelefonoCasa;
            this.DireccionTelefonoOficina = entity.DireccionTelefonoOficina;
            this.DireccionExtension = entity.DireccionExtension;
            this.DireccionFax = entity.DireccionFax;
        }
    }
    public class RegistrosDto
    {
        #region Primitive Properties

        public int RegistroId { get; set; }

        public int? RegistroMercantil { get; set; }

        public DateTime? FechaEmision { get; set; }

        public DateTime? FechaVencimiento { get; set; }

        public decimal? CapitalSocial { get; set; }

        public decimal? CapitalAutorizado { get; set; }

        public decimal? CapitalPagado { get; set; }

        public decimal? Activos { get; set; }

        public decimal? BienesRaices { get; set; }

        public DateTime? FechaInicioOperacion { get; set; }

        public int? EmpleadosMasculinos { get; set; }

        public int? EmpleadosFemeninos { get; set; }

        public int? EmpleadosTotal { get; set; }

        public string NombreComercial { get; set; }

        public string RegistroNombreComercial { get; set; }

        public string MarcaFabrica { get; set; }

        public string RegistroMarcaFabrica { get; set; }

        public string PatenteInvencion { get; set; }

        public string RegistroPatenteInvencion { get; set; }

        public string NombreOperador { get; set; }

        public string ActividadNegocio { get; set; }

        public int? NumeroSocios { get; set; }

        public int? TotalAcciones { get; set; }

        public bool EsNuevoRegistro { get; set; }

        public string DireccionCalle { get; set; }

        public string DireccionNumero { get; set; }

        public int? DireccionCiudadId { get; set; }

        public int? DireccionSectorId { get; set; }

        public string DireccionApartadoPostal { get; set; }

        public string DireccionTelefonoCasa { get; set; }

        public string DireccionTelefonoOficina { get; set; }

        public int? DireccionExtension { get; set; }

        public string DireccionFax { get; set; }

        public string DireccionEmail { get; set; }

        public string DireccionSitioWeb { get; set; }

        public string NombreSolicitante { get; set; }

        public string CargoSolicitante { get; set; }

        public string GestorUsername { get; set; }

        public DateTime? FechaSolicitud { get; set; }

        public bool? EntidadActiva { get; set; }

        public string DireccionCiudad { get; set; }

        public bool EsRenovacion { get; set; }

        public int? SrmRegistroId { get; set; }

        #endregion

        public RegistrosDto()
        {

        }

        public RegistrosDto(Registros entity)
        {
            this.RegistroId = entity.RegistroId;
            this.RegistroMercantil = entity.RegistroMercantil;
            this.FechaEmision = entity.FechaEmision;
            this.FechaVencimiento = entity.FechaVencimiento;
            this.CapitalSocial = entity.CapitalSocial;
            this.CapitalAutorizado = entity.CapitalAutorizado;
            this.CapitalPagado = entity.CapitalPagado;
            this.Activos = entity.Activos;
            this.BienesRaices = entity.BienesRaices;
            this.FechaInicioOperacion = entity.FechaInicioOperacion;
            this.EmpleadosMasculinos = entity.EmpleadosMasculinos;
            this.EmpleadosFemeninos = entity.EmpleadosFemeninos;
            this.EmpleadosTotal = entity.EmpleadosTotal;
            this.NombreComercial = entity.NombreComercial;
            this.RegistroNombreComercial = entity.RegistroNombreComercial;
            this.MarcaFabrica = entity.MarcaFabrica;
            this.RegistroMarcaFabrica = entity.RegistroMarcaFabrica;
            this.PatenteInvencion = entity.PatenteInvencion;
            this.RegistroPatenteInvencion = entity.RegistroPatenteInvencion;
            this.NombreOperador = entity.NombreOperador;
            this.ActividadNegocio = entity.ActividadNegocio;
            this.NumeroSocios = entity.NumeroSocios;
            this.TotalAcciones = entity.TotalAcciones;
            this.EsNuevoRegistro = entity.EsNuevoRegistro;
            this.DireccionCalle = entity.DireccionCalle;
            this.DireccionNumero = entity.DireccionNumero;
            this.DireccionCiudadId = entity.DireccionCiudadId;
            this.DireccionSectorId = entity.DireccionSectorId;
            this.DireccionApartadoPostal = entity.DireccionApartadoPostal;
            this.DireccionTelefonoCasa = entity.DireccionTelefonoCasa;
            this.DireccionTelefonoOficina = entity.DireccionTelefonoOficina;
            this.DireccionExtension = entity.DireccionExtension;
            this.DireccionFax = entity.DireccionFax;
            this.DireccionEmail = entity.DireccionEmail;
            this.DireccionSitioWeb = entity.DireccionSitioWeb;
            this.NombreSolicitante = entity.NombreSolicitante;
            this.CargoSolicitante = entity.CargoSolicitante;
            this.GestorUsername = entity.GestorUsername;
            this.FechaSolicitud = entity.FechaSolicitud;
            this.EntidadActiva = entity.EntidadActiva;
            this.DireccionCiudad = entity.DireccionCiudad;
            this.EsRenovacion = entity.EsRenovacion;
            this.SrmRegistroId = entity.SrmRegistroId;
        }
    }
    public class TransaccionesDto
    {
        #region Primitive Properties

        public int TransaccionId { get; set; }

        public System.DateTime Fecha { get; set; }

        public string Solicitante { get; set; }

        public string RNCSolicitante { get; set; }

        public string NombreContacto { get; set; }

        public string TelefonoContacto { get; set; }

        public string FaxContacto { get; set; }

        public string NoReciboDGII { get; set; }

        public DateTime? FechaReciboDGII { get; set; }

        public decimal? MontoDGII { get; set; }

        public string DestinoTraslado { get; set; }

        public string NombreSocialPersona { get; set; }

        public string ApellidoPersona { get; set; }

        public int TipoSociedadId { get; set; }

        public int? NumeroRegistro { get; set; }

        public DateTime? FechaAsamblea { get; set; }

        public decimal? CapitalSocial { get; set; }

        public decimal? ModificacionCapital { get; set; }

        public int RegistroId { get; set; }

        public bool? bLoadedInSRM { get; set; }

        public int ServicioId { get; set; }

        public string CamaraId { get; set; }

        public int? Tipo { get; set; }

        public string NCF { get; set; }

        public string TipoNcf { get; set; }

        public int EstatusTransId { get; set; }

        public int? SrmTransaccionId { get; set; }

        public string UserName { get; set; }

        public bool bPagada { get; set; }

        private int? SubTransaccionId { get; set; }

        public string InstanceXML { get; set; }

        public string Comentario { get; set; }

        public int? WebRegistroId { get; set; }

        public bool bDataLoadedInSRM { get; set; }

        public ServicioComun ServicioComun { get; set; }
        public List<TransaccionesDocumentosDto> TransaccionesDocumentos { get; set; }
        public List<TransaccionesDto> SubTransacciones { get; set; }

        public FacturaDto Factura { get; set; }
        public List<TransaccionDetalleDto> TransaccionDetalle { get; set; }

        #endregion

        public TransaccionesDto()
        {

        }

        public TransaccionesDto(Transacciones entity)
        {
            this.TransaccionesDocumentos = new List<TransaccionesDocumentosDto>();
            this.SubTransacciones = new List<TransaccionesDto>();

            if (entity == null)
                return;

            this.TransaccionId = entity.TransaccionId;
            this.Fecha = entity.Fecha;
            this.Solicitante = entity.Solicitante;
            this.RNCSolicitante = entity.RNCSolicitante;
            this.NombreContacto = entity.NombreContacto;
            this.TelefonoContacto = entity.TelefonoContacto;
            this.FaxContacto = entity.FaxContacto;
            this.NoReciboDGII = entity.NoReciboDGII;
            this.FechaReciboDGII = entity.FechaReciboDGII;
            this.MontoDGII = entity.MontoDGII;
            this.DestinoTraslado = entity.DestinoTraslado;
            this.NombreSocialPersona = entity.NombreSocialPersona;
            this.ApellidoPersona = entity.ApellidoPersona;
            this.TipoSociedadId = entity.TipoSociedadId;
            this.NumeroRegistro = entity.NumeroRegistro;
            this.FechaAsamblea = entity.FechaAsamblea;
            this.CapitalSocial = entity.CapitalSocial;
            this.ModificacionCapital = entity.ModificacionCapital;
            this.RegistroId = entity.RegistroId;
            this.bLoadedInSRM = entity.bLoadedInSRM;
            this.ServicioId = entity.ServicioId;
            this.CamaraId = entity.CamaraId;
            this.Tipo = entity.Tipo;
            this.NCF = entity.NCF;
            this.TipoNcf = entity.TipoNcf;
            this.EstatusTransId = entity.EstatusTransId;
            this.SrmTransaccionId = entity.SrmTransaccionId;
            this.UserName = entity.UserName;
            this.bPagada = entity.bPagada;
            this.SubTransaccionId = entity.SubTransaccionId;
            this.InstanceXML = entity.InstanceXML;
            this.Comentario = entity.Comentario;
            this.WebRegistroId = entity.WebRegistroId;
            this.bDataLoadedInSRM = (bool)entity.bDataLoadedInSRM;

            this.TransaccionDetalle = new List<TransaccionDetalleDto>();


            var dbComun = new CamaraComunEntities();
            var result = dbComun.Servicio.FirstOrDefault(a => a.ServicioId == entity.ServicioId);
            var servicioComun = new ServicioComun
                           {
                               ServicioId = entity.ServicioId,
                               Nombre = result.Descripcion,
                               TipoServicioId = result.TipoServicioId,
                               Cuenta = result.Cuenta,
                               PrecioUnitario = result.CalculoBaseCapital ? 0m : result.CostoServicio
                           };
            this.ServicioComun = servicioComun;

            if (entity.SubTransacciones != null)
                foreach (var item in entity.SubTransacciones.ToList())
                    this.SubTransacciones.Add(new TransaccionesDto(item));

            if (entity.TransaccionesDocumentos != null)
                foreach (var item in entity.TransaccionesDocumentos.ToList())
                {
                    var docLoaded = dbComun.TipoDocumento.FirstOrDefault(
                        a =>
                        a.TipoDocumentoId == item.TipoDocumentoId);

                    var Serv = dbComun.ServicioDocumentoRequerido.FirstOrDefault(a => a.TipoSociedadId == this.TipoSociedadId &&
                        a.ServicioId == this.ServicioId && a.TipoDocumentoId == item.TipoDocumentoId);

                    var docs = Utils.Clone<TransaccionesDocumentosDto, TransaccionesDocumentos>(item);
                    docs.CostoOriginal = docLoaded.CostoOriginal;
                    docs.CostoCopia = docLoaded.CostoCopia;
                    docs.EsRegistrable = docLoaded.Registrable;
                    docs.FechaDocumento = item.FechaDocumento;
                    if (Serv != null)
                        docs.Grupo = Serv.Grupo;
                    this.TransaccionesDocumentos.Add(docs);
                }

            foreach (var item in entity.TransaccionDocSeleccionado)
            {
                var docLoaded = dbComun.TipoDocumento.FirstOrDefault(
                    a =>
                    a.TipoDocumentoId == item.TipoDocumentoId);

                var Serv = dbComun.ServicioDocumentoRequerido.FirstOrDefault(a => a.TipoSociedadId == this.TipoSociedadId &&
                a.ServicioId == this.ServicioId && a.TipoDocumentoId == item.TipoDocumentoId);

                var newDoc = new TransaccionesDocumentosDto()
                                                        {
                                                            CantidadCopia = item.CantidadCopia,
                                                            CantidadOriginal = item.CantidadOriginal,
                                                            TipoDocumentoId = item.TipoDocumentoId,
                                                            TransaccionId = item.TransaccionId,
                                                            Descripcion = docLoaded.Nombre,
                                                            CostoCopia = docLoaded.CostoCopia,
                                                            CostoOriginal = docLoaded.CostoOriginal,
                                                            EsRegistrable = docLoaded.Registrable,
                                                            Grupo = Serv != null ? Serv.Grupo : (int?)null,
                                                            FechaDocumento = item.FechaDocumento

                                                        };


                this.TransaccionesDocumentos.Add(newDoc);
            }

            var dbWebsite = new CamaraWebsiteEntities();

            var factura = dbWebsite.Facturas.FirstOrDefault(a => a.TransaccionId == this.TransaccionId);

            if (factura != null)
            {
                this.Factura = new FacturaDto(factura);
                var tranDetalle = factura.TransaccionDetalle.ToList();

                if (factura != null && tranDetalle != null)
                    foreach (var detalle in tranDetalle)
                        this.TransaccionDetalle.Add(new TransaccionDetalleDto(detalle));
            }
        }
    }
    public class CopiasRegistradasDto
    {
        #region Primitive Properties

        public int TransaccionId { get; set; }
        public string Ruta { get; set; }
        public string NombreDocumento { get; set; }
        public DateTime? FechaDocumento { get; set; }
        public int CantPaginas { get; set; }

        #endregion
    }
    public class SociedadesDto
    {
        #region Primitive Properties

        public int SociedadId { get; set; }
        public int RegistroId { get; set; }
        public int? TipoSociedadId { get; set; }
        public string NombreSocial { get; set; }
        public string Rnc { get; set; }
        public bool EsNacional { get; set; }
        public int? NacionalidadId { get; set; }
        public DateTime? FechaConstitucion { get; set; }
        public string DuracionSociedad { get; set; }
        public DateTime? FechaAsamblea { get; set; }
        public int? DuraccionDirectiva { get; set; }
        public int? EstatusId { get; set; }
        public bool EsEnteRegulado { get; set; }
        public int? TipoEnteReguladoId { get; set; }
        public string NoResolucion { get; set; }
        public string NumeroNaveIndustrial { get; set; }
        public string NombreSiglas { get; set; }
        public string SiglasConfig { get; set; }
        public string Suscripcion { get; set; }
        public int? AccionesNominales { get; set; }
        public int? AccionesNoNominales { get; set; }
        public int? SrmSociedadId { get; set; }

        public SociedadesDto()
        {

        }

        public SociedadesDto(Sociedades entity)
        {
            this.SociedadId = entity.SociedadId;
            this.RegistroId = entity.RegistroId;
            this.TipoSociedadId = entity.TipoSociedadId;
            this.NombreSocial = entity.NombreSocial;
            this.Rnc = entity.Rnc;
            this.EsNacional = entity.EsNacional;
            this.NacionalidadId = entity.NacionalidadId;
            this.FechaConstitucion = entity.FechaConstitucion;
            this.DuracionSociedad = entity.DuracionSociedad;
            this.FechaAsamblea = entity.FechaAsamblea;
            this.DuraccionDirectiva = entity.DuraccionDirectiva;
            this.EstatusId = entity.EstatusId;
            this.EsEnteRegulado = entity.EsEnteRegulado;
            this.TipoEnteReguladoId = entity.TipoEnteReguladoId;
            this.NoResolucion = entity.NoResolucion;
            this.NumeroNaveIndustrial = entity.NumeroNaveIndustrial;
            this.NombreSiglas = entity.NombreSiglas;
            this.SiglasConfig = entity.SiglasConfig;
            this.AccionesNominales = entity.AccionesNominales;
            this.AccionesNoNominales = entity.AccionesNoNominales;
            this.SrmSociedadId = entity.SrmSociedadId;
        }

        #endregion
    }
    public class ReferenciasBancariasDto
    {
        #region Primitive Properties

        public int ReferenciaBancariaId { get; set; }

        public int RegistroId { get; set; }

        public int BancoId { get; set; }

        public DateTime FechaModificacion { get; set; }

        public string NombreBanco { get; set; }

        #endregion

        public ReferenciasBancariasDto()
        {

        }

        public ReferenciasBancariasDto(ReferenciasBancarias entity)
        {
            this.ReferenciaBancariaId = entity.ReferenciaBancariaId;
            this.RegistroId = entity.RegistroId;
            this.BancoId = entity.BancoId;
            this.FechaModificacion = entity.FechaModificacion;

            this.NombreBanco = !String.IsNullOrEmpty(entity.NombreBanco)
                                   ? entity.NombreBanco
                                   : String.Empty;
        }
    }
    public class ReferenciasComercialesDto
    {
        #region Primitive Properties

        public int ReferenciaComercialId { get; set; }

        public int RegistroId { get; set; }

        public string TipoReferencia { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaModificacion { get; set; }

        #endregion

        public ReferenciasComercialesDto()
        {

        }

        public ReferenciasComercialesDto(ReferenciasComerciales entity)
        {
            this.ReferenciaComercialId = entity.ReferenciaComercialId;
            this.RegistroId = entity.RegistroId;
            this.TipoReferencia = entity.TipoReferencia;
            this.Descripcion = entity.Descripcion;
            this.FechaModificacion = entity.FechaModificacion;
        }
    }
    public class RegistrosActividadesDto
    {
        #region Primitive Properties

        public int AtividadId { get; set; }

        public int RegistroId { get; set; }

        public int TipoActividadId { get; set; }

        public DateTime FechaModificacion { get; set; }

        public string Descripcion { get; set; }

        public string CodigoCIIU { get; set; }

        #endregion

        public RegistrosActividadesDto(RegistrosActividades entity)
        {
            this.AtividadId = entity.AtividadId;
            this.RegistroId = entity.RegistroId;
            this.TipoActividadId = entity.TipoActividadId;
            this.FechaModificacion = entity.FechaModificacion;
            this.Descripcion = String.Empty;
            this.CodigoCIIU = entity.CodigoCIIU;
        }

        public RegistrosActividadesDto()
        {

        }
    }
    public class ProductosDto
    {
        #region Primitive Properties

        public int ProductoId { get; set; }

        public string Descripcion { get; set; }

        public int RegistroId { get; set; }

        public string SistemaArmonizadoId { get; set; }

        public System.DateTime FechaModificacion { get; set; }

        #endregion

        public ProductosDto()
        {

        }

        public ProductosDto(Productos producto)
        {
            this.ProductoId = producto.ProductoId;
            this.Descripcion = producto.Descripcion;
            this.RegistroId = producto.RegistroId;
            this.SistemaArmonizadoId = producto.SistemaArmonizadoId;
            this.FechaModificacion = producto.FechaModificacion;
        }

    }
    public class SociosDto
    {
        #region Primitive Properties

        public int Id
        {
            get;
            set;
        }

        public int RegistroId
        {
            get;
            set;
        }

        public string TipoSocio
        {
            get;
            set;
        }

        public string TipoRelacion
        {
            get;
            set;
        }

        public int? CargoId
        {
            get;
            set;
        }

        public string TipoDocumento
        {
            get;
            set;
        }

        public string Documento
        {
            get;
            set;
        }

        public int? NacionalidadId
        {
            get;
            set;
        }

        public string RegistroMercantil
        {
            get;
            set;
        }

        public int Orden
        {
            get;
            set;
        }

        public string SociedadNombreSocial
        {
            get;
            set;
        }

        public string PersonaPrimerNombre
        {
            get;
            set;
        }

        public string PersonaSegundoNombre
        {
            get;
            set;
        }

        public string PersonaPrimerApellido
        {
            get;
            set;
        }

        public string PersonaSegundoApellido
        {
            get;
            set;
        }

        public string PersonaEstadoCivil
        {
            get;
            set;
        }

        public int? PersonaProfesionId
        {
            get;
            set;
        }

        public string DireccionCalle
        {
            get;
            set;
        }

        public string DireccionNumero
        {
            get;
            set;
        }

        public int? DireccionCiudadId
        {
            get;
            set;
        }

        public int? DireccionSectorId
        {
            get;
            set;
        }

        public string DireccionApartadoPostal
        {
            get;
            set;
        }

        public int? CantidadAcciones { get; set; }

        public PersonasDto Representante { get; set; }

        public string Telefono1 { get; set; }

        public string Telefono2 { get; set; }

        public string Email { get; set; }

        public int? SrmId { get; set; }

        #endregion

        public SociosDto()
        {

        }

        public SociosDto(Socios entity)
        {
            this.Id = entity.Id;
            this.RegistroId = entity.RegistroId;
            this.TipoSocio = entity.TipoSocio;
            this.TipoRelacion = entity.TipoRelacion;
            this.CargoId = entity.CargoId;
            this.TipoDocumento = entity.TipoDocumento;
            this.Documento = entity.Documento;
            this.NacionalidadId = entity.NacionalidadId;
            this.RegistroMercantil = entity.RegistroMercantil;
            this.Orden = entity.Orden;
            this.SociedadNombreSocial = entity.SociedadNombreSocial;
            this.PersonaPrimerNombre = entity.PersonaPrimerNombre;
            this.PersonaSegundoNombre = entity.PersonaSegundoNombre;
            this.PersonaPrimerApellido = entity.PersonaPrimerApellido;
            this.PersonaSegundoApellido = entity.PersonaSegundoApellido;
            this.PersonaEstadoCivil = entity.PersonaEstadoCivil;
            this.PersonaProfesionId = entity.PersonaProfesionId;
            this.DireccionCalle = entity.DireccionCalle;
            this.DireccionNumero = entity.DireccionNumero;
            this.DireccionCiudadId = entity.DireccionCiudadId;
            this.DireccionSectorId = entity.DireccionSectorId;
            this.DireccionApartadoPostal = entity.DireccionApartadoPostal;
            this.CantidadAcciones = entity.CantidadAcciones;
            this.Telefono1 = entity.Telefono1;
            this.Telefono2 = entity.Telefono2;
            this.Email = entity.CorreoElectronico;
            this.SrmId = entity.SrmId;

            if (entity.Personas != null)
                this.Representante = new PersonasDto(entity.Personas);
        }
    }
    public class PersonasDto
    {
        #region Primitive Properties

        public int PersonaId
        {
            get;
            set;
        }

        public int RegistroId
        {
            get;
            set;
        }

        public string TipoDocumento
        {
            get;
            set;
        }

        public string Documento
        {
            get;
            set;
        }

        public string PrimerNombre
        {
            get;
            set;
        }

        public string SegundoNombre
        {
            get;
            set;
        }

        public string PrimerApellido
        {
            get;
            set;
        }

        public string SegundoApellido
        {
            get;
            set;
        }

        public string Rnc
        {
            get;
            set;
        }

        public int? NacionalidadId
        {
            get;
            set;
        }

        public string EstadoCivil
        {
            get;
            set;
        }

        public int? ProfesionId
        {
            get;
            set;
        }

        public string DireccionCalle
        {
            get;
            set;
        }

        public string DireccionNumero
        {
            get;
            set;
        }

        public int? DireccionCiudadId
        {
            get;
            set;
        }

        public int? DireccionSectorId
        {
            get;
            set;
        }

        public string DireccionApartadoPostal
        {
            get;
            set;
        }

        #endregion


        public PersonasDto()
        {

        }

        public PersonasDto(Personas entity)
        {
            this.PersonaId = entity.PersonaId;
            this.RegistroId = entity.RegistroId;
            this.TipoDocumento = entity.TipoDocumento;
            this.Documento = entity.Documento;
            this.PrimerNombre = entity.PrimerNombre;
            this.SegundoNombre = entity.SegundoNombre;
            this.PrimerApellido = entity.PrimerApellido;
            this.SegundoApellido = entity.SegundoApellido;
            this.Rnc = entity.Rnc;
            this.NacionalidadId = entity.NacionalidadId;
            this.EstadoCivil = entity.EstadoCivil;
            this.ProfesionId = entity.ProfesionId;
            this.DireccionCalle = entity.DireccionCalle;
            this.DireccionNumero = entity.DireccionNumero;
            this.DireccionCiudadId = entity.DireccionCiudadId;
            this.DireccionSectorId = entity.DireccionSectorId;
            this.DireccionApartadoPostal = entity.DireccionApartadoPostal;
        }

    }
    public class FacturaDto
    {
        #region Properties
        public int FacturaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Ncf { get; set; }
        public string Usuario { get; set; }
        public int Estado { get; set; }
        public bool Complementaria { get; set; }
        public string TipoNcf { get; set; }
        public decimal TotalFactura { get; set; }
        public int FacturaSrmId { get; set; }
        public string CamaraId { get; set; }
        #endregion

        /// <summary>
        /// Constructor por Defecto
        /// </summary>
        public FacturaDto()
        { }

        /// <summary>
        /// Constructor a partir de un objeto del Entity Framework
        /// </summary>
        /// <param name="entity"></param>
        public FacturaDto(Facturas entity)
        {
            //Si la factura existe se inicializa
            if (entity == null) return;

            this.FacturaId = entity.FacturaId;
            this.Fecha = entity.Fecha;
            this.Ncf = entity.Ncf;
            this.Usuario = entity.Usuario;
            this.Estado = entity.Estado;
            this.Complementaria = entity.Complementaria;
            this.TipoNcf = entity.TipoNcf;
            this.TotalFactura = entity.TotalFactura;
            this.FacturaSrmId = entity.FacturaSrmId;
            this.CamaraId = entity.CamaraId;
        }
    }

    public class TransaccionDetalleDto
    {
        public TransaccionDetalleDto()
        {

        }
        public TransaccionDetalleDto(TransaccionDetalle entity)
        {
            if (entity == null) return;

            this.Cantidad = entity.Cantidad;
            this.Cuenta = entity.Cuenta;
            this.Descuento = entity.Descuento;
            this.Detalle = entity.Detalle;
            this.FacturaId = entity.FacturaId;
            this.PrecioUnitario = entity.PrecioUnitario;
            this.Total = entity.Total;
            this.TotalBruto = entity.TotalBruto;
        }

        #region Primitive Properties

        public virtual int TransaccionDetalles
        {
            get;
            set;
        }

        public virtual string Cuenta
        {
            get;
            set;
        }

        public virtual string Detalle
        {
            get;
            set;
        }

        public virtual int Cantidad
        {
            get;
            set;
        }

        public virtual decimal PrecioUnitario
        {
            get;
            set;
        }

        public virtual decimal Descuento
        {
            get;
            set;
        }

        public virtual decimal? Total
        {
            get;
            set;
        }

        public virtual decimal? TotalBruto
        {
            get;
            set;
        }

        public virtual int FacturaId
        {
            get { return _facturaId; }
            set { _facturaId = value; }
        }
        private int _facturaId;

        #endregion

    }

}
