using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamaraComercio.Website.DTO
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ServicioDTO'
    public class ServicioDTO
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ServicioDTO'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ServicioDTO.ServicioId'
        public int ServicioId { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ServicioDTO.ServicioId'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ServicioDTO.Descripcion'
        public string Descripcion { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ServicioDTO.Descripcion'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ServicioDTO.Cuenta'
        public string Cuenta { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ServicioDTO.Cuenta'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ServicioDTO.bFactura'
        public bool bFactura { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ServicioDTO.bFactura'
    }
}