using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ModuloPago
{
    public enum EnumSystemType
    {
        [Description("Camara Online")]
        CamaraOnline = 1,
        [Description("Ventanilla Unica")]
        VentanillaUnica = 2,
        [Description("Ronda de Negocio")]
        RondaNegocio = 3

    }

    public enum EnumCreditCardType
    {
        [Description("Visa")]
        Visa = 0,
        [Description("Master Card")]
        MasterCard = 1,
        [Description("Discover")]
        Discover = 2,
        [Description("American Express")]
        Amex = 3,
    }
}