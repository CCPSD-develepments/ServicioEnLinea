using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace CamaraComercio.DataAccess.EF.CamaraComun
{
    /// <summary>
    /// Repositorio de ciudades
    /// </summary>
    [DataObject]
    public class CiudadesRepository : Repository<CamaraComun.Ciudades, CamaraComun.CamaraComunEntities>
    {
        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        public CiudadesRepository()
        {
        }

        /// <summary>
        /// Obtiene todas las ciudades de un pais, con las ciudades principales
        /// apareciendo en el primer lugar de la lista. 
        /// </summary>
        /// <param name="primerasCiudadesEnLista"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<CamaraComun.Ciudades> FecthInDominicanRepublic(List<Int32> primerasCiudadesEnLista, int paisID)
        {
            var dbComun = this.Session;
            var info = CultureInfo.CurrentCulture.TextInfo;

            var ciudadMain = from c in dbComun.Ciudades
                             join p in primerasCiudadesEnLista on c.CiudadId equals p
                             where c.PaisId == paisID && c.Nombre.Length > 0
                             orderby p
                             select c;

            var ciudades = from c in dbComun.Ciudades
                           where !(from x in ciudadMain
                                   select x.CiudadId).Contains(c.CiudadId) && c.PaisId == paisID && c.Nombre.Length > 0
                           orderby c.Nombre ascending
                           select c;

            var list = new List<Ciudades>();

            list.AddRange(ciudadMain.AsEnumerable().ToList());
            list.Add(new CamaraComun.Ciudades { CiudadId = 0, Nombre = "----------------------" });
            list.AddRange(ciudades.AsEnumerable().ToList());
            return list.Select(c => new CamaraComun.Ciudades { CiudadId = c.CiudadId, Nombre = info.ToTitleCase(c.Nombre), PaisId = c.PaisId, Orden = c.Orden }).ToList();
        }
    }
}
