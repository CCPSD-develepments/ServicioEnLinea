using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuloPago
{
    public static class PagoVisanetService
    {
        /// <summary>
        /// Graba la transaccion con el objecto que retorna visanet/
        /// </summary>
        /// <param name="transaccion"></param>
        /// <param name="sistema"></param>
        /// <returns></returns>
        public static bool GrabarTransaccion(VisanetResponseDTO transaccion, EnumSystemType sistema)
        {
            var entities = new ModuloPagoVisanetEntities();
            var transaccionVisanet = new TransaccionesVisanet
                                         {
                                             Amount = (decimal) transaccion.Amount,
                                             AuthCode = transaccion.AuthCode,
                                             Currency = transaccion.Currency,
                                             MerchantKey = transaccion.MerchantKey,
                                             OrderID = transaccion.OrderID,
                                             ReferenceCode = transaccion.ReferenceCode,
                                             SistemaId = (int) sistema,
                                             Tarjeta = transaccion.Tarjeta,
                                             FechaTransaccion = DateTime.Now
                                         };

           

            entities.TransaccionesVisanet.Add(transaccionVisanet);

            return entities.SaveChanges() > 0;

        }
        /// <summary>
        /// Grabar la orden que se va a realizar
        /// </summary>
        /// <param name="transaccionId">id de la transaccion</param>
        /// <param name="sistema">sistema en que se cobrara el pago</param>
        /// <returns>retorna el id de la orden</returns>
        public static int GrabarOrder(int transaccionId,EnumSystemType sistema)
        {
            var entitites = new ModuloPagoVisanetEntities();
            var order = new Order
                            {FechaTransaccion = DateTime.Now, SistemaId = (int) sistema, TransaccionId = transaccionId};
            entitites.Order.Add(order);

            return entitites.SaveChanges()>0 ? order.Id : 0;
        }
        /// <summary>
        /// Obtener id de la transaccion del sistema
        /// </summary>
        /// <param name="orderId">id de la orden</param>
        /// <param name="tipoSistema">el sistema </param>
        /// <returns></returns>
        public static int GetTransaccionByOrderIdAndSystemType(int orderId, EnumSystemType tipoSistema)
        {
            var entitites = new ModuloPagoVisanetEntities();
            var res = (from order in entitites.Order
                       where order.Id.Equals(orderId) && order.SistemaId.Equals((int)tipoSistema)
                      select order.TransaccionId).FirstOrDefault();
            return res;
        }
        public static Order GetOrderBySistemaIdAndTransId(int transId, EnumSystemType tipoSistema)
        {
            var entitites = new ModuloPagoVisanetEntities();
            var orderObj = (from order in entitites.Order
                           where order.TransaccionId.Equals(transId) && order.SistemaId.Equals((int)tipoSistema)
                           orderby order.Id descending
                           select order
                          ).FirstOrDefault();
            return orderObj;
        }
        public static TransaccionesVisanet GetTransVisanet(int transaccionId, EnumSystemType tipoSistema)
        {
            var entitites = new ModuloPagoVisanetEntities();
            var orderId = (from order in entitites.Order                           
                           where order.TransaccionId.Equals(transaccionId) && order.SistemaId.Equals((int) tipoSistema)
                           orderby order.Id descending 
                           select order.Id
                           ).FirstOrDefault();
            var trans = (from tran in entitites.TransaccionesVisanet
                         where tran.OrderID.HasValue && tran.OrderID.Value.Equals(orderId)
                         select tran).FirstOrDefault();

            return trans;

        }
    }
}