using System;
using System.Xml.Serialization;

namespace CamaraComercio.FormsManager
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [XmlRoot("option")]
    public sealed class DropDownFieldOption
    {
        private string m_name;
        private bool m_selected = false;
        private string m_value;


        private DropDownFieldOption()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DropDownFieldOption"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        public DropDownFieldOption(string name, string value)
            : this(name, value, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DropDownFieldOption"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="selected">if set to <c>true</c> this option will be the selected by default.</param>
        public DropDownFieldOption(string name, string value, bool selected)
        {
            m_value = value;
            m_name = name;
            m_selected = selected;
        }


        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [XmlAttribute("value")]
        public string Value
        {
            get { return m_value; }
            set { m_value = value; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [XmlAttribute("name")]
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DropDownFieldOption"/> is selected.
        /// </summary>
        /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
        [XmlAttribute("selected")]
        public bool Selected
        {
            get { return m_selected; }
            set { m_selected = value; }
        }
    }
}