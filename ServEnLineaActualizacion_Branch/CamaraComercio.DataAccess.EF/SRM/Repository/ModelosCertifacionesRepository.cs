using System;
using System.Collections.Generic;
using System.Linq;
using CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.DataAccess.EF.SRM
{
    /// <summary>
    /// Repositorio de los modelos de certificaciones simples (generadas automáticamente)
    /// </summary>
    public class ModelosCertifacionesRepository : Repository<ModelosCertificaciones, CamaraComercio.DataAccess.EF.SRM.CamaraSRMEntities>
    {
        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        public ModelosCertifacionesRepository(String camaraId)
            : base(CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId))
        {
        }

        /// <summary>
        /// Constructor Sin Parametros
        /// </summary>
        public ModelosCertifacionesRepository()
        {

        }

        /// <summary>
        /// Obtiene todos los modelos de certificación para una cámara de comercio
        /// </summary>
        /// <param name="camaraId">ID de la Cámara</param>
        /// <param name="tipoSociedadId">ID del tipo de sociedad</param>
        /// <param name="esEmpresa">Especifica si las certificaciones son para una empresa o una persona</param>
        /// <returns></returns>
        public IEnumerable<ModelosCertificaciones> GetModelosCertificacion(String camaraId, int? tipoSociedadId, bool? esEmpresa)
        {
            var db = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId);

            var result =
                db.ModelosCertificaciones.Where(
                    a => (!a.TipoSociedadId.HasValue || a.TipoSociedadId == tipoSociedadId) && a.EsEmpresa == esEmpresa)
                    .Distinct().ToList();
            var servicio = new Dictionary<int?, Servicio>();
            var comun = new CamaraComunEntities();
            result.ForEach(a =>
                               {
                                   if (!servicio.Keys.Contains(a.ServicioId))
                                       servicio[a.ServicioId] =
                                           comun.Servicio.FirstOrDefault(s => s.ServicioId == a.ServicioId);
                                   a.Descripcion = a.Descripcion.ToUpper() + " - " + servicio[a.ServicioId].Descripcion;
                                   a.Monto = servicio[a.ServicioId].CostoServicio;
                               });

            return result.AsEnumerable();
        }

        /// <summary>
        /// Obtiene todos los modelos de certificación para una cámara de comercio
        /// </summary>
        /// <param name="camaraId">ID de la Cámara</param>
        /// <returns></returns>
        public IEnumerable<ModelosCertificaciones> GetModelosCertificacion(String camaraId, bool? esPersona)
        {
            var db = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId);

            var result =
                db.ModelosCertificaciones.Where(a => a.EsPersona == esPersona)
                    .Distinct().ToList();
            var servicio = new Dictionary<int?, Servicio>();
            var comun = new CamaraComunEntities();
            result.ForEach(a =>
            {
                if (!servicio.Keys.Contains(a.ServicioId))
                    servicio[a.ServicioId] =
                        comun.Servicio.FirstOrDefault(s => s.ServicioId == a.ServicioId);
                a.Descripcion = a.Descripcion.ToUpper() + " - " + servicio[a.ServicioId].Descripcion;
                a.Monto = servicio[a.ServicioId].CostoServicio;
            });

            return result.AsEnumerable();
        }
    }
}
