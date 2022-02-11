using System.Collections.Generic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public class TipoSocio : CharEnum
    {
        public const char Persona = 'P';
        public const char Sociedad = 'S';

        public TipoSocio(char value, string text)
            : base(value, text)
        {
        }

        public static List<TipoSocio> FetchAll()
        {
            List<TipoSocio> socios = new List<TipoSocio>
                                         {
                                             new TipoSocio('P', "Persona"),
                                             new TipoSocio('S', "Sociedad")
                                         };
            return socios;
        }
    }
}