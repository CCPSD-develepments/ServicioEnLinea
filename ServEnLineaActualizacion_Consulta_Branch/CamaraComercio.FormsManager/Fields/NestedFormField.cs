using System;
using System.Xml.Serialization;

namespace CamaraComercio.FormsManager.Fields
{
    [Serializable]
    public class NestedFormField : DataFormField
    {
        private DataForm m_nestedForm;


        protected NestedFormField()
        {
        }

        public NestedFormField(string id, string name, string SRM, DataForm nestedForm, bool isMandatory, int maxInstances)
            : base(id, name, SRM, DataFormFieldType.NestedForm, isMandatory, maxInstances)
        {
            m_nestedForm = nestedForm;
        }

        /// <summary>
        /// Gets or sets the nested form.
        /// </summary>
        /// <value>The nested form.</value>
        [XmlElement("form", typeof (DataForm), IsNullable = true)]
        public DataForm NestedForm
        {
            get { return m_nestedForm; }
            set { m_nestedForm = value; }
        }
    }
}