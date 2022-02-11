using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.Website.Helpers
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModificacionCompanias'
    public static class ModificacionCompanias
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModificacionCompanias'
    {
        private const int Entrega = 11, Cancelado = 13, Completado = 14,Devuelto =18;
        
#pragma warning disable CS1572 // XML comment has a param tag for 'numeroCertificacion', but there is no parameter by that name
#pragma warning disable CS1573 // Parameter 'numeroRegistro' has no matching param tag in the XML comment for 'ModificacionCompanias.EstaSiendoModificada(string, int, string)' (but other parameters do)
        /// <summary>
        /// Esta funcion valida si esta compania ya esta siendo trabajada por alguien.
        /// </summary>
        /// <param name="camaraId">id e la camara</param>
        /// <param name="numeroCertificacion">numero registro mercantil</param>
        /// <param name="userName">Nombre de usuario que esta haciendo la modificacion. </param>
        /// <returns></returns>
        public static bool EstaSiendoModificada(string camaraId, int numeroRegistro, string userName) 
#pragma warning restore CS1573 // Parameter 'numeroRegistro' has no matching param tag in the XML comment for 'ModificacionCompanias.EstaSiendoModificada(string, int, string)' (but other parameters do)
#pragma warning restore CS1572 // XML comment has a param tag for 'numeroCertificacion', but there is no parameter by that name
        {
            var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId);
            List<int> EstatusDeQueNoSeEstaTrabajando = new List<int> {Entrega, Cancelado, Completado, Devuelto};
            List<int> EstatusIdDeModificaciones = new List<int> { 2, 15, 16, 17, 18, 19, 20, 21, 22, 24, 25 };
            bool EstaSiendoModificada = false;
            
            //Aqui verifico cuales transacciones son la que se estan modificando
            var LaQueSeEstanModificando = from srm in dbSrm.Transacciones
                                          where srm.CustomInt2.Value.Equals(numeroRegistro) && !EstatusDeQueNoSeEstaTrabajando.Contains(srm.Estatus) && EstatusIdDeModificaciones.Contains(srm.TipoTransaccionId)
                                          select srm;
            
            EstaSiendoModificada = LaQueSeEstanModificando.Count() > 0;

            if (!EstaSiendoModificada)
            {
                EstaSiendoModificada = EstaSiendoModificadaPeroEstaEnEsperaDeDocumento(camaraId, numeroRegistro, userName.ToLower());
            }

            return EstaSiendoModificada;
        }

#pragma warning disable CS1572 // XML comment has a param tag for 'numeroCertificacion', but there is no parameter by that name
#pragma warning disable CS1573 // Parameter 'numeroRegistro' has no matching param tag in the XML comment for 'ModificacionCompanias.EstaSiendoModificadaPeroEstaEnEsperaDeDocumento(string, int, string)' (but other parameters do)
        /// <summary>
        /// Aqui verifico si la compañia ya se esta modificando, pero no a sido entregada a la camara.
        /// </summary>
        /// <param name="camaraId">id de la camara</param>
        /// <param name="numeroCertificacion">numero de registro mercantl</param>
        /// <param name="userName">usuario conectado actualmente</param>
        /// <returns></returns>
        private static bool EstaSiendoModificadaPeroEstaEnEsperaDeDocumento(string camaraId, int numeroRegistro,string userName) 
#pragma warning restore CS1573 // Parameter 'numeroRegistro' has no matching param tag in the XML comment for 'ModificacionCompanias.EstaSiendoModificadaPeroEstaEnEsperaDeDocumento(string, int, string)' (but other parameters do)
#pragma warning restore CS1572 // XML comment has a param tag for 'numeroCertificacion', but there is no parameter by that name
        {
            var dbCamaraOnline = new OFV.CamaraWebsiteEntities();
            var dbComun = new Comun.CamaraComunEntities();

            //aqui saco las transacciones que no se an entregado a la camara, pero esta siendo trabajada por otro usuario
            var transacciones = from tr in dbCamaraOnline.Transacciones
                                where tr.NumeroRegistro.HasValue && tr.NumeroRegistro.Value.Equals(numeroRegistro) && !tr.SrmTransaccionId.HasValue && tr.CamaraId.Equals(camaraId)
                                && !tr.UserName.Equals(userName.ToLower())
                                select tr;

            //aqui filtro solo las transacciones que son modificaciones.
            var modificaciones = from tr in  transacciones.ToList()
                                 join servicio in dbComun.Servicio on tr.ServicioId equals servicio.ServicioId
                                 join tipoServicio in dbComun.TipoServicio on servicio.TipoServicioId equals tipoServicio.TipoServicioId
                                 where tipoServicio.Sufijo.Equals("MO")
                                 select tr;

            return modificaciones.Count() > 0;
        }
    }
}