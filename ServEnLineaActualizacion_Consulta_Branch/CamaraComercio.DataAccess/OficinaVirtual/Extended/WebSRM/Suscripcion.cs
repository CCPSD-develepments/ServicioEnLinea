using System.Collections.Generic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public class Suscripcion
    {
        public const string Publica = "PU";
        public const string Privada = "PA";

        public string Value { get; set; }
        public string Text { get; set; }

        public Suscripcion(string value, string text)
        {
            Value = value;
            Text = text;
        }

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