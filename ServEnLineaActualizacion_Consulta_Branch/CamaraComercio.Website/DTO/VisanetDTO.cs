using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamaraComercio.Website.DTO
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VisanetDTO'
    public class VisanetDTO
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VisanetDTO'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VisanetDTO.MerchantKey'
        public String MerchantKey { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VisanetDTO.MerchantKey'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VisanetDTO.OrderID'
        public int OrderID { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VisanetDTO.OrderID'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VisanetDTO.Amount'
        public float Amount { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VisanetDTO.Amount'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VisanetDTO.Currency'
        public int Currency { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VisanetDTO.Currency'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VisanetDTO.Tarjeta'
        public String Tarjeta { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VisanetDTO.Tarjeta'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VisanetDTO.AuthCode'
        public String AuthCode { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VisanetDTO.AuthCode'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VisanetDTO.ReferenceCode'
        public String ReferenceCode { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VisanetDTO.ReferenceCode'
    }
}