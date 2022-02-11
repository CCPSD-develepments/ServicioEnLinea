using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CamaraComercio.Website.TarjetaCredito
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RedireccionPago'
    public partial class RedireccionPago : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RedireccionPago'
    {
        /// <summary>
        /// Id de la transacción en CamaraWebsite
        /// </summary>
        private int? TransaccionId
        {
            get
            {
                var parm = Request.GetParam("Id");
                if (parm.Length > 0 && parm != "source")
                {
                    var id = 0;
                    if (Int32.TryParse(parm, out id))
                        return id;
                    return null;
                }
                return null;
            }
        }

        /// <summary>
        /// Token de respuesta de la transacción
        /// </summary>
        private string TokenId
        {
            get { return Request.GetParam("token"); }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RedireccionPago.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RedireccionPago.Page_Load(object, EventArgs)'
        {
            //Se revisa que los parametros estén correctos
            if (String.IsNullOrEmpty(TokenId) || TransaccionId == 0)
            {
                this.litEstatusTrans.Text = "Transacción No Válida";
                return;
            }

            //Se consulta el servicio de tokens del sistema transaccional
            string respuesta;
            var x = VerificarToken(TransaccionId, TokenId, out respuesta);
        }

        private int VerificarToken(int? transId, string token, out string respuesta)
        {
            respuesta = "Transacción existe. Fue pagada";
            return 1;

            //respuesta = "Transacción existe. No ha sido pagada";
            //return 2;

            //respuesta = "Transacción existe. Fue cancelada";
            //return 3;

            //respuesta = "Transacción no existe.";
            //return 4;
        }
    }
}