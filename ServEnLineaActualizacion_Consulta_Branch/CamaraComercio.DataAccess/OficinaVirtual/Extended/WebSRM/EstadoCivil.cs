using System.Collections.Generic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public class EstadoCivil : CharEnum
    {
        public EstadoCivil(char value, string text) : base(value, text)
        {
        }

        public static List<EstadoCivil> FetchAll()
        {
            List<EstadoCivil> socios = new List<EstadoCivil>
                                           {
                                               new EstadoCivil('C', "Casado"),
                                               new EstadoCivil('S', "Soltero"),
                                               new EstadoCivil('X', "Investigar este valor")
                                           };
            return socios;
        }
    }
}