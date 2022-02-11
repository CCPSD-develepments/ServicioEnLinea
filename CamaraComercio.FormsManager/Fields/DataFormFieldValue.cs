using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CamaraComercio.FormsManager.Fields
{
    [Serializable]
    [XmlRoot("value")]
    [DebuggerDisplay("name = {m_fieldId}, value = {m_Contents}, innerValues = {m_innerValues.Count}")]
    public class DataFormFieldValue
    {
        private string m_Contents;
        private string m_fieldId;

        protected DataFormFieldValue()
        {
        }

        public DataFormFieldValue(string fieldId, string value)
        {
            m_fieldId = fieldId;
            m_Contents = value;
        }

        [XmlAttribute("contents")]
        public string Contents
        {
            get { return m_Contents; }
            set { m_Contents = value; }
        }

        [XmlAttribute("fieldId")]
        public string FieldId
        {
            get { return m_fieldId; }
            set { m_fieldId = value; }
        }
    }
}