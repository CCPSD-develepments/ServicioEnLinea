using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.SRM
{
    public class UsuarioRepository : Repository<Usuarios, CamaraSRMEntities>
    {
        /// <summary>
    /// Constructor Predeterminado
    /// </summary>
    /// <param name="camaraId">ID de la cámara</param>
    public UsuarioRepository(String camaraId)
        : base(CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId))
    {
    }

    public UsuarioRepository(CamaraSRMEntities context) : base(context) { }

    /// <summary>
    /// Obtiene el ID de un usuario a partir de su username
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public int? GetUsuarioIdByUsername(string username)
    {
        var db = this.Session;

        var usr = db.Usuarios.FirstOrDefault(u => u.NombreUsuario == username);
        return (usr != null) ? usr.UsuarioId : (int?) null;
    }
    }
}
