namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public class CharEnum
    {
        public CharEnum(char value, string text)
        {
            Value = value;
            Text = text;
        }

        public char Value { get; set; }
        public string Text { get; set; }
    }
}