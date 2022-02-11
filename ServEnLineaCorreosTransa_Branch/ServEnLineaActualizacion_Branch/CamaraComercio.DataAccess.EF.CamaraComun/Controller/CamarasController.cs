using System.ComponentModel;
using System.Linq;

namespace CamaraComercio.DataAccess.EF.CamaraComun
{
    /// <summary>
    /// Controlador de Camaras
    /// </summary>
    [DataObject()]
    public class CamarasController
    {
        /// <summary>
        /// Retorna la colección de cámaras activas en el sistema
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<Camaras> FetchAllActivas()
        {
            var db = new CamaraComunEntities();
            var qry = from c in db.Camaras
                      where c.ActivaOnline == true
                      select c;
            return qry;
        }

        /// <summary>
        /// Retorna la colección de cámaras activas en el sistema
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<Camaras> FetchAll()
        {
            var db = new CamaraComunEntities();
            var qry = from c in db.Camaras
                      select c;
            return qry;
        }

        /// <summary>
        /// Retorna la cámara activa indentificada con el Id pasado por parametros.
        /// </summary>
        /// <param name="id">Identificador de la cámara.</param>
        /// <returns></returns>
        public IQueryable<Camaras> FetchByID(string id)
        {
            var db = new CamaraComunEntities();
            var query = from camara in db.Camaras
                        where camara.Activa == true
                        && camara.ID == id
                        select camara;

            return query;
        }

       /// <summary>
       /// Actualiza una cámara
       /// </summary>
       /// <param name="camaraId">ID de la Cámara</param>
       /// <param name="nombre">Nombre</param>
       /// <param name="gestionId">ID en el sistema de gestión</param>
       /// <param name="RNC">RNC de la cámara</param>
       /// <param name="activa">Indica si la cámara está activa o no</param>
       /// <param name="header">Header de impresión</param>
        public static void Update(string camaraId, string nombre, int gestionId, string RNC, bool activa, string header)
        {
            //TODO: Agregar Direccion
            var db = new CamaraComunEntities();

            var camara = db.Camaras.Where(c => c.ID == camaraId).FirstOrDefault();
            camara.ID = camaraId;
            camara.Nombre = nombre;
            camara.GestionID = gestionId;
            camara.RNC = RNC;
            camara.Activa = activa;
            camara.HeaderImpresiones = header;
            db.SaveChanges();
        }

        /// <summary>
        /// Inserta una nueva cámara
        /// </summary>
        /// <param name="camaraId">ID de la Cámara</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="gestionId">ID en el sistema de gestión</param>
        /// <param name="RNC">RNC de la cámara</param>
        /// <param name="activa">Indica si la cámara está activa o no</param>
        /// <param name="header">Header de impresión</param>
        public static void Insert(string camaraId, string nombre, int gestionId, string RNC, bool activa, string header)
        {
            var camara = new Camaras()
                            {
                                ID = camaraId,
                                Nombre = nombre,
                                GestionID = gestionId,
                                RNC = RNC,
                                Activa = activa,
                                HeaderImpresiones = header
                            };
            
            var db = new CamaraComunEntities();

            db.Camaras.AddObject(camara);
            db.SaveChanges();

        }

        /// <summary>
        /// Borra una cámara de la base de datos
        /// </summary>
        /// <param name="camaraId">Id de la cámara</param>
        public static void Delete(string camaraId)
        {
            var db = new CamaraComunEntities();
            var camara = db.Camaras.Where(c => c.ID == camaraId).FirstOrDefault();

            db.Camaras.DeleteObject(camara);
            db.SaveChanges();
        }

        /// <summary>
        /// Retorna el Id del sistema de gestión de la cámara correspondiente.
        /// </summary>
        /// <param name="camaraId">Identificador de la cámara.</param>
        /// <returns></returns>
        public static int GetGestionId(string camaraId)
        {
            var db = new CamaraComunEntities();
            var camara = db.Camaras.Where(c => c.ID == camaraId).FirstOrDefault();
            return camara != null ? camara.GestionID.GetValueOrDefault(0) : 0;
        }
    }
}
