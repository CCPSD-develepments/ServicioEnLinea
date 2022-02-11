using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Web;


namespace ModuloPago
{
    public partial class ProcesarPagoVisanet : System.Web.UI.Page
    {



        //CamaraWebsiteAccountsEntities dbcamaraaccount = new CamaraWebsiteAccountsEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            //var authCode = HelperTransaccional.GetCardTypeFromNumber("5412751234123456");
            //if (EsRepuestaCardnet)
            //{
            //    RequestCardnet(EnumSystemType.VentanillaUnica, "ALT");
            //}
            //RealizarPago(27892, 2002M, "dfgdf", "00101469393", "http://localhost:58479/ProcesarPagoVisanet.aspx", EnumSystemType.VentanillaUnica, "SPM");

            //pruebas azul
            //var authCode = HelperTransaccional.GetCardTypeFromNumber("5412751234123456");
            //if (EsRepuestaAzul)
            //{
            //    RequestAzul(EnumSystemType.VentanillaUnica, "EPT");
            //}
            //RealizarPago(27892, 2500m
            //    , "dfgdf", "00101469393", "http://localhost:58479/ProcesarPagoVisanet.aspx", EnumSystemType.VentanillaUnica, "EPT");
        }

        /// <summary>
        /// Objecto para obtener el request de visanet
        /// </summary>
        /// <param name="systemType">el sistema en la que se esta realizando el pago</param>
        /// <returns></returns>
        public VisanetResponseDTO RequestVisanet(EnumSystemType systemType)
        {
            var vDTO = new VisanetResponseDTO();

            //Validacion de errores
            if (Status.ToLower() == "error")
            {
                //Asigno errores a la propiedad
                Errores = HttpContext.Current.Request.GetParamameter("Errors");               
            }

            //Validacion de redirect desde el transaccional de VisaNet
            vDTO.AuthCode = HttpContext.Current.Request.GetParamameter("AuthCode");
            if (String.IsNullOrEmpty(vDTO.AuthCode) || vDTO.AuthCode.Length <= 0)
            {               
                Errores = "No devolvio el Auth Code";
                return null;
            }

            vDTO.MerchantKey = HttpContext.Current.Request.GetParamameter("MerchantKey");
            vDTO.OrderID = int.Parse(HttpContext.Current.Request.GetParamameter("OrderID"));
            vDTO.Amount = float.Parse(HttpContext.Current.Request.GetParamameter("Amount"));
            vDTO.Currency = int.Parse(HttpContext.Current.Request.GetParamameter("Currency"));
            vDTO.Tarjeta = HttpContext.Current.Request.GetParamameter("Tarjeta");
            vDTO.ReferenceCode = HttpContext.Current.Request.GetParamameter("ReferenceCode");

            ObtenerResponse = vDTO;            

            //TODO: Grabar Datos en Base de datos
            PagoVisanetService.GrabarTransaccion(vDTO, systemType);
            //
            return vDTO;
           
        }
        
        /// <summary>
        /// Metodo para realizar el pago con la tarjeta de credito
        /// </summary>
        /// <param name="transaccionId">id de la transaccion</param>
        /// <param name="monto">monto a pagar</param>
        /// <param name="nombreCompletoSolicitante">Nombre del solicitante</param>
        /// <param name="rnc">Rnc</param>
        /// <param name="returnUrl">Url donde visanet hara el postback</param>
        public void RealizarPago(int transaccionId,decimal monto, string nombreCompletoSolicitante, string rnc, string returnUrl,EnumSystemType systemType)
        {
            //The easy way
            HttpContext.Current.Response.Clear();
            var sb = new StringBuilder();
            //Grabo la orden
            var orderId = PagoVisanetService.GrabarOrder(transaccionId, systemType);

            sb.Append("<html>");
            sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
            sb.AppendFormat("<form name='form' action='{0}' method='post'>", HelperTransaccional.TransGatewayUrl);
            sb.AppendFormat("<input type='hidden' name='MerchantKey' value='{0}'>", HelperTransaccional.TransGatewayApiKey);
            sb.AppendFormat("<input type='hidden' name='OrderID' value='{0}'>", orderId);
            sb.AppendFormat("<input type='hidden' name='Amount' value='{0}'>", monto.ToString("##########"));
            sb.AppendFormat("<input type='hidden' name='Currency' value='{0}'>", 214);
            sb.AppendFormat("<input type='hidden' name='Nombres' value='{0}'>", nombreCompletoSolicitante);
            sb.AppendFormat("<input type='hidden' name='Identificacion' value='{0}'>", rnc);
            sb.AppendFormat("<input type='hidden' name='returnUrl' value='{0}'>", returnUrl);
            sb.Append("</form>");
            sb.Append("</body>");
            sb.Append("</html>");

            HttpContext.Current.Response.Write(sb.ToString());
            HttpContext.Current.Response.End();                        
        }


        // metodo para realizar pago ventanilla 
        /// <summary>
        /// Metodo para realizar el pago con la tarjeta de credito
        /// </summary>
        /// <param name="transaccionId">id de la transaccion</param>
        /// <param name="monto">monto a pagar</param>
        /// <param name="nombreCompletoSolicitante">Nombre del solicitante</param>
        /// <param name="rnc">Rnc</param>
        /// <param name="returnUrl">Url donde visanet hara el postback</param>
        ///  /// <param name="_camaraId">Url donde visanet hara el postback</param>

        public void RealizarPago(int transaccionId, decimal monto, string nombreCompletoSolicitante, string rnc, string returnUrl, EnumSystemType systemType, string _camaraId)
        {
            //The easy way
            HttpContext.Current.Response.Clear();
            var sb = new StringBuilder();
            //Grabo la orden
            //var orderId = 123; 
            var orderId = PagoVisanetService.GrabarOrder(transaccionId, systemType);


            var CamarasConPago = ConfigurationManager.AppSettings["CamarasConPago"].Split(',');

            List<string> CamarasConPagoList = new List<string>();

            for (int i = 0; i < CamarasConPago.Length; i++)
            {
                CamarasConPagoList.Add(CamarasConPago[i]);
            }


            
            if (CamarasConPagoList.Contains(_camaraId + "/Carnet"))
            {
                returnUrl = returnUrl + "&formaEntrega=D" + "#red";
                sb = GenerarStringPagoCardNet(orderId, monto * 100, returnUrl, "", _camaraId, transaccionId);
            }

            else if (CamarasConPagoList.Contains(_camaraId + "/Azul"))
            {
                string returnUrla = returnUrl + "&formaEntrega=D" + "#red";
                sb = GenenarStringPagoAzul(orderId, _camaraId, returnUrl, monto, returnUrla, transaccionId);
            }


            else
            {

                sb.Append("<html>");
                sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
                sb.AppendFormat("<form name='form' action='{0}' method='post'>", HelperTransaccional.TransGatewayUrl);


                if (_camaraId == "SAN")
                {
                    sb.AppendFormat("<input type='hidden' name='MerchantKey' value='{0}'>", HelperTransaccional.TransGatewayApiKeySAN);
                }
                else
                    sb.AppendFormat("<input type='hidden' name='MerchantKey' value='{0}'>", HelperTransaccional.TransGatewayApiKey);

                sb.AppendFormat("<input type='hidden' name='OrderID' value='{0}'>", orderId);
                sb.AppendFormat("<input type='hidden' name='Amount' value='{0}'>", monto.ToString("##########"));
                sb.AppendFormat("<input type='hidden' name='Currency' value='{0}'>", 214);
                sb.AppendFormat("<input type='hidden' name='Nombres' value='{0}'>", nombreCompletoSolicitante);
                sb.AppendFormat("<input type='hidden' name='Identificacion' value='{0}'>", rnc);
                sb.AppendFormat("<input type='hidden' name='returnUrl' value='{0}'>", returnUrl);
                sb.Append("</form>");
                sb.Append("</body>");
                sb.Append("</html>");
            }

            HttpContext.Current.Response.Write(sb.ToString());
            HttpContext.Current.Response.End();
        }


        private StringBuilder GenerarStringPagoCardNet(int orderId, decimal monto, string returnUrl, string CancelUrl, string camaraId, int transaccionId) 
        {
            var sb = new StringBuilder();

            var camaraMerchants = HelperTransaccional.GetCardNetMechant(camaraId);

            sb.Append("<html>");
            sb.AppendFormat(@"<body onload='document.frm1.submit()'>");
            sb.AppendFormat("<form name='frm1' action='{0}' method='post'>", HelperTransaccional.TransGatewayUrlCardNet);
            sb.AppendFormat("<p><input name='TransactionType' value='0200' type='hidden'></p>");
            sb.AppendFormat("<p><input name='CurrencyCode' value='214' type='hidden'></p>");
            sb.AppendFormat("<p><input name='AcquiringInstitutionCode' value='349' type='hidden'></p>");
            sb.AppendFormat("<p><input name='MerchantType' value='{0}' type='hidden'></p>", camaraMerchants["MerchantType"]);
            sb.AppendFormat("<p><input name='MerchantNumber' value='{0}' type='hidden'</p>", camaraMerchants["MerchantNumber"]);
            sb.AppendFormat("<p><input name='MerchantTerminal' value='{0}' type='hidden'></p>", camaraMerchants["MerchantTerminal"]);
            sb.AppendFormat("<p><input name='ReturnUrl' value='{0}' type='hidden'></p>", returnUrl);
            sb.AppendFormat("<p><input name='CancelUrl' value='{0}' type='hidden'></p>", returnUrl);
            sb.AppendFormat("<p><input name='PageLanguaje' value='ESP' type='hidden'></p>");
            sb.AppendFormat("<p><input name='OrdenId' value='{0}' type='hidden'></p>", orderId);
            sb.AppendFormat("<p><input name='TransactionId' value='{0}' type='hidden'></p>", transaccionId.ToString("######"));
            sb.AppendFormat("<p><input name='Amount' value='{0}' type='hidden'></p>", monto.ToString("############"));
            sb.AppendFormat("<p><input name='Tax' value='000000000' type='hidden'></p>");
            sb.AppendFormat("<p><input name='MerchantName' value='COMERCIO PARA REALIZAR PRUEBAS DO' type='hidden'></p>", "");
            sb.AppendFormat("<p><input name='KeyEncriptionKey' value='{0}' type='hidden'></p>", HelperTransaccional.MD5Hash(camaraMerchants["MerchantType"]
                                                                                                                                                        + camaraMerchants["MerchantNumber"]
                                                                                                                                                        + camaraMerchants["MerchantTerminal"]
                                                                                                                                                        + transaccionId.ToString()
                                                                                                                                                        + monto
                                                                                                                                                        + "0"));
            sb.AppendFormat("<p><input name='Ipclient' value='X.X.X.X' type='hidden'></p>", ""); //TODO
            sb.AppendFormat("<p><input name='loteid' Value='001' type='hidden'></p>");
            sb.AppendFormat("<p><input name='seqid' Value='001' type='hidden'></p>");

            return sb;
        }

        public VisanetResponseDTO RequestCardnet(EnumSystemType systemType, string camaraId)
        {
            var vDTO = new VisanetResponseDTO();

            var responseCode = HttpContext.Current.Request.Params.Get("ResponseCode");
            if(!responseCode.Equals("00"))
            {
                switch (responseCode)
                {
                    case "51":
                        {
                            Errores = "Transacción No Aprobada. FONDOS INSUFICIENTES.";
                            break;
                        }
                    case "79":
                        {
                            Errores = "Transacción Rechazada.";
                            break;
                        }
                    case "07":
                    {
                        Errores = "Transacción No Aprobada. TARJETA RECHAZADA.";
                        break;
                    }
                    default:
                        {
                            Errores = "Error de Sistema. Intento mas tarde.";
                            break;
                        }
                }
                return null;
            }

            //Validacion de redirect desde el transaccional de VisaNet
            vDTO.AuthCode = HttpContext.Current.Request.Params.Get("AuthorizationCode");
            if (String.IsNullOrEmpty(vDTO.AuthCode) || vDTO.AuthCode.Length <= 0)
            {
                Errores = "No devolvio el Auth Code";
                return null;
            }



            vDTO.MerchantKey = HelperTransaccional.GetCardNetMechant(camaraId)["MerchantNumber"];
            vDTO.OrderID = int.Parse(HttpContext.Current.Request.Params.Get("OrdenID"));
            //vDTO.Amount = float.Parse(HttpContext.Current.Request.GetParamameter("Amount"));
            //vDTO.Currency = int.Parse(HttpContext.Current.Request.GetParamameter("Currency"));
            vDTO.Tarjeta = HttpContext.Current.Request.Params.Get("CreditCardNumber");
            vDTO.ReferenceCode = HttpContext.Current.Request.Params.Get("RetrivalReferenceNumber");

            ObtenerResponse = vDTO;

            //TODO: Grabar Datos en Base de datos
            PagoVisanetService.GrabarTransaccion(vDTO, systemType);
            //
            return vDTO;

        }


        private StringBuilder GenenarStringPagoAzul(int orderId, string camaraId, string returnUrl, decimal monto, string returnUrla, int transId) 
        {
         

            var camaraMerchants = HelperTransaccional.GetCardNetMechant(camaraId);

            var hash = camaraMerchants["MerchantNumber"] + camaraMerchants["MerchantTerminal"] + camaraMerchants["MerchantType"]
                + "$" + orderId + monto.ToString("0.00").Replace(".", String.Empty) + "000" + returnUrl + returnUrl + returnUrl + "&cancel=true" + returnUrla
                + "0" + "" + "" + "0" + "" + "" + camaraMerchants["Authkey"];

            var key = camaraMerchants["Authkey"];

            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding(); 
            byte [] keyByte = encoding.GetBytes(key);

            HMACSHA512 hmacsha512 = new HMACSHA512(keyByte); 

            byte [] messageBytes = encoding.GetBytes(hash);
            byte[] hashmessage = hmacsha512.ComputeHash(messageBytes);
            var hashHexagesimal = "";

            for (int i = 0; i < hashmessage.Length; i++)
            {
                hashHexagesimal += hashmessage[i].ToString("x2"); // hex format
            }

            var sb = new StringBuilder();

            sb.Append("<html>");
            sb.AppendFormat(@"<body onload='document.frm1.submit()'>");
            sb.AppendFormat("<form name='frm1' action='{0}' method='post'>", HelperTransaccional.TransGatewayUrlAzul);
            sb.AppendFormat("<p><input name='MerchantId' value='{0}' type='hidden'></p>", camaraMerchants["MerchantNumber"]);
            sb.AppendFormat("<p><input name='MerchantName' value='{0}' type='hidden'</p>", camaraMerchants["MerchantTerminal"]);
            sb.AppendFormat("<p><input name='MerchantType' value='{0}' type='hidden'></p>", camaraMerchants["MerchantType"]);
            sb.AppendFormat("<p><input type='hidden' id='CurrencyCode' name='CurrencyCode' value='$' ></p>");
            sb.AppendFormat("<p><input type='hidden' id='OrderNumber' name='OrderNumber' value='{0}' ></p>", orderId);
            sb.AppendFormat("<p><input type='hidden' id='Amount' name='Amount' value='{0}' ></p>", monto.ToString("0.00").Replace(".", String.Empty));
            sb.AppendFormat("<p><input type='hidden' id='Itbis' name='Itbis' value='000' ></p>");
            sb.AppendFormat("<p><input type='hidden' id='ApprovedUrl' name='ApprovedUrl' value='{0}' ></p>", returnUrl);
            sb.AppendFormat("<p><input type='hidden' id='DeclinedUrl' name='DeclinedUrl' value='{0}' ></p>", returnUrl);
            sb.AppendFormat("<p><input type='hidden' id='CancelUrl' name='CancelUrl' value='{0}' ></p>", returnUrl + "&cancel=true");
            sb.AppendFormat("<p><input type='hidden' id='ResponsePostUrl' name='ResponsePostUrl' value='{0}' ></p>", returnUrla);
            sb.AppendFormat("<p><input type='hidden' id='UseCustomField1' name='UseCustomField1' value='0' ></p>");
            sb.AppendFormat("<p><input type='hidden' id='CustomField1Label' name='CustomField1Label' value='' ></p>");
            sb.AppendFormat("<p><input type='hidden' id='CustomField1Value' name='CustomField1Value' value='' ></p>");
            sb.AppendFormat("<p><input type='hidden' id='UseCustomField2' name='UseCustomField2' value='0' ></p>");
            sb.AppendFormat("<p><input type='hidden' id='CustomField2Label' name='CustomField2Label' value='' ></p>");
            sb.AppendFormat("<p><input type='hidden' id='CustomField2Value' name='CustomField2Value' value='' ></p>");
            sb.AppendFormat("<p><input type='hidden' id='ShowTrxResult' name='ShowTrxResult' value='0' ></p>");
            sb.AppendFormat("<p><input type='hidden' id='AuthHash' name='AuthHash' value='{0}' ></p>", hashHexagesimal);


            string prueba = sb.ToString();

            HttpContext.Current.Response.Write(sb.ToString());
            HttpContext.Current.Response.End();
            return sb;

        }

        public VisanetResponseDTO RequestAzul(EnumSystemType systemType, string camaraId )
        {

             var vDTO = new VisanetResponseDTO();

            //Validacion de redirect desde el transaccional de VisaNet
            vDTO.AuthCode = HttpContext.Current.Request.Params.Get("AuthorizationCode");
            if (String.IsNullOrEmpty(vDTO.AuthCode) || vDTO.AuthCode.Length <= 0)
            {
                Errores = "No devolvio el Auth Code";
                return null;
            }

            vDTO.MerchantKey = HelperTransaccional.GetCardNetMechant(camaraId)["MerchantNumber"];
            vDTO.OrderID = int.Parse(HttpContext.Current.Request.Params.Get("OrderNumber"));
            vDTO.Amount = (float)Convert.ToDecimal(HttpContext.Current.Request.GetParamameter("Amount")) / 100;
            //vDTO.Currency = int.Parse(HttpContext.Current.Request.GetParamameter("Currency"));
            vDTO.Tarjeta = HttpContext.Current.Request.Params.Get("CardNumber");
            vDTO.ReferenceCode = HttpContext.Current.Request.Params.Get("AuthorizationCode");

            ObtenerResponse = vDTO;

            //TODO: Grabar Datos en Base de datos
            PagoVisanetService.GrabarTransaccion(vDTO, systemType);
            //
            return vDTO;
        }


        public VisanetResponseDTO RequestBHD(EnumSystemType systemType, string camaraId)
        {

            var vDTO = new VisanetResponseDTO();

            //Validacion de redirect desde el transaccional de VisaNet
            vDTO.AuthCode = "00";
          

            vDTO.MerchantKey = "0000";//HelperTransaccional.GetCardNetMechant(camaraId)["MerchantNumber"];
            vDTO.OrderID = 0;//int.Parse(HttpContext.Current.Request.Params.Get("OrderNumber"));
            vDTO.Amount = 00;//(float)Convert.ToDecimal(HttpContext.Current.Request.GetParamameter("Amount")) / 100;
            //vDTO.Currency = int.Parse(HttpContext.Current.Request.GetParamameter("Currency"));
            vDTO.Tarjeta = "00"; 
            HttpContext.Current.Request.Params.Get("CardNumber");
            vDTO.ReferenceCode = "00";//HttpContext.Current.Request.Params.Get("AuthorizationCode");

            ObtenerResponse = vDTO;

            var TransaId = HttpContext.Current.Request.Params.Get("reference");

            var OrderSaved = PagoVisanetService.GetOrderBySistemaIdAndTransId(Convert.ToInt32(TransaId), systemType);

            if (OrderSaved != null)
                vDTO.OrderID = OrderSaved.Id;
            //TODO: Grabar Datos en Base de datos
            PagoVisanetService.GrabarTransaccion(vDTO, systemType);
            //
            return vDTO;
        }


        public string RealizarPagoUrl(int transaccionId, decimal monto, string nombreCompletoSolicitante, string rnc, string returnUrl, EnumSystemType systemType, string camaraId)
        {
            //Se arma el mensaje a enviar al sistema transaccional
            var sb = new StringBuilder();
            var orderId = PagoVisanetService.GrabarOrder(transaccionId, systemType);

            sb.AppendFormat("returnUrl={0}", returnUrl);
            sb.AppendFormat("?orderType={0}", "RM-OFV");
            sb.AppendFormat("&OrderID={0}", orderId);
            

            if (camaraId == "SAN") {
                sb.AppendFormat("&MerchantKey={0}", HelperTransaccional.TransGatewayApiKeySAN);
            }
            else
                sb.AppendFormat("&MerchantKey={0}", HelperTransaccional.TransGatewayApiKey);

            sb.AppendFormat("&Amount={0}", monto.ToString("##########"));
            sb.AppendFormat("&Currency={0}", 214);
            sb.AppendFormat("&Nombres={0}", nombreCompletoSolicitante);
            sb.AppendFormat("&Identificacion={0} ", rnc);

            var url = String.Format("{0}?{1}", HelperTransaccional.TransGatewayUrl, sb);

            return url;
        }

        /// <summary>
        /// Parametro con el estatus de la transaccion (desde el transaccional)
        /// </summary>
        public string Status
        {
            get { return HttpContext.Current.Request.GetParamameter("status"); }
        }
        //Lista de errores que dio al momento de realizar el pago
        public string Errores { get; set; }
        //Objecto response de la respuesta del transaccional
        public VisanetResponseDTO ObtenerResponse
        {
            get
            {
                if (Session["VisanetResponseDTO"] != null)
                    return (VisanetResponseDTO) Session["VisanetResponseDTO"];
                
                return new VisanetResponseDTO();
            }
            set { Session["VisanetResponseDTO"] = value; }
        }

        public bool EsRepuestaVisanet
        {
            get
            {
                var authCode = HttpContext.Current.Request.GetParamameter("AuthCode");
                if (String.IsNullOrEmpty(authCode) || authCode.Length <= 0)
                {
                    Errores = "No devolvio el Auth Code";
                    return false;
                }

                return true;
            }
        }

        public bool EsRepuestaCardnet
        {
            get
            {
                var authCode = HttpContext.Current.Request.Params.Get("AuthorizationCode");
                if (String.IsNullOrEmpty(authCode) || authCode.Length <= 0)
                {
                    Errores = "No devolvio el Auth Code";
                    return false;
                }

                return true;
            }
        }


        public bool EsRepuestaBHD
        {
            get
            {
                var authCode = HttpContext.Current.Request.GetParamameter("transactionState");
                if (authCode != null && (authCode == "Completada" || authCode == "Sometido"))
                {
                    
                    return true;
                }

                return false;
            }
        }


        public bool EsRepuestaAzul
        {
            get
            {
               //var authCode = HttpContext.Current.Request.GetParamameter("AuthorizationCode");
               var authHash = HttpContext.Current.Request.GetParamameter("AuthHash");
               if (String.IsNullOrEmpty(authHash) || authHash.Length <= 0)
                {
                    Errores = "No devolvio el Auth Code";
                    return false;
                }

                return true;
            }
        }
    }

}