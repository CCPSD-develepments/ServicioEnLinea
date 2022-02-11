using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamaraComercio.Website.DTO.ONAPI
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOnapi'
    public class SolicitudOnapi
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOnapi'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOnapi.Representante'
        public Persona Representante;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOnapi.Representante'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOnapi.Solicitante'
        public Persona Solicitante;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOnapi.Solicitante'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOnapi.DenominacionDeSigno'
        public string DenominacionDeSigno;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOnapi.DenominacionDeSigno'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOnapi.ActividadesProtegidas'
        public string ActividadesProtegidas;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOnapi.ActividadesProtegidas'
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Persona'
    public class Persona
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Persona'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Persona.Nombre'
        public string Nombre { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Persona.Nombre'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Persona.Apellidos'
        public string Apellidos { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Persona.Apellidos'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Persona.Cedula'
        public string Cedula { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Persona.Cedula'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Persona.TipoIdentificacion'
        public string TipoIdentificacion { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Persona.TipoIdentificacion'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Persona.Nacionalidad'
        public string Nacionalidad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Persona.Nacionalidad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Persona.Docimilio'
        public string Docimilio { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Persona.Docimilio'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Persona.Numero'
        public string Numero { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Persona.Numero'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Persona.Sector'
        public string Sector { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Persona.Sector'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Persona.CodigoPostal'
        public string CodigoPostal { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Persona.CodigoPostal'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Persona.Ciudad'
        public string Ciudad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Persona.Ciudad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Persona.Provincia'
        public string Provincia { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Persona.Provincia'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Persona.Pais'
        public string Pais { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Persona.Pais'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Persona.Telefono'
        public string Telefono { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Persona.Telefono'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Persona.Fax'
        public string Fax { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Persona.Fax'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Persona.Email'
        public string Email { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Persona.Email'
    }

}