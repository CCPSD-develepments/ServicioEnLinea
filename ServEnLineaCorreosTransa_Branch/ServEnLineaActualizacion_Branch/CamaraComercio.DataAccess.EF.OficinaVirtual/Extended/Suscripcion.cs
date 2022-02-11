using System;
using System.Collections.Generic;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    /// <summary>
    /// Define los tipos de suscripci�n para las empresas an�nimas (p�blicas o privadas). 
    /// Esta denominaci�n no es utilizada en la nueva ley de sociedades
    /// </summary>
    [Obsolete("Propiedad no utilizada en la nueva ley")]
    public class Suscripcion
    {
        /// <summary>
        /// Identificador para empresas p�blicas
        /// </summary>
        public const string Publica = "PU";

        /// <summary>
        /// Identificador para empresas privadas
        /// </summary>
        public const string Privada = "PA";

        /// <summary>
        /// Valor de la propiedad
        /// </summary>
        public string Value { get; set; }
        
        /// <summary>
        /// Texto de la propiedad
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        /// <param name="value"></param>
        /// <param name="text"></param>
        public Suscripcion(string value, string text)
        {
            Value = value;
            Text = text;
        }

        /// <summary>
        /// Retorna un listado con todos los tipos de suscripci�n
        /// </summary>
        /// <returns></returns>
        public static List<Suscripcion> FetchAll()
        {
            return new List<Suscripcion>
                       {
                           new Suscripcion("PA", "Privada"),
                           new Suscripcion("PU", "Publica")
                       };
        }
    }
}