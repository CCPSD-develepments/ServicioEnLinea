using System.Linq;

namespace CamaraComercio.DataAccess.EF.CamaraComun
{
    /// <summary>
    /// Repositorio de Camaras
    /// </summary>
    public class CamarasRepository : Repository<Camaras, CamaraComunEntities>
    {
        /// <summary>
        /// Constructor predeterminado
        /// </summary>
        public CamarasRepository() : base(new CamaraComunEntities())
        {
        }

        /// <summary>
        /// Obtiene una camara a partir de su security group
        /// </summary>
        /// <param name="securityGroup"></param>
        /// <returns></returns>
        public Camaras GetCamara(string securityGroup)
        {
            var camara = Session.Camaras.Where(o => o.SecurityGroup == securityGroup).FirstOrDefault();
            return camara;
        }

        /// <summary>
        /// Obtiene todas las cámaras del sistema que están activas
        /// </summary>
        /// <returns></returns>
        public IQueryable<Camaras> GetActivas()
        {
            return Session.Camaras.Where(c => c.Activa == true);
        }
    }
}
