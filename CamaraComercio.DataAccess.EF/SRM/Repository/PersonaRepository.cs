using System.Collections.Generic;
using System.Linq;
using LinqKit;

namespace CamaraComercio.DataAccess.EF.SRM
{
    /// <summary>
    /// Repositorio de la entidad Personas. Usado para búsquedas
    /// </summary>
    public class PersonaRepository : Repository<Personas, CamaraSRMEntities>
    {
        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        /// <param name="camaraID">ID de la Cámara</param>
        public PersonaRepository(string camaraID) : 
            base(CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraID))
        {
        }

        /// <summary>
        /// Busqueda de una persona en la base de datos del registro mercantil (búsqueda dinámica)
        /// </summary>
        /// <param name="primerNombre">Primer Nombre</param>
        /// <param name="segundoNombre">Segundo Nombre</param>
        /// <param name="primerApellido">Primer Apellido</param>
        /// <param name="segundoApellido">Segundo Apellido</param>
        /// <param name="documento">Número de Documento</param>
        /// <returns></returns>
        public IEnumerable<Personas> FindPersona(string primerNombre, string segundoNombre, 
            string primerApellido, string segundoApellido, string documento)
        {
            //Acceso a datos
            var db = this.Session;
            var predicate = PredicateBuilder.True<Personas>();

            //Si los parametros vienen todos nulos no hacer el query
            if (string.IsNullOrEmpty(primerNombre) && string.IsNullOrEmpty(segundoNombre)
                    && string.IsNullOrEmpty(primerApellido) && string.IsNullOrEmpty(segundoApellido)
                    && string.IsNullOrEmpty(documento))
                return null;

            if (!string.IsNullOrEmpty(primerNombre))
                predicate = predicate.And(p => p.PrimerNombre.Contains(primerNombre));
            if (!string.IsNullOrEmpty(segundoNombre))
                predicate = predicate.And(p => p.SegundoNombre.Contains(segundoNombre));
            if (!string.IsNullOrEmpty(primerApellido))
                predicate = predicate.And(p => p.PrimerApellido.Contains(primerApellido));
            if (!string.IsNullOrEmpty(segundoApellido))
                predicate = predicate.And(p => p.SegundoApellido.Contains(segundoApellido));
            if (!string.IsNullOrEmpty(documento))
                predicate = predicate.And(p => p.Documento == documento);

            return db.Personas.AsExpandable().Where(predicate)
                .OrderBy(c => new {c.PrimerNombre, c.SegundoNombre, c.PrimerApellido, c.SegundoApellido})
                .Take(50);
        }
    }
}
