using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CamaraComercio.Website
{
    public partial class OnapiTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var ws = new wsDgii3.wsDGII();
            ////var montoAutorizacion = ws.CalcularAutorizacionPago(100000);
            ////var aut = ws.GeneraAutorizacionPago(Helper.WsDgiiUsername, Helper.WsDgiiPassword, "05601345191", 100000);

            //var resp = ws.ConsultaAutorizacionPago(Helper.WsDgiiUsername, Helper.WsDgiiPassword, "29564838266");
            ////var resp2 = ws.ConsultaAutorizacionPago("ccomer", "ccomer", "29562670830");
            ////var resp3 = ws.ConsultaAutorizacionPago("ccomer", "ccomer", "029562670830");

            ////var ws = new wsOnapi2.ServicioCC();
            ////var res1 = ws.BuscarNombresComerciales("nextmedia");
            ////var res2 = ws.BuscarNombresComerciales("NEXTMEDIA");
            ////var res3 = ws.BuscarNombresComerciales("PEPSI");

            var amhed = OficinaVirtualUserProfile.GetUserProfile("amhed");
            amhed.UsuarioPadre = null;
            amhed.Save();


         
        }
    }
}