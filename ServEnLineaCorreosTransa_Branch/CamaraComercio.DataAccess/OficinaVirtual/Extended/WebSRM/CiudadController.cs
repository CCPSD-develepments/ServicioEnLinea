using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using SubSonic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public partial class CiudadController
    {
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CiudadCollection FetchByPais(int paisId)
        {
            return FetchByQuery(new Query(Ciudad.Schema).AddWhere(Ciudad.Columns.PaisId, paisId));
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CiudadCollection FecthInDominicanRepublic()
        {
            int repDomID = (int) new AppSettingsReader().GetValue("IdPaisRepDominicana", typeof (Int32));
            CiudadCollection col = FetchByQuery(new Query(Ciudad.Schema).AddWhere(Ciudad.Columns.PaisId, repDomID));
            col.Sort("Nombre", true);
            return col;
        }

        /// <summary>
        /// Obtiene todas las ciudades de un pais, con las ciudades principales
        /// apareciendo en el primer lugar de la lista. 
        /// </summary>
        /// <param name="primerasCiudadesEnLista"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CiudadCollection FecthInDominicanRepublic(List<Int32> primerasCiudadesEnLista, int paisID)
        {
            try
            {
                CiudadCollection colCiudadesMain = new Select().From(Ciudad.Schema).
                    Where(Ciudad.PaisIdColumn).IsEqualTo(paisID).
                    And(Ciudad.CiudadIdColumn).In(primerasCiudadesEnLista).ExecuteAsCollection<CiudadCollection>();
                colCiudadesMain.Sort(Ciudad.Columns.Nombre, true);

                CiudadCollection colCiudades = new Select().From(Ciudad.Schema).
                    Where(Ciudad.PaisIdColumn).IsEqualTo(paisID).
                    And(Ciudad.CiudadIdColumn).NotIn(primerasCiudadesEnLista).ExecuteAsCollection<CiudadCollection>();
                colCiudades.Sort(Ciudad.Columns.Nombre, true);

                colCiudadesMain.Add(new Ciudad {CiudadId = 0, Nombre = "----------------------"});
                colCiudadesMain.AddRange(colCiudades);
                return colCiudadesMain;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Obtiene el nombre de una ciudad a partir de su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetNombreCiudad(int id)
        {
            try
            {
                return new Select().From(Ciudad.Schema).
                    Where(Ciudad.Columns.CiudadId).IsEqualTo(id).ExecuteSingle<Ciudad>().Nombre;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}