using System;
using System.Xml.Serialization;

namespace CamaraComercio.FormsManager.Fields
{
    [Serializable]
    public class DropDownField : DataFormField
    {
        private DropDownFieldOptionCollection m_Options = new DropDownFieldOptionCollection();

        public DropDownField(string id, string name, string SRM, bool isMandatory, int maxInstances)
            : base(id, name, SRM, DataFormFieldType.DropDown, isMandatory, maxInstances)
        {
        }

        protected DropDownField()
        {
        }

        [XmlAttribute("fieldType")]
        public new DataFormFieldType FieldType
        {
            get { return base.FieldType; }
            set { base.FieldType = value; }
        }

        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        /// <value>The options.</value>
        [XmlArray("options")]
        [XmlArrayItem("option", typeof(DropDownFieldOption))]
        public DropDownFieldOptionCollection Options
        {
            get { return m_Options; }
            set { m_Options = value; }
        }
    }
}