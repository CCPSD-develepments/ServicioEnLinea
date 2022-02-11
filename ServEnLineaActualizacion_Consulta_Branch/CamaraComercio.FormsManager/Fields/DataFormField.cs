using System;
using System.Xml.Serialization;

namespace CamaraComercio.FormsManager.Fields
{
    [Serializable]
    [XmlRoot("field")]
    public class DataFormField
    {
        private DataFormFieldType m_fieldType;
        private string m_id;
        private bool m_isMandatory = true;
        private int m_maxInstances;
        private string m_name;
        private string m_value;
        private DataFormFieldValueCollection m_Values;
        private string m_controlSRM; //agregado para el mapeo de SRM con Website.

        protected DataFormField()
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="DataFormField"/> class.
        /// </summary>
        /// <param name="id">The id of the field.</param>
        /// <param name="name">The name of the field.</param>
        /// <param name="fieldType">Type of the field.</param>
        public DataFormField(string id, string name, DataFormFieldType fieldType)
        {
            m_id = id;
            m_name = name;
            m_fieldType = fieldType;
            m_maxInstances = 1;
            m_isMandatory = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataFormField"/> class.
        /// </summary>
        /// <param name="fieldType">Type of the field.</param>
        /// <param name="id">The id of the field.</param>
        /// <param name="isMandatory">if set to <c>true</c> the field is mandatory.</param>
        /// <param name="maxInstances">The max possible instances of this field in a form.</param>
        /// <param name="name">The name of the field.</param>
        public DataFormField(string id, string name, string SRM, DataFormFieldType fieldType, bool isMandatory, int maxInstances)
        {
            m_fieldType = fieldType;
            m_id = id;
            m_name = name;
            m_isMandatory = isMandatory;
            m_maxInstances = maxInstances;
            IsNumber = false;
            this.m_controlSRM = SRM;
        }

        /// <summary>
        /// Gets or sets the type of the field.
        /// </summary>
        /// <value>The type of the field.</value>
        [XmlAttribute("fieldType")]
        public virtual DataFormFieldType FieldType
        {
            get { return m_fieldType; }
            set { m_fieldType = value; }
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [XmlAttribute("id")]
        public string Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this field is mandatory.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this field is mandatory; otherwise, <c>false</c>.
        /// </value>
        [XmlAttribute("isMandatory")]
        public bool IsMandatory
        {
            get { return m_isMandatory; }
            set { m_isMandatory = value; }
        }

        /// <summary>
        /// Gets or sets the max number of instances of this field.
        /// </summary>
        /// <value>The max instances.</value>
        [XmlAttribute("maxInstances")]
        public int MaxInstances
        {
            get
            {
                //HACK: Always return 1 as the max instance, until problem is solved with multi instance support
                //return m_maxInstances;
                return 1;
            }
            set { m_maxInstances = value; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [XmlElement("name")]
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        [XmlArray("values", IsNullable = true)]
        [XmlArrayItem("value", typeof (DataFormFieldValue))]
        public DataFormFieldValueCollection Values
        {
            get { return m_Values; }
            set { m_Values = value; }
        }

        /// <summary>
        /// Gets or Sets Wheather the field is numeric or not.
        /// </summary>
        [XmlElement("isNumber")]
        public bool IsNumber { get; set; }

        /// <summary>
        /// Gets or Sets the value for SRM Control.
        /// </summary>
        [XmlAttribute("controlSRM")]
        public string ControlSRM
        {
            get { return m_controlSRM; }
            set { m_controlSRM = value; }
        }
    }
}