using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using LinqKit;

namespace CamaraComercio.DataAccess.EF.CamaraComun
{
    /// <summary>
    /// Repositorio de Cargos
    /// </summary>
    public class CargosRepository : Repository<CamaraComun.Cargos, CamaraComun.CamaraComunEntities>
    {
        /// <summary>
        /// Constructor Predeterminado
        /// </summary
        public CargosRepository()
        {
        }

        ///<summary>
        /// Retorna todos los cargos 
        ///</summary>
        ///<returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<CamaraComun.Cargos> SelectVisible()
        {
            return Session.Cargos.Where(c => c.SiteVisible == true).OrderBy(c => c.Descripcion).ToList();
        }

        ///<summary>
        /// Retorna todos los cargos permitidos para un tipo de sociedadID
        ///</summary>
        ///<param name="tipoSociedadId">ID del tipo de sociedad</param>
        ///<param name="puedeSerEmpresa">Indica si se deben incluir las empresas en el filtro de cargos</param>
        ///<param name="esModificacion">Indica si se deben incluir los cargos solo permitidos en modificacion</param>
        ///<returns></returns>
        /// [DataObjectMethod(DataObjectMethodType.Select)]
        public List<CamaraComun.Cargos> SelectByTipoSociedadId(int tipoSociedadId, bool puedeSerEmpresa, bool esModificacion)
        {
            var predicate = PredicateBuilder.True<TipoSociedadCargos>();

            predicate = predicate.And(p => p.TipoSociedadId == tipoSociedadId);

            if (puedeSerEmpresa)
                predicate = predicate.And(p => p.PuedeSerEmpresa == true);
            
            if (!esModificacion)
                predicate = predicate.And(p => p.CargoModificacion == false);

            var cargosPorSoc = Session.TipoSociedadCargos.AsExpandable()
                .Where(predicate)
                .Select(tsc => tsc.CargoId)
                .ToList();

            return Session.Cargos
                    .Where(c => c.SiteVisible == true && cargosPorSoc.Contains(c.CargoId))
                    .OrderBy(c => c.Descripcion).ToList();
        }


    }
}
