using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    /// <summary>
    /// Repositorio para facturas en la Oficina Virtual
    /// </summary>
    [DataObject]
    public class FacturaRepository : Repository<Facturas, CamaraWebsiteEntities>
    {
        ///<summary>
        /// Constructor Predeterminado
        ///</summary>
        public FacturaRepository()
            : base(new CamaraWebsiteEntities())
        {

        }

        /// <summary>
        /// Retorna el histórico de facturas para un usuario
        /// </summary>
        /// <param name="userName">Nombre de usuario</param>
        /// <param name="startRowIndex">índice de inicio</param>
        /// <param name="maximumRows">Cantidad de registros a retornar</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IEnumerable<Facturas> GetHistoricoFacturas(String userName, int startRowIndex, int maximumRows)
        {
            var db = this.Session;

            var result = (from f in db.Facturas.Include("Camaras")
                          where f.Usuario == userName
                          select f).ToList().OrderBy(f => f.Fecha).ThenBy(a => a.Estado).Skip(startRowIndex).Take(maximumRows);

            return result;
        }

        /// <summary>
        /// Cuenta la cantidad de facturas asignadas a un usuario (asiste con la paginación)
        /// </summary>
        /// <param name="userName">Nombre de usuario</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public int GetCountHistoricoFacturas(String userName)
        {
            var db = this.Session;

            var result = (from f in db.Facturas
                          where f.Usuario == userName
                          select f).Count();

            return result;
        }
    }
}