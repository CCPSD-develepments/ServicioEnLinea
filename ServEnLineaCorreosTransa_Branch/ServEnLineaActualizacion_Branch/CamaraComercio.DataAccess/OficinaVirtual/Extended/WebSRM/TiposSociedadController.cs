using System;
using System.Collections.Generic;
using SubSonic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public partial class TiposSociedadController
    {
        /// <summary>
        /// Obtiene los tipos a los que se puede adecuar una empresa, a partir del tipo actual
        /// </summary>
        /// <param name="tipoEmpresaActual">ID en la base de datos del tipo de empresa actual</param>
        /// <returns></returns>
        public TiposSociedadCollection FetchPosiblesTransformaciones(int tipoEmpresaActual)
        {
            TiposSociedadCollection colTiposSociedad = new TiposSociedadCollection();
            try
            {
                List<Int32> posiblesConversiones = new List<int>();
                MatrizConversionTipoSociedadCollection colMatrizConversion =
                    new Select(MatrizConversionTipoSociedad.TipoSociedadNuevaIdColumn).
                        From("MatrizConversionTipoSociedad").Where("TipoSociedadActualId").
                        IsEqualTo(tipoEmpresaActual).ExecuteAsCollection<MatrizConversionTipoSociedadCollection>();
                foreach (MatrizConversionTipoSociedad item in colMatrizConversion)
                {
                    posiblesConversiones.Add(item.TipoSociedadNuevaId);
                }

                MatrizConversionTipoSociedadCollection colTemp = new Select().
                    From("MatrizConversionTipoSociedad").Where("TipoSociedadActualId").
                    IsEqualTo(tipoEmpresaActual).ExecuteAsCollection<MatrizConversionTipoSociedadCollection>();

                if (posiblesConversiones.Count > 0)
                {
                    colTiposSociedad = new Select().From("TiposSociedades").
                        Where("TipoSociedadId").In(posiblesConversiones).ExecuteAsCollection<TiposSociedadCollection>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return colTiposSociedad;
        }

        /// <summary>
        /// Obtiene el nombre de un tipo de sociedad a partir de su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetNombreTipoSociedad(int id)
        {
            try
            {
                return new Select().From(TiposSociedad.Schema).
                    Where(TiposSociedad.Columns.TipoSociedadId).IsEqualTo(id).ExecuteSingle<TiposSociedad>().Descripcion;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}