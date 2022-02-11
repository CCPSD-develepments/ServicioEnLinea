using System;
using System.Xml.Serialization;

namespace CamaraComercio.FormsManager.Fields
{
    [Serializable]
    public class CheckboxField : DataFormField
    {
        private string m_defaultValue;
        private bool m_isChecked = false;

        protected CheckboxField()
        {
        }

        public CheckboxField(string id, string name, string SRM, string defaultValue, bool checkedByDefault)
            : base(id, name, SRM, DataFormFieldType.Check, false, 1)
        {
            m_defaultValue = defaultValue;
            IsChecked = checkedByDefault;
        }

        [XmlAttribute("isChecked")]
        public bool IsChecked
        {
            get { return m_isChecked; }
            set { m_isChecked = value; }
        }

        [XmlElement("defaultValue")]
        public string DefaultValue
        {
            get { return m_defaultValue; }
            set { m_defaultValue = value; }
        }
    }
}