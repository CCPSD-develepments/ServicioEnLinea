using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CamaraComercio.DataAccess.EF.SRM
{
    /// <summary>
    ///Define las formas de cobros en base al capital.
    /// </summary>
    public enum BaseCobro
    {
        /// <summary>
        /// Cobra las transacciones en base a la tarifa de constituciones.
        /// </summary>
        [Description("Constitución")]
        Constitucion = 0,
        /// <summary>
        /// Cobra las transacciones en base a la tarifa de modificaciones.
        /// </summary>
        [Description("Modificación")]
        Modificacion = 1,
        /// <summary>
        /// Cobra las transacciones en base a la tarifa de renovaciones.
        /// </summary>
        [Description("Renovación")]
        Renovacion = 2,
        /// <summary>
        /// Cobra las transacciones en base a la tarifa de modificaciones del nuevo aumento de capital.
        /// </summary>
        [Description("Modificación con Aumento de Capital")]
        ModificacionAumentoCapital = 3,
        /// <summary>
        /// Cobra las transacciones en base a la tarifa de renovaciones del aumento de nuevo capital.
        /// </summary>
        [Description("Renovación con Aumento de Capital")]
        RenovacionAumentoCapital = 4,
        /// <summary>
        /// Cobra las transacciones en base a la tarifa de modificaciones de la reducción de capital.
        /// </summary>
        [Description("Modificación con Reducción de Capital")]
        ModificacionReduccionCapital = 5,
        /// <summary>
        /// Cobra las transacciones en base a la tarifa de renovaciones de la redución de capital.
        /// </summary>
        [Description("Renovación con Reducción de Capital")]
        RenovacionReduccionCapital = 6
    }
}
