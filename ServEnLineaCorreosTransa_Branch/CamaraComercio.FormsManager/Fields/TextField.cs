using System;
using System.Xml.Serialization;

namespace CamaraComercio.FormsManager.Fields
{
    [Serializable]
    [XmlRoot("field")]
    public class TextField : DataFormField
    {
        private int m_maxLength = int.MaxValue;

        protected TextField()
        {
        }

        public TextField(string id, string name, string SRM, bool isMandatory, bool isNumber, int maxInstances, int maxLength)
            : base(id, name, SRM, DataFormFieldType.Text, isMandatory, maxInstances)
        {
            MaxLength = maxLength;
            IsNumber = isNumber;
           
        }

        /// <summary>
        /// Gets or sets the Maximum length of the field's value.
        /// </summary>
        /// <value>The length of the max.</value>
        [XmlAttribute("maxLength")]
        public int MaxLength
        {
            get { return m_maxLength; }
            set { m_maxLength = value; }
        }

    }
}