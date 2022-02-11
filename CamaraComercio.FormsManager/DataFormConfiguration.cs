using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Xml;

namespace CamaraComercio.FormsManager
{
    public class DataFormConfiguration : IConfigurationSectionHandler
    {
        #region Section Handler Implementation

        public object Create(object parent, object configContext, XmlNode section)
        {
            //Website Url
            WebsiteUrl = string.Format("http://{0}:{1}",
                                       HttpContext.Current.Request.ServerVariables["SERVER_NAME"],
                                       HttpContext.Current.Request.ServerVariables["SERVER_PORT"]);


            FormDefinitionsDirectory = section.SelectSingleNode("@formDefinitionsUrl").Value.ToLowerInvariant();
            FormDefinitionsDirectory = HttpContext.Current.Server.MapPath(FormDefinitionsDirectory);

            XslDirectory = section.SelectSingleNode("@xslUrl").Value.ToLowerInvariant();
            XslDirectory = HttpContext.Current.Server.MapPath(XslDirectory);

            EntryXslPath = Path.Combine(XslDirectory, section.SelectSingleNode("@entryXslName").Value.ToLowerInvariant());

            return this;
        }

        public string WebsiteUrl { get; private set; }

        public string FormDefinitionsDirectory { get; private set; }

        public string XslDirectory { get; private set; }

        public string EntryXslPath { get; private set; }

        #endregion

    }
}