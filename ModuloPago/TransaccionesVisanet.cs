//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModuloPago
{
    using System;
    using System.Collections.Generic;
    
    public partial class TransaccionesVisanet
    {
        public int Id { get; set; }
        public int SistemaId { get; set; }
        public string MerchantKey { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<int> Currency { get; set; }
        public string Tarjeta { get; set; }
        public string AuthCode { get; set; }
        public string ReferenceCode { get; set; }
        public Nullable<System.DateTime> FechaTransaccion { get; set; }
    
        public virtual Sistema Sistema { get; set; }
    }
}
