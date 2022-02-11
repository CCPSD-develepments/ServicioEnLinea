using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace CamaraComercio.FormsManager.Fields
{
    [Serializable]
    [XmlRoot("options")]
    public class DropDownFieldOptionCollection : Collection<DropDownFieldOption>
    {
        public void Add(string value)
        {
            Add(value, false);
        }

        public void Add(string value, bool selected)
        {
            Add(value, value, selected);
        }

        public void Add(string name, string value, bool selected)
        {
            Add(new DropDownFieldOption(name, value, selected));
        }
    }
}