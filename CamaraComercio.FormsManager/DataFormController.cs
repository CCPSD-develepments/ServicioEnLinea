using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Xsl;

namespace Xcel.Enterprise.FormsManager
{
    public static class DataFormController
    {

        public static string GetHtmlForm(string xmlContent, string actionUrl)
        {
            //Set XSL Params
            XsltArgumentList xslArgs = new XsltArgumentList();
            xslArgs.AddParam("action", "", actionUrl);

            //Load DataForm Xml
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlContent);

            //Load default Xsl
            XslCompiledTransform transform = new XslCompiledTransform(false);
            XmlDocument xsl = new XmlDocument();
            xsl.LoadXml(GetXslFromResource());
            transform.Load(xsl);

            //Perform Transformation
            using (StringWriter sw = new StringWriter(new StringBuilder()))
            {
                transform.Transform(doc, xslArgs, sw);
                return sw.ToString();
            }
        }

        public static string GetXslFromResource()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string[] names = assembly.GetManifestResourceNames();
            string fooResourceName = string.Format("{0}.{1}", assembly.GetName().Name, "Xslt.Form.xslt");
            using (Stream fooStream = assembly.GetManifestResourceStream(fooResourceName))
            {
                using (StreamReader sr = new StreamReader(fooStream))
                {
                    return sr.ReadToEnd();
                }
            }
        }

    }
}
