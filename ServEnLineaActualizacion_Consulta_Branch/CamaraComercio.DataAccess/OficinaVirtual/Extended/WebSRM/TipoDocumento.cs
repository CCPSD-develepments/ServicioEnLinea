using System.Collections.Generic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public class TipoDocumento : CharEnum
    {
        public TipoDocumento(char value, string text) : base(value, text)
        {
        }

        public static List<TipoDocumento> FetchAll()
        {
            List<TipoDocumento> socios = new List<TipoDocumento>
                                             {
                                                 new TipoDocumento('C', "Cedula"),
                                                 new TipoDocumento('P', "Pasaporte"),
                                                 new TipoDocumento('R', "Rnc")
                                             };
            return socios;
        }
    }
}