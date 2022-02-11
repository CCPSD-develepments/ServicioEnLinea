using System.Collections.Generic;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    /// <summary>
    /// Enumeración tipo Char
    /// </summary>
    public class EstadoCivil : CharEnum
    {
        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        /// <param name="value"></param>
        /// <param name="text"></param>
        public EstadoCivil(char value, string text) : base(value, text)
        {
        }

        /// <summary>
        /// Posibles Estados Civiles
        /// </summary>
        /// <returns></returns>
        public static List<EstadoCivil> FetchAll()
        {
            var socios = new List<EstadoCivil>
                                           {
                                               new EstadoCivil('C', "Casado"),
                                               new EstadoCivil('S', "Soltero"),
                                           };
            return socios;
        }
    }
}