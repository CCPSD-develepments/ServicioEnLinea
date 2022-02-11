using System;
using System.Xml.Serialization;

namespace CamaraComercio.FormsManager.Fields
{
    [Serializable]
    [XmlRoot("fieldType")]
    public enum DataFormFieldType
    {
        Text = 1,
        Check = 2,
        DropDown = 3,
        NestedForm = 6
    }
}