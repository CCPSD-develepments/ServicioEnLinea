using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.SRM
{
    /// <summary>
    /// Definicion de Estatus en los que puede estar una sociedad/empresa
    /// </summary>
    public enum SociedadesEstatudId
    {
        [Description("Activa")]
        Activa = 1,
        [Description("Disuelta")]
        Disuelta = 2,
        [Description("Cese Temporal")]
        CeseTemporal = 3,
        [Description("Fusionada")]
        Fusionada = 4,
        [Description("Trasladada")]
        Trasladada = 5
    }
}
