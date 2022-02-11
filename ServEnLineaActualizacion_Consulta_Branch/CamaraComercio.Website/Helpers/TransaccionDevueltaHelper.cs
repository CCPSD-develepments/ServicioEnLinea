using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamaraComercio.Website.Helpers
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransaccionDevueltaHelper'
    public sealed class TransaccionDevueltaHelper
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransaccionDevueltaHelper'
    {
        private readonly HttpRequest _request;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransaccionDevueltaHelper.TransaccionDevueltaHelper(HttpRequest)'
        public TransaccionDevueltaHelper(HttpRequest request)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransaccionDevueltaHelper.TransaccionDevueltaHelper(HttpRequest)'
        {
            _request = request;
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransaccionDevueltaHelper.EstaDevuelta()'
        public bool EstaDevuelta()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransaccionDevueltaHelper.EstaDevuelta()'
        {
            var tieneEstado = !string.IsNullOrEmpty(_request.QueryString["estado"]?.ToString());
            return tieneEstado && ObtenerTransaccionId() > 0;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TransaccionDevueltaHelper.ObtenerTransaccionId()'
        public long ObtenerTransaccionId()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TransaccionDevueltaHelper.ObtenerTransaccionId()'
        {
            var tieneValor = int.TryParse(_request.QueryString["nSolicitud"]?.ToString(), out int transaccionId);
            if (tieneValor)
            {
                return transaccionId;
            }
            else
            {
                return 0;
            }
        }
    }
}