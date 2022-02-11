using System.Collections.Generic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public class TipoRelacionSocio : CharEnum
    {
        public const char Accionista = 'A';
        public const char Consejo_de_Administracion = 'C';
        public const char Consejo_de_Accionistas = 'C';
        public const char Firma_Autorizada = 'F';
        public const char Comisario_de_Cuenta = 'O';

        public TipoRelacionSocio(char value, string text) : base(value, text)
        {
        }

        public static List<TipoRelacionSocio> FetchAll()
        {
            List<TipoRelacionSocio> socios = new List<TipoRelacionSocio>
                                                 {
                                                     new TipoRelacionSocio('A', "Accionista"),
                                                     new TipoRelacionSocio('C', "Consejo de Administracion"),
                                                     new TipoRelacionSocio('F', "Firma Autorizada"),
                                                     new TipoRelacionSocio('O', "Comisario de Cuenta"),
                                                 };
            return socios;
        }
    }
}