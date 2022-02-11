using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Xml;

namespace CamaraComercio.Website.DTO
{
    /// <summary>
    /// Clase que define los elementos de los formularios para modificaciones en el SRM. Asiste en la serializacion.
    /// </summary>
    [XmlRoot("ElementoSolcitudSrm")]
    public class SolicitudSrmXml
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudSrmXml.SolicitudSrmXml()'
        public SolicitudSrmXml()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudSrmXml.SolicitudSrmXml()'
        {
        }
    }

    [Serializable]
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'NombreControlSrm'
    public class NombreControlSrm : Attribute
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'NombreControlSrm'
    {
        private readonly string _nombre;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'NombreControlSrm.NombreControlSrm(string)'
        public NombreControlSrm(string nombre)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'NombreControlSrm.NombreControlSrm(string)'
        {
            this._nombre = nombre;
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'NombreControlSrm.Nombre'
        public string Nombre 
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'NombreControlSrm.Nombre'
        { 
            get { return this._nombre; }
        }
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ElementoSolicidSrm'
    public class ElementoSolicidSrm
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ElementoSolicidSrm'
    {
        [XmlAttribute]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ElementoSolicidSrm.NombrePropiedaSrm'
        public string NombrePropiedaSrm { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ElementoSolicidSrm.NombrePropiedaSrm'
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ElementoSrmString'
    public class ElementoSrmString: ElementoSolicidSrm
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ElementoSrmString'
    {
        [XmlText]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ElementoSrmString.Valor'
        public string Valor { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ElementoSrmString.Valor'
    }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ElementoSrmInt'
    public class ElementoSrmInt: ElementoSolicidSrm
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ElementoSrmInt'
    {
        [XmlText]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ElementoSrmInt.Valor'
        public int Valor { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ElementoSrmInt.Valor'
    }
}