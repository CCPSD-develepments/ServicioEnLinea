using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.CamaraComun
{
    //public class ActividadesRepository : Repository<Actividades, CamaraComunEntities>
    //{
    //    /// <summary>
    //    /// Constructor predeterminado
    //    /// </summary>
    //    public ActividadesRepository()
    //        : base(new CamaraComunEntities())
    //    {
    //    }

    //    [Obsolete("Método no completado")]
    //    public IEnumerable<ActividadDTO> ObtenerActividades()
    //    {
    //        var listado = new List<ActividadDTO>();
    //        listado.AddRange(this.Session.Actividades.Where(a => a.PadreID == null)
    //                        .Select(a => new ActividadDTO() { ActividadID = a.ActividadID, Actividad = a.Descripcion })
    //                        .ToList());

    //        var listB = new List<ActividadDTO>();
    //        foreach (ActividadDTO item in listado)
    //        {
    //            listB.AddRange(
    //                this.Session.Actividades.Where(b => b.PadreID == item.ActividadID)
    //                    .Select(a => new ActividadDTO()
    //                                     {
    //                                         ActividadID = item.ActividadID,
    //                                         Actividad = item.Actividad,
    //                                         ClasificacionID = a.ActividadID,
    //                                         Clasificacion = a.Descripcion
    //                                     })
    //                    .ToList());
    //        }

    //        listado.AddRange(listB);

    //        return listado;
    //    }

    //    ///<summary>
    //    /// Obtiene las actividades de acuerdo al padre ID
    //    ///</summary>
    //    ///<param name="padreId"></param>
    //    ///<returns></returns>
    //    public IEnumerable<Actividades> GetActividadByPadreId(int? padreId)
    //    {
    //        return this.Session.Actividades.Where(a => a.PadreID == padreId);
    //    }
    //}

    /// <summary>
    /// Representacion de la actividad
    /// </summary>
    public class ActividadDTO
    {
        public int ActividadID { get; set; }
        public string Actividad { get; set; }
        public int ClasificacionID { get; set; }
        public string Clasificacion { get; set; }
        public int SubClasificacionID { get; set; }
        public string SubClasificacion { get; set; }
        public int CategoriaID { get; set; }
        public string Categoria { get; set; }
    }
}
