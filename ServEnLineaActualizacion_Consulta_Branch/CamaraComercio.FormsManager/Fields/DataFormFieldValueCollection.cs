using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace CamaraComercio.FormsManager.Fields
{
    [XmlRoot("instances")]
    public class DataFormFieldValueCollection : Collection<DataFormFieldValue>
    {
        [XmlAttribute("count")]
        public new int Count
        {
            get { return base.Count; }
        }
    }
}