using System;
using System.Collections.Generic;
using System.Web.Services;

namespace CamaraComercio.WebServices.Servicios
{
    /// <summary>
    /// Describe los servicios registrados en el sistema de gestión
    /// </summary>
    public class Servicio
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        /// <summary>
        /// Optienes o establece la fecha de la transacción
        /// </summary>
        /// <value>Tipo <see cref="DateTime"/>.</value>
        public DateTime Fecha { get; set; }
        /// <summary>
        /// Obtienes o estableces la relación del registro.
        /// </summary>
        /// <value>Tipo <see cref="Guid"/>.</value>
        public Guid CgControl { get; set; }
        /// <summary>
        /// Obtienes o estableces el Id del registro.
        /// </summary>
        /// <value>Tipo <see cref="Guid"/>.</value>
        public Guid IdReg { get; set; }
        public string Contacto { get; set; }
        public string Cliente { get; set; }
        public string Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public decimal TotalBruto { get; set; }
        public decimal TotalFactura { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal TotalPagar { get; set; }
        public int TransaccionId { get; set; }

    }

    public interface IServicioHandler
    {
        List<Servicio> ObtenerListadoServicios();
    }

    /// <summary>
    /// Obtiene un mockup de servicios
    /// </summary>
    [WebService(Namespace = "http://www.registromercantil.org.do")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // [System.Web.Script.Services.ScriptService]
    public class MockServicioHandler : WebService, IServicioHandler
    {
        [WebMethod(Description = "Clase que maneja la obtención del listado de servicios de prueba")]
        public List<Servicio> ObtenerListadoServicios()
        {
            var servicios = new List<Servicio>
                                           {
                                                new Servicio {Codigo = "1001", Descripcion = "Nuevo Registro Mercantil"},
                                                new Servicio {Codigo = "1002", Descripcion = "Renovación Simple Registro Mercantil"},
                                                new Servicio {Codigo = "1003", Descripcion = "Renovación con Cambios"},
                                                new Servicio {Codigo = "1004", Descripcion = "Adecuación de Empresa"}
                                           };
            return servicios;
        }
    }

    /// <summary>
    /// Clase que maneja la obtención del listado de servicios desde el sistema de gestión
    /// </summary>
    [WebService(Namespace = "http://www.registromercantil.org.do")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // [System.Web.Script.Services.ScriptService]
    public class SistemaGestionServicioHandler : WebService, IServicioHandler
    {
        [WebMethod(Description = "Clase que maneja la obtención del listado de servicios desde el sistema de gestión")]
        public List<Servicio> ObtenerListadoServicios()
        {
            throw new NotImplementedException();
        }
    }
}