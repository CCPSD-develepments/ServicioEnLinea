using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    ///<summary>
    ///</summary>
    public partial class Transacciones
    {   
        /// <summary>
        /// Obtiene el costo de un servicio
        /// </summary>
        /// <returns></returns>
        private static decimal GetCostoServicio()
        {
            return 0M;
        }

        /// <summary>
        /// Propiedad Extendida - Nombre del servicio relacionado a la transaccion
        /// </summary>
        public string NombreServicio { get; set; }

        public bool Deleted { get; set; }
    }

    /// <summary>
    /// Extensiones para transacciones
    /// </summary>
    public static class TransaccionesExtensions
    {
        /// <summary>
        /// Obtiene los ids de servicios relacionados a una transacción 
        /// </summary>
        /// <param name="tnx"></param>
        /// <returns></returns>
        public static List<int> GetServicioTransacciones(this Transacciones tnx)
        {
            var result = new List<int>();
            if (tnx != null)
            {
                result.Add(tnx.ServicioId);
                result.AddRange(tnx.SubTransacciones.Select(a => a.ServicioId).Distinct().ToList());
            }

            return result;
        }


        /// <summary>
        /// Obtiene el servicio relacionado a esta transacción 
        /// </summary>
        /// <param name="tnx"></param>
        /// <returns></returns>
        public static Transacciones GetTransaccionByServicioId(this Transacciones tnx, int servicioId)
        {
            if (tnx != null)
            {
                if (tnx.ServicioId == servicioId)
                    return tnx;
                return tnx.SubTransacciones.FirstOrDefault(a => a.ServicioId == servicioId);
            }

            return null;
        }

    }
}
