using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using CamaraComercio.FormsManager.Fields;

namespace CamaraComercio.FormsManager
{
    /// <summary>
    /// Represents a Data Form
    /// </summary>
    [Serializable]
    [XmlRoot("dataForm")]
    public sealed class DataForm
    {
        private string m_id;
        private bool m_isEmpty;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataForm"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="instructions">The instructions.</param>
        /// <param name="isEmpty">if set to <c>true</c> the form step is empty.</param>
        public DataForm(string title, string description, string instructions)
        {
            Fields = new Collection<DataFormField>();
            Title = title;
            Description = description;
            Instructions = instructions;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [XmlElement("title")]
        protected string Title { get; set; }

        private DataForm()
        {
            Fields = new Collection<DataFormField>();
        }


        public string Name
        {
            get { return Regex.Replace(Title, @"[^A-Za-z0-9]", string.Empty); }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the instructions.
        /// </summary>
        /// <value>The instructions.</value>
        [XmlElement("instructions")]
        public string Instructions { get; set; }

        /// <summary>
        /// Gets or sets the fields.
        /// </summary>
        /// <value>The fields.</value>
        [XmlArray("fields"), XmlArrayItem("field", typeof(DataFormField)), XmlArrayItem(typeof(TextField)), XmlArrayItem(typeof(DropDownField)), XmlArrayItem(typeof(NestedFormField)), XmlArrayItem(typeof(CheckboxField))]
        public Collection<DataFormField> Fields { get; set; }

        public string ToXml()
        {
            XmlSerializer xmls = new XmlSerializer(GetType());
            using (StringWriter sw = new StringWriter(new StringBuilder()))
            {
                xmls.Serialize(sw, this);
                return sw.GetStringBuilder().ToString();
            }
        }

        public static DataForm FromXml(string xmlDefinition)
        {
            XmlSerializer xmls = new XmlSerializer(typeof(DataForm));
            using (StringReader sr = new StringReader(xmlDefinition))
            {
                return (DataForm)xmls.Deserialize(sr);
            }
        }
    }
}