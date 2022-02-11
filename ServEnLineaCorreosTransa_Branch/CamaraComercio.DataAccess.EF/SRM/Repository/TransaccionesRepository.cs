using System;
using System.Collections.Generic;
using System.Linq;

namespace CamaraComercio.DataAccess.EF.SRM
{
    /// <summary>
    /// Repositorio de Transacciones
    /// </summary>
    public class TransaccionesRepository : Repository<Transacciones, CamaraSRMEntities>
    {
        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        /// <param name="camaraId">ID de la cámara</param>
        public TransaccionesRepository(String camaraId)
            : base(CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId))
        {
        }

        ///<summary>
        /// Sobrecarga para usar un contexto compartido
        ///</summary>
        ///<param name="context"></param>
        public TransaccionesRepository(CamaraSRMEntities context) : base(context)
        {
        }

        /// <summary>
        /// Cuenta las transacciones activas para un servicio
        /// </summary>
        /// <param name="servicioId">ID Del servicio</param>
        /// <param name="statusCerrados">Estados a obviar en el query</param>
        /// <param name="numeroCertificacion">Número del registro mercantil</param>
        /// <returns></returns>
        public int CountTransaccionActiva(int servicioId, int? numeroRegistro, List<int> statusCerrados)
        {
            var db = this.Session;
            return db.Transacciones.Where(t => t.TipoServicioId == servicioId && t.CustomInt2 == numeroRegistro &&
                !statusCerrados.Contains(t.Estatus)).Count();
        }
        public int CountTransaccionActivaMejora(int servicioId, int? numeroRegistro, List<int> statusCerrados, int tipoSocieadId)
        {
            var db = this.Session;

            if (tipoSocieadId != 7)
            {
                var countTranSoc = from ts in db.TransaccionesSociedades
                                   join t in db.Transacciones on ts.TransaccionId
                                   equals t.TransaccionId
                                   select new
                                   {
                                       t.TipoServicioId,
                                       t.CustomInt2,
                                       t.Estatus
                                   };
                countTranSoc.ToList();

                return countTranSoc.Where(t => t.TipoServicioId == servicioId && t.CustomInt2 == numeroRegistro &&
                !statusCerrados.Contains(t.Estatus)).Count();
            }
            else
            {
                var countTranPer = from tp in db.TransaccionesPersonas
                                   join t in db.Transacciones on tp.TransaccionId
                                   equals t.TransaccionId
                                   select new
                                   {
                                       t.TipoServicioId,
                                       t.CustomInt2,
                                       t.Estatus
                                   };
                countTranPer.ToList();

                return countTranPer.Where(t => t.TipoServicioId == servicioId && t.CustomInt2 == numeroRegistro &&
                    !statusCerrados.Contains(t.Estatus)).Count();
            }

        }

        /// <summary>
        /// Cuenta las transacciones activas para un servicio
        /// </summary>
        /// <param name="servicioId">ID Del servicio</param>
        /// <param name="statusCerrados">Estados a obviar en el query</param>
        /// <param name="numeroCertificacion">Número del registro mercantil</param>
        /// <returns></returns>
        public int CountTransaccionActiva(List<int> servicioId, int? numeroRegistro, List<int> statusCerrados)
        {
            var db = this.Session;
            return
                db.Transacciones.Where(t => servicioId.Contains(t.TipoServicioId) && t.CustomInt2 == numeroRegistro &&
                                            !statusCerrados.Contains(t.Estatus)).Count();
        }

        /// <summary>
        /// Obtiene todas las transacciones asociadas a un número de registro mercantil
        /// </summary>
        /// <param name="noRegistro">Número del registro mercantil</param>
        /// <returns></returns>
        public IEnumerable<Transacciones> GetTransaccionesByNoRegistro(int noRegistro)
        {
            var db = this.Session;
            return db.Transacciones.Where(t => t.CustomInt2 == noRegistro).OrderByDescending(t => t.Fecha);
        }

        /// <summary>
        /// Revisa la base de datos de registros para verificar si un número de recibo
        /// de la DGII ha sido utilizado anteriormente
        /// </summary>
        /// <param name="noRecibo">Número del registro mercantil</param>
        /// <returns></returns>
        public bool ReciboDgiiExiste(string noRecibo)
        {
            var db = this.Session;
            var trans = db.Transacciones.Where(t => t.NoReciboDGII == noRecibo &&
                                        t.Estatus != 13).Count();
            return (trans > 0);
        }

        /// <summary>
        /// Consulta la base de datos de registros para verificar si un número de registro
        /// de nombre comercial existe previamente
        /// </summary>
        /// <param name="noRegistro"></param>
        /// <returns></returns>
        public bool RegistroOnapiExiste(string noRegistro)
        {
            var db = this.Session;
            var trans = db.Registros.Where(r => r.RegistroNombreComercial == noRegistro.Trim()).Count();
            return (trans > 0);
        }

        ///<summary>
        /// Función que asigna de forma automática una tansacción para que sea manejada por un analista en el SRM
        ///</summary>
        /// <remarks>
        /// Esta función es llamada para enviar una transacción a un analista directamente desde la web con el formulario
        /// de envío de datos/documentos con firma digital
        /// </remarks>
        ///<param name="transaccionId"></param>
        ///<param name="roldId"></param>
        ///<param name="lastUserId"></param>
        public void AsignarTransaccion(int transaccionId, int roldId, int? lastUserId)
        {
            var db = this.Session;
            //db.SetAsignaciones(transaccionId, roldId,
            //    "Expediente asignado automáticamente desde la Web", lastUserId)
            //    .FirstOrDefault();

            db.csp_AsignacionTransaccionVU(transaccionId, "Expediente asignado automáticamente desde la Web", null).FirstOrDefault();
        }
    }

    /// <summary>
    /// Repositorio de Sub-Transacciones (solo se usa así en el SRM)
    /// </summary>
    public class SubTransaccionesRepository : Repository<SubTransacciones, CamaraSRMEntities>
    {
        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        /// <param name="camaraId">ID de la cámara</param>
        public SubTransaccionesRepository(String camaraId)
            : base(CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId))
        {

        }

        /// <summary>
        /// Sobrecarga para usar un contexto compartido
        /// </summary>
        /// <param name="context"></param>

        public SubTransaccionesRepository(CamaraSRMEntities context) : base(context)
        {

        }
    }
}
