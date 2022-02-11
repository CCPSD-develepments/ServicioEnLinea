using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CamaraComercio.Website.Helpers.ExtendedControls
{
    public class RequiredValidatorOfv : RequiredFieldValidator, IExtendedControlOfv
    {
        public string PropertyName { get; set; }
        public RequiredValidatorOfv() : base()
        {
        }
    }
}