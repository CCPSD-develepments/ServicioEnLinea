using System;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;

namespace CamaraComercio.WebServices.Helpers
{
    public static class StringHelper
    {
        public static string FormatRnc(this string rnc)
        {
            rnc = rnc.Replace("-", "");

            if (rnc.Length == 9)
                rnc = String.Format("{0}-{1}-{2}-{3}", rnc.Substring(0, 1), rnc.Substring(1, 2), rnc.Substring(3, 5), rnc.Substring(8, 1));
            else if (rnc.Length == 11)
                rnc = String.Format("{0}-{1}-{2}", rnc.Substring(0, 3), rnc.Substring(3, 7), rnc.Substring(10, 1));

            return rnc;
        }

        //TODO: Jason: Quitar este metodo temporal
        public static int ConvertToInt32Value(this string value)
        {
            var valueInt = 0;
            Int32.TryParse(value, out valueInt);
            return valueInt;
        }
    }

    public static class JSonMethods
    {
        /// <summary>
        /// Serializes an object to Javascript Object Notation
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJSON(this object obj)
        {
            string json;
            var ser = new DataContractJsonSerializer(obj.GetType());
            using (var ms = new MemoryStream())
            {
                ser.WriteObject(ms, obj);
                json = Encoding.Default.GetString(ms.ToArray());
            }
            return json;
        }

        /// <summary>
        /// Serializes an anonymous object to Javascript Object Notation
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToAnonJSON(this object obj)
        {
            var ser = new JavaScriptSerializer();
            return ser.Serialize(obj);
        }
    }
}