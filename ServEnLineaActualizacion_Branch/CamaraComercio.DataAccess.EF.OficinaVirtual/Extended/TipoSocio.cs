using System.Collections.Generic;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    /// <summary>
    /// Enumeración, tipo de personas
    /// </summary>
    public class TipoSocio : CharEnum
    {
        public const char Persona = 'P';
        public const char Sociedad = 'S';

        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        /// <param name="value"></param>
        /// <param name="text"></param>
        public TipoSocio(char value, string text)
            : base(value, text)
        {
        }

        /// <summary>
        /// Obtiene un listado de los tipos de personas
        /// </summary>
        public static List<TipoSocio> FetchAll()
        {
            var socios = new List<TipoSocio>
                                         {
                                             new TipoSocio('P', "Persona"),
                                             new TipoSocio('S', "Sociedad")
                                         };
            return socios;
        }
    }
}