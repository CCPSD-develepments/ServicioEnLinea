using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}