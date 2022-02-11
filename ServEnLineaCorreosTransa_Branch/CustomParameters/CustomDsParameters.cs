using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NmParameters
{
    public class LoginParameter : Parameter
    {
        public LoginParameter(string Name)
            : base(Name)
        { }

        protected override object Evaluate(HttpContext context, Control control)
        {
            //UPDATED as suggested in Joels comments below...
            //return HttpContext.Current.User.Identity.Name;
            return context.User.Identity.Name;
        }
    }
}