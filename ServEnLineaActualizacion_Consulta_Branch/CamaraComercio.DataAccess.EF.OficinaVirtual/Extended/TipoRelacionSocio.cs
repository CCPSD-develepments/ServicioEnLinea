using System.Collections.Generic;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    public class TipoRelacionSocio : CharEnum
    {
        public const char Accionista = 'A';
        public const char Consejo_de_Administracion = 'C';
        public const char Consejo_de_Accionistas = 'C';
        public const char Firma_Autorizada = 'F';
        public const char Comisario_de_Cuenta = 'O';

        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        /// <param name="value"></param>
        /// <param name="text"></param>
        public TipoRelacionSocio(char value, string text) : base(value, text)
        {
        }

        /// <summary>
        /// Retorna todos los tipos de relación para un socio
        /// </summary>
        /// <returns></returns>
        public static List<TipoRelacionSocio> FetchAll()
        {
            var socios = new List<TipoRelacionSocio>
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