using System;

namespace CamaraComercio.Website.DTO
{

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DetalleServicio'
    public class DetalleServicio
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DetalleServicio'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DetalleServicio.Descripcion'
        public String Descripcion { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DetalleServicio.Descripcion'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DetalleServicio.Cantidad'
        public int Cantidad { get; set; } = 1;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DetalleServicio.Cantidad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DetalleServicio.Costo'
        public decimal Costo { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DetalleServicio.Costo'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DetalleServicio.CostoTotal'
        public decimal CostoTotal { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DetalleServicio.CostoTotal'
    }
}