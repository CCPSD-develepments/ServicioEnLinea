using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CamaraComercio.Website
{
    public partial class MailTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Armar el link de confirmacion            
            var url = string.Format("{0}/account/Activacionusuario.aspx?id={1}", Helper.UrlPortal, "TESTKEY");

            //Armar correo a enviar
            var parametros = new Dictionary<string, string>
                                 {
                                     {"[NombreCompleto]", "Juango Perez"},
                                     {"[UserName]", "juango"},
                                     {"[link]", url}
                                 };

            MailBot.MailBot.SendMail("juango@nextmedia.com.do", null, null, Helper.FromEmailCorreoCamara, "RDU",
                Helper.MailServer, 1, parametros);
        }
    }
}