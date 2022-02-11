namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    /// <summary>
    /// Clase para representar enumeraciones como chars
    /// </summary>
    public class CharEnum
    {
        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        /// <param name="value">Valor</param>
        /// <param name="text">Texto</param>
        public CharEnum(char value, string text)
        {
            Value = value;
            Text = text;
        }

        /// <summary>
        /// Valor de la enumeraci�n
        /// </summary>
        public char Value { get; set; }
        
        /// <summary>
        /// Texto (descripci�n) de la enumeraci�n
        /// </summary>
        public string Text { get; set; }
    }
}