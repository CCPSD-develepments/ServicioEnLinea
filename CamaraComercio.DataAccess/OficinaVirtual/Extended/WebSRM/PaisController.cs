using System;
using SubSonic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public partial class PaisController
    {
        /// <summary>
        /// Obtiene todos los paises en la base de datos, colocando el 
        /// pais deseado como predeterminado en la lista
        /// </summary>
        /// <param name="primerPaisEnlista"></param>
        /// <returns></returns>
        public PaisCollection FetchAll(int primerPaisEnlista)
        {
            PaisCollection colPaises = new PaisCollection();
            PaisCollection colRepDom = new PaisCollection();

            try
            {
                colRepDom = FetchByID(primerPaisEnlista);
                colPaises = new Select().From(Pais.Schema).
                    Where(Pais.PaisIdColumn).IsNotEqualTo(primerPaisEnlista).ExecuteAsCollection<PaisCollection>();

                colRepDom.AddRange(colPaises);
                return colRepDom;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
    }
}