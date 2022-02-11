using Bluelaser.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ModuloPago
{
    //Clase de helper
    public static class HelperTransaccional
    {
        /// <summary>
        /// Obtiene un parametro del Request String
        /// </summary>
        /// <param name="request">Objeto del request</param>
        /// <param name="paramName">Nombre del parametro</param>
        /// <returns></returns>
        public static string GetParamameter(this HttpRequest request, string paramName)
        {
            return !String.IsNullOrWhiteSpace(request.QueryString[paramName])
                       ? request.QueryString[paramName]
                       : String.Empty;
        }

        /// <summary>
        /// Application Key que almacena la llave del API para hacer llamadas al transaccional
        /// </summary>
        public static string TransGatewayApiKey
        {
            //get { return "NJMZMJK0MJY4ODG4MTA0MZI0"; }
            get { return GetAppVariable("TransGatewayApiKey"); }
        }

        /// <summary>
        /// Application Key que almacena la llave del API para hacer llamadas al transaccional Santiago
        /// </summary>
        public static string TransGatewayApiKeySAN
        {
            //get { return "NJMZMJK0MJY4ODG4MTA0MZI0"; }
            get { return GetAppVariable("TransGatewayApiKeySAN"); }
        }



        /// <summary>
        /// Application Key del url del sistema transaccional donde se envia el pago
        /// </summary>
        public static string TransGatewayUrl
        {
            //get { return "https://ecommerce.visanet.com.do/APaymentWebPay/default.aspx"; }
            get { return GetAppVariable("TransGatewayUrl"); }
        }

        /// <summary>
        /// Retorna un valor de configuración almacenado en el web.config
        /// </summary>
        /// <param name="varName"></param>
        /// <returns></returns>
        public static string GetAppVariable(string varName)
        {
            var reader = new AppSettingsReader();
            return (string)reader.GetValue(varName, typeof(string));
        }

        /// <summary>
        /// Retorna un valor de configuración almacenado en el web.config como Int
        /// </summary>
        /// <param name="varName"></param>
        /// <returns></returns>
        public static int GetAppVariableAsInt(string varName)
        {
            var reader = new AppSettingsReader();
            return (Int32)reader.GetValue(varName, typeof(Int32));
        }

        /// <summary>
        /// Retorna un valor de configuración almacenado en el web.config como Booleano
        /// </summary>
        /// <param name="varName"></param>
        /// <returns></returns>
        public static bool GetAppVariableAsBool(string varName)
        {
            var reader = new AppSettingsReader();
            return (bool)reader.GetValue(varName, typeof(Boolean));
        }

        /// <summary>
        /// Retorna un valor de configuración almacenado en el web.config como Decimal
        /// </summary>
        /// <param name="varName"></param>
        /// <returns></returns>
        public static decimal GetAppVariableAsDecimal(string varName)
        {
            var response = 0m;
            var reader = new AppSettingsReader();
            response = (Decimal)reader.GetValue(varName, typeof(Decimal));
            return response;
        }

        /// <summary>
        /// Retorna un valor de configuración almacenado en el web.config como TimeSpan
        /// </summary>
        /// <param name="varName"></param>
        /// <returns></returns>
        public static T GetAppVariableAsT<T>(string varName)
        {
            var reader = new AppSettingsReader();
            return (T)reader.GetValue(varName, typeof(T));
        }


        public static string ReturnUrl
        {
            get { return GetAppVariable("ReturnUrl"); }
        }


        /// <summary>
        /// Application Key del url del sistema transaccional donde se envia el pago
        /// </summary>
        public static string TransGatewayUrlCardNet
        {
            //get { return "https://ecommerce.visanet.com.do/APaymentWebPay/default.aspx"; }
            get { return GetAppVariable("TransGatewayUrlCardNet"); }
        }

        public static string TransGatewayUrlAzul
        {
            //get { return "https://ecommerce.visanet.com.do/APaymentWebPay/default.aspx"; }
            get { return GetAppVariable("TransGatewayUrlAzul"); }
        }

        public static Dictionary<string, string> GetCardNetMechant(string camaraId)
        {
            var key = GetAppVariable(camaraId);
            if (!string.IsNullOrEmpty(key))
            {
                var listKey = key.Split(',').ToList();
                var dic = new Dictionary<string, string>();
                dic.Add("MerchantNumber", listKey[0].ToString());
                dic.Add("MerchantTerminal", listKey[1].ToString());
                dic.Add("MerchantType", listKey[2].ToString());
                dic.Add("Authkey", listKey[3].ToString());
                return dic;
            }
            return null;
        }

        public static string MD5Hash(string input)
        {
            var hash = new System.Text.StringBuilder();
            var md5provider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new System.Text.UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        private const string cardRegex = "^(?:(?<Visa>4\\d{3})|(?<MasterCard>5[1-5]\\d{2})|(?<Discover>6011)|(?<DinersClub>(?:3[68]\\d{2})|(?:30[0-5]\\d))|(?<Amex>3[47]\\d{2}))";

        public static string GetCardTypeFromNumber(string cardNum)
        {
            //Create new instance of Regex comparer with our
            //credit card regex patter
            Regex cardTest = new Regex(cardRegex);

            //Compare the supplied card number with the regex
            //pattern and get reference regex named groups
            GroupCollection gc = cardTest.Match(cardNum).Groups;
   
            //Compare each card type to the named groups to 
            //determine which card type the number matches
            if (gc[EnumCreditCardType.Amex.ToString()].Success)
            {
                return "American Express";
            }
            else if (gc[EnumCreditCardType.MasterCard.ToString()].Success)
            {
                return "Master Card";
            }
            else if (gc[EnumCreditCardType.Visa.ToString()].Success)
            {
                return "Visa";
            }
            else if (gc[EnumCreditCardType.Discover.ToString()].Success)
            {
                return "Discover";
            }
            else
            {
                //Card type is not supported by our system, return null
                //(You can modify this code to support more (or less)
                // card types as it pertains to your application)
                return string.Empty;
            }
        }
    }
}