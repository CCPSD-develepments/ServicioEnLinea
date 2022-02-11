using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamaraComercio.Website.DTO
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ActividadDTO'
    public class ActividadDTO
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ActividadDTO'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ActividadDTO.ID'
        public int? ID { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ActividadDTO.ID'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ActividadDTO.CodigoCIIU'
        public string CodigoCIIU { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ActividadDTO.CodigoCIIU'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ActividadDTO.PadreID'
        public int? PadreID { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ActividadDTO.PadreID'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ActividadDTO.Descripcion'
        public string Descripcion { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ActividadDTO.Descripcion'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ActividadDTO.DescripcionLarga'
        public string DescripcionLarga { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ActividadDTO.DescripcionLarga'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ActividadDTO.RecibeAccion'
        public bool? RecibeAccion { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ActividadDTO.RecibeAccion'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ActividadDTO.TieneHijos'
        public bool? TieneHijos { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ActividadDTO.TieneHijos'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ActividadDTO.ActividadesHijas'
        public List<ActividadDTO> ActividadesHijas { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ActividadDTO.ActividadesHijas'

    }
}