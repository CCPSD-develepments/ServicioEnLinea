using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuloPago
{
    public class VisanetResponseDTO
    {
        public String MerchantKey { get; set; }
        public int OrderID { get; set; }
        public float Amount { get; set; }
        public int Currency { get; set; }
        public String Tarjeta { get; set; }
        public String AuthCode { get; set; }
        public String ReferenceCode { get; set; }
    }
}