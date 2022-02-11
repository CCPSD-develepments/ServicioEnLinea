using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Hammock;
using Hammock.Web;

namespace CamaraComercio.Website.Helpers
{
    ///<summary>
    /// Clase que encapsula todas las interacciones con las aplicaciones web de Nobox
    ///</summary>
    public class TransGatewayHelper
    {
        /// <summary>
        /// Método utilizado para invocar un handshake entre la aplicación de VU/OFV 
        /// y las apps del website que corren bajo PHP en otro contexto
        /// </summary>
        /// <param name="token">
        /// Token de confirmación de la transacción 
        /// </param>
        /// <returns></returns>
        public TransGatewayResponse GetTransactionResponse(string token)
        {
            var client = new RestClient() { Authority = Helper.TransGatewayConfirmUrl };
            var request = new RestRequest { Method = WebMethod.Get };

            request.AddParameter("confirmationCode", token);
            request.AddParameter("apiKey", Helper.TransGatewayApiKey);

            var response = client.Request(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var obj = new TransGatewayResponse();
                try
                {
                    var ser = new XmlSerializer(typeof (TransGatewayResponse));
                    obj = (TransGatewayResponse) ser.Deserialize(response.ContentStream);
                }
                catch
                {
                    obj.Id = -1;
                }
                return obj;
            }

            return null;
        }

        /// <summary>
        /// Representa una respuesta desde Nobox para el delegate del login
        /// </summary>
        [XmlRoot("Transaction")]
        public class TransGatewayResponse
        {
            [XmlElement("Id")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.Id'
            public int Id { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.Id'

            [XmlElement("CreatedAt")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.CreatedAt'
            public DateTime? CreatedAt { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.CreatedAt'

            [XmlElement("ModifiedAt")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.ModifiedAt'
            public DateTime? ModifiedAt { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.ModifiedAt'

            [XmlElement("Amount")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.Amount'
            public Decimal Amount { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.Amount'

            [XmlElement("GatewayType")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.GatewayType'
            public String GatewayType { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.GatewayType'

            [XmlElement("OrderId")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.OrderId'
            public Int32 OrderId { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.OrderId'

            [XmlElement("OrderType")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.OrderType'
            public String OrderType { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.OrderType'

            [XmlElement("CurrencyValue")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.CurrencyValue'
            public Int32 CurrencyValue { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.CurrencyValue'

            [XmlElement("Tax")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.Tax'
            public Decimal Tax { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.Tax'

            [XmlElement("Currency")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.Currency'
            public String Currency { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.Currency'

            [XmlElement("ConfirmationToken")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.ConfirmationToken'
            public String ConfirmationToken { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.ConfirmationToken'

            [XmlElement("Confirmed")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.Confirmed'
            public Boolean Confirmed { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.Confirmed'

            [XmlElement("GatewayTransId")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.GatewayTransId'
            public string GatewayTransId { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.GatewayTransId'

            [XmlElement("MaskedCard")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.MaskedCard'
            public String MaskedCard { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.MaskedCard'

            [XmlElement("AuthorizationCode")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.AuthorizationCode'
            public String AuthorizationCode { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransGatewayHelper.TransGatewayResponse.AuthorizationCode'
        }
    }

}