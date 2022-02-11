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
        /// Valor de la enumeración
        /// </summary>
        public char Value { get; set; }
        
        /// <summary>
        /// Texto (descripción) de la enumeración
        /// </summary>
        public string Text { get; set; }
    }
}