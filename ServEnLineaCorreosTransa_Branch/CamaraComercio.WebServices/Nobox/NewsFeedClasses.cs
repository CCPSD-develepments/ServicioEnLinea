using System;

namespace CamaraComercio.WebServices.Nobox
{

    /// <summary>
    /// Representa información básica sobre una empresa/sociedad
    /// </summary>
    public class SociedadDTO
    {
        public string ActividadNegocio { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string SitioWeb { get; set; }
        public DateTime? FechaInicioOperaciones { get; set; }
        public string Nacionalidad { get; set; }
        public string NombreSocial { get; set; }
        public string Siglas { get; set; }
        public string RNC { get; set; }
        public string TipoSociedad { get; set; }
    }

    /// <summary>
    /// Representa una actividad ejecutada por una empresa
    /// </summary>
    public class ActividadDTO
    {
        public DateTime Fecha { get; set; }
        public string TipoActividad { get; set; }
        public string Descripcion { get; set; }
    }

    /// <summary>
    /// Representa una Cámara de Comercio
    /// </summary>
    public class CamaraDTO
    {
        public string CamaraID { get; set; }
        public string Descripcion { get; set; }
    }
}