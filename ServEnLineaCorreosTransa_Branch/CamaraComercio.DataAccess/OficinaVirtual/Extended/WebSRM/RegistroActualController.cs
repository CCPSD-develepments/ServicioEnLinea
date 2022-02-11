using System;
using System.ComponentModel;
using SubSonic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public partial class RegistroActualController
    {
        /// <summary>
        /// Obtiene los datos actuales de una empresa 
        /// </summary>
        /// <param name="noRegistroMercantil">Numero del registro mercantil</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public RegistroActual FecthByRegistroMercantil(int noRegistroMercantil)
        {
            RegistroActual regActual = null;
            try
            {
                regActual = new Select().From<RegistroActual>().
                    Where("NumeroRegistro").IsEqualTo(noRegistroMercantil).ExecuteSingle<RegistroActual>();
            }
            catch (Exception)
            {
            }
            return regActual;
        }
    }
}